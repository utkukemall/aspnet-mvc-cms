using App.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Abstract
{
    public interface IPatientRepository :  IRepository<Patient>
    {
        Task<Patient> GetPatientByIncludeAsync(int id);

        Task<List<Patient>> GetAllPatientsByIncludeAsync();

        Task<List<Patient>> GetSomePatientsByIncludeAsync(Expression<Func<Patient, bool>> expression);
    }
}
