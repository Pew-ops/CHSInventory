using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace CHSInventory.Admin
{
    public partial class AdminExpired : UserControl
    {
        private ReportManager reportManager;

        public AdminExpired()
        {
            InitializeComponent();
            reportManager = new ReportManager();
            LoadExpiredItems();
        }

        // ================= LOAD EXPIRED ITEMS =================
        private void LoadExpiredItems()
        {
            try
            {
                DataTable dt = reportManager.GetExpiredItems();
                datagrigitemrecorddispose.DataSource = dt;
                datagrigitemrecorddispose.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= DISPOSE =================
        private void btndispose_Click(object sender, EventArgs e)
        {
            if (datagrigitemrecorddispose.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select items to dispose first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to dispose the selected items?",
                "Confirm Dispose",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                int successCount = 0;
                int failCount = 0;

                foreach (DataGridViewRow row in datagrigitemrecorddispose.SelectedRows)
                {
                    try
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value);
                        reportManager.DisposeItem(id);
                        successCount++;
                    }
                    catch
                    {
                        failCount++;
                    }
                }

                string message = $"Disposed {successCount} item(s) successfully!";
                if (failCount > 0)
                {
                    message += $"\n{failCount} item(s) failed to dispose.";
                }

                MessageBox.Show(message, "Dispose Results",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadExpiredItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disposing items: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= SEARCH =================
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtsearch.Text.Trim();

                DataTable dt;
                if (string.IsNullOrEmpty(searchText))
                {
                    dt = reportManager.GetExpiredItems();
                }
                else
                {
                    dt = reportManager.SearchExpiredItems(searchText);
                }

                datagrigitemrecorddispose.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= REPORT PDF =================
        private void btnmakereport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = reportManager.GetDisposedItemsReport();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No disposed items to report.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Ask user where to save PDF
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.FileName = "Disposed_Items_Report.pdf";

                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                string filePath = saveFileDialog.FileName;

                // Create PDF document
                Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                // Title
                Paragraph title = new Paragraph("Disposed Items Report",
                    FontFactory.GetFont("Arial"));
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);
                doc.Add(new Paragraph(" ")); // empty line

                // Table with all columns
                PdfPTable table = new PdfPTable(11);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 10f, 20f, 15f, 10f, 10f, 10f, 15f, 15f, 10f, 15f, 15f });

                // Table headers
                string[] headers = { "Code", "Name", "Category", "Dosage", "Unit Cost",
                    "Qty", "Expiration Date", "Delivery Date", "Status", "Batch No", "Supplier" };

                foreach (string header in headers)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(header, FontFactory.GetFont("Arial")));
                    cell.BackgroundColor = new Color(211, 211, 211);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.Padding = 5;
                    table.AddCell(cell);
                }

                // Table rows
                foreach (DataRow row in dt.Rows)
                {
                    table.AddCell(row["item_code"].ToString());
                    table.AddCell(row["item_name"].ToString());
                    table.AddCell(row["category"].ToString());
                    table.AddCell(row["dosage"].ToString());
                    table.AddCell(Convert.ToDecimal(row["unit_cost"]).ToString("0.00"));
                    table.AddCell(row["quantity"].ToString());
                    table.AddCell(Convert.ToDateTime(row["expiration_date"]).ToString("yyyy-MM-dd"));
                    table.AddCell(Convert.ToDateTime(row["delivery_date"]).ToString("yyyy-MM-dd"));
                    table.AddCell(row["status"].ToString());
                    table.AddCell(row["batch_no"].ToString());
                    table.AddCell(row["supplier"].ToString());
                }

                doc.Add(table);
                doc.Close();

                MessageBox.Show("PDF report generated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF report: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}