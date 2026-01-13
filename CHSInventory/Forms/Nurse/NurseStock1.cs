using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CHSInventory.Nurse
{
    public partial class NurseStock1 : UserControl
    {
        private MedicalItemManager medicalItemManager;
        private int selectedId = -1;
        private string connectionString = System.Configuration.ConfigurationManager
            .ConnectionStrings["CHSInventoryDB"].ConnectionString;

     
        public NurseStock1()
        {
            InitializeComponent();
            medicalItemManager = new MedicalItemManager();

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
            DataTable dt = medicalItemManager.GetTodayMedicineData();
            dataGridViewmedicine.DataSource = dt;

            if (dataGridViewmedicine.Columns.Contains("id"))
                dataGridViewmedicine.Columns["id"].Visible = false;

            dataGridViewmedicine.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
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
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtitemcode.Text) ||
                string.IsNullOrWhiteSpace(txtitemname.Text) ||
                string.IsNullOrWhiteSpace(txtbatch.Text))
            {
                MessageBox.Show("Item code, name, and batch are required.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtquantity.Text, out int addQuantity) || addQuantity <= 0)
            {
                MessageBox.Show("Invalid quantity.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtunitcost.Text, out decimal unitCost))
            {
                MessageBox.Show("Invalid unit cost.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                medicalItemManager.AddMedicineWithBatchCheck(
                    itemCode: txtitemcode.Text.Trim(),
                    itemName: txtitemname.Text.Trim(),
                    category: cmbcategories.Text,
                    dosage: txtdosage.Text.Trim(),
                    unitCost: unitCost,
                    quantity: addQuantity,
                    expirationDate: datetimepickerexpiration.Value.Date,
                    deliveryDate: datetimepickerdelivery.Value.Date,
                    status: txtstatus.Text.Trim(),
                    batchNo: txtbatch.Text.Trim(),
                    supplier: txtsupplier.Text.Trim()
                );

                MessageBox.Show("Stock recorded successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadTodayMedicineData();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ================= DELETE =================
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Select a record first.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Delete this medicine?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                int rowsAffected = medicalItemManager.DeleteMedicineById(selectedId);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Medicine deleted successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadTodayMedicineData();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("No record was deleted.",
                        "Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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

        // ================= AUTO FILL (LATEST BATCH) =================
        private void Txtitemcode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtitemcode.Text))
                return;

            try
            {
                MedicineInfo info = medicalItemManager.GetMedicineInfoByCode(
                    txtitemcode.Text.Trim());

                if (info != null)
                {
                    txtitemname.Text = info.ItemName;
                    cmbcategories.Text = info.Category;
                    txtdosage.Text = info.Dosage;
                    txtunitcost.Text = info.UnitCost.ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching medicine info: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Select a record first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"UPDATE medicine_receive
                                   SET item_code = @item_code,
                                       item_name = @item_name,
                                       category = @category,
                                       dosage = @dosage,
                                       unit_cost = @unit_cost,
                                       quantity = @quantity,
                                       expiration_date = @expiration_date,
                                       delivery_date = @delivery_date,
                                       status = @status,
                                       batch_no = @batch_no,
                                       supplier = @supplier
                                   WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        cmd.Parameters.AddWithValue("@item_code", txtitemcode.Text.Trim());
                        cmd.Parameters.AddWithValue("@item_name", txtitemname.Text.Trim());
                        cmd.Parameters.AddWithValue("@category", cmbcategories.Text.Trim());
                        cmd.Parameters.AddWithValue("@dosage", txtdosage.Text.Trim());
                        cmd.Parameters.AddWithValue("@unit_cost", decimal.Parse(txtunitcost.Text));
                        cmd.Parameters.AddWithValue("@quantity", int.Parse(txtquantity.Text));
                        cmd.Parameters.AddWithValue("@expiration_date", datetimepickerexpiration.Value.Date);
                        cmd.Parameters.AddWithValue("@delivery_date", datetimepickerdelivery.Value.Date);
                        cmd.Parameters.AddWithValue("@status", txtstatus.Text.Trim());
                        cmd.Parameters.AddWithValue("@batch_no", txtbatch.Text.Trim());
                        cmd.Parameters.AddWithValue("@supplier", txtsupplier.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Medicine updated successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadTodayMedicineData();
                            ClearFields();
                        }
                        else
                        {
                            MessageBox.Show("No record was updated.",
                                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //this update
        }
    }
}
