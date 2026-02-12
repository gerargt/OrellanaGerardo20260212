
CREATE DATABASE [OrellanaGerardo20260212];
GO

USE [OrellanaGerardo20260212];
GO

CREATE TABLE dbo.Clients
(
    Country NVARCHAR(100) NOT NULL,
    Id      NVARCHAR(50)  NOT NULL,
    Name    NVARCHAR(150) COLLATE Latin1_General_CI_AI NOT NULL,
    Phone   NVARCHAR(30)  NOT NULL,
    Category INT          NOT NULL,
    CONSTRAINT PK_Clients PRIMARY KEY (Country, Id)
);
GO


INSERT INTO dbo.Clients (Country, Id, Name, Phone, Category) VALUES
(N'El Salvador', N'0023188245', N'Elena Núñez',  N'+50366986544', 1),
(N'Honduras',    N'33295443000',N'Haydé Recinos',N'+50477523651', 2),
(N'Guatemala',   N'5503280432', N'Raul Menendez',N'+50299873622', 1);
GO

