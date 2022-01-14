using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoanBookDB_ASPNET_MVC_Web.Models
{
    public class LoanOperationViewModel
    {
        public int Id { get; set; }
        public DateTime DateRegistered { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public int PersonnelId { get; set; }
        public DateTime LoanStarts { get; set; }
        public DateTime LoanEnds { get; set; }
        public bool IsReturned { get; set; }
        public Nullable<DateTime> DateReturned { get; set; }
    }
}