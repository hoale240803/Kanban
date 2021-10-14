/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Name]
      ,[Time]
  FROM [Kanban].[dbo].[Requests]

  delete from Requests