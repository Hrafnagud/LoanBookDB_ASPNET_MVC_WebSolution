//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoanBookDB_ASPNET_MVC_Web_BLL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Loan
    {
        public int Id { get; set; }
        public System.DateTime DateRegistered { get; set; }
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        public int PersonnelId { get; set; }
        public System.DateTime LoanStarts { get; set; }
        public System.DateTime LoanEnds { get; set; }
        public bool IsReturned { get; set; }
        public Nullable<System.DateTime> DateReturned { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Personnel Personnel { get; set; }
    }
}
