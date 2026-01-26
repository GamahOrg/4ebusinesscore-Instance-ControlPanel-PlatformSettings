
namespace PlatformSettings.Domain.Entities
{
    public class MainSettingsSites : AuditEntity<Guid>
    {
        [ForeignKey("MainSettings")]
        public Guid? MainSetId { get; set; }
        public MainSettings MainSettings { get; set; }
        public string? SiteName { get; set; }
        public string? SiteUrl { get; set; }
    }
}
