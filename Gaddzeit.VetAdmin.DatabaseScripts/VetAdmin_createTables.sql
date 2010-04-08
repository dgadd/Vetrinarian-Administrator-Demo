--VET ADMIN CREATE TABLES SCRIPT
--2010Apr07  David Gadd
--Use this script to drop and recreate the tables related to VetAdmin
-------------------------------------------------------
--DROP ALL FKCONSTRAINT INDEXES AND TABLES-------------
--CREATE TABLE: Pet------------------------------------
--CREATE INDEXES FOR: Pet------------------------------
--INSERT DATA TO: Pet----------------------------------
-------------------------------------------------------



-------------------------------------------------------
--DROP ALL FKCONSTRAINT INDEXES AND TABLES-------------

PRINT N' '
PRINT N'##### Begin drop constaints/indexes/tables.'
PRINT N' '

--ALTER TABLE dbo.StaffMember DROP CONSTRAINT FK_StaffMember_PersonRole;
--DONT USE THIS, TOO POWERFUL: exec sp_MSforeachtable 'DROP TABLE ? PRINT '? to be dropped' '

PRINT N' '
PRINT N'##### End drop constaints/indexes/tables.'
PRINT N' '


-------------------------------------------------------
--CREATE TABLE: Pet------------------------------------

PRINT N' '
PRINT N'##### CREATE TABLE Pet begin.'
PRINT N' '

IF EXISTS(SELECT name 
	  FROM 	 sysobjects 
	  WHERE   name = N'Pet' 
	  AND 	 type = 'U')
    DROP TABLE Pet
GO

CREATE TABLE Pet
(
PetID INT PRIMARY KEY NOT NULL Identity(1, 1),
PetName VarChar(50) NOT NULL,
Breed VarChar(50) NOT NULL,
Age int NOT NULL,
HealthHistory VarChar(500) NOT NULL,
--RoleID int CONSTRAINT FK_PersonRole_Role FOREIGN KEY (RoleID)
--   REFERENCES Role(RoleID),
ModifiedBy VarChar(40) NOT NULL,
ModifiedDate DateTime NOT NULL
)
GO

PRINT N' '
PRINT N'##### CREATE TABLE Pet end.'
PRINT N' '

-------------------------------------------------------
--CREATE INDEXES FOR: Pet------------------------------


SET NOCOUNT ON
USE SQL2008_717150_vetadmin
IF EXISTS (SELECT name FROM sysindexes 
      WHERE name = 'Pet_IX_PetName')
   DROP INDEX Pet.Pet_IX_PetName
GO
SET NOCOUNT OFF
USE SQL2008_717150_vetadmin
CREATE INDEX [Pet_IX_PetName] ON [dbo].[Pet] 
(
	[PetName] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO

PRINT N' '
PRINT N'##### Pet_IX_PetName index created.'
PRINT N' '


-------------------------------------------------------
--INSERT DATA TO: Pet----------------------------------

USE SQL2008_717150_vetadmin
GO

INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Fido', 'pug', 3, 'diabetes risk', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Melody', 'domestic shorthair', 2, 'gingivitis', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Sandy', 'jack russell', 5, 'perfect health', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Clarence', 'beagle', 7, 'perfect health', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Skinny', 'calico', 2, 'perfect health', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Lucy', 'german shephard', 14, 'perfect health', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Mao', 'westie', 4, 'perfect health', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Jenny', 'yorkie', 6, 'perfect health', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Fifi', 'persian', 1, 'hip socket issues', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Roger', 'burmese', 7, 'perfect health', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Rachel', 'pyrhenees', 16, 'perfect health', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Luis', 'black lab', 12, 'hard of hearing', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Horton', 'golden retriever', 11, 'arthritis', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Lassie', 'domestic shorthair', 2, 'perfect health', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Frederick', 'pug', 4, 'glaucoma', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Ira', 'beagle', 7, 'sickly', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Flossie', 'newfoundland', 9, 'diabetes', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('George', 'shiz tzu', 11, 'worms', 'DatabaseScript', GETDATE())
INSERT INTO Pet (PetName, Breed, Age, HealthHistory, ModifiedBy, ModifiedDate) VALUES ('Peyton', 'tibetan spaniel', 5, 'perfect health', 'DatabaseScript', GETDATE())

GO

PRINT N' '
PRINT N'##### Test data inserted to table: Pet.'
PRINT N' '


--END OF SCRIPT----------------------------------------
