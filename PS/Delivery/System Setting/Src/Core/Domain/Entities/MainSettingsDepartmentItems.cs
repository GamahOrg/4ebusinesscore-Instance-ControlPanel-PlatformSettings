
namespace PlatformSettings.Domain.Entities
{
    public class MainSettingsDepartmentItems : AuditEntity<Guid>
    {
        [ForeignKey("MainSettings")]
        public Guid? MainSettingsId { get; set; }
        public MainSettings MainSettings { get; set; }
        public string? IconImg { get; set; }
        public string? ItemName { get; set; }
        public string? ItemURL { get; set; }
    }
}
