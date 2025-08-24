using Microsoft.AspNetCore.Mvc;
using UsersTasks.DTOs.TaskDTOs;
using UsersTasks.DTOs.UserDTOs;
using UsersTasks.Interfaces.Services;
using UsersTasks.Services;

namespace UsersTasks.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly ILogger<TaskController> _logger;
        public TaskController(ITaskService taskService, ILogger<TaskController> logger) { 
            _taskService = taskService;
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("CreateNewTask")]
        public async Task<ActionResult<AddTaskDTO>> CreateNewTask(AddTaskDTO newTask)
        {
            try
            {
                var isTaskCreated = await _taskService.CreateTaskAsync(newTask);

                if (!isTaskCreated)
                    return NotFound("The assigned user was not found");

                return CreatedAtAction(nameof(CreateNewTask), new { title = newTask.Title }, newTask);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error while trying to get all users");
                return StatusCode(500, "An unexpected error occurred, our team is currently looking into it. Please try again later");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetAllTask")]
        public async Task<ActionResult<List<FetchTaskDTO>>> GetAllTasks()
        {
            try
            {
                var tasks = await _taskService.GetAllTasksAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error while trying to get all tasks");
                return StatusCode(500, "An unexpected error occurred, our team is currently looking into it. Please try again later");
            }

        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("UpdateTask/{UpdateTaskWithId}")]
        public async Task<IActionResult> UpdateTask([FromRoute] Guid UpdateTaskWithId, [FromBody] UpdateTaskDTO updatedTask)
        {
            try
            {
                var updateTask = await _taskService.UpdateTaskByIdAsync(UpdateTaskWithId, updatedTask);

                if (!updateTask)
                    return NotFound("The provided user or task Id was not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to update a task");
                return StatusCode(500, "An unexpected error occurred, our team is currently looking into it. Please try again later");
            }
            
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetTask/{getTaskWithId}")]
        public async Task<ActionResult<FetchTaskDTO>> GetTaskById([FromRoute] Guid getTaskWithId)
        {
            try
            {
                var task = await _taskService.GetATaskByIdAsync(getTaskWithId);

                if (task == null)
                    return NotFound("The provided task ID was not found");

                return Ok(task);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to get task details");
                return StatusCode(500, "An unexpected error occurred, our team is currently looking into it. Please try again later");
            }
        }


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("DeleteTask/{deleteTaskWithId}")]
        public async Task<IActionResult> DeleteTaskById([FromRoute] Guid deleteTaskWithId)
        {
            try
            {
                var isTaskDeleted = await _taskService.DeleteATaskByIdAsync(deleteTaskWithId);

                if (!isTaskDeleted)
                    return NotFound("The provided task ID was not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to delete a task");
                return StatusCode(500, "An unexpected error occurred, our team is currently looking into it. Please try again later");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetExpiredTasks")]
        public async Task<ActionResult<List<FetchTaskDTO>>> GetExpiredTasks()
        {
            try
            {
                var tasks = await _taskService.GetExpiredTasksAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to get expired tasks");
                return StatusCode(500, "An unexpected error occurred, our team is currently looking into it. Please try again later");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetActiveTasks")]
        public async Task<ActionResult<List<FetchTaskDTO>>> GetActiveTasks()
        {
            try
            {
                var tasks = await _taskService.GetActiveTasksAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to get active tasks");
                return StatusCode(500, "An unexpected error occurred, our team is currently looking into it. Please try again later");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetTasksByDate/{givenDate}")]
        public async Task<ActionResult<List<FetchTaskDTO>>> GetTasksByDate([FromRoute] DateOnly givenDate)
        {
            try
            {
                var tasks = await _taskService.GetTasksByDateAsync(givenDate);

                if (tasks == null || !tasks.Any())
                    return NotFound("No tasks found for the given date");

                return Ok(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to get tasks by date");
                return StatusCode(500, "An unexpected error occurred, our team is currently looking into it. Please try again later");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("GetTasksByAssignee/{assigneeId}")]
        public async Task<ActionResult<List<FetchTaskDTO>>> GetTasksByAssignee([FromRoute] Guid assigneeId)
        {
            try
            {
                var tasks = await _taskService.GetTasksByAssigneeAsync(assigneeId);

                if (tasks == null || !tasks.Any())
                    return NotFound("No tasks found for the given assignee");

                return Ok(tasks);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to get tasks by assignee");
                return StatusCode(500, "An unexpected error occurred, our team is currently looking into it. Please try again later");
            }
        }
    }
}