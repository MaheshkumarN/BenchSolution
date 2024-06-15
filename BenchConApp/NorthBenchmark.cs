
using BenchConApp.Models;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BenchConApp;

[MemoryDiagnoser]
[ShortRunJob]
public class NorthBenchmark
{
  NorthDbContext? _northContext;
  List<int>? _intList;

  [Params(1_000, 10_000, 100_000)]
  public int ListSize;

  [GlobalSetup]
  public void GlobalSetup()
  {
    Console.WriteLine("Global Setup");
    _northContext = new NorthDbContext();
    
    _intList = new List<int>();
    Random rnd = new Random();
    //for (int i = 0; i < 1000; i++)
    for (int i = 0; i < ListSize; i++)
    {
      _intList.Add(rnd.Next(0, 1000));
    }
  }


  [Benchmark]
  public async Task GetAllCustomers()
  {
    var result = await _northContext!.Customers.ToListAsync();

    int ctr = 1;
    foreach (var item in result)
    {
      Console.WriteLine($"{ctr++} -- {item}");
    }
  }


  [Benchmark]
  public void Sort()
  {
    _intList!.Sort();
  }
}
