using ENTITIES.Enums;

namespace ENTITIES.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatusEnum DataStatus { get; set; } = DataStatusEnum.Created;
        public StatusEnum Status { get; set; } = StatusEnum.Active;
    }
}
