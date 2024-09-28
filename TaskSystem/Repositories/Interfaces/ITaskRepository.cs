using TaskSystem.Models;

namespace TaskSystem.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> Index();
        Task<TaskModel> Show(int id);
        Task<TaskModel> Create(TaskModel task);
        Task<TaskModel> Update(TaskModel task, int id);
        Task<bool> Delete(int id);
    }
}
