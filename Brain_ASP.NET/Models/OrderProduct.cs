using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class OrderProduct
    {
        public int OrdersId { get; set; }
        public int ProductsId { get; set; }

        public virtual Order Orders { get; set; }
        public virtual Product Products { get; set; }
    }
}
