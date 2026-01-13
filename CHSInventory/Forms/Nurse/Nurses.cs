using CHSInventory.Nurse;
using System;
using System.Windows.Forms;

namespace CHSInventory
{
    public partial class Nurses : Form
    {
        // Declare all UserControls
        private NursePatient _nursePatient;
        private NursePatientsRecords _nursePatientRecord;
        private NurseStock1 _nurseStock1;
        private NurseDashboard _nurseDashboard;
        private NurseExpire _nurseExpire;

        public Nurses()
        {
            InitializeComponent();

            // Load NurseDashboard automatically on form load
            LoadControl(ref _nurseDashboard, new NurseDashboard());
        }

        // Generic method to load any UserControl into panel3
        private void LoadControl<T>(ref T control, T newControl) where T : UserControl
        {
            if (control == null || control.IsDisposed)
            {
                control = newControl;
                control.Dock = DockStyle.Fill;
            }

            panel3.Controls.Clear();
            panel3.Controls.Add(control);
            control.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            LoadControl(ref _nurseDashboard, new NurseDashboard());
        }

        private void btnpatients_Click(object sender, EventArgs e)
        {
            LoadControl(ref _nursePatientRecord, new NursePatientsRecords());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            LoadControl(ref _nursePatient, new NursePatient());
        }

        private void btnstock_Click(object sender, EventArgs e)
        {
            LoadControl(ref _nurseStock1, new NurseStock1());
        }

        private void btnexpired_Click(object sender, EventArgs e)
        {
            LoadControl(ref _nurseExpire, new NurseExpire());
        }

        private void btnexitsta_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Optional: remove unused event handlers
        private void Nurse_Load(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Do you want to logout?",
               "Logout Confirmation",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (result == DialogResult.Yes)
            {
                // Show login form again
                Form1 loginForm = new Form1();
                loginForm.Show();

                // Close current dashboard form
                this.FindForm().Close();
            }
        }
    }
}
