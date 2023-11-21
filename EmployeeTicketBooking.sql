create database EmployeeTicketBooking
 use EmployeeTicketBooking
 
create table AdminLogin
(
  AdminId nvarchar(max),
  AdminPswd nvarchar(max) not null
)
 
insert into AdminLogin values
('ETBSAdmin','ICS100678')
 
select * from Adminlogin
 
create table Managers
( 
  MgrId int primary key,
  Name nvarchar(max) not null,
  DOB date not null,
  Gender nvarchar(15) not null,
  Email nvarchar(100) not null unique,
  PhoneNumber nvarchar(10) not null unique,
  DOJ date not null,
  DeptName nvarchar(max)not null,
  Designation nvarchar(max) not null,
  RepMgrId int not null,
  MaritalStatus nvarchar(15) not null,
  Address nvarchar(max) not null
)
create table ManagerLogin
(
  ManagerLoginId int foreign key references Managers(MgrId),
  MgrPswd nvarchar(max) not null
)
 
create table Employees
(
  Empid int primary key,
  Name nvarchar(max) not null,
  DOB date not null,
  Gender nvarchar(15),
  Email nvarchar(100) not null unique,
  PhoneNumber nvarchar(10) not null unique,
  DOJ date not null,
  DeptName int not null,
  Designation nvarchar(max),
  RepMgrId int foreign key references Managers(MgrId),
  MaritalStatus nvarchar(15),
  Address nvarchar(max)
)

create table EmployeeLogin
(
  EmpLoginId int foreign key references Employees(EmpId),
  EmpPswd nvarchar(max) not null
)
 
create table TravelAgent
(
  AgentId int primary key,
  Name nvarchar(max) not null,
  Email nvarchar(max),
  PhoneNumber nvarchar(10) not null,
  Agencyid int not null unique
)

create table TravelAgentLogin
(
  AgentLoginId int foreign key references TravelAgent(AgentId),
  AgentPswd nvarchar(max) not null
)
 
create table TravelRequestDetails
(
  RequestId int primary key identity,
  EmpId int foreign key references Employees(EmpId),
  EmpMgrId int foreign key references Managers(MgrId),
  Destination nvarchar(max) not null,
  Purpose nvarchar(max) not null,
  DepartureDate date not null,
  ReturnDate date not null,
  TravelMode nvarchar(max) not null
)
 
create table RequestStatus
(
  BookingId int primary key identity,
  RequestId int foreign key references TravelRequestDetails (RequestId),
  AgentId int foreign key references TravelAgent(AgentId),
  BookingDate date not null,
  ManagerStatus nvarchar(max) not null,
  CostInvolved nvarchar(max) not null,
  TravelAgentStatus nvarchar(max) not null
)
 
 ---------------- Currently Ignore Below Code --------------------------

 -- Audit Table
CREATE TABLE Audit (
    LogID INT PRIMARY KEY,
    --UserID INT, -- Reference to the User performing the action
    Action NVARCHAR(100), -- Description of the action performed
    TimeStamp DATETIME, -- Timestamp for when the action occurred
    Description NVARCHAR(MAX) -- Additional description or details about the action
);

-- Trigger
CREATE TRIGGER Employee_AuditTrigger
ON Employee
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @Action NVARCHAR(100);
    SET @Action = CASE
        WHEN EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted) THEN 'UPDATE'
        WHEN EXISTS (SELECT * FROM inserted) THEN 'INSERT'
        WHEN EXISTS (SELECT * FROM deleted) THEN 'DELETE'
        ELSE NULL
    END;

    IF @Action IS NOT NULL
    BEGIN
        INSERT INTO Audit (UserID, Action, TimeStamp, Description)
        SELECT 
            ISNULL((SELECT UserID FROM inserted), (SELECT UserID FROM deleted)), 
            @Action, 
            GETDATE(),
            'Action performed on Employee table'
    END;
END;
