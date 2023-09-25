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
        private TenantRepo tenantRepo = new TenantRepo();

        public List<string> GetTenantFullnameFromModel()
        {
            //List<string> result = Tenant.GetTenantFullName();
            return tenantRepo.GetTenantFullName();
           
        }
    }
}
