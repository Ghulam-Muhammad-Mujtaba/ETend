﻿using ETend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETend.DataAccess.Data
{
	public class ApplicationDbContext:IdentityDbContext
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
		public DbSet<Product> Products { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<ShoppingCart> ShoppingCarts { get; set;}
		public DbSet<OrderHeader> OrderHeaders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
	}
}
