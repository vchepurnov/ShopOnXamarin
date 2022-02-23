using System.Collections.ObjectModel;

namespace Models
{
    public class Seat
    {
        public int Id { get; set; }
        public bool IsBusy { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public int? ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
    }
}
