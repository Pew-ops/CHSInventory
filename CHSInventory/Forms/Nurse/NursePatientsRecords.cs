using System;
using System.Data;
using System.Windows.Forms;

namespace CHSInventory.Nurse
{
    public partial class NursePatientsRecords : UserControl
    {
        private PatientVisitsManager patientVisitsManager;

        public NursePatientsRecords()
        {
            InitializeComponent();
            patientVisitsManager = new PatientVisitsManager();

            // Load data when control is created
            this.Load += NursePatientsRecords_Load;
            // Backup in case control is hidden/shown again
            this.VisibleChanged += NursePatientsRecords_VisibleChanged;
        }

        // ================= MAIN LOAD - ALWAYS LOAD ON FIRST OPEN =================
        private void NursePatientsRecords_Load(object sender, EventArgs e)
        {
            LoadAllPatients();
        }

        // ================= BACKUP - IF CONTROL IS SHOWN AGAIN =================
        private void NursePatientsRecords_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && datagridpatientsrecord.DataSource == null)
            {
                LoadAllPatients();
            }
        }

        // ================= SEARCH =================
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

        // ================= LOAD ALL PATIENTS WITH MEDICINES =================
        private void LoadAllPatients()
        {
            try
            {
                DataTable dt = patientVisitsManager.GetAllPatientsWithMedicines();
                datagridpatientsrecord.DataSource = dt;
                datagridpatientsrecord.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patient records: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ================= LOAD PATIENT HISTORY BY STUDENT ID =================
        private void LoadPatientHistory(string studentId)
        {
            try
            {
                DataTable dt = patientVisitsManager.GetPatientHistoryByStudentId(studentId);
                datagridpatientsrecord.DataSource = dt;
                datagridpatientsrecord.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patient history: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}