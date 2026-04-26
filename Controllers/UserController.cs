using MYAPI.Models;
using MYAPI.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace MYAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApiDbContext _contex;

        public UserController(ApiDbContext contex)
        {
            _contex = contex;
        }

        [HttpGet("Person", Name = "GetAllPersons")]
        public async Task<ActionResult<IEnumerable<GetPersonResponse>>> GetAllPersons()
        {
            return Ok(await _contex.Person
                .Select(p => new GetPersonResponse(
                    p.Id,
                    p.Name,
                    p.Phone_Number
                    ))
                .ToListAsync());
        }

        [HttpGet("GetInterestById", Name = "GetInterestById")]
        public async Task<IActionResult> GetInterestById(int PersonId)
        {
            var person = _contex.Person.Where(p => p.Id == PersonId).Select(p => new
            {
                p.Name,
                Interest = p.Links.Select(l => new
                {
                    l.Interest.Title,
                    l.Interest.Description
                })
            })
            .FirstOrDefault();

            if(person == null)
            {
                return NotFound($"Person NotFound with id:{PersonId}");
            }
           return Ok(person);
        }


        [HttpGet("GetLinksById", Name = "GetLinksById")]
        public async Task<ActionResult> GetLinksById(int PersonId)
        {
            var person = _contex.Person.Where(p => p.Id == PersonId)
            .Select(p => new
            {
                p.Name,
                Link = p.Links.Select(l => new
                {
                    l.URL,
                    l.Interest.Title,
                    l.Interest.Description
                })
            })
            .FirstOrDefault();

            if (person == null)
            {
                return NotFound($"Person NotFound with id:{PersonId}");
            }
            return Ok(person);
        }

        [HttpPost("AttachNewInterestById", Name ="AddInterestById")]
        public async Task<IActionResult> AddInterestById(int PersonId, int InterestId)
        {
            var personToUpdate = await _contex.Person.FirstOrDefaultAsync(u => u.Id == PersonId);
            var interest = await _contex.Interest.FirstOrDefaultAsync(i => i.Id == InterestId);

            if (PersonId == null)
            {
                return NotFound($"Person NotFound with id:{PersonId}");
            }
            if(InterestId == null)
            {
                return NotFound($"Person NotFound with id:{PersonId}");
            }

            var AlreadyHasInterest = await _contex.Links.AnyAsync(l => l.PersonId == PersonId && l.InterestId == InterestId);
            if (AlreadyHasInterest)
            {
                return BadRequest($"Person with this id:{PersonId} already has this Interest");
            }

            var NewInterest = new Link
            {
                InterestId = InterestId,
                PersonId = PersonId,
            };

            await _contex.Links.AddAsync(NewInterest);
            await _contex.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("AddLinkById", Name = "AddLinkById")]
        public async Task<IActionResult> AddLinkById(int PersonId, AddLinkToPerson dto)
        {
            var personExists = await _contex.Person.AnyAsync(p => p.Id == PersonId);
            if (!personExists)
            {
                return NotFound($"Cannot add link. Person with ID {PersonId} was not found.");
            }

            var interestExists = await _contex.Interest.AnyAsync(i => i.Id == dto.InterestId);
            if (!interestExists)
            {
                return NotFound($"Cannot add link. Interest with ID {dto.InterestId} was not found.");
            }

            var NewLink = new Link
            {
                PersonId = PersonId,
                URL = dto.URL,
                InterestId = dto.InterestId
            };

            await _contex.Links.AddAsync(NewLink);
            await _contex.SaveChangesAsync();

            return NoContent();
        }
    }

}

