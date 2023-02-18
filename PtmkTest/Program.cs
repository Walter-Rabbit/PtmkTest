using System.Text.Json;
using PtmkTest.Models;
using PtmkTest.Repositories;

var configuration = JsonSerializer.Deserialize<Configuration>(File.ReadAllText("configuration.json")) ??
                    throw new Exception("Incorrect configuration.");
var repository = new MsSqlRepository(configuration);

switch (args[0])
{
    case "1":
        repository.CreateTable();
        break;
    case "2":
        repository.InsertPerson(new Person(args[1], DateTime.Parse(args[2]), args[3]));
        break;
    case "3":
        var distinctPersons = repository.GetDistinctPersons();
        distinctPersons.ForEach(Console.WriteLine);
        break;
    case "4":
        repository.FakeTable();
        break;
    case "5":
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();

        var fPersons = repository.GetMalesStartingWithF();
        fPersons.ForEach(Console.WriteLine);

        watch.Stop();
        Console.WriteLine($"Execution Time: {(int)watch.ElapsedMilliseconds} ms.");
        break;
    case "6":
        repository.CreateViewMalesStartingWithF();
        break;
}