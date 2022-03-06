using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class OrderSeat
    {
        public int OrdersId { get; set; }
        public int SeatsId { get; set; }

        public virtual Order Orders { get; set; }
        public virtual Seat Seats { get; set; }
    }
}
