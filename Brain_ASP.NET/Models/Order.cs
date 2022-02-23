using Models.Identity;
using System.Collections.ObjectModel;

namespace Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ObservableCollection<Seat> Seats { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public OrderStatus Status { get; set; }
    }
    public enum OrderStatus
    {
        Отменён,
        Неоплачен,
        Оплачен,
        ОплатаПриПолучении
    }
}
