
namespace PlatformSettings.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        #region Repository
        public SystemSetting.GenericRepo.IGRepository<MainSettings> _mainSettingsRepository { get; }
        public SystemSetting.GenericRepo.IGRepository<MainSettingsSites> _mainSettingsSitesRepository { get; }
        public SystemSetting.GenericRepo.IGRepository<MainSettingsDepartmentItems> _mainSettingsDepartmentRepository { get; }
        public SystemSetting.GenericRepo.IGRepository<MainSettingsDepartmentsIcons> _mainSettingsDeptsIconsRepository { get; }
        public SystemSetting.GenericRepo.IGRepository<MainSettingHeaders> _mainSettingHeadersRepository { get; }
        public SystemSetting.GenericRepo.IGRepository<MainSettingLogin> _mainSettingLoginRepository { get; }

        #endregion

        #region Transaction
        void BeginTransaction();
        void Commit();
        void Rollback();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        #endregion

        #region SaveChanges
        Task SaveChangesAsync();
        void SaveChanges();
        #endregion
    }
}
