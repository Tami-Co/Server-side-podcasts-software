using Microsoft.EntityFrameworkCore;
using MyProject.Repository.Entity;
using MyProject.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Repositories
{
    public class UserRepository:IRepository<User>
    {
        private readonly IContext _context;
        public UserRepository(IContext context)
        {
            _context = context;
        }

        public async Task<User> AddItemAsync(User item)
        {
            User u = item;
            await _context.Users.AddAsync(u);
            await _context.save();
            return u;
        }
        public async Task DeleteAsync(int id )
        {
            _context.Users.Remove(await GetByIdAsync(id));
            await _context.save();
        }


        public  async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }
    
        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(int id, User item)
        {
            //  _context.Users.Update(item);
            User u = await GetByIdAsync(id);
            if (item.Email != "")
            {
            u.Email= item.Email;

            }
            if (item.FirstName != "")
            {
                u.FirstName = item.FirstName;

            }
            if (item.LastName != "")
            {
                u.LastName= item.LastName;

            }
            if (item.Password != "")
            {
                u.Password= item.Password;

            }
            await _context.save();
        }
    

    }
}










