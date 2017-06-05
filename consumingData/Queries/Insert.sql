USE [ProgrammingInCSharp]
GO

/****** Object: Table [dbo].[People] Script Date: 4/18/2017 1:09:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

insert into dbo.People(FirstName,MiddleName, LastName)
values('John', null, 'Smith'), ('Joe', 'John', 'Smith')
go

