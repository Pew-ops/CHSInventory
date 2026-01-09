using CHSInventory.Nurse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CHSInventory
{
    public partial class Nurses : Form
    {
        private NursePatient _nursePatient;
        private NursePatientsRecords _nursePatientRecord;
        private NurseStock1 _nurseStock1;

        public Nurses()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void Nurse_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnpatients_Click(object sender, EventArgs e)
        {
            if (_nursePatientRecord == null || _nursePatientRecord.IsDisposed)
            {
                _nursePatientRecord = new NursePatientsRecords();
                _nursePatientRecord.Dock = DockStyle.Fill;
            }

            // Replace current content of the right panel
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(_nursePatientRecord);
            _nursePatientRecord.BringToFront();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (_nursePatient == null || _nursePatient.IsDisposed)
            {
                _nursePatient = new NursePatient();
                _nursePatient.Dock = DockStyle.Fill;
            }

            // Replace current content of the right panel
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(_nursePatient);
            _nursePatient.BringToFront();

        }

        private void btnstock_Click(object sender, EventArgs e)
        {
            if (_nurseStock1 == null || _nurseStock1.IsDisposed)
            {
                _nurseStock1 = new NurseStock1();
                _nurseStock1.Dock = DockStyle.Fill;
            }

            // Replace current content of the right panel
            this.panel3.Controls.Clear();
            this.panel3.Controls.Add(_nurseStock1);
            _nurseStock1.BringToFront();
        }
    }
}
