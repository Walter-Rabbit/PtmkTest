using System.Data;
using System.Data.SqlClient;
using System.Text;
using PtmkTest.Models;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;

namespace PtmkTest.Repositories;

public class MsSqlRepository : IRepository
{
    private readonly Configuration _configuration;
    private readonly SqlConnection _sqlConnection;

    public MsSqlRepository(Configuration configuration)
    {
        _configuration = configuration;
        _sqlConnection = new SqlConnection(_configuration.ConnectionString);
        _sqlConnection.Open();
    }

    public void CreateTable()
    {
        using var command = _sqlConnection.CreateCommand();
        command.CommandText = "CREATE TABLE Persons (" +
                              "Id int IDENTITY(1,1) PRIMARY KEY, " +
                              "FullName nchar(100) NOT NULL, " +
                              "BirthDate date NOT NULL, " +
                              "Gender nchar(100) Not Null)";
        command.ExecuteNonQuery();
    }

    public void InsertPerson(Person person)
    {
        var fullName = person.FullName;
        var birthDate = person.BirthDate;
        var gender = person.Gender;

        using var command = _sqlConnection.CreateCommand();
        command.CommandText = "INSERT INTO Persons " +
                              $"VALUES ('{fullName}', '{birthDate}', '{gender}')";
        command.ExecuteNonQuery();
    }

    public List<Person> GetDistinctPersons()
    {
        using var command = _sqlConnection.CreateCommand();
        command.CommandText = File.ReadAllText("Repositories/ConstSqlScripts/GetDistinctPersons.sql");

        var reader = command.ExecuteReader();

        var persons = new List<Person>();
        while (reader.Read())
        {
            var data = (IDataRecord)reader;
            var fullName = (string)data[0];
            var birthDate = (DateTime)data[1];
            var gender = (string)data[2];

            persons.Add(new Person(fullName.Trim(), birthDate, gender.Trim()));
        }

        return persons;
    }

    public void FakeTable()
    {
        using var command = _sqlConnection.CreateCommand();
        command.CommandTimeout = 300;
        command.CommandText = "DELETE FROM Persons";
        command.ExecuteNonQuery();

        var commandText = File.ReadAllText("Repositories/ConstSqlScripts/FakeTable.sql");
        command.CommandText = commandText;
        for (var i = 0; i < 100; i++)
        {
            command.ExecuteNonQuery();
        }
    }

    public List<Person> GetMalesStartingWithF()
    {
        using var command = _sqlConnection.CreateCommand();
        command.CommandText = File.ReadAllText("Repositories/ConstSqlScripts/GetMalesStartingWithF.sql");
        var reader = command.ExecuteReader();

        var persons = new List<Person>();
        while (reader.Read())
        {
            var data = (IDataRecord)reader;
            var fullName = (string)data[0];
            var birthDate = (DateTime)data[1];
            var gender = (string)data[2];

            persons.Add(new Person(fullName.Trim(), birthDate, gender.Trim()));
        }

        return persons;
    }

    public void CreateViewMalesStartingWithF()
    {
        using var command = _sqlConnection.CreateCommand();

        command.CommandText = "DROP VIEW FMales";
        command.ExecuteNonQuery();
        
        command.CommandText = File.ReadAllText("Repositories/ConstSqlScripts/CreateViewMalesStartingWithF.sql");
        command.ExecuteNonQuery();

        command.CommandText = File.ReadAllText("Repositories/ConstSqlScripts/CreateIndex.sql");
        command.ExecuteNonQuery();
    }
}