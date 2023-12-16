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
	public class AreaRepository: Repository<Area>, IAreaRepository
	{
		private ApplicationDbContext _db;

		public AreaRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Area obj)
		{
			_db.Areas.Update(obj);
		}
	}
}
