using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanBookDB_ASPNET_MVC_Web_BLL.Managers
{
    public class AuthorManager
    {
        LOANBOOKDBEntities dbContext = new LOANBOOKDBEntities();

        public List<Author> BringAllActiveAuthors()
        {
            try
            {
                List<Author> authorList = new List<Author>();
                authorList = dbContext.Authors.Where(x => !x.IsPassive).ToList();
                return authorList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
