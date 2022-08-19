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
        }

        private void ClearData()
        {
            scratchPadContext.Database.ExecuteSqlRaw("DELETE FROM Projects");
            scratchPadContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT (Projects, RESEED, 1)");
            scratchPadContext.Database.ExecuteSqlRaw("DELETE FROM Products");
            scratchPadContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT (Products, RESEED, 1)");
            scratchPadContext.Database.ExecuteSqlRaw("DELETE FROM Customers");
            scratchPadContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT (Customers, RESEED, 1)");
            scratchPadContext.Database.ExecuteSqlRaw("DELETE FROM Redresses");
            scratchPadContext.Database.ExecuteSqlRaw("DBCC CHECKIDENT (Redresses, RESEED, 1)");
        }

        private void CreatePrograms()
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

        private void CreateCustomers()
        {
            List<Customer> customers = new();

            var lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "customers.csv"));

            foreach (var line in lines.Skip(1))
            {
                var c = line.Split(',');

                var customer = new Customer
                {
                    Name = $"{c[0]} {c[1]} {c[2]}"
                };

                customer.Products.Add(new Product
                {
                    Name = c[11],
                    ProductType = (ProductType)Enum.Parse(typeof(ProductType), c[12]),
                    Duration = int.Parse(c[15]),
                    Rate = decimal.Parse(c[16]),
                    StartDate = DateTime.Parse(c[17]),
                    Value = decimal.Parse(c[18])
                });

                customers.Add(customer);
            }

            foreach (var customer in customers)
            {
                scratchPadContext.Customers.Add(customer);
            }

            scratchPadContext.SaveChanges();
        }
    }
}