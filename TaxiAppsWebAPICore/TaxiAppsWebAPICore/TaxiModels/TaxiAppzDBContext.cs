using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaxiAppsWebAPICore.TaxiModels
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

        public virtual DbSet<TabAdmin> TabAdmin { get; set; }
        public virtual DbSet<TabCommonLanguages> TabCommonLanguages { get; set; }
        public virtual DbSet<TabCountry> TabCountry { get; set; }
        public virtual DbSet<TabRefreshtoken> TabRefreshtoken { get; set; }
        public virtual DbSet<TabRoles> TabRoles { get; set; }
        public virtual DbSet<TblErrorlog> TblErrorlog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=TaxiAppzDB");
                //optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabAdmin>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.LanguageNavigation)
                    .WithMany(p => p.TabAdmin)
                    .HasForeignKey(d => d.Language)
                    .HasConstraintName("fk_tab_language_id");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.TabAdmin)
                    .HasForeignKey(d => d.Role)
                    .HasConstraintName("fk_tab_role_id");

                entity.HasOne(d => d.ZoneAccessNavigation)
                    .WithMany(p => p.TabAdmin)
                    .HasForeignKey(d => d.ZoneAccess)
                    .HasConstraintName("fk_tab_Country_id");
            });

            modelBuilder.Entity<TabCommonLanguages>(entity =>
            {
                entity.HasKey(e => e.Languageid)
                    .HasName("PK__tab_Comm__B93751832661A59F");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TabCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK__tab_Coun__10D1609FC6C557A1");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Currency).IsUnicode(false);

                entity.Property(e => e.DCode).IsUnicode(false);
            });

            modelBuilder.Entity<TabRefreshtoken>(entity =>
            {
                entity.HasKey(e => e.Reftokenid)
                    .HasName("PK__tab_refr__5D8647FA42EF6F11");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TabRefreshtoken)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_userrefreshtoken");
            });

            modelBuilder.Entity<TabRoles>(entity =>
            {
                entity.HasKey(e => e.Roleid)
                    .HasName("PK__tab_role__8AF5CA32CD07C8D1");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TblErrorlog>(entity =>
            {
                entity.HasKey(e => e.Int)
                    .HasName("PK__tbl_erro__DC50F6D8C9ECC621");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FunctionName).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
