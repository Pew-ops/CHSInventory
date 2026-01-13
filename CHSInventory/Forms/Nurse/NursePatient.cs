using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CHSInventory.Nurse
{
    public partial class NursePatient : UserControl
    {
        private IssuanceManager issuanceManager;
        private List<string> allMedicines = new List<string>();
        private HashSet<string> checkedMedicines = new HashSet<string>();
        private int selectedDispenseId = -1;

        public NursePatient()
        {
            InitializeComponent();
            issuanceManager = new IssuanceManager();
            this.Load += NursePatient_Load;
        }

        private void NursePatient_Load(object sender, EventArgs e)
        {
            cmbnurseassign.Font = new Font(
                cmbnurseassign.Font.FontFamily, 15, FontStyle.Regular, GraphicsUnit.Pixel);

            datagridpatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridpatients.MultiSelect = false;

            LoadNurses();
            LoadMedicines();
            LoadDispensedPatients();
        }

        // ================= LOAD NURSES =================
        private void LoadNurses()
        {
            cmbnurseassign.Items.Clear();

            try
            {
                List<string> nurses = issuanceManager.GetAllNurses();

                foreach (var nurse in nurses)
                {
                    cmbnurseassign.Items.Add(nurse);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading nurses: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ================= LOAD MEDICINES =================
        private void LoadMedicines()
        {
            chklistmedicine.Items.Clear();
            allMedicines.Clear();

            try
            {
                allMedicines = issuanceManager.GetAvailableMedicines();

                foreach (var med in allMedicines)
                {
                    int i = chklistmedicine.Items.Add(med);
                    if (checkedMedicines.Contains(med))
                        chklistmedicine.SetItemChecked(i, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading medicines: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void chklistmedicine_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string item = chklistmedicine.Items[e.Index].ToString();
            BeginInvoke((MethodInvoker)delegate
            {
                if (e.NewValue == CheckState.Checked)
                    checkedMedicines.Add(item);
                else
                    checkedMedicines.Remove(item);
            });
        }

        // ================= SEARCH MEDICINE =================
        private void txtsearchmedicine_TextChanged(object sender, EventArgs e)
        {
            string search = txtsearchmedicine.Text.ToLower();
            chklistmedicine.Items.Clear();

            foreach (var med in allMedicines)
            {
                if (med.ToLower().Contains(search))
                {
                    int i = chklistmedicine.Items.Add(med);
                    if (checkedMedicines.Contains(med))
                        chklistmedicine.SetItemChecked(i, true);
                }
            }
        }

        // ================= ADD PATIENT =================
        private void btnadd_Click(object sender, EventArgs e)
        {
            // Validate required fields
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtfullname.Text) ||
                string.IsNullOrWhiteSpace(cmbprogram.Text) ||
                string.IsNullOrWhiteSpace(txtcomplain.Text) ||
                string.IsNullOrWhiteSpace(cmbnurseassign.Text))
            {
                MessageBox.Show("Please fill in all required fields.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Get checked medicines directly from CheckedListBox
            List<string> selectedMedicines = new List<string>();
            foreach (var item in chklistmedicine.CheckedItems)
            {
                selectedMedicines.Add(item.ToString());
            }

            if (selectedMedicines.Count == 0)
            {
                MessageBox.Show("Select at least one medicine.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                issuanceManager.AddPatientWithMedicines(
                    studentId: txtId.Text.Trim(),
                    studentName: txtfullname.Text.Trim(),
                    program: cmbprogram.Text,
                    complaint: txtcomplain.Text.Trim(),
                    nurseAssigned: cmbnurseassign.Text,
                    medicines: selectedMedicines
                );

                MessageBox.Show("Patient added successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Clear and refresh
                ClearFields();
                checkedMedicines.Clear();

                // Uncheck all items
                for (int i = 0; i < chklistmedicine.Items.Count; i++)
                {
                    chklistmedicine.SetItemChecked(i, false);
                }

                LoadMedicines();
                LoadDispensedPatients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding patient: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ================= LOAD GRID =================
        private void LoadDispensedPatients()
        {
            try
            {
                DataTable dt = issuanceManager.GetAllDispensedPatients();
                datagridpatients.DataSource = dt;
                datagridpatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading patient records: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ================= GRID CLICK =================
        private void datagridpatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                DataGridViewRow r = datagridpatients.Rows[e.RowIndex];

                selectedDispenseId = Convert.ToInt32(r.Cells["id"].Value);
                txtId.Text = r.Cells["student_id"].Value?.ToString() ?? "";
                txtfullname.Text = r.Cells["student_name"].Value?.ToString() ?? "";
                cmbprogram.Text = r.Cells["program"].Value?.ToString() ?? "";
                txtcomplain.Text = r.Cells["complain"].Value?.ToString() ?? "";
                cmbnurseassign.Text = r.Cells["nurse_assigned"].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting record: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ================= SEARCH PATIENT =================
        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(guna2TextBox7.Text))
                {
                    LoadDispensedPatients();
                }
                else
                {
                    DataTable dt = issuanceManager.SearchDispensedPatients(
                        guna2TextBox7.Text.Trim());
                    datagridpatients.DataSource = dt;
                    datagridpatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching patients: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ================= UPDATE =================
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (selectedDispenseId == -1)
            {
                MessageBox.Show("Select a record first.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int rowsAffected = issuanceManager.UpdateMedicineDispense(
                    id: selectedDispenseId,
                    studentId: txtId.Text.Trim(),
                    studentName: txtfullname.Text.Trim(),
                    program: cmbprogram.Text,
                    complaint: txtcomplain.Text.Trim(),
                    nurseAssigned: cmbnurseassign.Text
                );

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Updated successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadDispensedPatients();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("No record was updated.",
                        "Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ================= CLEAR FIELDS =================
        private void ClearFields()
        {
            txtId.Clear();
            txtfullname.Clear();
            cmbprogram.SelectedIndex = -1;
            txtcomplain.Clear();
            cmbnurseassign.SelectedIndex = -1;
            selectedDispenseId = -1;
        }
    }
}