SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
USE FlutterAppDB;

DECLARE @i INT = 1;
DECLARE @classId INT = 1;
DECLARE @insertedUserId INT;

WHILE @classId <= 2
BEGIN
    SET @i = 1;
    WHILE @i <= 15
    BEGIN
        DECLARE @phone NVARCHAR(20) = '090' + CAST(@classId AS NVARCHAR) + RIGHT('00000' + CAST(@i AS NVARCHAR), 5) + CAST(ABS(CHECKSUM(NEWID())) % 10 AS NVARCHAR);
        DECLARE @email NVARCHAR(100) = 'student' + CAST(@classId AS NVARCHAR) + '_' + CAST(@i AS NVARCHAR) + '@fpt.edu.vn';
        DECLARE @studentId NVARCHAR(20) = 'SE' + CAST(1914 + @classId AS NVARCHAR) + RIGHT('000' + CAST(@i AS NVARCHAR), 3);
        DECLARE @fullName NVARCHAR(100) = N'Học sinh ' + CAST(@i AS NVARCHAR) + N' Lớp ' + CAST(@classId AS NVARCHAR);

        IF NOT EXISTS (SELECT 1 FROM Users WHERE Email = @email OR PhoneNumber = @phone)
        BEGIN
            INSERT INTO Users (Email, Password, FullName, StudentId, ClassId, PhoneNumber)
            VALUES (@email, 'password123', @fullName, @studentId, @classId, @phone);

            SET @insertedUserId = SCOPE_IDENTITY();

            INSERT INTO UserRoles (UserId, RoleId)
            VALUES (@insertedUserId, 2);
        END
        SET @i = @i + 1;
    END
    SET @classId = @classId + 1;
END
