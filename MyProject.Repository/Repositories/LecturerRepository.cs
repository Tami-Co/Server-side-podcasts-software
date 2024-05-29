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
    public class LecturerRepository:IRepository<Lecturer>
    {
        private readonly IContext _context;
        public LecturerRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Lecturer> AddItemAsync(Lecturer item)
        {
            Lecturer l = item;
            await _context.Lecturers.AddAsync(l);
            await _context.save();
            return l;
        }
    
        public async Task DeleteAsync(int id)
        {
            _context.Lecturers.Remove(await GetByIdAsync(id));
            await _context.save();
        }

        public async Task<List<Lecturer>> GetAllAsync()
        {
            return await _context.Lecturers.ToListAsync();

        }

        public async Task<Lecturer> GetByIdAsync(int id)
        {
            return await _context.Lecturers.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task UpdateAsync(int id, Lecturer item)
        {
            Lecturer l = await GetByIdAsync(id);
            l.NumberViews= l.NumberViews+1;
            await _context.save();
        }

    }
}
