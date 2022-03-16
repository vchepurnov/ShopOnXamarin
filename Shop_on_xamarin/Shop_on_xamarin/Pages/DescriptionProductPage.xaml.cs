using Shop_on_xamarin.ViewModels;
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
    public partial class DescriptionProductPage : ContentPage
    {
        private readonly DescriptionProductViewModel _vm = new DescriptionProductViewModel();
        public DescriptionProductPage(int Id)
        {
            var id = Id;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _vm;
            loading(id);
        }

        public async Task loading(int _id)
        {
            var Id = _id;
            await _vm.LoadData(Id);
        }
        private void GoToBack(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}