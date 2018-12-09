using System;
using System.Collections.Generic;
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
            client.BaseAddress = new Uri("http://localhost:24326/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
