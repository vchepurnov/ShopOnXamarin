using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shop_on_xamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderListPage : ContentPage
    {
        public OrderListPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void GoToShopingCart(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShoppingCartPage());
        }

        private void GoToProductsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync (new ProductsPage());
        }
    }
}