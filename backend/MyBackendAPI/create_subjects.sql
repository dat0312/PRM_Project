SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
USE FlutterAppDB;

-- Create Subjects table
CREATE TABLE Subjects (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Code NVARCHAR(20) NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Grade INT NOT NULL,
    [Group] NVARCHAR(50) NOT NULL
);

-- Create TeacherSubjects table
CREATE TABLE TeacherSubjects (
    TeacherId INT NOT NULL,
    SubjectId INT NOT NULL,
    PRIMARY KEY (TeacherId, SubjectId),
    FOREIGN KEY (TeacherId) REFERENCES Users(Id) ON DELETE CASCADE,
    FOREIGN KEY (SubjectId) REFERENCES Subjects(Id) ON DELETE CASCADE
);

-- Insert Subjects Grade 10
INSERT INTO Subjects (Code, Name, Grade, [Group]) VALUES
('TOAN10', N'Toán học', 10, N'Bắt buộc'),
('VAN10', N'Ngữ văn', 10, N'Bắt buộc'),
('ANH10', N'Tiếng Anh', 10, N'Bắt buộc'),
('LY10', N'Vật lý', 10, N'Tự nhiên'),
('HOA10', N'Hóa học', 10, N'Tự nhiên'),
('SINH10', N'Sinh học', 10, N'Tự nhiên'),
('SU10', N'Lịch sử', 10, N'Xã hội'),
('DIA10', N'Địa lý', 10, N'Xã hội');

-- Insert Subjects Grade 11
INSERT INTO Subjects (Code, Name, Grade, [Group]) VALUES
('TOAN11', N'Toán học', 11, N'Bắt buộc'),
('VAN11', N'Ngữ văn', 11, N'Bắt buộc'),
('ANH11', N'Tiếng Anh', 11, N'Bắt buộc'),
('LY11', N'Vật lý', 11, N'Tự nhiên'),
('HOA11', N'Hóa học', 11, N'Tự nhiên'),
('SINH11', N'Sinh học', 11, N'Tự nhiên'),
('SU11', N'Lịch sử', 11, N'Xã hội'),
('DIA11', N'Địa lý', 11, N'Xã hội');

-- Insert Subjects Grade 12
INSERT INTO Subjects (Code, Name, Grade, [Group]) VALUES
('TOAN12', N'Toán học', 12, N'Bắt buộc'),
('VAN12', N'Ngữ văn', 12, N'Bắt buộc'),
('ANH12', N'Tiếng Anh', 12, N'Bắt buộc'),
('LY12', N'Vật lý', 12, N'Tự nhiên'),
('HOA12', N'Hóa học', 12, N'Tự nhiên'),
('SINH12', N'Sinh học', 12, N'Tự nhiên'),
('SU12', N'Lịch sử', 12, N'Xã hội'),
('DIA12', N'Địa lý', 12, N'Xã hội');

-- Link Teacher 3 to some subjects
DECLARE @tId INT = 3;
INSERT INTO TeacherSubjects (TeacherId, SubjectId)
SELECT @tId, Id FROM Subjects WHERE Code IN ('TOAN10', 'TOAN11', 'TOAN12');
