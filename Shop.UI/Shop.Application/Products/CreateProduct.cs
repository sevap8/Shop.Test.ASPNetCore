using Shop.Database;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Products
{
    public class CreateProduct
    {
        private readonly ApplicationDbContext dbContext;

        public CreateProduct(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Do(string Name, string Description, decimal Value)
        {
            dbContext.Products.Add(new Product { Name = Name, Description = Description, Value = Value });

            await dbContext.SaveChangesAsync();
        }
    }
}
