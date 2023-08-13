using App.Data.Abstract;
using App.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace App.Data.Concrete
{
    public class DepartmentsPostsRepository : Repository<DepartmentPost>, IDepartmentsPostsRepository
    {
        public DepartmentsPostsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<DepartmentPost>> GetAllDepartmentPostByIncludeAsync()
        {
            return await _context.DepartmentPosts.Include(d => d.Departments).Include(d => d.Post).Include(d=> d.Post.Comments).ToListAsync();
        }

        public async Task<DepartmentPost> GetDepartmentPostByIncludeAsync(int id)
        {
            return await _context.DepartmentPosts.Include(d => d.Departments).Include(d => d.Post).Include(d => d.Post.Comments).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<DepartmentPost>> GetSomeDepartmentPostByIncludeAsync(Expression<Func<DepartmentPost, bool>> expression)
        {
            return await _context.DepartmentPosts.Where(expression).Include(d => d.Departments).Include(d => d.Post.Comments).Include(d => d.Post).ToListAsync();
        }
    }
}

