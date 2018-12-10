using Marfrig.Application.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace Marfrig.API.Controllers
{
    [Authorize]
    public class PecuaristaController : ApiController
    {
        private readonly IPecuaristaAppService pecuaristaAppService;

        public PecuaristaController(IPecuaristaAppService pecuaristaAppService)
        {
            this.pecuaristaAppService = pecuaristaAppService;
        }


        public async Task<IHttpActionResult> Get()
        {
            var pecuaristas = await pecuaristaAppService.ObterPecuaristas();
            return Ok(pecuaristas);
        }
    }
}