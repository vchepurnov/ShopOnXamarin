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
    public partial class Page1 : Shell
    {
        private readonly RegisterViewModel _vm = new RegisterViewModel();
        public Page1()
        {
            InitializeComponent();
            BindingContext = _vm;
        }

    }
}