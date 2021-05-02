using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository, ILogger<UsersController> logger)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _userRepository.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUsers(int id)
        {
            return _userRepository.Get(id);
        }

        [HttpPost]
        public ActionResult<User> PostUsers([FromBody] User user)
        {
            var newUser = _userRepository.Create(user);
            return CreatedAtAction(nameof(GetUsers), new { id = newUser.Id }, newUser);
        }

        [HttpPut]
        public ActionResult PutUsers(int id, [FromBody] User user)
        {
            if(id != user.Id)
            {
                return BadRequest();
            }

            _userRepository.Update(user);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteUsers(int id)
        {
            var toDelete = _userRepository.Get(id);
            if(toDelete == null)
            {
                return NotFound();
            }
            _userRepository.Delete(id);

            return NoContent();
        }

    }
}
