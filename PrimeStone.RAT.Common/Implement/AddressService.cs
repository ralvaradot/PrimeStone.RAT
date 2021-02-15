using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PrimeStone.RAT.Common.Interface;
using PrimeStone.RAT.DAL;
using PrimeStone.RAT.Dtos;
using PrimeStone.RAT.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeStone.RAT.Common.Implement
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        readonly PrimeStoneDbContext context = new PrimeStoneDbContext();

        public AddressService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Address, AddressDto>();
                cfg.CreateMap<AddressDto, Address>();
            });
            _mapper = config.CreateMapper();

        }

        public int AddAddress(AddressDto address, string user)
        {
            var entity = _mapper.Map<Address>(address);

            context.Addresses.Add(entity);
            return context.SaveChanges();
        }

        public int DeleteAddress(int addressId)
        {
            var entity = context.Addresses.Where(c => c.AddressId == addressId).FirstOrDefault();
            if (entity == null)
                return -1;

            context.Addresses.Remove(entity);
            return context.SaveChanges();
        }

        public AddressDto GetAddress(int addressId)
        {
            var address = context.Students.Where(c => c.StudentId == addressId).FirstOrDefault();
            if (address == null)
                return new AddressDto();

            var entity = _mapper.Map<AddressDto>(address);
            return entity;
        }

        public async Task<List<AddressDto>> ListAddresses()
        {
            var lista = _mapper.Map<List<AddressDto>>(await context.Addresses.ToListAsync());
            return lista;
        }

        public int UpdateAddress(AddressDto address, string user)
        {
            var entity = _mapper.Map<Address>(address);
            context.Addresses.Update(entity);
            return context.SaveChanges();
        }
    }
}
