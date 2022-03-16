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
    public partial class TablePage6 : ContentPage
    {
        public TablePage6()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void GoToBack(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        private void GoToProductPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProductsPage());
        }
    }
}