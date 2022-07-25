namespace API._Repositories.Interface
{
    public interface IRepositoryAccessor
    {
        IAddressRepository AddressRepository { get; }
        Task<bool> Save();
    }
}