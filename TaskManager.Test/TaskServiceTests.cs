namespace TaskManager.Test;

public class TaskServiceTests
{
    [Fact]
    public void AddTask_ShouldReturnAddedTask()
    {
        const string title = "Test title";

        var taskService = new TaskService();
        taskService.AddTask(title);

        var tasks = taskService.GetAll();
        Assert.NotNull(tasks);
        Assert.Equal("Test title", tasks[0].Title);
        Assert.False(tasks[0].Done);
    }

    [Fact]
    public void GetAll_ShouldReturnAllTasks()
    {
        const string title = "Test title";

        var taskService = new TaskService();
        taskService.AddTask(title);

        var tasks = taskService.GetAll();
        Assert.NotNull(tasks);
        Assert.Equal("Test title", tasks[0].Title);
        Assert.Single(tasks);
    }

    [Fact]
    public void MarkDone_ShouldSetTaskToDone_AndReturnTrue_WhenIdExists()
    {
        var taskService = new TaskService();
        var taskItem = taskService.AddTask("Test title");

        var result = taskService.MarkDone(taskItem.Id);

        Assert.True(result);
        Assert.True(taskItem.Done);
    }

    [Fact]
    public void MarkDone_ShouldReturnFalse_WhenIdNotIncludedInMemory()
    {
        var idNotIncludedInMemory = 2;
        var taskService = new TaskService();
        var taskItem = taskService.AddTask("Test title");

        var result = taskService.MarkDone(idNotIncludedInMemory);
        Assert.False(result);
    }

    [Fact]
    public void Delete_ShouldRemoveTaskFromList_AndReturnTrue_WhenIdExists()
    {
        var taskService = new TaskService();
        taskService.AddTask("Test title");

        var isDeleted = taskService.Delete(1);
        var tasks = taskService.GetAll();

        Assert.True(isDeleted);
        Assert.Empty(tasks);
    }
}