CREATE VIEW FMales
            WITH SCHEMABINDING
AS
SELECT p.FullName, p.BirthDate, p.Gender
FROM dbo.Persons AS p
WHERE p.Gender = 'Male'
  AND LEFT(p.FullName, 1) = 'F'