using System;
using Microsoft.AspNetCore.Mvc;
using MS.ACTIONS;
using MS.MODELS;
using MS.REPO;

namespace MS.DATA.GUTTERAPI.Controllers
{
	public class CREATE_CONTROLLER : ControllerBase
    {
        private readonly ILogger<CREATE_CONTROLLER> _logger;
        private readonly Idbcreate repo;
        private readonly Imsactions actions;

        public CREATE_CONTROLLER(ILogger<CREATE_CONTROLLER> logger, Idbcreate db, Imsactions ac)
        {
            _logger = logger;
            repo = db;
            actions = ac;
        }

        [HttpPost("create-store")]
        public async Task<ActionResult<bool>> CREATE_STORE( [FromBody] CreateShowDTO dto)
        {
            bool CHECK = false;
            if(ModelState.IsValid)
            {
                CHECK = await this.repo.CREATE_STORE(dto.personID, dto.storename, dto.image, dto.privacyLevel);
                return Created( "mystore/", CHECK);
            }
            return BadRequest(CHECK);
        }

        [HttpPost("create-product")]
        public async Task<ActionResult<bool>> CREATE_PRODUCT([FromBody] CreateProductDTO dto)
        {
            bool CHECK = false;
            if (ModelState.IsValid)
            {

                CHECK = await this.repo.CREATE_PRODUCT(dto.storeID, dto.type, dto.category, dto.name, dto.price, dto.description, dto.status);
                return Created("myproduct/", CHECK);
            }
            return BadRequest(CHECK);
        }
    }
}

