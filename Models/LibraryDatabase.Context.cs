﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LibraryDatabaseEntities8 : DbContext
    {
        public LibraryDatabaseEntities8()
            : base("name=LibraryDatabaseEntities8")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BookInventory> BookInventory { get; set; }
        public virtual DbSet<LibraryBooks> LibraryBooks { get; set; }
        public virtual DbSet<CheckOut> CheckOut { get; set; }
        public virtual DbSet<LibraryUsers> LibraryUsers { get; set; }
    }
}