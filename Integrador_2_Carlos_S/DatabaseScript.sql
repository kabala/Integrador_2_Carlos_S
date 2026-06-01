CREATE DATABASE ClientesDB;
GO

USE ClientesDB;
GO

CREATE TABLE Clientes (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre NVARCHAR(100) NOT NULL,
	Apellido NVARCHAR(100) NOT NULL,
	Email NVARCHAR(150) NOT NULL UNIQUE,
	Telefono NVARCHAR(20),
	Direccion NVARCHAR(200),
	Ciudad NVARCHAR(100),
	CodigoPostal NVARCHAR(10),
	FechaNacimiento DATE,
	Activo BIT DEFAULT 1,
	FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

INSERT INTO Clientes (Nombre, Apellido, Email, Telefono, Direccion, Ciudad, CodigoPostal, FechaNacimiento, Activo)
VALUES 
('Juan', 'Pérez', 'juan.perez@email.com', '555-0101', 'Calle Principal 123', 'Madrid', '28001', '1985-05-15', 1),
('María', 'García', 'maria.garcia@email.com', '555-0102', 'Avenida Central 456', 'Barcelona', '08001', '1990-08-22', 1),
('Carlos', 'López', 'carlos.lopez@email.com', '555-0103', 'Plaza Mayor 789', 'Valencia', '46001', '1988-12-10', 1);
GO
