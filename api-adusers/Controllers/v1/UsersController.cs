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
            var results = ActiveUsers();

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

        [HttpGet]
        [Route("v1/programs")]
        public ActionResult GetPrograms()
        {
            var programs = ActiveUsers()
                .Select(u => u.Program)
                .Distinct()
                .ToList();

            return Ok(programs);
        }

        [HttpGet]
        [Route("v1/programs/{program}")]
        public ActionResult GetProgramUsers(string program)
        {
            var users = ActiveUsers()
                .Where(u => u.Program.ToLower() == program.ToLower());
            return Ok(users);
        }

        private List<User> ActiveUsers()
        {
            List<User> results = new List<User>();

            var dbusers = _context.Users
                .Where(u => u.Active == true)
                .Where(u => u.Firstname != null)
                .Where(u => u.Lastname != null)
                .Where(u => u.Deleted != true)
                .Where(u => u.Program != null)
                .Where(u => u.Office != null)
                .Where(u => !u.Ou.Contains("General"))
                .ToList();

            foreach (var user in dbusers)
            {
                results.Add(new User(user));
            }

            results = results.OrderBy(u => u.SortName).ToList();

            return results;
        }
    }
}
