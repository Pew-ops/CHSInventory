using CHSInventory.Admin;
using System;
using System.Windows.Forms;

namespace CHSInventory
{
    public partial class Admin1 : Form
    {
        private Admindashboard _admindashboard;
        private AdminUser _adminUser;
        private AdminInventory _adminInventory;
        private AdminStock _adminStock;
        private AdminPatient _adminPatient;
        


        public Admin1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (_admindashboard == null || _admindashboard.IsDisposed)
            {
                _admindashboard = new Admindashboard();
                _admindashboard.Dock = DockStyle.Fill;
            }

            // Replace current content of the right panel
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(_admindashboard);
            _admindashboard.BringToFront();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnuserAdmin_Click(object sender, EventArgs e)
        {
            if (_adminUser == null || _adminUser.IsDisposed)
            {
                _adminUser = new AdminUser();
                _adminUser.Dock = DockStyle.Fill;
            }

            // Replace current content of the right panel
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(_adminUser);
            _adminUser.BringToFront();




            AdminUser adminUser1 = new AdminUser();
            // Make the UserControl visible
            adminUser1.BringToFront();
            adminUser1.Visible = true;

            // Load all users inside the UserControl
            adminUser1.LoadUsers();

        }

        private void btnexitadmin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btninventoryAdmin_Click(object sender, EventArgs e)
        {
            if (_adminInventory == null || _adminInventory.IsDisposed)
            {
                _adminInventory = new AdminInventory();
                _adminInventory.Dock = DockStyle.Fill;
            }

            // Replace current content of the right panel
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(_adminInventory);
            _adminInventory.BringToFront();
        }

        private void btnstocksAdmin_Click(object sender, EventArgs e)     
        {
            if (_adminStock == null || _adminStock.IsDisposed)
            {
                _adminStock = new AdminStock();
                _adminStock.Dock = DockStyle.Fill;
            }

            // Replace current content of the right panel
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(_adminStock);
            _adminStock.BringToFront();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (_adminPatient == null || _adminPatient.IsDisposed)
            {
                _adminPatient = new AdminPatient();
                _adminPatient.Dock = DockStyle.Fill;
            }

            // Replace current content of the right panel
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(_adminPatient);
            _adminPatient.BringToFront();
            
        }

       
    }
}
