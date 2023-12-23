using ETend.DataAccess.Data;
using ETend.DataAccess.Repository.IRepository;
using ETend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETend.DataAccess.Repository
{
	public class CustomerRepository: Repository<Customer>, ICustomerRepository
    {
		private ApplicationDbContext _db;

		public CustomerRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

	}
}
