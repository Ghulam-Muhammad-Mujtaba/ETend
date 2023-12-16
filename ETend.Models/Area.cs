using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ETend.Models
{
	public class Area
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public AreaType Type { get; set; }

		// Navigation Properties
		//public ICollection<House> Houses { get; set; }
		//public ICollection<Company> Companies { get; set; }
		//public ICollection<RetailShop> RetailShops { get; set; }
	}
	public enum AreaType
	{
		Commercial,
		Residential
	}
}
