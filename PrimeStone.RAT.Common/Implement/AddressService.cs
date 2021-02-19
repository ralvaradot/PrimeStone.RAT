using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PrimeStone.RAT.Common.Interface;
using PrimeStone.RAT.DAL;
using PrimeStone.RAT.Dtos;
using PrimeStone.RAT.Entities;
using System;
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
            try
            {

                context.Database.ExecuteSqlRaw("exec Add_Addresses  @AddressId, @Calle,@Carrera, @Numero,@Adicional,@AddressActive,@CreateAt ,@UserCreated",
                      new SqlParameter("@AddressId", entity.AddressId),
                      new SqlParameter("@Carrera", entity.Carrera),
                      new SqlParameter("@Numero", entity.Numero),
                      new SqlParameter("@Adicional", entity.Adicional),
                      new SqlParameter("@AddressActive", entity.AddressActive),
                      new SqlParameter("@CreateAt", entity.CreateAt),
                      new SqlParameter("@UserCreated", entity.UserCreated)
                  );
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public int DeleteAddress(int addressId)
        {
            try
            {
                context.Database.ExecuteSqlRaw("exec delete_Address @AddressId", new SqlParameter("@AddressId", addressId));
                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
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
            var lista = _mapper.Map<List<AddressDto>>(await context.Database.ExecuteSqlRawAsync("execute dbo.List_Addresses"));
            return lista;
        }

        public int UpdateAddress(AddressDto address, string user)
        {
            var entity = _mapper.Map<Address>(address);
            int response = 0;
            context.Database.ExecuteSqlRaw("exec Update_Addresses @AddressId, @Calle,@Carrera, @Numero,@Adicional,@AddressActive,@UpadtedAt ,@UserLastUpdated",
                new SqlParameter("@AddressId", entity.AddressId),
                new SqlParameter("@Carrera", entity.Carrera),
                new SqlParameter("@Numero", entity.Numero),
                new SqlParameter("@Adicional", entity.Adicional),
                new SqlParameter("@AddressActive", entity.AddressActive),
                new SqlParameter("@UpadtedAt", entity.UpadtedAt),
                new SqlParameter("@UserLastUpdated", entity.UserLastUpdated)
            );
            response = 1;
            return response;
        }
    }
}
