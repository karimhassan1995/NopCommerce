﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Nop.Plugin.Invoice.InvoicSell.Models
{
    public partial class testContext : DbContext
    {
        public testContext()
        {
        }

        public testContext(DbContextOptions<testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<InvoiceSell> InvoiceSell { get; set; }
        public virtual DbSet<InvoiceSellUnit> InvoiceSellUnit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=HP\\KARIM;Initial Catalog=test;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceSell>(entity =>
            {
                entity.HasKey(e => new { e.buildingNo, e.invoiceNo });

                entity.Property(e => e.row_timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<InvoiceSellUnit>(entity =>
            {
                entity.HasKey(e => new { e.invoiceNo, e.buildingNo, e.orderNo });

                entity.Property(e => e.row_timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}