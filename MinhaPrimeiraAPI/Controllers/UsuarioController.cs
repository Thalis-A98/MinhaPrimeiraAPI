using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraAPI.Models;
using MinhaPrimeiraAPI.Repository.Interfaces;

namespace MinhaPrimeiraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;
        public UsuarioController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuariosRepository.BuscarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarUsuarioId(int id)
        {
            UsuarioModel usuario = await _usuariosRepository.BuscarUsuarioId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> AddUsuario([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuariosRepository.AddUsuario(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> AttUsuario([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id= id;
            UsuarioModel usuario = await _usuariosRepository.AttUsuario(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> DelUsuario(int id)
        {
            bool apagado = await _usuariosRepository.DelUsuario(id);
            return Ok(apagado);
        }
    }
}
