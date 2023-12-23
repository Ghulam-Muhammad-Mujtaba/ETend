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
			Driver = new DriverRepository(_db);
			Product = new ProductRepository(_db);
			ShoppingCart = new ShoppingCartRepository(_db);
			Customer = new CustomerRepository(_db);
			OrderDetail = new OrderDetailRepository(_db);
			OrderHeader = new OrderHeaderRepository(_db);
		}
		public IAreaRepository Area { get; private set; }
		public IHouseRepository House { get; private set; }
		public ICompanyRepository Company { get; private set; }
		public IRetailShopRepository RetailShop { get; private set; }
		public IVehicleRepository Vehicle { get; private set; }
		public IDriverRepository Driver { get; private set; }
		public IProductRepository Product { get; private set; }
		public IShoppingCartRepository ShoppingCart { get; private set; }
		public ICustomerRepository Customer { get; private set; }
		public IOrderHeaderRepository OrderHeader { get; private set; }
		public IOrderDetailRepository OrderDetail { get; private set; }

        public void Save()
		{
			_db.SaveChanges();
		}
	}
}
