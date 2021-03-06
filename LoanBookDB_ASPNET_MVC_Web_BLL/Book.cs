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
    
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.Loans = new HashSet<Loan>();
        }
    
        public int Id { get; set; }
        public System.DateTime DateRegistered { get; set; }
        public string BookName { get; set; }
        public byte GenreId { get; set; }
        public int AuthorId { get; set; }
        public int Pages { get; set; }
        public int Stock { get; set; }
        public bool IsPassive { get; set; }
        public string ImageLink { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loan> Loans { get; set; }
    }
}
