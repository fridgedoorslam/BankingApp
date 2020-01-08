using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace BankingApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>();

            CreateMap<AccountForCreationDto, Account>();
        }
    }
}
