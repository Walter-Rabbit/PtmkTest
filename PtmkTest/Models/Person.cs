namespace PtmkTest.Models;

public class Person
{
    public Person(string fullName, DateTime birthDate, string gender)
    {
        FullName = fullName;
        BirthDate = birthDate;
        Gender = gender;
    }

    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; }

    public int Age => DateTime.Today.Year - BirthDate.Year -
                      (DateTime.Today.Month >= BirthDate.Month && DateTime.Today.Day > BirthDate.Day ? 1 : 0);

    public override string ToString()
    {
        return $"{FullName}, {BirthDate.Day}.{BirthDate.Month}.{BirthDate.Year}, {Gender}, {Age}";
    }
}