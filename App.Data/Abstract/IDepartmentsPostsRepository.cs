using App.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Abstract
{
    public interface IDepartmentsPostsRepository : IRepository<DepartmentPost>
    {
        Task<List<DepartmentPost>> GetAllDepartmentPostByIncludeAsync();
        Task<DepartmentPost> GetDepartmentPostByIncludeAsync(int id);
        Task<List<DepartmentPost>> GetSomeDepartmentPostByIncludeAsync(Expression<Func<DepartmentPost, bool>> expression);

    }
}
