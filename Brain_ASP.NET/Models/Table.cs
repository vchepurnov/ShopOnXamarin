using System.Collections.ObjectModel;

namespace Models
{
    class Table
    {
        public int Id { get; set; }
        public ObservableCollection<Seat> Seats { get; set; }
    }
}
