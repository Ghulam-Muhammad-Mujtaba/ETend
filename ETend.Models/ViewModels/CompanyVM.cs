﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETend.Models.ViewModels
{
    public class CompanyVM
    {
        public Company Company{ get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> AreaList { get; set; }

    }
}
