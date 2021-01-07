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
    public class VendorController : Controller
    {
        private IUserDAO userDAO;
        private IHomeDAO homeDAO;

        public VendorController(IHomeDAO homeDAO, IUserDAO userDAO)
        {
            this.homeDAO = homeDAO;
            this.userDAO = userDAO;
        }
        [HttpGet("/map/{id}")]
        public List<Vendor> GetVendors(string id)
        {
            int vendorId = Convert.ToInt32(id.Substring(1));
            List<Vendor> vendors = new List<Vendor>(); 

            if (id.Contains("r"))
            {
                vendors = homeDAO.GetVendors(vendorId);
                
            }
            else
            {
                vendors = homeDAO.GetStores(vendorId);
            }

            return vendors;

        }

        [HttpGet("/stores/{id}")]
        public List<Vendor> GetStores(int id)
        {

            List<Vendor> vendors = new List<Vendor>();            
            
                vendors = homeDAO.GetStoreList(id);
           

            return vendors;

        }


        [HttpPost("/stores/{homeId}")]
        public ActionResult AddStore(Vendor store)
        {
            homeDAO.AddNewStore(store);
            return Created(store.VendorName, null);

        }

        [HttpPut("/stores/{homeId}")]
        public ActionResult UpdateStore(Vendor store)
        {
            homeDAO.UpdateStore(store);
            return Ok();

        }

        [HttpDelete("/stores/{storeId}")]
        public ActionResult DeleteStore(int storeId)
        {
            homeDAO.DeleteStore(storeId);
            return Ok();
        }
        [HttpGet("/services/{homeid}")]
        public List<Vendor> GetServiceList(int homeid)
        {
            List<Vendor> vendors = new List<Vendor>();
            vendors = homeDAO.GetServiceList(homeid);

            return vendors;
        }
        [HttpPost("/services/{homeId}")]
        public ActionResult AddService(Vendor service)
        {
            homeDAO.AddNewService(service);
            return Created(service.VendorName, null);

        }

        [HttpPut("/services/{homeId}")]
        public ActionResult UpdateService(Vendor service)
        {
            homeDAO.UpdateService(service);
            return Ok();

        }

        [HttpDelete("/services/{serviceId}")]
        public ActionResult DeleteService(int serviceId)
        {
            homeDAO.DeleteService(serviceId);
            return Ok();

        }
    }

}
