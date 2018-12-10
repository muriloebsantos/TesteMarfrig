using Marfrig.Application.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace Marfrig.API.Controllers
{
    [Authorize]
    public class RelatorioCompraController : ApiController
    {
        private readonly ICompraGadoAppService compraGadoAppService;
        public RelatorioCompraController(ICompraGadoAppService compraGadoAppService)
        {
            this.compraGadoAppService = compraGadoAppService;
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            var relatorioCompra = await compraGadoAppService.RelatorioCompra(id);

            return Ok(relatorioCompra);
        }
    }
}
