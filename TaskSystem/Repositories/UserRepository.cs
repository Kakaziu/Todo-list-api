using TaskSystem.Data;
using TaskSystem.Models;

namespace TaskSystem.Repositories
{
    public class UserRepository
    {
        private readonly TaskSystemDBContext _dbContext;

        public UserRepository(TaskSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
