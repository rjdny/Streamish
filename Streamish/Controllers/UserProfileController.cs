using Microsoft.AspNetCore.Mvc;
using Streamish.Models;
using Streamish.Repositories;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Streamish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userProfileRepository.GetAll());
        }



        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var video = _userProfileRepository.GetById(id);
            if (video == null)
            {
                return NotFound();
            }
            return Ok(video);
        }

        [HttpGet("GetUserWithVideos/{id}")]
        public IActionResult GetWithVideos(int id)
        {
            var video = _userProfileRepository.GetUserProfileByIdWithVideos(id);
            if (video == null)
            {
                return NotFound();
            }
            return Ok(video);
        }

        [HttpPost]
        public IActionResult Post(UserProfile profile)
        {
            _userProfileRepository.Add(profile);
            return CreatedAtAction("Get", new { id = profile.Id }, profile);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UserProfile profile)
        {
            if (id != profile.Id)
            {
                return BadRequest();
            }

            _userProfileRepository.Update(profile);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userProfileRepository.Delete(id);
            return NoContent();
        }
    }
}
