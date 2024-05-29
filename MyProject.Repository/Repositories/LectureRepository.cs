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
    public class LectureRepository : IRepository<Lecture>
    {

        private readonly IContext _context;
        public LectureRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Lecture> AddItemAsync(Lecture item)
        {
            Lecture l = item;
            await _context.Lectures.AddAsync(l);
            await _context.save();
            return l;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Lectures.Remove(await GetByIdAsync(id));
            await _context.save();
        }

        public async Task<List<Lecture>> GetAllAsync()
        {
           var l=  await _context.Lectures.Include(l=>l.Lecturer).ToListAsync();
            return l;
        }

        public async Task<Lecture> GetByIdAsync(int id)
        {
            return await _context.Lectures.Include(l =>l.Lecturer).Include(l => l.Responses).ThenInclude(u=>u.User).FirstOrDefaultAsync(x => x.Id == id);

        }
        public async Task UpdateAsync(int id, Lecture item)
        {
            Lecture u = await GetByIdAsync(id);
            u.NumberViews = u.NumberViews+1;
            await _context.save();
        }
    }
}
