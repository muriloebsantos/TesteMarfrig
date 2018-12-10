using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Marfrig.WPF.Services
{
    public static class AutenticacaoService
    {
        public static async Task Autenticar()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("grant_type", "password");
            dict.Add("username", "usr_marfrig");
            dict.Add("password", "4oa_4ajujd584dk55");

            var client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["urlApi"]);

            var req = new HttpRequestMessage(HttpMethod.Post, "token") { Content = new FormUrlEncodedContent(dict) };
            var res = await client.SendAsync(req);

            if (res.IsSuccessStatusCode)
            {
                var jsonString = await res.Content.ReadAsStringAsync();
                var jsonObject = JsonConvert.DeserializeObject<Token>(jsonString.ToString());

                Token = jsonObject.Access_Token;
            }
        }

        public static string Token { get; set; }
    }

    public class Token
    {
        public string Access_Token { get; set; }
    }
}
