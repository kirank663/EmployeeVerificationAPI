USE [EmployeeVerificationDB]
GO

/****** Object:  Table [dbo].[Employee]    Script Date: 1/16/2025 9:07:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmpId] [numeric](10, 0) NOT NULL,
	[CompanyName] [nvarchar](100) NOT NULL,
	[VerificationCode] [nvarchar](10) NOT NULL
) ON [PRIMARY]
GO

INSERT INTO [dbo].[Employee] VALUES(111,'Cybage','222')
INSERT INTO [dbo].[Employee] VALUES(112,'Cybage','224')
INSERT INTO [dbo].[Employee] VALUES(113,'Cybage','225')
INSERT INTO [dbo].[Employee] VALUES(114,'Cybage','226')

CREATE PROCEDURE [dbo].[Proc_EmployeeVerification]
@empId numeric(10,0)=null,
@companyName nvarchar(100),
@verificationCode nvarchar(10)
AS
BEGIN
	SELECT
		EmpId,
		CompanyName,
		VerificationCode
	FROM
		Employee
	WHERE
		EmpId=@empId and CompanyName=@companyName and VerificationCode=@verificationCode
END




CREATE FUNCTION [dbo].[udf_CheckIfEmployeeIsExist]
(
@empId int
)
RETURNS TABLE
AS
RETURN
(
-- Add the SELECT statement with parameter references here
	SELECT
		EmpId,
		CompanyName,
		VerificationCode
	FROM
		Employee
	WHERE
		EmpId=@empId
)