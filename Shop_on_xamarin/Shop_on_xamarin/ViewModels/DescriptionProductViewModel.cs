using Hangfire.Annotations;
using Models.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Models;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Shop_on_xamarin.ViewModels
{
    class DescriptionProductViewModel : INotifyPropertyChanged
    {
        public int Id;
        private string name;
        private string mainphoto;
        private int price;
        private string description;
        public ICommand loadingDescription => new Command(async value => { await LoadData(Id); });

        private ObservableCollection<Product> _product;

        public ObservableCollection<Product> product
        {
            get => _product;
            set
            {
                _product = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get { return name; }
            private set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public string MainPhoto
        {
            get { return mainphoto; }
            private set
            {
                mainphoto = value;
                OnPropertyChanged("MainPhoto");
            }
        }
        public int Price
        {
            get { return price; }
            private set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public string Description
        {
            get { return description; }
            private set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public async Task LoadData(int Id)
        {
            var _id = Id;
            string url = "http://10.0.2.2:5000/api/Products/";
            try
            {
                HttpClient client = new HttpClient(GetInsecureHandler());
                client.BaseAddress = new Uri(url + Convert.ToString(_id));
                var response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode(); // выброс исключения, если произошла ошибка

                // десериализация ответа в формате json
                var content = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(content);
                var str = o.SelectToken("");
                var product = JsonConvert.DeserializeObject<Product>(str.ToString());

                this.Name = product.Name;
                this.MainPhoto = product.MainPhoto;
                this.Price = product.Price;
                this.Description = product.Description;

            }
            catch (Exception ex)
            { }
        }

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

