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
            BindingContext = _vm;
            loading();
        }
        public async Task loading()
        {
            await _vm.LoadData();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}