using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETend.Models
{
	public class Vehicle
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[DisplayName("Vehicle Name")]
		public string VehicleName { get; set; }

		[Required]
		[DisplayName("Vehicle No")]
		[ValidateNever]
		public string VehicleNo { get; set; }

		[Required]
		public string? Source { get; set; }

		[Required]
		public string? Destination { get; set; }

		// Navigation Property
		//public ICollection<Driver> Drivers { get; set; }
	}
}
