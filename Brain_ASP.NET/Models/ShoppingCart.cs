using Microsoft.EntityFrameworkCore;
using Models.Identity;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Models
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            ProductShoppingCarts = new HashSet<ProductShoppingCart>();
            Seats = new HashSet<Seat>();
        }

        public int Id { get; set; }

        public virtual ICollection<ProductShoppingCart> ProductShoppingCarts { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
        public virtual int UserProfileId { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
