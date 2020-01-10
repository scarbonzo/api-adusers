using api_adusers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace api_adusers.Controllers.v1
{
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly AdUsersContext _context;

        public UsersController(AdUsersContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("v1/users")]
        public IActionResult GetUsers()
        {
            List<User> results = new List<User>();

            var dbusers = _context.Users
                .Where(u => u.Active == true)
                .Where(u => u.Deleted != true)
                .Where(u => u.Program != null)
                .Where(u => u.Office != null)
                .Where(u => !u.Ou.Contains("General"))
                .ToList();
                
            foreach(var user in dbusers)
            {
                results.Add(new User(user));
            }

            results = results.OrderBy(u => u.Username).ThenBy(u => u.Firstname).ToList();

            return Ok(results);
        }

        [HttpGet]
        [Route("v1/users/{id}")]
        public IActionResult GetUser(string Id)
        {
            var result = _context.Users
                .Where(u => u.Id == Id)
                .FirstOrDefault();

            if (result != null)
            {
                return Ok(new User(result));
            }
            else
            {
                return NotFound(Id);
            }
        }
    }
}
