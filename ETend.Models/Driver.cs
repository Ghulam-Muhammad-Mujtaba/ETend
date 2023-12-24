using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace ETend.Models
{
	public class Driver
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[DisplayName("Vehicle Name")]
		public int VehicleId { get; set; }

		[ForeignKey("VehicleId")]
		[ValidateNever]
		public Vehicle Vehicle { get; set; }

		[Required]
		[DisplayName("Driver Name")]
		public string DriverName { get; set; }

		[Required]
		[Phone]
		[DisplayName("Phone No")]
		public string PhoneNo { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}