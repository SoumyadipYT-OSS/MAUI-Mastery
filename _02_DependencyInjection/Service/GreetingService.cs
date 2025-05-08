
namespace _02_DependencyInjection.Service;

public class GreetingService : IGreetingService {
    public string GetGreeting() {
        return "Namaste from Dependency Injection!";
    }
}