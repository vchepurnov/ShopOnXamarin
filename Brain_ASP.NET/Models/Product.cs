using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Models
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
            ProductShoppingCarts = new HashSet<ProductShoppingCart>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int TypeProductId { get; set; }
        public string[] Photo { get; set; }

        public virtual TypeProduct TypeProduct { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<ProductShoppingCart> ProductShoppingCarts { get; set; }
    }
}
