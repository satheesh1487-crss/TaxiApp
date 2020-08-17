using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaziappzMobileWebAPI.TaxiModels
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
        public virtual DbSet<TabAdminDetails> TabAdminDetails { get; set; }
        public virtual DbSet<TabAdminDocument> TabAdminDocument { get; set; }
        public virtual DbSet<TabCommonCurrency> TabCommonCurrency { get; set; }
        public virtual DbSet<TabCommonLanguages> TabCommonLanguages { get; set; }
        public virtual DbSet<TabCountries> TabCountries { get; set; }
        public virtual DbSet<TabCountry> TabCountry { get; set; }
        public virtual DbSet<TabCurrencies> TabCurrencies { get; set; }
        public virtual DbSet<TabDriverBonus> TabDriverBonus { get; set; }
        public virtual DbSet<TabDriverCancellation> TabDriverCancellation { get; set; }
        public virtual DbSet<TabDriverComplaint> TabDriverComplaint { get; set; }
        public virtual DbSet<TabDriverDocuments> TabDriverDocuments { get; set; }
        public virtual DbSet<TabDriverFine> TabDriverFine { get; set; }
        public virtual DbSet<TabDriverWallet> TabDriverWallet { get; set; }
        public virtual DbSet<TabDrivers> TabDrivers { get; set; }
        public virtual DbSet<TabFaq> TabFaq { get; set; }
        public virtual DbSet<TabGeneralSettings> TabGeneralSettings { get; set; }
        public virtual DbSet<TabInstallationSettings> TabInstallationSettings { get; set; }
        public virtual DbSet<TabManageDocument> TabManageDocument { get; set; }
        public virtual DbSet<TabManageEmail> TabManageEmail { get; set; }
        public virtual DbSet<TabManageEmailHints> TabManageEmailHints { get; set; }
        public virtual DbSet<TabManageReferral> TabManageReferral { get; set; }
        public virtual DbSet<TabManageSms> TabManageSms { get; set; }
        public virtual DbSet<TabManageSmsHints> TabManageSmsHints { get; set; }
        public virtual DbSet<TabMenu> TabMenu { get; set; }
        public virtual DbSet<TabMenuAccess> TabMenuAccess { get; set; }
        public virtual DbSet<TabMenucode> TabMenucode { get; set; }
        public virtual DbSet<TabOtpUsers> TabOtpUsers { get; set; }
        public virtual DbSet<TabPromo> TabPromo { get; set; }
        public virtual DbSet<TabPushNotification> TabPushNotification { get; set; }
        public virtual DbSet<TabRefreshtoken> TabRefreshtoken { get; set; }
        public virtual DbSet<TabRequest> TabRequest { get; set; }
        public virtual DbSet<TabRequestMeta> TabRequestMeta { get; set; }
        public virtual DbSet<TabRequestPlace> TabRequestPlace { get; set; }
        public virtual DbSet<TabRoles> TabRoles { get; set; }
        public virtual DbSet<TabServicelocation> TabServicelocation { get; set; }
        public virtual DbSet<TabSetpriceZonetype> TabSetpriceZonetype { get; set; }
        public virtual DbSet<TabSettings> TabSettings { get; set; }
        public virtual DbSet<TabSos> TabSos { get; set; }
        public virtual DbSet<TabSurgeprice> TabSurgeprice { get; set; }
        public virtual DbSet<TabTimezone> TabTimezone { get; set; }
        public virtual DbSet<TabTripSettings> TabTripSettings { get; set; }
        public virtual DbSet<TabTypes> TabTypes { get; set; }
        public virtual DbSet<TabUploadfiledetails> TabUploadfiledetails { get; set; }
        public virtual DbSet<TabUser> TabUser { get; set; }
        public virtual DbSet<TabUserCancellation> TabUserCancellation { get; set; }
        public virtual DbSet<TabUserComplaint> TabUserComplaint { get; set; }
        public virtual DbSet<TabWalletSettings> TabWalletSettings { get; set; }
        public virtual DbSet<TabZone> TabZone { get; set; }
        public virtual DbSet<TabZonepolygon> TabZonepolygon { get; set; }
        public virtual DbSet<TabZonetypeRelationship> TabZonetypeRelationship { get; set; }
        public virtual DbSet<TblErrorlog> TblErrorlog { get; set; }

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
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.AreaNameNavigation)
                    .WithMany(p => p.TabAdmin)
                    .HasForeignKey(d => d.AreaName)
                    .HasConstraintName("FK__tab_admin__area___0E391C95");

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

                entity.HasOne(d => d.ZoneAccess1)
                    .WithMany(p => p.TabAdmin)
                    .HasForeignKey(d => d.ZoneAccess)
                    .HasConstraintName("fk_tab_timezone_id");
            });

            modelBuilder.Entity<TabAdminDetails>(entity =>
            {
                entity.HasKey(e => e.Admindtlsid)
                    .HasName("PK__tab_admi__052BF0DC62A41327");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.TabAdminDetails)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK__tab_admin__admin__26CFC035");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TabAdminDetails)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__tab_admin__Count__27C3E46E");
            });

            modelBuilder.Entity<TabAdminDocument>(entity =>
            {
                entity.HasKey(e => e.Admindocumentid)
                    .HasName("PK__tab_Admi__8E005B2F539714CD");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.TabAdminDocument)
                    .HasForeignKey(d => d.Adminid)
                    .HasConstraintName("FK__tab_Admin__admin__2D7CBDC4");
            });

            modelBuilder.Entity<TabCommonCurrency>(entity =>
            {
                entity.HasKey(e => e.Currencyid)
                    .HasName("PK__tab_comm__DAF1B62278E5F2B1");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrencySymbol).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Currencies)
                    .WithMany(p => p.TabCommonCurrency)
                    .HasForeignKey(d => d.Currenciesid)
                    .HasConstraintName("FK__tab_commo__curre__6EC0713C");
            });

            modelBuilder.Entity<TabCommonLanguages>(entity =>
            {
                entity.HasKey(e => e.Languageid)
                    .HasName("PK__tab_Comm__B93751832661A59F");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TabCountries>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("('1')");

                entity.Property(e => e.CountryCode).HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrencyDecimals).HasDefaultValueSql("('0')");

                entity.Property(e => e.Iso31662).HasDefaultValueSql("('')");

                entity.Property(e => e.Iso31663).HasDefaultValueSql("('')");

                entity.Property(e => e.Name).HasDefaultValueSql("('')");

                entity.Property(e => e.RegionCode).HasDefaultValueSql("('')");

                entity.Property(e => e.SubRegionCode).HasDefaultValueSql("('')");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TabCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK__tab_Coun__10D1609FC6C557A1");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Currency).IsUnicode(false);

                entity.Property(e => e.DCode).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<TabCurrencies>(entity =>
            {
                entity.HasKey(e => e.Currenciesid)
                    .HasName("PK__tab_curr__DAF1B622C7683A66");

                entity.Property(e => e.Code).IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Currency).IsUnicode(false);

                entity.Property(e => e.DecimalSeparator).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Symbol).IsUnicode(false);

                entity.Property(e => e.ThousandSeparator).IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TabCurrencies)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("FK__tab_curre__count__0E6E26BF");
            });

            modelBuilder.Entity<TabDriverBonus>(entity =>
            {
                entity.HasKey(e => e.Driverbonusid)
                    .HasName("PK__tab_driv__4F800ADF551E801F");

                entity.Property(e => e.Createdat).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Createdby).IsUnicode(false);

                entity.Property(e => e.Deletedby).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Updatedby).IsUnicode(false);

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.TabDriverBonus)
                    .HasForeignKey(d => d.Driverid)
                    .HasConstraintName("FK__tab_drive__Drive__3BFFE745");
            });

            modelBuilder.Entity<TabDriverCancellation>(entity =>
            {
                entity.HasKey(e => e.DriverCancelId)
                    .HasName("PK__tab_driv__CDFB5C7A795B27A8");

                entity.Property(e => e.Arrivalstatus).IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Paymentstatus).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Zonetype)
                    .WithMany(p => p.TabDriverCancellation)
                    .HasForeignKey(d => d.Zonetypeid)
                    .HasConstraintName("FK__tab_drive__zonet__5006DFF2");
            });

            modelBuilder.Entity<TabDriverComplaint>(entity =>
            {
                entity.HasKey(e => e.DriverComplaintId)
                    .HasName("PK__tab_Driv__79164EE0E63CE269");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TabDriverComplaint)
                    .HasForeignKey(d => d.Zoneid)
                    .HasConstraintName("FK__tab_Drive__zonei__5B78929E");
            });

            modelBuilder.Entity<TabDriverDocuments>(entity =>
            {
                entity.HasKey(e => e.DriverDocId)
                    .HasName("PK__tab_Driv__545AF4F6E49E3966");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.Property(e => e.UploadedFileName).IsUnicode(false);

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.TabDriverDocuments)
                    .HasForeignKey(d => d.Documentid)
                    .HasConstraintName("FK__tab_Drive__Docum__6CA31EA0");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.TabDriverDocuments)
                    .HasForeignKey(d => d.Driverid)
                    .HasConstraintName("FK__tab_Drive__Drive__6BAEFA67");
            });

            modelBuilder.Entity<TabDriverFine>(entity =>
            {
                entity.HasKey(e => e.Driverfineid)
                    .HasName("PK__tab_driv__6012F48AFF9B8C44");

                entity.Property(e => e.Createdat).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Createdby).IsUnicode(false);

                entity.Property(e => e.Deletedby).IsUnicode(false);

                entity.Property(e => e.FinepaidStatus).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Updatedby).IsUnicode(false);

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.TabDriverFine)
                    .HasForeignKey(d => d.Driverid)
                    .HasConstraintName("FK__tab_drive__Drive__3552E9B6");
            });

            modelBuilder.Entity<TabDriverWallet>(entity =>
            {
                entity.HasKey(e => e.Driverwalletid)
                    .HasName("PK__tab_driv__7C05DCF24299CD43");

                entity.Property(e => e.Createdat).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Createdby).IsUnicode(false);

                entity.Property(e => e.Deletedby).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Updatedby).IsUnicode(false);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.TabDriverWallet)
                    .HasForeignKey(d => d.Currencyid)
                    .HasConstraintName("FK__tab_drive__curre__2F9A1060");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.TabDriverWallet)
                    .HasForeignKey(d => d.Driverid)
                    .HasConstraintName("FK__tab_drive__Drive__2EA5EC27");
            });

            modelBuilder.Entity<TabDrivers>(entity =>
            {
                entity.HasKey(e => e.Driverid)
                    .HasName("PK__tab_Driv__F1B2D17C7A0C01B0");

                entity.Property(e => e.Carcolor).IsUnicode(false);

                entity.Property(e => e.Carmanufacturer).IsUnicode(false);

                entity.Property(e => e.Carmodel).IsUnicode(false);

                entity.Property(e => e.Carnumber).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.Company).IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.NationalId).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TabDrivers)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("FK__tab_Drive__count__18B6AB08");

                entity.HasOne(d => d.Serviceloc)
                    .WithMany(p => p.TabDrivers)
                    .HasForeignKey(d => d.Servicelocid)
                    .HasConstraintName("FK__tab_Drive__servi__19AACF41");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TabDrivers)
                    .HasForeignKey(d => d.Typeid)
                    .HasConstraintName("FK__tab_Drive__typei__1A9EF37A");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TabDrivers)
                    .HasForeignKey(d => d.Zoneid)
                    .HasConstraintName("FK__tab_Drive__zonei__473C8FC7");
            });

            modelBuilder.Entity<TabFaq>(entity =>
            {
                entity.HasKey(e => e.Faqid)
                    .HasName("PK__tab_FAQ__4B88DD9AA7117E63");

                entity.Property(e => e.ComplaintType).IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Serviceloc)
                    .WithMany(p => p.TabFaq)
                    .HasForeignKey(d => d.Servicelocid)
                    .HasConstraintName("FK__tab_FAQ__service__3335971A");
            });

            modelBuilder.Entity<TabGeneralSettings>(entity =>
            {
                entity.HasKey(e => e.TripGeneralId)
                    .HasName("PK__tab_Gene__F301C569EBFF3461");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.TripGeneralAnswer).IsUnicode(false);

                entity.Property(e => e.TripGeneralQuestion).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<TabInstallationSettings>(entity =>
            {
                entity.HasKey(e => e.TripInstallationId)
                    .HasName("PK__tab_inst__466056281545B20D");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.TripInstallationAnswer).IsUnicode(false);

                entity.Property(e => e.TripInstallationQuestion).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<TabManageDocument>(entity =>
            {
                entity.HasKey(e => e.DocumentId)
                    .HasName("PK__tab_Mana__1ABEEF6FE4BF9584");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.DocumentName).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<TabManageEmail>(entity =>
            {
                entity.HasKey(e => e.ManageEmailid)
                    .HasName("PK__tab_Mana__57CEAE3506B88066");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Emailtitle).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<TabManageEmailHints>(entity =>
            {
                entity.HasKey(e => e.ManageEmailHint)
                    .HasName("PK__tab_mana__A0650D00E5482C58");

                entity.Property(e => e.HintDescription).IsUnicode(false);

                entity.Property(e => e.HintKeyword).IsUnicode(false);

                entity.HasOne(d => d.ManageEmail)
                    .WithMany(p => p.TabManageEmailHints)
                    .HasForeignKey(d => d.ManageEmailid)
                    .HasConstraintName("FK__tab_manag__Manag__15A53433");
            });

            modelBuilder.Entity<TabManageReferral>(entity =>
            {
                entity.HasKey(e => e.Managereferral)
                    .HasName("PK__tab_Mana__A1BB58E9D6FF145D");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<TabManageSms>(entity =>
            {
                entity.HasKey(e => e.ManageSmsid)
                    .HasName("PK__tab_Mana__FB9C110A6FEBC5FF");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Smstitle).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<TabManageSmsHints>(entity =>
            {
                entity.HasKey(e => e.ManageSmshint)
                    .HasName("PK__tab_mana__D30D8C94EFCE586D");

                entity.Property(e => e.HintDescription).IsUnicode(false);

                entity.Property(e => e.HintKeyword).IsUnicode(false);

                entity.HasOne(d => d.ManageSms)
                    .WithMany(p => p.TabManageSmsHints)
                    .HasForeignKey(d => d.ManageSmsid)
                    .HasConstraintName("FK__tab_manag__Manag__0A338187");
            });

            modelBuilder.Entity<TabMenu>(entity =>
            {
                entity.HasKey(e => e.Menuid)
                    .HasName("PK__menu__3213E83F440BAF20");
            });

            modelBuilder.Entity<TabMenuAccess>(entity =>
            {
                entity.HasKey(e => e.Accessid)
                    .HasName("PK__tab_Menu__4131EC77F9A578F5");

                entity.Property(e => e.Createdby).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Viewstatus).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.TabMenuAccess)
                    .HasForeignKey(d => d.Menuid)
                    .HasConstraintName("FK__tab_MenuA__Menui__12FDD1B2");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TabMenuAccess)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("FK__tab_MenuA__Rolei__13F1F5EB");
            });

            modelBuilder.Entity<TabMenucode>(entity =>
            {
                entity.HasKey(e => e.Menuid)
                    .HasName("PK__tab_menu__3B5F7D5C2E9983C9");

                entity.Property(e => e.Menuname).IsUnicode(false);
            });

            modelBuilder.Entity<TabOtpUsers>(entity =>
            {
                entity.HasKey(e => e.Userotpid)
                    .HasName("PK__tab_OTP___85A65242EDE0E049");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.Property(e => e.UserDeviceIpaddress).IsUnicode(false);

                entity.Property(e => e.UserDeviceName).IsUnicode(false);
            });

            modelBuilder.Entity<TabPromo>(entity =>
            {
                entity.HasKey(e => e.Promoid)
                    .HasName("PK__tab_prom__E19F75CE92EC1FA4");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.PromoType).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TabPromo)
                    .HasForeignKey(d => d.Zoneid)
                    .HasConstraintName("FK__tab_promo__zonei__477199F1");
            });

            modelBuilder.Entity<TabPushNotification>(entity =>
            {
                entity.HasKey(e => e.Pushnotificationid)
                    .HasName("PK__tab_push__2051B54F44533F93");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.HasRedirectUrl).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.UploadFileName).IsUnicode(false);
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

            modelBuilder.Entity<TabRequest>(entity =>
            {
                entity.Property(e => e.CancelMethod).IsUnicode(false);

                entity.Property(e => e.CancelOtherReason).IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Distance).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DriverRated).HasDefaultValueSql("((0))");

                entity.Property(e => e.IfDispatch).HasDefaultValueSql("((0))");

                entity.Property(e => e.InstantTrip)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Normal Trip')");

                entity.Property(e => e.IsCancelled).HasDefaultValueSql("('False')");

                entity.Property(e => e.IsCompleted).HasDefaultValueSql("('False')");

                entity.Property(e => e.IsDriverArrived).HasDefaultValueSql("('False')");

                entity.Property(e => e.IsDriverStarted)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('False')");

                entity.Property(e => e.IsPaid)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('UNPAID')");

                entity.Property(e => e.IsShare).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsTripStart).HasDefaultValueSql("('False')");

                entity.Property(e => e.Isreschedule)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('No')");

                entity.Property(e => e.NoOfSeats).HasDefaultValueSql("((0))");

                entity.Property(e => e.PaymentId).IsUnicode(false);

                entity.Property(e => e.PaymentOpt)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('CASH')");

                entity.Property(e => e.PromoId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Reason).IsUnicode(false);

                entity.Property(e => e.RequestId).IsUnicode(false);

                entity.Property(e => e.RideLaterCustomDriver).HasDefaultValueSql("((0))");

                entity.Property(e => e.Time).HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Timezone).IsUnicode(false);

                entity.Property(e => e.Total).HasDefaultValueSql("((0))");

                entity.Property(e => e.UserRated).HasDefaultValueSql("((0))");

                entity.Property(e => e.WaitingTime).HasDefaultValueSql("((0.00))");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.TabRequest)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK__tab_reque__drive__4DE98D56");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TabRequest)
                    .HasForeignKey(d => d.Typeid)
                    .HasConstraintName("FK__tab_reque__typei__5D2BD0E6");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TabRequest)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__tab_reque__user___4CF5691D");
            });

            modelBuilder.Entity<TabRequestMeta>(entity =>
            {
                entity.HasKey(e => e.MetaId)
                    .HasName("PK__tab_requ__1F8299A026B8D6D6");

                entity.Property(e => e.AssignMethod).IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Notification).IsUnicode(false);

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.TabRequestMeta)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK__tab_reque__drive__04459E07");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.TabRequestMeta)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__tab_reque__Reque__025D5595");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TabRequestMeta)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__tab_reque__user___035179CE");
            });

            modelBuilder.Entity<TabRequestPlace>(entity =>
            {
                entity.HasKey(e => e.RequestPlaceId)
                    .HasName("PK__tab_requ__A8B4FE3AA877DE91");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.DropLocation).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.PickLocation).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.TabRequestPlace)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__tab_reque__Reque__7F80E8EA");
            });

            modelBuilder.Entity<TabRoles>(entity =>
            {
                entity.HasKey(e => e.Roleid)
                    .HasName("PK__tab_role__8AF5CA32CD07C8D1");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<TabServicelocation>(entity =>
            {
                entity.HasKey(e => e.Servicelocid)
                    .HasName("PK__tab_serv__03B9BBF9F2E26C97");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TabServicelocation)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("FK__tab_servi__count__2645B050");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.TabServicelocation)
                    .HasForeignKey(d => d.Currencyid)
                    .HasConstraintName("FK__tab_servi__curre__0D44F85C");

                entity.HasOne(d => d.Timezone)
                    .WithMany(p => p.TabServicelocation)
                    .HasForeignKey(d => d.Timezoneid)
                    .HasConstraintName("FK__tab_servi__timez__282DF8C2");
            });

            modelBuilder.Entity<TabSetpriceZonetype>(entity =>
            {
                entity.HasKey(e => e.Setpriceid)
                    .HasName("PK__tab_setp__527353B2ACC22FA2");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.RideType).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Zonetype)
                    .WithMany(p => p.TabSetpriceZonetype)
                    .HasForeignKey(d => d.Zonetypeid)
                    .HasConstraintName("FK__tab_setpr__zonet__2057CCD0");
            });

            modelBuilder.Entity<TabSettings>(entity =>
            {
                entity.HasKey(e => e.SettingsId)
                    .HasName("PK__tab_sett__DCEDDA8DA108B40F");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.SettingsName).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<TabSos>(entity =>
            {
                entity.HasKey(e => e.Sosid)
                    .HasName("PK__tab_SOS__860933B66F746209");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TabSurgeprice>(entity =>
            {
                entity.HasKey(e => e.SurgepriceId)
                    .HasName("PK__tab_surg__88B7F9CF011E45F5");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.EndTime).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.PeakType).IsUnicode(false);

                entity.Property(e => e.StartTime).IsUnicode(false);

                entity.Property(e => e.SurgepriceType).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TabSurgeprice)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName("FK__tab_surge__zone___3AD6B8E2");
            });

            modelBuilder.Entity<TabTimezone>(entity =>
            {
                entity.HasKey(e => e.Timezoneid)
                    .HasName("PK__tab_time__71C7553D1AB8C0E3");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TabTimezone)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("FK__tab_timez__count__07C12930");
            });

            modelBuilder.Entity<TabTripSettings>(entity =>
            {
                entity.HasKey(e => e.TripSettingsId)
                    .HasName("PK__tab_trip__12935248603A5874");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.TripSettingsAnswer).IsUnicode(false);

                entity.Property(e => e.TripSettingsQuestion).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<TabTypes>(entity =>
            {
                entity.HasKey(e => e.Typeid)
                    .HasName("PK__tab_type__F0528D02D8690A2C");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TabUploadfiledetails>(entity =>
            {
                entity.HasKey(e => e.Fileid)
                    .HasName("PK__tab_uplo__C2C7C24418AF6D34");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Extention).IsUnicode(false);

                entity.Property(e => e.Filename).IsUnicode(false);

                entity.Property(e => e.Mimetype).IsUnicode(false);
            });

            modelBuilder.Entity<TabUser>(entity =>
            {
                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeviceToken).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Lastname).IsUnicode(false);

                entity.Property(e => e.LoginBy).IsUnicode(false);

                entity.Property(e => e.LoginMethod).IsUnicode(false);

                entity.Property(e => e.OtpVerificationCode).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.ProfilePic).IsUnicode(false);

                entity.Property(e => e.SocialUniqueId).IsUnicode(false);

                entity.Property(e => e.State).IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TabUser)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("FK__tab_user__countr__14270015");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.TabUser)
                    .HasForeignKey(d => d.Currencyid)
                    .HasConstraintName("TAB_USERS_COMM_CURRENCY_ID");

                entity.HasOne(d => d.Timezone)
                    .WithMany(p => p.TabUser)
                    .HasForeignKey(d => d.Timezoneid)
                    .HasConstraintName("FK__tab_user__timezo__151B244E");
            });

            modelBuilder.Entity<TabUserCancellation>(entity =>
            {
                entity.HasKey(e => e.UserCancelId)
                    .HasName("PK__tab_User__AAEAADBAE649A4A3");

                entity.Property(e => e.Arrivalstatus).IsUnicode(false);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Paymentstatus).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Zonetype)
                    .WithMany(p => p.TabUserCancellation)
                    .HasForeignKey(d => d.Zonetypeid)
                    .HasConstraintName("FK__tab_User___zonet__55BFB948");
            });

            modelBuilder.Entity<TabUserComplaint>(entity =>
            {
                entity.HasKey(e => e.UserComplaintId)
                    .HasName("PK__tab_User__9B89799F9E855525");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TabUserComplaint)
                    .HasForeignKey(d => d.Zoneid)
                    .HasConstraintName("FK__tab_User___zonei__61316BF4");
            });

            modelBuilder.Entity<TabWalletSettings>(entity =>
            {
                entity.HasKey(e => e.TripWalletId)
                    .HasName("PK__tab_wall__C5BB59366ED0D7A0");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.TripWalletAnswer).IsUnicode(false);

                entity.Property(e => e.TripWalletQuestion).IsUnicode(false);

                entity.Property(e => e.UpdatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<TabZone>(entity =>
            {
                entity.HasKey(e => e.Zoneid)
                    .HasName("PK__tab_zone__2F74DB51C7D6F85A");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Unit).IsUnicode(false);

                entity.HasOne(d => d.Serviceloc)
                    .WithMany(p => p.TabZone)
                    .HasForeignKey(d => d.Servicelocid)
                    .HasConstraintName("FK__tab_zone__servic__59C55456");
            });

            modelBuilder.Entity<TabZonepolygon>(entity =>
            {
                entity.HasKey(e => e.Zonepolygonid)
                    .HasName("PK__tab_zone__05C6EB76CBA1E296");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TabZonepolygon)
                    .HasForeignKey(d => d.Zoneid)
                    .HasConstraintName("FK__tab_zonep__zonei__5F7E2DAC");
            });

            modelBuilder.Entity<TabZonetypeRelationship>(entity =>
            {
                entity.HasKey(e => e.Zonetypeid)
                    .HasName("PK__tab_zone__87431789CD918029");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DeletedBy).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");

                entity.Property(e => e.Paymentmode).IsUnicode(false);

                entity.Property(e => e.Showbill).HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedBy).IsUnicode(false);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TabZonetypeRelationship)
                    .HasForeignKey(d => d.Typeid)
                    .HasConstraintName("FK__tab_zonet__typei__078C1F06");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TabZonetypeRelationship)
                    .HasForeignKey(d => d.Zoneid)
                    .HasConstraintName("FK__tab_zonet__zonei__0697FACD");
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
