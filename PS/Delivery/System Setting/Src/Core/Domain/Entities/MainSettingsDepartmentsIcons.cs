
namespace PlatformSettings.Domain.Entities
{
    public class MainSettingsDepartmentsIcons : AuditEntity<Guid>
    {
        [ForeignKey("MainSettings")]
        public Guid? MainSettingsId { get; set; }
        public MainSettings MainSettings { get; set; }
        public string? IconImg { get; set; }
        public string? IconName { get; set; }
        public string? IconURL { get; set; }
    }
}
