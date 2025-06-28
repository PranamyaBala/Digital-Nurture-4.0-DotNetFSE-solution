CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);

INSERT INTO Departments (DepartmentID, DepartmentName) VALUES (1, 'HR'), (2, 'Finance'), (3, 'IT'), (4, 'Marketing');
SELECT * FROM Departments;

INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
('John', 'Doe', 1, 5000.00, '2020-01-15'), ('Jane', 'Smith', 2, 6000.00, '2019-03-22'),
('Michael', 'Johnson', 3, 7000.00, '2018-07-30'), ('Emily', 'Davis', 4, 5500.00, '2021-11-05');
SELECT * FROM Employees;

--Create Stored Procedure to Get Employees by Department

GO
CREATE PROCEDURE sp_GetEmployeesByDepartment 
	@DepartmentID INT
AS
BEGIN
    SELECT 
        E.EmployeeID,
        E.FirstName,
        E.LastName,
        D.DepartmentName,
        E.Salary,
        E.JoinDate
    FROM Employees E
    INNER JOIN Departments D ON E.DepartmentID = D.DepartmentID
    WHERE E.DepartmentID = @DepartmentID;
END;

--Test sp_GetEmployeesByDepartment

EXEC sp_GetEmployeesByDepartment @DepartmentID = 2;

--Create sp_InsertEmployee Procedure

GO
CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10,2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) 
	VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;

--Test sp_InsertEmployee

EXEC sp_InsertEmployee 
    @FirstName = 'Amit',
    @LastName = 'Kumar',
    @DepartmentID = 3,
    @Salary = 6500.00,
    @JoinDate = '2022-08-01';

--Verify

SELECT * FROM Employees;


