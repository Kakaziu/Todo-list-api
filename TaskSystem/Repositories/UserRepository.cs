using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSystemDBContext _dbContext;

        public UserRepository(TaskSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserModel>> Index()
        {
            List<UserModel> users = await _dbContext.Users.ToListAsync();

            return users;
        }

        public async Task<UserModel> Create(UserModel user)
        {
            await _dbContext.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;

        }

        public async Task<bool> Delete(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null) throw new Exception("Usuário não existe.");

            _dbContext.Remove(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<UserModel> Show(int id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null) throw new Exception("Usuário não existe.");

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            var foundUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (foundUser == null) throw new Exception("Usuário não existe.");

            foundUser.Name = user.Name;
            foundUser.Email = user.Email;

            _dbContext.Update(foundUser);
            await _dbContext.SaveChangesAsync();

            return foundUser;
        }
    }
}
