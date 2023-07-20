namespace App.Data.Entity
{
    public abstract class BaseAuditEntity : BaseEntity, IAuditEntity
    {
        public DateTime CreatedAt { get; set ; }
        public DateTime? UpdatedAt { get ; set ; }
        public DateTime? DeletedAt { get ; set ; }
    }
}
