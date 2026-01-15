using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace CHSInventory.Nurse
{
    public partial class NurseDashboard : UserControl
    {
        private InventoryManager inventoryManager;
        private Timer autoUpdateTimer;

        public NurseDashboard()
        {
            InitializeComponent();
            inventoryManager = new InventoryManager();

            // Setup auto-update timer
            autoUpdateTimer = new Timer();
            autoUpdateTimer.Interval = 5000; // Update every 5 seconds
            autoUpdateTimer.Tick += AutoUpdateTimer_Tick;
            autoUpdateTimer.Start();
        }

        private void NurseDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                // Update medicine status first
                inventoryManager.UpdateMedicineStatus();

                // Load all data
                LoadAllMedicines();
                LoadTotalMedicine();
                LoadNearlyExpiredCount();
                LoadMonthlyPatientCount();
                LoadLowStockCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= AUTO-UPDATE TIMER =================
        private void AutoUpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                inventoryManager.UpdateMedicineStatus();
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

        // ================= DISPLAY ALL MEDICINES =================
        private void LoadAllMedicines()
        {
            try
            {
                DataTable dt = inventoryManager.GetAllDashboardMedicines();
                datagridviewdashboard.DataSource = dt;
                datagridviewdashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading medicines: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= TOTAL MEDICINE COUNT =================
        private void LoadTotalMedicine()
        {
            try
            {
                int total = inventoryManager.GetTotalMedicineCountDashboard();
                lbltotalmedicine.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading total medicine count: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= SEARCH BY BATCH OR ITEM NAME =================
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtsearch.Text.Trim();
                DataTable dt = inventoryManager.SearchDashboardMedicines(searchText);
                datagridviewdashboard.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching medicines: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // ================= NEARLY EXPIRED =================
        private void lblcountexpire_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = inventoryManager.GetNearlyExpiredMedicinesDashboard();
                datagridviewdashboard.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading nearly expired medicines: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadNearlyExpiredCount()
        {
            try
            {
                int count = inventoryManager.GetNearlyExpiredCountDashboard();
                lblcountexpire.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading nearly expired count: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= MONTHLY PATIENTS =================
        private void lblpatient_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = inventoryManager.GetMonthlyPatientsDashboard();
                datagridviewdashboard.DataSource = dt;
                datagridviewdashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading monthly patients: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMonthlyPatientCount()
        {
            try
            {
                int total = inventoryManager.GetMonthlyPatientCountDashboard();
                lblpatient.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading monthly patient count: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= LOW STOCK =================
        private void lbllowstock_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = inventoryManager.GetLowStockMedicinesDashboard();
                datagridviewdashboard.DataSource = dt;
                datagridviewdashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading low stock medicines: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLowStockCount()
        {
            try
            {
                int count = inventoryManager.GetLowStockCountDashboard();
                lbllowstock.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading low stock count: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= CLEANUP =================
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Stop and dispose the timer
                if (autoUpdateTimer != null)
                {
                    autoUpdateTimer.Stop();
                    autoUpdateTimer.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}