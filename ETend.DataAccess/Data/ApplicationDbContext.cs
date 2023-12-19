using ETend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETend.DataAccess.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		public DbSet<Area> Areas { get; set; }
		public DbSet<House> Houses { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<RetailShop> RetailShops { get; set; }
		public DbSet<Vehicle> Vehicles { get; set; }
		public DbSet<Driver> Drivers { get; set; }
	}
}
