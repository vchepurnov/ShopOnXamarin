using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Shop_on_xamarin.ViewModels;

namespace Shop_on_xamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        private readonly CategoriesViewModel _vm = new CategoriesViewModel();
        public ProductsPage()
        {
            InitializeComponent();
            BindingContext = _vm;
            //loading();
        }
        public async Task loading()
        {
            await _vm.LoadData();
        }
    }
}