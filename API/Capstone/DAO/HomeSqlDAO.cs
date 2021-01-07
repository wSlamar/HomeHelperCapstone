using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;
using System.Net.Mail;

namespace Capstone.DAO
{
    public class HomeSqlDAO : IHomeDAO
    {
        private readonly string connectionString;
       
        public HomeSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;    
        }
        
        public Home GetHome(int userId, int homeId)
        {
            Home home = new Home();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from home h join users u on u.user_id = h.user_id where h.user_id = @user_id and h.home_id = @home_id ", conn);
                    //SqlCommand cmd = new SqlCommand("select * from home where home_id = @home_id ", conn);
                    cmd.Parameters.AddWithValue("@home_id", homeId);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {


                            home.HomeId = Convert.ToInt32(reader["home_id"]);
                            home.UserId = Convert.ToInt32(reader["user_id"]);
                            home.Description = Convert.ToString(reader["description"]);
                            home.TypeOfHome = Convert.ToString(reader["type"]);
                            home.Nickname = Convert.ToString(reader["nickname"]);
                            home.StreetAddress = Convert.ToString(reader["street_address"]);
                            home.City = Convert.ToString(reader["city"]);
                            home.State = Convert.ToString(reader["state"]);
                            home.Zip = Convert.ToString(reader["zip"]);
                            home.PicUrl = Convert.ToString(reader["pic_url"]);


                        }
                    }

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return home;


        }

        public bool DeleteHome(int userId, int homeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"Delete vendor where home_id = @home_id; 
                        Delete store where home_id = @home_id;
                        DELETE home WHERE user_id = @user_id AND home_id = @home_id ", conn);

                    cmd.Parameters.AddWithValue("@home_id", homeId);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    int result = cmd.ExecuteNonQuery();

                    return result > 0;

                }
            }
            catch (SqlException ex)
            {
                throw ex;

            }
        }
        public List<Home> GetHomes(int userId)
        {
            List<Home> listHomes = new List<Home>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from home where user_id = @user_id ", conn);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Home home = new Home();

                            home.HomeId = Convert.ToInt32(reader["home_id"]);
                            home.UserId = Convert.ToInt32(reader["user_id"]);
                            home.Description = Convert.ToString(reader["description"]);
                            home.TypeOfHome = Convert.ToString(reader["type"]);
                            home.Nickname = Convert.ToString(reader["nickname"]);
                            home.StreetAddress = Convert.ToString(reader["street_address"]);
                            home.City = Convert.ToString(reader["city"]);
                            home.State = Convert.ToString(reader["state"]);
                            home.Zip = Convert.ToString(reader["zip"]);
                            home.PicUrl = Convert.ToString(reader["pic_url"]);

                            listHomes.Add(home);

                        }
                    }

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return listHomes;


        }

        //public bool AddHome(int userId, string description, string type,string streetAddress, string city, string state, string zip)
        public int AddHome(Home home)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"INSERT INTO home(user_id, description, type, nickname, street_address, city, state, zip, pic_url) 
                    VALUES(@user_id, @description, @type, @nickname, @street_address, @city, @state, @zip, @pic_url); SELECT @@IDENTITY", conn);

                    cmd.Parameters.AddWithValue("@user_id", home.UserId);
                    cmd.Parameters.AddWithValue("@description", home.Description);
                    cmd.Parameters.AddWithValue("@type", home.TypeOfHome);
                    cmd.Parameters.AddWithValue("@nickname", home.Nickname);
                    cmd.Parameters.AddWithValue("@street_address", home.StreetAddress);
                    cmd.Parameters.AddWithValue("@city", home.City);
                    cmd.Parameters.AddWithValue("@state", home.State);
                    cmd.Parameters.AddWithValue("@zip", home.Zip);
                    cmd.Parameters.AddWithValue("@pic_url", home.PicUrl);

                    int result = Convert.ToInt32(cmd.ExecuteScalar());

                    return result;

                }
            }
            catch (SqlException ex)
            {
                throw ex;

            }
        }

        public bool UpdateHome(Home home)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE home SET description = @description, type = @type, nickname = @nickname, street_address = @street_address, city = @city, state = @state, zip = @zip where home_id = @home_id", conn);

                    cmd.Parameters.AddWithValue("@home_id", home.HomeId);
                    cmd.Parameters.AddWithValue("@description", home.Description);
                    cmd.Parameters.AddWithValue("@type", home.TypeOfHome);
                    cmd.Parameters.AddWithValue("@nickname", home.Nickname);
                    cmd.Parameters.AddWithValue("@street_address", home.StreetAddress);
                    cmd.Parameters.AddWithValue("@city", home.City);
                    cmd.Parameters.AddWithValue("@state", home.State);
                    cmd.Parameters.AddWithValue("@zip", home.Zip);

                    int result = Convert.ToInt32(cmd.ExecuteScalar());

                    return result > 0;

                }
            }
            catch (SqlException ex)
            {
                throw ex;

            }
        }

        public Milestones GetMilestones(int homeId)
        {
            //List<Milestones> listMilestones = new List<Milestones>();
            Milestones milestone = new Milestones();


            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from milestones where home_id = @home_id ", conn);
                    cmd.Parameters.AddWithValue("@home_id", homeId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //Milestones milestone = new Milestones();

                            milestone.HomeId = Convert.ToInt32(reader["home_id"]);
                            milestone.BuildYear = Convert.ToInt32(reader["build_year"]);
                            milestone.PurchaseYear = Convert.ToInt32(reader["purchase_date"]);

                            //listMilestones.Add(milestone);

                        }
                    }

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            //return listMilestones;
            return milestone;

        }

        public bool UpdateMilestones(int homeId, int buildYear, int purchaseYear)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"UPDATE milestones SET build_year = @build_year, purchase_date = @purchase_date WHERE home_id = @home_id", conn);

                    cmd.Parameters.AddWithValue("@home_id", homeId);
                    cmd.Parameters.AddWithValue("@build_year", buildYear);
                    cmd.Parameters.AddWithValue("@purchase_date", purchaseYear);

                    int result = Convert.ToInt32(cmd.ExecuteScalar());

                    return result > 0;

                }
            }
            catch (SqlException ex)
            {
                throw ex;

            }
        }

        public bool AddMileStones(int homeId, int year, int purchaseDate)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO milestones (home_id, build_year, purchase_date) VALUES(@home_id, @build_year, @purchase_date)", conn);
                    cmd.Parameters.AddWithValue("@home_id", homeId);
                    cmd.Parameters.AddWithValue("@build_year", year);
                    cmd.Parameters.AddWithValue("@purchase_date", purchaseDate);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool DeleteMilestones (int homeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"DELETE milestones WHERE home_id = @home_id", conn);

                    cmd.Parameters.AddWithValue("@home_id", homeId);                   
                    int result = cmd.ExecuteNonQuery();

                    return result > 0;

                }
            }
            catch (SqlException ex)
            {
                throw ex;

            }
        }

        public List<Repair> GetRepairs(int userId, int homeId)
        {
            List<Repair> repairs = new List<Repair>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from repairs where user_id = @user_id and home_id = @home_id ", conn);
                    cmd.Parameters.AddWithValue("@home_id", homeId);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Repair repair = new Repair();
                            repair.UserId = Convert.ToInt32(reader["user_id"]);
                            repair.HomeId = Convert.ToInt32(reader["home_id"]);
                            repair.ProjectedCost = Convert.ToDecimal(reader["projected_cost"]);
                            repair.Cost = Convert.ToDecimal(reader["cost"]);
                            repair.LastRepairDate = Convert.ToDateTime(reader["last_repair_date"]).ToString("MM-dd-yyyy"); ;
                            repair.ExpectedLife = Convert.ToInt32(reader["expected_life"]);
                            repair.PotentialReplacementDate = Convert.ToDateTime(reader["potential_replacement_date"]).ToString("MM-dd-yyyy"); ;
                            repair.Description = Convert.ToString(reader["description"]);
                            repair.RepairId = Convert.ToInt32(reader["repair_id"]);
                            repair.Name = Convert.ToString(reader["name"]);
                            
                            repairs.Add(repair);

                        }
                    }

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return repairs;


        }

        public Repair GetRepair(int userId, int repairId)
        {
            Repair repair = new Repair();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from repairs where user_id = @user_id and repair_id = @repair_id ", conn);
                    cmd.Parameters.AddWithValue("@repair_id", repairId);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            repair.HomeId = Convert.ToInt32(reader["home_id"]);
                            repair.ProjectedCost = Convert.ToDecimal(reader["projected_cost"]);
                            repair.Cost = Convert.ToDecimal(reader["cost"]);
                            repair.LastRepairDate = Convert.ToDateTime(reader["last_repair_date"]).ToString("MM-dd-yyyy"); ;
                            repair.ExpectedLife = Convert.ToInt32(reader["expected_life"]);
                            repair.PotentialReplacementDate = Convert.ToDateTime(reader["potential_replacement_date"]).ToString("MM-dd-yyyy"); ;
                            repair.Description = Convert.ToString(reader["description"]);
                        }
                    }

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return repair;


        }
        public bool AddRepair(Repair repair)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO repairs (home_id, user_id, name ,projected_cost, cost, last_repair_date, expected_life, potential_replacement_date, description) VALUES(@home_id, @user_id, @name , @projected_cost, @cost, @last_repair_date, @expected_life, @potential_replacement_date, @description); SELECT @@IDENTITY", conn);
                    cmd.Parameters.AddWithValue("@home_id", repair.HomeId);
                    cmd.Parameters.AddWithValue("@user_id", repair.UserId);
                    cmd.Parameters.AddWithValue("@name", repair.Name);
                    cmd.Parameters.AddWithValue("@projected_cost", repair.ProjectedCost);
                    cmd.Parameters.AddWithValue("@cost", repair.Cost);
                    cmd.Parameters.AddWithValue("@last_repair_date", repair.LastRepairDate);
                    cmd.Parameters.AddWithValue("@expected_life", repair.ExpectedLife);
                    cmd.Parameters.AddWithValue("@potential_replacement_date", repair.PotentialReplacementDate);
                    cmd.Parameters.AddWithValue("@description", repair.Description);

                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    SqlCommand cmd2 = new SqlCommand("insert into reminders (home_id, user_id, repair_id, type, name, reminder_date) values (@home_id, @user_id, @repair_id, @type, @name, @reminder_date ) ", conn);
                    cmd2.Parameters.AddWithValue("@home_id", repair.HomeId);
                    cmd2.Parameters.AddWithValue("@user_id", repair.UserId);
                    cmd2.Parameters.AddWithValue("@repair_id", result);
                    //cmd2.Parameters.AddWithValue("@appliance_id", 0);
                    cmd2.Parameters.AddWithValue("@type", "Repair");
                    cmd2.Parameters.AddWithValue("@name", repair.Name );
                    cmd2.Parameters.AddWithValue("@reminder_date", repair.PotentialReplacementDate);



                    int rowsAffected = cmd2.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;

            }
        }
        public bool UpdateRepair(Repair repair)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"
                        Update repairs set name = @name, projected_cost = @projected_cost, cost = @cost, last_repair_date = @last_repair_date, expected_life = @expected_life, 
                        potential_replacement_date = @potential_replacement_date , description = @description where repair_id = @repair_id; UPDATE reminders set name = @name where repair_id = @repair_id", conn);

                    cmd.Parameters.AddWithValue("@repair_id", repair.RepairId);
                    cmd.Parameters.AddWithValue("@name", repair.Name);
                    cmd.Parameters.AddWithValue("@projected_cost", repair.ProjectedCost);
                    cmd.Parameters.AddWithValue("@cost", repair.Cost);
                    cmd.Parameters.AddWithValue("@last_repair_date", repair.LastRepairDate);
                    cmd.Parameters.AddWithValue("@expected_life", repair.ExpectedLife);
                    cmd.Parameters.AddWithValue("@potential_replacement_date", repair.PotentialReplacementDate);
                    cmd.Parameters.AddWithValue("@description", repair.Description);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool DeleteRepair(int userId, int repairId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE reminders where repair_id = @repair_id; DELETE repairs where user_id = @user_id AND repair_id = @repair_id", conn);

                    cmd.Parameters.AddWithValue("@repair_id", repairId);
                    cmd.Parameters.AddWithValue("@user_id", userId);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public Appliance GetAppliance(int userId, int applianceId)
        {
            Appliance appliance = new Appliance();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from appliance where user_id = @user_id and appliance_id = @appliance_id ", conn);
                    cmd.Parameters.AddWithValue("@appliance_id", applianceId);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            appliance.ApplianceId = Convert.ToInt32(reader["appliance_id"]);
                            appliance.HomeId = Convert.ToInt32(reader["home_id"]);
                            appliance.UserId = Convert.ToInt32(reader["user_id"]);
                            appliance.Name = Convert.ToString(reader["name"]);
                            appliance.Make = Convert.ToString(reader["make"]);
                            appliance.Cost = Convert.ToDecimal(reader["cost"]);
                            appliance.ModelNumber = Convert.ToString(reader["model_number"]);
                            appliance.SerialNumber = Convert.ToString(reader["serial_number"]);
                            appliance.WarrantyExpiration = Convert.ToString(reader["warranty_expiration"]);
                            appliance.PurchaseDate = Convert.ToDateTime(reader["purchase_date"]).ToString("MM-dd-yyyy");
                            appliance.Description = Convert.ToString(reader["description"]);
                            appliance.EstimatedDelivery = Convert.ToDateTime(reader["estimated_delivery"]).ToString("MM-dd-yyyy");
                            appliance.DeliveryDate = Convert.ToDateTime(reader["delivery_date"]).ToString("MM-dd-yyyy");
                            appliance.ReceiptUrl = Convert.ToString(reader["receipt_url"]);
                        }
                    }

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return appliance;
        }

        public List<Appliance> GetAppliances(int userId, int homeId)
        {
            List<Appliance> appliances = new List<Appliance>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from appliance where user_id = @user_id and home_id = @home_id ", conn);
                    cmd.Parameters.AddWithValue("@home_id", homeId);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Appliance appliance = new Appliance();

                            appliance.ApplianceId = Convert.ToInt32(reader["appliance_id"]);
                            appliance.HomeId = Convert.ToInt32(reader["home_id"]);
                            appliance.UserId = Convert.ToInt32(reader["user_id"]);
                            appliance.Name = Convert.ToString(reader["name"]);
                            appliance.Make = Convert.ToString(reader["make"]);
                            appliance.Cost = Convert.ToDecimal(reader["cost"]);
                            appliance.ModelNumber = Convert.ToString(reader["model_number"]);
                            appliance.SerialNumber = Convert.ToString(reader["serial_number"]);
                            appliance.WarrantyExpiration = Convert.ToDateTime(reader["warranty_expiration"]).ToString("MM-dd-yyyy");
                            appliance.PurchaseDate = Convert.ToDateTime(reader["purchase_date"]).ToString("MM-dd-yyyy");
                            appliance.Description = Convert.ToString(reader["description"]);
                            appliance.EstimatedDelivery = Convert.ToDateTime(reader["estimated_delivery"]).ToString("MM-dd-yyyy");
                            appliance.DeliveryDate = Convert.ToDateTime(reader["delivery_date"]).ToString("MM-dd-yyyy");
                            appliance.ReceiptUrl = Convert.ToString(reader["receipt_url"]);

                            appliances.Add(appliance);

                        }
                    }

                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return appliances;
        }
        public bool AddAppliance(Appliance appliance)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO appliance ( home_id, user_id , name, make, cost, model_number, serial_number, warranty_expiration, purchase_date, description, estimated_delivery, delivery_date, receipt_url)     
                    VALUES( @home_id, @user_id , @name, @make,@cost, @model_number, @serial_number, @warranty_expiration, @purchase_date, @description, @estimated_delivery, @delivery_date, @receipt_url); SELECT @@IDENTITY", conn);



                    cmd.Parameters.AddWithValue("@home_id", appliance.HomeId);
                    cmd.Parameters.AddWithValue("@user_id", appliance.UserId);
                    cmd.Parameters.AddWithValue("@name", appliance.Name);
                    cmd.Parameters.AddWithValue("@make", appliance.Make);
                    cmd.Parameters.AddWithValue("@cost", appliance.Cost);
                    cmd.Parameters.AddWithValue("@model_number", appliance.ModelNumber);
                    cmd.Parameters.AddWithValue("@serial_number", appliance.SerialNumber);
                    cmd.Parameters.AddWithValue("@warranty_expiration", appliance.WarrantyExpiration);
                    cmd.Parameters.AddWithValue("@purchase_date", appliance.PurchaseDate);
                    cmd.Parameters.AddWithValue("@description", appliance.Description);
                    cmd.Parameters.AddWithValue("@estimated_delivery", appliance.EstimatedDelivery);
                    cmd.Parameters.AddWithValue("@delivery_date", appliance.DeliveryDate);
                    cmd.Parameters.AddWithValue("@receipt_url", appliance.ReceiptUrl);

                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    SqlCommand cmd2 = new SqlCommand("insert into reminders (home_id, user_id ,appliance_id ,type,  name, reminder_date) values (@home_id, @user_id, @appliance_id, @type,  @name, @reminder_date) ", conn);
                    cmd2.Parameters.AddWithValue("@home_id", appliance.HomeId);
                    cmd2.Parameters.AddWithValue("@user_id", appliance.UserId);
                    cmd2.Parameters.AddWithValue("@appliance_id", result);
                    cmd2.Parameters.AddWithValue("@type", "Appliance");
                    cmd2.Parameters.AddWithValue("@name", appliance.Name);
                    cmd2.Parameters.AddWithValue("@reminder_date", appliance.WarrantyExpiration);

                    int rowsAffected = cmd2.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }

                
                
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public bool UpdateAppliance(Appliance appliance)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"Update appliance 
                    set name = @name, make = @make, cost = @cost, model_number = @model_number, serial_number = @serial_number, warranty_expiration = @warranty_expiration,
                    purchase_date = @purchase_date, description = @description, estimated_delivery = @estimated_delivery, delivery_date = @delivery_date, receipt_url = @receipt_url
                    where appliance_id = @appliance_id; UPDATE reminders set name = @name where appliance_id = @appliance_id", conn);


                    cmd.Parameters.AddWithValue("@appliance_id", appliance.ApplianceId);
                    cmd.Parameters.AddWithValue("@name", appliance.Name);
                    cmd.Parameters.AddWithValue("@make", appliance.Make);
                    cmd.Parameters.AddWithValue("@cost", appliance.Cost);
                    cmd.Parameters.AddWithValue("@model_number", appliance.ModelNumber);
                    cmd.Parameters.AddWithValue("@serial_number", appliance.SerialNumber);
                    cmd.Parameters.AddWithValue("@warranty_expiration", appliance.WarrantyExpiration);
                    cmd.Parameters.AddWithValue("@purchase_date", appliance.PurchaseDate);
                    cmd.Parameters.AddWithValue("@description", appliance.Description);
                    cmd.Parameters.AddWithValue("@estimated_delivery", appliance.EstimatedDelivery);
                    cmd.Parameters.AddWithValue("@delivery_date", appliance.DeliveryDate);
                    cmd.Parameters.AddWithValue("@receipt_url", appliance.ReceiptUrl);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException)
            {
                return false;
            }

        }

        public bool DeleteAppliance(int userId, int applianceId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE reminders where appliance_id = @appliance_id; DELETE appliance where user_id = @user_id AND appliance_id = @appliance_id", conn);

                    cmd.Parameters.AddWithValue("@appliance_id", applianceId);
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<Vendor> GetVendors(int repId)
        {

            List<Vendor> vendors = new List<Vendor>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from vendor v JOIN repairs r on r.home_id = v.home_id JOIN home h on h.home_id = r.home_id where r.repair_id = @repair_id", conn);
                    cmd.Parameters.AddWithValue("@repair_id", repId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Vendor vendor = new Vendor();

                            vendor.HomeId = Convert.ToInt32(reader["home_id"]);
                            vendor.VendorId = Convert.ToInt32(reader["service_id"]);
                            vendor.VendorName = Convert.ToString(reader["vendor_name"]);
                            vendor.Phone = Convert.ToString(reader["phone"]);
                            vendor.Email = Convert.ToString(reader["email"]);
                            vendor.Specialty = Convert.ToString(reader["specialty"]);
                            vendor.Notes = Convert.ToString(reader["notes"]);
                            vendor.Zip = Convert.ToInt32(reader["zip"]);
                            vendor.Name = Convert.ToString(reader["name"]);

                            vendors.Add(vendor);

                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return vendors;
        }

        public List<Vendor> GetStores(int appId)
        {
            List<Vendor> vendors = new List<Vendor>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from store s JOIN appliance a on a.home_id = s.home_id JOIN home h on h.home_id = a.home_id where a.appliance_id = @appliance_id", conn);
                    cmd.Parameters.AddWithValue("@appliance_id", appId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Vendor vendor = new Vendor();

                            vendor.HomeId = Convert.ToInt32(reader["home_id"]);
                            vendor.VendorId = Convert.ToInt32(reader["store_id"]);
                            vendor.VendorName = Convert.ToString(reader["store_name"]);
                            vendor.Phone = Convert.ToString(reader["phone"]);
                            vendor.Notes = Convert.ToString(reader["notes"]);
                            vendor.Zip = Convert.ToInt32(reader["zip"]);
                            vendor.Name = Convert.ToString(reader["name"]);

                            vendors.Add(vendor);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return vendors;
        }

        public List<Vendor> GetStoreList(int homeId)
        {
            List<Vendor> vendors = new List<Vendor>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from store where home_id = @home_id", conn);
                    cmd.Parameters.AddWithValue("@home_id", homeId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Vendor vendor = new Vendor();

                            vendor.HomeId = Convert.ToInt32(reader["home_id"]);
                            vendor.VendorName = Convert.ToString(reader["store_name"]);
                            vendor.Phone = Convert.ToString(reader["phone"]);
                            vendor.Notes = Convert.ToString(reader["notes"]);
                            vendor.VendorId = Convert.ToInt32(reader["store_id"]);
                            //vendor.Name = Convert.ToString(reader["name"]);

                            vendors.Add(vendor);

                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return vendors;
        }
        public List<Vendor> GetServiceList(int homeId)
        {
            List<Vendor> services = new List<Vendor>();


            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("select * from vendor where home_id = @home_id", conn);
                    cmd.Parameters.AddWithValue("@home_id", homeId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Vendor service = new Vendor();

                            service.HomeId = Convert.ToInt32(reader["home_id"]);
                            service.VendorName = Convert.ToString(reader["vendor_name"]);
                            service.Email = Convert.ToString(reader["email"]);
                            service.Phone = Convert.ToString(reader["phone"]);
                            service.Specialty = Convert.ToString(reader["specialty"]);
                            service.Notes = Convert.ToString(reader["notes"]);
                            service.VendorId = Convert.ToInt32(reader["service_id"]);
                            //vendor.Name = Convert.ToString(reader["name"]);

                            services.Add(service);

                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return services;
        }
        public bool AddVendor(Home home, int homeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT into vendor(home_id, vendor_name, phone, email, specialty, notes) VALUES(@home_id, @vendor_name, @phone, @email, @specialty, @notes)", conn);


                    cmd.Parameters.AddWithValue("@home_id", homeId);
                    cmd.Parameters.AddWithValue("@vendor_name", home.VendorName);
                    cmd.Parameters.AddWithValue("@phone", home.VendorPhone);
                    cmd.Parameters.AddWithValue("@email", home.VendorEmail);
                    cmd.Parameters.AddWithValue("@specialty", home.VendorSpecialty);
                    cmd.Parameters.AddWithValue("@notes", home.VendorNotes);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public bool AddStore(Home home, int homeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT into store(home_id, store_name, phone, notes) VALUES(@home_id, @store_name, @phone, @notes)", conn);

                    cmd.Parameters.AddWithValue("@home_id", homeId);
                    cmd.Parameters.AddWithValue("@store_name", home.StoreName);
                    cmd.Parameters.AddWithValue("@phone", home.StorePhone);
                    cmd.Parameters.AddWithValue("@notes", home.StoreNotes);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public bool AddNewStore(Vendor vendor)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT into store(home_id, store_name, phone, notes) VALUES(@home_id, @store_name, @phone, @notes)", conn);

                    cmd.Parameters.AddWithValue("@home_id", vendor.HomeId);
                    cmd.Parameters.AddWithValue("@store_name", vendor.VendorName);
                    cmd.Parameters.AddWithValue("@phone", vendor.Phone);
                    cmd.Parameters.AddWithValue("@notes", vendor.Notes);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public bool AddNewService(Vendor service)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT into vendor(home_id, vendor_name, email, specialty, phone, notes) VALUES(@home_id, @vendor_name, @email, @specialty, @phone, @notes)", conn);
                                                          
                    cmd.Parameters.AddWithValue("@home_id", service.HomeId);
                    cmd.Parameters.AddWithValue("@vendor_name", service.VendorName);
                    cmd.Parameters.AddWithValue("@email", service.Email);
                    cmd.Parameters.AddWithValue("@phone", service.Phone);
                    cmd.Parameters.AddWithValue("@specialty", service.Specialty);
                    cmd.Parameters.AddWithValue("@notes", service.Notes);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public bool UpdateStore(Vendor vendor)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Update store SET store_name = @store_name, phone = @phone, notes = @notes WHERE store_id = @store_id", conn);

                    cmd.Parameters.AddWithValue("@store_id", vendor.VendorId);
                    cmd.Parameters.AddWithValue("@store_name", vendor.VendorName);
                    cmd.Parameters.AddWithValue("@phone", vendor.Phone);
                    cmd.Parameters.AddWithValue("@notes", vendor.Notes);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public bool UpdateService(Vendor service)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Update vendor SET vendor_name = @vendor_name, email = @email, specialty = @specialty, phone = @phone, notes = @notes WHERE service_id = @vendor_id", conn);

                    cmd.Parameters.AddWithValue("@vendor_id", service.VendorId);
                    cmd.Parameters.AddWithValue("@vendor_name", service.VendorName);
                    cmd.Parameters.AddWithValue("@email", service.Email);
                    cmd.Parameters.AddWithValue("@phone", service.Phone);
                    cmd.Parameters.AddWithValue("@specialty", service.Specialty);
                    cmd.Parameters.AddWithValue("@notes", service.Notes);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public bool DeleteStore(int storeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Delete store WHERE store_id = @store_id", conn);

                    cmd.Parameters.AddWithValue("@store_id", storeId);
                    

                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public bool DeleteService(int serviceId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Delete vendor WHERE service_id = @service_id", conn);

                    cmd.Parameters.AddWithValue("@service_id", serviceId);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

    }
}
