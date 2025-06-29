use [Employee Management schema]
go
-- EMPLOYEE MANAGEMENT SYSTEM SCHEMA

-- Create Departments table
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

-- Create Employees table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);

-- Insert sample data into Departments
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'Finance'),
(3, 'IT'),
(4, 'Marketing');

-- Insert sample data into Employees
INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
(4, 'Emily', 'Davis', 4, 5500.00, '2021-11-05');

-- EXERCISE 1: Stored Procedure to insert a new employee
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

-- EXERCISE 2: Stored Procedure to retrieve employee details by DepartmentID
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

-- EXERCISE 5: Stored Procedure to count employees in a department
CREATE PROCEDURE sp_CountEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        D.DepartmentName,
        COUNT(E.EmployeeID) AS TotalEmployees
    FROM Departments D
    LEFT JOIN Employees E ON D.DepartmentID = E.DepartmentID
    WHERE D.DepartmentID = @DepartmentID
    GROUP BY D.DepartmentName;
END;

-- EXECUTE stored procedure to retrieve employee details for DepartmentID = 2
EXEC sp_GetEmployeesByDepartment @DepartmentID = 2;

-- EXECUTE stored procedure to count employees in DepartmentID = 2
EXEC sp_CountEmployeesByDepartment @DepartmentID = 2;
