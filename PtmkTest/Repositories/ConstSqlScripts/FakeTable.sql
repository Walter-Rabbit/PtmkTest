DECLARE @counter INT
SET @counter = 0

WHILE @counter < 9999
    BEGIN
        INSERT INTO Persons
        SELECT TRANSLATE(LEFT(RAND() * 1000, 3), '0123456789.', 'QWERTYUIOAN'),
               CAST(GETDATE() - CAST(RAND() * 50000 AS INT) AS Date),
               IIF(RAND() > 0.5, 'Male', 'Female')
        SET @counter = @counter + 1
    END

SET
    @counter = 0

WHILE @counter < 1
    BEGIN
        INSERT INTO Persons
        SELECT 'F' + TRANSLATE(LEFT(RAND() * 1000, 2), '0123456789.', 'QWERTYUIOAN'),
               CAST(GETDATE() - CAST(RAND() * 50000 AS INT) AS Date),
               IIF(RAND() > 0.5, 'Male', 'Female')
        SET @counter = @counter + 1
    END