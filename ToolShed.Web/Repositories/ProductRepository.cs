using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolShed.Web.DataAccess;
using ToolShed.Web.Models;

namespace ToolShed.Web.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext ctx;
        public ProductRepository(ApplicationDbContext context)
        {
            ctx = context;
        }
        public IEnumerable<Product> Products => ctx.Products;
    }
}
