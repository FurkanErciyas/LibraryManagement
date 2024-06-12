using ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Models
{
    public class Book : BaseEntity
    {
        [Required, MaxLength(100)]
        public string? Title { get; set; }

        [Required, MaxLength(100)]
        public string? Author { get; set; }

        [Required, MaxLength(100)]
        public string? Translator { get; set; }

        [Required, MaxLength(50)]
        public string? Publisher { get; set; }

        [Required]
        public BookTypeEnum BookType { get; set; }

        [Required]
        public BookLanguageEnum BookLanguage { get; set; }

        [Required]
        public int NumberPages { get; set; }

        [Required, MaxLength(20)]
        public string? ISBN { get; set; }
        public ICollection<Checkout>? Checkouts { get; set; }
    }
}
