using MinhaPrimeiraAPI.Models;

namespace MinhaPrimeiraAPI.Repository.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<List<UsuarioModel>> BuscarUsuarios();
        Task<UsuarioModel> BuscarUsuarioId(int id);
        Task<UsuarioModel> AddUsuario( UsuarioModel usuario);
        Task<UsuarioModel> AttUsuario(UsuarioModel usuario, int id);
        Task<bool> DelUsuario(int id);
    }
}
