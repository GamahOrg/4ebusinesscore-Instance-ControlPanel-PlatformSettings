namespace PlatformSettings.Domain.Entities
{
    public class AuditEntity<TKey> : Entity<TKey>
    {
        public DateTime CreatedOn { set; get; }
        public Guid? UpdatedBy { set; get; }
        public DateTime? UpdatedOn { set; get; }
        public Guid? CreatedBy { set; get; }
    }
}
