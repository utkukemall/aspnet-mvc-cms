using App.Data;
using App.Data.Concrete;
using App.Data.Entity;
using App.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.Concrete
{
	public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
	{
		public Service(AppDbContext context) : base(context)
		{

		}
	}
}
