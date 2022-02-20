namespace Models
{
    class Seat
    {
        public int Id { get; set; }
        public bool IsBusy { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
    }
}
