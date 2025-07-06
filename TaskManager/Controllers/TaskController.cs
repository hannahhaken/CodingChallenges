using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers;

[ApiController]
[Route("tasks")]
public class TaskController : ControllerBase
{
    private readonly TaskService _taskService;

    public TaskController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    public IActionResult AddTask([FromBody] TaskItem task)
    {
        var result = _taskService.Add(task.Title);
        return null;
    }
}