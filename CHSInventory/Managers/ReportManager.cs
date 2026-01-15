using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CHSInventory.Admin
{
    public class ReportManager
    {
        private string connectionString = System.Configuration.ConfigurationManager
            .ConnectionStrings["CHSInventoryDB"].ConnectionString;

        // ===============================================================
        // EXPIRED ITEMS METHODS
        // ===============================================================

        // ================= GET EXPIRED ITEMS =================
        public DataTable GetExpiredItems()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_GetExpiredItems", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading expired/damaged items: " + ex.Message);
            }
        }

        // ================= SEARCH EXPIRED ITEMS =================
        public DataTable SearchExpiredItems(string searchText)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_SearchExpiredItems", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_search", searchText);

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching items: " + ex.Message);
            }
        }

        // ================= DISPOSE ITEM =================
        public void DisposeItem(int itemId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_DisposeItem", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_id", itemId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error disposing item: " + ex.Message);
            }
        }

        // ================= GET DISPOSED ITEMS REPORT =================
        public DataTable GetDisposedItemsReport()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_GetDisposedItemsReport", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting disposed items report: " + ex.Message);
            }
        }

        // ===============================================================
        // PATIENT MANAGEMENT METHODS
        // ===============================================================

        // ================= GET ALL PATIENTS =================
        public DataTable GetAllPatients()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_GetAllPatients", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading all patients: " + ex.Message);
            }
        }

        // ================= GET PATIENT HISTORY =================
        public DataTable GetPatientHistory(string studentId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_GetPatientHistory", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_student_id", studentId);

                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading patient history: " + ex.Message);
            }
        }

        // ================= GET MONTHLY PATIENT REPORT =================
        public DataTable GetMonthlyPatientReport()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_GetMonthlyPatientReport", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting monthly patient report: " + ex.Message);
            }
        }

        // ================= UPDATE PATIENT RECORD =================
        public int UpdatePatientRecord(int id, string studentName, string program,
            string complain, string nurseAssigned)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_UpdatePatientRecord", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_id", id);
                        cmd.Parameters.AddWithValue("@p_student_name", studentName);
                        cmd.Parameters.AddWithValue("@p_program", program);
                        cmd.Parameters.AddWithValue("@p_complain", complain);
                        cmd.Parameters.AddWithValue("@p_nurse_assigned", nurseAssigned);

                        // Execute and get rows affected
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return Convert.ToInt32(reader["rows_affected"]);
                            }
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating patient record: " + ex.Message);
            }
        }

        // ================= DELETE PATIENT RECORD =================
        public int DeletePatientRecord(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("sp_DeletePatientRecord", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@p_id", id);

                        // Execute and get rows affected
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return Convert.ToInt32(reader["rows_affected"]);
                            }
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting patient record: " + ex.Message);
            }
        }
    }
}