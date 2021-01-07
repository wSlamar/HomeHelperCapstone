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
    [Authorize]
    public class ApplianceController : ControllerBase
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

        public ApplianceController(IHomeDAO homeDAO, IUserDAO userDAO)
        {
            this.homeDAO = homeDAO;
            this.userDAO = userDAO;
        }

        [HttpGet("/appliances/{homeId}")]

        public ActionResult<List<Appliance>> GetAppliances(int homeId)
        {
            List<Appliance> appliances = homeDAO.GetAppliances(UserId, homeId);

            if (appliances.Count != 0)
            {
                if (appliances[0].UserId != UserId)
                {
                    return Forbid();
                }

                return appliances;
            }
            return  null;
        }

        [HttpPost("/appliances/{homeId}")]
        
        public IActionResult AddAppliance(Appliance appliance)
        {
            if(appliance.UserId == UserId)
            {
                homeDAO.AddAppliance(appliance);
                return Created(appliance.Name,null);
            }
            return Forbid();
             
        }
        [HttpPut("/appliances/{homeId}")]

        public ActionResult UpdateAppliance(Appliance appliance)
        {
            //if (appliance.Name == "" && appliance.ModelNumber == "" && appliance.SerialNumber == "")
            //{
            //    homeDAO.DeleteAppliance(UserId, appliance.HomeId, appliance.ApplianceId);
            //    return Ok();
            //}
            if (appliance.UserId == UserId)
            {
                homeDAO.UpdateAppliance(appliance);
                return Ok();
            }
            return Forbid();
            
        }



        [HttpDelete("/appliances/{applianceId}")]
        public ActionResult DeleteAppliance(int applianceId)
        {
            if (homeDAO.DeleteAppliance(UserId, applianceId))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        //[HttpGet("/map/{id}")]

        //public List<Vendor> GetAppliance(string id)
        //{
        //    Appliance appliance = new Appliance();
        //    int applianceId = Convert.ToInt32(id.Substring(1));
        //    appliance = homeDAO.GetAppliance(UserId, applianceId);
        //    appliance.DeliveryZip = homeDAO.GetHome(UserId, appliance.HomeId).Zip;
        //    return appliance;
        //}
    }
}
