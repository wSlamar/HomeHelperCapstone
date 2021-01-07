using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IUserDAO
    {
        User GetUser(string username);
        User AddUser(string username, string password, string role, string firstName, string lastName, string email, string phoneNumber, string billingStreetAddress, string billingCity, string billingState, string billingZip);
        bool UpdateUserInfo(User user);
        //bool Updatebilling(int userId, string billingStreetAddress, string billingCity, string billingState, string billingZip);
        string[] GetUsernames();
    }    
}
