using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ShareController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetShareByUniqueId")]
        public IActionResult GetShareByUniqueId(Guid id)
        {
            try
            {
                var share = _repository.Share.GetShareByUniqueId(id);

                if (share == null)
                {
                    return NotFound();
                }
                else
                {
                    var shareResult = _mapper.Map<ShareDto>(share);
                    return Ok(shareResult);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateShare([FromBody]ShareForCreationDto share)
        {
            try
            {
                if (share == null)
                {
                    return BadRequest("Share object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var shareEntity = _mapper.Map<Share>(share);

                var account = _repository.Account.GetAccountById(shareEntity.AccountId);
                if (account == null)
                {
                    return BadRequest("Specified account number does not exist");
                }

                _repository.Share.CreateShare(shareEntity);
                _repository.Save();

                var createdShare = _mapper.Map<ShareDto>(shareEntity);

                return CreatedAtRoute("GetAccountById", new { id = createdShare.AccountId }, createdShare);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}