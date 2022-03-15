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
    public partial class TablePage4 : ContentPage
    {
        public TablePage4()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void GoToBack(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void GoToRegisterPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProductsPage());
        }
    }
}