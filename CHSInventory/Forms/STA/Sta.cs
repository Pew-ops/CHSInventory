using CHSInventory.Nurse;
using CHSInventory;
using System;
using System.Windows.Forms;
using CHSInventory.STA;
using CHSInventory.Forms.STA;

namespace CHSInventory
{
    public partial class Sta : Form
    {
        private Stareceive1 _stareceive1;
        private staDisposal _stadisposal;

        public Sta()
        {
            InitializeComponent();
            this.Load += Sta_Load; // Form Load event
        }

        // ================= FORM LOAD =================
        private void Sta_Load(object sender, EventArgs e)
        {
            // Show Disposal form first when STA form opens
            ShowDisposalForm();
        }

        // ================= SHOW DISPOSAL FORM =================
        private void ShowDisposalForm()
        {
            if (_stadisposal == null || _stadisposal.IsDisposed)
            {
                _stadisposal = new staDisposal();
                _stadisposal.Dock = DockStyle.Fill;
            }

            panel3.Controls.Clear();
            panel3.Controls.Add(_stadisposal);
            _stadisposal.BringToFront();
            _stadisposal.Show();
        }

        // ================= SHOW RECEIVE FORM =================
        private void ShowReceiveForm()
        {
            if (_stareceive1 == null || _stareceive1.IsDisposed)
            {
                _stareceive1 = new Stareceive1();
                _stareceive1.Dock = DockStyle.Fill;
            }

            panel3.Controls.Clear();
            panel3.Controls.Add(_stareceive1);
            _stareceive1.BringToFront();
            _stareceive1.Show();
        }

        // ================= BUTTON EVENTS =================
        private void btnrecieve_Click(object sender, EventArgs e)
        {
            ShowReceiveForm();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            ShowDisposalForm();
        }

        private void btnexitsta_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

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
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Close();
            }
        }
    }
}
