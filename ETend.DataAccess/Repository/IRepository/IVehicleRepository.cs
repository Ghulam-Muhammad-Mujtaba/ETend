using ETend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETend.DataAccess.Repository.IRepository
{
	public interface IVehicleRepository:IRepository<Vehicle>
	{
		void Update(Vehicle obj);
	}
}
