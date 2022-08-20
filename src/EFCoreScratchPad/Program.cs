// See https://aka.ms/new-console-template for more information
using EFCoreScratchPad.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

var config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", false)
               .Build();

var connectionString = config.GetConnectionString("DefaultConnection");

Console.WriteLine($"Connection String = {connectionString}");
Console.WriteLine();

var builder = new DbContextOptionsBuilder<ScratchPadContext>();
builder.EnableSensitiveDataLogging(true);
builder.UseSqlServer(connectionString);

using var dbContext = new ScratchPadContext(builder.Options);

Console.WriteLine("Initialise data...");
Console.WriteLine();

Data.Initialise(dbContext);

Console.WriteLine();
Console.WriteLine("Initialise data complete.");
Console.WriteLine();

Console.ReadLine();