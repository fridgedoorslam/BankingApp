using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IRepositoryWrapper _repository;

        public MemberController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllMembers()
        {
            try
            {
                var members = _repository.Member.GetAllMembers();

                return Ok(members);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}