
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

using APX.Controllers.Response;
using APX.Models;
using APX.Models.Dto;
using APX.Services;
using APX.Services.Exceptions;
using APX.Swagger.Example;

namespace APX.Controllers
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

        /// <response code="201">Created Token returns.</response>
        /// <response code="400">Inputs is not validated.</response>
        [HttpPost("api/v1.0/token")]
        [Produces("application/json")]
        [SwaggerRequestExample(typeof(TokenDto), typeof(CreateTokenRequestExample))]
        [SwaggerResponse(201, Type=typeof(SucceedResponse<Token>))]
        [SwaggerResponseExample(201, typeof(CreateTokenResponseExample))]
        [SwaggerResponse(400, Type=typeof(ErrorResponse))]
        [SwaggerResponseExample(400, typeof(ErrorResponseExample))]
        public async Task<IActionResult> CreateToken([FromBody]TokenDto tokenDto)
        {
            try
            {
                Token createdToken = await this._service.Create(tokenDto);
                string message = "Token is created.";
                return StatusCode(201, new SucceedResponse<Token>(createdToken, message));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }


        /// <response code="200">Get list of Tokens.</response>
        [HttpGet("api/v1.0/tokens")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type=typeof(SucceedResponse<IEnumerable<Token>>))]
        [SwaggerResponseExample(200, typeof(GetTokensResponseExample))]
        public async Task<IActionResult> FindAllTokens()
        {
            IEnumerable<Token> allTokens = await this._service.FindAll();
            string message = String.Format("Find {0} records.", allTokens.Count());
            return StatusCode(200, new SucceedResponse<IEnumerable<Token>>(
                allTokens, message));
        }


        /// <response code="200">Get a specific Token by SEQ.</response>
        /// <response code="400">Token is not exist.</response>
        [HttpGet("api/v1.0/token/{seq}")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type=typeof(SucceedResponse<Token>))]
        [SwaggerResponseExample(200, typeof(GetTokenResponseExample))]
        [SwaggerResponse(400, Type=typeof(ErrorResponse))]
        [SwaggerResponseExample(400, typeof(ErrorResponseExample))]
        public async Task<IActionResult> FindToken([FromRoute]string seq)
        {
            try
            {
                Token findToken = await this._service.FindBySeq(seq);
                string message = String.Format("Find Token SEQ {0}.", seq);
                return StatusCode(200, new SucceedResponse<Token>(findToken, message));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }

        #endregion
    }
}