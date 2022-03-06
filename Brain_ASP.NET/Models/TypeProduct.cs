using System.Collections.Generic;

namespace Models
{
    public partial class TypeProduct
    {
        public TypeProduct()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
