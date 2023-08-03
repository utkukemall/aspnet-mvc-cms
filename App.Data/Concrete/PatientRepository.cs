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
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Patient>> GetAllPatientsByIncludeAsync()
        {
            return await _context.Patients.Include(p => p.Doctor).Include(p=> p.Image).Include(d => d.Role).ToListAsync();
        }

        public async Task<Patient> GetPatientByIncludeAsync(int id)
        {
            return await _context.Patients.Include(p=> p.Doctor).Include(p=> p.Image).Include(d => d.Role).FirstOrDefaultAsync(p=> p.Id == id);
        }

        public async Task<List<Patient>> GetSomePatientsByIncludeAsync(Expression<Func<Patient, bool>> expression)
        {
            return await _context.Patients.Where(expression).Include(d => d.Role).Include(p => p.Doctor).Include(p=> p.Image).ToListAsync();
        }
    }
}
