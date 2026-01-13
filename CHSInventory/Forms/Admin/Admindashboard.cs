using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace CHSInventory
{
    public partial class Admindashboard : UserControl
    {
        string connectionString =
            ConfigurationManager.ConnectionStrings["CHSInventoryDB"].ConnectionString;

        public Admindashboard()
        {
            InitializeComponent();
            this.Load += Admindashboard_Load; // Ensure the Load event triggers
        }

        private void Admindashboard_Load(object sender, EventArgs e)
        {
            UpdateMedicineStatus();
            LoadAllMedicines();
            LoadTotalMedicine();
            LoadNearlyExpiredCount();
            LoadMonthlyPatientCount();
            LoadLowStockCount();
        }

        // ================= DISPLAY ALL MEDICINES =================
        private void LoadAllMedicines()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT item_code, item_name, category, dosage, quantity,
                           batch_no, expiration_date, STATUS
                    FROM medicine_receive
                    ORDER BY expiration_date ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                datagridviewadmin.DataSource = dt;
                datagridviewadmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void lbltotalmedicine_Click(object sender, EventArgs e)
        {
            LoadAllMedicines();
            LoadTotalMedicine();
        }

        // ================= TOTAL MEDICINE COUNT =================
        private void LoadTotalMedicine()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM medicine_receive";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                int total = Convert.ToInt32(cmd.ExecuteScalar());
                lbltotalmedicine.Text = total.ToString();
            }
        }

        // ================= SEARCH MEDICINE =================
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT item_code, item_name, category, dosage, quantity,
                           batch_no, expiration_date, STATUS
                    FROM medicine_receive
                    WHERE item_name LIKE @search
                       OR batch_no LIKE @search
                    ORDER BY expiration_date ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@search", txtsearch.Text.Trim() + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                datagridviewadmin.DataSource = dt;
            }
        }

        // ================= NEARLY EXPIRED =================
        private void lblnearlyexpired_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT item_code, item_name, category, dosage, quantity,
                           batch_no, expiration_date, STATUS
                    FROM medicine_receive
                    WHERE expiration_date 
                          BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 30 DAY)
                    ORDER BY expiration_date ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                datagridviewadmin.DataSource = dt;
            }
        }

        private void LoadNearlyExpiredCount()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT COUNT(*)
                    FROM medicine_receive
                    WHERE expiration_date 
                          BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 30 DAY)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                lblnearlyexpired.Text = count.ToString();
            }
        }

        // ================= MONTHLY PATIENT COUNT =================
        private void lblpatients_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT student_id, student_name, program, complain, nurse_assigned, dispense_date
                    FROM medicine_dispense
                    WHERE MONTH(dispense_date) = MONTH(CURDATE())
                      AND YEAR(dispense_date) = YEAR(CURDATE())
                    ORDER BY dispense_date ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                datagridviewadmin.DataSource = dt;
                datagridviewadmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void LoadMonthlyPatientCount()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT COUNT(*)
                    FROM medicine_dispense
                    WHERE MONTH(dispense_date) = MONTH(CURDATE())
                      AND YEAR(dispense_date) = YEAR(CURDATE())";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                int total = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                lblpatients.Text = total.ToString();
            }
        }

        // ================= LOW STOCK =================
        private void lblstock_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string selectQuery = @"
                    SELECT item_code, item_name, category, dosage, quantity,
                           batch_no, expiration_date, STATUS
                    FROM medicine_receive
                    WHERE category = 'Medicine' AND quantity <= 50
                    ORDER BY quantity ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(selectQuery, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                datagridviewadmin.DataSource = dt;
                datagridviewadmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                string countQuery = @"
                    SELECT COUNT(*)
                    FROM medicine_receive
                    WHERE category = 'Medicine' AND quantity <= 50";

                int lowStockCount = Convert.ToInt32(new MySqlCommand(countQuery, conn).ExecuteScalar());
                lblstock.Text = lowStockCount.ToString();
            }
        }

        private void LoadLowStockCount()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT COUNT(*)
                    FROM medicine_receive
                    WHERE category = 'Medicine' AND quantity <= 50";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                lblstock.Text = count.ToString();
            }
        }

        // ================= AUTO UPDATE MEDICINE STATUS =================
        private void UpdateMedicineStatus()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string expiredQuery = @"
                    UPDATE medicine_receive
                    SET STATUS = 'Expired'
                    WHERE DATE(expiration_date) <= CURDATE()";

                string nearlyExpiredQuery = @"
                    UPDATE medicine_receive
                    SET STATUS = 'Nearly Expired'
                    WHERE DATE(expiration_date) > CURDATE()
                      AND DATE(expiration_date) <= DATE_ADD(CURDATE(), INTERVAL 30 DAY)";

                string lowStockQuery = @"
                    UPDATE medicine_receive
                    SET STATUS = 'Low Stock'
                    WHERE quantity <= 50
                      AND DATE(expiration_date) > DATE_ADD(CURDATE(), INTERVAL 30 DAY)";

                string availableQuery = @"
                    UPDATE medicine_receive
                    SET STATUS = 'Available'
                    WHERE quantity > 50
                      AND DATE(expiration_date) > DATE_ADD(CURDATE(), INTERVAL 30 DAY)";

                string updateCategoryQuery = @"
                    UPDATE medicine_receive
                    SET category = 'Medicine'
                    WHERE DATE(expiration_date) <= DATE_ADD(CURDATE(), INTERVAL 30 DAY)";

                new MySqlCommand(expiredQuery, conn).ExecuteNonQuery();
                new MySqlCommand(nearlyExpiredQuery, conn).ExecuteNonQuery();
                new MySqlCommand(lowStockQuery, conn).ExecuteNonQuery();
                new MySqlCommand(availableQuery, conn).ExecuteNonQuery();
                new MySqlCommand(updateCategoryQuery, conn).ExecuteNonQuery();
            }
        }
    }
}
