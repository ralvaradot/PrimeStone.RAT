using PrimeStone.RAT.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrimeStone.RAT.Common.Interface
{
    public interface IAddressService
    {
        Task<List<AddressDto>> ListAddresses();
        AddressDto GetAddress(int addressId);
        int AddAddress(AddressDto address, string user);
        int UpdateAddress(AddressDto address, string user);
        int DeleteAddress(int addressId);
    }
}
