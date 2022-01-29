CREATE DATABASE Seguritas
GO
USE Seguritas
GO
CREATE TABLE Cliente
(
	IdCliente INT PRIMARY KEY,
	Nombre VARCHAR(50) UNIQUE NOT NULL,
	ApellidoPaterno VARCHAR(20),
	ApellidoMaterno VARCHAR(20),
	FechaModificacion DATETIME
)
GO
CREATE TABLE Planes
(
	IdPlan INT PRIMARY KEY,
	Descripcion VARCHAR(50) NOT NULL,
	FechaModificacion DATE
)
GO
CREATE TABLE Cobertura
(
	IdCobertura INT PRIMARY KEY,
	Descripcion VARCHAR(50) NOT NULL,
	FechaModificacion DATE
)
GO
CREATE TABLE ClientePlanes
(
	IdClientePlanes INT PRIMARY KEY IDENTITY(1,1),
	IdCliente INT REFERENCES Cliente(IdCliente),
	IdPlan INT REFERENCES Planes(IdPlan)
)
GO
CREATE TABLE PlanesCobertura
(
	IdPlanesCobertura INT PRIMARY KEY IDENTITY(1,1),
	IdPlan INT REFERENCES Planes(IdPlan),
	IdCliente INT REFERENCES Cobertura(IdCobertura)
)
GO
--------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------
CREATE PROCEDURE ClienteAdd
	@ID INT,
	@Nombre VARCHAR(50),
	@ApellidoPaterno VARCHAR(20),
	@ApellidoMaterno VARCHAR(20)
	AS
		INSERT INTO Cliente
           (IdCliente
           ,Nombre
           ,ApellidoPaterno
           ,ApellidoMaterno
           ,FechaModificacion)
     VALUES
           (@ID
           ,@Nombre
           ,@ApellidoPaterno
           ,@ApellidoMaterno
           ,GETDATE())
GO
CREATE PROCEDURE ClienteUpdate
	@IdCliente INT,
	@Nombre VARCHAR(50),
	@ApellidoPaterno VARCHAR(20),
	@ApellidoMaterno VARCHAR(20)
	AS
		UPDATE Cliente
			SET Nombre = @Nombre
			,ApellidoPaterno = @ApellidoPaterno
			,ApellidoMaterno = @ApellidoMaterno
			,FechaModificacion = GETDATE()
			WHERE IdCliente = @IdCliente
GO
CREATE PROCEDURE ClienteDelete
	@IdCliente INT
	AS
		DELETE FROM Cliente
			WHERE IdCliente = @IdCliente
GO
CREATE PROCEDURE ClienteGetById
	@IdCliente INT
	AS
		SELECT [IdCliente]
			,[Nombre]
			,[ApellidoPaterno]
			,[ApellidoMaterno]
			,[FechaModificacion]
		FROM [Cliente]
			WHERE IdCliente = @IdCliente
GO
CREATE PROCEDURE ClienteGetAll
	AS
		SELECT [IdCliente]
			,[Nombre]
			,[ApellidoPaterno]
			,[ApellidoMaterno]
			,[FechaModificacion]
		FROM [Cliente]
GO
ClienteAdd 1,'Oziel','Silva','Lopez'
GO
ClienteAdd 2,'Aram','Sanchez','Rodriguez'
GO
ClienteAdd 3,'Juan','Perez','Rodriguez'
GO
ClienteAdd 4,'Caleb','Vazquez','Araujo'
GO
ClienteAdd 5,'Angelica','Guzman','Romero'
GO	