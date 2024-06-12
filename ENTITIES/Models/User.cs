using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Models
{
    public class User : BaseEntity
    {
        [Required, MaxLength(20)]
        public string? FirstName { get; set; }

        [MaxLength(20)]
        public string? SecondName { get; set; }
        
        [Required, MaxLength(20)]
        public string? LastName { get; set; }
        
        [Required, MaxLength(11)]
        public string? IdentityNumber { get; set; }

        [Required, MaxLength(200)]
        public string? Address { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required, Phone]
        public string? Phone { get; set; }
        public ICollection<Checkout>? Checkouts { get; set; }
    }
}
