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
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Post>> GetAllPostsByIncludeAsync()
        {
            return await _context.Posts.Include(x=> x.User).Include(x=> x.Comments).Include(x=> x.PostImage).AsNoTracking().ToListAsync();
        }

        public async Task<Post> GetPostByIncludeAsync(int id)
        {
            return await _context.Posts.Include(x => x.User).Include(x => x.Comments).Include(x => x.PostImage).AsNoTracking().FirstOrDefaultAsync(p=> p.Id == id);
        }

        public async Task<List<Post>> GetSomePostsByIncludeAsync(Expression<Func<Post, bool>> expression)
        {
            return await _context.Posts.Include(p=> p.Comments).Include(p=> p.PostImage).Include(p=> p.User).AsNoTracking().Where(expression).ToListAsync();
        }
    }
}
