using _01_MVVM_structure.ViewModels;

namespace _01_MVVM_structure.Examples;

public partial class CustomMVVM : ContentPage
{
	private TaskViewModel _viewModel;

	public CustomMVVM() {
		InitializeComponent();
		_viewModel = new TaskViewModel();
		BindingContext = _viewModel;
	}

	private void OnTaskCompletedChanged(object sender, CheckedChangedEventArgs e) {
		if (sender is CheckBox checkBox  &&  checkBox.BindingContext is TaskItem taks) {
			_viewModel.UpdateTaskStatus(taks);
		}
	}
}