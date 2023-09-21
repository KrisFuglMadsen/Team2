using Reolmarkedet_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reolmarkedet_System.ViewModel
{
    public class ViewModelTenant
    {
        public static List<string> GetTenantFullnameFromModel()
        {
            List<string> result = Model.Tenant.GetTenantFullName();
            return result;
        }
    }
}
