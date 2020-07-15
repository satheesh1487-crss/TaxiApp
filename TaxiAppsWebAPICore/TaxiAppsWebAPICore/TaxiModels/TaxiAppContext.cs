using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaxiAppsWebAPICore.TaxiModels
{
    public partial class TaxiAppContext : DbContext
    {
        public TaxiAppContext()
        {
        }

        public TaxiAppContext(DbContextOptions<TaxiAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TabAdmin> TabAdmin { get; set; }
        public virtual DbSet<TabRefreshtoken> TabRefreshtoken { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=TaxiAppzDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabAdmin>(entity =>
            {
                entity.ToTable("tab_admin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdminKey)
                    .HasColumnName("admin_key")
                    .HasMaxLength(200);

                entity.Property(e => e.AdminReference).HasColumnName("admin_reference");

                entity.Property(e => e.AreaName)
                    .HasColumnName("area_name")
                    .HasMaxLength(150);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(191);

                entity.Property(e => e.EmergencyNumber)
                    .HasColumnName("emergency_number")
                    .HasMaxLength(20);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(200);

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Language)
                    .HasColumnName("language")
                    .HasMaxLength(200);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(200);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(20);

                entity.Property(e => e.ProfilePic)
                    .HasColumnName("profile_pic")
                    .HasMaxLength(100);

                entity.Property(e => e.RegistrationCode)
                    .HasColumnName("registration_code")
                    .HasMaxLength(255);

                entity.Property(e => e.RememberToken)
                    .HasColumnName("remember_token")
                    .HasMaxLength(191);

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ZoneAccess).HasColumnName("zone_access");
            });

            modelBuilder.Entity<TabRefreshtoken>(entity =>
            {
                entity.HasKey(e => e.Reftokenid)
                    .HasName("PK__tab_refr__5D8647FAEB5F7A26");

                entity.ToTable("tab_refreshtoken");

                entity.Property(e => e.Reftokenid).HasColumnName("reftokenid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Refreshtoken)
                    .HasColumnName("refreshtoken")
                    .HasMaxLength(500);

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TabRefreshtoken)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_userrefreshtoken");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
