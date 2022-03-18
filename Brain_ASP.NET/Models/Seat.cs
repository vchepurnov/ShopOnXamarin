using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public partial class Seat
    {
        public Seat()
        {
        }

        public int Id { get; set; }
        /// <summary>
        /// Для вернового отображения загружать с помощью Include(a => a.Order)
        /// </summary>
        [NotMapped]
        public bool IsBusy { get => Order == null; }
        public Table Table { get; set; }
        public int TableId { get; set; }
        public int? ShoppingCartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
