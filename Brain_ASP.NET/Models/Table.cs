using System.Collections.ObjectModel;

namespace Models
{
    public class Table
    {
        public int Id { get; set; }
        public ObservableCollection<Seat> Seats { get; set; }
    }
}
