using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;



namespace CHSInventory
{
    public partial class AdminInventory : UserControl
    {
        string connectionString = ConfigurationManager
            .ConnectionStrings["CHSInventoryDB"].ConnectionString;

        public AdminInventory()
        {
            InitializeComponent();
            LoadLowStockCount();
            LoadTotalStockReceived();
            LoadNearlyExpiredCount();
            LoadAllMedicines(); // Display all medicines in the grid         
            LoadMonthlyDispenseCount(); // ✅ Update the label on load
        }

      
        // ================= LOW STOCK COUNT =================
        private void LoadLowStockCount()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT COUNT(*) 
            FROM medicine_receive 
            WHERE quantity <= 50 AND category = 'Medicine'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                lblstock.Text = count.ToString();
            }
        }

        private void LoadTotalStockReceived()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT SUM(quantity) FROM medicine_receive";

                object result = new MySqlCommand(query, conn).ExecuteScalar();
                int totalStock = (result != DBNull.Value) ? Convert.ToInt32(result) : 0;

                lbltotalmedicine.Text = totalStock.ToString();
            }
        }

        // ================= NEARLY EXPIRED COUNT =================
        private void LoadNearlyExpiredCount()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT COUNT(*) 
                    FROM medicine_receive 
                    WHERE expiration_date BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 30 DAY)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                lblnearlyexpired.Text = count.ToString();
            }
        }

        // ================= LOAD ALL MEDICINES TO GRID =================
        private void LoadAllMedicines()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
            SELECT item_code, item_name, category, dosage, quantity,
                   batch_no, expiration_date, delivery_date, STATUS
            FROM medicine_receive
            ORDER BY expiration_date ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                datagridviewadmin.DataSource = dt;
                datagridviewadmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }


        // ================= SEARCH MEDICINES =================
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
        SELECT item_code, item_name, category, dosage, quantity,
               batch_no, expiration_date, delivery_date, STATUS
        FROM medicine_receive
        WHERE 
            item_name LIKE @search
            OR category LIKE @search
            OR batch_no LIKE @search
            OR REPLACE(UPPER(batch_no), 'BATCH', '') LIKE @batchOnly
        ORDER BY expiration_date ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);

                string searchText = txtsearch.Text.Trim().ToUpper();

                // Extract numeric part (e.g. Batch002 → 002)
                string numericBatch = System.Text.RegularExpressions.Regex
                    .Replace(searchText, @"\D", "");

                da.SelectCommand.Parameters.AddWithValue("@search", "%" + searchText + "%");
                da.SelectCommand.Parameters.AddWithValue("@batchOnly", "%" + numericBatch + "%");

                DataTable dt = new DataTable();
                da.Fill(dt);

                datagridviewadmin.DataSource = dt;
                datagridviewadmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }



        private void datagridviewadmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: Handle clicks if you want to edit or select medicine
            if (e.RowIndex >= 0) // ignore header clicks
            {
                datagridviewadmin.Rows[e.RowIndex].Selected = true;
            }
        }

        // ================= SHOW LOW STOCK ON CLICK =================
        private void lblstock_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
            SELECT item_code, item_name, category, dosage, quantity,
                   batch_no, expiration_date, STATUS
            FROM medicine_receive
            WHERE quantity <= 50 AND category = 'Medicine'
            ORDER BY quantity ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                datagridviewadmin.DataSource = dt;
                datagridviewadmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }


        // ================= SHOW NEARLY EXPIRED ON CLICK =================
        private void lblnearlyexpired_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
            SELECT item_code, item_name, category, dosage, quantity,
                   batch_no, expiration_date, STATUS
            FROM medicine_receive
            WHERE expiration_date BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 30 DAY)
            ORDER BY expiration_date ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                datagridviewadmin.DataSource = dt;
                datagridviewadmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void lbltotalmedicine_Click(object sender, EventArgs e)
        {
            LoadAllMedicines();   // ✅ SHOW ALL
            LoadTotalMedicine();
        }
        private void LoadTotalMedicine()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM medicine_receive";
                lbltotalmedicine.Text =
                    Convert.ToInt32(new MySqlCommand(query, conn).ExecuteScalar()).ToString();
            }
        }

        private void lbltotaldispence_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
        SELECT 
            md.student_name, 
            mdi.item_name, 
            mdi.quantity, 
            md.dispense_date
        FROM medicine_dispense md
        INNER JOIN medicine_dispense_items mdi ON md.id = mdi.dispense_id
        WHERE md.dispense_date >= DATE_FORMAT(CURDATE(), '%Y-%m-01')
          AND md.dispense_date < DATE_ADD(DATE_FORMAT(CURDATE(), '%Y-%m-01'), INTERVAL 1 MONTH)
        ORDER BY md.dispense_date DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                datagridviewadmin.DataSource = dt;
                datagridviewadmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }


        // ================= MONTHLY DISPENSE COUNT =================
        private void LoadMonthlyDispenseCount()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
        SELECT SUM(mdi.quantity) 
        FROM medicine_dispense md
        INNER JOIN medicine_dispense_items mdi ON md.id = mdi.dispense_id
        WHERE md.dispense_date >= DATE_FORMAT(CURDATE(), '%Y-%m-01')
          AND md.dispense_date < DATE_ADD(DATE_FORMAT(CURDATE(), '%Y-%m-01'), INTERVAL 1 MONTH)";

                object result = new MySqlCommand(query, conn).ExecuteScalar();
                int count = (result != DBNull.Value) ? Convert.ToInt32(result) : 0;

                lbltotaldispence.Text = count.ToString();
            }
        }

        private void btnmakeareport_Click(object sender, EventArgs e)
        {
            try
            {
                // 1️⃣ Create a SaveFileDialog to choose where to save the PDF
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", FileName = "InventoryReport.pdf" })
                {
                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    // 2️⃣ Create a PDF document
                    Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    // 3️⃣ Add a title
                    var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                    Paragraph title = new Paragraph("Monthly Inventory Report", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    title.SpacingAfter = 20;
                    doc.Add(title);

                    // 4️⃣ Add each inventory table
                    AddInventorySection(doc, "Low Stock Medicines", @"
                SELECT item_code, item_name, category, dosage, quantity, batch_no, expiration_date, STATUS
                FROM medicine_receive
                WHERE quantity <= 50 AND category = 'Medicine'
                ORDER BY quantity ASC");

                    AddInventorySection(doc, "All Medicines", @"
                SELECT item_code, item_name, category, dosage, quantity, batch_no, expiration_date, STATUS
                FROM medicine_receive
                ORDER BY expiration_date ASC");

                    AddInventorySection(doc, "Nearly Expired Medicines (Next 30 Days)", @"
                SELECT item_code, item_name, category, dosage, quantity, batch_no, expiration_date, STATUS
                FROM medicine_receive
                WHERE expiration_date BETWEEN CURDATE() AND DATE_ADD(CURDATE(), INTERVAL 30 DAY)
                ORDER BY expiration_date ASC");

                    AddInventorySection(doc, "Monthly Dispensed Medicines", @"
                SELECT md.student_name, mdi.item_name, mdi.quantity, md.dispense_date
                FROM medicine_dispense md
                INNER JOIN medicine_dispense_items mdi ON md.id = mdi.dispense_id
                WHERE md.dispense_date >= DATE_FORMAT(CURDATE(), '%Y-%m-01')
                  AND md.dispense_date < DATE_ADD(DATE_FORMAT(CURDATE(), '%Y-%m-01'), INTERVAL 1 MONTH)
                ORDER BY md.dispense_date DESC");

                    doc.Close();

                    MessageBox.Show("PDF report generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating report: " + ex.Message);
            }
        }

        // Helper function to add a section to the PDF
        private void AddInventorySection(Document doc, string sectionTitle, string query)
        {
            // Section title
            var sectionFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            Paragraph section = new Paragraph(sectionTitle, sectionFont);
            section.SpacingBefore = 15;
            section.SpacingAfter = 10;
            doc.Add(section);

            // Get data from DB
            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            // Create table in PDF
            if (dt.Rows.Count > 0)
            {
                PdfPTable pdfTable = new PdfPTable(dt.Columns.Count);
                pdfTable.WidthPercentage = 100;

                // Add headers
                foreach (DataColumn col in dt.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(col.ColumnName))
                    {
                        BackgroundColor = Color.LIGHT_GRAY // use Color instead of BaseColor
                    };

                }

                // Add rows
                foreach (DataRow row in dt.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        pdfTable.AddCell(item.ToString());
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

        // ----------------- CUSTOM INPUT DIALOG -----------------
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

            Label textLabel = new Label() { Left = 10, Top = 10, Text = prompt, AutoSize = true };
            TextBox inputBox = new TextBox() { Left = 10, Top = 40, Width = 310, Text = defaultValue };
            Button okButton = new Button() { Text = "OK", Left = 150, Width = 80, Top = 70, DialogResult = DialogResult.OK };

            promptForm.Controls.Add(textLabel);
            promptForm.Controls.Add(inputBox);
            promptForm.Controls.Add(okButton);
            promptForm.AcceptButton = okButton;

            return promptForm.ShowDialog() == DialogResult.OK ? inputBox.Text : null;
        }

        // ----------------- BTN UPDATE FUNCTION -----------------
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (datagridviewadmin.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = datagridviewadmin.SelectedRows[0];
            string itemCode = selectedRow.Cells["item_code"].Value.ToString();
            string itemName = selectedRow.Cells["item_name"].Value.ToString();
            int currentQuantity = Convert.ToInt32(selectedRow.Cells["quantity"].Value);
            string currentStatus = selectedRow.Cells["STATUS"].Value.ToString();

            // Get new quantity
            string inputQuantity = ShowInputDialog($"Update Quantity for {itemName} (current: {currentQuantity}):", "Update Quantity", currentQuantity.ToString());
            if (!int.TryParse(inputQuantity, out int newQuantity))
            {
                MessageBox.Show("Invalid quantity entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get new status
            string newStatus = ShowInputDialog($"Update Status for {itemName} (current: {currentStatus}):", "Update Status", currentStatus);
            if (newStatus == null) return; // User canceled

            // Update database
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                UPDATE medicine_receive
                SET quantity = @quantity, STATUS = @status
                WHERE item_code = @item_code";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@quantity", newQuantity);
                    cmd.Parameters.AddWithValue("@status", newStatus);
                    cmd.Parameters.AddWithValue("@item_code", itemCode);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllMedicines();
                        LoadLowStockCount();
                        LoadTotalStockReceived();
                        LoadNearlyExpiredCount();
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



    }
}
