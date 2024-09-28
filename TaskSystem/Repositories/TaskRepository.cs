using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemDBContext _dbContext;

        public TaskRepository(TaskSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TaskModel>> Index()
        {
            return await _dbContext.Tasks.Include(x => x.User).ToListAsync();
        }

        public async Task<TaskModel> Show(int id)
        {
            TaskModel? task = await _dbContext.Tasks.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);

            if (task == null) throw new Exception("Tarefa não encontrada");

            return task;
        }

        public async Task<TaskModel> Create(TaskModel task)
        {
            await _dbContext.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<TaskModel> Update(TaskModel task, int id)
        {
            TaskModel? newTask = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if (newTask == null) throw new Exception("Tarefa não encontrada");

            newTask.Name = task.Name;
            newTask.Description = task.Description;
            newTask.Status = task.Status;
            newTask.UserId = task.UserId;

            _dbContext.Update(newTask);
            await _dbContext.SaveChangesAsync();

            return newTask;
        }

        public async Task<bool> Delete(int id)
        {
            TaskModel? task = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);

            if (task == null) throw new Exception("Tarefa não encontrada");

            _dbContext.Remove(task);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
