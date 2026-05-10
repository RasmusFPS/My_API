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
        private readonly ApiDbContext _context;

        public UserController(ApiDbContext contex)
        {
            _context = contex;
        }

        [HttpGet("Person", Name = "GetAllPersons")]
        public async Task<ActionResult<IEnumerable<GetPersonResponse>>> GetAllPersons()
        {
            return Ok(await _context.Person
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
            var person = _context.Person.Where(p => p.Id == PersonId).Select(p => new
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
            var person = _context.Person.Where(p => p.Id == PersonId)
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
        public async Task<IActionResult> AddInterestById(int personId, int interestId)
        {
            var person = await _context.Person.FirstOrDefaultAsync(p => p.Id == personId);
            var interest = await _context.Interest.FirstOrDefaultAsync(i => i.Id == interestId);

            if (person == null)
            {
                return NotFound($"Person NotFound with id:{personId}");
            }
            if(interest == null)
            {
                return NotFound($"Person NotFound with id:{personId}");
            }

            var AlreadyHasInterest = await _context.PersonInterests.AnyAsync(p => p.PersonId == personId && p.InterestId == interestId);
            if (AlreadyHasInterest)
            {
                return BadRequest($"Person with this id:{personId} already has this Interest");
            }

            var NewInterest = new PersonInterests
            {
                PersonId = personId,
                InterestId = interestId,
            };

            await _context.PersonInterests.AddAsync(NewInterest);
            await _context.SaveChangesAsync();

            return Ok(NewInterest);
        }

        [HttpPost("AddLinkById", Name = "AddLinkById")]
        public async Task<ActionResult<AddLinkToPerson>> AddLinkById(int PersonId, AddLinkToPerson dto)
        {
            var personExists = await _context.Person.AnyAsync(p => p.Id == PersonId);
            if (!personExists)
            {
                return NotFound($"Cannot add link. Person with ID {PersonId} was not found.");
            }

            var interestExists = await _context.Interest.AnyAsync(i => i.Id == dto.InterestId);
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

            await _context.Links.AddAsync(NewLink);
            await _context.SaveChangesAsync();

            return Ok(NewLink);
        }
    }

}

