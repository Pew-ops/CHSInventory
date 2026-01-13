using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace CHSInventory.Nurse
{
    public partial class NurseExpire : UserControl
    {
        string connectionString =
            ConfigurationManager.ConnectionStrings["CHSInventoryDB"].ConnectionString;

        private Timer autoUpdateTimer; // Timer for auto-update

        public NurseExpire()
        {
            InitializeComponent();

            // Setup auto-update timer
            autoUpdateTimer = new Timer();
            autoUpdateTimer.Interval = 5000; // Update every 5 seconds
            autoUpdateTimer.Tick += AutoUpdateTimer_Tick;
            autoUpdateTimer.Start();

            this.Load += NurseExpire_Load;
        }

        private void NurseExpire_Load(object sender, EventArgs e)
        {
            UpdateMedicineStatus();
            LoadExpiredItems();
            LoadLowStockItems();
            LoadExpiredCount();
            LoadLowStockCount();
        }

        // 🔄 Timer Tick Event for Auto-Update
        private void AutoUpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                UpdateMedicineStatus();
                LoadExpiredCount();
                LoadLowStockCount();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Auto-update error: " + ex.Message);
            }
        }

        // 🔄 AUTO UPDATE MEDICINE STATUS
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
                    WHERE category IN ('Medicine', 'First Aid')
                      AND quantity < 50
                      AND DATE(expiration_date) > DATE_ADD(CURDATE(), INTERVAL 30 DAY)";

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

        // ================= LOAD EXPIRED ITEMS =================
        private void LoadExpiredItems()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT item_code, item_name, category, dosage, quantity,
                           batch_no, expiration_date, STATUS
                    FROM medicine_receive
                    WHERE expiration_date <= CURDATE()
                    ORDER BY expiration_date ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                datagridviewdashboard.DataSource = dt;
                datagridviewdashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        // ================= LOAD LOW STOCK ITEMS =================
        private void LoadLowStockItems()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT item_code, item_name, category, dosage, quantity,
                           batch_no, expiration_date, STATUS
                    FROM medicine_receive
                    WHERE category IN ('Medicine', 'First Aid') AND quantity <= 50
                    ORDER BY quantity ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                datagridviewdashboard.DataSource = dt;
                datagridviewdashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        // ================= COUNT EXPIRED ITEMS =================
        private void LoadExpiredCount()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT COUNT(*)
                    FROM medicine_receive
                    WHERE expiration_date <= CURDATE()";

                int count = Convert.ToInt32(new MySqlCommand(query, conn).ExecuteScalar());
                lblcountexpire.Text = count.ToString();
            }
        }

        // ================= COUNT LOW STOCK ITEMS =================
        private void LoadLowStockCount()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT COUNT(*)
                    FROM medicine_receive
                    WHERE category IN ('Medicine', 'First Aid') AND quantity <= 50";

                int count = Convert.ToInt32(new MySqlCommand(query, conn).ExecuteScalar());
                lbllowstock.Text = count.ToString();
            }
        }

        // Optional: click events to refresh
        private void lblcountexpire_Click(object sender, EventArgs e)
        {
            LoadExpiredItems();
            LoadExpiredCount();
        }

        private void lbllowstock_Click(object sender, EventArgs e)
        {
            LoadLowStockItems();
            LoadLowStockCount();
        }
    }
}
