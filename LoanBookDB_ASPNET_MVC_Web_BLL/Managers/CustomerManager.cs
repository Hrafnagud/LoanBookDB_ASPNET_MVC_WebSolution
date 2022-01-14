using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanBookDB_ASPNET_MVC_Web_BLL.Managers
{
    public class CustomerManager
    {
        //Global
        LOANBOOKDBEntities dbContext = new LOANBOOKDBEntities();

        public List<Customer> BringAllActiveCustomers()
        {
            try
            {
                List<Customer> customerList = new List<Customer>();
                customerList = dbContext.Customers.Where(x => !x.IsPassive).ToList();
                return customerList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
