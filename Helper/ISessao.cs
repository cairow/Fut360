using Fut360.Models;

namespace Fut360.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario);
        void RemoverSessaoDoUsuario(UsuarioModel usuario);
        UsuarioModel BuscarSessaoDoUsuario();
    }
}
