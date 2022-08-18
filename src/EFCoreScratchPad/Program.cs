// See https://aka.ms/new-console-template for more information
using EFCoreScratchPad.Data;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", false)
               .Build();

using var dbContext = new ScratchPadContext(config.GetConnectionString("DefaultConnection"));

Console.WriteLine($"Connection String = {dbContext.ConnectionString}");
Console.WriteLine();

Console.ReadLine();