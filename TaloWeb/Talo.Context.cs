﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaloWeb
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TaloEntities : DbContext
    {
        public TaloEntities()
            : base("name=TaloEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SaunanTila> SaunanTila { get; set; }
        public virtual DbSet<Saunat> Saunat { get; set; }
        public virtual DbSet<TalonTila> TalonTila { get; set; }
        public virtual DbSet<Talot> Talot { get; set; }
        public virtual DbSet<ValonTila> ValonTila { get; set; }
        public virtual DbSet<Valot> Valot { get; set; }
    }
}
