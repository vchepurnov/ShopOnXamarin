using Models.Identity;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Models
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
            OrderSeats = new HashSet<OrderSeat>();
        }

        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public int? UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<OrderSeat> OrderSeats { get; set; }
    }
    public enum OrderStatus
    {
        Отменён,
        Неоплачен,
        Оплачен,
        ОплатаПриПолучении
    }
}
