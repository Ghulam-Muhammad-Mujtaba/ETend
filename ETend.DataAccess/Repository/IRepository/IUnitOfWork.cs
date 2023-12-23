using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETend.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		IAreaRepository Area { get; }
		IHouseRepository House { get; }
		ICompanyRepository Company { get; }
		IRetailShopRepository RetailShop { get; }
		IVehicleRepository Vehicle { get; }
		IDriverRepository Driver { get; }
		IProductRepository Product { get; }
		ICustomerRepository Customer { get; }
		IShoppingCartRepository ShoppingCart { get; }
		IOrderHeaderRepository OrderHeader { get; }
		IOrderDetailRepository OrderDetail { get; }
		void Save();
	}
}