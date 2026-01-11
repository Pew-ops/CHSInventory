using CHSInventory.Nurse;
using CHSInventory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CHSInventory.STA;

namespace CHSInventory
{
    public partial class Sta : Form
    {

        private Stareceive1 _stareceive1;
        public Sta()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnrecieve_Click(object sender, EventArgs e)
        {
            if (_stareceive1 == null || _stareceive1.IsDisposed)
            {
                _stareceive1 = new Stareceive1();
                // Important when adding a Form to a Panel
                _stareceive1.Dock = DockStyle.Fill;
            }

            panel3.Controls.Clear();
            panel3.Controls.Add(_stareceive1);
            _stareceive1.BringToFront();
            _stareceive1.Show(); // Also ensure the Form is visible
        }

        private void btnexitsta_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
