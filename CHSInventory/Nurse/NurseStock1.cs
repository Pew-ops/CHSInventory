using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

namespace CHSInventory.Nurse
{
    public partial class NurseStock1 : UserControl
    {
        string connectionString =
            ConfigurationManager.ConnectionStrings["CHSInventoryDB"].ConnectionString;

        int selectedId = -1;

        public NurseStock1()
        {
            InitializeComponent();
            dataGridViewmedicine.CellClick += dataGridViewmedicine_CellClick;
            txtitemcode.Leave += Txtitemcode_Leave;
        }

        private void NurseStock1_Load(object sender, EventArgs e)
        {
            // 👉 SHOW ONLY TODAY'S ADDED MEDICINE
            LoadTodayMedicineData();
        }

        // ================= LOAD TODAY ONLY =================
      
        private void LoadTodayMedicineData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"SELECT *
                         FROM medicine_receive
                         WHERE DATE(delivery_date) = CURDATE()
                         ORDER BY id DESC"; // use delivery_date instead of created_at

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewmedicine.DataSource = dt;

                // Hide the ID column
                if (dataGridViewmedicine.Columns.Contains("id"))
                    dataGridViewmedicine.Columns["id"].Visible = false;
            }
        }


        // ================= CELL CLICK =================
        private void dataGridViewmedicine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridViewmedicine.Rows[e.RowIndex];

            selectedId = Convert.ToInt32(row.Cells["id"].Value);

            txtitemcode.Text = row.Cells["item_code"].Value.ToString();
            txtitemname.Text = row.Cells["item_name"].Value.ToString();
            cmbcategories.Text = row.Cells["category"].Value.ToString();
            txtdosage.Text = row.Cells["dosage"].Value.ToString();
            txtunitcost.Text = row.Cells["unit_cost"].Value.ToString();
            txtquantity.Text = row.Cells["quantity"].Value.ToString();
            datetimepickerexpiration.Value =
                Convert.ToDateTime(row.Cells["expiration_date"].Value);
            datetimepickerdelivery.Value =
                Convert.ToDateTime(row.Cells["delivery_date"].Value);
            txtstatus.Text = row.Cells["status"].Value.ToString();
            txtbatch.Text = row.Cells["batch_no"].Value.ToString();
            txtsupplier.Text = row.Cells["supplier"].Value.ToString();
        }

        // ================= ADD =================
        // ================= ADD =================
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtitemcode.Text) ||
                string.IsNullOrWhiteSpace(txtitemname.Text))
            {
                MessageBox.Show("Item code and name are required.");
                return;
            }

            int addQuantity = Convert.ToInt32(txtquantity.Text);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // ✅ Check if batch already exists for this item
                string checkBatchQuery = @"SELECT id 
                                   FROM medicine_receive
                                   WHERE item_code=@code AND batch_no=@batch
                                   LIMIT 1";

                MySqlCommand checkBatchCmd = new MySqlCommand(checkBatchQuery, conn);
                checkBatchCmd.Parameters.AddWithValue("@code", txtitemcode.Text);
                checkBatchCmd.Parameters.AddWithValue("@batch", txtbatch.Text);

                object result = checkBatchCmd.ExecuteScalar();

                if (result != null)
                {
                    // Batch exists -> update quantity for that batch
                    int existingId = Convert.ToInt32(result);

                    string updateQuery = @"UPDATE medicine_receive
                                   SET quantity = quantity + @qty
                                   WHERE id=@id";

                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@qty", addQuantity);
                    updateCmd.Parameters.AddWithValue("@id", existingId);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Existing batch quantity updated!");
                }
                else
                {
                    // New batch -> insert new record
                    MySqlCommand cmd = new MySqlCommand("sp_add_medicine_receive", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_item_code", txtitemcode.Text);
                    cmd.Parameters.AddWithValue("p_item_name", txtitemname.Text);
                    cmd.Parameters.AddWithValue("p_category", cmbcategories.Text);
                    cmd.Parameters.AddWithValue("p_dosage", txtdosage.Text);
                    cmd.Parameters.AddWithValue("p_unit_cost", Convert.ToDecimal(txtunitcost.Text));
                    cmd.Parameters.AddWithValue("p_quantity", addQuantity);
                    cmd.Parameters.AddWithValue("p_expiration_date", datetimepickerexpiration.Value);
                    cmd.Parameters.AddWithValue("p_delivery_date", datetimepickerdelivery.Value); // use actual delivery date
                    cmd.Parameters.AddWithValue("p_status", txtstatus.Text);
                    cmd.Parameters.AddWithValue("p_batch_no", txtbatch.Text);
                    cmd.Parameters.AddWithValue("p_supplier", txtsupplier.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("New batch added successfully!");
                }

                LoadTodayMedicineData();
                ClearFields();
            }
        }


        // ================= DELETE =================
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Select a record first.");
                return;
            }

            if (MessageBox.Show("Delete this medicine?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd =
                    new MySqlCommand("DELETE FROM medicine_receive WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", selectedId);
                cmd.ExecuteNonQuery();
            }

            LoadTodayMedicineData();
            ClearFields();
        }

        // ================= CLEAR =================
        private void ClearFields()
        {
            txtitemcode.Clear();
            txtitemname.Clear();
            cmbcategories.SelectedIndex = -1;
            txtdosage.Clear();
            txtunitcost.Clear();
            txtquantity.Clear();
            txtstatus.Clear();
            txtbatch.Clear();
            txtsupplier.Clear();
            selectedId = -1;
        }

        // ================= AUTO FILL =================
        private void Txtitemcode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtitemcode.Text))
                return;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // Only get the latest batch for this item code
                string queryLatest = @"
            SELECT item_name, category, dosage, unit_cost, batch_no, quantity, expiration_date, delivery_date
            FROM medicine_receive
            WHERE item_code=@code
            ORDER BY delivery_date DESC
            LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(queryLatest, conn);
                cmd.Parameters.AddWithValue("@code", txtitemcode.Text);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtitemname.Text = reader["item_name"].ToString();
                        cmbcategories.Text = reader["category"].ToString();
                        txtdosage.Text = reader["dosage"].ToString();
                        txtunitcost.Text = reader["unit_cost"].ToString();
                        txtbatch.Text = reader["batch_no"].ToString();
                        txtquantity.Text = reader["quantity"].ToString();
                        datetimepickerexpiration.Value = Convert.ToDateTime(reader["expiration_date"]);
                        datetimepickerdelivery.Value = Convert.ToDateTime(reader["delivery_date"]);
                    }
                }

                // ✅ Do NOT overwrite the grid here
                // If you want to show all batches, call a separate button / method
                // LoadAllBatchesForItem(txtitemcode.Text); // optional
            }
        }

    }
}
