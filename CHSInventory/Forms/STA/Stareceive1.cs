using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

namespace CHSInventory.STA
{
    public partial class Stareceive1 : UserControl
    {
        private string connectionString = ConfigurationManager
            .ConnectionStrings["CHSInventoryDB"].ConnectionString;

        private int selectedId = -1;

        public Stareceive1()
        {
            InitializeComponent();

            dataGridViewmedicine.CellClick += DataGridViewmedicine_CellClick;
            txtitemcode.Leave += Txtitemcode_Leave;
            this.Load += Stareceive1_Load;
        }

        // ================= LOAD =================
        private void Stareceive1_Load(object sender, EventArgs e)
        {
            LoadTodayMedicineData();
        }

        // ================= LOAD TODAY =================
        private void LoadTodayMedicineData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"SELECT * FROM medicine_receive WHERE DATE(delivery_date) = CURDATE()";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewmedicine.DataSource = dt;

                if (dataGridViewmedicine.Columns.Contains("id"))
                    dataGridViewmedicine.Columns["id"].Visible = false;

                dataGridViewmedicine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        // ================= CELL CLICK =================
        private void DataGridViewmedicine_CellClick(object sender, DataGridViewCellEventArgs e)
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
            datetimepickerexpiration.Value = Convert.ToDateTime(row.Cells["expiration_date"].Value);
            datetimepickerdelivery.Value = Convert.ToDateTime(row.Cells["delivery_date"].Value);
            txtstatus.Text = row.Cells["status"].Value.ToString();
            txtbatch.Text = row.Cells["batch_no"].Value.ToString();
            txtsupplier.Text = row.Cells["supplier"].Value.ToString();
        }

        // ================= ADD =================
        private void btnadd_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtitemcode.Text) ||
                string.IsNullOrWhiteSpace(txtitemname.Text) ||
                string.IsNullOrWhiteSpace(txtbatch.Text))
            {
                MessageBox.Show("Item code, name, and batch are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtquantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Invalid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtunitcost.Text, out decimal unitCost))
            {
                MessageBox.Show("Invalid unit cost.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"INSERT INTO medicine_receive
                                   (item_code, item_name, category, dosage, unit_cost, quantity, expiration_date, delivery_date, status, batch_no, supplier)
                                   VALUES
                                   (@code, @name, @category, @dosage, @unit_cost, @qty, @exp, @del, @status, @batch, @supplier)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@code", txtitemcode.Text.Trim());
                        cmd.Parameters.AddWithValue("@name", txtitemname.Text.Trim());
                        cmd.Parameters.AddWithValue("@category", cmbcategories.Text.Trim());
                        cmd.Parameters.AddWithValue("@dosage", txtdosage.Text.Trim());
                        cmd.Parameters.AddWithValue("@unit_cost", unitCost);
                        cmd.Parameters.AddWithValue("@qty", quantity);
                        cmd.Parameters.AddWithValue("@exp", datetimepickerexpiration.Value.Date);
                        cmd.Parameters.AddWithValue("@del", datetimepickerdelivery.Value.Date);
                        cmd.Parameters.AddWithValue("@status", txtstatus.Text.Trim());
                        cmd.Parameters.AddWithValue("@batch", txtbatch.Text.Trim());
                        cmd.Parameters.AddWithValue("@supplier", txtsupplier.Text.Trim());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Medicine added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadTodayMedicineData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding medicine: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= UPDATE =================
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Select a record first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"UPDATE medicine_receive SET
                                   item_code=@code,
                                   item_name=@name,
                                   category=@category,
                                   dosage=@dosage,
                                   unit_cost=@unit_cost,
                                   quantity=@qty,
                                   expiration_date=@exp,
                                   delivery_date=@del,
                                   status=@status,
                                   batch_no=@batch,
                                   supplier=@supplier
                                   WHERE id=@id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@code", txtitemcode.Text.Trim());
                        cmd.Parameters.AddWithValue("@name", txtitemname.Text.Trim());
                        cmd.Parameters.AddWithValue("@category", cmbcategories.Text.Trim());
                        cmd.Parameters.AddWithValue("@dosage", txtdosage.Text.Trim());
                        cmd.Parameters.AddWithValue("@unit_cost", decimal.Parse(txtunitcost.Text));
                        cmd.Parameters.AddWithValue("@qty", int.Parse(txtquantity.Text));
                        cmd.Parameters.AddWithValue("@exp", datetimepickerexpiration.Value.Date);
                        cmd.Parameters.AddWithValue("@del", datetimepickerdelivery.Value.Date);
                        cmd.Parameters.AddWithValue("@status", txtstatus.Text.Trim());
                        cmd.Parameters.AddWithValue("@batch", txtbatch.Text.Trim());
                        cmd.Parameters.AddWithValue("@supplier", txtsupplier.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", selectedId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Medicine updated successfully!" : "No record was updated.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadTodayMedicineData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= DELETE =================
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Select a record first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Delete this medicine?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "DELETE FROM medicine_receive WHERE id=@id";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show(rowsAffected > 0 ? "Medicine deleted successfully!" : "No record deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadTodayMedicineData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        // ================= AUTO FILL LATEST BATCH =================
        private void Txtitemcode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtitemcode.Text)) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT * FROM medicine_receive
                                   WHERE item_code=@code
                                   ORDER BY delivery_date DESC
                                   LIMIT 1";
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@code", txtitemcode.Text.Trim());
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtitemname.Text = reader["item_name"].ToString();
                                cmbcategories.Text = reader["category"].ToString();
                                txtdosage.Text = reader["dosage"].ToString();
                                txtunitcost.Text = Convert.ToDecimal(reader["unit_cost"]).ToString("0.00");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching medicine info: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewmedicine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
