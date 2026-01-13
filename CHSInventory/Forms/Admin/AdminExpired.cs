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
        private string connectionString = System.Configuration.ConfigurationManager
            .ConnectionStrings["CHSInventoryDB"].ConnectionString;

        public AdminExpired()
        {
            InitializeComponent();
            LoadExpiredItems();
        }

        // ================= LOAD EXPIRED ITEMS =================
        private void LoadExpiredItems()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = @"SELECT * FROM medicine_receive 
                           WHERE status IN ('Expire','expire','Expired','Damage','damage','DAMAGE')";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    datagrigitemrecorddispose.DataSource = dt;
                    datagrigitemrecorddispose.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading expired/damaged items: " + ex.Message);
            }
        }


        // ================= DISPOSE =================
        private void btndispose_Click(object sender, EventArgs e)
        {
            if (datagrigitemrecorddispose.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select items to dispose first.");
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
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (DataGridViewRow row in datagrigitemrecorddispose.SelectedRows)
                    {
                        int id = Convert.ToInt32(row.Cells["id"].Value);

                        // 1️⃣ Insert into disposed_items
                        string insertSql = @"INSERT INTO disposed_items
                                            (item_code, item_name, category, dosage, unit_cost, quantity, expiration_date, delivery_date, status, batch_no, supplier)
                                            SELECT item_code, item_name, category, dosage, unit_cost, quantity, expiration_date, delivery_date, status, batch_no, supplier
                                            FROM medicine_receive
                                            WHERE id = @id";
                        using (MySqlCommand cmdInsert = new MySqlCommand(insertSql, conn))
                        {
                            cmdInsert.Parameters.AddWithValue("@id", id);
                            cmdInsert.ExecuteNonQuery();
                        }

                        // 2️⃣ Delete from medicine_receive
                        string deleteSql = "DELETE FROM medicine_receive WHERE id = @id";
                        using (MySqlCommand cmdDelete = new MySqlCommand(deleteSql, conn))
                        {
                            cmdDelete.Parameters.AddWithValue("@id", id);
                            cmdDelete.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Selected items disposed successfully!");
                    LoadExpiredItems();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disposing items: " + ex.Message);
            }
        }

        // ================= SEARCH =================
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = @"SELECT * FROM medicine_receive 
                           WHERE status IN ('Expire','expire','Expired','Damage','damage','DAMAGE')
                           AND (item_name LIKE @search OR item_code LIKE @search)";
                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@search", "%" + txtsearch.Text.Trim() + "%");
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        datagrigitemrecorddispose.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching: " + ex.Message);
            }
        }

        // ================= REPORT PDF =================
        private void btnmakereport_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "SELECT * FROM disposed_items ORDER BY disposed_at DESC";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No disposed items to report.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Paragraph title = new Paragraph("Disposed Items Report", iTextSharp.text.FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);
                    doc.Add(new Paragraph(" ")); // empty line

                    // Table with all columns
                    PdfPTable table = new PdfPTable(11); // match disposed_items
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 10f, 20f, 15f, 10f, 10f, 10f, 15f, 15f, 10f, 15f, 15f });

                    // Table headers
                    string[] headers = { "Code", "Name", "Category", "Dosage", "Unit Cost", "Qty", "Expiration Date", "Delivery Date", "Status", "Batch No", "Supplier" };
                    foreach (string header in headers)
                    {
                        PdfPCell cell = new PdfPCell(
     new Phrase(header, FontFactory.GetFont("Arial"))
 );
                        cell.BackgroundColor = new Color(211, 211, 211); // light gray
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.Padding = 5; // optional, makes text nicer
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

                    MessageBox.Show("PDF report generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
