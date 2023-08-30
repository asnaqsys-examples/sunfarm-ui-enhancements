﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SunFarmSite.Pages.Asna
{
    public class EoJModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.Remove("ASNA_SingleJobNumber");
        }
    }
}