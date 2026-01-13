using CHSInventory.Admin;
using System;
using System.Windows.Forms;

namespace CHSInventory
{
    public partial class Admin1 : Form
    {
        // Declare all UserControls
        private Admindashboard _admindashboard;
        private AdminUser _adminUser;
        private AdminInventory _adminInventory;
        private AdminExpired _adminExpired;
        private AdminPatient _adminPatient;

        public Admin1()
        {
            InitializeComponent();

            // Load dashboard automatically when the form opens
            LoadControl(ref _admindashboard, new Admindashboard());
        }

        // Generic method to load any UserControl into panel3
        private void LoadControl<T>(ref T control, T newControl) where T : UserControl
        {
            if (control == null || control.IsDisposed)
            {
                control = newControl;
                control.Dock = DockStyle.Fill;
            }

            // Clear existing controls and add the new one
            panel3.Controls.Clear();
            panel3.Controls.Add(control);
            control.BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadControl(ref _admindashboard, new Admindashboard());
        }

        private void btnuserAdmin_Click(object sender, EventArgs e)
        {
            LoadControl(ref _adminUser, new AdminUser());

            // Optional: load users if your UserControl has a LoadUsers() method
            _adminUser.LoadUsers();
        }

        private void btninventoryAdmin_Click(object sender, EventArgs e)
        {
            LoadControl(ref _adminInventory, new AdminInventory());
        }

        private void btnstocksAdmin_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            LoadControl(ref _adminPatient, new AdminPatient());
        }

        private void btnexitadmin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Optional: you can remove unused event handlers if not needed
        private void label2_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }

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

        private void btnexpiredAdmin_Click(object sender, EventArgs e)
        {
            LoadControl(ref _adminExpired, new AdminExpired());
        }
    }
}
