
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
    public class CodeController : ControllerBase
    {
        private ICodeService _service;

        public CodeController(ICodeService service)
        {
            _service = service;
        }

        # region api v1.0

        /// <response code="201">Created Code returns.</response>
        /// <response code="400">
        /// Code cannot create because
        /// - Inputs is not validated.
        /// - ID of Code is exist.
        /// - Kind of Code is not exist.
        /// </response>
        [HttpPost("api/v1.0/code")]
        [Produces("application/json")]
        [SwaggerRequestExample(typeof(CodeDto), typeof(CreateCodeRequestExample))]
        [SwaggerResponse(201, Type=typeof(SucceedResponse<Code>))]
        [SwaggerResponseExample(201, typeof(CreateCodeResponseExample))]
        [SwaggerResponse(400, Type=typeof(ErrorResponse))]
        [SwaggerResponseExample(400, typeof(ErrorResponseExample))]
        public async Task<IActionResult> CreateCode([FromBody]CodeDto codeDto)
        {
            try
            {
                Code createdCode = await this._service.Create(codeDto);
                string message = "Code is created.";
                return StatusCode(201, new SucceedResponse<Code>(createdCode, message));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }


        /// <response code="200">Get list of Codes.</response>
        [HttpGet("api/v1.0/codes")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type=typeof(SucceedResponse<IEnumerable<Code>>))]
        [SwaggerResponseExample(200, typeof(GetCodesResponseExample))]
        public async Task<IActionResult> FindAllCodes()
        {
            IEnumerable<Code> allCodes = await this._service.FindAll();
            string message = String.Format("Find {0} records.", allCodes.Count());
            return StatusCode(200, new SucceedResponse<IEnumerable<Code>>(
                allCodes, message));
        }


        /// <response code="200">Get a specific Code by ID.</response>
        /// <response code="400">Code is not exist.</response>
        [HttpGet("api/v1.0/code/{id}")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type=typeof(SucceedResponse<Code>))]
        [SwaggerResponseExample(200, typeof(GetCodeResponseExample))]
        [SwaggerResponse(400, Type=typeof(ErrorResponse))]
        [SwaggerResponseExample(400, typeof(ErrorResponseExample))]
        public async Task<IActionResult> FindCode([FromRoute]string id)
        {
            try
            {
                Code findCode = await this._service.FindByID(id);
                string message = String.Format("Find Code ID {0}.", id);
                return StatusCode(200, new SucceedResponse<Code>(findCode, message));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }


        /// <response code="200">Updated a specific Code returns.</response>
        /// <response code="400">
        /// Code cannot update because
        /// - Inputs is not validated.
        /// - ID of Code is not exist.
        /// - Kind of Code is not exist.
        /// </response>
        [HttpPut("api/v1.0/code/{id}")]
        [Produces("application/json")]
        [SwaggerRequestExample(typeof(CodeDto), typeof(UpdateCodeRequestExample))]
        [SwaggerResponse(200, Type=typeof(SucceedResponse<Code>))]
        [SwaggerResponseExample(200, typeof(UpdateCodeResponseExample))]
        [SwaggerResponse(400, Type=typeof(ErrorResponse))]
        [SwaggerResponseExample(400, typeof(ErrorResponseExample))]
        public async Task<IActionResult> UpdateCodeBy([FromRoute]string id,
            [FromBody]CodeDto codeDto)
        {
            try
            {
                Code updatedCode = await this._service.UpdateByID(id, codeDto);
                string message = String.Format("Update Code ID {0}.", id);
                return StatusCode(200, new SucceedResponse<Code>(updatedCode, message));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }

        #endregion
    }
}