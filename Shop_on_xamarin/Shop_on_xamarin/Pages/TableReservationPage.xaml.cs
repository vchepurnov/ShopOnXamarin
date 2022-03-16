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
    public partial class TableReservationPage : ContentPage
    {
        public TableReservationPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void GoToBack(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void GoToTablePage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TablePage8());
        }
    }
}