using System.Linq;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AutoMapper;

using Chat.Service.SecurityManagement;
using Chat.Admin.Api.ViewModels;
using Chat.Core.Domain.SecurityManagement;
using Chat.Core.Data;
using Chat.Data.DatabaseContext;
using Chat.Common.Datatable;
using Microsoft.AspNetCore.Cors;


namespace Chat.Admin.Api.Controllers
{
    [Route("api/group-member")]
    public class GroupMemberController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GroupMemberController> _logger;
        private readonly IUnitOfWork<SecurityManagementContext> _unitOfWork;
        private  readonly IGroupMemberService _groupMemberService;
        public GroupMemberController(
            IMapper mapper, 
            ILogger<GroupMemberController> logger, 
            IUnitOfWork<SecurityManagementContext> unitOfWork, 
            IGroupMemberService groupMemberService)
        {
            this._mapper = mapper;
            this._logger = logger;
            this._unitOfWork = unitOfWork;
            this._groupMemberService = groupMemberService;
        }

        [HttpPost]
        [Route("datatable")]
        [EnableCors("CrossClient")]
        public IActionResult DataTable([FromBody] DataTableRequest request)
        {
            var data = _groupMemberService.FindAll().ToList();
            request.Count = data.Count();

            DataTableResponse<GroupMember> result = new DataTableResponse<GroupMember>();
            result.Data = data;
            result.Page = request;

            return Ok(result);
        }

        [HttpGet]
        [Route("find/{id}")]
        public IActionResult Find(int id)
        {
            var a = _groupMemberService.StoreFindAll();
            var b = _groupMemberService.StoreFind(1);
            return Ok();
            //return Ok(_groupMemberService.Find(id));
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create([FromBody] GroupMemberViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                GroupMember groupMember = _mapper.Map<GroupMemberViewModel, GroupMember>(viewModel);
                _groupMemberService.Add(groupMember);
                _unitOfWork.Commit();
                return CreatedAtRoute("find", new { id = groupMember.Id }, groupMember);
            }
            catch
            {
                return StatusCode(500);
            }
            
        }

        [HttpPut]
        [Route("edit/{id}")]
        public IActionResult Update(int id, [FromBody] GroupMemberViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != viewModel.Id)
            {
                return BadRequest();
            }
            try
            {
                var orginalGroupMember = _groupMemberService.Find(id);
                if(orginalGroupMember == null)
                {
                    return NotFound();
                }
                orginalGroupMember = _mapper.Map(viewModel, orginalGroupMember);
                _groupMemberService.Update(orginalGroupMember);
                _unitOfWork.Commit();
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }

        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var originalGroupMember = _groupMemberService.Find(id);
                if(originalGroupMember == null)
                {
                    return NotFound();
                }
                _groupMemberService.Delete(originalGroupMember);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}