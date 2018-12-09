using Marfrig.Application.DTOs.ComprasGado;
using Marfrig.Application.Exceptions;
using Marfrig.Application.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Marfrig.API.Controllers
{
    public class CompraGadoController : ApiController
    {
        private readonly ICompraGadoAppService compraGadoAppService;

        public CompraGadoController(ICompraGadoAppService compraGadoAppService)
        {
            this.compraGadoAppService = compraGadoAppService;
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var compraGadoDTO = await compraGadoAppService.ObterPorId(id);
            if (compraGadoDTO == null)
                return NotFound();

            return Ok(compraGadoDTO);
        }


        public async Task<IHttpActionResult> Get(int pagina, int registrosPorPagina, int compraGadoId, int pecuaristaId, DateTime? dataInicialCompra, DateTime? dataFinalCompra)
        {
            var comprasGados = await compraGadoAppService.Buscar(
                                 pagina,
                                 registrosPorPagina,
                                 compraGadoId,
                                 pecuaristaId,
                                 dataInicialCompra,
                                 dataFinalCompra);

            return Ok(comprasGados);
        }

        public async Task<IHttpActionResult> Post(CompraGadoInputDTO compraGadoDTO)
        {
            try
            {
                var idCompraGado = await compraGadoAppService.CriarNovaCompraDeGado(compraGadoDTO);
                var compraGadoCriada = await compraGadoAppService.ObterPorId(idCompraGado);
                return Content(HttpStatusCode.Created, compraGadoCriada);
            }
            catch (NotFoundException ex)
            {
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IHttpActionResult> Put(CompraGadoInputDTO compraGadoDTO)
        {
            try
            {
                var idCompraGado = await compraGadoAppService.AtualizarCompraDeGado(compraGadoDTO);
                var compraGadoAtualizada = await compraGadoAppService.ObterPorId(idCompraGado);
                return Content(HttpStatusCode.OK, compraGadoAtualizada);
            }
            catch (NotFoundException ex)
            {
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                var excluido = await compraGadoAppService.Excluir(id);
                if (excluido)
                    return Ok();
                else
                    return Content(HttpStatusCode.MethodNotAllowed, "Exclusão não realizada");
            }
            catch (NotFoundException ex)
            {
                return Content(HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
