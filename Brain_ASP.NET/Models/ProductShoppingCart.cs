using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class ProductShoppingCart
    {
        public int ProductsId { get; set; }
        public int ShoppingCartsId { get; set; }

        public virtual Product Products { get; set; }
        public virtual ShoppingCart ShoppingCarts { get; set; }
    }
}
