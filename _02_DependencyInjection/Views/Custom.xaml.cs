using _02_DependencyInjection.Service;
using _02_DependencyInjection.Models;
using Microsoft.Maui.Controls;

namespace _02_DependencyInjection.Views {
    public partial class Custom : ContentPage {
        private readonly ICoffeeService _coffeeService;

        public Custom(ICoffeeService coffeeService) {
            InitializeComponent();
            _coffeeService = coffeeService;

            LoadCoffeePackages();
        }

        private void LoadCoffeePackages() {
            var coffeePackages = _coffeeService.GetCoffeePackages();
            CoffeePackagesView.ItemsSource = coffeePackages;
        }
    }
}