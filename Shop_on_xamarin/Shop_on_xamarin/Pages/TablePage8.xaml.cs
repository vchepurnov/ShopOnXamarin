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
    public partial class TablePage8 : ContentPage
    {
        public TablePage8()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void GoToBack(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}