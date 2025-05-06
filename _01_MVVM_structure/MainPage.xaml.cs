using _01_MVVM_structure.Examples;

namespace _01_MVVM_structure
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnBasicMvvM_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new BasicMVVM());
        }

        private async void OnSimpleMvvM_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new SimpleMVVM());
        }

        private async void OnCustomMvvM_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new CustomMVVM());
        }
    }

}
