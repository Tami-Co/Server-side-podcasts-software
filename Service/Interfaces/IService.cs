using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service.Interfaces
{
    public interface IService<T> 
    {
        public Task< List<T>> GetAllAsync();
        public Task< T> GetByIdAsync(int id);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(int id, T service);
        public Task<T> AddAsync(T service);
    }
}
