using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetAccountById")]
        public IActionResult GetAccountById(int id)
        {
            try
            {
                var account = _repository.Account.GetAccountById(id);

                if (account == null)
                {
                    return NotFound();
                }
                else
                {
                    var accountResult = _mapper.Map<AccountDto>(account);
                    return Ok(accountResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateAccount([FromBody]AccountForCreationDto account)
        {
            try
            {
                if (account == null)
                {
                    return BadRequest("Account object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var accountEntity = _mapper.Map<Account>(account);

                _repository.Account.CreateAccount(accountEntity);
                _repository.Save();

                var createdAccount = _mapper.Map<AccountDto>(accountEntity);

                return CreatedAtRoute("GetAccountById", new { id = createdAccount.AccountId }, createdAccount);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}