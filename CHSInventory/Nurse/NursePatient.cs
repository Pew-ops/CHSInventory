using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CHSInventory.Nurse
{
    public partial class NursePatient : UserControl
    {
        private List<string> allMedicines = new List<string>();
        private HashSet<string> checkedMedicines = new HashSet<string>();
        private int selectedDispenseId = -1;

        string connStr =
            ConfigurationManager.ConnectionStrings["CHSInventoryDB"].ConnectionString;

        public NursePatient()
        {
            InitializeComponent();
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

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT first_name FROM users WHERE role='Nurses'", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        cmbnurseassign.Items.Add(reader["first_name"].ToString());
                }
            }
        }

        // ================= LOAD MEDICINES =================
        private void LoadMedicines()
        {
            chklistmedicine.Items.Clear();
            allMedicines.Clear();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("GetAvailableMedicines", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        allMedicines.Add(reader["item_name"].ToString());
                }
            }

            foreach (var med in allMedicines)
            {
                int i = chklistmedicine.Items.Add(med);
                if (checkedMedicines.Contains(med))
                    chklistmedicine.SetItemChecked(i, true);
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
            if (checkedMedicines.Count == 0)
            {
                MessageBox.Show("Select at least one medicine.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlTransaction tx = conn.BeginTransaction();

                try
                {
                    MySqlCommand nurseCmd = new MySqlCommand(
                        "SELECT user_id FROM users WHERE first_name=@nurse LIMIT 1",
                        conn, tx);
                    nurseCmd.Parameters.AddWithValue("@nurse", cmbnurseassign.Text);
                    int nurseId = Convert.ToInt32(nurseCmd.ExecuteScalar());

                    MySqlCommand visitCmd = new MySqlCommand(@"
                        INSERT INTO patient_visits
                        (student_id, program, complaint, user_id, visit_date)
                        VALUES (@sid,@prog,@comp,@uid,NOW())",
                        conn, tx);

                    visitCmd.Parameters.AddWithValue("@sid", txtId.Text);
                    visitCmd.Parameters.AddWithValue("@prog", cmbprogram.Text);
                    visitCmd.Parameters.AddWithValue("@comp", txtcomplain.Text);
                    visitCmd.Parameters.AddWithValue("@uid", nurseId);
                    visitCmd.ExecuteNonQuery();

                    int visitId = Convert.ToInt32(
                        new MySqlCommand("SELECT LAST_INSERT_ID()", conn, tx).ExecuteScalar());

                    MySqlCommand dispCmd = new MySqlCommand(@"
                        INSERT INTO medicine_dispense
                        (student_id, student_name, program, complain, nurse_assigned, dispense_date, visit_id)
                        VALUES (@sid,@name,@prog,@comp,@nurse,NOW(),@vid)",
                        conn, tx);

                    dispCmd.Parameters.AddWithValue("@sid", txtId.Text);
                    dispCmd.Parameters.AddWithValue("@name", txtfullname.Text);
                    dispCmd.Parameters.AddWithValue("@prog", cmbprogram.Text);
                    dispCmd.Parameters.AddWithValue("@comp", txtcomplain.Text);
                    dispCmd.Parameters.AddWithValue("@nurse", cmbnurseassign.Text);
                    dispCmd.Parameters.AddWithValue("@vid", visitId);
                    dispCmd.ExecuteNonQuery();

                    int dispenseId = Convert.ToInt32(
                        new MySqlCommand("SELECT LAST_INSERT_ID()", conn, tx).ExecuteScalar());

                    foreach (var med in checkedMedicines)
                    {
                        MySqlCommand itemCmd = new MySqlCommand(
                            "INSERT INTO medicine_dispense_items(dispense_id,item_name,quantity) VALUES(@id,@med,1)",
                            conn, tx);
                        itemCmd.Parameters.AddWithValue("@id", dispenseId);
                        itemCmd.Parameters.AddWithValue("@med", med);
                        itemCmd.ExecuteNonQuery();

                        MySqlCommand stockCmd = new MySqlCommand(@"
                            UPDATE medicine_receive
                            SET quantity = quantity - 1
                            WHERE id = (
                                SELECT id FROM (
                                    SELECT id FROM medicine_receive
                                    WHERE item_name=@med AND quantity>0
                                    ORDER BY delivery_date ASC LIMIT 1
                                ) t)", conn, tx);

                        stockCmd.Parameters.AddWithValue("@med", med);
                        stockCmd.ExecuteNonQuery();
                    }

                    tx.Commit();
                    MessageBox.Show("Patient added successfully!");

                    checkedMedicines.Clear();
                    LoadMedicines();
                    LoadDispensedPatients();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // ================= LOAD GRID =================
        private void LoadDispensedPatients()
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(
                    "SELECT * FROM medicine_dispense ORDER BY dispense_date DESC", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                datagridpatients.DataSource = dt;
            }
        }

        // ================= GRID CLICK =================
        private void datagridpatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow r = datagridpatients.Rows[e.RowIndex];

            selectedDispenseId = Convert.ToInt32(r.Cells["id"].Value);
            txtId.Text = r.Cells["student_id"].Value.ToString();
            txtfullname.Text = r.Cells["student_name"].Value.ToString();
            cmbprogram.Text = r.Cells["program"].Value.ToString();
            txtcomplain.Text = r.Cells["complain"].Value.ToString();
            cmbnurseassign.Text = r.Cells["nurse_assigned"].Value.ToString();
        }

        // ================= SEARCH PATIENT =================
        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"
                    SELECT * FROM medicine_dispense
                    WHERE student_id LIKE @s OR program LIKE @s
                    ORDER BY dispense_date DESC", conn);

                cmd.Parameters.AddWithValue("@s", "%" + guna2TextBox7.Text + "%");

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                datagridpatients.DataSource = dt;
            }
        }

        // ================= UPDATE =================
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (selectedDispenseId == -1)
            {
                MessageBox.Show("Select a record first.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(@"
                    UPDATE medicine_dispense SET
                    student_id=@sid,
                    student_name=@name,
                    program=@prog,
                    complain=@comp,
                    nurse_assigned=@nurse
                    WHERE id=@id", conn);

                cmd.Parameters.AddWithValue("@sid", txtId.Text);
                cmd.Parameters.AddWithValue("@name", txtfullname.Text);
                cmd.Parameters.AddWithValue("@prog", cmbprogram.Text);
                cmd.Parameters.AddWithValue("@comp", txtcomplain.Text);
                cmd.Parameters.AddWithValue("@nurse", cmbnurseassign.Text);
                cmd.Parameters.AddWithValue("@id", selectedDispenseId);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated successfully!");

                LoadDispensedPatients();
            }
        }
    }
}
