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

    }
}
