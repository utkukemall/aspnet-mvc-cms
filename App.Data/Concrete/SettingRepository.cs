using App.Data.Abstract;
using App.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Concrete
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        public SettingRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Setting>> GetAllSettingAsync()
        {
            return await _dbSet.AsNoTracking().Include(s => s.User).ToListAsync();
        }

        public async Task<Setting> GetSettingByIncludeAsync(int id)
        {
            return await _dbSet.Where(s => s.Id == id).Include(s => s.User).FirstOrDefaultAsync();
        }
    }
}
