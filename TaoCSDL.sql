IF EXISTS(SELECT * FROM sys.databases WHERE name = 'ThucTap')
begin
	 use master
	alter database ThucTap set single_user with rollback immediate
	Drop Database ThucTap
end

IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'ThucTap')
BEGIN
CREATE DATABASE ThucTap
END
GO
 USE ThucTap
GO

Create table Khoa (
	makhoa char(10) not null primary key,
	tenkhoa char(30),
	dienthoai char(10),
);
GO

Create table GiangVien (
	magv int not null primary key,
	hotengv char(30),
	luong decimal(5,2),
	makhoa char(10) not null foreign key REFERENCES Khoa(makhoa)
);
GO

create table SinhVien (
	masv int not null primary key,
	hotensv char(30),
	makhoa char(10) not null foreign key REFERENCES Khoa(makhoa),
	namsinh int,
	quequan char(30)
);
GO

create table DeTai (
	madt char(10) not null primary key,
	tendt char(30),
	kinhphi int,
	noithuctap char(30)
);
GO

create table HuongDan (
	mahd int identity(1,1) not null primary key,
	masv int not null foreign key REFERENCES SinhVien(masv),
	madt char(10) not null foreign key REFERENCES DeTai(madt),
	magv int not null foreign key REFERENCES GiangVien(magv),
	ketqua decimal(5,2),
	--primary key(masv,madt,magv)
);
GO

insert into Khoa Values
('Geo','Dia ly va QLTN',3855413),
('Math','Toan',3855411),
('Bio','Cong nghe Sinh hoc',3855412);

INSERT INTO GiangVien VALUES
(11,'Thanh Binh',700,'Geo'),    
(12,'Thu Huong',500,'Math'),
(13,'Chu Vinh',650,'Geo'),
(14,'Le Thi Ly',500,'Bio'),
(15,'Tran Son',900,'Math');

INSERT INTO SinhVien VALUES
(1,'Le Van Son','Bio',1990,'Nghe An'),
(2,'Nguyen Thi Mai','Geo',1990,'Thanh Hoa'),
(3,'Bui Xuan Duc','Math',1992,'Ha Noi'),
(4,'Nguyen Van Tung','Bio',null,'Ha Tinh'),
(5,'Le Khanh Linh','Bio',1989,'Ha Nam'),
(6,'Tran Khac Trong','Geo',1991,'Thanh Hoa'),
(7,'Le Thi Van','Math',null,'null'),
(8,'Hoang Van Duc','Bio',1992,'Nghe An');

INSERT INTO DeTai VALUES
('Dt01','GIS',100,'Nghe An'),
('Dt02','ARC GIS',500,'Nam Dinh'),
('Dt03','Spatial DB',100, 'Ha Tinh'),
('Dt04','MAP',300,'Quang Binh' );

INSERT INTO HuongDan VALUES
(1,'Dt01',13,8),
(2,'Dt03',14,0),
(3,'Dt03',12,10),
(5,'Dt04',14,7),
(6,'Dt01',13,Null),
(7,'Dt04',11,10),
(8,'Dt03',15,6);
