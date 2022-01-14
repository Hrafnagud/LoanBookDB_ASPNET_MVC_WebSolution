using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanBookDB_ASPNET_MVC_Web_BLL.Managers
{
    public class LoanOperationManager
    {
        LOANBOOKDBEntities dbContext = new LOANBOOKDBEntities();
        public bool AddLoanOperation(Loan newLoanOperation)
        {
            try
            {
                bool result = false;
                dbContext.Loans.Add(newLoanOperation);
                dbContext.SaveChanges();
                result = true;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
