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
    }
}
