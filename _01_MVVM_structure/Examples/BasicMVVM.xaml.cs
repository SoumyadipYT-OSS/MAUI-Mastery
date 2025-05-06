using _01_MVVM_structure.ViewModels;

namespace _01_MVVM_structure.Examples;

public partial class BasicMVVM : ContentPage
{
	public BasicMVVM()
	{
		InitializeComponent();

		// Set the BindingContext to the ViewModel
		BindingContext = new ClockViewModel();
    }
}