namespace App.Data.Entity
{
    public abstract class BaseAuditEntity : BaseEntity, IAuditEntity
    {

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get ; set ; }
        public DateTime? DeletedAt { get ; set ; }
    }
}
