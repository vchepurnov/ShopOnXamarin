using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Models
{
    public partial class Seat
    {
        public Seat()
        {
            OrderSeats = new HashSet<OrderSeat>();
        }

        public int Id { get; set; }
        public bool IsBusy { get; set; }
        public int TableId { get; set; }
        public int? ShoppingCartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual ICollection<OrderSeat> OrderSeats { get; set; }
    }
}
