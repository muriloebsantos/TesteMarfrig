using Marfrig.Application.DTOs.Pecuaristas;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Marfrig.WPF.Services
{
    public class PecuaristaService : ApiClient
    {
        public async Task<IEnumerable<PecuaristaDTO>> ObterPecuaristas()
        {
            IEnumerable<PecuaristaDTO> pecuaristas = null;
            HttpResponseMessage response = await client.GetAsync($"api/Pecuarista");
            if (response.IsSuccessStatusCode)
            {
                pecuaristas = await response.Content.ReadAsAsync<IEnumerable<PecuaristaDTO>>();
            }
            return pecuaristas;
        }
    }
}
