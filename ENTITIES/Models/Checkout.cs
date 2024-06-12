using ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Models
{
    public class Checkout
    {
        public int CheckoutId { get; set; }

        public DateTime CheckOutDate { get; set; } = DateTime.Now;
        public DateTime? ReturnDate { get; set; } = DateTime.Now.AddDays(15);
        public DateTime? CheckInDate { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.Active;

        public int UserId { get; set; }
        public User User { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }


    }
}
