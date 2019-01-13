using System.Linq;
using Red.Domain.Interfaces;
using Red.Domain.Models;
using Red.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Red.Infra.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(RedContext context)
            : base(context)
        {

        }

        public Usuario GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
