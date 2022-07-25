using API.DTO;
using API.Helpers.Utilities;

namespace API._Services.Interface
{
    public interface IAddressService
    {
        Task<PaginationUtility<AddressDTO>> SearchData(PaginationParam pagination);
        Task<OperationResult> AddNewAddress(AddressDTO address);
        Task<OperationResult> UpdateAddress(AddressDTO address);
        Task<OperationResult> DeleteAddress(int addressID);
    }
}