using App.Data.Abstract;
using App.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Concrete
{
    public class DepartmentsPostsRepository : Repository<DepartmentPost>, IDepartmentsPostsRepository
    {
        public DepartmentsPostsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<DepartmentPost>> GetAllDepartmentPostByIncludeAsync()
        {
            return await _context.DepartmentPosts.Include(d => d.Departments).Include(d => d.Post).ToListAsync();
        }

        public async Task<DepartmentPost> GetDepartmentPostByIncludeAsync(int id)
        {
            return await _context.DepartmentPosts.Include(d => d.Departments).Include(d => d.Post).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<DepartmentPost>> GetSomeDepartmentPostByIncludeAsync(Expression<Func<DepartmentPost, bool>> expression)
        {
            return await _context.DepartmentPosts.Where(expression).Include(d => d.Departments).Include(d => d.Post).ToListAsync();
        }
    }
}

