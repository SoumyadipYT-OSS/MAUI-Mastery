using _02_DependencyInjection.Models;
using System.Collections.Generic;

namespace _02_DependencyInjection.Service;

public class CoffeeService : ICoffeeService {
    public List<CoffeePackage> GetCoffeePackages() {
        return [
            new CoffeePackage {
                Name = "Araku",
                Description = "A coffee from the Araku Valley in India, known for its unique flavor profile and organic farming practices.",
                Quantity = "250",
                Price = 500,
                Rating = 4.5,
                ImageUrl = "https://www.arakucoffee.in/cdn/shop/files/Coffee-grandreserve-mood.jpg?v=1686923973&width=2048"
            },
            new CoffeePackage {
                Name = "Blue Tokai",
                Description = "A specialty coffee brand from India, known for its single-origin coffees sourced from various regions.",
                Quantity = "200",
                Price = 600,
                Rating = 4.7,
                ImageUrl = "https://bluetokaicoffee.com/cdn/shop/products/CBCListing1055_260922_1024x1024.jpg?v=1664272351"
            },
            new CoffeePackage {
                Name = "Country Bean",
                Description = "A brand that offers a variety of coffee blends, including instant coffee and filter coffee.",
                Quantity = "300",
                Price = 300,
                Rating = 4.2,
                ImageUrl = "https://www.bigbasket.com/media/uploads/p/l/40186120_2-country-bean-vanilla-flavoured-instant-coffee.jpg"
            }
        ];
    }
}

