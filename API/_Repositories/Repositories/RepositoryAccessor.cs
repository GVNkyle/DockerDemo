
using API._Repositories.Interface;
using API.Data;

namespace API._Repositories.Repositories
{
    public class RepositoryAccessor : IRepositoryAccessor
    {
        private readonly DataContext _context;

        public RepositoryAccessor(DataContext context)
        {
            _context = context;

            AddressRepository = new AddressRepository(_context);
        }

        public IAddressRepository AddressRepository { get; private set; }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}