using Microsoft.EntityFrameworkCore;
using MinhaPrimeiraAPI.Data;
using MinhaPrimeiraAPI.Models;
using MinhaPrimeiraAPI.Repository.Interfaces;

namespace MinhaPrimeiraAPI.Repository
{
    public class UsuarioRepository : IUsuariosRepository
    {
        private readonly SistemadeCadastroDBContext _sistemadeCadastroDBContext;
        public UsuarioRepository(SistemadeCadastroDBContext sistemadeCadastroDBContext)
        {
            _sistemadeCadastroDBContext = sistemadeCadastroDBContext;
        }
        public async Task<List<UsuarioModel>> BuscarUsuarios()
        {
            return await _sistemadeCadastroDBContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> BuscarUsuarioId(int id)
        {
            return await _sistemadeCadastroDBContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<UsuarioModel> AddUsuario(UsuarioModel usuario)
        {
            await _sistemadeCadastroDBContext.AddAsync(usuario);
            await _sistemadeCadastroDBContext.SaveChangesAsync();

            return usuario;

        }
        public async Task<UsuarioModel> AttUsuario(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioId = await BuscarUsuarioId(id);
            
            if (usuarioId == null) 
            {
                throw new Exception($"Usuário para o ID: {id} não encontrado na Base de Dados.");
            }

            usuarioId.Nome = usuario.Nome;
            usuarioId.Email = usuario.Email;

            _sistemadeCadastroDBContext.Update(usuarioId);
            await _sistemadeCadastroDBContext.SaveChangesAsync();

            return usuarioId;
        }

        public async Task<bool> DelUsuario(int id)
        {
            UsuarioModel usuarioId = await BuscarUsuarioId(id);

            if (usuarioId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não encontrado na Base de Dados.");
            }

            _sistemadeCadastroDBContext.Remove(usuarioId);
            await _sistemadeCadastroDBContext.SaveChangesAsync();

            return true;

        }

    }
}
