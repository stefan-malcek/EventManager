using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.BL.DTOs;
using EventManager.BL.DTOs.Filters;

namespace EventManager.BL.Services.Addresses
{
    public interface IAddressService
    {
        void CreateAddress(AddressDTO addressDto);

        void UpdateAddress(AddressDTO addressDto);

        void DeleteAddress(int addressId);

        AddressDTO GetAddress(int addressId);

        IEnumerable<AddressDTO> ListAddresses(AddressFilter filter);
    }
}
