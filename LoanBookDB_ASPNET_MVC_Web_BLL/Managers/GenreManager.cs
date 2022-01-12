using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanBookDB_ASPNET_MVC_Web_BLL.Managers
{
    public class GenreManager
    {
        LOANBOOKDBEntities dbContext = new LOANBOOKDBEntities();

        public List<Genre> BringAllActiveGenre()
        {
            try
            {
                List<Genre> genre = new List<Genre>();
                genre = dbContext.Genres.Where(x => x.IsPassive == false).ToList();
                return genre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
