using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CHSInventory.Forms.STA
{
    public partial class staDisposal : UserControl
    {
        private string connectionString = System.Configuration.ConfigurationManager
            .ConnectionStrings["CHSInventoryDB"].ConnectionString;

        public staDisposal()
        {
            InitializeComponent();
            LoadDisposedItems();
        }

        // ================= LOAD DISPOSED ITEMS =================
        private void LoadDisposedItems()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM disposed_items ORDER BY disposed_at DESC";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridViewdisposal.DataSource = dt;
                    dataGridViewdisposal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading disposed items: " + ex.Message);
            }
        }

        // ================= SEARCH =================
        
    }
}
