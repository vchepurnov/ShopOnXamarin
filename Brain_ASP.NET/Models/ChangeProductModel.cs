using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ChangeProductModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public int? TypeProductId { get; set; }
    }
}
