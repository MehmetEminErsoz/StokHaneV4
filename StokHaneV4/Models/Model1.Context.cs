﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StokHaneV4.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB0345Entities1 : DbContext
    {
        public DB0345Entities1()
            : base("name=DB0345Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TabAlsatkul> TabAlsatkul { get; set; }
        public virtual DbSet<TabHane> TabHane { get; set; }
        public virtual DbSet<Tabirsaliye> Tabirsaliye { get; set; }
        public virtual DbSet<Tabisletme> Tabisletme { get; set; }
        public virtual DbSet<TabKullanici> TabKullanici { get; set; }
        public virtual DbSet<TabLogRasyon> TabLogRasyon { get; set; }
        public virtual DbSet<TabmiktarCins> TabmiktarCins { get; set; }
        public virtual DbSet<TabRasyon> TabRasyon { get; set; }
        public virtual DbSet<Tabrasyontarifi> Tabrasyontarifi { get; set; }
        public virtual DbSet<Taburun> Taburun { get; set; }
        public virtual DbSet<TabUrunGenel> TabUrunGenel { get; set; }
        public virtual DbSet<TabYetki> TabYetki { get; set; }
    }
}