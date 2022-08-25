using AgileObjects.AgileMapper;
using API._Repositories.Interface;
using API._Services.Interface;
using API.DTO;
using API.Helpers.Utilities;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API._Services.Services
{
    public class AddressService : IAddressService
    {
        private readonly IRepositoryAccessor _repositoryAccessor;

        public AddressService(IRepositoryAccessor repositoryAccessor)
        {
            _repositoryAccessor = repositoryAccessor;
        }

        public async Task<OperationResult> AddNewAddress(AddressDTO address)
        {
            var model = Mapper.Map(address).ToANew<Address>();
            _repositoryAccessor.AddressRepository.Add(model);
            if (await _repositoryAccessor.Save())
                return new OperationResult(true, "Success");

            return new OperationResult(false, "Failed");
        }

        public async Task<OperationResult> DeleteAddress(int addressID)
        {
            var model = await _repositoryAccessor.AddressRepository.FindSingle(x => x.AddressID == addressID);
            _repositoryAccessor.AddressRepository.Remove(model);
            if (await _repositoryAccessor.Save())
                return new OperationResult(true, "Success");

            return new OperationResult(false, "Failed");
        }

        public async Task<PaginationUtility<AddressDTO>> SearchData(PaginationParam pagination)
        {
            var data = await _repositoryAccessor.AddressRepository.FindAll().OrderByDescending(x => x.ModifiedDate).Project().To<AddressDTO>().AsNoTracking().ToListAsync();
            return PaginationUtility<AddressDTO>.Create(data, pagination.PageNumber, pagination.PageSize, false);
        }

        public async Task<OperationResult> UpdateAddress(AddressDTO address)
        {
            var model = await _repositoryAccessor.AddressRepository.FindSingle(x => x.AddressID == address.AddressID);
            model.AddressLine1 = address.AddressLine1;
            model.City = address.City;
            model.CountryRegion = address.CountryRegion;
            model.PostalCode = address.PostalCode;
            model.StateProvince = address.StateProvince;
            _repositoryAccessor.AddressRepository.Update(model);
            if (await _repositoryAccessor.Save())
                return new OperationResult(true, "Success");

            return new OperationResult(false, "Failed");
        }
    }
}