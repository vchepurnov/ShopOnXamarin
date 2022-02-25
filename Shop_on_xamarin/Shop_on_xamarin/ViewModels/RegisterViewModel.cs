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
namespace Shop_on_xamarin.ViewModels
{
    class RegisterViewModel
    {

            public async Task LoadData()
            {
                var NewPerson = new RegisterModel { Username = "Vitaly", Email = "chepurnov@mail.ru", Password ="PacTa02!" };
                // сериализация объекта с помощью Json.NET
                string json = JsonConvert.SerializeObject(NewPerson);
                HttpContent content = new StringContent(json);

                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.PostAsync("http://10.0.2.2:5000/api/Authenticate/register", content);
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

