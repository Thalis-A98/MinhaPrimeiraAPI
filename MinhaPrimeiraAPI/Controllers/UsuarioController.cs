using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraAPI.Models;

namespace MinhaPrimeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UsuarioModel>> BuscarUsuarios()
        {
            return Ok();
        }
    }
}
