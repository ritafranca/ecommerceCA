using System.ComponentModel.DataAnnotations;

public class ProductDto
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; } // ✅ ID is required

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty; // ✅ Name is required (cannot be empty)

    public string Description { get; set; } = string.Empty; // ✅ Description is optional (can be empty)

    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
    public decimal Price { get; set; } // ✅ Price is required and must be greater than 0
}
