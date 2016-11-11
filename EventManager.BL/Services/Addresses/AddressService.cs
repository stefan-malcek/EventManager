using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EventManager.BL.DTOs;
using EventManager.BL.DTOs.Addresses;
using EventManager.BL.DTOs.Filters;
using EventManager.BL.Queries;
using EventManager.BL.Repositories;
using EventManager.DAL.Entities;

namespace EventManager.BL.Services.Addresses
{
    public class AddressService : EventManagerService, IAddressService
    {
        private readonly AddressRepository _addressRepository;
        private readonly AddressListQuery _addressListQuery;

        public AddressService(AddressRepository addressRepository, AddressListQuery addressListQuery)
        {
            _addressListQuery = addressListQuery;
            _addressRepository = addressRepository;
        }

        public void CreateAddress(AddressCreateDTO addressDto)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var address = Mapper.Map<Address>(addressDto);
                _addressRepository.Insert(address);
                uow.Commit();
            }
        }

        public void UpdateAddress(AddressDTO addressDto)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                var address = _addressRepository.GetById(addressDto.Id);
                Mapper.Map(addressDto, address);
                _addressRepository.Update(address);
                uow.Commit();
            }
        }

        public void DeleteAddress(int addressId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                _addressRepository.Delete(addressId);
                uow.Commit();
            }
        }

        public AddressDTO GetAddress(int addressId)
        {
            using (UnitOfWorkProvider.Create())
            {
                var address = _addressRepository.GetById(addressId);
                return address == null ? null : Mapper.Map<AddressDTO>(address);
            }
        }

        public IEnumerable<AddressDTO> ListAddresses(AddressFilter filter)
        {
            using (UnitOfWorkProvider.Create())
            {
                _addressListQuery.Filter = filter;
                return _addressListQuery.Execute() ?? new List<AddressDTO>();
            }
        }
    }
}
