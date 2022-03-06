using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TypeProduct> TypeProducts { get; set; }
    }
}
