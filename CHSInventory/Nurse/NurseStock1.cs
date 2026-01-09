using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

namespace CHSInventory.Nurse
{
    public partial class NurseStock1 : UserControl
    {
        string connectionString = ConfigurationManager
            .ConnectionStrings["CHSInventoryDB"].ConnectionString;

        int selectedId = -1;

        public NurseStock1()
        {
            InitializeComponent();
            dataGridViewmedicine.CellClick += dataGridViewmedicine_CellClick;
        }

        private void NurseStock1_Load(object sender, EventArgs e)
        {
            LoadMedicineData();
        }

        // ================= LOAD DATA =================
        private void LoadMedicineData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter da =
                    new MySqlDataAdapter("SELECT * FROM medicine_receive", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridViewmedicine.DataSource = dt;
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
        private void btnadd_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                MySqlCommand cmd =
                    new MySqlCommand("sp_add_medicine_receive", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_item_code", txtitemcode.Text);
                cmd.Parameters.AddWithValue("p_item_name", txtitemname.Text);
                cmd.Parameters.AddWithValue("p_category", cmbcategories.Text);
                cmd.Parameters.AddWithValue("p_dosage", txtdosage.Text);
                cmd.Parameters.AddWithValue("p_unit_cost",
                    Convert.ToDecimal(txtunitcost.Text));
                cmd.Parameters.AddWithValue("p_quantity",
                    Convert.ToInt32(txtquantity.Text));
                cmd.Parameters.AddWithValue("p_expiration_date",
                    datetimepickerexpiration.Value);
                cmd.Parameters.AddWithValue("p_delivery_date",
                    datetimepickerdelivery.Value);
                cmd.Parameters.AddWithValue("p_status", txtstatus.Text);
                cmd.Parameters.AddWithValue("p_batch_no", txtbatch.Text);
                cmd.Parameters.AddWithValue("p_supplier", txtsupplier.Text);

                cmd.ExecuteNonQuery();
            }

            LoadMedicineData();
            ClearFields();
        }

        // ================= UPDATE =================
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Please select a record to update.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"UPDATE medicine_receive SET
                    item_code=@code,
                    item_name=@name,
                    category=@category,
                    dosage=@dosage,
                    unit_cost=@cost,
                    quantity=@qty,
                    expiration_date=@exp,
                    delivery_date=@del,
                    status=@status,
                    batch_no=@batch,
                    supplier=@supplier
                    WHERE id=@id";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@code", txtitemcode.Text);
                cmd.Parameters.AddWithValue("@name", txtitemname.Text);
                cmd.Parameters.AddWithValue("@category", cmbcategories.Text);
                cmd.Parameters.AddWithValue("@dosage", txtdosage.Text);
                cmd.Parameters.AddWithValue("@cost",
                    Convert.ToDecimal(txtunitcost.Text));
                cmd.Parameters.AddWithValue("@qty",
                    Convert.ToInt32(txtquantity.Text));
                cmd.Parameters.AddWithValue("@exp",
                    datetimepickerexpiration.Value);
                cmd.Parameters.AddWithValue("@del",
                    datetimepickerdelivery.Value);
                cmd.Parameters.AddWithValue("@status", txtstatus.Text);
                cmd.Parameters.AddWithValue("@batch", txtbatch.Text);
                cmd.Parameters.AddWithValue("@supplier", txtsupplier.Text);
                cmd.Parameters.AddWithValue("@id", selectedId);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Medicine updated successfully!");
            LoadMedicineData();
            ClearFields();
        }

        // ================= DELETE =================
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            if (MessageBox.Show("Delete this medicine?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                MySqlCommand cmd =
                    new MySqlCommand(
                        "DELETE FROM medicine_receive WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", selectedId);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Medicine deleted.");
            LoadMedicineData();
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
    }
}
