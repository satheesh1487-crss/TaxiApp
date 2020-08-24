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
        public virtual DbSet<TabAdminDetails> TabAdminDetails { get; set; }
        public virtual DbSet<TabAdminDocument> TabAdminDocument { get; set; }
        public virtual DbSet<TabCancellationFeeForDriver> TabCancellationFeeForDriver { get; set; }
        public virtual DbSet<TabCommonCurrency> TabCommonCurrency { get; set; }
        public virtual DbSet<TabCommonLanguages> TabCommonLanguages { get; set; }
        public virtual DbSet<TabCountries> TabCountries { get; set; }
        public virtual DbSet<TabCountry> TabCountry { get; set; }
        public virtual DbSet<TabCurrencies> TabCurrencies { get; set; }
        public virtual DbSet<TabDocumentApporvalStatus> TabDocumentApporvalStatus { get; set; }
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
                entity.ToTable("tab_admin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdminKey)
                    .HasColumnName("admin_key")
                    .HasMaxLength(200);

                entity.Property(e => e.AdminReference).HasColumnName("admin_reference");

                entity.Property(e => e.AreaName).HasColumnName("area_name");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(191);

                entity.Property(e => e.EmergencyNumber)
                    .HasColumnName("emergency_number")
                    .HasMaxLength(20);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(200);

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.Language).HasColumnName("language");

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
                    .HasMaxLength(2000);

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneAccess).HasColumnName("zone_access");

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

                entity.ToTable("tab_admin_details");

                entity.Property(e => e.Admindtlsid).HasColumnName("admindtlsid");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(300);

                entity.Property(e => e.AdminId).HasColumnName("admin_id");

                entity.Property(e => e.Block).HasColumnName("block");

                entity.Property(e => e.CountryId).HasColumnName("Country_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Document)
                    .HasColumnName("document")
                    .HasMaxLength(200);

                entity.Property(e => e.DocumentName)
                    .HasColumnName("document_name")
                    .HasMaxLength(100);

                entity.Property(e => e.DriverDocumentCount).HasColumnName("driver_document_count");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastLoginIpAddress)
                    .HasColumnName("last_login_ip_address")
                    .HasMaxLength(100);

                entity.Property(e => e.LoginAttempt).HasColumnName("login_attempt");

                entity.Property(e => e.PostalCode).HasColumnName("postalCode");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

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

                entity.ToTable("tab_Admin_Document");

                entity.Property(e => e.Admindocumentid).HasColumnName("admindocumentid");

                entity.Property(e => e.Adminid).HasColumnName("adminid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentName)
                    .IsRequired()
                    .HasColumnName("document_name")
                    .HasMaxLength(300);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.TabAdminDocument)
                    .HasForeignKey(d => d.Adminid)
                    .HasConstraintName("FK__tab_Admin__admin__2D7CBDC4");
            });

            modelBuilder.Entity<TabCancellationFeeForDriver>(entity =>
            {
                entity.HasKey(e => e.CancellationId)
                    .HasName("PK__tab_canc__4ED4366D775E3A76");

                entity.ToTable("tab_cancellation_fee_for_driver");

                entity.Property(e => e.CancellationId).HasColumnName("cancellation_id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.RequestId).HasColumnName("request_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.TabCancellationFeeForDriver)
                    .HasForeignKey(d => d.Driverid)
                    .HasConstraintName("FK__tab_cance__Drive__0FB750B3");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.TabCancellationFeeForDriver)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__tab_cance__reque__10AB74EC");
            });

            modelBuilder.Entity<TabCommonCurrency>(entity =>
            {
                entity.HasKey(e => e.Currencyid)
                    .HasName("PK__tab_comm__DAF1B62278E5F2B1");

                entity.ToTable("tab_common_currency");

                entity.Property(e => e.Currencyid).HasColumnName("currencyid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(100);

                entity.Property(e => e.Currenciesid).HasColumnName("currenciesid");

                entity.Property(e => e.CurrencySymbol)
                    .IsRequired()
                    .HasColumnName("currency_symbol")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Currencyname)
                    .IsRequired()
                    .HasColumnName("currencyname")
                    .HasMaxLength(200);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("Deleted_by")
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_by")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Currencies)
                    .WithMany(p => p.TabCommonCurrency)
                    .HasForeignKey(d => d.Currenciesid)
                    .HasConstraintName("FK__tab_commo__curre__6EC0713C");
            });

            modelBuilder.Entity<TabCommonLanguages>(entity =>
            {
                entity.HasKey(e => e.Languageid)
                    .HasName("PK__tab_Comm__B93751832661A59F");

                entity.ToTable("tab_Common_Languages");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_At")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_By")
                    .HasMaxLength(100);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.ShortLang)
                    .HasColumnName("Short_Lang")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_At")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TabCountries>(entity =>
            {
                entity.ToTable("tab_countries");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.CallingCode)
                    .HasColumnName("calling_code")
                    .HasMaxLength(3);

                entity.Property(e => e.Capital)
                    .HasColumnName("capital")
                    .HasMaxLength(255);

                entity.Property(e => e.Citizenship)
                    .HasColumnName("citizenship")
                    .HasMaxLength(255);

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasColumnName("country_code")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasMaxLength(255);

                entity.Property(e => e.CurrencyCode)
                    .HasColumnName("currency_code")
                    .HasMaxLength(255);

                entity.Property(e => e.CurrencyDecimals)
                    .HasColumnName("currency_decimals")
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CurrencySubUnit)
                    .HasColumnName("currency_sub_unit")
                    .HasMaxLength(255);

                entity.Property(e => e.CurrencySymbol)
                    .HasColumnName("currency_symbol")
                    .HasMaxLength(3);

                entity.Property(e => e.Eea).HasColumnName("eea");

                entity.Property(e => e.Flag)
                    .HasColumnName("flag")
                    .HasMaxLength(191);

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Iso31662)
                    .IsRequired()
                    .HasColumnName("iso_3166_2")
                    .HasMaxLength(2)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Iso31663)
                    .IsRequired()
                    .HasColumnName("iso_3166_3")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.RegionCode)
                    .IsRequired()
                    .HasColumnName("region_code")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.SubRegionCode)
                    .IsRequired()
                    .HasColumnName("sub_region_code")
                    .HasMaxLength(3)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TabCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId)
                    .HasName("PK__tab_Coun__10D1609FC6C557A1");

                entity.ToTable("tab_Country");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_At")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_By")
                    .HasMaxLength(100);

                entity.Property(e => e.Currency)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DCode)
                    .HasColumnName("d_code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabCurrencies>(entity =>
            {
                entity.HasKey(e => e.Currenciesid)
                    .HasName("PK__tab_curr__DAF1B622C7683A66");

                entity.ToTable("tab_currencies");

                entity.Property(e => e.Currenciesid).HasColumnName("currenciesid");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_By")
                    .HasMaxLength(200);

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DecimalSeparator)
                    .HasColumnName("decimal_separator")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(200);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Symbol)
                    .HasColumnName("symbol")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ThousandSeparator)
                    .HasColumnName("thousand_separator")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TabCurrencies)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("FK__tab_curre__count__0E6E26BF");
            });

            modelBuilder.Entity<TabDocumentApporvalStatus>(entity =>
            {
                entity.HasKey(e => e.DocApprovalId)
                    .HasName("PK__tab_Docu__5F18C0180CB3A61D");

                entity.ToTable("tab_Document_ApporvalStatus");

                entity.Property(e => e.DocApprovalId).HasColumnName("Doc_ApprovalID");

                entity.Property(e => e.DocStatus)
                    .HasColumnName("Doc_Status")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TabDriverBonus>(entity =>
            {
                entity.HasKey(e => e.Driverbonusid)
                    .HasName("PK__tab_driv__4F800ADF551E801F");

                entity.ToTable("tab_driver_bonus");

                entity.Property(e => e.Driverbonusid).HasColumnName("driverbonusid");

                entity.Property(e => e.BonusReason)
                    .HasColumnName("bonus_reason")
                    .HasMaxLength(600);

                entity.Property(e => e.Bonusamount).HasColumnName("bonusamount");

                entity.Property(e => e.Createdat)
                    .HasColumnName("createdat")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Deletedat)
                    .HasColumnName("deletedat")
                    .HasColumnType("datetime");

                entity.Property(e => e.Deletedby)
                    .HasColumnName("deletedby")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Updatedat)
                    .HasColumnName("updatedat")
                    .HasColumnType("datetime");

                entity.Property(e => e.Updatedby)
                    .HasColumnName("updatedby")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.TabDriverBonus)
                    .HasForeignKey(d => d.Driverid)
                    .HasConstraintName("FK__tab_drive__Drive__3BFFE745");
            });

            modelBuilder.Entity<TabDriverCancellation>(entity =>
            {
                entity.HasKey(e => e.DriverCancelId)
                    .HasName("PK__tab_driv__CDFB5C7A795B27A8");

                entity.ToTable("tab_driver_cancellation");

                entity.Property(e => e.DriverCancelId).HasColumnName("Driver_CancelId");

                entity.Property(e => e.Arrivalstatus)
                    .HasColumnName("arrivalstatus")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CancellationReasonArabic)
                    .HasColumnName("Cancellation_Reason_Arabic")
                    .HasMaxLength(400);

                entity.Property(e => e.CancellationReasonEnglish)
                    .HasColumnName("Cancellation_Reason_English")
                    .HasMaxLength(400);

                entity.Property(e => e.CancellationReasonSpanish)
                    .HasColumnName("Cancellation_Reason_Spanish")
                    .HasMaxLength(400);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("Deleted_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Paymentstatus)
                    .HasColumnName("paymentstatus")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Zonetypeid).HasColumnName("zonetypeid");

                entity.HasOne(d => d.Zonetype)
                    .WithMany(p => p.TabDriverCancellation)
                    .HasForeignKey(d => d.Zonetypeid)
                    .HasConstraintName("FK__tab_drive__zonet__5006DFF2");
            });

            modelBuilder.Entity<TabDriverComplaint>(entity =>
            {
                entity.HasKey(e => e.DriverComplaintId)
                    .HasName("PK__tab_Driv__79164EE0E63CE269");

                entity.ToTable("tab_Driver_Complaint");

                entity.Property(e => e.DriverComplaintId).HasColumnName("Driver_ComplaintID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("Deleted_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DriverComplaintTitle)
                    .HasColumnName("DriverComplaint_title")
                    .HasMaxLength(400);

                entity.Property(e => e.DriverComplaintType)
                    .HasColumnName("DriverComplaint_type")
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Zoneid).HasColumnName("zoneid");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TabDriverComplaint)
                    .HasForeignKey(d => d.Zoneid)
                    .HasConstraintName("FK__tab_Drive__zonei__5B78929E");
            });

            modelBuilder.Entity<TabDriverDocuments>(entity =>
            {
                entity.HasKey(e => e.DriverDocId)
                    .HasName("PK__tab_Driv__545AF4F6E49E3966");

                entity.ToTable("tab_Driver_Documents");

                entity.Property(e => e.DriverDocId).HasColumnName("DriverDoc_id");

                entity.Property(e => e.Comments)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("Deleted_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DocApprovalId).HasColumnName("Doc_ApprovalID");

                entity.Property(e => e.DocumentIdNumber)
                    .HasColumnName("DocumentID_Number")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UploadedFileName)
                    .HasColumnName("Uploaded_FileName")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.DocApproval)
                    .WithMany(p => p.TabDriverDocuments)
                    .HasForeignKey(d => d.DocApprovalId)
                    .HasConstraintName("FK__tab_Drive__Doc_A__0BE6BFCF");

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

                entity.ToTable("tab_driver_fine");

                entity.Property(e => e.Driverfineid).HasColumnName("driverfineid");

                entity.Property(e => e.Createdat)
                    .HasColumnName("createdat")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Deletedat)
                    .HasColumnName("deletedat")
                    .HasColumnType("datetime");

                entity.Property(e => e.Deletedby)
                    .HasColumnName("deletedby")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.FineReason)
                    .HasColumnName("fine_reason")
                    .HasMaxLength(600);

                entity.Property(e => e.Fineamount).HasColumnName("fineamount");

                entity.Property(e => e.FinepaidStatus)
                    .HasColumnName("finepaid_status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Updatedat)
                    .HasColumnName("updatedat")
                    .HasColumnType("datetime");

                entity.Property(e => e.Updatedby)
                    .HasColumnName("updatedby")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.TabDriverFine)
                    .HasForeignKey(d => d.Driverid)
                    .HasConstraintName("FK__tab_drive__Drive__3552E9B6");
            });

            modelBuilder.Entity<TabDriverWallet>(entity =>
            {
                entity.HasKey(e => e.Driverwalletid)
                    .HasName("PK__tab_driv__7C05DCF24299CD43");

                entity.ToTable("tab_driver_wallet");

                entity.Property(e => e.Driverwalletid).HasColumnName("driverwalletid");

                entity.Property(e => e.Createdat)
                    .HasColumnName("createdat")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Currencyid).HasColumnName("currencyid");

                entity.Property(e => e.Deletedat)
                    .HasColumnName("deletedat")
                    .HasColumnType("datetime");

                entity.Property(e => e.Deletedby)
                    .HasColumnName("deletedby")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Updatedat)
                    .HasColumnName("updatedat")
                    .HasColumnType("datetime");

                entity.Property(e => e.Updatedby)
                    .HasColumnName("updatedby")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Walletamount).HasColumnName("walletamount");

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

                entity.ToTable("tab_Drivers");

                entity.Property(e => e.Address).HasMaxLength(1000);

                entity.Property(e => e.Carcolor)
                    .HasColumnName("carcolor")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Carmanufacturer)
                    .HasColumnName("carmanufacturer")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Carmodel)
                    .HasColumnName("carmodel")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Carnumber)
                    .HasColumnName("carnumber")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Caryear).HasColumnName("caryear");

                entity.Property(e => e.City)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo).HasMaxLength(15);

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DeviceToken)
                    .HasColumnName("device_token")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Driverregno).HasMaxLength(500);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsApproved)
                    .HasColumnName("isApproved")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsAvailable)
                    .HasColumnName("isAvailable")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LoginBy)
                    .HasColumnName("login_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LoginMethod)
                    .HasColumnName("login_method")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NationalId)
                    .HasColumnName("NationalID")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OnlineStatus)
                    .HasColumnName("Online_Status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RewardPoint).HasColumnName("Reward_point");

                entity.Property(e => e.Servicelocid).HasColumnName("servicelocid");

                entity.Property(e => e.State)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TokenExpiry)
                    .HasColumnName("token_expiry")
                    .HasColumnType("datetime");

                entity.Property(e => e.Typeid).HasColumnName("typeid");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Zoneid).HasColumnName("zoneid");

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

                entity.ToTable("tab_FAQ");

                entity.Property(e => e.Faqid).HasColumnName("FAQid");

                entity.Property(e => e.ComplaintType)
                    .HasColumnName("Complaint_Type")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("Deleted_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.FaqAnswer)
                    .IsRequired()
                    .HasColumnName("FAQ_Answer")
                    .HasMaxLength(1000);

                entity.Property(e => e.FaqQuestion)
                    .IsRequired()
                    .HasColumnName("FAQ_Question")
                    .HasMaxLength(600);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Servicelocid).HasColumnName("servicelocid");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.Serviceloc)
                    .WithMany(p => p.TabFaq)
                    .HasForeignKey(d => d.Servicelocid)
                    .HasConstraintName("FK__tab_FAQ__service__3335971A");
            });

            modelBuilder.Entity<TabGeneralSettings>(entity =>
            {
                entity.HasKey(e => e.TripGeneralId)
                    .HasName("PK__tab_Gene__F301C569EBFF3461");

                entity.ToTable("tab_General_settings");

                entity.Property(e => e.TripGeneralId).HasColumnName("trip_General_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TripGeneralAnswer)
                    .HasColumnName("trip_General_answer")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TripGeneralQuestion)
                    .IsRequired()
                    .HasColumnName("trip_General_question")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabInstallationSettings>(entity =>
            {
                entity.HasKey(e => e.TripInstallationId)
                    .HasName("PK__tab_inst__466056281545B20D");

                entity.ToTable("tab_installation_settings");

                entity.Property(e => e.TripInstallationId).HasColumnName("trip_installation_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TripInstallationAnswer)
                    .HasColumnName("trip_Installation_answer")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TripInstallationQuestion)
                    .IsRequired()
                    .HasColumnName("trip_installation_question")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabManageDocument>(entity =>
            {
                entity.HasKey(e => e.DocumentId)
                    .HasName("PK__tab_Mana__1ABEEF6FE4BF9584");

                entity.ToTable("tab_ManageDocument");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("Deleted_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentName)
                    .HasColumnName("Document_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabManageEmail>(entity =>
            {
                entity.HasKey(e => e.ManageEmailid)
                    .HasName("PK__tab_Mana__57CEAE3506B88066");

                entity.ToTable("tab_Manage_Email");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(600);

                entity.Property(e => e.Emailtitle)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_By")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabManageEmailHints>(entity =>
            {
                entity.HasKey(e => e.ManageEmailHint)
                    .HasName("PK__tab_mana__A0650D00E5482C58");

                entity.ToTable("tab_manage_Email_Hints");

                entity.Property(e => e.HintDescription)
                    .HasColumnName("Hint_Description")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.HintKeyword)
                    .HasColumnName("Hint_Keyword")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.ManageEmail)
                    .WithMany(p => p.TabManageEmailHints)
                    .HasForeignKey(d => d.ManageEmailid)
                    .HasConstraintName("FK__tab_manag__Manag__15A53433");
            });

            modelBuilder.Entity<TabManageReferral>(entity =>
            {
                entity.HasKey(e => e.Managereferral)
                    .HasName("PK__tab_Mana__A1BB58E9D6FF145D");

                entity.ToTable("tab_Manage_Referral");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ReferralGainAmountPerPerson)
                    .HasColumnName("ReferralGain_Amount_PerPerson")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.ReferralWorthAmount)
                    .HasColumnName("ReferralWorth_Amount")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.TripToCompletedToearnRefferalAmount)
                    .HasColumnName("Trip_to_completed_toearn_refferalAmount")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.TripToCompletedTorefer).HasColumnName("Trip_to_completed_torefer");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabManageSms>(entity =>
            {
                entity.HasKey(e => e.ManageSmsid)
                    .HasName("PK__tab_Mana__FB9C110A6FEBC5FF");

                entity.ToTable("tab_Manage_SMS");

                entity.Property(e => e.ManageSmsid).HasColumnName("ManageSMSid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(600);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Smstitle)
                    .IsRequired()
                    .HasColumnName("SMStitle")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_By")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabManageSmsHints>(entity =>
            {
                entity.HasKey(e => e.ManageSmshint)
                    .HasName("PK__tab_mana__D30D8C94EFCE586D");

                entity.ToTable("tab_manage_SMS_Hints");

                entity.Property(e => e.ManageSmshint).HasColumnName("ManageSMSHint");

                entity.Property(e => e.HintDescription)
                    .HasColumnName("Hint_Description")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.HintKeyword)
                    .HasColumnName("Hint_Keyword")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ManageSmsid).HasColumnName("ManageSMSid");

                entity.HasOne(d => d.ManageSms)
                    .WithMany(p => p.TabManageSmsHints)
                    .HasForeignKey(d => d.ManageSmsid)
                    .HasConstraintName("FK__tab_manag__Manag__0A338187");
            });

            modelBuilder.Entity<TabMenu>(entity =>
            {
                entity.HasKey(e => e.Menuid)
                    .HasName("PK__menu__3213E83F440BAF20");

                entity.ToTable("tab_menu");

                entity.Property(e => e.Menukey)
                    .HasColumnName("menukey")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ParentId).HasColumnName("parentID");
            });

            modelBuilder.Entity<TabMenuAccess>(entity =>
            {
                entity.HasKey(e => e.Accessid)
                    .HasName("PK__tab_Menu__4131EC77F9A578F5");

                entity.ToTable("tab_MenuAccess");

                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Updatedby)
                    .HasColumnName("updatedby")
                    .HasColumnType("datetime");

                entity.Property(e => e.Viewstatus)
                    .HasColumnName("viewstatus")
                    .HasDefaultValueSql("((0))");

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

                entity.ToTable("tab_menucode");

                entity.Property(e => e.Menuid).HasColumnName("menuid");

                entity.Property(e => e.Menuname)
                    .IsRequired()
                    .HasColumnName("menuname")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabOtpUsers>(entity =>
            {
                entity.HasKey(e => e.Userotpid)
                    .HasName("PK__tab_OTP___85A65242EDE0E049");

                entity.ToTable("tab_OTP_users");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserContactNo).HasColumnName("User_Contact_no");

                entity.Property(e => e.UserDeviceIpaddress)
                    .HasColumnName("User_Device_IPAddress")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserDeviceName)
                    .HasColumnName("User_Device_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserOtp).HasColumnName("User_OTP");

                entity.Property(e => e.UserOtpCreatedDate)
                    .HasColumnName("User_OTP_CreatedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserOtpExpireDate)
                    .HasColumnName("User_OTP_ExpireDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TabPromo>(entity =>
            {
                entity.HasKey(e => e.Promoid)
                    .HasName("PK__tab_prom__E19F75CE92EC1FA4");

                entity.ToTable("tab_promo");

                entity.Property(e => e.Promoid).HasColumnName("promoid");

                entity.Property(e => e.CouponCode)
                    .IsRequired()
                    .HasColumnName("Coupon_code")
                    .HasMaxLength(300);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PromoEstimateAmount).HasColumnName("promo_estimate_amount");

                entity.Property(e => e.PromoType)
                    .HasColumnName("promo_type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PromoUsersRepeateduse).HasColumnName("promo_users_repeateduse");

                entity.Property(e => e.PromoUses).HasColumnName("promo_uses");

                entity.Property(e => e.PromoValue).HasColumnName("promo_value");

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Zoneid).HasColumnName("zoneid");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TabPromo)
                    .HasForeignKey(d => d.Zoneid)
                    .HasConstraintName("FK__tab_promo__zonei__477199F1");
            });

            modelBuilder.Entity<TabPushNotification>(entity =>
            {
                entity.HasKey(e => e.Pushnotificationid)
                    .HasName("PK__tab_push__2051B54F44533F93");

                entity.ToTable("tab_push_notification");

                entity.Property(e => e.Pushnotificationid).HasColumnName("pushnotificationid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("Deleted_By")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.HasRedirectUrl)
                    .HasColumnName("HasRedirectURL")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MessageDescription).HasMaxLength(600);

                entity.Property(e => e.Messagesubtitle)
                    .IsRequired()
                    .HasColumnName("messagesubtitle")
                    .HasMaxLength(200);

                entity.Property(e => e.Messagetitle)
                    .IsRequired()
                    .HasColumnName("messagetitle")
                    .HasMaxLength(200);

                entity.Property(e => e.UploadFileName)
                    .HasColumnName("Upload_FileName")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabRefreshtoken>(entity =>
            {
                entity.HasKey(e => e.Reftokenid)
                    .HasName("PK__tab_refr__5D8647FA42EF6F11");

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

            modelBuilder.Entity<TabRequest>(entity =>
            {
                entity.ToTable("tab_request");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CancelDialogBoxAfterWaitingTime).HasColumnName("cancel_dialog_box_after_waiting_time");

                entity.Property(e => e.CancelDialogBoxClickedTime)
                    .HasColumnName("cancel_dialog_box_clicked_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.CancelMethod)
                    .HasColumnName("cancel_method")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CancelOtherReason)
                    .HasColumnName("cancel_other_reason")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CardId).HasColumnName("card_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DispatchReference)
                    .HasColumnName("dispatch_reference")
                    .HasMaxLength(400);

                entity.Property(e => e.Distance)
                    .HasColumnName("distance")
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.DriverAcceptedTime)
                    .HasColumnName("driver_accepted_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DriverId).HasColumnName("driver_id");

                entity.Property(e => e.DriverRated)
                    .HasColumnName("driver_rated")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FixedPlaceId).HasColumnName("fixed_place_id");

                entity.Property(e => e.FreeWaitingTime).HasColumnName("free_waiting_time");

                entity.Property(e => e.IfDispatch)
                    .HasColumnName("if_dispatch")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InstantTrip)
                    .HasColumnName("instant_trip")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Normal Trip')");

                entity.Property(e => e.IsCancelled)
                    .HasColumnName("is_cancelled")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsCompleted)
                    .HasColumnName("is_completed")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsDriverArrived)
                    .HasColumnName("is_driver_arrived")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsDriverStarted)
                    .HasColumnName("is_driver_started")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('False')");

                entity.Property(e => e.IsPaid)
                    .HasColumnName("is_paid")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('UNPAID')");

                entity.Property(e => e.IsShare)
                    .HasColumnName("is_share")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsTripStart)
                    .HasColumnName("is_trip_start")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Isreschedule)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('No')");

                entity.Property(e => e.Later).HasColumnName("later");

                entity.Property(e => e.NoOfSeats)
                    .HasColumnName("no_of_seats")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("payment_id")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentOpt)
                    .HasColumnName("payment_opt")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('CASH')");

                entity.Property(e => e.PromoId)
                    .HasColumnName("promo_id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Reason)
                    .HasColumnName("reason")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RequestId)
                    .HasColumnName("Request_id")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.RequestOtp).HasColumnName("request_otp");

                entity.Property(e => e.RideLaterCustomAcceptedDriverId).HasColumnName("ride_later_custom_accepted_driver_id");

                entity.Property(e => e.RideLaterCustomDriver)
                    .HasColumnName("ride_later_custom_driver")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ScheduleAtTime)
                    .HasColumnName("schedule_at_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShowCancelButtonToDriverAtTime)
                    .HasColumnName("show_cancel_button_to_driver_at_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.SubscribedDriverAcceptRequest).HasColumnName("subscribed_driver_accept_request");

                entity.Property(e => e.Time)
                    .HasColumnName("time")
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.Timezone)
                    .HasColumnName("timezone")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TripEndTime)
                    .HasColumnName("trip_end_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.TripStartTime)
                    .HasColumnName("trip_start_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Typeid).HasColumnName("typeid");

                entity.Property(e => e.Unit).HasColumnName("unit");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserRated)
                    .HasColumnName("user_rated")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.WaitingTime)
                    .HasColumnName("waiting_time")
                    .HasColumnType("decimal(10, 2)")
                    .HasDefaultValueSql("((0.00))");

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

                entity.ToTable("tab_request_meta");

                entity.Property(e => e.MetaId).HasColumnName("meta_id");

                entity.Property(e => e.AssignMethod)
                    .HasColumnName("assign_method")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DriverId).HasColumnName("driver_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Notification)
                    .HasColumnName("notification")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RequestId).HasColumnName("Request_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");

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

                entity.ToTable("tab_request_place");

                entity.Property(e => e.RequestPlaceId).HasColumnName("request_place_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.DropLatitude)
                    .HasColumnName("drop_latitude")
                    .HasColumnType("decimal(8, 6)");

                entity.Property(e => e.DropLocation)
                    .HasColumnName("drop_location")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DropLongitude)
                    .HasColumnName("drop_longitude")
                    .HasColumnType("decimal(9, 6)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PickLatitude)
                    .HasColumnName("pick_latitude")
                    .HasColumnType("decimal(8, 6)");

                entity.Property(e => e.PickLocation)
                    .HasColumnName("pick_location")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.PickLongitude)
                    .HasColumnName("pick_longitude")
                    .HasColumnType("decimal(9, 6)");

                entity.Property(e => e.RequestId).HasColumnName("Request_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.TabRequestPlace)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__tab_reque__Reque__7F80E8EA");
            });

            modelBuilder.Entity<TabRoles>(entity =>
            {
                entity.HasKey(e => e.Roleid)
                    .HasName("PK__tab_role__8AF5CA32CD07C8D1");

                entity.ToTable("tab_roles");

                entity.Property(e => e.AllRights).HasColumnName("ALL_Rights");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_At")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_By")
                    .HasMaxLength(100);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.DisplayName)
                    .HasColumnName("Display_Name")
                    .HasMaxLength(30);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.RoleName).HasMaxLength(30);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_At")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabServicelocation>(entity =>
            {
                entity.HasKey(e => e.Servicelocid)
                    .HasName("PK__tab_serv__03B9BBF9F2E26C97");

                entity.ToTable("tab_servicelocation");

                entity.Property(e => e.Servicelocid).HasColumnName("servicelocid");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(100);

                entity.Property(e => e.Currencyid).HasColumnName("currencyid");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("Deleted_by")
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(300);

                entity.Property(e => e.Timezoneid).HasColumnName("timezoneid");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_by")
                    .HasMaxLength(100);

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

                entity.ToTable("tab_setprice_zonetype");

                entity.Property(e => e.Setpriceid).HasColumnName("setpriceid");

                entity.Property(e => e.Admincommission)
                    .HasColumnName("admincommission")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Admincommtype)
                    .HasColumnName("admincommtype")
                    .HasMaxLength(100);

                entity.Property(e => e.Basedistance).HasColumnName("basedistance");

                entity.Property(e => e.Baseprice).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Cancellationfee)
                    .HasColumnName("cancellationfee")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Customseldrifee)
                    .HasColumnName("customseldrifee")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Driversavingper).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Dropfee)
                    .HasColumnName("dropfee")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Freewaitingtime).HasColumnName("freewaitingtime");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Priceperdistance)
                    .HasColumnName("priceperdistance")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Pricepertime)
                    .HasColumnName("pricepertime")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.RideType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Waitingcharges)
                    .HasColumnName("waitingcharges")
                    .HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Zonetypeid).HasColumnName("zonetypeid");

                entity.HasOne(d => d.Zonetype)
                    .WithMany(p => p.TabSetpriceZonetype)
                    .HasForeignKey(d => d.Zonetypeid)
                    .HasConstraintName("FK__tab_setpr__zonet__2057CCD0");
            });

            modelBuilder.Entity<TabSettings>(entity =>
            {
                entity.HasKey(e => e.SettingsId)
                    .HasName("PK__tab_sett__DCEDDA8DA108B40F");

                entity.ToTable("tab_settings");

                entity.Property(e => e.SettingsId).HasColumnName("settings_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SettingsName)
                    .IsRequired()
                    .HasColumnName("settings_name")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabSos>(entity =>
            {
                entity.HasKey(e => e.Sosid)
                    .HasName("PK__tab_SOS__860933B66F746209");

                entity.ToTable("tab_SOS");

                entity.Property(e => e.Sosid).HasColumnName("SOSid");

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasColumnName("contact_number")
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(100);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("Deleted_by")
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Sosname)
                    .IsRequired()
                    .HasColumnName("SOSName")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_by")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TabSurgeprice>(entity =>
            {
                entity.HasKey(e => e.SurgepriceId)
                    .HasName("PK__tab_surg__88B7F9CF011E45F5");

                entity.ToTable("tab_surgeprice");

                entity.Property(e => e.SurgepriceId).HasColumnName("surgeprice_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PeakType)
                    .HasColumnName("peak_type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SurgepriceType)
                    .HasColumnName("surgeprice_type")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SurgepriceValue).HasColumnName("surgeprice_value");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneId).HasColumnName("zone_id");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TabSurgeprice)
                    .HasForeignKey(d => d.ZoneId)
                    .HasConstraintName("FK__tab_surge__zone___3AD6B8E2");
            });

            modelBuilder.Entity<TabTimezone>(entity =>
            {
                entity.HasKey(e => e.Timezoneid)
                    .HasName("PK__tab_time__71C7553D1AB8C0E3");

                entity.ToTable("tab_timezone");

                entity.Property(e => e.Timezoneid).HasColumnName("timezoneid");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_By")
                    .HasMaxLength(200);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(200);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(200);

                entity.Property(e => e.Zonedescription)
                    .HasColumnName("zonedescription")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TabTimezone)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("FK__tab_timez__count__07C12930");
            });

            modelBuilder.Entity<TabTripSettings>(entity =>
            {
                entity.HasKey(e => e.TripSettingsId)
                    .HasName("PK__tab_trip__12935248603A5874");

                entity.ToTable("tab_trip_settings");

                entity.Property(e => e.TripSettingsId).HasColumnName("trip_settings_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TripSettingsAnswer)
                    .HasColumnName("trip_settings_answer")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TripSettingsQuestion)
                    .IsRequired()
                    .HasColumnName("trip_settings_question")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabTypes>(entity =>
            {
                entity.HasKey(e => e.Typeid)
                    .HasName("PK__tab_type__F0528D02D8690A2C");

                entity.ToTable("tab_types");

                entity.Property(e => e.Typeid).HasColumnName("typeid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(100);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("Deleted_by")
                    .HasMaxLength(100);

                entity.Property(e => e.Imagename)
                    .IsRequired()
                    .HasColumnName("imagename")
                    .HasMaxLength(150);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Typename)
                    .IsRequired()
                    .HasColumnName("typename")
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_by")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TabUploadfiledetails>(entity =>
            {
                entity.HasKey(e => e.Fileid)
                    .HasName("PK__tab_uplo__C2C7C24418AF6D34");

                entity.ToTable("tab_uploadfiledetails");

                entity.Property(e => e.Fileid).HasColumnName("fileid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_By")
                    .HasMaxLength(200);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("Deleted_By")
                    .HasMaxLength(200);

                entity.Property(e => e.Extention)
                    .IsRequired()
                    .HasColumnName("extention")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnName("filename")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Mimetype)
                    .IsRequired()
                    .HasColumnName("mimetype")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_By")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<TabUser>(entity =>
            {
                entity.ToTable("tab_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(500);

                entity.Property(e => e.CancellationContinuousSkip).HasColumnName("cancellation_continuous_skip");

                entity.Property(e => e.CancellationContinuousSkipNotified).HasColumnName("cancellation_continuous_skip_notified");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ContinuousCancellationBlock).HasColumnName("continuous_cancellation_block");

                entity.Property(e => e.CorporateAdminId).HasColumnName("corporate_admin_id");

                entity.Property(e => e.CorporateAdminReference).HasColumnName("corporate_admin_reference");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_By")
                    .HasMaxLength(200);

                entity.Property(e => e.Currencyid).HasColumnName("currencyid");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(200);

                entity.Property(e => e.DeviceToken)
                    .HasColumnName("device_token")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(250);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IfCorporateUser).HasColumnName("if_corporate_user");

                entity.Property(e => e.IfDispatch).HasColumnName("if_dispatch");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsIosProduction).HasColumnName("is_ios_production");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.LoginBy)
                    .HasColumnName("login_by")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.LoginMethod)
                    .HasColumnName("login_method")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.OtpVerificationCode)
                    .HasColumnName("otp_verification_code")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.OtpVerificationValidationTime)
                    .HasColumnName("otp_verification_validation_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.ProfilePic)
                    .HasColumnName("profile_pic")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.SocialUniqueId)
                    .HasColumnName("social_unique_id")
                    .HasMaxLength(191)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Timezoneid).HasColumnName("timezoneid");

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasMaxLength(500);

                entity.Property(e => e.TokenExpiry)
                    .HasColumnName("token_expiry")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(200);

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

                entity.ToTable("tab_User_cancellation");

                entity.Property(e => e.UserCancelId).HasColumnName("User_CancelId");

                entity.Property(e => e.Arrivalstatus)
                    .HasColumnName("arrivalstatus")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CancellationReasonArabic)
                    .HasColumnName("Cancellation_Reason_Arabic")
                    .HasMaxLength(400);

                entity.Property(e => e.CancellationReasonEnglish)
                    .HasColumnName("Cancellation_Reason_English")
                    .HasMaxLength(400);

                entity.Property(e => e.CancellationReasonSpanish)
                    .HasColumnName("Cancellation_Reason_Spanish")
                    .HasMaxLength(400);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("Deleted_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Paymentstatus)
                    .HasColumnName("paymentstatus")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Zonetypeid).HasColumnName("zonetypeid");

                entity.HasOne(d => d.Zonetype)
                    .WithMany(p => p.TabUserCancellation)
                    .HasForeignKey(d => d.Zonetypeid)
                    .HasConstraintName("FK__tab_User___zonet__55BFB948");
            });

            modelBuilder.Entity<TabUserComplaint>(entity =>
            {
                entity.HasKey(e => e.UserComplaintId)
                    .HasName("PK__tab_User__9B89799F9E855525");

                entity.ToTable("tab_User_Complaint");

                entity.Property(e => e.UserComplaintId).HasColumnName("User_ComplaintID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("Deleted_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_by")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserComplaintTitle)
                    .HasColumnName("UserComplaint_title")
                    .HasMaxLength(400);

                entity.Property(e => e.UserComplaintType)
                    .HasColumnName("UserComplaint_type")
                    .HasMaxLength(100);

                entity.Property(e => e.Zoneid).HasColumnName("zoneid");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TabUserComplaint)
                    .HasForeignKey(d => d.Zoneid)
                    .HasConstraintName("FK__tab_User___zonei__61316BF4");
            });

            modelBuilder.Entity<TabWalletSettings>(entity =>
            {
                entity.HasKey(e => e.TripWalletId)
                    .HasName("PK__tab_wall__C5BB59366ED0D7A0");

                entity.ToTable("tab_wallet_settings");

                entity.Property(e => e.TripWalletId).HasColumnName("trip_wallet_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TripWalletAnswer)
                    .HasColumnName("trip_wallet_answer")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TripWalletQuestion)
                    .IsRequired()
                    .HasColumnName("trip_wallet_question")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TabZone>(entity =>
            {
                entity.HasKey(e => e.Zoneid)
                    .HasName("PK__tab_zone__2F74DB51C7D6F85A");

                entity.ToTable("tab_zone");

                entity.Property(e => e.Zoneid).HasColumnName("zoneid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(100);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("Deleted_by")
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Servicelocid).HasColumnName("servicelocid");

                entity.Property(e => e.Unit)
                    .HasColumnName("unit")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_by")
                    .HasMaxLength(100);

                entity.Property(e => e.Zonename)
                    .IsRequired()
                    .HasColumnName("zonename")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Serviceloc)
                    .WithMany(p => p.TabZone)
                    .HasForeignKey(d => d.Servicelocid)
                    .HasConstraintName("FK__tab_zone__servic__59C55456");
            });

            modelBuilder.Entity<TabZonepolygon>(entity =>
            {
                entity.HasKey(e => e.Zonepolygonid)
                    .HasName("PK__tab_zone__05C6EB76CBA1E296");

                entity.ToTable("tab_zonepolygon");

                entity.Property(e => e.Zonepolygonid).HasColumnName("zonepolygonid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("Created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("Created_by")
                    .HasMaxLength(100);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("Deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("Deleted_by")
                    .HasMaxLength(100);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("isDeleted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Latitudes)
                    .HasColumnName("latitudes")
                    .HasColumnType("decimal(8, 6)");

                entity.Property(e => e.Longitudes)
                    .HasColumnName("longitudes")
                    .HasColumnType("decimal(9, 6)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("Updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("Updated_by")
                    .HasMaxLength(100);

                entity.Property(e => e.Zoneid).HasColumnName("zoneid");

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.TabZonepolygon)
                    .HasForeignKey(d => d.Zoneid)
                    .HasConstraintName("FK__tab_zonep__zonei__5F7E2DAC");
            });

            modelBuilder.Entity<TabZonetypeRelationship>(entity =>
            {
                entity.HasKey(e => e.Zonetypeid)
                    .HasName("PK__tab_zone__87431789CD918029");

                entity.ToTable("tab_zonetype_relationship");

                entity.Property(e => e.Zonetypeid).HasColumnName("zonetypeid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Paymentmode)
                    .IsRequired()
                    .HasColumnName("paymentmode")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Showbill)
                    .HasColumnName("showbill")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Typeid).HasColumnName("typeid");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Zoneid).HasColumnName("zoneid");

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

                entity.ToTable("tbl_errorlog");

                entity.Property(e => e.Int).HasColumnName("int");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(100);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.FunctionName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
