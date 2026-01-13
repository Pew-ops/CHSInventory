using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace CHSInventory
{
    public class MedicalItemManager
    {
        private string connectionString = ConfigurationManager
            .ConnectionStrings["CHSInventoryDB"].ConnectionString;

        // ================= GET TODAY'S MEDICINE DATA =================
        public DataTable GetTodayMedicineData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_GetTodayMedicineData", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        // ================= CHECK EXISTING MEDICINE =================
        public int? CheckExistingMedicine(string itemCode, string batchNo, DateTime expirationDate)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_CheckExistingMedicine", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_item_code", itemCode);
                cmd.Parameters.AddWithValue("p_batch_no", batchNo);
                cmd.Parameters.AddWithValue("p_expiration_date", expirationDate.Date);

                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }

                return null;
            }
        }

        // ================= UPDATE MEDICINE QUANTITY =================
        public int UpdateMedicineQuantity(int id, int quantityToAdd)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_UpdateMedicineQuantity", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_id", id);
                cmd.Parameters.AddWithValue("p_quantity_to_add", quantityToAdd);

                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
        }

        // ================= ADD NEW MEDICINE RECEIVE =================
        public int AddMedicineReceive(
            string itemCode,
            string itemName,
            string category,
            string dosage,
            decimal unitCost,
            int quantity,
            DateTime expirationDate,
            DateTime deliveryDate,
            string status,
            string batchNo,
            string supplier)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_add_medicine_receive", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_item_code", itemCode);
                cmd.Parameters.AddWithValue("p_item_name", itemName);
                cmd.Parameters.AddWithValue("p_category", category);
                cmd.Parameters.AddWithValue("p_dosage", dosage);
                cmd.Parameters.AddWithValue("p_unit_cost", unitCost);
                cmd.Parameters.AddWithValue("p_quantity", quantity);
                cmd.Parameters.AddWithValue("p_expiration_date", expirationDate.Date);
                cmd.Parameters.AddWithValue("p_delivery_date", deliveryDate.Date);
                cmd.Parameters.AddWithValue("p_status", status);
                cmd.Parameters.AddWithValue("p_batch_no", batchNo);
                cmd.Parameters.AddWithValue("p_supplier", supplier);

                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
        }

        // ================= ADD MEDICINE WITH TRANSACTION LOGIC =================
        public void AddMedicineWithBatchCheck(
            string itemCode,
            string itemName,
            string category,
            string dosage,
            decimal unitCost,
            int quantity,
            DateTime expirationDate,
            DateTime deliveryDate,
            string status,
            string batchNo,
            string supplier)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // Check if same item + batch + expiration exists
                    MySqlCommand checkCmd = new MySqlCommand("sp_CheckExistingMedicine", conn, trans);
                    checkCmd.CommandType = CommandType.StoredProcedure;
                    checkCmd.Parameters.AddWithValue("p_item_code", itemCode);
                    checkCmd.Parameters.AddWithValue("p_batch_no", batchNo);
                    checkCmd.Parameters.AddWithValue("p_expiration_date", expirationDate.Date);

                    object existingId = checkCmd.ExecuteScalar();

                    if (existingId != null && existingId != DBNull.Value)
                    {
                        // Update existing batch
                        MySqlCommand updateCmd = new MySqlCommand("sp_UpdateMedicineQuantity", conn, trans);
                        updateCmd.CommandType = CommandType.StoredProcedure;
                        updateCmd.Parameters.AddWithValue("p_id", Convert.ToInt32(existingId));
                        updateCmd.Parameters.AddWithValue("p_quantity_to_add", quantity);
                        updateCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // Insert new record
                        MySqlCommand insertCmd = new MySqlCommand("sp_add_medicine_receive", conn, trans);
                        insertCmd.CommandType = CommandType.StoredProcedure;
                        insertCmd.Parameters.AddWithValue("p_item_code", itemCode);
                        insertCmd.Parameters.AddWithValue("p_item_name", itemName);
                        insertCmd.Parameters.AddWithValue("p_category", category);
                        insertCmd.Parameters.AddWithValue("p_dosage", dosage);
                        insertCmd.Parameters.AddWithValue("p_unit_cost", unitCost);
                        insertCmd.Parameters.AddWithValue("p_quantity", quantity);
                        insertCmd.Parameters.AddWithValue("p_expiration_date", expirationDate.Date);
                        insertCmd.Parameters.AddWithValue("p_delivery_date", deliveryDate.Date);
                        insertCmd.Parameters.AddWithValue("p_status", status);
                        insertCmd.Parameters.AddWithValue("p_batch_no", batchNo);
                        insertCmd.Parameters.AddWithValue("p_supplier", supplier);
                        insertCmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        // ================= DELETE MEDICINE BY ID =================
        public int DeleteMedicineById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_DeleteMedicineById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_id", id);

                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
        }

        // ================= GET MEDICINE INFO BY CODE (FOR AUTO-FILL) =================
        public MedicineInfo GetMedicineInfoByCode(string itemCode)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("sp_GetMedicineInfoByCode", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_item_code", itemCode);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new MedicineInfo
                        {
                            ItemName = reader["item_name"].ToString(),
                            Category = reader["category"].ToString(),
                            Dosage = reader["dosage"].ToString(),
                            UnitCost = reader["unit_cost"] != DBNull.Value
                                ? Convert.ToDecimal(reader["unit_cost"])
                                : 0
                        };
                    }
                }

                return null;
            }
        }

        // ================= GET MEDICINE BY ID =================
        public DataRow GetMedicineById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_GetMedicineById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_id", id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }

                return null;
            }
        }
    }

    // ================= HELPER CLASS FOR MEDICINE INFO =================
    public class MedicineInfo
    {
        public string ItemName { get; set; }
        public string Category { get; set; }
        public string Dosage { get; set; }
        public decimal UnitCost { get; set; }
    }
}