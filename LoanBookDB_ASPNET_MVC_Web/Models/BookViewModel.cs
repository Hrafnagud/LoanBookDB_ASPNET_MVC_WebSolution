using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoanBookDB_ASPNET_MVC_Web.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public DateTime DateRegistered { get; set; }

        [Required(ErrorMessage = "Book name is required.")]
        [StringLength(maximumLength:50, ErrorMessage ="Book name must have characters between 1-50. (Both included)")]
        public string BookName { get; set; }
        public byte GenreId { get; set; }
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Total Page amount is required.")]
        public int Pages { get; set; }
        [Required(ErrorMessage = "Stock is required")]
        public int Stock { get; set; }
        public bool IsPassive { get; set; }
        public string ImageLink { get; set; }
        public HttpPostedFileBase Image { get; set; }
    }
}