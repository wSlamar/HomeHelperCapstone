using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private IUserDAO userDAO;
        private IHomeDAO homeDAO;
        //private int userid;
        private int homeid;
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

        public HomeController(IHomeDAO homeDAO, IUserDAO userDAO)
        {

            this.homeDAO = homeDAO;
            this.userDAO = userDAO;
        }

        //[HttpGet("/homedetail/{homeid}")]
        //[Authorize]
        //public ActionResult<List<Reminder>> GetHome(int homeId)
        //{
        //    Home home = homeDAO.GetHome(UserId, homeId);
        //    Milestones milestones = homeDAO.GetMilestones(homeId);
        //    home.PurchaseYear = milestones.PurchaseYear;
        //    home.BuildYear = milestones.BuildYear;
        //    User user = userDAO.GetUser(UserName);
        //    if (home.UserId != UserId)
        //    {
        //        return Forbid();
        //    }

        //    return homeDAO.Reminder(user, homeId);
        //}

        [HttpPut("/homedetail/{homeid}")]
        [Authorize]
        public ActionResult<List<Reminder>> UpdateHome(Home home)
        {
            if (home.UserId != UserId)
            {
                return Forbid();
            }
            homeDAO.UpdateHome(home);
            homeDAO.UpdateMilestones(home.HomeId, home.BuildYear, home.PurchaseYear);
            return Ok();
        }


        [HttpDelete("/homedetail/{homeid}")]
        [Authorize]
        public ActionResult DeleteHome(int homeId)
        {
            if (homeDAO.GetHome(UserId, homeId).HomeId == homeId)
            {
                if (homeDAO.DeleteMilestones(homeId))
                {
                    if (homeDAO.DeleteHome(UserId, homeId))
                    {
                        return NoContent();
                    }
                }
            }
                        
            
                return NotFound();
                     
        }

        //[HttpGet("/homedetail/{homeid}")]
        //[Authorize]
        //public List<Reminder> GetReminders(int homeid)
        //{
        //    User user = userDAO.GetUser(UserName);
        //    return homeDAO.Reminder(user, homeid);
        //}
        [HttpGet("/myhomes")]
        [Authorize]
        public List<Home> GetHomes()
        {
            return homeDAO.GetHomes(UserId);
        }

        //[HttpPost("/addhome")]
        //[Authorize]
        //public ActionResult AddHome(Home home)
        //{
        //    home.UserId = this.UserId;
        //    homeDAO.AddHome(home);
        //    return Ok();
        //}
        [HttpPost("/addhome")]

        [Authorize]
        public IActionResult AddHome(Home home)
        {
            home.UserId = this.UserId;
            this.homeid = homeDAO.AddHome(home);
            homeDAO.AddMileStones(homeid, home.BuildYear, home.PurchaseYear);
            homeDAO.AddVendor(home, homeid);
            homeDAO.AddStore(home, homeid);
            return Created(home.StreetAddress, null);
        }

        [HttpPost("/stores/:homeId")]
        //[Authorize]
        public ActionResult AddNewStore(Vendor vendor)
        {
            
            homeDAO.AddNewStore(vendor);
            return Created(vendor.VendorName, null);
        }

        //[Authorize]
        //[HttpGet("auth")]
        //public ActionResult GetUserInfo(string username)
        //{
        //    userid = userDAO.GetUser(username).UserId;
        //    return Ok();
        //}



        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
