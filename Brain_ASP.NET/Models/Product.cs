namespace Models
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int TypeProductId { get; set; }
        public TypeProduct TypeProduct { get; set; }
    }
}
