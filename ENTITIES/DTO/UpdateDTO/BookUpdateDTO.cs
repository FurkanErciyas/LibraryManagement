using ENTITIES.Enums;
using ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.DTO.UpdateDTO
{
    public class BookUpdateDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Translator { get; set; }
        public string? Publisher { get; set; }
        public BookTypeEnum BookType { get; set; }
        public BookLanguageEnum BookLanguage { get; set; }
        public int NumberPages { get; set; }
        public string? ISBN { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public DataStatusEnum DataStatus { get; set; } = DataStatusEnum.Updated;
    }
}
