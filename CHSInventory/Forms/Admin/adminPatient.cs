using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace CHSInventory.Admin
{
    public partial class AdminPatient : UserControl
    {
        private string connStr =
            ConfigurationManager.ConnectionStrings["CHSInventoryDB"].ConnectionString;

        public AdminPatient()
        {
            InitializeComponent();

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
            if (string.IsNullOrWhiteSpace(txtsearch.Text))
            {
                LoadAllPatients();
            }
            else
            {
                LoadPatientHistory(txtsearch.Text.Trim());
            }
        }

        // ================= LOAD ALL PATIENTS =================
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

        // ================= LOAD SINGLE PATIENT HISTORY =================
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
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // Get current month records
                    string query = @"
                SELECT 
                    student_id,
                    student_name,
                    program,
                    complain,
                    nurse_assigned,
                    dispense_date,
                    GROUP_CONCAT(CONCAT(item_name, ' (', quantity, ')') SEPARATOR ', ') AS medicines_given
                FROM medicine_dispense md
                LEFT JOIN medicine_dispense_items mdi
                    ON md.id = mdi.dispense_id
                WHERE MONTH(dispense_date) = MONTH(CURDATE())
                  AND YEAR(dispense_date) = YEAR(CURDATE())
                GROUP BY md.id
                ORDER BY md.dispense_date";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Create PDF
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter.GetInstance(pdfDoc, new FileStream(filePath, FileMode.Create));
                    pdfDoc.Open();

                    // Add title
                    iTextSharp.text.Font titleFont = iTextSharp.text.FontFactory.GetFont("Helvetica", 16, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Monthly Student Medicine Report", titleFont);
                    title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    pdfDoc.Add(title);


                    pdfDoc.Add(new Paragraph("\n")); // empty line

                    // Create table
                    PdfPTable table = new PdfPTable(dt.Columns.Count);
                    table.WidthPercentage = 100;

                    // Add headers
                    foreach (DataColumn column in dt.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
                        cell.BackgroundColor = Color.LIGHT_GRAY;
                        table.AddCell(cell);
                    }

                    // Add data rows
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (var item in row.ItemArray)
                        {
                            table.AddCell(item.ToString());
                        }
                    }

                    pdfDoc.Add(table);
                    pdfDoc.Close();
                }

                MessageBox.Show("Monthly report saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void datagridpatientsrecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Select the clicked row
                datagridpatientsrecord.Rows[e.RowIndex].Selected = true;
            }
        }

        // ================== UPDATE PATIENT ==================
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (datagridpatientsrecord.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient record to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string query = @"
                UPDATE medicine_dispense
                SET student_name = @student_name,
                    program = @program,
                    complain = @complain,
                    nurse_assigned = @nurse_assigned
                WHERE id = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@student_name", newName);
                    cmd.Parameters.AddWithValue("@program", newProgram);
                    cmd.Parameters.AddWithValue("@complain", newComplain);
                    cmd.Parameters.AddWithValue("@nurse_assigned", newNurse);
                    cmd.Parameters.AddWithValue("@id", patientId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Patient record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllPatients();
                    }
                    else
                    {
                        MessageBox.Show("No record was updated.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================== DELETE PATIENT ==================
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (datagridpatientsrecord.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a patient record to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = datagridpatientsrecord.SelectedRows[0];
            int patientId = Convert.ToInt32(selectedRow.Cells["id"].Value);

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this patient record?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes) return;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    // First delete the items related to this dispense
                    string deleteItemsQuery = "DELETE FROM medicine_dispense_items WHERE dispense_id = @id";
                    MySqlCommand cmdItems = new MySqlCommand(deleteItemsQuery, conn);
                    cmdItems.Parameters.AddWithValue("@id", patientId);
                    cmdItems.ExecuteNonQuery();

                    // Then delete the main record
                    string deleteQuery = "DELETE FROM medicine_dispense WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(deleteQuery, conn);
                    cmd.Parameters.AddWithValue("@id", patientId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Patient record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllPatients();
                    }
                    else
                    {
                        MessageBox.Show("No record was deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting record: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================== HELPER: SHOW INPUT DIALOG ==================
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
