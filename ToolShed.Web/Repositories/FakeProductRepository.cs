using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolShed.Web.Models;

namespace ToolShed.Web.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products => new List<Product>
        {
            new Product { Name = "AFG KS55-2", Price = 1295, Description = "Lorem ipsum dolor sit amet." },
            new Product { Name = "Bosch GK5 165", Price = 1275, Description = "Lorem ipsum dolor sit amet." },
            new Product { Name = "DeWalt DWE550", Price = 1190, Description = "Lorem ipsum dolor sit amet." },
            new Product { Name = "Festool HK 55 EBQ-Plus", Price = 3695, Description = "Lorem ipsum dolor sit amet." }
        };
    }
}
