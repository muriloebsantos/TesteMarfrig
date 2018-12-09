using Marfrig.Application.DTOs.Animais;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Marfrig.WPF.Services
{
    public class AnimalService : ApiClient
    {
        public async Task<IEnumerable<AnimalDTO>> ObterAnimais()
        {
            IEnumerable<AnimalDTO> animais = null;
            HttpResponseMessage response = await client.GetAsync($"api/Animal");
            if (response.IsSuccessStatusCode)
            {
                animais = await response.Content.ReadAsAsync<IEnumerable<AnimalDTO>>();
            }
            return animais;
        }
    }
}
