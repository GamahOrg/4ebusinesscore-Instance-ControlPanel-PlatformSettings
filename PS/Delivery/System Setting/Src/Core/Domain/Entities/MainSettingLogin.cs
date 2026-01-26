
namespace PlatformSettings.Domain.Entities
{
    public class MainSettingLogin : AuditEntity<Guid>
    {
        public string? DescriptionAr { get; set; }
        public string? DescriptionEn { get; set; }
        public string? Image { get; set; }

        [ForeignKey("MainSettings")]
        public Guid? MainSettingsId { get; set; }

        public MainSettings MainSettings { get; set; }
        public Guid? SubSystemId { get; set; }
    }
}
