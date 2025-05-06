using _01_MVVM_structure.ViewModels;

namespace _01_MVVM_structure.Examples;

public partial class SimpleMVVM : ContentPage
{
	public SimpleMVVM()
	{
		InitializeComponent();

        // Set the ViewModel as the BindingContext in the Code instead of XAML
        BindingContext = new DateTimeViewModel();
	}
}