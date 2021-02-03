
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using APXBackend.Controllers.Response;
using APX.Services;
using APX.Services.Parameter;
using APX.Services.Exceptions;
using APX.Models;

namespace APXBackend.Controllers
{
    [ApiController]
    public class TokenController : ControllerBase
    {
        private ITokenService _service;

        public TokenController(ITokenService service)
        {
            _service = service;
        }


        #region api v1.0

        [HttpPost("api/v1.0/token")]
        [Produces("application/json")]
        public async Task<IActionResult> CreateToken(
            [FromBody]CreatedTokenParameter parameter)
        {
            try
            {
                Token createdToken = await this._service.Create(parameter);
                string message = "Token is created.";
                return StatusCode(200, new SucceedResponse(message, createdToken));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }


        [HttpGet("api/v1.0/tokens")]
        [Produces("application/json")]
        public async Task<IActionResult> FindAllTokens()
        {
            List<Token> allTokens = await this._service.FindAll();
            string message = String.Format("Find {0} records.", allTokens.Count);
            return StatusCode(200, new SucceedResponse(message, allTokens));
        }


        [HttpGet("api/v1.0/token/{seq}")]
        [Produces("application/json")]
        public async Task<IActionResult> FindToken([FromRoute]string seq)
        {
            try
            {
                Token findToken = await this._service.FindBySeq(seq);
                string message = String.Format("Find token seq {0}.", seq);
                return StatusCode(200, new SucceedResponse(message, findToken));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }

        #endregion
    }
}