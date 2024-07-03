using Microsoft.AspNetCore.Mvc;
using Pets.Interfaces;
using Pets.Dtos;

namespace Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ILogger<MemberController> _logger;
        private readonly IMember _member;
        public MemberController(ILogger<MemberController> logger, IMember member)
        {
            _logger = logger;
            _member = member;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            try
            {
                var members = await _member.GetAllMembers();
                return Ok(new
                {
                    Success = true,
                    Message = "All Members Returned.",
                    members
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("{Maccount}")]
        public async Task<IActionResult> GetMemberById(string Maccount)
        {
            try
            {
                var member = await _member.GetMemberById(Maccount);
                return Ok(new
                {
                    Success = true,
                    Message = "Member Returned.",
                    member
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember(MemberForCreationDto member)
        {
            try
            {
                var newMember = await _member.CreateMember(member);
                return Ok(new
                {
                    Success = true,
                    Message = "Member Created.",
                    newMember
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        
        //[HttpPut]
        //[Route("{id}")]
        //public async Task<IActionResult> UpdateMember(string Maccount, MemberForUpdateDto member)
        //{
        //    try
        //    {
        //        await _member.UpdateMember(Maccount, member);
        //        return Ok(new { Success = true, Message = "Member Updated." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        [HttpDelete]
        [Route("{Maccount}")]
        public async Task<IActionResult> DeleteMember(string Maccount)
        {
            try
            {
                await _member.DeleteMember(Maccount);
                return Ok(new
                {
                    Success = true,
                    Message = "Member Deleted."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
