﻿using ETend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETend.DataAccess.Repository.IRepository
{
	public interface IAreaRepository:IRepository<Area>
	{
		void Update(Area obj);
	}
}
