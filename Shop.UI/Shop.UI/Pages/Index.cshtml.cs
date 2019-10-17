﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Products;
using Shop.Database;

namespace Shop.UI.Pages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext dbContext;

        public IndexModel(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }

        [BindProperty]
        public ProductViewModel Product { set; get; }

        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
        
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
           await new CreateProduct(dbContext).Do(Product.Name, Product.Description, Product.Value);

            return RedirectToPage("Index");
        }
    }
}
