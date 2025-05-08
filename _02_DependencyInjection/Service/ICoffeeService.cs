using _02_DependencyInjection.Models;

namespace _02_DependencyInjection.Service;

public interface ICoffeeService {
    List<CoffeePackage> GetCoffeePackages();
}
