USE [EileenGaldamez]
GO

--------------------------------------------------------------------------------------------------------------------------------------------------
INSERT INTO  dbo.tblProductType (name, detail) VALUES ('Disposables', 'Descartables');
INSERT INTO  dbo.tblProductType (name, detail) VALUES ('Consumables', 'Consumibles');
INSERT INTO  dbo.tblProductType (name, detail) VALUES ('reusable', 'Reutilizables');
---------------------------------------------------------------------------------------------------------------------------------------------------
INSERT INTO  dbo.tblCellarArea (name, detail) VALUES ('Medical Suplies', 'Suplementos de medicina (SM)');
INSERT INTO  dbo.tblCellarArea (name, detail) VALUES ('General Services', 'Servicios Generales (RG)');
INSERT INTO  dbo.tblCellarArea (name, detail) VALUES ('HouseKeeping', 'Cocina (C)');
INSERT INTO  dbo.tblCellarArea (name, detail) VALUES ('Cafeteria', 'Cafeteria (C)');
----------------------------------------- Read (1) Add(2) Write (3) Delete (4) --------------------------------------------------------------------  
INSERT INTO  dbo.tblTypePermission (name, detail, numberLevel) VALUES ('Read', 'Lectura', '1');
INSERT INTO  dbo.tblTypePermission (name, detail, numberLevel) VALUES ('Read, Add', 'Lectura, Agregar', '3');
INSERT INTO  dbo.tblTypePermission (name, detail, numberLevel) VALUES ('Read, Add, Edit', 'Lectura, Agregar, Editar', '6');
INSERT INTO  dbo.tblTypePermission (name, detail, numberLevel) VALUES ('Read, add, Delete', 'Lectura, Agregar, Eliminar', '7');
INSERT INTO  dbo.tblTypePermission (name, detail, numberLevel) VALUES ('Read, Add, Edit, Delete', 'Lectura, Agregar, Editar, Eliminar', '10');
INSERT INTO  dbo.tblTypePermission (name, detail, numberLevel) VALUES ('Read, Edit', 'Lectura, Editar', '4');
INSERT INTO  dbo.tblTypePermission (name, detail, numberLevel) VALUES ('Read, Edit, Delete', 'Lectura, editar, Eliminar', '8');
INSERT INTO  dbo.tblTypePermission (name, detail, numberLevel) VALUES('Read, Delete', 'Lectura, Eliminar', '5');
----------------------------------------------------------------------------------------------------------------------------------------------------
INSERT INTO  dbo.tblUserType (name, detail) VALUES ('Admin', 'Administracion');
----------------------------------------------------------------------------------------------------------------------------------------------------
INSERT INTO  dbo.tblProvider (companyName, detail) VALUES ('Crudem', 'Crudem');
INSERT INTO  dbo.tblProvider (companyName, detail) VALUES ('Donations', 'It is only donations');
INSERT INTO  dbo.tblProvider (companyName, detail) VALUES ('Nationals', 'Nacionales');
----------------------------------------------------------------------------------------------------------------------------------------------------
INSERT INTO dbo.tblTransactionType (name, detail) VALUES('Cellar','Bodega Principal');
INSERT INTO dbo.tblTransactionType (name, detail) VALUES('Assignment','Bodega Por Departamento O Categoria');
INSERT INTO dbo.tblTransactionType (name, detail) VALUES('DownLoadAssignment','Descarga De La Asignacion');
INSERT INTO dbo.tblTransactionType (name, detail) VALUES('LoanAssignment','Prestamo De La Asignacion');
----------------------------------------------------------------------------------------------------------------------------------------------------
