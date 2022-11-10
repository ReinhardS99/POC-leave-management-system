using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using POC_Leave_Management.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace POC_Leave_Management.Data
{
    public partial class dbLeave_managementContext : DbContext
    {
        public dbLeave_managementContext()
        {
        }

        public dbLeave_managementContext(DbContextOptions<dbLeave_managementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RequestLeave> RequestLeave { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Password=ShadowStriderFantasy1599!;Persist Security Info=True;User ID=Steynrp_29997313;Initial Catalog=dbLeave_management;Data Source=poc-interview.database.windows.net");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestLeave>(entity =>
            {
                entity.HasKey(e => e.ReqId)
                    .HasName("PK_Request Leave Table");

                entity.ToTable("Request_Leave");

                entity.Property(e => e.ReqId)
                    .HasColumnName("Req_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First Name")
                    .HasMaxLength(25);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last Name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LeaveEnd)
                    .HasColumnName("Leave End")
                    .HasColumnType("date");

                entity.Property(e => e.LeaveStart)
                    .HasColumnName("Leave Start")
                    .HasColumnType("date");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
