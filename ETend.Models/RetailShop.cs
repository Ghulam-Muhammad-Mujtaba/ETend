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
	public class RetailShop
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int AreaId { get; set; }

		[ForeignKey("AreaId")]
		[ValidateNever]
		public Area Area { get; set; }

		[Required]
		public string ShopName { get; set; }

		[Required]
		public string ShopOwner { get; set; }

		[Required]
		public string ShopAddress { get; set; }
		[Required]
		public string PhoneNumber { get; set; }
	}
}
