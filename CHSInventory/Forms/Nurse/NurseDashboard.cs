using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace CHSInventory.Nurse
{
    public partial class NurseDashboard : UserControl
    {
        string connectionString =
            ConfigurationManager.ConnectionStrings["CHSInventoryDB"].ConnectionString;

        private Timer autoUpdateTimer; // Timer for auto-update

        public NurseDashboard()
        {
            InitializeComponent();

            // Setup auto-update timer
            autoUpdateTimer = new Timer();
            autoUpdateTimer.Interval = 5000; // Update every 5 seconds
            autoUpdateTimer.Tick += AutoUpdateTimer_Tick;
            autoUpdateTimer.Start();
        }

        private void NurseDashboard_Load(object sender, EventArgs e)
        {
            UpdateMedicineStatus();   // 🔴 update once
            LoadAllMedicines();       // 👁 read only
            LoadTotalMedicine();
            LoadNearlyExpiredCount();
            LoadMonthlyPatientCount();
            LoadLowStockCount();

        }

        // 🔄 Timer Tick Event for Auto-Update
        private void AutoUpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                UpdateMedicineStatus();
                LoadTotalMedicine();
                LoadNearlyExpiredCount();
                LoadMonthlyPatientCount();
                LoadLowStockCount();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Auto-update error: " + ex.Message);
            }
        }

        // ✅ DISPLAY ALL MEDICINES
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

                datagridviewdashboard.DataSource = dt;
                datagridviewdashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        // ✅ TOTAL MEDICINE COUNT
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

        // ✅ SEARCH BY BATCH OR ITEM NAME
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
                datagridviewdashboard.DataSource = dt;
            }
        }

        private void datagridviewdashboard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: select row or show details
        }

        private void lbltotalmedicine_Click(object sender, EventArgs e)
        {
            LoadAllMedicines();
            LoadTotalMedicine();
        }

        private void lblcountexpire_Click(object sender, EventArgs e)
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

                datagridviewdashboard.DataSource = dt;
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
                lblcountexpire.Text = count.ToString();
            }
        }

        private void lblpatient_Click(object sender, EventArgs e)
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

                datagridviewdashboard.DataSource = dt;
                datagridviewdashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

                lblpatient.Text = total.ToString();
            }
        }

        private void lbllowstock_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string selectQuery = @"
            SELECT item_code, item_name, category, dosage, quantity,
                   batch_no, expiration_date, STATUS
            FROM medicine_receive
            WHERE category IN ('Medicine', 'First Aid') AND quantity <= 50
            ORDER BY quantity ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(selectQuery, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                datagridviewdashboard.DataSource = dt;
                datagridviewdashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                string countQuery = @"
            SELECT COUNT(*)
            FROM medicine_receive
            WHERE category IN ('Medicine', 'First Aid') AND quantity <= 50";

                int lowStockCount = Convert.ToInt32(new MySqlCommand(countQuery, conn).ExecuteScalar());
                lbllowstock.Text = lowStockCount.ToString();
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
            WHERE category IN ('Medicine', 'First Aid') AND quantity <= 50";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                lbllowstock.Text = count.ToString();
            }
        }

        // 🔄 AUTO UPDATE MEDICINE STATUS
        private void UpdateMedicineStatus()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // 1️⃣ EXPIRED (highest priority)
                string expiredQuery = @"
            UPDATE medicine_receive
            SET STATUS = 'Expired'
            WHERE DATE(expiration_date) <= CURDATE()";

                // 2️⃣ NEARLY EXPIRED
                string nearlyExpiredQuery = @"
            UPDATE medicine_receive
            SET STATUS = 'Nearly Expired'
            WHERE DATE(expiration_date) > CURDATE()
              AND DATE(expiration_date) <= DATE_ADD(CURDATE(), INTERVAL 30 DAY)";

                // 3️⃣ LOW STOCK (Medicine & First Aid only)
                string lowStockQuery = @"
            UPDATE medicine_receive
            SET STATUS = 'Low Stock'
            WHERE category IN ('Medicine', 'First Aid')   -- 🔴 change if DB uses different name
              AND quantity < 50
              AND DATE(expiration_date) > DATE_ADD(CURDATE(), INTERVAL 30 DAY)";

                // 4️⃣ AVAILABLE
                string availableQuery = @"
            UPDATE medicine_receive
            SET STATUS = 'Available'
            WHERE quantity >= 50
              AND DATE(expiration_date) > DATE_ADD(CURDATE(), INTERVAL 30 DAY)";

                new MySqlCommand(expiredQuery, conn).ExecuteNonQuery();
                new MySqlCommand(nearlyExpiredQuery, conn).ExecuteNonQuery();
                new MySqlCommand(lowStockQuery, conn).ExecuteNonQuery();
                new MySqlCommand(availableQuery, conn).ExecuteNonQuery();
            }
        }

    }
}
