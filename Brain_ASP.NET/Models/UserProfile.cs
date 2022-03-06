using Microsoft.EntityFrameworkCore;
using Models.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Models
{
    //[Owned]
    public partial class UserProfile
    {
        public UserProfile()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual string AspNetUserId { get; set; }
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
