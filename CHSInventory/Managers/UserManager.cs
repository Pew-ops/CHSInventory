using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using CHSInventory.Models;

namespace CHSInventory.Managers
{
    public class UserManager
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["CHSInventoryDB"].ConnectionString;

        public UserModel Login(string email, string password, string role)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_login_user", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_email", email);
                cmd.Parameters.AddWithValue("p_password", password);
                cmd.Parameters.AddWithValue("p_role", role);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    return new UserModel
                    {
                        UserId = reader.GetInt32("user_id"),
                        FirstName = reader.GetString("first_name"),
                        LastName = reader.GetString("last_name"),
                        Email = reader.GetString("email"),
                        Role = reader.GetString("role"),
                        Status = reader.GetString("status")
                    };
                }
            }
        }
    }
}
