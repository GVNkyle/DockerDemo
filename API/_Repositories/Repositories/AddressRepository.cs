
using API._Repositories.Interface;
using API.Data;
using API.Models;

namespace API._Repositories.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(DataContext context) : base(context)
        {
        }
    }
}