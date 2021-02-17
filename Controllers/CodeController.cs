
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
    public class CodeController : ControllerBase
    {
        private ICodeService _service;

        public CodeController(ICodeService service)
        {
            _service = service;
        }

        # region api v1.0

        [HttpPost("api/v1.0/code")]
        [Produces("application/json")]
        public async Task<IActionResult> CreateCode([FromBody]CodeDto codeDto)
        {
            try
            {
                Code createdCode = await this._service.Create(codeDto);
                string message = "Code is created.";
                return StatusCode(200, new SucceedResponse<Code>(createdCode, message));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }

        
        [HttpGet("api/v1.0/codes")]
        [Produces("application/json")]
        public async Task<IActionResult> FindAllCodes()
        {
            IEnumerable<Code> allCodes = await this._service.FindAll();
            string message = String.Format("Find {0} records.", allCodes.Count());
            return StatusCode(200, new SucceedResponse<IEnumerable<Code>>(
                allCodes, message));
        }


        [HttpGet("api/v1.0/code/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> FindCode([FromRoute]string id)
        {
            try
            {
                Code findCode = await this._service.FindById(id);
                string message = String.Format("Find code id {0}.", id);
                return StatusCode(200, new SucceedResponse<Code>(findCode, message));
            }
            catch(ServiceError error)
            {
                return StatusCode(400, new ErrorResponse(error.Message));
            }
        }


        [HttpPut("api/v1.0/code/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateCodeBy([FromRoute]string id,
            [FromBody]CodeDto codeDto)
        {
            try
            {
                Code updatedCode = await this._service.UpdateById(id, codeDto);
                string message = String.Format("Update code id {0}.", id);
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