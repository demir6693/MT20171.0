﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mobile_Town_V3
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Mobile_TownEntities1 : DbContext
    {
        public Mobile_TownEntities1()
            : base("name=Mobile_TownEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Artikli> Artiklis { get; set; }
        public virtual DbSet<Artikli_knjizeno> Artikli_knjizeno { get; set; }
        public virtual DbSet<Korisnici> Korisnicis { get; set; }
    }
}
