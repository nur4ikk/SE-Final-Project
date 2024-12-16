using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_System_Development_Plan
{
    public class Helper
    {

        public static bool IsAdmin;
     
        // Use Application Base Directory for Consistent File Placement
        public static string connectionString =
            $"Data Source={AppDomain.CurrentDomain.BaseDirectory}CRMSystemDevelopmentPlan.db;Version=3;";
    }
}
