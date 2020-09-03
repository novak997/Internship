USE [timesheet]
GO
/****** Object:  StoredProcedure [dbo].[uspAddCategory]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAddCategory]
   @name nvarchar(30)
AS
BEGIN
   SET NOCOUNT ON
	INSERT INTO Category(name) VALUES (@name)
END
GO
/****** Object:  StoredProcedure [dbo].[uspAddClient]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAddClient]
   @name nvarchar(30),
   @address nvarchar(50),
   @city nvarchar(20),
   @zip nvarchar(15),
   @country int
AS
BEGIN
   SET NOCOUNT ON
	INSERT INTO Client (name, address, city, zip, countryID) VALUES (@name, @address, @city, @zip, @country)
END
GO
/****** Object:  StoredProcedure [dbo].[uspAddCountry]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAddCountry]
   @name nvarchar(30),
   @short nvarchar(3)
AS
BEGIN
   SET NOCOUNT ON
	INSERT INTO Country(name, short) VALUES (@name, @short)
END
GO
/****** Object:  StoredProcedure [dbo].[uspAddProject]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAddProject]
   @name nvarchar(30),
   @description nvarchar(60),
   @client int,
   @lead int
AS
BEGIN
   SET NOCOUNT ON
	INSERT INTO Project (name, description, clientID, leadID) VALUES (@name, @description, @client, @lead)
END
GO
/****** Object:  StoredProcedure [dbo].[uspAddUser]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAddUser]
   @name nvarchar(30),
   @weekly float,
   @username nvarchar(20),
   @email nvarchar(30),
   @isActive bit,
   @isAdmin bit
AS
BEGIN
   SET NOCOUNT ON
	INSERT INTO "User" (name, weekly, username, email, isActive, isAdmin) VALUES (@name, @weekly, @username, @email, @isActive, @isAdmin)
END
GO
/****** Object:  StoredProcedure [dbo].[uspAddWorktime]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAddWorktime]
   @client int,
   @project int,
   @category int,
   @user int,
   @description nvarchar(60),
   @hours float,
   @overtime float
AS
BEGIN
   SET NOCOUNT ON
	INSERT INTO Worktime(clientID, projectID, categoryID, userID, description, hours, overtime) VALUES (@client, @project, @category, @user, @description, @hours, @overtime)
END
GO
/****** Object:  StoredProcedure [dbo].[uspChangePassword]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspChangePassword]
   @password char(60),
   @id int
AS
BEGIN
   SET NOCOUNT ON
	UPDATE "User"
	SET password=@password
	WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteClientLogically]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDeleteClientLogically]
   @id int
AS
BEGIN
   SET NOCOUNT ON
	UPDATE Client
	SET isDeleted=1
	WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteClientPhysically]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDeleteClientPhysically]
   @id int
AS
BEGIN
   SET NOCOUNT ON
	DELETE FROM Client WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteProjectLogically]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDeleteProjectLogically]
   @id int
AS
BEGIN
   SET NOCOUNT ON
	UPDATE Project
	SET isDeleted=1
	WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteProjectPhysically]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDeleteProjectPhysically]
   @id int
AS
BEGIN
   SET NOCOUNT ON
	DELETE FROM Project WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteUserLogically]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDeleteUserLogically]
   @id int
AS
BEGIN
   SET NOCOUNT ON
	UPDATE "User"
	SET isDeleted=1
	WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteUserPhysically]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDeleteUserPhysically]
   @id int
AS
BEGIN
   SET NOCOUNT ON
	DELETE FROM "User" WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[uspFilterReports]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspFilterReports]
   @user int,
   @client int,
   @project int,
   @category int,
   @startDate date,
   @endDate date
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Worktime 
	WHERE (@user IS NULL OR userID=@user)
	AND (@client IS NULL OR userID=@client)
	AND (@project IS NULL OR userID=@project)
	AND (@category IS NULL OR userID=@category)
	AND (@startDate IS NULL OR date >= @startDate)
	AND (@endDate IS NULL OR date<=@endDate)
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetAllCategories]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetAllCategories]
   
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Category
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetAllClients]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetAllClients]
   
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM dbo.Client
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetAllCountries]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetAllCountries]
   
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Country
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetAllProjects]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetAllProjects]
   
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Project
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetAllUsers]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetAllUsers]
   
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM "User"
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetCategoryById]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetCategoryById]
   @id int
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Category WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetCategoryByName]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetCategoryByName]
   @name nvarchar(30)
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Category WHERE LOWER(name)=LOWER(@name)
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetClientById]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetClientById]
   @id int
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Client WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetClientByNameAndAddress]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetClientByNameAndAddress]
   @name nvarchar(30),
   @address nvarchar(50)
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Client WHERE LOWER(name)=LOWER(@name) AND LOWER(address)=LOWER(@address)
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetClientsFirstLetters]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetClientsFirstLetters]

AS
BEGIN
   SET NOCOUNT ON
	SELECT DISTINCT UPPER(LEFT(name, 1)) AS letter FROM Client
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetCountryById]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetCountryById]
   @id int
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Country WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetCountryByName]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetCountryByName]
   @name nvarchar(40)
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Country WHERE LOWER(name)=LOWER(@name)
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetCountryByShort]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetCountryByShort]
   @short nvarchar(3)
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Country WHERE LOWER(short)=LOWER(@short)
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetProjectById]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetProjectById]
   @id int
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Project WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetProjectByNameAndClient]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetProjectByNameAndClient]
   @name nvarchar(30),
   @client int
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Project WHERE LOWER(name)=LOWER(@name) AND clientID=@client
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetProjectsFirstLetters]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetProjectsFirstLetters]

AS
BEGIN
   SET NOCOUNT ON
	SELECT DISTINCT UPPER(LEFT(name, 1)) AS letter FROM Project
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetUserByEmail]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetUserByEmail]
   @email nvarchar(30)
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM "User" WHERE email=@email
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetUserById]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetUserById]
   @id int
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM "User" WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetUserByUsername]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetUserByUsername]
   @username nvarchar(20)
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM "User" WHERE username=@username
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetWorktimesForUser]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetWorktimesForUser]
   @id int
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Worktime WHERE userID=@id
END
GO
/****** Object:  StoredProcedure [dbo].[uspSearchClients]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspSearchClients]
   @query nvarchar(50)
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Client WHERE CHARINDEX(LOWER(Client.name), LOWER(@query)) = 1
END
GO
/****** Object:  StoredProcedure [dbo].[uspSearchProjects]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspSearchProjects]
   @query nvarchar(50)
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Project WHERE CHARINDEX(LOWER(Project.name), LOWER(@query)) = 1
END
GO
/****** Object:  StoredProcedure [dbo].[uspUpdateClient]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspUpdateClient]
   @name nvarchar(30),
   @address nvarchar(50),
   @city nvarchar(20),
   @zip nvarchar(15),
   @country int,
   @id int
AS
BEGIN
   SET NOCOUNT ON
	UPDATE Client
	SET name=@name, address=@address, city=@city, zip=@zip, countryID=@country
	WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[uspUpdateProject]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspUpdateProject]
   @name nvarchar(30),
   @description nvarchar(60),
   @client int,
   @lead int,
   @status varchar(10),
   @id int
AS
BEGIN
   SET NOCOUNT ON
	UPDATE Project
	SET name=@name, description=@description, clientID=@client, leadID=@lead, status=@status
	WHERE id=@id
END
GO
/****** Object:  StoredProcedure [dbo].[uspUpdateUser]    Script Date: 3.9.2020. 15:45:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspUpdateUser]
   @name nvarchar(30),
   @weekly float,
   @username nvarchar(20),
   @email nvarchar(30),
   @isActive bit,
   @isAdmin bit,
   @id int
AS
BEGIN
   SET NOCOUNT ON
	UPDATE "User"
	SET name=@name, weekly=@weekly, username=@username, email=@email, isActive=@isActive, isAdmin=@isAdmin
	WHERE id=@id
END
GO
