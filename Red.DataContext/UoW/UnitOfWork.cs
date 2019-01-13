using Red.Domain.Interfaces;
using Red.Infra.Data.Context;

namespace Red.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RedContext _context;

        public UnitOfWork(RedContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
