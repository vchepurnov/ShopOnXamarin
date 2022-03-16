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
    public partial class ShoppingCartPage : ContentPage
    {
        public ShoppingCartPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void GoToProductsPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProductsPage());
        }
        private void GoToOrderListPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrderListPage());
        }
    }
}