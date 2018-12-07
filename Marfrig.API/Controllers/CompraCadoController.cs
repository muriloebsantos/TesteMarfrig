using Marfrig.Application.DTOs.ComprasGado;
using Marfrig.Application.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Marfrig.API.Controllers
{
    public class CompraCadoController : ApiController
    {
        private readonly ICompraGadoAppService compraGadoAppService;

        public CompraCadoController(ICompraGadoAppService compraGadoAppService)
        {
            this.compraGadoAppService = compraGadoAppService;
        }

        public async Task<IHttpActionResult> Post(CompraGadoInputDTO compraGadoDTO)
        {
            try
            {
                var idCompraGado = await compraGadoAppService.CriarNovaCompraDeGado(compraGadoDTO);
                return Ok(idCompraGado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
