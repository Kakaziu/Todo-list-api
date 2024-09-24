using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> Index()
        {
            var users = await _userRepository.Index();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Show(int id)
        {
            var user = await _userRepository.Show(id);

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Create([FromBody] UserModel user)
        {
            var newUser = await _userRepository.Create(user);

            return Ok(newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel user, int id)
        {
            user.Id = id;
            var updatedUser = await _userRepository.Update(user, id);

            return updatedUser;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool isDeleted = await _userRepository.Delete(id);

            return Ok(isDeleted);
        }
    }
}
