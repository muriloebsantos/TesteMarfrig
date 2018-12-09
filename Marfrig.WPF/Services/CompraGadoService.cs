using Marfrig.Application.DTOs;
using Marfrig.Application.DTOs.ComprasGado;
using Marfrig.WPF.ViewModels;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Marfrig.WPF.Services
{
    public class CompraGadoService : ApiClient
    {
        public async Task<PagedResultDTO<CompraGadoConsultaDTO>> ObterComprasGado(CompraGadoConsultaViewModel viewModel)
        {
            PagedResultDTO<CompraGadoConsultaDTO> compras = null;
            HttpResponseMessage response = await client.GetAsync($"api/CompraGado?" +
                                                                $"pagina={viewModel.PaginaAtual}" +
                                                                $"&registrosPorPagina=10" +
                                                                $"&compraGadoId={viewModel.Id ?? 0}" +
                                                                $"&pecuaristaId={viewModel.PecuaristaId ?? 0}" +
                                                                $"&dataInicialCompra={viewModel.DataInicio?.ToString("yyyy-MM-dd")}" +
                                                                $"&dataFinalCompra={viewModel.DataFim?.ToString("yyyy-MM-dd")}");
            if (response.IsSuccessStatusCode)
            {
                compras = await response.Content.ReadAsAsync<PagedResultDTO<CompraGadoConsultaDTO>>();
            }
            return compras;
        }

        public async Task<bool> ExcluirCompra(int id)
        {
            bool excluiu = false;
            var response = await client.DeleteAsync($"api/CompraGado/{id}");

            if (response.IsSuccessStatusCode)
                excluiu = true;

            return excluiu;
        }

        public async Task<CompraGadoInputDTO> CadastrarCompra(CompraGadoInputDTO inputDTO)
        {
            CompraGadoInputDTO dtoSalvo = null;
            HttpResponseMessage response = await client.PostAsJsonAsync("api/CompraGado", inputDTO);

            if (response.IsSuccessStatusCode)
            {
                dtoSalvo = await response.Content.ReadAsAsync<CompraGadoInputDTO>();
            }
            else
            {
                throw new ApplicationException(response.Content.ReadAsStringAsync().Result);
            }

            return dtoSalvo;
        }

        public async Task<CompraGadoInputDTO> AtualizarCompra(CompraGadoInputDTO inputDTO)
        {
            CompraGadoInputDTO dtoSalvo = null;
            HttpResponseMessage response = await client.PutAsJsonAsync("api/CompraGado", inputDTO);

            if (response.IsSuccessStatusCode)
            {
                dtoSalvo = await response.Content.ReadAsAsync<CompraGadoInputDTO>();
            }
            else
            {
                throw new ApplicationException(response.Content.ReadAsStringAsync().Result);
            }

            return dtoSalvo;
        }


        public async Task<CompraGadoInputDTO> ObterCompra(int id)
        {
            CompraGadoInputDTO compraGado = null;
            HttpResponseMessage response = await client.GetAsync($"api/CompraGado/{id}");

            if (response.IsSuccessStatusCode)
            {
                compraGado = await response.Content.ReadAsAsync<CompraGadoInputDTO>();
            }
           
            return compraGado;
        }
    }
}
