﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class BasketController : Controller
    {
        public async Task<IActionResult> AddItem(int productId, int quantity=1)
        {
            return View();
        }
    }
}
