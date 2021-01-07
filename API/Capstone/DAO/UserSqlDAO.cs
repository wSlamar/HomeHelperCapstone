using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class UserSqlDAO : IUserDAO
    {
        private readonly string connectionString;

        public UserSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public User GetUser(string username)
        {
            User returnUser = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT user_id, username, password_hash, salt, user_role, first_name, last_name, email, phone, billing_Street_Address, billing_city, billing_state, billing_zip FROM users WHERE username = @username", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        returnUser = GetUserFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return returnUser;
        }
        public User AddUser(string username, string password, string role, string firstName, string lastName, string email, string phoneNumber, string billingStreetAddress,string billingCity, string billingState,string billingZip)
        {
            IPasswordHasher passwordHasher = new PasswordHasher();
            PasswordHash hash = passwordHasher.ComputeHash(password);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO users (username, password_hash, salt, user_role, first_name, last_name, email, phone, billing_street_address, billing_city, billing_state, billing_zip) VALUES (@username, @password_hash, @salt, @user_role, @first_name, @last_name, @email, @phone, @billing_street_address, @billing_city, @billing_state, @billing_zip)", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password_hash", hash.Password);
                    cmd.Parameters.AddWithValue("@salt", hash.Salt);
                    cmd.Parameters.AddWithValue("@user_role", role);
                    cmd.Parameters.AddWithValue("@first_name", firstName);
                    cmd.Parameters.AddWithValue("@last_name", lastName);
                    cmd.Parameters.AddWithValue("@email",email);
                    cmd.Parameters.AddWithValue("@phone",phoneNumber);
                    cmd.Parameters.AddWithValue("@billing_street_address", billingStreetAddress);
                    cmd.Parameters.AddWithValue("@billing_city", billingCity);
                    cmd.Parameters.AddWithValue("@billing_state", billingState);
                    cmd.Parameters.AddWithValue("@billing_zip", billingZip);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return GetUser(username);
        }
        public bool UpdateUserInfo(User user)
        {
            //IPasswordHasher passwordHasher = new PasswordHasher();
            //PasswordHash hash = passwordHasher.ComputeHash(user.Password);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update users set first_name = @first_name, last_name = @last_name, email = @email, phone = @phone, billing_street_address = @billing_street_address, billing_city = @billing_city, billing_state = @billing_state, billing_zip = @billing_zip  where user_id = @user_id", conn);
                    cmd.Parameters.AddWithValue("@user_id", user.UserId);
                    //cmd.Parameters.AddWithValue("@password_hash", hash.Password);
                    //cmd.Parameters.AddWithValue("@salt", hash.Salt);
                    cmd.Parameters.AddWithValue("@first_name", user.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", user.LastName);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@phone", user.PhoneNumber);
                    cmd.Parameters.AddWithValue("@billing_street_address", user.BillingStreetAddress);
                    cmd.Parameters.AddWithValue("@billing_city", user.BillingCity);
                    cmd.Parameters.AddWithValue("@billing_state", user.BillingState);
                    cmd.Parameters.AddWithValue("@billing_zip", user.BillingZip);

                    cmd.ExecuteNonQuery();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        //public bool Updatebilling(int userId, string billingStreetAddress, string billingCity, string billingState, string billingZip)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
                    
        //            SqlCommand cmd = new SqlCommand("update users set billing_street_address = @billing_street_address, billing_city = @billing_city, billing_state = @billing_state, billing_zip = @billing_zip where user_id = @user_id", conn);
        //            cmd.Parameters.AddWithValue("@user_id", userId);
        //            cmd.Parameters.AddWithValue("@billing_street_address", billingStreetAddress);
        //            cmd.Parameters.AddWithValue("@billing_city", billingCity);
        //            cmd.Parameters.AddWithValue("@billing_state", billingState);
        //            cmd.Parameters.AddWithValue("@billing_zip", billingZip);

        //            cmd.ExecuteNonQuery();
        //            int rowsAffected = cmd.ExecuteNonQuery();

        //            return (rowsAffected > 0);
        //        }
        //    }
        //    catch (SqlException)
        //    {
        //        return false;
        //    }
        //}

        private User GetUserFromReader(SqlDataReader reader)
        {
            User u = new User()
            {
                UserId = Convert.ToInt32(reader["user_id"]),
                Username = Convert.ToString(reader["username"]),
                PasswordHash = Convert.ToString(reader["password_hash"]),
                Salt = Convert.ToString(reader["salt"]),
                Role = Convert.ToString(reader["user_role"]),
                FirstName = Convert.ToString(reader["first_name"]),
                LastName = Convert.ToString(reader["last_name"]),
                Email = Convert.ToString(reader["email"]),
                PhoneNumber = Convert.ToString(reader["phone"]),
                BillingStreetAddress = Convert.ToString(reader["billing_street_address"]),
                BillingCity = Convert.ToString(reader["billing_city"]),
                BillingState = Convert.ToString(reader["billing_state"]),
                BillingZip = Convert.ToString(reader["billing_zip"]),
            };
            return u;
        }

        public string[] GetUsernames()
        {            
            List<string> usernameList = new List<string>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select username from users", conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {   
                        string username = reader["username"].ToString().ToLower();                    

                        usernameList.Add(username);
                    }
                    return usernameList.ToArray();
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
        
    }
}
