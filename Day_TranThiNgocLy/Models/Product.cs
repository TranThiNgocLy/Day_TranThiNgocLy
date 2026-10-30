namespace Day_TranThiNgocLy.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = String.Empty;
        public int CategoryId { get; set; } 
        public Category? Category { get; set; }
    }
}
