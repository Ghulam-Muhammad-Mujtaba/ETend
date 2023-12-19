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
	public class VehicleRepository: Repository<Vehicle>, IVehicleRepository
	{
		private ApplicationDbContext _db;

		public VehicleRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Vehicle obj)
		{
			_db.Vehicles.Update(obj);
		}
	}
}
