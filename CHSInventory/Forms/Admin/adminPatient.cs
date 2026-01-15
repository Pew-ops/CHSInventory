using System;
using System.Data;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace CHSInventory.Admin
{
    public partial class AdminPatient : UserControl
    {
        private ReportManager reportManager;

        public AdminPatient()
        {
            InitializeComponent();
            reportManager = new ReportManager();

            // Load when opened
            this.Load += AdminPatient_Load;

            // Safety reload
            this.VisibleChanged += AdminPatient_VisibleChanged;

            // Search
            this.txtsearch.TextChanged += txtsearch_TextChanged;
        }

        // 🔥 LOAD ON FIRST OPEN
        private void AdminPatient_Load(object sender, EventArgs e)
        {
            LoadAllPatients();
        }

        // 🛡 Reload if hidden/shown again
        private void AdminPatient_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible && datagridpatientsrecord.DataSource == null)
            {
                LoadAllPatients();
            }
        }

        // 🔍 SEARCH
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= LOAD ALL PATIENTS =================
        private void LoadAllPatients()
        {
            try
            {
                DataTable dt = reportManager.GetAllPatients();
                datagridpatientsrecord.DataSource = dt;
                datagridpatientsrecord.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= LOAD SINGLE PATIENT HISTORY =================
        private void LoadPatientHistory(string studentId)
        {
            try
            {
                DataTable dt = reportManager.GetPatientHistory(studentId);
                datagridpatientsrecord.DataSource = dt;
                datagridpatientsrecord.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= GENERATE MONTHLY REPORT =================
        private void btnmakeareport_Click(object sender, EventArgs e)
        {
            GenerateMonthlyReport();
        }

        private void GenerateMonthlyReport()
        {
            // Ask user where to save the PDF
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF files (*.pdf)|*.pdf";
            sfd.FileName = "Monthly_Student_Report.pdf";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            string filePath = sfd.FileName;

            try
            {
                DataTable dt = reportManager.GetMonthlyPatientReport();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No patient records found for this month.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Create PDF
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 25, 25, 30, 30);
                PdfWriter.GetInstance(pdfDoc, new FileStream(filePath, FileMode.Create));
                pdfDoc.Open();

                // Add title
                Font titleFont = FontFactory.GetFont("Helvetica"  );
                Paragraph title = new Paragraph("Monthly Student Medicine Report", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                pdfDoc.Add(title);

                pdfDoc.Add(new Paragraph("\n")); // empty line

                // Create table
                PdfPTable table = new PdfPTable(dt.Columns.Count);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 12f, 20f, 15f, 25f, 15f, 15f, 30f });

                // Add headers
                foreach (DataColumn column in dt.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName,
                        FontFactory.GetFont("Helvetica")));
                    cell.BackgroundColor = new Color(211, 211, 211);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Padding = 5;
                    table.AddCell(cell);
                }

                // Add data rows
                foreach (DataRow row in dt.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(item.ToString(),
                            FontFactory.GetFont("Helvetica", 9)));
                        cell.Padding = 3;
                        table.AddCell(cell);
                    }
                }

                pdfDoc.Add(table);
                pdfDoc.Close();

                MessageBox.Show("Monthly report saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= DATAGRID CELL CLICK =================
        private void datagridpatientsrecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Select the clicked row
                datagridpatientsrecord.Rows[e.RowIndex].Selected = true;
            }
        }

        // ================= UPDATE PATIENT =================
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (datagridpatientsrecord.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient record to update.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = datagridpatientsrecord.SelectedRows[0];
            int patientId = Convert.ToInt32(selectedRow.Cells["id"].Value);
            string studentName = selectedRow.Cells["student_name"].Value.ToString();
            string program = selectedRow.Cells["program"].Value.ToString();
            string complain = selectedRow.Cells["complain"].Value.ToString();
            string nurseAssigned = selectedRow.Cells["nurse_assigned"].Value.ToString();

            // Ask for new values
            string newName = ShowInputDialog("Update Student Name:", "Update", studentName);
            if (string.IsNullOrEmpty(newName)) return;

            string newProgram = ShowInputDialog("Update Program:", "Update", program);
            if (string.IsNullOrEmpty(newProgram)) return;

            string newComplain = ShowInputDialog("Update Complaint:", "Update", complain);
            if (string.IsNullOrEmpty(newComplain)) return;

            string newNurse = ShowInputDialog("Update Nurse Assigned:", "Update", nurseAssigned);
            if (string.IsNullOrEmpty(newNurse)) return;

            // Update database
            try
            {
                int rowsAffected = reportManager.UpdatePatientRecord(
                    patientId, newName, newProgram, newComplain, newNurse);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Patient record updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllPatients();
                }
                else
                {
                    MessageBox.Show("No record was updated.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= DELETE PATIENT =================
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (datagridpatientsrecord.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient record to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = datagridpatientsrecord.SelectedRows[0];
            int patientId = Convert.ToInt32(selectedRow.Cells["id"].Value);

            DialogResult dr = MessageBox.Show(
                "Are you sure you want to delete this patient record?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr != DialogResult.Yes) return;

            try
            {
                int rowsAffected = reportManager.DeletePatientRecord(patientId);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Patient record deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllPatients();
                }
                else
                {
                    MessageBox.Show("No record was deleted.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= HELPER: SHOW INPUT DIALOG =================
        private string ShowInputDialog(string text, string caption, string defaultValue = "")
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 340 };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340, Text = defaultValue };
            Button confirmation = new Button() { Text = "Ok", Left = 200, Width = 80, Top = 90, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Cancel", Left = 280, Width = 80, Top = 90, DialogResult = DialogResult.Cancel };
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }
    }
}