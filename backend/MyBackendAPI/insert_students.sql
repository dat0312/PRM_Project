SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
USE FlutterAppDB;
INSERT INTO Users (Email, Password, FullName, StudentId, ClassId, PhoneNumber)
VALUES
('student1@fpt.edu.vn', 'password123', N'Nguyễn Văn A', 'SE191601', 1, '0981111111'),
('student2@fpt.edu.vn', 'password123', N'Trần Thị B', 'SE191602', 1, '0982222222'),
('student3@fpt.edu.vn', 'password123', N'Lê Văn C', 'SE191603', 1, '0983333333'),
('student4@fpt.edu.vn', 'password123', N'Phạm Thị D', 'SE191604', 1, '0984444444'),
('student5@fpt.edu.vn', 'password123', N'Hoàng Văn E', 'SE191605', 1, '0985555555');

DECLARE @s1 INT = (SELECT Id FROM Users WHERE Email = 'student1@fpt.edu.vn');
DECLARE @s2 INT = (SELECT Id FROM Users WHERE Email = 'student2@fpt.edu.vn');
DECLARE @s3 INT = (SELECT Id FROM Users WHERE Email = 'student3@fpt.edu.vn');
DECLARE @s4 INT = (SELECT Id FROM Users WHERE Email = 'student4@fpt.edu.vn');
DECLARE @s5 INT = (SELECT Id FROM Users WHERE Email = 'student5@fpt.edu.vn');

INSERT INTO UserRoles (UserId, RoleId)
VALUES
(@s1, 2),
(@s2, 2),
(@s3, 2),
(@s4, 2),
(@s5, 2);
