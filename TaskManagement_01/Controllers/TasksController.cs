using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement_01.Data;
using TaskManagement_01.Models;
using TaskEntity = TaskManagement_01.Models.Entities.Task;

namespace TaskManagement_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
    {
        private readonly ApplicationDbContext dbContext;

        public TasksController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var allTasks = dbContext.Tasks.ToList();
            return Ok(allTasks);
        }
        [HttpPost]
        public IActionResult AddTask(AddTaskDto addTaskDto)
        {
            var taskentity = new TaskEntity()
            {
                Title = addTaskDto.Title,
                Description = addTaskDto.Description,
                DueDate = addTaskDto.DueDate,
                Priority = addTaskDto.Priority,
                Assignee = addTaskDto.Assignee,
                Status = addTaskDto.Status,
            };

            dbContext.Tasks.Add(taskentity);
            dbContext.SaveChanges();
            return Ok(taskentity);
        }
        [HttpGet]
        [Route("{TaskId:int}")]
        public IActionResult GetTaskbyId(int TaskId)
        {
            var task = dbContext.Tasks.FirstOrDefault(t => t.TaskId == TaskId);
            if (task is null)
            {
                return NotFound();
            }
            return Ok(task);
        }
        [HttpPut]
        [Route("{TaskId:int}")]
        public IActionResult UpdateTask(int TaskId,updateTaskDto updatetaskdto) 
        {
            var task = dbContext.Tasks.FirstOrDefault(t => t.TaskId == TaskId);
            if (task is null) {
                return NotFound();

            }
            task.Title = updatetaskdto.Title;
            task.DueDate = updatetaskdto.DueDate;
            task.Status = updatetaskdto.Status;
            task.Assignee = updatetaskdto.Assignee;
            task.Priority = updatetaskdto.Priority;
            task.Description = updatetaskdto.Description;
            dbContext.SaveChanges();
            return Ok(task);
        }
        [HttpDelete]
        [Route("{TaskId:int}")]
        public IActionResult DeleteTask(int TaskId)
        {
            var task = dbContext.Tasks.FirstOrDefault(t => t.TaskId == TaskId);
            if (task is null)
            {
               return NotFound(); 
            }
            dbContext.Tasks.Remove(task);
            dbContext.SaveChanges();
            return Ok(task);
         

        }

    }
}
