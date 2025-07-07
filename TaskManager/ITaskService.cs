using System.Collections.Generic;

namespace TaskManager;

public interface ITaskService
{
    TaskItem AddTask(string title);
    List<TaskItem> GetAll();
    bool MarkDone(int id);
    bool Delete(int id);
}