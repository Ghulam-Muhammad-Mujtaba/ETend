using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ETend.Models
{
	public class House
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int AreaId { get; set; }

		[ForeignKey("AreaId")]
		[ValidateNever]
		public Area Area { get; set; }

		[Required]
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
	}
}
