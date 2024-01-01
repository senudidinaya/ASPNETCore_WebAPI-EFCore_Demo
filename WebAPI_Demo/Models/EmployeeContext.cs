﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI_Demo.Models
{
    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext() {}

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options){}

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.First_Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Last_Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .IsRequired()
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}