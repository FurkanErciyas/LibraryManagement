using ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.DTO.DeleteDTO
{
    public class BookDeleteDTO
    {
        public int Id { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.Passive;
        public DataStatusEnum DataStatus { get; set; } = DataStatusEnum.Deleted;
        public DateTime DeletedDate { get; set; } = DateTime.Now;
    }
}
