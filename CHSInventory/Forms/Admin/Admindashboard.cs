using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace CHSInventory
{
    public partial class Admindashboard : UserControl
    {
        private InventoryManager inventoryManager;

        public Admindashboard()
        {
            InitializeComponent();
            inventoryManager = new InventoryManager();
            this.Load += Admindashboard_Load;
        }

        private void Admindashboard_Load(object sender, EventArgs e)
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

        // ================= DISPLAY ALL MEDICINES =================
        private void LoadAllMedicines()
        {
            try
            {
                DataTable dt = inventoryManager.GetAllDashboardMedicines();
                datagridviewadmin.DataSource = dt;
                datagridviewadmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading medicines: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // ================= SEARCH MEDICINE =================
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtsearch.Text.Trim();
                DataTable dt = inventoryManager.SearchDashboardMedicines(searchText);
                datagridviewadmin.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching medicines: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= NEARLY EXPIRED =================
        private void lblnearlyexpired_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = inventoryManager.GetNearlyExpiredMedicinesDashboard();
                datagridviewadmin.DataSource = dt;
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
                lblnearlyexpired.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading nearly expired count: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= MONTHLY PATIENT COUNT =================
        private void lblpatients_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = inventoryManager.GetMonthlyPatientsDashboard();
                datagridviewadmin.DataSource = dt;
                datagridviewadmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                lblpatients.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading monthly patient count: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= LOW STOCK =================
        private void lblstock_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = inventoryManager.GetLowStockMedicinesDashboard();
                datagridviewadmin.DataSource = dt;
                datagridviewadmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Update count after loading data
                LoadLowStockCount();
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
                lblstock.Text = count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading low stock count: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}