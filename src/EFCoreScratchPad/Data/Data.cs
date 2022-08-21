using EFCoreScratchPad.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace EFCoreScratchPad.Data
{
    public class Data
    {
        private ScratchPadContext scratchPadContext;
        private Dictionary<string, Project> projects = new();

        private Data(ScratchPadContext scratchPadContext)
        {
            this.scratchPadContext = scratchPadContext;
        }

        public static void Initialise(ScratchPadContext scratchPadContext)
        {
            var instance = new Data(scratchPadContext);
            instance.Run();
        }

        private void Run()
        {
            ClearData();
            CreateProjects();
            CreateCustomersAndProducts();
            CreateRedressCases();
        }

        private void ClearData()
        {
            scratchPadContext.Database.ExecuteSqlRaw("DELETE FROM Redresses");
            scratchPadContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT (Redresses, RESEED, 1)");
            scratchPadContext.Database.ExecuteSqlRaw("DELETE FROM Projects");
            scratchPadContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT (Projects, RESEED, 1)");
            scratchPadContext.Database.ExecuteSqlRaw("DELETE FROM Products");
            scratchPadContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT (Products, RESEED, 1)");
            scratchPadContext.Database.ExecuteSqlRaw("DELETE FROM Customers");
            scratchPadContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT (Customers, RESEED, 1)");
        }

        private void CreateProjects()
        {
            projects.Add(
                "IRMS",
                new Project
                {
                    Name = "IRMS",
                    Description = "Interest Rate Missold",
                    Compensation = 400.00m,
                    CompensatoryInterest = 5.00m,
                    ProductType = ProductType.Vehicle
                });

            projects.Add(
                "BTL-IOC",
                new Project
                {
                    Name = "BTL-RP",
                    Description = "Buy To Let Mortgage Redemption Penalty",
                    Compensation = 1500.00m,
                    CompensatoryInterest = 7.50m,
                    ProductType = ProductType.Home
                });

            projects.Add(
                "STULIOC",
                new Project
                {
                    Name = "STULIOC",
                    Description = "Student Loan Introductory Offer Conversion",
                    Compensation = 275.00m,
                    CompensatoryInterest = 3.75m,
                    ProductType = ProductType.Student
                });

            foreach (var project in projects.Values)
            {
                scratchPadContext.Projects.Add(project);
            }

            scratchPadContext.SaveChanges();
        }

        private void CreateCustomersAndProducts()
        {
            List<Customer> customers = new();

            var customerLines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "_customers.csv"));
            var productLines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "_products.csv"));

            foreach (var line in customerLines.Skip(1))
            {
                var customer = new Customer
                {
                    Name = line
                };

                var products = productLines.Where(p => p.StartsWith(line));

                foreach(var product in products)
                {
                    var p = product.Split(",");

                    customer.Products.Add(new Product
                    {
                        Name = p[1],
                        ProductType = (ProductType)Enum.Parse(typeof(ProductType), p[2]),
                        Duration = int.Parse(p[5]),
                        Rate = decimal.Parse(p[6]),
                        StartDate = DateTime.Parse(p[7]),
                        Value = decimal.Parse(p[8])
                    });
                }

                customers.Add(customer);
            }

            foreach (var customer in customers)
            {
                scratchPadContext.Customers.Add(customer);
            }

            scratchPadContext.SaveChanges();
        }

        private void CreateRedressCases()
        {
            var projects = scratchPadContext.Projects.ToList();

            var products = scratchPadContext.Products
                .Include(p => p.Customer)
                .ToList();

            var redresses = (from proj in projects
                        join prod in products on proj.ProductType equals prod.ProductType
                        where proj.ProductType.Equals(ProductType.Home)
                        || proj.ProductType.Equals(ProductType.Vehicle)
                        select new Redress
                        {
                            Project = proj,
                            Product = prod,
                        }).ToList();

            scratchPadContext.Redresses.AddRange(redresses);

            scratchPadContext.SaveChanges();
        }
    }
}