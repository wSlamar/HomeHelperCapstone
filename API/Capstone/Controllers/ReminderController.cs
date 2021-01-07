using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;

using System.Security.Claims;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ReminderController : Controller
    {
        private IUserDAO userDAO;
        private IHomeDAO homeDAO;
        private IReminderDAO reminderDAO;
        private int UserId
        {
            get
            {
                return Convert.ToInt32(User.Claims.FirstOrDefault(cl => cl.Type == "sub").Value);
            }
        }
        private string UserName
        {
            get
            {
                return User.Identity.Name;
            }
        }


        public ReminderController(IHomeDAO homeDAO, IUserDAO userDAO, IReminderDAO reminderDAO)
        {
            this.reminderDAO = reminderDAO;
            this.homeDAO = homeDAO;
            this.userDAO = userDAO;
        }

        [HttpGet("/reminders")]
        public void GetMailReminders()
        {

            reminderDAO.GetMailReminders();

        }
        [HttpGet("/homedetail/{homeid}")]
        [Authorize]
        public ActionResult<HomeReminder> GetReminderHome(int homeId)
        //public ActionResult<List<ReminderHome>> GetReminderHome(int homeId)
        {
            Home home = homeDAO.GetHome(UserId, homeId);
            Milestones milestones = homeDAO.GetMilestones(homeId);
            home.PurchaseYear = milestones.PurchaseYear;
            home.BuildYear = milestones.BuildYear;
            User user = userDAO.GetUser(UserName);
            if (home.UserId != UserId)
            {
                return Forbid();
            }
           
            reminderDAO.GetMailReminders(user);
            return reminderDAO.GetReminderHome(homeId);
            //return reminderDAO.GetReminderHomes(homeId);
        }

    }
}
