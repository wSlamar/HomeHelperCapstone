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
    public class UserController : ControllerBase
    {
        private IUserDAO userDAO;
        private IHomeDAO homeDAO;
        private User user;
        private int userid;

        public UserController(IHomeDAO homeDAO, IUserDAO userDAO)
        {
            this.homeDAO = homeDAO;
            this.userDAO = userDAO;
        }
        private int UserId
        {
            get
            {
                return Convert.ToInt32(User.Claims.FirstOrDefault(cl => cl.Type == "sub").Value);
            }
        }
        [Authorize]
        [HttpGet("/profile")]
       public User GetUserInfo()
        {
            return user = userDAO.GetUser(UserName);
        }

        
        [HttpGet("/register")]
        public Array GetUsernames()
        {
            return userDAO.GetUsernames();
        }

        //[Authorize]
        //[HttpGet("auth")]
        //public ActionResult GetUserId(string username)
        //{
        //    userid = userDAO.GetUser(username).UserId;
        //    return Ok();
        //}

        [HttpPut("/profile")]
        public ActionResult UpdateUser(User user)
        {
            if (user.UserId == UserId)
            {
                userDAO.UpdateUserInfo(user);
                return Ok();
            }
            return Forbid();
        }

        private string UserName
        {
            get
            {
                return User.Identity.Name;
            }
        }

    }
}
