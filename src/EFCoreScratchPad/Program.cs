// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", false)
               .Build();

Console.WriteLine($"DefaultConnection = {config.GetConnectionString("DefaultConnection")}");

Console.ReadLine();