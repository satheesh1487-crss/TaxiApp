using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SampleEmp.EmpModels
{
    public partial class TaxiAppzDBContext : DbContext
    {
        public TaxiAppzDBContext()
        {
        }

        public TaxiAppzDBContext(DbContextOptions<TaxiAppzDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TabEmployeeDetails> TabEmployeeDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=TaxiAppzDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabEmployeeDetails>(entity =>
            {
                entity.HasKey(e => e.Empid)
                    .HasName("PK__tab_empl__AF4CE865E0763AB0");

                entity.Property(e => e.EmpCreatedby).IsUnicode(false);

                entity.Property(e => e.EmpCreateddate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmpEmailid).IsUnicode(false);

                entity.Property(e => e.EmpFirstname).IsUnicode(false);

                entity.Property(e => e.EmpIsactive).HasDefaultValueSql("((1))");

                entity.Property(e => e.EmpLastname).IsUnicode(false);

                entity.Property(e => e.EmpUpdatedby).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
