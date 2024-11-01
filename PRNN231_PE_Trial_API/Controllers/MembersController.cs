using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using PRNN231_PE_Trial_API.Models;
using PRNN231_PE_Trial_API.Models.DTOs;

namespace PRNN231_PE_Trial_API.Controllers
{
    [Authorize]
    public class MembersController : ODataController
    {
        private readonly MyDbContext _context;

        public MembersController(MyDbContext context)
        {
            _context = context;
        }

        // GET: /Members
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetMembers()
        {
            try
            {
                var members = await _context.Members.ToListAsync();
                return Ok(members);
            }
            catch (Exception)
            {
                return BadRequest("Error retrieving members.");
            }
        }

        // GET: /Members(id)
        [HttpGet("Members/Get/{id}")]
        [EnableQuery]
        public async Task<IActionResult> GetMember([FromRoute] int id)
        {
            try
            {
                var member = await _context.Members.FindAsync(id);
                if (member == null)
                {
                    return NotFound($"Member with ID {id} not found.");
                }

                return Ok(member);
            }
            catch (Exception)
            {
                return BadRequest("Error retrieving member.");
            }
        }

        // PUT: /Members(id)
        [HttpPut("Members/Update")]
        public async Task<IActionResult> PutMember([FromBody] UMemberDTO memberDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var member = new Member
            {
                MemberId = memberDTO.MemberId,
                City = memberDTO.City,
                CompanyName = memberDTO.CompanyName,
                Country = memberDTO.Country,
                Email = memberDTO.Email,
                Fullname = memberDTO.Fullname,
                Password = memberDTO.Password,
            };

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(member.MemberId))
                {
                    return NotFound($"Member with ID {member.MemberId} not found.");
                }

                throw;
            }
            catch (Exception)
            {
                return BadRequest("Error updating member.");
            }
        }

        // POST: /Members
        [HttpPost]
        public async Task<IActionResult> PostMember([FromBody] MemberDTO memberDTO)
        {
            try
            {
                var member = new Member
                {
                    City = memberDTO.City,
                    CompanyName = memberDTO.CompanyName,
                    Country = memberDTO.Country,
                    Email = memberDTO.Email,
                    Fullname = memberDTO.Fullname,
                    Password = memberDTO.Password
                };

                _context.Members.Add(member);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetMember), new { id = member.MemberId }, member);
            }
            catch (Exception)
            {
                return BadRequest("Error creating new member.");
            }
        }

        // DELETE: /Members(id)
        [HttpDelete("Members/Delete/{id}")]
        public async Task<IActionResult> DeleteMember([FromRoute] int id)
        {
            try
            {
                var member = await _context.Members.FindAsync(id);
                if (member == null)
                {
                    return NotFound($"Member with ID {id} not found.");
                }

                _context.Members.Remove(member);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest("Error deleting member.");
            }
        }

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.MemberId == id);
        }
    }
}
