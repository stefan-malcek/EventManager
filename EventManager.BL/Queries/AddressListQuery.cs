using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using EventManager.BL.AppEfConfiguration;
using EventManager.BL.DTOs;
using EventManager.BL.DTOs.Addresses;
using EventManager.BL.DTOs.Filters;
using EventManager.DAL.Entities;
using Riganti.Utils.Infrastructure.Core;

namespace EventManager.BL.Queries
{
    public class AddressListQuery : AppQuery<AddressDTO>
    {
        public AddressFilter Filter { get; set; }

        public AddressListQuery(IUnitOfWorkProvider provider) : base(provider) { }

        protected override IQueryable<AddressDTO> GetQueryable()
        {
            IQueryable<Address> query = Context.Addresses;

            if (!string.IsNullOrEmpty(Filter?.City))
            {
                query = query.Where(w => w.City.ToLower().Contains(Filter.City.ToLower()));
            }

            return query.ProjectTo<AddressDTO>();
        }
    }
}
