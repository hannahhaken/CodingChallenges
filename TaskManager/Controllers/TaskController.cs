using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers;

[ApiController]
[Route("tasks")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public IActionResult AddTask([FromBody] TaskItem task)
    {
        var result = _taskService.AddTask(task.Title);
        return Created($"/tasks/{result.Id}", result);
    }

    [HttpGet]
    public ActionResult<List<TaskItem>> GetAllTasks()
    {
        var result = _taskService.GetAll();
        return Ok(result);
    }

    [HttpPut("{id}")]
    public IActionResult MarkTaskAsDone([FromRoute] int id)
    {
        var taskUpdated = _taskService.MarkDone(id);
        if (taskUpdated == false) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask([FromRoute] int id)
    {
        var taskDeleted = _taskService.Delete(id);
        if (taskDeleted == false) return NotFound();
        return NoContent();
    }
}