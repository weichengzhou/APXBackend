
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using APX.Controllers.Response;
using APX.Models;
using APX.Models.Dto;
using APX.Services;
using APX.Services.Exceptions;

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

        [HttpPost("api/v1.0/codekind")]
        [Produces("application/json")]
        public async Task<IActionResult> CreateCodeKind([FromBody] CodeKindDto dto)
        {
            try
            {
                CodeKind createdKind = await this._service.Create(dto);
                string message = "CodeKind is created.";
                return StatusCode(200, new SucceedResponse<CodeKind>(createdKind, message));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }

        [HttpGet("api/v1.0/codekinds")]
        [Produces("application/json")]
        public async Task<IActionResult> FindAllCodeKinds()
        {
            IEnumerable<CodeKind> allKinds = await this._service.FindAll();
            string message = String.Format("Find {0} records.", allKinds.Count());
            return StatusCode(200, new SucceedResponse<IEnumerable<CodeKind>>(
                allKinds, message));
        }

        [HttpGet("api/v1.0/codekind/{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> FindCodeKind([FromRoute]string name)
        {
            try
            {
                CodeKind findKind = await this._service.FindByName(name);
                string message = String.Format("Find codeKind name {0}.", name);
                return StatusCode(200, new SucceedResponse<CodeKind>(findKind, message));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }


        [HttpPut("api/v1.0/codekind/{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateCodeKind([FromRoute]string name,
            [FromBody]CodeKindDto dto)
        {
            try
            {
                CodeKind updatedKind = await this._service.UpdateByName(name, dto);
                string message = String.Format("Update codeKind name {0}.", name);
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