USE [timesheet]
GO
/****** Object:  StoredProcedure [dbo].[uspAddCategory]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAddCategory]
   @name nvarchar(30),
   @newId int OUTPUT
AS
BEGIN
   SET NOCOUNT ON
	INSERT INTO Category(name) VALUES (@name)
	SET @newId = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[uspAddClient]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAddClient]
   @name nvarchar(30),
   @address nvarchar(50),
   @city nvarchar(20),
   @zip nvarchar(15),
   @country int,
   @newId int OUTPUT
AS
BEGIN
   SET NOCOUNT ON
	INSERT INTO Client (name, address, city, zip, countryID) VALUES (@name, @address, @city, @zip, @country)
	SET @newId = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[uspAddCountry]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAddCountry]
   @name nvarchar(30),
   @short nvarchar(3),
   @newId int OUTPUT
AS
BEGIN
   SET NOCOUNT ON
	INSERT INTO Country(name, short) VALUES (@name, @short)
	SET @newId = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[uspAddProject]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspAddProject]
   @name nvarchar(30),
   @description nvarchar(60),
   @client int,
   @lead int,
   @newId int OUTPUT
AS
BEGIN
   SET NOCOUNT ON
	INSERT INTO Project (name, description, clientID, leadID) VALUES (@name, @description, @client, @lead)
	SET @newId = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[uspAddUser]    Script Date: 18.9.2020. 12:55:08 ******/
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
   @isAdmin bit,
   @newId int OUTPUT
AS
BEGIN
   SET NOCOUNT ON
	INSERT INTO "User" (name, weekly, username, email, isActive, isAdmin) VALUES (@name, @weekly, @username, @email, @isActive, @isAdmin)
	SET @newId = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[uspAddWorktime]    Script Date: 18.9.2020. 12:55:08 ******/
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
   @overtime float,
   @date date,
   @newId int OUTPUT
AS
BEGIN
   SET NOCOUNT ON
	INSERT INTO Worktime(clientID, projectID, categoryID, userID, description, hours, overtime, date) VALUES (@client, @project, @category, @user, @description, @hours, @overtime, @date)
	SET @newId = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[uspChangePassword]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspDeleteClientLogically]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspDeleteClientLogically]
   @id int,
   @violation bit OUTPUT
AS
BEGIN
   SET NOCOUNT ON
   DECLARE @concurrency rowversion
   SELECT @concurrency=concurrency FROM Client WHERE id=@id 

	UPDATE Client
	SET isDeleted=1
	WHERE id=@id AND concurrency=@concurrency
	IF @@ROWCOUNT=0
		BEGIN
			SET @violation = 1
		END
	ELSE
		BEGIN
			SET @violation = 0
		END
END
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteClientPhysically]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspDeleteClientPhysically]
   @id int,
   @violation bit OUTPUT
AS
BEGIN
   SET NOCOUNT ON
   DECLARE @concurrency rowversion
   SELECT @concurrency=concurrency FROM Client WHERE id=@id 

	DELETE FROM Client WHERE id=@id AND concurrency=@concurrency
	IF @@ROWCOUNT=0
		BEGIN
			SET @violation = 1
		END
	ELSE
		BEGIN
			SET @violation = 0
		END
END
GO
/****** Object:  StoredProcedure [dbo].[uspDeleteProjectLogically]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspDeleteProjectPhysically]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspDeleteUserLogically]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspDeleteUserPhysically]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspFilterReports]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspGetAllCategories]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspGetAllClients]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetAllClients]
   
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Client WHERE isDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetAllCountries]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspGetAllProjects]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetAllProjects]
   
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Project WHERE isDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetAllUsers]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetAllUsers]
   
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM "User" WHERE isDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetCategoryById]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspGetCategoryByName]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspGetClientById]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspGetClientByNameAndAddress]    Script Date: 18.9.2020. 12:55:08 ******/
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
	SELECT * FROM Client WHERE LOWER(name)=LOWER(@name) AND LOWER(address)=LOWER(@address) AND isDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetClientsByPage]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetClientsByPage]
   @page int,
   @number int
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY id) AS RowIndex, * FROM Client WHERE isDeleted = 0) AS Sub
	WHERE Sub.RowIndex > ((@page - 1) * @number) AND Sub.RowIndex <= (@page * @number)
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetClientsFirstLetters]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetClientsFirstLetters]

AS
BEGIN
   SET NOCOUNT ON
	SELECT DISTINCT UPPER(LEFT(name, 1)) AS letter FROM Client WHERE isDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetCountryById]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspGetCountryByName]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspGetCountryByShort]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspGetNumberOfClients]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetNumberOfClients]
   
AS
BEGIN
   SET NOCOUNT ON
	SELECT COUNT(*) AS number FROM Client WHERE isDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetNumberOfFilteredClients]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetNumberOfFilteredClients]
   @query nvarchar(50)
AS
BEGIN
   SET NOCOUNT ON
	SELECT COUNT(*) AS number FROM Client WHERE isDeleted = 0 AND CHARINDEX(LOWER(@query), LOWER(name)) = 1
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetNumberOfFilteredProjects]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetNumberOfFilteredProjects]
   @query nvarchar(50)
AS
BEGIN
   SET NOCOUNT ON
	SELECT COUNT(*) AS number FROM Project WHERE isDeleted = 0 AND CHARINDEX(LOWER(@query), LOWER(name)) = 1
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetNumberOfProjects]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetNumberOfProjects]
   
AS
BEGIN
   SET NOCOUNT ON
	SELECT COUNT(*) AS number FROM Project WHERE isDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetProjectById]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspGetProjectByNameAndClient]    Script Date: 18.9.2020. 12:55:08 ******/
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
	SELECT * FROM Project WHERE LOWER(name)=LOWER(@name) AND clientID=@client AND isDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetProjectsByClient]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetProjectsByClient]
   @client int
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Project WHERE clientID=@client AND isDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetProjectsByPage]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetProjectsByPage]
   @page int,
   @number int
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY id) AS RowIndex, * FROM Project WHERE isDeleted = 0) AS Sub
	WHERE Sub.RowIndex > ((@page - 1) * @number) AND Sub.RowIndex <= (@page * @number)
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetProjectsFirstLetters]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetProjectsFirstLetters]

AS
BEGIN
   SET NOCOUNT ON
	SELECT DISTINCT UPPER(LEFT(name, 1)) AS letter FROM Project WHERE isDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetUserByEmail]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetUserByEmail]
   @email nvarchar(30)
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM "User" WHERE email=@email AND isDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetUserById]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspGetUserByUsername]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetUserByUsername]
   @username nvarchar(20)
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM "User" WHERE username=@username AND isDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetWorktimesForUser]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspGetWorktimesForUserAndDate]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetWorktimesForUserAndDate]
   @id int,
   @date date
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Worktime WHERE userID=@id AND date=@date
END
GO
/****** Object:  StoredProcedure [dbo].[uspGetWorktimesTotalHours]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGetWorktimesTotalHours]
   @id int,
   @date date
AS
BEGIN
   SET NOCOUNT ON
	SELECT SUM(COALESCE(hours, 0) + COALESCE(overtime, 0)) AS totalHours FROM Worktime WHERE userID=@id AND date=@date
END
GO
/****** Object:  StoredProcedure [dbo].[uspSearchClients]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspSearchClients]
   @query nvarchar(50)
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Client WHERE CHARINDEX(LOWER(@query), LOWER(name)) = 1 AND isDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[uspSearchClientsByPage]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspSearchClientsByPage]
   @query nvarchar(50),
   @page int,
   @number int
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY id) AS RowIndex, * FROM Client WHERE isDeleted = 0 AND CHARINDEX(LOWER(@query), LOWER(name)) = 1) AS Sub
	WHERE Sub.RowIndex > ((@page - 1) * @number) AND Sub.RowIndex <= (@page * @number)
END
GO
/****** Object:  StoredProcedure [dbo].[uspSearchProjects]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspSearchProjects]
   @query nvarchar(50)
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM Project WHERE CHARINDEX(LOWER(@query), LOWER(name)) = 1 AND isDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[uspSearchProjectsByPage]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspSearchProjectsByPage]
   @query nvarchar(50),
   @page int,
   @number int
AS
BEGIN
   SET NOCOUNT ON
	SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY id) AS RowIndex, * FROM Project WHERE isDeleted = 0 AND CHARINDEX(LOWER(@query), LOWER(name)) = 1) AS Sub
	WHERE Sub.RowIndex > ((@page - 1) * @number) AND Sub.RowIndex <= (@page * @number)
END
GO
/****** Object:  StoredProcedure [dbo].[uspUpdateClient]    Script Date: 18.9.2020. 12:55:08 ******/
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
   @id int,
   @concurrency rowversion,
   @violation bit OUTPUT
AS
BEGIN
   SET NOCOUNT ON

	UPDATE Client
	SET name=@name, address=@address, city=@city, zip=@zip, countryID=@country
	WHERE id=@id AND concurrency=@concurrency
	IF @@ROWCOUNT=0
		BEGIN
			SET @violation = 1
		END
	ELSE
		BEGIN
			SET @violation = 0
		END
END
GO
/****** Object:  StoredProcedure [dbo].[uspUpdateProject]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspUpdateUser]    Script Date: 18.9.2020. 12:55:08 ******/
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
/****** Object:  StoredProcedure [dbo].[uspUpdateWorktime]    Script Date: 18.9.2020. 12:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspUpdateWorktime]
   @client int,
   @project int,
   @category int,
   @description nvarchar(60),
   @hours float,
   @overtime float,
   @id int
AS
BEGIN
   SET NOCOUNT ON
   UPDATE Worktime
	SET clientID=@client, projectID=@project, categoryID=@category, description=@description, hours=@hours, overtime=@overtime
	WHERE id=@id
END
GO
