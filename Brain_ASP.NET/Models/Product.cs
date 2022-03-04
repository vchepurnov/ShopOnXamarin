using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int TypeProductId { get; set; }
        public TypeProduct TypeProduct { get; set; }
        public List<string> Photo { get; set; }
        public ObservableCollection<ShoppingCart> ShoppingCarts { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
    }
}
