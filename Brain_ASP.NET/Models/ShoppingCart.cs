using Models.Identity;
using System.Collections.ObjectModel;

namespace Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ObservableCollection<Seat> Seats { get; set; }
        public ObservableCollection<Product> Products { get; set; }
    }
}
