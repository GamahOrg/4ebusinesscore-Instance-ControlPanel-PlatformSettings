
namespace PlatformSettings.Domain.Entities
{
    public class MainSettingHeaders : AuditEntity<Guid>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Url { get; set; }
        public int? WorkspaceKey { get; set; }
        public bool IsDropdown { get; set; }
        public State? State { get; set; }
        public int? Squence { get; set; }
        public bool? IsHide { get; set; }
        public bool? CanDelete { get; set; }

        [ForeignKey("MainSettings")]
        public Guid? MainSettingsId { get; set; }

        public MainSettings MainSettings { get; set; }
    }
}
