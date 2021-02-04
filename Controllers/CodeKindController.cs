
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using APXBackend.Controllers.Response;
using APX.Models;
using APX.Models.Dto;
using APX.Services;
using APX.Services.Exceptions;

namespace APXBackend.Controllers
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

        [HttpPost("api/v1.0/codeKind")]
        [Produces("application/json")]
        public async Task<IActionResult> CreateCodeKind([FromBody] CodeKindDto dto)
        {
            try
            {
                CodeKind createdKind = await this._service.Create(dto);
                string message = "CodeKind is created.";
                return StatusCode(200, new SucceedResponse(message, createdKind));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }

        [HttpGet("api/v1.0/codeKinds")]
        [Produces("application/json")]
        public async Task<IActionResult> FindAllCodeKinds()
        {
            IEnumerable<CodeKind> allKinds = await this._service.FindAll();
            string message = String.Format("Find {0} records.", allKinds.Count());
            return StatusCode(200, new SucceedResponse(message, allKinds));
        }

        [HttpGet("api/v1.0/codeKind/{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> FindCodeKind([FromRoute]string name)
        {
            try
            {
                CodeKind findKind = await this._service.FindByName(name);
                string message = String.Format("Find codeKind name {0}.", name);
                return StatusCode(200, new SucceedResponse(message, findKind));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }


        [HttpPut("api/v1.0/codeKind/{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateCodeKind([FromRoute]string name,
            [FromBody]CodeKindDto dto)
        {
            try
            {
                CodeKind updatedKind = await this._service.UpdateByName(name, dto);
                string message = String.Format("Update codeKind name {0}.", name);
                return StatusCode(200, new SucceedResponse(message, updatedKind));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }

        #endregion
    }
}