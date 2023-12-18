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
	public class CompanyRepository: Repository<Company>, ICompanyRepository
	{
		private ApplicationDbContext _db;

		public CompanyRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Company obj)
		{
			var objFromDb = _db.Companies.FirstOrDefault(u=>u.Id== obj.Id);
			if (objFromDb != null)
			{
				objFromDb.Area = obj.Area;
				objFromDb.Address = obj.Address;
				objFromDb.AreaId = obj.AreaId;
				objFromDb.PhoneNumber = obj.PhoneNumber;
				objFromDb.Name = obj.Name;
			}
		}
	}
}
