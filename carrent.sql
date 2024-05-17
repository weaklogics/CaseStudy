create database carrent
use carrent

CREATE TABLE Vehicle (
    VehicleID INT PRIMARY KEY,
    Make VARCHAR(50),
    Model VARCHAR(50),
    Year INT,
    DailyRate DECIMAL,
    Status VARCHAR(20),
    PassengerCapacity INT,
    EngineCapacity INT
);

CREATE TABLE Customer (
    CustomerID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
    PhoneNumber VARCHAR(20)
);
CREATE TABLE Lease (
    LeaseID INT PRIMARY KEY,
    VehicleID INT,
    CustomerID INT,
    StartDate DATE,
    EndDate DATE,
    Type VARCHAR(20),
	TotalLeaseAmount  int,
    FOREIGN KEY (VehicleID) REFERENCES Vehicle(VehicleID) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID) ON DELETE CASCADE ON UPDATE CASCADE
);


CREATE TABLE Payment (
    PaymentID INT PRIMARY KEY,
    LeaseID INT,
    PaymentDate DATE,
    Amount DECIMAL(10, 2),
    FOREIGN KEY (LeaseID) REFERENCES Lease(LeaseID) ON DELETE CASCADE ON UPDATE CASCADE
);


INSERT INTO Vehicle (VehicleID, Make, Model, Year,DailyRate, Status,PassengerCapacity,EngineCapacity) VALUES
(1, 'Toyota', 'Corolla', 2019, 50.00, 'available', 5, 2000),
(2, 'Honda', 'Civic', 2020, 60.00, 'available', 5, 1800),
(3, 'Ford', 'Mustang', 2018, 100.00, 'notAvailable', 4, 3000),
(4, 'Chevrolet', 'Silverado', 2021, 80.00, 'available', 3, 3500),
(5, 'BMW', 'X5', 2022, 150.00, 'available', 7, 2500);


INSERT INTO Customer (customerID, firstName, lastName, email, phoneNumber) VALUES
(1, 'Aarav', 'Patel', 'aarav.patel@example.com', '+91 9876543210'),
(2, 'Diya', 'Shah', 'diya.shah@example.com', '+91 8765432109'),
(3, 'Aaradhya', 'Joshi', 'aaradhya.joshi@example.com', '+91 7654321098'),
(4, 'Advik', 'Gupta', 'advik.gupta@example.com', '+91 6543210987'),
(5, 'Vihaan', 'Kumar', 'vihaan.kumar@example.com', '+91 5432109876');

-- Lease Table data
INSERT INTO Lease (LeaseID,VehicleID,CustomerID,StartDate,EndDate,Type,TotalLeaseAmount) VALUES
(1, 1, 1, '2024-05-01', '2024-05-10', 'DailyLease',1230),
(2, 2, 2, '2024-05-05', '2024-06-05', 'MonthlyLease',2323),
(3, 3, 3, '2024-05-10', '2024-05-20', 'DailyLease',3233),
(4, 4, 4, '2024-05-15', '2024-06-15', 'MonthlyLease',33245),
(5, 5, 5, '2024-05-20', '2024-05-25', 'DailyLease',5678);

-- Payment Table data
INSERT INTO Payment (paymentID, leaseID, paymentDate, amount) VALUES
(1, 1, '2024-05-10', 5000.00),
(2, 2, '2024-06-01', 1500.00),
(3, 3, '2024-05-20', 7000.00),
(4, 4, '2024-06-15', 2000.00),
(5, 5, '2024-05-25', 3500.00);


select * from Customer
select * from Lease
select * from Payment



