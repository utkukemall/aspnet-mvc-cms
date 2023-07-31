using App.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Abstract
{
    public interface IDoctorsRepository : IRepository<Doctors>
    {
        Task<Doctors> GetDoctorByIncludeAsync(int id);

        Task<List<Doctors>> GetAllDoctorsByIncludeAsync();

        Task<List<Doctors>> GetSomeDoctorsByIncludeAsync(Expression<Func<Doctors,bool>> expression);
    }
}
