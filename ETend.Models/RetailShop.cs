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
	public class RetailShop
	{
		[Key]
		public int Id { get; set; }

		[Required]
        [DisplayName("Area Name")]
        public int AreaId { get; set; }

		[ForeignKey("AreaId")]
		[ValidateNever]
		public Area Area { get; set; }

		[Required]
		[DisplayName("Shop Name")]
		public string ShopName { get; set; }

		[Required]
        [DisplayName("Shop Owner")]
        public string ShopOwner { get; set; }

		[Required]
        [DisplayName("Shop Address")]
        public string ShopAddress { get; set; }
		[Required]
        [DisplayName("Phone No.")]

        public string PhoneNumber { get; set; }
	}
}
