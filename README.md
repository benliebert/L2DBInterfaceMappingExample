# L2DBInterfaceMappingExample
Repro for L2Db Issue 1365

## Step 1 - create database
Requires Sql Server database, with 'OrderItem' table:

``` sql

CREATE TABLE [dbo].[OrderItem](
	[OrderItemID] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_OrderItem] PRIMARY KEY  
(
	[OrderItemID] ASC
))
GO

insert into OrderItem(Quantity, Name) values (1, 'Apples')
insert into OrderItem(Quantity, Name) values (20, 'Oranges')
insert into OrderItem(Quantity, Name) values (1, 'Grapefruit')
insert into OrderItem(Quantity, Name) values (2, 'Bananas')
GO
```

## Step 2 - reference db in config file
Change your app.config file to point to your new database



