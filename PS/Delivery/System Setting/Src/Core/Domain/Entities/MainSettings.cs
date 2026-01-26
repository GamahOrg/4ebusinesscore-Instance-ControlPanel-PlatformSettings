
namespace PlatformSettings.Domain.Entities
{
    public class MainSettings : AuditEntity<Guid>
    {
        public string? WebLogo { get; set; }
        public string? WebTitle { get; set; }
        public string? WebUrl { get; set; }
        public string? WebDescription { get; set; }
        public string? WebCover { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? TemporaryWebCover { get; set; }

        public string? headerCover { get; set; }

        public string? TemporaryWebCoverDarkMode { get; set; }
        public string? WebCoverDarkMode { get; set; }
        public string? FooterLogo { get; set; }
        public string? FooterLogoDarkMode { get; set; }
        public string? LogoWebCoverLogin { get; set; }
        public string? WebCoverLogin { get; set; }
        public string? FooterDescriptionAr { get; set; }
        public string? FooterDescriptionEn { get; set; }
        public string? WebLogoDarkMode { get; set; }
        public string? headerCoverDarkMode { get; set; }
        public string? IconTitle { get; set; }
        public string? ThemName { get; set; }
        public string? AttachmentStyle { get; set; }
        public bool? IsThem { get; set; }
        public string? LogoWebCoverLoginEn { get; set; }
        public string? ChatBotName { get; set; }
        public bool? ChatBotIsVisible { get; set; }
        public string? LogoSystemLogin { get; set; }
        public int? DeurationSppinner { get; set; }
        public string? TitleNews { get; set; }
        public string? TitleEvents { get; set; }
        public string? TitleNewsEn { get; set; }
        public string? TitleEventsEn { get; set; }
        public SignInMode SignInMode { get; set;}
        public ThemMode? ThemMode { get; set; }

        public ICollection<MainSettingsSites> MainSettingsSites { get; set; }
        public ICollection<MainSettingsDepartmentItems> MainSettingsDepartments { get; set; }
        public ICollection<MainSettingsDepartmentsIcons> MainSettingsDepartmentsIcons { get; set; }
        public ICollection<MainSettingHeaders> MainSettingHeaders { get; set; }
        public ICollection<MainSettingLogin> MainSettingLogins { get; set; }
    }
}
