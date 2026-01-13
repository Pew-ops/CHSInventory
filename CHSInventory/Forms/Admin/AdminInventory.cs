using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CHSInventory
{
    public partial class AdminInventory : UserControl
    {
        private InventoryManager inventoryManager;

        public AdminInventory()
        {
            InitializeComponent();
            inventoryManager = new InventoryManager();

            LoadLowStockCount();
            LoadTotalStockReceived();
            LoadNearlyExpiredCount();
            LoadAllMedicines();
            LoadMonthlyDispenseCount();
        }

        // ================= LOW STOCK COUNT =================
        private void LoadLowStockCount()
        {
            int count = inventoryManager.GetLowStockCount();
            lblstock.Text = count.ToString();
        }

        // ================= TOTAL STOCK RECEIVED =================
        private void LoadTotalStockReceived()
        {
            int totalStock = inventoryManager.GetTotalStockReceived();
            lbltotalmedicine.Text = totalStock.ToString();
        }

        // ================= NEARLY EXPIRED COUNT =================
        private void LoadNearlyExpiredCount()
        {
            int count = inventoryManager.GetNearlyExpiredCount();
            lblnearlyexpired.Text = count.ToString();
        }

        // ================= LOAD ALL MEDICINES TO GRID =================
        private void LoadAllMedicines()
        {
            DataTable dt = inventoryManager.GetAllMedicines();
            datagridviewadmin.DataSource = dt;
            datagridviewadmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ================= SEARCH MEDICINES =================
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtsearch.Text.Trim().ToUpper();

            // Extract numeric part (e.g. Batch002 → 002)
            string numericBatch = System.Text.RegularExpressions.Regex
                .Replace(searchText, @"\D", "");

            DataTable dt = inventoryManager.SearchMedicines(searchText, numericBatch);
            datagridviewadmin.DataSource = dt;
            datagridviewadmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ================= GRID CELL CLICK =================
        private void datagridviewadmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                datagridviewadmin.Rows[e.RowIndex].Selected = true;
            }
        }

        // ================= SHOW LOW STOCK ON CLICK =================
        private void lblstock_Click(object sender, EventArgs e)
        {
            DataTable dt = inventoryManager.GetLowStockMedicines();
            datagridviewadmin.DataSource = dt;
            datagridviewadmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ================= SHOW NEARLY EXPIRED ON CLICK =================
        private void lblnearlyexpired_Click(object sender, EventArgs e)
        {
            DataTable dt = inventoryManager.GetNearlyExpiredMedicines();
            datagridviewadmin.DataSource = dt;
            datagridviewadmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ================= SHOW TOTAL MEDICINE ON CLICK =================
        private void lbltotalmedicine_Click(object sender, EventArgs e)
        {
            LoadAllMedicines();
            LoadTotalMedicine();
        }

        private void LoadTotalMedicine()
        {
            int count = inventoryManager.GetTotalMedicineCount();
            lbltotalmedicine.Text = count.ToString();
        }

        // ================= SHOW MONTHLY DISPENSE ON CLICK =================
        private void lbltotaldispence_Click(object sender, EventArgs e)
        {
            DataTable dt = inventoryManager.GetMonthlyDispensedMedicines();
            datagridviewadmin.DataSource = dt;
            datagridviewadmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ================= MONTHLY DISPENSE COUNT =================
        private void LoadMonthlyDispenseCount()
        {
            int count = inventoryManager.GetMonthlyDispenseCount();
            lbltotaldispence.Text = count.ToString();
        }

        // ================= MAKE REPORT =================
        private void btnmakeareport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "PDF file|*.pdf",
                    FileName = "InventoryReport.pdf"
                })
                {
                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    // Add title
                    var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    Paragraph title = new Paragraph("Monthly Inventory Report", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    title.SpacingAfter = 20;
                    doc.Add(title);

                    // Add sections
                    AddInventorySection(doc, "Low Stock Medicines",
                        inventoryManager.GetLowStockMedicines());

                    AddInventorySection(doc, "All Medicines",
                        inventoryManager.GetAllMedicines());

                    AddInventorySection(doc, "Nearly Expired Medicines (Next 30 Days)",
                        inventoryManager.GetNearlyExpiredMedicines());

                    AddInventorySection(doc, "Monthly Dispensed Medicines",
                        inventoryManager.GetMonthlyDispensedMedicines());

                    doc.Close();

                    MessageBox.Show("PDF report generated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= HELPER: ADD SECTION TO PDF =================
        private void AddInventorySection(Document doc, string sectionTitle, DataTable dt)
        {
            var sectionFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            Paragraph section = new Paragraph(sectionTitle, sectionFont);
            section.SpacingBefore = 15;
            section.SpacingAfter = 10;
            doc.Add(section);

            if (dt.Rows.Count > 0)
            {
                PdfPTable pdfTable = new PdfPTable(dt.Columns.Count);
                pdfTable.WidthPercentage = 100;

                // Add headers
                foreach (DataColumn col in dt.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(col.ColumnName))
                    {
                        BackgroundColor = Color.LIGHT_GRAY
                    };
                    pdfTable.AddCell(cell);
                }

                // Add rows
                foreach (DataRow row in dt.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        pdfTable.AddCell(item?.ToString() ?? "");
                    }
                }

                doc.Add(pdfTable);
            }
            else
            {
                Paragraph noData = new Paragraph("No data found.");
                doc.Add(noData);
            }
        }

        // ================= CUSTOM INPUT DIALOG =================
        private string ShowInputDialog(string prompt, string title, string defaultValue = "")
        {
            Form promptForm = new Form()
            {
                Width = 350,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label()
            {
                Left = 10,
                Top = 10,
                Text = prompt,
                AutoSize = true
            };

            TextBox inputBox = new TextBox()
            {
                Left = 10,
                Top = 40,
                Width = 310,
                Text = defaultValue
            };

            Button okButton = new Button()
            {
                Text = "OK",
                Left = 150,
                Width = 80,
                Top = 70,
                DialogResult = DialogResult.OK
            };

            promptForm.Controls.Add(textLabel);
            promptForm.Controls.Add(inputBox);
            promptForm.Controls.Add(okButton);
            promptForm.AcceptButton = okButton;

            return promptForm.ShowDialog() == DialogResult.OK ? inputBox.Text : null;
        }

        // ================= UPDATE MEDICINE =================
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (datagridviewadmin.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = datagridviewadmin.SelectedRows[0];
            string itemCode = selectedRow.Cells["item_code"].Value.ToString();
            string itemName = selectedRow.Cells["item_name"].Value.ToString();
            int currentQuantity = Convert.ToInt32(selectedRow.Cells["quantity"].Value);
            string currentStatus = selectedRow.Cells["STATUS"].Value.ToString();

            // Get new quantity
            string inputQuantity = ShowInputDialog(
                $"Update Quantity for {itemName} (current: {currentQuantity}):",
                "Update Quantity",
                currentQuantity.ToString());

            if (!int.TryParse(inputQuantity, out int newQuantity))
            {
                MessageBox.Show("Invalid quantity entered.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get new status
            string newStatus = ShowInputDialog(
                $"Update Status for {itemName} (current: {currentStatus}):",
                "Update Status",
                currentStatus);

            if (newStatus == null) return;

            // Update database
            try
            {
                int rowsAffected = inventoryManager.UpdateMedicine(itemCode, newQuantity, newStatus);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadAllMedicines();
                    LoadLowStockCount();
                    LoadTotalStockReceived();
                    LoadNearlyExpiredCount();
                }
                else
                {
                    MessageBox.Show("No record was updated.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating record: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}