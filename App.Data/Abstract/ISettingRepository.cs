using App.Data.Concrete;
using App.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Abstract
{
    public interface ISettingRepository : IRepository<Setting>
    {
        Task<Setting> GetSettingByIncludeAsync(int id);
        Task<List<Setting>> GetAllSettingAsync();
    }
}
