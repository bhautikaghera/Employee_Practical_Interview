**Stored Procedure Database Script**

**Get All Employees Records**

CREATE PROCEDURE [dbo].[GetAllEmployees]
AS
BEGIN
    SELECT * FROM employees
END

**Get Employee By Id Record**

CREATE PROCEDURE [dbo].[GetEmployeeById]
    @Id INT
AS
BEGIN
    SELECT * FROM employees WHERE Id = @Id
END

**Insert Employee Record**

CREATE PROCEDURE [dbo].[InsertEmployee]
    @Name NVARCHAR(50),
    @Email NVARCHAR(50),
    @Phone NVARCHAR(15),
    @Address NVARCHAR(250),
    @State NVARCHAR(50),
    @City NVARCHAR(50)
AS
BEGIN
    INSERT INTO employees (Name, Email, Phone, Address, State, City)
    VALUES (@Name, @Email, @Phone, @Address, @State, @City)
END

**Update Employee Record**

CREATE PROCEDURE [dbo].[UpdateEmployee]
    @Id INT,
    @Name NVARCHAR(50),
    @Email NVARCHAR(50),
    @Phone NVARCHAR(15),
    @Address NVARCHAR(250),
    @State NVARCHAR(50),
    @City NVARCHAR(50)
AS
BEGIN
    UPDATE employees
    SET Name = @Name, Email = @Email, Phone = @Phone, Address = @Address, State = @State, City = @City
    WHERE Id = @Id
END

**Delete Employee Record**

CREATE PROCEDURE [dbo].[DeleteEmployee]
    @Id INT
AS
BEGIN
    DELETE FROM employees WHERE Id = @Id
END
