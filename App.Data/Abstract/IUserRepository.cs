using App.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByIncludeAsync(int userId);
        Task<List<User>> GetAllUserByIncludeAsync();
    }
}
