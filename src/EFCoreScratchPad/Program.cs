// See https://aka.ms/new-console-template for more information
using EFCoreScratchPad.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", false)
               .Build();
var connectionString = config.GetConnectionString("DefaultConnection");

Console.WriteLine($"Connection String = {connectionString}");

var builder = new DbContextOptionsBuilder<ScratchPadContext>();
builder.UseSqlServer(connectionString);
using var dbContext = new ScratchPadContext(builder.Options);

Console.WriteLine();

Console.ReadLine();