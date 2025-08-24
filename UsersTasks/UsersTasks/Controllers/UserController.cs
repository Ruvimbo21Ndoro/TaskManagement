using Microsoft.AspNetCore.Mvc;
using UsersTasks.DTOs.UserDTOs;
using UsersTasks.Interfaces.Services;

namespace UsersTasks.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(IUserService userService, ILogger<UserController> logger) { 
            _userService = userService;
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<FetchUserDTO>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error while trying to get all users");
                return StatusCode(500, "An unexpected error occurred, our team is currently looking into it. Please try again later");
            }
           
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetUser/{id}")]
        public async Task<ActionResult<FetchUserDTO>> GetUserById([FromRoute] Guid id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);

                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to get user details");
                return StatusCode(500, "An unexpected error occurred, our team is currently looking into it. Please try again later");
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("AddUser")]
        public async Task<ActionResult<AddUserDTO>> AddNewUser([FromBody] AddUserDTO newUser)
        {
            try
            {
                var isUserAdded = await _userService.CreateUserAsync(newUser);

                if (!isUserAdded)
                    return Conflict("A user with the provided email already exists");

                return CreatedAtAction(nameof(AddNewUser), new { email = newUser.Email }, newUser);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to add a user");
                return StatusCode(500, "An unexpected error occurred, our team is currently looking into it. Please try again later");
            }

            
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("UpdateUser/{userId}")]
        public async Task<IActionResult> UpdateUserById([FromRoute]Guid userId, [FromBody] UpdateUserDTO updateUser)
        {

            try
            {
                var updatedUser = await _userService.UpdateUserAsync(userId, updateUser);

                if (!updatedUser)
                    return NotFound("The user with the provided details does not exist");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to update a user");
                return StatusCode(500, "An unexpected error occurred, our team is currently looking into it. Please try again later");
            }

            
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUserById([FromRoute] Guid id)
        {
            try
            {
                var success = await _userService.DeleteUserAsync(id);

                if (!success)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to delete user");
                return StatusCode(500, "An unexpected error occurred, our team is currently looking into it. Please try again later");
            }
        }


    }
}