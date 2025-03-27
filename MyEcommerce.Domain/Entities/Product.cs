namespace MyEcommerce.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } // Nullable, so it can be empty
        public decimal Price { get; set; }
    }
}
