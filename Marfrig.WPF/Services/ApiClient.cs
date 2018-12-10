using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Marfrig.WPF.Services
{
    public abstract class ApiClient
    {
        protected readonly HttpClient client;

        public ApiClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["urlApi"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + AutenticacaoService.Token);
        }
    }
}
