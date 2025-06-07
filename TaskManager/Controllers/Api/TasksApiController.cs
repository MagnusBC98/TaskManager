using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using TaskManager.Data;
using TaskManager.Interfaces;
using TaskManager.Models;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace TaskManager.Controllers.Api
{
    [Route("api/Tasks")]
    [ApiController]
    public class TasksApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ITaskService _taskService;

        public TasksApiController(ApplicationDbContext context, ITaskService taskService)
        {
            _context = context;
            _taskService = taskService;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTaskItems()
        {
            var tasks = await _taskService.GetTasksAsync();
            return Ok(tasks);
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskItem(int id)
        {
            var task = await _taskService.GetTaskAsync(id);
            return task is not null ? task : NotFound();
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskItem(int id, TaskItem taskItem)
        {
            if (id != taskItem.Id)
            {
                return BadRequest();
            }

            var updated = await _taskService.UpdateTaskAsync(taskItem);

            if (!updated) return NotFound();

            return NoContent();
        }

        // POST: api/Tasks
        [HttpPost]
        public async Task<ActionResult<TaskItem>> PostTaskItem(TaskItem taskItem)
        {
            var createdTask = await _taskService.CreateTaskAsync(taskItem);
            return CreatedAtAction(nameof(PostTaskItem), new { id = createdTask.Id }, createdTask);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(int id)
        {
            var deleted = await _taskService.DeleteTaskAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
