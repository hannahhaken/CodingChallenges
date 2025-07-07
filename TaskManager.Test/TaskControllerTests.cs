using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TaskManager.Controllers;

namespace TaskManager.Test;

public class TaskControllerTests
{
    [Fact]
    public void AddTask_ShouldReturnCreated_WhenTaskAdded()
    {
        var task = new TaskItem { Id = 1, Title = "Test title", Done = false };
        var mockService = new Mock<ITaskService>();
        mockService
            .Setup(s => s.AddTask(task.Title))
            .Returns(new TaskItem { Id = 1, Title = task.Title, Done = false });

        var taskController = new TaskController(mockService.Object);
        var result = taskController.AddTask(task);

        Assert.NotNull(result);
        var createdResult = Assert.IsType<CreatedResult>(result);
        Assert.Equal(201, createdResult.StatusCode);
        Assert.Equal("/tasks/1", createdResult.Location);

        var returnedTask = Assert.IsType<TaskItem>(createdResult.Value);
        Assert.Equal(1, returnedTask.Id);
        Assert.Equal("Test title", returnedTask.Title);
        Assert.False(returnedTask.Done);
    }

    [Fact]
    public void GetAllTasks_ShouldReturnListOfTasks()
    {
        var mockService = new Mock<ITaskService>();
        mockService.Setup(s => s.GetAll()).Returns(new List<TaskItem>());

        var taskController = new TaskController(mockService.Object);
        var result = taskController.GetAllTasks();

        Assert.NotNull(result);
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.IsType<List<TaskItem>>(okResult.Value);
        Assert.Equal(200, okResult.StatusCode);
    }
    
    [Fact]
    public void GetAllTasks_ShouldReturnPopulatedList_WhenTasksExist()
    {
        var taskList = new List<TaskItem>
        {
            new() { Id = 1, Title = "A", Done = false },
            new() { Id = 2, Title = "B", Done = true }
        };
        var mockService = new Mock<ITaskService>();
        mockService.Setup(s => s.GetAll()).Returns(taskList);

        var controller = new TaskController(mockService.Object);
        var result = controller.GetAllTasks();

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var returnedList = Assert.IsType<List<TaskItem>>(okResult.Value);
        Assert.Equal(2, returnedList.Count);
    }
}