using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Skilltest.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<SkillTask>>> GetTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return Ok(tasks);
        }

        
        [HttpPost]
        public async Task<ActionResult> CreateTaskAsync([FromBody] SkillTask newTask)
        {
            newTask.DeadLine = newTask.DeadLine.ToUniversalTime();

            _context.Add(newTask);
            await _context.SaveChangesAsync();
            return Ok(newTask);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }
            _context.Remove(task);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTask(int id, [FromBody] SkillTask updatedTask)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            task.Subject = updatedTask.Subject;
            task.Description = updatedTask.Description;
            task.DeadLine = updatedTask.DeadLine.ToUniversalTime();
            task.IsCompleted = updatedTask.IsCompleted;

            await _context.SaveChangesAsync();
            return Ok(task);
        }

    }
}
