USE MATUTEBD
GO

CREATE TABLE PRODUCTOS (
    Codigo INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(200) NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    Stock INT NOT NULL,
    Categoria VARCHAR(50) NOT NULL
)
GO
