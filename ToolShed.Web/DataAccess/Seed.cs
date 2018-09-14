using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolShed.Web.Models;

namespace ToolShed.Web.DataAccess
{
    public static class Seed
    {
        internal static void FillIfEmpty(ApplicationDbContext ctx)
        {
            if (!ctx.Categories.Any())
            {
                ctx.Categories.Add(new Category { Name = "Cirkelsågar" });
                ctx.Categories.Add(new Category { Name = "Skruvdragare" });
                ctx.SaveChanges();
            }

            if (!ctx.Products.Any())
            {
                var products = new List<Product>
                {
                    // Cirkelsågar
                    new Product { Name = "AFG KS55-2", Price = 1295, Description = "Lorem ipsum dolor sit amet.", CategoryId = 1 },
                    new Product { Name = "Bosch GK5 165", Price = 1275, Description = "Lorem ipsum dolor sit amet.", CategoryId = 1 },
                    new Product { Name = "DeWalt DWE550", Price = 1190, Description = "Lorem ipsum dolor sit amet.", CategoryId = 1 },
                    new Product { Name = "Festool HK 55 EBQ-Plus", Price = 3695, Description = "Lorem ipsum dolor sit amet.", CategoryId = 1 },
                    // Skruvdragare
                    new Product { Name = "Bosch GDR 10,8V", Price = 2365, Description = "Lorem ipsum dolor sit amet.", CategoryId = 2 },
                    new Product { Name = "Bosch PSR 10,8 LI-2", Price = 1349, Description = "Lorem ipsum dolor sit amet.", CategoryId = 2 },
                    new Product { Name = "DeWalt DCF835M2", Price = 3599, Description = "Lorem ipsum dolor sit amet.", CategoryId = 2 },
                    new Product { Name = "FEIN ASCM 12 C", Price = 3270, Description = "Lorem ipsum dolor sit amet.", CategoryId = 2 }
                };
                ctx.Products.AddRange(products);
                ctx.SaveChanges();
            }
        }
    }
}
