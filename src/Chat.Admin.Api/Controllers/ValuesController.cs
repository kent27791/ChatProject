using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AutoMapper;

using Chat.Service.LogManagement;
using Chat.Core.Domain.LogManagement;

namespace Chat.Admin.Api.Controllers
{
    [Route("api/values")]
    public class ValuesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ValuesController> _logger;
        public readonly ISystemLogService _systemLogService;

        public ValuesController(IMapper mapper, ILogger<ValuesController> logger, ISystemLogService systemLogService)
        {
            this._mapper = mapper;
            this._logger = logger;
            this._systemLogService = systemLogService;
        }

        [HttpGet]
        [Route("get-all")]
        public IEnumerable<SystemLog> GetAll()
        {
            return _systemLogService.FindAll();
        }

        [HttpPost]
        [Route("post")]
        public IActionResult Post([FromBody] SystemLog log)
        {
            return Ok();
        }
    }
}
