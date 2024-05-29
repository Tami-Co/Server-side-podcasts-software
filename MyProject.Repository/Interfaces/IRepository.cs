using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Repository.Interfaces
{
    public interface IRepository<T> where T:class
    {
        public Task< List<T>>  GetAllAsync();
        public Task< T> GetByIdAsync(int id);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(int id,T item);
        public Task<T> AddItemAsync(T item);
    }
}
