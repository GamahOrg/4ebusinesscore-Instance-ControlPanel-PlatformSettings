namespace PlatformSettings.Domain.Entities
{
    public class Entity<TKey>
    {
        public TKey Id { get; set; }        
        public State State { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
