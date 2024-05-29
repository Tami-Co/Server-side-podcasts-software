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
    public class ResponseRepository : IRepository<Response>
    {
        private readonly IContext _context;
        public ResponseRepository(IContext context)
        {
            _context = context;
        }
        public async Task<Response> AddItemAsync(Response item)
        {
            Response r = item;
            await _context.Responses.AddAsync(r);
            await _context.save();
            return r;
        }

        public async Task DeleteAsync(int id)
        {
            _context.Responses.Remove(await GetByIdAsync(id));
            await _context.save();
        }

        public async Task<List<Response>> GetAllAsync()
        {
            return await _context.Responses.ToListAsync();

        }

        public async Task<Response> GetByIdAsync(int id)
        {
            return await _context.Responses.Include(r => r.User).FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task UpdateAsync(int id, Response item)
        {
            Response r = await GetByIdAsync(id);
            r.ContentOfResponse = item.ContentOfResponse;
            r.LectureId = item.LectureId;
            r.UserId = item.UserId;
            r.Date=item.Date;
            await _context.save();
        }
    }
}
