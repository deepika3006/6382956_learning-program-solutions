use [Employee Management schema]
go

-- Drop tables if they exist
IF OBJECT_ID('Employees', 'U') IS NOT NULL DROP TABLE Employees;
IF OBJECT_ID('Departments', 'U') IS NOT NULL DROP TABLE Departments;

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
(2, 'IT'),
(3, 'Finance');

-- Insert sample data into Employees
INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Bob', 'Johnson', 3, 5500.00, '2021-07-01');

-- Drop function if it already exists
-- Drop the function if it already exists
IF OBJECT_ID('dbo.GetEmployeeFullName', 'FN') IS NOT NULL
    DROP FUNCTION dbo.GetEmployeeFullName;
GO

-- Now CREATE FUNCTION as the first statement in a new batch
CREATE FUNCTION dbo.GetEmployeeFullName
(
    @EmpID INT
)
RETURNS VARCHAR(101)
AS
BEGIN
    DECLARE @FullName VARCHAR(101);

    SELECT @FullName = FirstName + ' ' + LastName
    FROM Employees
    WHERE EmployeeID = @EmpID;

    RETURN @FullName;
END;
GO
-- Test by passing a specific EmployeeID
SELECT dbo.GetEmployeeFullName(2) AS FullName;
SELECT 
    EmployeeID,
    dbo.GetEmployeeFullName(EmployeeID) AS FullName,
    Salary
FROM Employees;
