using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Service.Interfaces
{
    public interface IServicesExtention<T> : IService<T>
    {
        public Task<string> GetUserByUserEmail(string userName, string password);

    }
}


