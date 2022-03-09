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
using System.Net.Http.Headers;

namespace Shop_on_xamarin.ViewModels
{
    class CategoriesViewModel : INotifyPropertyChanged
    {

        public ICommand loadingCategories => new Command(async value => { await LoadData(); });

        private ObservableCollection<Category> _category;

        public ObservableCollection<Category> category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadData()
        {
            //var client = await loadData();
            var client = new HttpClient(GetInsecureHandler());
            var response = await client.GetAsync("http://10.0.2.2:5000/api/Categories").ConfigureAwait(false);
            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ObservableCollection<Category>>(json);
            category = list;
        }

        public async Task<HttpClient> loadData()
        {
            HttpClient client = new HttpClient(GetInsecureHandler());
            client.BaseAddress = new Uri("http://10.0.2.2:28499/");
            client.DefaultRequestHeaders
                  .Accept
                  .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
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
