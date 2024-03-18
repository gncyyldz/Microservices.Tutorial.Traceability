CREATE DATABASE TraceabilityDB
GO
USE TraceabilityDB
GO
CREATE TABLE [dbo].[TraceabilityLogs]
(
  [Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
  [EventDateTime] [datetime] NOT NULL,
  [EventLevel] [nvarchar](100) NOT NULL,
  [CorrelationId] [uniqueidentifier] NOT NULL,
  [MachineName] [nvarchar](100) NOT NULL,
  [EventMessage] [nvarchar](max) NOT NULL,
  [ErrorSource] [nvarchar](100) NULL,
  [ErrorClass] [nvarchar](500) NULL,
  [ErrorMethod] [nvarchar](max) NULL,
  [ErrorMessage] [nvarchar](max) NULL,
  [InnerErrorMessage] [nvarchar](max) NULL
)
