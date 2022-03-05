using System.Collections.Generic;

namespace Models
{
    public class AddProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public List<string> Photo { get; set; }

        public int TypeProductId { get; set; }
    }
}
