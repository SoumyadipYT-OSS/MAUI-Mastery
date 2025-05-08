
namespace _02_DependencyInjection.Models;

public class CoffeePackage {
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Quantity { get; set; }  // in mg
    public decimal Price { get; set; }  // in Rupees
    public double Rating { get; set; }  // out of 5.0
    public string? ImageUrl { get; set; }
}
