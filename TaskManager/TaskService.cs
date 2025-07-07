using System.Collections.Generic;
using System.Linq;

namespace TaskManager;

public class TaskService : ITaskService
{
    private readonly List<TaskItem> _tasks = new();
    private int _nextId = 1;

    public TaskItem AddTask(string title)
    {
        var task = new TaskItem { Id = _nextId++, Title = title, Done = false };
        _tasks.Add(task);
        return task;
    }

    public List<TaskItem> GetAll() => _tasks;

    public bool MarkDone(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return false;
        task.Done = true;
        return true;
    }

    public bool Delete(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return false;
        _tasks.Remove(task);
        return true;
    }
}