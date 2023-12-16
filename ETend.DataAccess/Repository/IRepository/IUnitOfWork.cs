﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETend.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		IAreaRepository Area { get; }
		void Save();
	}
}
