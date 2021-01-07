using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class RepairController : Controller
    {
        private IUserDAO userDAO;
        private IHomeDAO homeDAO;
        private int UserId
        {
            get
            {
                return Convert.ToInt32(User.Claims.FirstOrDefault(cl => cl.Type == "sub").Value);
            }
        }
        private  string UserRole
        {
            get
            {
                return User.Claims.FirstOrDefault(cl => cl.Type == ClaimTypes.Role).Value;
            }
        }

        public RepairController(IHomeDAO homeDAO, IUserDAO userDAO)
        {
            this.homeDAO = homeDAO;
            this.userDAO = userDAO;
        }
        [HttpGet("/repairs/{homeId}")]
        public ActionResult<List<Repair>> GetRepairs(int homeId)
        {
            //string admin = "admin";

            List<Repair> repairs = homeDAO.GetRepairs(UserId,homeId);
            //if (repairs[0].UserId != UserId || UserRole.ToLower() == admin.ToLower())
            //{
            //    return Forbid();
            //}

            return repairs;
            
        }
        [HttpPost("/repairs/{homeId}")]
        public IActionResult AddRepair(RepairDate dateRepair)
        {
            Repair repair = new Repair();

            repair.RepairId = dateRepair.RepairId;
            repair.HomeId = dateRepair.HomeId;
            repair.UserId = dateRepair.UserId;
            repair.Name = dateRepair.Name;
            repair.ProjectedCost = Convert.ToDecimal(dateRepair.ProjectedCost);
            repair.Cost = Convert.ToDecimal(dateRepair.Cost);
            repair.LastRepairDate = dateRepair.LastRepairDate; //Convert.ToString(dateRepair.LastRepairDate);
            repair.ExpectedLife = dateRepair.ExpectedLife;
            repair.PotentialReplacementDate = dateRepair.PotentialReplacementDate;// Convert.ToString(dateRepair.PotentialReplacementDate);
            repair.Description = dateRepair.Description; 


           
           
            if (repair.UserId == UserId)
            {
                homeDAO.AddRepair(repair);
                return Created(repair.Name,null);
            }
            return Forbid();
            
        }
        [HttpPut("/repairs/{homeId}")]

        public ActionResult UpdateRepair(Repair repair)
        {
            if (repair.UserId == UserId)
            {
                homeDAO.UpdateRepair(repair);
                return Ok();
            }
            return Forbid();
            
        }
        [HttpDelete("/repairs/{repairid}")]
        public ActionResult DeleteRepair(int repairId)
        {
            if (homeDAO.DeleteRepair(UserId, repairId))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
