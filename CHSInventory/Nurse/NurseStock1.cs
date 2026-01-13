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
            this.Load += NurseStock1_Load;
        }

        // ================= LOAD =================
        private void NurseStock1_Load(object sender, EventArgs e)
        {
            LoadTodayMedicineData();
        }

        // ================= LOAD TODAY ONLY =================
        private void LoadTodayMedicineData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT id, item_code, item_name, category, dosage,
                           batch_no, quantity, unit_cost,
                           expiration_date, delivery_date, supplier, status
                    FROM medicine_receive
                    WHERE DATE(delivery_date) = CURDATE()
                    ORDER BY id DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewmedicine.DataSource = dt;

                if (dataGridViewmedicine.Columns.Contains("id"))
                    dataGridViewmedicine.Columns["id"].Visible = false;

                dataGridViewmedicine.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
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
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtitemcode.Text) ||
                string.IsNullOrWhiteSpace(txtitemname.Text) ||
                string.IsNullOrWhiteSpace(txtbatch.Text))
            {
                MessageBox.Show("Item code, name, and batch are required.");
                return;
            }

            if (!int.TryParse(txtquantity.Text, out int addQuantity) || addQuantity <= 0)
            {
                MessageBox.Show("Invalid quantity.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // 🔍 CHECK SAME ITEM + SAME BATCH + SAME EXPIRATION
                    string checkQuery = @"
                SELECT id
                FROM medicine_receive
                WHERE item_code = @code
                  AND batch_no = @batch
                  AND expiration_date = @exp
                LIMIT 1";

                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn, trans);
                    checkCmd.Parameters.AddWithValue("@code", txtitemcode.Text.Trim());
                    checkCmd.Parameters.AddWithValue("@batch", txtbatch.Text.Trim());
                    checkCmd.Parameters.AddWithValue("@exp",
                        datetimepickerexpiration.Value.Date);

                    object existingId = checkCmd.ExecuteScalar();

                    if (existingId != null)
                    {
                        // ✅ SAME BATCH → ADD ONLY TO THAT BATCH
                        string updateQuery = @"
                    UPDATE medicine_receive
                    SET quantity = quantity + @qty
                    WHERE id = @id";

                        MySqlCommand updateCmd =
                            new MySqlCommand(updateQuery, conn, trans);

                        updateCmd.Parameters.AddWithValue("@qty", addQuantity);
                        updateCmd.Parameters.AddWithValue("@id",
                            Convert.ToInt32(existingId));

                        updateCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // ✅ DIFFERENT BATCH OR DATE → INSERT NEW ROW
                        MySqlCommand insertCmd =
                            new MySqlCommand("sp_add_medicine_receive", conn, trans);

                        insertCmd.CommandType = CommandType.StoredProcedure;

                        insertCmd.Parameters.AddWithValue("p_item_code", txtitemcode.Text.Trim());
                        insertCmd.Parameters.AddWithValue("p_item_name", txtitemname.Text.Trim());
                        insertCmd.Parameters.AddWithValue("p_category", cmbcategories.Text);
                        insertCmd.Parameters.AddWithValue("p_dosage", txtdosage.Text.Trim());
                        insertCmd.Parameters.AddWithValue("p_unit_cost",
                            Convert.ToDecimal(txtunitcost.Text));
                        insertCmd.Parameters.AddWithValue("p_quantity", addQuantity);
                        insertCmd.Parameters.AddWithValue("p_expiration_date",
                            datetimepickerexpiration.Value.Date);
                        insertCmd.Parameters.AddWithValue("p_delivery_date",
                            datetimepickerdelivery.Value.Date);
                        insertCmd.Parameters.AddWithValue("p_status", txtstatus.Text.Trim());
                        insertCmd.Parameters.AddWithValue("p_batch_no", txtbatch.Text.Trim());
                        insertCmd.Parameters.AddWithValue("p_supplier", txtsupplier.Text.Trim());

                        insertCmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    MessageBox.Show("Stock recorded successfully!");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            LoadTodayMedicineData();
            ClearFields();
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

        // ================= AUTO FILL (LATEST BATCH) =================
        private void Txtitemcode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtitemcode.Text))
                return;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT item_name, category, dosage, unit_cost
                    FROM medicine_receive
                    WHERE item_code=@code
                    ORDER BY delivery_date DESC
                    LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@code", txtitemcode.Text);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtitemname.Text = reader["item_name"].ToString();
                        cmbcategories.Text = reader["category"].ToString();
                        txtdosage.Text = reader["dosage"].ToString();
                        txtunitcost.Text = reader["unit_cost"].ToString();
                    }
                }
            }
        }
    }
}
