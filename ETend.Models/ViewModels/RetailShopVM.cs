using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETend.Models.ViewModels
{
    public class RetailShopVM
    {
        public RetailShop RetailShop { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> AreaList { get; set; }

    }
}
