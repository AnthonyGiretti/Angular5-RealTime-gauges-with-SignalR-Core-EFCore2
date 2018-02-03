# Angular5-RealTime-gauges-with-SignalR-Core-EFCore2

![Example](http://anthonygiretti.com/wp-content/uploads/2017/12/demoanimated.gif)

## Setup SQL Database

For an easy setup with SQL SERVER, I recommand to use LocalDB, installed automatically since Visual Studio 2012

Use for example SQL Management Studio V12+ top type this serie of commands:

### Create Database
```CREATE DATABASE SignalRDemo;```

### Create SQL table for the project
```
USE [SignalRDemo]
GO

/****** Object:  Table [dbo].[GaugesData]    Script Date: 2017-12-30 14:51:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[GaugesData](
	[Id] [int] NOT NULL,
	[Memory] [int] NOT NULL,
	[Cpu] [int] NOT NULL,
	[Network] [int] NOT NULL,
 CONSTRAINT [PK_GaugesData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
```

### Enable service broker
```ALTER DATABASE SignalRDemo SET ENABLE_BROKER with rollback immediate```

Then populate table with data (minimum 0, maximum 100)

<strong>You may have some issues with service broker when you use Windows Authentification</strong>, notifications from database might not be fired, then use a SQL Server login / password authentification

## Setup Angular project

### Install Angular-CLI 1.6.3 or later

```npm install -g angular-cli@1.6.3```

### Install the project 

Download the repository and install the project like this ```npm install```

## Setup .NET Core project

### Requirements

[Visual Studio 2017](https://www.visualstudio.com/downloads/) and [.Net Core 2](https://www.microsoft.com/net/download/windows) are required
Download repository

### Install required Nuget Packages

Microsoft.AspNetCore.SignalR ```Install-Package Microsoft.AspNetCore.SignalR -Version 1.0.0-alpha2-final```
Microsoft.EntityFrameworkCore ```Install-Package Microsoft.EntityFrameworkCore -Version 2.0.1```
Microsoft.EntityFrameworkCore.SqlServer ```Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 2.0.1```
SqlTableDependency ```Install-Package SqlTableDependency -Version 6.1.0```

### Build and run 
In my solution (and in Agnular config) I use http://localhost:33383/ Url

## Informations
This project uses [Google Charts](https://developers.google.com/chart/interactive/docs/gallery), especially Gauges charts.
This project is fully reusable for any Google Charts.

