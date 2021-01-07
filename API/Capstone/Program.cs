using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Capstone
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        //public void ExecuteReminder(User user, int homeId)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            SqlCommand cmd = new SqlCommand("select * from home h join reminders r on r.home_id = h.home_id where h.home_id = @home_id and r.completed = 0 and (r.reminder_date BETWEEN GETDATE() AND GETDATE()+30)", conn);

        //            cmd.Parameters.AddWithValue("@home_id", homeId);

        //            int result = Convert.ToInt32(cmd.ExecuteScalar());

        //            if (result != 0)
        //            {
        //                Reminder(user, homeId);

        //            }
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }

        //}

    }
}
