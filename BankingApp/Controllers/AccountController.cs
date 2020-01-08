using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public AccountController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            try
            {
                var accounts = _repository.Account.GetAllAccounts();
                var ownersResult = _mapper.Map<IEnumerable<AccountDto>>(accounts);
                return Ok(ownersResult);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}