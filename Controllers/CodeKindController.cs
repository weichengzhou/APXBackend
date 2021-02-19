
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
    public class CodeKindController : ControllerBase
    {
        private ICodeKindService _service;

        public CodeKindController(ICodeKindService service)
        {
            _service = service;
        }

        # region api v1.0

        /// <response code="201">Created CodeKind returns.</response>
        /// <response code="400">
        /// CodeKind cannot create because
        /// - Inputs is not validated.
        /// - Name of CodeKind is exist.
        /// </response>
        [HttpPost("api/v1.0/codekind")]
        [Produces("application/json")]
        [SwaggerRequestExample(typeof(CodeKindDto), typeof(CreateCodeKindRequestExample))]
        [SwaggerResponse(201, Type=typeof(SucceedResponse<CodeKind>))]
        [SwaggerResponseExample(201, typeof(CreateCodeKindResponseExample))]
        [SwaggerResponse(400, Type=typeof(ErrorResponse))]
        [SwaggerResponseExample(400, typeof(ErrorResponseExample))]
        public async Task<IActionResult> CreateCodeKind([FromBody] CodeKindDto dto)
        {
            try
            {
                CodeKind createdKind = await this._service.Create(dto);
                string message = "CodeKind is created.";
                return StatusCode(201, new SucceedResponse<CodeKind>(createdKind, message));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }


        /// <response code="200">Get list of CodeKinds.</response>
        [HttpGet("api/v1.0/codekinds")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type=typeof(SucceedResponse<IEnumerable<CodeKind>>))]
        [SwaggerResponseExample(200, typeof(GetCodeKindsResponseExample))]
        public async Task<IActionResult> FindAllCodeKinds()
        {
            IEnumerable<CodeKind> allKinds = await this._service.FindAll();
            string message = String.Format("Find {0} records.", allKinds.Count());
            return StatusCode(200, new SucceedResponse<IEnumerable<CodeKind>>(
                allKinds, message));
        }


        /// <response code="200">Get a specific CodeKind by Name.</response>
        /// <response code="400">CodeKind is not exist.</response>
        [HttpGet("api/v1.0/codekind/{name}")]
        [Produces("application/json")]
        [SwaggerResponse(200, Type=typeof(SucceedResponse<CodeKind>))]
        [SwaggerResponseExample(200, typeof(GetCodeKindResponseExample))]
        [SwaggerResponse(400, Type=typeof(ErrorResponse))]
        [SwaggerResponseExample(400, typeof(ErrorResponseExample))]
        public async Task<IActionResult> FindCodeKind([FromRoute]string name)
        {
            try
            {
                CodeKind findKind = await this._service.FindByName(name);
                string message = String.Format("Find CodeKind Name {0}.", name);
                return StatusCode(200, new SucceedResponse<CodeKind>(findKind, message));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }


        /// <response code="200">Update a specific CodeKind returns.</response>
        /// <response code="400">
        /// CodeKind cannot update because
        /// - Inputs is not validated.
        /// - Name of CodeKind is not exist.
        /// </response>
        [HttpPut("api/v1.0/codekind/{name}")]
        [Produces("application/json")]
        [SwaggerRequestExample(typeof(CodeKindDto), typeof(UpdateCodeKindRequestExample))]
        [SwaggerResponse(200, Type=typeof(SucceedResponse<CodeKind>))]
        [SwaggerResponseExample(200, typeof(UpdateCodeKindResponseExample))]
        [SwaggerResponse(400, Type=typeof(ErrorResponse))]
        [SwaggerResponseExample(400, typeof(ErrorResponseExample))]
        public async Task<IActionResult> UpdateCodeKind([FromRoute]string name,
            [FromBody]CodeKindDto dto)
        {
            try
            {
                CodeKind updatedKind = await this._service.UpdateByName(name, dto);
                string message = String.Format("Update CodeKind Name {0}.", name);
                return StatusCode(200, new SucceedResponse<CodeKind>(updatedKind, message));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }

        #endregion
    }
}