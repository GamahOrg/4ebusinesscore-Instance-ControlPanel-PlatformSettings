namespace PlatformSettings.Infrastructure.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
        public DbSet<MainSettings> PlatformSettings { get; set; }
        public DbSet<MainSettingsSites> PlatformSettingsSites { get; set; }
        public DbSet<MainSettingsDepartmentItems> PlatformSettingsDepartmentItems { get; set; }
        public DbSet<MainSettingsDepartmentsIcons> PlatformSettingsDepartmentsIcons { get; set; }
        public DbSet<MainSettingHeaders> MainSettingHeaders { get; set; }
        public DbSet<MainSettingLogin> MainSettingLogin { get; set; }
        public bool AllMigrationsApplied()
        {
            var applied = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = this.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        public void Migrate()
        {
            Database.Migrate();
        }
    }
}
