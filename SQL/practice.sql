CREATE TABLE Groups
(
Group_Id INT,
Group_Name VARCHAR (30),
CONSTRAINT PK_Group PRIMARY KEY (Group_Id)
);

CREATE TABLE Students
(
Student_Id INT,
Group_Id INT,
Student_Name VARCHAR (30),
CONSTRAINT PK_Student PRIMARY KEY (Student_Id),
CONSTRAINT FK_StudentsGroups FOREIGN KEY (Group_Id) REFERENCES Groups(Group_Id)
);

INSERT INTO Groups(Group_Id, group_name) 
VALUES(1, '17-MOA');

INSERT INTO Groups(Group_Id, group_name) 
VALUES(2, '16-PRI');

INSERT INTO Groups(Group_Id, group_name) 
VALUES(3, '18-IVT');

INSERT INTO Groups(Group_Id, group_name) 
VALUES(4, '19-PM');

INSERT INTO Students (Student_Id, Group_Id, Student_Name)
VALUES (1, 3, 'Ivanov E.A.');

INSERT INTO Students (Student_Id, Group_Id, Student_Name)
VALUES (2, 2, 'Petrov B.E.');

INSERT INTO Students (Student_Id, Group_Id, Student_Name)
VALUES (3, 4, 'Zuev V.E.');

INSERT INTO Students (Student_Id, Group_Id, Student_Name)
VALUES (4, 1, 'Vlasova A.P.');

INSERT INTO Students (Student_Id, Group_Id, Student_Name)
VALUES (5, 4, 'Zueva E.S.');
