using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Shop_on_xamarin.ViewModels;
using System.Windows.Input;
using Models;

namespace Shop_on_xamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        private readonly ProductListViewModel _vm = new ProductListViewModel();
        public ProductsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _vm;         
            loading();
        }
        public async Task loading()
        {
            await _vm.LoadData();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var product = ((ListView)sender).SelectedItem as Product;
            if (product == null)
                return;
            var Id = product.Id;
            await Navigation.PushAsync(new DescriptionProductPage(Id));
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        private void Open_Description(object sender, EventArgs e)
        {
            
        }

        private void GoToShopingCart(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShoppingCartPage());
        }

        private void GoToOrderListPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrderListPage());
        }
    }
}