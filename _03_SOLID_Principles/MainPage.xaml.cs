using _03_SOLID_Principles.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace _03_SOLID_Principles
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private async void OnBasicSOLIDClicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new BasicSOLID());
        }
    }
}
