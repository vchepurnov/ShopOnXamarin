using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;

namespace Models.Identity
{
    public class ApplicationUser: IdentityUser
    {
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public ObservableCollection<Order> Orders { get; set; }
    }
}
