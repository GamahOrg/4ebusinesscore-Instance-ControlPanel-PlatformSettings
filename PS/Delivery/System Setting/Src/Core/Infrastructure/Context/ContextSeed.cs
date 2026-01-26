namespace PlatformSettings.Infrastructure.Context
{
    public class ContextSeed
    {
        private static DBContext _dbContext;
        private static IServiceProvider _serviceProvider;

        public static void Seed(DBContext appDbContext, IServiceProvider serviceProvider)
        {
            _dbContext = appDbContext;
            _dbContext.Database.EnsureCreated();
            _serviceProvider = serviceProvider;

            SeedPlatform();
            SeedMainSettingHeaders();
        }
        private static void SeedPlatform()
        {
            if (!_dbContext.PlatformSettings.Any())
            {
                string platformAsJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "PlatformSeed.json");
                var platform = JsonConvert.DeserializeObject<List<MainSettings>>(platformAsJson);
                
                if (platform != null)
                {
                    foreach (var item in platform)
                    {
                        item.CreatedOn = DateTime.Now;
                        item.UpdatedOn = DateTime.Now;
                        item.CreatedBy = null;
                        item.UpdatedBy = null;
                        _dbContext.PlatformSettings.Add(item);
                        _dbContext.SaveChanges();
                    }
                }
            }
        }
        private static void SeedMainSettingHeaders()
        {
            if (!_dbContext.MainSettingHeaders.Any())
            {
                string platformAsJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "MainSettingHeadersSeed.json");
                var platform = JsonConvert.DeserializeObject<List<MainSettingHeaders>>(platformAsJson);
                var id = _dbContext.PlatformSettings?.FirstOrDefault()?.Id;
                if (platform != null)
                {
                    foreach (var item in platform)
                    {
                        item.CreatedOn = DateTime.Now;
                        item.UpdatedOn = DateTime.Now;
                        item.CreatedBy = null;
                        item.UpdatedBy = null;

                        item.MainSettingsId = id;
                        _dbContext.MainSettingHeaders.Add(item);
                        _dbContext.SaveChanges();
                    }
                }
            }
            else
            {
                string platformAsJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "MainSettingHeadersSeed.json");
                var platform = JsonConvert.DeserializeObject<List<MainSettingHeaders>>(platformAsJson);
                var id = _dbContext.PlatformSettings?.FirstOrDefault()?.Id;
                var headers = _dbContext.MainSettingHeaders.ToList();
                platform.ForEach(item => {
                    var header = headers.FirstOrDefault(n=>n.Id == item.Id);
                        if (header != null)
                        {
                            header.Squence = item.Squence;
                            _dbContext.MainSettingHeaders.Update(header);
                            _dbContext.SaveChanges();
                        }
                        else
                        {
                            item.CreatedOn = DateTime.Now;
                            item.UpdatedOn = DateTime.Now;
                            item.CreatedBy = null;
                            item.UpdatedBy = null;

                            item.MainSettingsId = id;
                            _dbContext.MainSettingHeaders.Add(item);
                            _dbContext.SaveChanges();
                        }

                    });
            }

        }
    }
}