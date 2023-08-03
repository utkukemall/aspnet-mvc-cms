using App.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Abstract
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<Department> GetDepartmentByIncludeAsync(int id);

        Task<List<Department>> GetAllDepartmentsByIncludeAsync();

        Task<List<Department>> GetSomeDepartmentsByIncludeAsync(Expression<Func<Department, bool>> expression);
    }
}
