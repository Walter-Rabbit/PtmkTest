IF (EXISTS(select * FROM sys.views WHERE name = 'FMales'))
    SELECT v.FullName, v.BirthDate, v.Gender FROM FMales AS v
ELSE
    SELECT p.FullName, p.BirthDate, p.Gender FROM Persons AS p
    WHERE p.Gender = 'Male' AND LEFT(p.FullName, 1) = 'F'