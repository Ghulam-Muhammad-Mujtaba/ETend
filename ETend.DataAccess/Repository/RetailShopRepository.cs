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
	public class RetailShopRepository: Repository<RetailShop>, IRetailShopRepository
	{
		private ApplicationDbContext _db;

		public RetailShopRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(RetailShop obj)
		{
			var objFromDb = _db.RetailShops.FirstOrDefault(u=>u.Id== obj.Id);
			if (objFromDb != null)
			{
				objFromDb.Area = obj.Area;
				objFromDb.ShopAddress = obj.ShopAddress;
				objFromDb.AreaId = obj.AreaId;
				objFromDb.PhoneNumber = obj.PhoneNumber;
				objFromDb.ShopName = obj.ShopName;
				objFromDb.ShopOwner = obj.ShopOwner;
			}
		}
	}
}
