-- Crear Base de Datos
CREATE DATABASE InvoiceDB;
GO

USE InvoiceDB;
GO

-- Tabla principal
CREATE TABLE Invoices (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ClientName NVARCHAR(150) NOT NULL,
    Amount DECIMAL(18,2) NOT NULL,
    IssueDate DATETIME NOT NULL
);
GO

-- Stored Procedure: Crear factura
CREATE PROCEDURE sp_CreateInvoice
    @ClientName NVARCHAR(150),
    @Amount DECIMAL(18,2),
    @IssueDate DATETIME
AS
BEGIN
    INSERT INTO Invoices (ClientName, Amount, IssueDate)
    VALUES (@ClientName, @Amount, @IssueDate);

    SELECT SCOPE_IDENTITY() AS Id;
END
GO

-- Stored Procedure: Buscar por Id
CREATE PROCEDURE sp_GetInvoiceById
    @Id INT
AS
BEGIN
    SELECT * FROM Invoices WHERE Id = @Id;
END
GO

-- Stored Procedure: Buscar por Cliente
CREATE PROCEDURE sp_GetInvoicesByClient
    @ClientName NVARCHAR(150)
AS
BEGIN
    SELECT * 
    FROM Invoices
    WHERE ClientName LIKE '%' + @ClientName + '%'
    ORDER BY IssueDate DESC;
END
GO

-- Índice para búsqueda eficiente
CREATE INDEX IX_Invoices_ClientName ON Invoices(ClientName);
GO
