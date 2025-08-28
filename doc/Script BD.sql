/* CREAR USUARIO Y LOGIN */

USE MASTER;
GO
CREATE LOGIN Main_iSoft
    WITH PASSWORD = 'Main_iSoft';  
GO  

-- Crear usuario iSoft para el login iSoft.
CREATE USER Main_iSoft FOR LOGIN Main_iSoft;  
GO  


GRANT BACKUP DATABASE TO Main_iSoft;
GO

GRANT CREATE DATABASE TO Main_iSoft;
GO

GRANT ALTER SERVER STATE TO Main_iSoft;
GO


CREATE LOGIN [IIS APPPOOL\MainApi] FROM WINDOWS;
CREATE USER [IIS APPPOOL\MainApi] FOR LOGIN [IIS APPPOOL\MainApi];
GO

exec sp_grantlogin 'IIS APPPOOL\MainApi'

/* CREACION DE BASE DE DATOS */

USE [master]
GO

CREATE DATABASE [Main]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Main_dat', FILENAME = N'D:\SQLDatabases\Data\Main_dat.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Main_log', FILENAME = N'D:\SQLDatabases\Log\Main_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Main].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO


ALTER AUTHORIZATION ON DATABASE::[Main] TO Main_iSoft;
GO

ALTER DATABASE [Main] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Main] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Main] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Main] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Main] SET ARITHABORT OFF 
GO
ALTER DATABASE [Main] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Main] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Main] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Main] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Main] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Main] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Main] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Main] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Main] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Main] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Main] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Main] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Main] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Main] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Main] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Main] SET RECOVERY FULL 
GO
ALTER DATABASE [Main] SET  MULTI_USER 
GO
ALTER DATABASE [Main] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Main] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Main] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Main] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Main] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Main] SET QUERY_STORE = OFF
GO
ALTER DATABASE [Main] SET  READ_WRITE 
GO


--- LOGUEARSE CON iSoft


/* CREACION DE TABLAS */

CREATE TABLE [dbo].[groupmenu](
	[code] [varchar](25) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](500) NOT NULL,
	[order] [int] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](50) NOT NULL,
	[lastmodifieddate] [datetime] NULL,
	[lastmodifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_groupmenu] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[menu](
	[code] [varchar](25) NOT NULL,
	[codegroupmenu] [varchar](25) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](500) NOT NULL,
	[order] [int] NOT NULL,
	[level] [int] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](50) NOT NULL,
	[lastmodifieddate] [datetime] NULL,
	[lastmodifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_menu] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[menu]  WITH CHECK ADD  CONSTRAINT [FK_menu_groupmenu] FOREIGN KEY([codegroupmenu])
REFERENCES [dbo].[groupmenu] ([code])
GO

ALTER TABLE [dbo].[menu] CHECK CONSTRAINT [FK_menu_groupmenu]
GO


CREATE TABLE [dbo].[program](
	[code] [varchar](25) NOT NULL,
	[codegroupmenu] [varchar](25) NOT NULL,
	[codemenu] [varchar](25) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](500) NOT NULL,
	[order] [int] NOT NULL,
	[pathprogram] [varchar](500) NOT NULL,
	[pathimage] [varchar](500) NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](50) NOT NULL,
	[lastmodifieddate] [datetime] NULL,
	[lastmodifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_program] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[resource](
	[code] [varchar](25) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](500) NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](50) NOT NULL,
	[lastmodifieddate] [datetime] NULL,
	[lastmodifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_resource] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[accesscontrol](
	[code] [varchar](25) NOT NULL,
	[coderesource] [varchar](25) NOT NULL,
	[codeprogram] [varchar](25) NOT NULL,
	[read] [bit] NOT NULL,
	[write] [bit] NOT NULL,
	[create] [bit] NOT NULL,
	[eliminate] [bit] NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](50) NOT NULL,
	[lastmodifieddate] [datetime] NULL,
	[lastmodifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_accesscontrol_1] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[accesscontrol]  WITH CHECK ADD  CONSTRAINT [FK_accesscontrol_program] FOREIGN KEY([codeprogram])
REFERENCES [dbo].[program] ([code])
GO

ALTER TABLE [dbo].[accesscontrol] CHECK CONSTRAINT [FK_accesscontrol_program]
GO

ALTER TABLE [dbo].[accesscontrol]  WITH CHECK ADD  CONSTRAINT [FK_accesscontrol_resource] FOREIGN KEY([coderesource])
REFERENCES [dbo].[resource] ([code])
GO

ALTER TABLE [dbo].[accesscontrol] CHECK CONSTRAINT [FK_accesscontrol_resource]
GO


CREATE TABLE [dbo].[role](
	[code] [varchar](25) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](500) NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](50) NOT NULL,
	[lastmodifieddate] [datetime] NULL,
	[lastmodifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[administration](
	[coderole] [varchar](25) NOT NULL,
	[coderesource] [varchar](25) NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](50) NOT NULL,
	[lastmodifieddate] [datetime] NULL,
	[lastmodifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_administration] PRIMARY KEY CLUSTERED 
(
	[coderole] ASC,
	[coderesource] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[administration]  WITH CHECK ADD  CONSTRAINT [FK_administration_role] FOREIGN KEY([coderole])
REFERENCES [dbo].[role] ([code])
GO

ALTER TABLE [dbo].[administration] CHECK CONSTRAINT [FK_administration_role]
GO


CREATE TABLE [dbo].[user](
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[description] [varchar](500) NOT NULL,
	[names] [varchar](250) NOT NULL,
	[surnames] [varchar](250) NOT NULL,
	[phone] [varchar](50) NOT NULL,
	[email] [varchar](250) NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](50) NOT NULL,
	[lastmodifieddate] [datetime] NULL,
	[lastmodifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[roleperuser](
	[username] [varchar](50) NOT NULL,
	[coderole] [varchar](25) NOT NULL,
	[createddate] [datetime] NOT NULL,
	[createdby] [varchar](50) NOT NULL,
	[lastmodifieddate] [datetime] NULL,
	[lastmodifiedby] [varchar](50) NULL,
 CONSTRAINT [PK_roleperuser] PRIMARY KEY CLUSTERED 
(
	[username] ASC,
	[coderole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[roleperuser]  WITH CHECK ADD  CONSTRAINT [FK_roleperuser_role] FOREIGN KEY([coderole])
REFERENCES [dbo].[role] ([code])
GO

ALTER TABLE [dbo].[roleperuser] CHECK CONSTRAINT [FK_roleperuser_role]
GO

ALTER TABLE [dbo].[roleperuser]  WITH CHECK ADD  CONSTRAINT [FK_roleperuser_user] FOREIGN KEY([username])
REFERENCES [dbo].[user] ([username])
GO

ALTER TABLE [dbo].[roleperuser] CHECK CONSTRAINT [FK_roleperuser_user]
GO

/* DATOS DE PRUEBA */

INSERT INTO [dbo].[groupmenu]
           ([code],[name],[description],[order],[createddate],[createdby],[lastmodifieddate],[lastmodifiedby])
SELECT 'GRPMENU00000001','SISTEMAS ADMINISTRATIVOS','Sistemas Administrativos',1,getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'GRPMENU00000002','SISTEMAS FINANCIEROS','Sistemas Financieros',2,getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'GRPMENU00000003','SISTEMAS DE SEGURIDAD','Sistemas de Seguridad',3,getdate(),'JTorres',NULL,NULL
GO

INSERT INTO [dbo].[menu]
           ([code],[codegroupmenu],[name],[description],[order],[level],[createddate],[createdby],[lastmodifieddate],[lastmodifiedby])
SELECT 'MENU00000000001','GRPMENU00000003','Usuarios y Roles','Mantenimiento de Usuarios y Roles',1,1,getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'MENU00000000002','GRPMENU00000003','Programas','Mantenimiento de Grupos de Menu, Menu y Programas',2,1,getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'MENU00000000003','GRPMENU00000003','Recursos','Mantenimiento de Recursos y Accesos',3,1,getdate(),'JTorres',NULL,NULL
GO

INSERT INTO [dbo].[program]
           ([code],[codegroupmenu],[codemenu],[name],[description],[order],[pathprogram],[pathimage],[createddate],[createdby],[lastmodifieddate],[lastmodifiedby])
SELECT 'PROG00000000001','GRPMENU00000002','','Estado de Cuenta','Mantenimiento de Estados de Cuentas',1,'X','X',getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'PROG00000000002','','MENU00000000001','Rol','Mantenimiento de Roles',1,'X','X',getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'PROG00000000003','','MENU00000000001','Usuario','Mantenimiento de Usuarios',2,'X','X',getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'PROG00000000004','','MENU00000000001','Rol x Usuario','Mantenimiento de Roles x Usuario',3,'X','X',getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'PROG00000000005','','MENU00000000002','Grupo de Menu','Mantenimiento de Grupos de Menu',1,'X','X',getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'PROG00000000006','','MENU00000000002','Menu','Mantenimiento de Menu',2,'X','X',getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'PROG00000000007','','MENU00000000002','Programa','Mantenimiento de Programas',3,'X','X',getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'PROG00000000008','','MENU00000000003','Recurso','Mantenimiento de Recursos',1,'X','X',getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'PROG00000000009','','MENU00000000003','Accesos','Mantenimiento de Accesos',2,'X','X',getdate(),'JTorres',NULL,NULL
GO

INSERT INTO [dbo].[resource]
           ([code],[name],[description],[createddate],[createdby],[lastmodifieddate],[lastmodifiedby])
SELECT 'RSCE00000000001','MAIN','Acceso General',getdate(),'JTorres',NULL,NULL
GO

INSERT INTO [dbo].[accesscontrol]
           ([code],[coderesource],[codeprogram],[read],[write],[create],[eliminate],[createddate],[createdby],[lastmodifieddate],[lastmodifiedby])
SELECT 'ACCCTRL00000001','RSCE00000000001','PROG00000000001',1,1,1,1,getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'ACCCTRL00000002','RSCE00000000001','PROG00000000002',1,1,1,1,getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'ACCCTRL00000003','RSCE00000000001','PROG00000000003',1,1,1,1,getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'ACCCTRL00000004','RSCE00000000001','PROG00000000004',1,1,1,1,getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'ACCCTRL00000005','RSCE00000000001','PROG00000000005',1,1,1,1,getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'ACCCTRL00000006','RSCE00000000001','PROG00000000006',1,1,1,1,getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'ACCCTRL00000007','RSCE00000000001','PROG00000000007',1,1,1,1,getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'ACCCTRL00000008','RSCE00000000001','PROG00000000008',1,1,1,1,getdate(),'JTorres',NULL,NULL
UNION ALL
SELECT 'ACCCTRL00000009','RSCE00000000001','PROG00000000009',1,1,1,1,getdate(),'JTorres',NULL,NULL
GO

INSERT INTO [dbo].[role]
           ([code],[name],[description],[createddate],[createdby],[lastmodifieddate],[lastmodifiedby])
SELECT 'ROLE00000000001','MAIN','Acceso General',getdate(),'JTorres',NULL,NULL
GO

INSERT INTO [dbo].[administration]
           ([coderole],[coderesource],[createddate],[createdby],[lastmodifieddate],[lastmodifiedby])
SELECT 'ROLE00000000001','RSCE00000000001',getdate(),'JTorres',NULL,NULL
GO

INSERT INTO [dbo].[user]
           ([username],[password],[description],[names],[surnames],[phone],[email],[createddate],[createdby],[lastmodifieddate],[lastmodifiedby])
SELECT 'ADMINIST','±²³´µ¶·¸¹','AMINISTRADOR','Usuario Administrador','ADMIN','','@',getdate(),'ADMINIST',NULL,NULL
UNION ALL
SELECT 'JTorres','Ç°òç°ç±·°¤','Jorge Luis Torres Agapito','Jorge Luis','Torres Agapito','991506290','ta_jorge_luis@hotmail.com',getdate(),'ADMINIST',NULL,NULL
GO

INSERT INTO [dbo].[roleperuser]
           ([username],[coderole],[createddate],[createdby],[lastmodifieddate],[lastmodifiedby])
SELECT 'JTorres','ROLE00000000001',getdate(),'JTorres',NULL,NULL
GO


/* FUNCIONES */

CREATE FUNCTION [dbo].[EncryptString](@Text VARCHAR(250), @Key VARCHAR(025))
RETURNS VARCHAR(250)
AS
BEGIN
  DECLARE @I   INT;
  DECLARE @RET VARCHAR(250);
  DECLARE @C1  INT;
  DECLARE @C2  INT;
  SET  @I = 0;
  SET @RET = '';
  IF(LEN(@Key) > 0)
  BEGIN
    WHILE @I < LEN(@Text)
	BEGIN
	  SET @I = @I + 1;
      SET @C1 = ASCII(SUBSTRING(@Text, @I, 1));
      If (@I > LEN(@Key))
	  BEGIN
        SET @C2 = ASCII(SUBSTRING(@Key, @I % LEN(@Key) + 1, 1));
	  END
      ELSE
	  BEGIN
        SET @C2 = ASCII(SUBSTRING(@Key, @I, 1));
      END
      SET @C1 = @C1 + @C2 + 64;
      IF (@C1 > 255) 
	  BEGIN SET @C1 = @C1 - 256 END
      SET @RET = @RET + CHAR(@C1);
    END
  END
  ELSE
  BEGIN
    SET @RET = @Text;
  END
  RETURN @RET;
END;
GO

CREATE FUNCTION [dbo].[DecryptString](@Text VARCHAR(250), @Key VARCHAR(025))
RETURNS VARCHAR(250)
AS
BEGIN
  DECLARE @I   INT;
  DECLARE @RET VARCHAR(250);
  DECLARE @C1  INT;
  DECLARE @C2  INT;
  SET  @I = 0;
  SET @RET = '';
  IF(LEN(@Key) > 0)
  BEGIN
    WHILE @I < LEN(@Text)
	BEGIN
	  SET @I = @I + 1;
      SET @C1 = ASCII(SUBSTRING(@Text, @I, 1));
      If (@I > LEN(@Key))
	  BEGIN
        SET @C2 = ASCII(SUBSTRING(@Key, @I % LEN(@Key) + 1, 1));
	  END
      ELSE
	  BEGIN
        SET @C2 = ASCII(SUBSTRING(@Key, @I, 1));
      END
      SET @C1 = @C1 - @C2 - 64;
      IF (SIGN(@C1) = -1) 
	  BEGIN SET @C1 = 256 + @C1 END
      SET @RET = @RET + CHAR(@C1);
    END
  END
  ELSE
  BEGIN
    SET @RET = @Text;
  END
  RETURN @RET;
END;
GO


/* PROCEDIMIENTOS ALMACENADOS */

create PROCEDURE [dbo].[AccessControlDelete]
(@Code varchar(050))
AS
BEGIN
  DELETE [AccessControl]
  WHERE [Code] = @Code;
END
GO

CREATE PROCEDURE [dbo].[AccessControlGetByID]
(@Code varchar(050))
AS
BEGIN
  SELECT [Code], [CodeResource], [CodeProgram], [Read], [Write], [Create], [Eliminate], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [AccessControl]
  WHERE [Code] = @Code;
END
GO

CREATE PROCEDURE [dbo].[AccessControlGetByProgram]
(@CodeProgram varchar(050))
AS
BEGIN
  SELECT [Code], [CodeResource], [CodeProgram], [Read], [Write], [Create], [Eliminate], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [AccessControl]
  WHERE [CodeProgram] = @CodeProgram;
END
GO

USE [Main]
GO

CREATE PROCEDURE [dbo].[AccessControlGetByResource]
(@CodeResource varchar(050))
AS
BEGIN
  SELECT [Code], [CodeResource], [CodeProgram], [Read], [Write], [Create], [Eliminate], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [AccessControl]
  WHERE [CodeResource] = @CodeResource;
END
GO

CREATE PROCEDURE [dbo].[AccessControlInsert]
(
 @Code             varchar(050),
 @CodeResource     varchar(050),
 @CodeProgram      varchar(050),
 @Read             bit,
 @Write            bit,
 @Create           bit,
 @Eliminate        bit,
 @CreatedDate      datetime,
 @CreatedBy        varchar(50)
)
AS
BEGIN
  INSERT INTO [AccessControl]([Code], [CodeResource], [CodeProgram], [Read], [Write], [Create], [Eliminate], [CreatedDate], [CreatedBy])
  VALUES(@Code, @CodeResource, @CodeProgram, @Read, @Write, @Create, @Eliminate, @CreatedDate, @CreatedBy);
END
GO

CREATE PROCEDURE [dbo].[AccessControlList]
AS
BEGIN
  SELECT [Code], [CodeResource], [CodeProgram], [Read], [Write], [Create], [Eliminate], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [AccessControl];
END
GO

CREATE PROCEDURE [dbo].[AccessControlListWithPagination]
(
  @PageNumber int,
  @PageSize   int
)
AS
BEGIN
  SELECT [Code], [CodeResource], [CodeProgram], [Read], [Write], [Create], [Eliminate], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [AccessControl]
  ORDER BY [Code], [CodeResource], [CodeProgram]
  OFFSET (@PageNumber - 1) * @PageSize ROWS
  FETCH NEXT @PageSize ROWS ONLY
END
GO

create PROCEDURE [dbo].[AccessControlUpdate]
(
 @Code             varchar(050),
 @CodeResource     varchar(050),
 @CodeProgram      varchar(050),
 @Read             bit,
 @Write            bit,
 @Create           bit,
 @Eliminate        bit,
 @LastModifiedDate datetime,
 @LastModifiedBy   varchar(50)
)
AS
BEGIN
  UPDATE [AccessControl]
    SET
      [CodeResource]     = @CodeResource,
      [CodeProgram]      = @CodeProgram,
      [Read]             = @Read,
      [Write]            = @Write,
      [Create]           = @Create,
      [Eliminate]        = @Eliminate,
      [LastModifiedDate] = @LastModifiedDate,
      [LastModifiedBy]   = @LastModifiedBy
  WHERE [Code] = @Code;
END
GO

create PROCEDURE [dbo].[AdministrationDelete]
(
 @CodeRole         varchar(050),
 @CodeResource     varchar(050)
)
AS
BEGIN
  DELETE [Administration]
  WHERE [CodeRole]     = @CodeRole
    and [CodeResource] = @CodeResource;
END
GO

CREATE PROCEDURE [dbo].[AdministrationGetByID]
(
 @CodeRole         varchar(050),
 @CodeResource     varchar(050)
)
AS
BEGIN
  SELECT [CodeRole], [CodeResource], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Administration]
  WHERE [CodeRole]     = @CodeRole
    and [CodeResource] = @CodeResource;
END
GO

CREATE PROCEDURE [dbo].[AdministrationGetByResource]
(@CodeResource varchar(050))
AS
BEGIN
  SELECT [CodeRole], [CodeResource], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Administration]
  WHERE [CodeResource] = @CodeResource;
END
GO

CREATE PROCEDURE [dbo].[AdministrationGetByRole]
(@CodeRole varchar(050))
AS
BEGIN
  SELECT [CodeRole], [CodeResource], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Administration]
  WHERE [CodeRole] = @CodeRole;
END
GO

CREATE PROCEDURE [dbo].[AdministrationInsert]
(
 @CodeRole         varchar(050),
 @CodeResource     varchar(050),
 @CreatedDate      datetime,
 @CreatedBy        varchar(50)
)
AS
BEGIN
  INSERT INTO [Administration]([CodeRole], [CodeResource], [CreatedDate], [CreatedBy])
  VALUES(@CodeRole, @CodeResource, @CreatedDate, @CreatedBy);
END
GO

CREATE PROCEDURE [dbo].[AdministrationList]
AS
BEGIN
  SELECT [CodeRole], [CodeResource], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Administration];
END
GO

CREATE PROCEDURE [dbo].[AdministrationListWithPagination]
(
  @PageNumber int,
  @PageSize   int
)
AS
BEGIN
  SELECT [CodeRole], [CodeResource], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Administration]
  ORDER BY [CodeRole], [CodeResource]
  OFFSET (@PageNumber - 1) * @PageSize ROWS
  FETCH NEXT @PageSize ROWS ONLY
END
GO

create PROCEDURE [dbo].[AdministrationUpdate]
(
 @CodeRole         varchar(050),
 @CodeResource     varchar(050),
 @LastModifiedDate datetime,
 @LastModifiedBy   varchar(50)
)
AS
BEGIN
  UPDATE [Administration]
    SET
      [LastModifiedDate] = @LastModifiedDate,
      [LastModifiedBy]   = @LastModifiedBy
  WHERE [CodeRole]     = @CodeRole
    and [CodeResource] = @CodeResource;
END
GO

CREATE PROCEDURE [dbo].[GroupMenuDelete]
(@Code varchar(025))
AS
BEGIN
  DELETE [GroupMenu]
  WHERE [Code] = @Code;
END
GO

CREATE PROCEDURE [dbo].[GroupMenuGetByID]
(@Code varchar(050))
AS
BEGIN
  SELECT [Code], [Name], [Description], [Order], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [GroupMenu]
  WHERE [Code] = @Code;
END
GO

CREATE PROCEDURE [dbo].[GroupMenuInsert]
(
 @Code        varchar(025),
 @Name        varchar(050),
 @Description varchar(500),
 @Order       int,
 @CreatedDate datetime,
 @CreatedBy   varchar(50)
)
AS
BEGIN
  INSERT INTO [GroupMenu]([Code], [Name], [Description], [Order], [CreatedDate], [CreatedBy])
  VALUES(@Code, @Name, @Description, @Order, @CreatedDate, @CreatedBy);
END
GO

CREATE PROCEDURE [dbo].[GroupMenuList]
AS
BEGIN
  SELECT [Code], [Name], [Description], [Order], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [GroupMenu];
END
GO

CREATE PROCEDURE [dbo].[GroupMenuListWithPagination]
(
  @PageNumber int,
  @PageSize   int
)
AS
BEGIN
  SELECT [Code], [Name], [Description], [Order], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [GroupMenu]
  ORDER BY [Code], [Order], [Name]
  OFFSET (@PageNumber - 1) * @PageSize ROWS
  FETCH NEXT @PageSize ROWS ONLY
END
GO

CREATE PROCEDURE [dbo].[GroupMenuUpdate]
(
 @Code             varchar(025),
 @Name             varchar(050),
 @Description      varchar(500),
 @Order            int,
 @LastModifiedDate datetime,
 @LastModifiedBy   varchar(50)
)
AS
BEGIN
  UPDATE [GroupMenu]
    SET
      [Name]             = @Name,
      [Description]      = @Description,
      [Order]            = @Order,
      [LastModifiedDate] = @LastModifiedDate,
      [LastModifiedBy]   = @LastModifiedBy
  WHERE [Code] = @Code;
END
GO

CREATE PROCEDURE [dbo].[MenuDelete]
(@Code varchar(025))
AS
BEGIN
  DELETE [Menu]
  WHERE [Code] = @Code;
END
GO

CREATE PROCEDURE [dbo].[MenuGetByGroupMenu]
(@CodeGroupMenu    varchar(025))
AS
BEGIN
  SELECT [Code], [CodeGroupMenu], [Name], [Description], [Order], [Level], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Menu]
  WHERE [CodeGroupMenu] = @CodeGroupMenu;
END
GO

CREATE PROCEDURE [dbo].[MenuGetByID]
(@Code varchar(050))
AS
BEGIN
  SELECT [Code], [CodeGroupMenu], [Name], [Description], [Order], [Level], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Menu]
  WHERE [Code] = @Code;
END
GO

CREATE PROCEDURE [dbo].[MenuInsert]
(
 @Code          varchar(025),
 @CodeGroupMenu varchar(025),
 @Name          varchar(050),
 @Description   varchar(500),
 @Order         int,
 @Level         int,
 @CreatedDate   datetime,
 @CreatedBy     varchar(050)
)
AS
BEGIN
  INSERT INTO [Menu]([Code], [CodeGroupMenu], [Name], [Description], [Order], [Level], [CreatedDate], [CreatedBy])
  VALUES(@Code, @CodeGroupMenu, @Name, @Description, @Order, @Level, @CreatedDate, @CreatedBy);
END
GO

CREATE PROCEDURE [dbo].[MenuList]
AS
BEGIN
  SELECT [Code], [CodeGroupMenu], [Name], [Description], [Order], [Level], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Menu];
END
GO

CREATE PROCEDURE [dbo].[MenuListWithPagination]
(
  @PageNumber int,
  @PageSize   int
)
AS
BEGIN
  SELECT [Code], [CodeGroupMenu], [Name], [Description], [Order], [Level], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Menu]
  ORDER BY [Code], [Order], [Name]
  OFFSET (@PageNumber - 1) * @PageSize ROWS
  FETCH NEXT @PageSize ROWS ONLY
END
GO

CREATE PROCEDURE [dbo].[MenuUpdate]
(
 @Code             varchar(025),
 @CodeGroupMenu    varchar(025),
 @Name             varchar(050),
 @Description      varchar(500),
 @Order            int,
 @Level            int,
 @LastModifiedDate datetime,
 @LastModifiedBy   varchar(050)
)
AS
BEGIN
  UPDATE [Menu]
    SET
      [Name]             = @Name,
	  [CodeGroupMenu]    = @CodeGroupMenu,
      [Description]      = @Description,
      [Order]            = @Order,
	  [Level]            = @Level,
      [LastModifiedDate] = @LastModifiedDate,
      [LastModifiedBy]   = @LastModifiedBy
  WHERE [Code] = @Code;
END
GO

CREATE PROCEDURE [dbo].[ProgramDelete]
(@Code varchar(025))
AS
BEGIN
  DELETE [Program]
  WHERE [Code] = @Code;
END
GO

CREATE PROCEDURE [dbo].[ProgramGetByGroupMenu]
(@CodeGroupMenu    varchar(025))
AS
BEGIN
  SELECT [code], [codegroupmenu], [codemenu], [name], [description],[order], [pathprogram], [pathimage], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Program]
  WHERE [CodeGroupMenu] = @CodeGroupMenu;
END
GO

CREATE PROCEDURE [dbo].[ProgramGetByID]
(@Code varchar(050))
AS
BEGIN
  SELECT [code], [codegroupmenu], [codemenu], [name], [description],[order], [pathprogram], [pathimage], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Program]
  WHERE [Code] = @Code;
END
GO

CREATE PROCEDURE [dbo].[ProgramGetByMenu]
(@CodeMenu    varchar(025))
AS
BEGIN
  SELECT [code], [codegroupmenu], [codemenu], [name], [description],[order], [pathprogram], [pathimage], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Program]
  WHERE [CodeMenu] = @CodeMenu;
END
GO

CREATE PROCEDURE [dbo].[ProgramInsert]
(
 @Code          varchar(025),
 @CodeGroupMenu varchar(025),
 @CodeMenu      varchar(025),
 @Name          varchar(050),
 @Description   varchar(500),
 @Order         int,
 @PathProgram   varchar(500),
 @PathImage     varchar(500),
 @CreatedDate   datetime,
 @CreatedBy     varchar(050)
)
AS
BEGIN
  INSERT INTO [Program]([code], [codegroupmenu], [codemenu], [name], [description],[order], [pathprogram], [pathimage], [CreatedDate], [CreatedBy])
  VALUES(@Code, @CodeGroupMenu, @CodeMenu, @Name, @Description, @Order, @PathProgram, @PathImage, @CreatedDate, @CreatedBy);
END
GO

CREATE PROCEDURE [dbo].[ProgramList]
AS
BEGIN
  SELECT [code], [codegroupmenu], [codemenu], [name], [description],[order], [pathprogram], [pathimage], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Program];
END
GO

CREATE PROCEDURE [dbo].[ProgramListWithPagination]
(
  @PageNumber int,
  @PageSize   int
)
AS
BEGIN
  SELECT [code], [codegroupmenu], [codemenu], [name], [description],[order], [pathprogram], [pathimage], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Program]
  ORDER BY [Code], [Order], [Name]
  OFFSET (@PageNumber - 1) * @PageSize ROWS
  FETCH NEXT @PageSize ROWS ONLY
END
GO

CREATE PROCEDURE [dbo].[ProgramUpdate]
(
 @Code             varchar(025),
 @CodeGroupMenu    varchar(025),
 @CodeMenu         varchar(025),
 @Name             varchar(050),
 @Description      varchar(500),
 @Order            int,
 @PathProgram      varchar(500),
 @PathImage        varchar(500),
 @LastModifiedDate datetime,
 @LastModifiedBy   varchar(050)
)
AS
BEGIN
  UPDATE [Program]
    SET      
	  [CodeGroupMenu]    = @CodeGroupMenu,
	  [CodeMenu]         = @CodeMenu,
	  [Name]             = @Name,
      [Description]      = @Description,
      [Order]            = @Order,
	  [PathProgram]      = @PathProgram,
	  [PathImage]        = @PathImage,
      [LastModifiedDate] = @LastModifiedDate,
      [LastModifiedBy]   = @LastModifiedBy
  WHERE [Code] = @Code;
END
GO

CREATE PROCEDURE [dbo].[ResourceDelete]
(@Code varchar(025))
AS
BEGIN
  DELETE [Resource]
  WHERE [Code] = @Code;
END
GO

CREATE PROCEDURE [dbo].[ResourceGetByID]
(@Code varchar(050))
AS
BEGIN
  SELECT [code], [name], [description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Resource]
  WHERE [Code] = @Code;
END
GO

CREATE PROCEDURE [dbo].[ResourceInsert]
(
 @Code          varchar(025), 
 @Name          varchar(050),
 @Description   varchar(500), 
 @CreatedDate   datetime,
 @CreatedBy     varchar(050)
)
AS
BEGIN
  INSERT INTO [Resource]([code], [name], [description], [CreatedDate], [CreatedBy])
  VALUES(@Code, @Name, @Description, @CreatedDate, @CreatedBy);
END
GO

CREATE PROCEDURE [dbo].[ResourceList]
AS
BEGIN
  SELECT [code], [name], [description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Resource];
END
GO

CREATE PROCEDURE [dbo].[ResourceListWithPagination]
(
  @PageNumber int,
  @PageSize   int
)
AS
BEGIN
  SELECT [code], [name], [description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Resource]
  ORDER BY [Code], [Name]
  OFFSET (@PageNumber - 1) * @PageSize ROWS
  FETCH NEXT @PageSize ROWS ONLY
END
GO

CREATE PROCEDURE [dbo].[ResourceUpdate]
(
 @Code             varchar(025),
 @Name             varchar(050),
 @Description      varchar(500),
 @LastModifiedDate datetime,
 @LastModifiedBy   varchar(050)
)
AS
BEGIN
  UPDATE [Resource]
    SET      
	  [Name]             = @Name,
      [Description]      = @Description,
      [LastModifiedDate] = @LastModifiedDate,
      [LastModifiedBy]   = @LastModifiedBy
  WHERE [Code] = @Code;
END
GO

CREATE PROCEDURE [dbo].[RoleDelete]
(@Code varchar(025))
AS
BEGIN
  DELETE [Role]
  WHERE [Code] = @Code;
END
GO

CREATE PROCEDURE [dbo].[RoleGetByID]
(@Code varchar(050))
AS
BEGIN
  SELECT [code], [name], [description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Role]
  WHERE [Code] = @Code;
END
GO

CREATE PROCEDURE [dbo].[RoleInsert]
(
 @Code          varchar(025), 
 @Name          varchar(050),
 @Description   varchar(500), 
 @CreatedDate   datetime,
 @CreatedBy     varchar(050)
)
AS
BEGIN
  INSERT INTO [Role]([code], [name], [description], [CreatedDate], [CreatedBy])
  VALUES(@Code, @Name, @Description, @CreatedDate, @CreatedBy);
END
GO

CREATE PROCEDURE [dbo].[RoleList]
AS
BEGIN
  SELECT [code], [name], [description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Role];
END
GO

CREATE PROCEDURE [dbo].[RoleListWithPagination]
(
  @PageNumber int,
  @PageSize   int
)
AS
BEGIN
  SELECT [code], [name], [description], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [Role]
  ORDER BY [Code], [Name]
  OFFSET (@PageNumber - 1) * @PageSize ROWS
  FETCH NEXT @PageSize ROWS ONLY
END
GO

CREATE PROCEDURE [dbo].[RoleUpdate]
(
 @Code             varchar(025),
 @Name             varchar(050),
 @Description      varchar(500),
 @LastModifiedDate datetime,
 @LastModifiedBy   varchar(050)
)
AS
BEGIN
  UPDATE [Role]
    SET      
	  [Name]             = @Name,
      [Description]      = @Description,
      [LastModifiedDate] = @LastModifiedDate,
      [LastModifiedBy]   = @LastModifiedBy
  WHERE [Code] = @Code;
END
GO

CREATE PROCEDURE [dbo].[RolePerUserDelete]
(@UserName varchar(050), @CodeRole varchar(025))
AS
BEGIN
  DELETE [RolePerUser]
  WHERE [UserName] = @UserName and [CodeRole] = @CodeRole;
END
GO

CREATE PROCEDURE [dbo].[RolePerUserGetByID]
(@UserName varchar(050), @CodeRole varchar(025))
AS
BEGIN
  SELECT [UserName], [CodeRole], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [RolePerUser]
  WHERE [UserName] = @UserName and [CodeRole] = @CodeRole;
END
GO

CREATE PROCEDURE [dbo].[RolePerUserGetByRole]
(@CodeRole varchar(025))
AS
BEGIN
  SELECT [UserName], [CodeRole], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [RolePerUser]
  WHERE [CodeRole] = @CodeRole;
END
GO

CREATE PROCEDURE [dbo].[RolePerUserGetByUser]
(@UserName varchar(050))
AS
BEGIN
  SELECT [UserName], [CodeRole], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [RolePerUser]
  WHERE [UserName] = @UserName;
END
GO

CREATE PROCEDURE [dbo].[RolePerUserInsert]
(
 @UserName      varchar(050),
 @CodeRole      varchar(025),
 @CreatedDate   datetime,
 @CreatedBy     varchar(050)
)
AS
BEGIN
  INSERT INTO [RolePerUser]([UserName], [CodeRole], [CreatedDate], [CreatedBy])
  VALUES(@UserName, @CodeRole, @CreatedDate, @CreatedBy);
END
GO

CREATE PROCEDURE [dbo].[RolePerUserList]
AS
BEGIN
  SELECT [UserName], [CodeRole], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [RolePerUser];
END
GO

CREATE PROCEDURE [dbo].[RolePerUserListWithPagination]
(
  @PageNumber int,
  @PageSize   int
)
AS
BEGIN
  SELECT [UserName], [CodeRole], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [RolePerUser]
  ORDER BY [UserName], [CodeRole]
  OFFSET (@PageNumber - 1) * @PageSize ROWS
  FETCH NEXT @PageSize ROWS ONLY
END
GO

CREATE PROCEDURE [dbo].[UserDelete]
(@UserName varchar(50))
AS
BEGIN
  DELETE [User]
  WHERE [UserName] = @UserName;
END
GO

CREATE PROCEDURE [dbo].[UserGetByID]
(@UserName varchar(50))
AS
BEGIN
  SELECT [UserName], [Password], [Description], [Names], [Surnames], [Phone], [EMail], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [User]
  WHERE [UserName] = @UserName;
END
GO

CREATE PROCEDURE [dbo].[UserGetByUserAndPassword]
(
  @UserName varchar(50),
  @Password varchar(50)
)
AS
BEGIN
    SELECT [UserName], [Password], [Description], [Names], [Surnames], [Phone], [EMail], '' [Token]
    FROM [User]
    WHERE [UserName] = @UserName and [Password] = [dbo].EncryptString(@Password, '@');
END
GO

CREATE PROCEDURE [dbo].[UserInsert]
(
 @UserName         varchar(50),
 @Password         varchar(50),
 @Description      varchar(500),
 @Names            varchar(250),
 @Surnames         varchar(250),
 @Phone            varchar(50),
 @EMail            varchar(250),
 @CreatedDate      datetime,
 @CreatedBy        varchar(50)
)
AS
BEGIN
  INSERT INTO [User]([UserName], [Password], [Description], [Names], [Surnames], [Phone], [EMail], [CreatedDate], [CreatedBy])
  VALUES(@UserName, @Password, @Description, @Names, @Surnames, @Phone, @EMail, @CreatedDate, @CreatedBy);
END
GO

CREATE PROCEDURE [dbo].[UserList]
AS
BEGIN
  SELECT [UserName], [Password], [Description], [Names], [Surnames], [Phone], [EMail], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [User];
END
GO

CREATE PROCEDURE [dbo].[UserListWithPagination]
(
  @PageNumber int,
  @PageSize   int
)
AS
BEGIN
  SELECT [UserName], [Password], [Description], [Names], [Surnames], [Phone], [EMail], [CreatedDate], [CreatedBy], [LastModifiedDate], [LastModifiedBy]
  FROM [User]
  ORDER BY [UserName], [Description]
  OFFSET (@PageNumber - 1) * @PageSize ROWS
  FETCH NEXT @PageSize ROWS ONLY
END
GO

CREATE PROCEDURE [dbo].[UserUpdate]
(
 @UserName         varchar(50),
 @Password         varchar(50),
 @Description      varchar(500),
 @Names            varchar(250),
 @Surnames         varchar(250),
 @Phone            varchar(50),
 @EMail            varchar(250),
 @LastModifiedDate datetime,
 @LastModifiedBy   varchar(50)
)
AS
BEGIN
  UPDATE [User]
    SET
      [Password]         = @Password,
      [Description]      = @Description,
      [Names]            = @Names,
      [Surnames]         = @Surnames,
      [Phone]            = @Phone,
      [EMail]            = @EMail,
      [LastModifiedDate] = @LastModifiedDate,
      [LastModifiedBy]   = @LastModifiedBy
  WHERE [UserName] = @UserName;
END
GO



/* ASIGNACION DE OBJETOS A APPPOOL\iSOFT */


USE [Main]
GO

CREATE USER [IIS APPPOOL\MainApi] FOR LOGIN [IIS APPPOOL\MainApi];
GO

GRANT ALTER TO [IIS APPPOOL\MainApi];
GO
GRANT CREATE TABLE TO [IIS APPPOOL\MainApi];
GO
GRANT SELECT TO [IIS APPPOOL\MainApi]
GO
GRANT EXECUTE ON SCHEMA ::dbo TO [IIS APPPOOL\MainApi]
GO



DECLARE @SCHEMA VARCHAR(500), @NAME VARCHAR(500)

DECLARE RUTINAS_CUR CURSOR FOR   
SELECT SPECIFIC_SCHEMA, ROUTINE_NAME FROM INFORMATION_SCHEMA.ROUTINES 
WHERE ROUTINE_TYPE IN ('PROCEDURE', 'FUNCTION')
ORDER BY ROUTINE_TYPE, SPECIFIC_SCHEMA, ROUTINE_NAME;

OPEN RUTINAS_CUR  
  
FETCH NEXT FROM RUTINAS_CUR   
INTO @SCHEMA, @NAME;
  
WHILE @@FETCH_STATUS = 0
BEGIN
  
  EXEC ('GRANT EXECUTE ON OBJECT::[' + @SCHEMA + '].[' + @NAME + ']
        TO [IIS APPPOOL\iSoft];');

  FETCH NEXT FROM RUTINAS_CUR   
  INTO @SCHEMA, @NAME;
END
CLOSE RUTINAS_CUR;
DEALLOCATE RUTINAS_CUR;

GO