using Marfrig.Application.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace Marfrig.API.Controllers
{
    [Authorize]
    public class AnimalController : ApiController
    {
        private readonly IAnimalAppService animalAppService;

        public AnimalController(IAnimalAppService animalAppService)
        {
            this.animalAppService = animalAppService;
        }
        
        public async Task<IHttpActionResult> Get()
        {
            var animais = await animalAppService.ObterAnimais();
            return Ok(animais);
        }
    }
}