using _02_DependencyInjection.Views;
using Microsoft.Extensions.DependencyInjection;

namespace _02_DependencyInjection {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        private async void OnBasic_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(Application.Current!.Handler.MauiContext!.Services.GetService<Basic>());
        }

        private async void OnSimple_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(Application.Current!.Handler.MauiContext!.Services.GetService<Simple>());
        }

        private async void OnCustom_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(Application.Current!.Handler.MauiContext!.Services.GetService<Custom>());
        }
    }
}
