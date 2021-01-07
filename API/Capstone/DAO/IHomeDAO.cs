using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;


namespace Capstone.DAO
{
    public interface IHomeDAO
    {
        Home GetHome(int userId, int homeid);
        List<Home> GetHomes(int userId);
        int AddHome(Home home);
        Milestones GetMilestones(int homeId);
        bool AddMileStones(int homeId, int year, int purchaseDate);
        List<Repair> GetRepairs(int userId,int homeId);
        bool AddRepair(Repair repair);
        bool DeleteRepair(int userId, int repairId);
        bool UpdateRepair(Repair repair);
        List<Appliance> GetAppliances(int userId, int homeId);
        bool AddAppliance(Appliance appliance);
        bool UpdateAppliance(Appliance appliance);
        bool DeleteAppliance(int user_id, int applianceId);
        List<Vendor> GetStores(int appId);
        bool AddVendor(Home home, int homeId);
        bool AddStore(Home home, int homeId);

        List<Vendor> GetVendors(int homeId);

        Repair GetRepair(int userId, int repairId);

        Appliance GetAppliance(int userId, int applianceId);
        //List<Reminder> Reminder(User user, int homeId);

        bool UpdateMilestones(int homeId, int buildYear, int purchaseYear);
        bool UpdateHome(Home home);

        bool DeleteHome(int userId, int homeId);

        bool DeleteMilestones(int homeId);

        bool AddNewStore(Vendor vendor);

        List<Vendor> GetStoreList(int homeId);

        bool UpdateStore(Vendor vendor);

        bool DeleteStore(int storeId);
        List<Vendor> GetServiceList(int homeId);
        bool AddNewService(Vendor service);
        bool UpdateService(Vendor service);
        bool DeleteService(int serviceId);
    }
}
