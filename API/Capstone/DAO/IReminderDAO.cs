using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;


namespace Capstone.DAO
{
    public interface IReminderDAO
    {
        void GetMailReminders(User user);
        void GetMailReminders();
        List<ReminderHome> GetReminderHomes(int homeId);
        HomeReminder GetReminderHome(int homeId);
    }
}
