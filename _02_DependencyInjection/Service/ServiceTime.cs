
namespace _02_DependencyInjection.Service;

public class ServiceTime : ITimeService {
    public string GetCurrentTime() {
        return DateTime.Now.ToString("F");
    }
}
