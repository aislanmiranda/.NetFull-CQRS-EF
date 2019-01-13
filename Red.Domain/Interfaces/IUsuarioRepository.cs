using Red.Domain.Models;

namespace Red.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario GetByEmail(string email);
    }
}