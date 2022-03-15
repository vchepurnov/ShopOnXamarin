﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shop_on_xamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        private void GoToTableReservationPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TableReservationPage());
        }
        private void GoToOrderList(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OrderListPage());
        }

    }
}