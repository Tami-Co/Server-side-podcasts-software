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
    public class CategoryRepository : IRepository<Category>
    {
        private readonly IContext _context;
        public CategoryRepository(IContext context)
        {
            _context = context;
        }

        public  async Task<Category> AddItemAsync(Category item)
        {
            Category c = item;
            await _context.Categories.AddAsync(c);
            await _context.save();
            return c;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Categories.Remove(await GetByIdAsync(id));
            await _context.save();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var c= await _context.Categories.ToListAsync();
            return c;
        }

        public async Task<Category> GetByIdAsync(int id)
        {          
            //var c = await _context.Categories
            //    .Include(c=>c.Lectures).ThenInclude(l=> l.Lecturer).Include(l=>l.Lectures).ThenInclude(l=>l.Responses)
            //    .FirstOrDefaultAsync(x => x.Id == id);
            //return c;
            var c = await _context.Categories
               .Include(c => c.Lectures).ThenInclude(l => l.Lecturer).Include(l => l.Lectures).ThenInclude(l => l.Responses).ThenInclude(u=>u.User)
               .FirstOrDefaultAsync(x => x.Id == id);
            return c;

        }

        public async Task UpdateAsync(int id, Category item)
        {

            Category c = await GetByIdAsync(id);
            c.NameOfCategory= item.NameOfCategory;
             c.UrlImage= item.UrlImage;
            await _context.save();
        }
    }
}
