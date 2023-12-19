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
	public class DriverRepository: Repository<Driver>, IDriverRepository
	{
		private ApplicationDbContext _db;

		public DriverRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Driver obj)
		{
			var objFromDb = _db.Drivers.FirstOrDefault(u=>u.Id== obj.Id);
			if (objFromDb != null)
			{
				objFromDb.DriverName = obj.DriverName;
				objFromDb.PhoneNo = obj.PhoneNo;
				objFromDb.VehicleId = obj.VehicleId;
				objFromDb.Vehicle = obj.Vehicle;
				objFromDb.Email = obj.Email;
			}
		}
	}
}
