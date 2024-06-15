using BenchConApp;
using BenchConApp.Models;
using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

//NorthDbContext context = new NorthDbContext();

#region Get All Customers
//var result = await context.Customers.ToListAsync();

//int ctr = 1;
//foreach (var item in result)
//{
//	Console.WriteLine($"{ctr++} -- {item}");
//} 
#endregion

#region Get all customers from London
//var result = await context.Customers.Where(c=>c.City == "London").ToListAsync();

//int ctr = 1;
//foreach (var item in result)
//{
//  Console.WriteLine($"{ctr++} -- {item}"); 
//}
#endregion

//var summary= BenchmarkRunner.Run<NorthBenchmark>();
BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args);
NorthBenchmark northBenchmark = new NorthBenchmark();

await northBenchmark.GetAllCustomers();
northBenchmark.Sort();
