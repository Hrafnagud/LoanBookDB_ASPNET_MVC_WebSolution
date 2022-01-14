using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LoanBookDB_ASPNET_MVC_Web_BLL.Managers
{
    public class BookManager
    {
        LOANBOOKDBEntities dbContext = new LOANBOOKDBEntities();

        public List<Book> BringAllActiveBooks()
        {
            try
            {
                List<Book> books = new List<Book>();
                books = dbContext.Books.Where(x => !x.IsPassive && x.Stock > 0).OrderByDescending(x=>x.Id).ToList();
                return books;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public bool AddNewBook(Book newBook)
        {
            try
            {
                dbContext.Books.Add(newBook);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
