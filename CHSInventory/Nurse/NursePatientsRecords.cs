using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace CHSInventory.Nurse
{
    public partial class NursePatientsRecords : UserControl
    {
        private string connStr =
            ConfigurationManager.ConnectionStrings["CHSInventoryDB"].ConnectionString;

        public NursePatientsRecords()
        {
            InitializeComponent();

            // ✅ Load data when control is created
            this.Load += NursePatientsRecords_Load;

            // (Optional safety net)
            this.VisibleChanged += NursePatientsRecords_VisibleChanged;
        }

        // 🔥 MAIN FIX — ALWAYS LOAD ON FIRST OPEN
        private void NursePatientsRecords_Load(object sender, EventArgs e)
        {
            LoadAllPatients();
        }

        // 🛡 Backup in case control is hidden/shown again
        private void NursePatientsRecords_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && datagridpatientsrecord.DataSource == null)
            {
                LoadAllPatients();
            }
        }

        // 🔍 SEARCH
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtsearch.Text))
            {
                LoadAllPatients();
            }
            else
            {
                LoadPatientHistory(txtsearch.Text.Trim());
            }
        }

        // ✅ LOAD ALL PATIENTS
        private void LoadAllPatients()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                string query = @"
            SELECT 
                md.id,
                md.student_id,
                md.student_name,
                md.program,
                md.complain,
                md.nurse_assigned,
                md.dispense_date,
                GROUP_CONCAT(
                    CONCAT(mdi.item_name, ' (', mdi.quantity, ')')
                    SEPARATOR ', '
                ) AS medicines_given
            FROM medicine_dispense md
            LEFT JOIN medicine_dispense_items mdi
                ON md.id = mdi.dispense_id
            GROUP BY md.id
            ORDER BY md.dispense_date DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                datagridpatientsrecord.DataSource = dt;
                datagridpatientsrecord.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
        }



        // 🔎 LOAD SINGLE PATIENT HISTORY
        private void LoadPatientHistory(string studentId)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("GetPatientHistory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_student_id", studentId);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                datagridpatientsrecord.DataSource = dt;
                datagridpatientsrecord.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

    }
}
