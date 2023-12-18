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
	public class HouseRepository: Repository<House>, IHouseRepository
	{
		private ApplicationDbContext _db;

		public HouseRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(House obj)
		{
			var objFromDb = _db.Houses.FirstOrDefault(u=>u.Id== obj.Id);
			if (objFromDb != null)
			{
				objFromDb.Area = obj.Area;
				objFromDb.Address = obj.Address;
				objFromDb.AreaId = obj.AreaId;
				objFromDb.PhoneNumber = obj.PhoneNumber;
			}
		}
	}
}
