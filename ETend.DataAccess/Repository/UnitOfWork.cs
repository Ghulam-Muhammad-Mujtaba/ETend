using ETend.DataAccess.Data;
using ETend.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETend.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _db;

		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			Area = new AreaRepository(_db);
			House= new HouseRepository(_db);
			Company = new CompanyRepository(_db);
			RetailShop = new RetailShopRepository(_db);
			Vehicle= new VehicleRepository(_db);
		}
		public IAreaRepository Area { get; private set; }
		public IHouseRepository House { get; private set; }
		public ICompanyRepository Company { get; private set; }
		public IRetailShopRepository RetailShop { get; private set; }
		public IVehicleRepository Vehicle { get; private set; }

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
