using PtmkTest.Models;

namespace PtmkTest.Repositories;

public interface IRepository
{
    void CreateTable();
    void InsertPerson(Person person);
    List<Person> GetDistinctPersons();
    void FakeTable();
    List<Person> GetMalesStartingWithF();
    void CreateViewMalesStartingWithF();
}