using Hangfire.Annotations;
using Models.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Models;
using System.Text;

namespace Shop_on_xamarin.ViewModels
{
    class RegisterViewModel : INotifyPropertyChanged
    {

        public ICommand loading => new Command(async value => { await LoadData(); });
        //public ICommand post => new Command(async value => { await PostMethod(); });

        private ObservableCollection<Product> _picture;

        public ObservableCollection<Product> picture
        {
            get => _picture;
            set
            {
                _picture = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadData()
        {
            var client = new HttpClient(GetInsecureHandler());
            var response = await client.GetAsync("http://10.0.2.2:5000/api/Products").ConfigureAwait(false);
            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ObservableCollection<Product>>(json);
            picture = list;
        }

        //public async Task PostMethod()
        //{
        //    var Post = new AddProductModel { Name = "Индийский чай", Price = 50, TypeProductId = 1 };
        //    HttpClient client = new HttpClient(GetInsecureHandler());
        //    client.DefaultRequestHeaders.Add("Accept", "application.json");
        //    var result = client.PostAsync("http://10.0.2.2:5000/api/Products/add-product",
        //        new StringContent(JsonConvert.SerializeObject(Post), Encoding.UTF8, "application/json"));
        //    Name = "Индийский чай";
        //}


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;


        }
    }

}




