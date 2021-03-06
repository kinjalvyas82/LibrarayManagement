//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LibraryBooks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LibraryBooks()
        {
            this.BookInventory = new HashSet<BookInventory>();
        }
    
        public int BookID { get; set; }
        public string Title { get; set; }
        public string ISBNID { get; set; }
        public string AuthorName { get; set; }
        public int Year { get; set; }
        public string Category { get; set; }
        public string Abstract { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookInventory> BookInventory { get; set; }
    }
}
