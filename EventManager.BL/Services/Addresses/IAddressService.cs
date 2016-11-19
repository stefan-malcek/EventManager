using System.Collections.Generic;
using EventManager.BL.DTOs.Addresses;
using EventManager.BL.DTOs.Filters;

namespace EventManager.BL.Services.Addresses
{
    public interface IAddressService
    {
        void CreateAddress(AddressCreateDTO addressDto);

        void UpdateAddress(AddressDTO addressDto);

        void DeleteAddress(int addressId);

        AddressDTO GetAddress(int addressId);

        IEnumerable<AddressDTO> ListAddresses(AddressFilter filter);
    }
}
