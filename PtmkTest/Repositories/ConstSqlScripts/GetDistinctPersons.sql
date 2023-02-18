SELECT rankedP.FullName, rankedP.BirthDate, rankedP.Gender
FROM (SELECT *, DENSE_RANK() OVER (PARTITION BY FullName, BirthDate ORDER BY Id) AS Rank FROM Persons) AS rankedP
WHERE rankedP.Rank = 1