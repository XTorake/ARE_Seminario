USE [master]
GO
/****** Object:  Database [ARE_Seminario]    Script Date: 31/5/2020 22:24:34 ******/
CREATE DATABASE [ARE_Seminario]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ARE_Seminario', FILENAME = N'E:\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ARE_Seminario.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ARE_Seminario_log', FILENAME = N'E:\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ARE_Seminario_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ARE_Seminario] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ARE_Seminario].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ARE_Seminario] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ARE_Seminario] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ARE_Seminario] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ARE_Seminario] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ARE_Seminario] SET ARITHABORT OFF 
GO
ALTER DATABASE [ARE_Seminario] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ARE_Seminario] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ARE_Seminario] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ARE_Seminario] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ARE_Seminario] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ARE_Seminario] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ARE_Seminario] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ARE_Seminario] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ARE_Seminario] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ARE_Seminario] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ARE_Seminario] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ARE_Seminario] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ARE_Seminario] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ARE_Seminario] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ARE_Seminario] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ARE_Seminario] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ARE_Seminario] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ARE_Seminario] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ARE_Seminario] SET  MULTI_USER 
GO
ALTER DATABASE [ARE_Seminario] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ARE_Seminario] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ARE_Seminario] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ARE_Seminario] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ARE_Seminario] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ARE_Seminario] SET QUERY_STORE = OFF
GO
USE [ARE_Seminario]
GO
/****** Object:  Table [dbo].[EncabezadoFactura]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EncabezadoFactura](
	[idEncabezado] [varchar](5) NOT NULL,
	[idEstudiante] [varchar](30) NOT NULL,
	[fechaPago] [datetime] NOT NULL,
	[direccion] [varchar](100) NULL,
	[descuento] [float] NOT NULL,
	[totalPagar] [float] NOT NULL,
	[totalCobrar] [float] NOT NULL,
 CONSTRAINT [PK_EncabezadoFactura] PRIMARY KEY CLUSTERED 
(
	[idEncabezado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[idProducto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[idCategoriaProducto] [int] NOT NULL,
	[precio] [float] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LineaFactura]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LineaFactura](
	[idLinea] [int] IDENTITY(1,1) NOT NULL,
	[idProducto] [int] NOT NULL,
	[pago] [float] NOT NULL,
	[descripcion] [varchar](50) NULL,
	[idEncabezado] [varchar](5) NOT NULL,
 CONSTRAINT [PK_LineaFactura] PRIMARY KEY CLUSTERED 
(
	[idLinea] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[CuentasxMes]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CuentasxMes]
AS
SELECT        DATENAME(MONTH, e.fechaPago) AS Mes, SUM(l.pago) AS 'Pagos Recibidos', SUM(p.precio) AS 'Total Cobrado'
FROM            dbo.Producto AS p INNER JOIN
                         dbo.LineaFactura AS l ON p.idProducto = l.idProducto INNER JOIN
                         dbo.EncabezadoFactura AS e ON l.idEncabezado = e.idEncabezado
GROUP BY DATENAME(MONTH, e.fechaPago)
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[cedula] [varchar](12) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[apellido1] [varchar](20) NOT NULL,
	[apellido2] [varchar](20) NOT NULL,
	[idPais] [int] NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[usuario] [varchar](30) NOT NULL,
	[cedula] [varchar](12) NOT NULL,
	[contrasena] [varchar](200) NOT NULL,
	[idTipoUsuario] [int] NOT NULL,
	[idIglesia] [int] NULL,
	[idMetodoPago] [int] NULL,
	[idCarrera] [int] NULL,
	[isTemp] [bit] NULL,
	[loginCount] [int] NOT NULL,
	[correo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Factura_Usuario]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Factura_Usuario]
AS
SELECT        dbo.Persona.cedula AS Cedula, { fn CONCAT({ fn CONCAT({ fn CONCAT(dbo.Persona.nombre, ' ') }, { fn CONCAT(dbo.Persona.apellido1, ' ') }) }, dbo.Persona.apellido2) } AS Nombre, dbo.Usuario.usuario AS Usuario, 
                         UPPER(dbo.EncabezadoFactura.idEncabezado) AS 'N° de Factura', dbo.EncabezadoFactura.fechaPago AS 'Fecha de Pago', dbo.EncabezadoFactura.totalCobrar AS 'Total a Cobrar', 
                         dbo.EncabezadoFactura.descuento AS 'Descuento', dbo.EncabezadoFactura.totalPagar AS 'Total a Pagar', dbo.Producto.idProducto AS 'ID de Producto', dbo.LineaFactura.pago AS 'Pago Realizado', 
                         dbo.Producto.nombre AS Descripcion, dbo.Producto.precio AS Precio
FROM            dbo.Persona INNER JOIN
                         dbo.Usuario ON dbo.Persona.cedula = dbo.Usuario.cedula INNER JOIN
                         dbo.EncabezadoFactura ON dbo.Usuario.usuario = dbo.EncabezadoFactura.idEstudiante INNER JOIN
                         dbo.LineaFactura ON dbo.EncabezadoFactura.idEncabezado = dbo.LineaFactura.idEncabezado INNER JOIN
                         dbo.Producto ON dbo.LineaFactura.idProducto = dbo.Producto.idProducto
GO
/****** Object:  UserDefinedFunction [dbo].[FacturaPorUsuario]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[FacturaPorUsuario] (
    @Usuario varchar(30)
)
RETURNS TABLE
AS
RETURN
    SELECT 
        *
    FROM
       Factura_Usuario
    WHERE
        Usuario = @Usuario;
GO
/****** Object:  UserDefinedFunction [dbo].[FacturaPorMes]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[FacturaPorMes] (
    @Mes varchar(30)
)
RETURNS TABLE
AS
RETURN
    SELECT 
        *
    FROM
       Factura_Usuario
    WHERE
        MONTH([Fecha de Pago]) = @mes;
GO
/****** Object:  Table [dbo].[Auditoria]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auditoria](
	[idAuditoria] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](30) NOT NULL,
	[tablaAfectada] [varchar](30) NOT NULL,
	[columna] [varchar](30) NOT NULL,
	[valorViejo] [varchar](30) NOT NULL,
	[valorNuevo] [varchar](30) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[accion] [varchar](30) NOT NULL,
 CONSTRAINT [PK_Auditoria] PRIMARY KEY CLUSTERED 
(
	[idAuditoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrera]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrera](
	[idCarrera] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Carrera] PRIMARY KEY CLUSTERED 
(
	[idCarrera] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CarreraxCurso]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarreraxCurso](
	[idRelacion] [int] IDENTITY(1,1) NOT NULL,
	[idCarrera] [int] NOT NULL,
	[idCurso] [int] NOT NULL,
 CONSTRAINT [PK_CarreraxCurso] PRIMARY KEY CLUSTERED 
(
	[idRelacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoriaProducto]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriaProducto](
	[idCategoriaProducto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
 CONSTRAINT [PK_CategoriaProducto] PRIMARY KEY CLUSTERED 
(
	[idCategoriaProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[idCurso] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[idProfesor] [varchar](12) NOT NULL,
	[precio] [float] NOT NULL,
	[creditos] [int] NOT NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[idCurso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DistritoEclesiastico]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DistritoEclesiastico](
	[idDistritoEclesiastico] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
 CONSTRAINT [PK_DistritoEclesiastico] PRIMARY KEY CLUSTERED 
(
	[idDistritoEclesiastico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Iglesia]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Iglesia](
	[idIglesia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[idDistritoEclesiastico] [int] NOT NULL,
	[descuento] [float] NOT NULL,
 CONSTRAINT [PK_Iglesia] PRIMARY KEY CLUSTERED 
(
	[idIglesia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MetodoPago]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MetodoPago](
	[idMetodoPago] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
 CONSTRAINT [PK_MetodoPago] PRIMARY KEY CLUSTERED 
(
	[idMetodoPago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[idPais] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[codigoPais] [int] NULL,
	[descuento] [float] NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[idPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telefono]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telefono](
	[idTelefono] [int] IDENTITY(1,1) NOT NULL,
	[cedula] [varchar](12) NOT NULL,
	[telefono] [int] NOT NULL,
	[idCodigoPais] [int] NOT NULL,
 CONSTRAINT [PK_Telefono] PRIMARY KEY CLUSTERED 
(
	[idTelefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoUsuario]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoUsuario](
	[idTipoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](15) NOT NULL,
 CONSTRAINT [PK_TipoUsuario] PRIMARY KEY CLUSTERED 
(
	[idTipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_Pais]    Script Date: 31/5/2020 22:24:34 ******/
CREATE NONCLUSTERED INDEX [IX_Pais] ON [dbo].[Pais]
(
	[idPais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CarreraxCurso]  WITH CHECK ADD  CONSTRAINT [FK_CarreraxCurso_Carrera] FOREIGN KEY([idCarrera])
REFERENCES [dbo].[Carrera] ([idCarrera])
GO
ALTER TABLE [dbo].[CarreraxCurso] CHECK CONSTRAINT [FK_CarreraxCurso_Carrera]
GO
ALTER TABLE [dbo].[CarreraxCurso]  WITH CHECK ADD  CONSTRAINT [FK_CarreraxCurso_Curso] FOREIGN KEY([idCurso])
REFERENCES [dbo].[Curso] ([idCurso])
GO
ALTER TABLE [dbo].[CarreraxCurso] CHECK CONSTRAINT [FK_CarreraxCurso_Curso]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_Persona] FOREIGN KEY([idProfesor])
REFERENCES [dbo].[Persona] ([cedula])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_Persona]
GO
ALTER TABLE [dbo].[EncabezadoFactura]  WITH CHECK ADD  CONSTRAINT [FK_EncabezadoFactura_Usuario] FOREIGN KEY([idEstudiante])
REFERENCES [dbo].[Usuario] ([usuario])
GO
ALTER TABLE [dbo].[EncabezadoFactura] CHECK CONSTRAINT [FK_EncabezadoFactura_Usuario]
GO
ALTER TABLE [dbo].[Iglesia]  WITH CHECK ADD  CONSTRAINT [FK_Iglesia_DistritoEclesiastico] FOREIGN KEY([idDistritoEclesiastico])
REFERENCES [dbo].[DistritoEclesiastico] ([idDistritoEclesiastico])
GO
ALTER TABLE [dbo].[Iglesia] CHECK CONSTRAINT [FK_Iglesia_DistritoEclesiastico]
GO
ALTER TABLE [dbo].[LineaFactura]  WITH CHECK ADD  CONSTRAINT [FK_LineaFactura_EncabezadoFactura] FOREIGN KEY([idEncabezado])
REFERENCES [dbo].[EncabezadoFactura] ([idEncabezado])
GO
ALTER TABLE [dbo].[LineaFactura] CHECK CONSTRAINT [FK_LineaFactura_EncabezadoFactura]
GO
ALTER TABLE [dbo].[LineaFactura]  WITH CHECK ADD  CONSTRAINT [FK_LineaFactura_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[LineaFactura] CHECK CONSTRAINT [FK_LineaFactura_Producto]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Pais] FOREIGN KEY([idPais])
REFERENCES [dbo].[Pais] ([idPais])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Pais]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_CategoriaProducto] FOREIGN KEY([idCategoriaProducto])
REFERENCES [dbo].[CategoriaProducto] ([idCategoriaProducto])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_CategoriaProducto]
GO
ALTER TABLE [dbo].[Telefono]  WITH CHECK ADD  CONSTRAINT [FK_Telefono_Pais] FOREIGN KEY([idCodigoPais])
REFERENCES [dbo].[Pais] ([idPais])
GO
ALTER TABLE [dbo].[Telefono] CHECK CONSTRAINT [FK_Telefono_Pais]
GO
ALTER TABLE [dbo].[Telefono]  WITH CHECK ADD  CONSTRAINT [FK_Telefono_Persona] FOREIGN KEY([cedula])
REFERENCES [dbo].[Persona] ([cedula])
GO
ALTER TABLE [dbo].[Telefono] CHECK CONSTRAINT [FK_Telefono_Persona]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Carrera] FOREIGN KEY([idCarrera])
REFERENCES [dbo].[Carrera] ([idCarrera])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Carrera]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Iglesia] FOREIGN KEY([idIglesia])
REFERENCES [dbo].[Iglesia] ([idIglesia])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Iglesia]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_MetodoPago] FOREIGN KEY([idMetodoPago])
REFERENCES [dbo].[MetodoPago] ([idMetodoPago])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_MetodoPago]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Persona] FOREIGN KEY([cedula])
REFERENCES [dbo].[Persona] ([cedula])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Persona]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_TipoUsuario] FOREIGN KEY([idTipoUsuario])
REFERENCES [dbo].[TipoUsuario] ([idTipoUsuario])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_TipoUsuario]
GO
/****** Object:  StoredProcedure [dbo].[DetallesCarrera]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create     PROCEDURE [dbo].[DetallesCarrera] (
@idCarrera        int

)  
AS
	BEGIN  
	   SELECT *  
            FROM   Carrera
			where idCarrera = @idCarrera
	END   
	    
GO
/****** Object:  StoredProcedure [dbo].[DetallesPersona]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[DetallesPersona] (
@cedula         VARCHAR(12)

)  
AS
	BEGIN  
	   SELECT *  
            FROM   Persona 
			where cedula = @cedula
	END   
	    
GO
/****** Object:  StoredProcedure [dbo].[EditarCarrera]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     PROCEDURE [dbo].[EditarCarrera] (
@idCarrera        int  ,
@nombre			VARCHAR(50)
)  
AS
	BEGIN  
	    UPDATE Carrera
            SET 
				nombre= @nombre
            WHERE  idCarrera = @idCarrera
	END   
	  
GO
/****** Object:  StoredProcedure [dbo].[EditarPersona]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROCEDURE [dbo].[EditarPersona] (
@cedula         VARCHAR(12),  
@nombre			VARCHAR(20),  
@apellido1		VARCHAR(20),  
@apellido2      VARCHAR(20),  
@idPais         int 
)  
AS
	BEGIN  
	    UPDATE Persona 
            SET cedula = @cedula,
				nombre= @nombre,
                   apellido1 = @apellido1,  
                   apellido2 = @apellido2,  
                   idPais = @idPais
            WHERE  cedula = @cedula
	END   
	  
GO
/****** Object:  StoredProcedure [dbo].[EliminarCarrera]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     PROCEDURE [dbo].[EliminarCarrera] (
@idCarrera        int  


)  
AS
	BEGIN  
	  DELETE FROM Carrera 
            WHERE  idCarrera = @idCarrera
	END   
	
GO
/****** Object:  StoredProcedure [dbo].[EliminarPersona]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROCEDURE [dbo].[EliminarPersona] (
@cedula         VARCHAR(12)

)  
AS
	BEGIN  
	  DELETE FROM Persona  
            WHERE  cedula = @cedula
	END   
	
GO
/****** Object:  StoredProcedure [dbo].[InsertarCarrrera]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROCEDURE [dbo].[InsertarCarrrera] (

@nombre			VARCHAR(50)
)  
AS
	BEGIN  
		INSERT INTO Carrera(
		
		nombre
		)  
        VALUES(
	
        @nombre
		)
	END   
GO
/****** Object:  StoredProcedure [dbo].[InsertarPersona]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarPersona] (
@cedula         VARCHAR(12),  
@nombre			VARCHAR(20),  
@apellido1		VARCHAR(20),  
@apellido2      VARCHAR(20),  
@idPais         int 
)  
AS
	BEGIN  
		INSERT INTO Persona(
		cedula,
		nombre,
        apellido1,  
        apellido2,  
        idPais
		)  
        VALUES(
		@cedula,  
        @nombre,  
        @apellido1,  
        @apellido2,  
        @idPais
		)
	END   
GO
/****** Object:  StoredProcedure [dbo].[ListarCarrera]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create     PROCEDURE [dbo].[ListarCarrera]
AS
	BEGIN  
	   SELECT *  
            FROM   Carrera
			
	END   
	    
GO
/****** Object:  StoredProcedure [dbo].[ListarPersona]    Script Date: 31/5/2020 22:24:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create   PROCEDURE [dbo].[ListarPersona] (
@cedula         VARCHAR(12)

)  
AS
	BEGIN  
	   SELECT *  
            FROM   Persona 
			
	END   
	    
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "l"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "e"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 136
               Right = 653
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CuentasxMes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CuentasxMes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Persona"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Usuario"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EncabezadoFactura"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 136
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LineaFactura"
            Begin Extent = 
               Top = 6
               Left = 662
               Bottom = 136
               Right = 832
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Producto"
            Begin Extent = 
               Top = 6
               Left = 870
               Bottom = 136
               Right = 1069
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
     ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Factura_Usuario'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Factura_Usuario'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Factura_Usuario'
GO
USE [master]
GO
ALTER DATABASE [ARE_Seminario] SET  READ_WRITE 
GO
