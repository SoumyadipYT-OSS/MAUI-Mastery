using _02_DependencyInjection.Service;

namespace _02_DependencyInjection.Views;

public partial class Basic : ContentPage
{
	private readonly IGreetingService _greetingService;

	public Basic(IGreetingService greetingService)
	{
		InitializeComponent();

		// Resolve the IGreetingService from the service provider
		_greetingService = greetingService;

		// Use the injected service
		GreetingLabel.Text = _greetingService.GetGreeting();
    }
}