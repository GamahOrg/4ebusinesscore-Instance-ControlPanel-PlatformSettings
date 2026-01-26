
using PlatformSettings.Domain.Entities;

namespace PlatformSettings.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;
        private IDbContextTransaction _transaction;

        #region Repository
        public SystemSetting.GenericRepo.IGRepository<MainSettings> _mainSettingsRepository { get; }
        public SystemSetting.GenericRepo.IGRepository<MainSettingsSites> _mainSettingsSitesRepository { get; }
        public SystemSetting.GenericRepo.IGRepository<MainSettingsDepartmentItems> _mainSettingsDepartmentRepository { get; }
        public SystemSetting.GenericRepo.IGRepository<MainSettingsDepartmentsIcons> _mainSettingsDeptsIconsRepository { get; }
        public SystemSetting.GenericRepo.IGRepository<MainSettingHeaders> _mainSettingHeadersRepository { get; }
        public SystemSetting.GenericRepo.IGRepository<MainSettingLogin> _mainSettingLoginRepository { get; }

        #endregion

        #region constructor
        public UnitOfWork
        (
            DBContext context,
            SystemSetting.GenericRepo.IGRepository<MainSettings> mainSettingsRepository,
            SystemSetting.GenericRepo.IGRepository<MainSettingsSites> mainSettingsSitesRepository,
            SystemSetting.GenericRepo.IGRepository<MainSettingsDepartmentItems> mainSettingsDepartmentRepository,
            SystemSetting.GenericRepo.IGRepository<MainSettingsDepartmentsIcons> mainSettingsDeptsIconsRepository,
            SystemSetting.GenericRepo.IGRepository<MainSettingHeaders> mainSettingHeadersRepository,
            SystemSetting.GenericRepo.IGRepository<MainSettingLogin> mainSettingLoginRepository
        )
        {
            _context = context;
            _mainSettingsRepository = mainSettingsRepository;
            _mainSettingsSitesRepository = mainSettingsSitesRepository;
            _mainSettingsDepartmentRepository = mainSettingsDepartmentRepository;
            _mainSettingsDeptsIconsRepository = mainSettingsDeptsIconsRepository;
            _mainSettingHeadersRepository = mainSettingHeadersRepository;
            _mainSettingLoginRepository = mainSettingLoginRepository;
        }

        #endregion

        #region Transaction
        public void BeginTransaction() => _transaction = _context.Database.BeginTransaction();
        //public async Task BeginTransactionAsync() => _transaction = await _context.Database.BeginTransactionAsync();
        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
            {
                _transaction = await _context.Database.BeginTransactionAsync();
            }
        }
        public void Commit() => _transaction.Commit();
        //public async Task CommitAsync() => await _transaction.CommitAsync();
        public async Task CommitAsync()
        {
            try
            {
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                    _transaction = null;
                }
            }
            catch (Exception)
            {
                await RollbackAsync();
                await Console.Out.WriteLineAsync("RollBack!");
                throw new InvalidOperationException("RollBack!");
            }
        }
        public void Rollback() => _transaction?.Rollback();
        //public async Task RollbackAsync() => await _transaction.RollbackAsync();
        public async Task RollbackAsync()
        {
            try
            {
                if (_transaction != null)
                {
                    await _transaction.RollbackAsync();
                    _transaction = null;
                }
                else
                {
                    await Console.Out.WriteLineAsync("NoActiveTransactionToRollBack!");
                    throw new InvalidOperationException("NoActiveTransactionToRollBack!");
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message + (ex != null && ex.InnerException != null ? ex.InnerException.Message : ""));
                throw new InvalidOperationException("anErrorOccurredPleaseContactSystemAdministrator!");
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
        public async Task DisposeAsync()
        {
            await _transaction.DisposeAsync();
            await _context.DisposeAsync();
        }
        #endregion

        #region SaveChanges
        public void SaveChanges()
        {
            try
            {
                if (_context.Database.CurrentTransaction == null)
                    BeginTransaction();
                _context.SaveChanges();
                //Commit();
            }
            catch (Exception)
            {
                Rollback();

            }

        }

        public async Task SaveChangesAsync()
        {
            try
            {
                if (_context.Database.CurrentTransaction == null)
                    await BeginTransactionAsync();
                await _context.SaveChangesAsync();
                //Commit();
            }
            catch (Exception)
            {
                await RollbackAsync();

            }

        }
        #endregion

    }
}
