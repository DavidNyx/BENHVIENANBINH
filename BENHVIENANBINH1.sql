﻿CREATE DATABASE BENHVIENANHBINH
GO

USE BENHVIENANHBINH
GO

CREATE TABLE NHACUNGCAP
(
	MA_NCC CHAR(5),
	TEN_NCC NVARCHAR(30) NOT NULL,
	DIACHI_NCC NVARCHAR(100) NOT NULL,
	SDT_NCC CHAR(10) NOT NULL,
	CONSTRAINT PK_NCC PRIMARY KEY(MA_NCC)
)
GO

CREATE TABLE KHACHHANG
(
	MA_KH CHAR(5),
	TEN_KH NVARCHAR(30) NOT NULL,
	DIACHI_KH NVARCHAR(100) NOT NULL,
	NGAYSINH DATE NOT NULL,
	SDT_KH CHAR(10) NOT NULL,
	NGAYLAP DATE NOT NULL,
	CMND CHAR(10) NOT NULL UNIQUE,
	CONSTRAINT PK_KH PRIMARY KEY(MA_KH)
)
GO

CREATE TABLE NGUOIGIAMHO --kiểm tra tuổi KH < 18 thì có NGH >= 18
(
	MA_KH CHAR(5),--FK
	HOTEN_NGH NVARCHAR(30) NOT NULL,
	NGAYSINH_NGH DATE NOT NULL,
	DIACHI_NGH NVARCHAR(100) NOT NULL,
	SDT_NGH CHAR(10) NOT NULL,
	CONSTRAINT PK_NGH PRIMARY KEY(MA_KH)
)
GO

CREATE TABLE TRUNGTAM
(
	MA_TT CHAR(5),
	TEN_TT NVARCHAR(30) NOT NULL,
	DIACHI_TT NVARCHAR(100) NOT NULL,
	SDT_TT CHAR(10) NOT NULL,
	CONSTRAINT PK_TT PRIMARY KEY(MA_TT)
)
GO

CREATE TABLE NHANVIEN
(
	MA_NV CHAR(5),
	TEN_NV NVARCHAR(30) NOT NULL,
	SDT_NV CHAR(10) NOT NULL,
	EMAIL_NV NVARCHAR(100) NOT NULL,
	DIACHI_NV NVARCHAR(100) NOT NULL,
	MA_TT CHAR(5) NOT NULL,--FK
	VITRI NVARCHAR(20) NOT NULL,
	BANGCAP NVARCHAR(20),
	CONSTRAINT PK_NV PRIMARY KEY(MA_NV),
	CONSTRAINT CONS_VITRI CHECK (VITRI IN(N'Kế toán', N'Bác sĩ', N'Y tá', N'Hướng dẫn', N'Quản lý', N'Điều hành'))
)
GO

CREATE TABLE GOIVACXIN
(
	MA_GVX CHAR(5),
	TEN_GVX NVARCHAR(30) NOT NULL,
	LOAI_GVX BIT NOT NULL, --0 là tiêm lẻ, 1 là gói tiêm, 2 là tiêm bắt buộc theo gói
	NGAYSX DATE,
	NGAYHH DATE,
	DOITUONGTIEM NVARCHAR(100),
	GHICHU_GVX NVARCHAR(100),
	GIATIEN FLOAT,
	CONSTRAINT PK_GVX PRIMARY KEY(MA_GVX),
	CONSTRAINT CONS_LOAI CHECK (LOAI_GVX IN(0, 1, 2))
)
GO

CREATE TABLE CHITIET_GVX
(
	MA_GVX CHAR(5), --kiểm tra LOAI_GXV = 1--FK
	MA_VX CHAR(5), --kiểm tra LOAI_GXV = 0, 2--FK
	CONSTRAINT PK_CTGXV PRIMARY KEY(MA_GVX, MA_VX)
)
GO

CREATE TABLE KHO
(
	MA_TT CHAR(5),
	MA_GVX CHAR(5),--FK
	SOLUONGTON INT NOT NULL,
	CONSTRAINT PK_KHO PRIMARY KEY(MA_TT, MA_GVX)
)
GO

CREATE TABLE PHIEUDKTIEM
(
	MA_PDKT CHAR(5),
	MA_KH CHAR(5) NOT NULL,--FK
	MA_GVX CHAR(5),--FK
	MA_TT CHAR(5) NOT NULL,--FK
	THOIGIANTIEM DATE NOT NULL,	
	CONSTRAINT PK_PDKT PRIMARY KEY(MA_PDKT)
)
GO

CREATE TABLE PHIEUDATMUAVX -- kiểm tra chỉ được nhập MA_GVX(cho vắc xin đã có trong hệ thống) hoặc TEN_GVX(cho vắc xin không có trong hệ thống)
(
	MA_PDMVX CHAR(5),
	MA_PDKT CHAR(5) NOT NULL,--FK
	MA_GVX CHAR(5),--FK
	TEN_GVX NVARCHAR(30),
	DUYET_PDMVX BIT NOT NULL DEFAULT 0,
	MA_DSDMVX CHAR(5),--FK
	CONSTRAINT PK_PDMVX PRIMARY KEY(MA_PDMVX),
	CONSTRAINT CONS_DPDMVX CHECK (DUYET_PDMVX IN(0, 1))
)
GO

CREATE TABLE DANHSACHDATMUAVX
(
	MA_DSDMVX CHAR(5),
	NGAYLAP_DSDMVX DATE NOT NULL,
	SOLUONGDAT INT,
	CONSTRAINT PK_DSDMVXTHT PRIMARY KEY(MA_DSDMVX)
)
GO

CREATE TABLE PHIEUNHAPHANG
(
	MA_PNH CHAR(5),
	MA_DSMDVX CHAR(5) NOT NULL,--FK
	MA_NCC CHAR(5) NOT NULL,--FK
	NGAYGUIPHIEU DATE NOT NULL,
	CONSTRAINT PK_PNH PRIMARY KEY(MA_PNH)
)
GO

CREATE TABLE HOADON
(
	MA_HD CHAR(5),
	MA_PDKT CHAR(5) NOT NULL,--FK
	NGAYLAP_HD DATE NOT NULL,
	STK CHAR(10),
	HINHTHUCTHANHTOAN BIT NOT NULL, --0 là thanh toán 1 lần, 1 là thanh toán theo đợt
	TONGTIEN FLOAT NOT NULL,
	DATHANHTOAN BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_HD PRIMARY KEY(MA_HD),
	CONSTRAINT CONS_HTTT CHECK (HINHTHUCTHANHTOAN IN(0, 1)),
	CONSTRAINT CONS_DTTHD CHECK (DATHANHTOAN IN(0, 1))
)
GO

CREATE TABLE CHITIET_HD
(
	MA_HD CHAR(5),--FK
	DOTTHANHTOAN INT,
	SOTIENTHANHTOAN FLOAT NOT NULL,
	HANTHANHTOAN DATE NOT NULL,
	DATHANHTOAN BIT NOT NULL, --0 là chưa thanh toán, 1 là đã thanh toán
	CONSTRAINT PK_CTHD PRIMARY KEY(MA_HD, DOTTHANHTOAN),
	CONSTRAINT CONS_DTTCTHD CHECK (DATHANHTOAN IN(0, 1))
)
GO

CREATE TABLE LICHRANH
(
	MA_NV CHAR(5),--FK
	NGAYRANH DATE NOT NULL,
	CARANH BIT NOT NULL, --0 là sáng, 1 là chiều, 2 là tối
	CONSTRAINT PK_LR PRIMARY KEY(MA_NV),
	CONSTRAINT CONS_CARANH CHECK (CARANH IN(0, 1, 2))
)
GO

CREATE TABLE LICHLAMVIEC
(
	MA_NV CHAR(5),--FK
	NGAYLAMVIEC DATE NOT NULL,
	CALAMVIEC BIT NOT NULL, --0 là sáng, 1 là chiều, 2 là tối
	CONSTRAINT PK_LLV PRIMARY KEY(MA_NV),
	CONSTRAINT CONS_CALAMVIEC CHECK (CALAMVIEC IN(0, 1, 2))
)
GO

CREATE TABLE HANGCHO
(
	STT CHAR(5),
	MA_PDKT CHAR(5) NOT NULL,--FK
	CONSTRAINT PK_HC PRIMARY KEY(STT)
)
GO

CREATE TABLE HOSOBENHAN
(
	MA_HSBA CHAR(5),
	MA_PDKT CHAR(5) NOT NULL,--FK
	MA_BS CHAR(5) NOT NULL,--FK
	NGAYKHAM DATE NOT NULL,
	NOIDUNGKHAM NVARCHAR(250) NOT NULL,
	VACXINCHIDINH CHAR(5),--FK
	KETLUAN NVARCHAR(250) NOT NULL,
	CONSTRAINT PK_HSBA PRIMARY KEY(MA_HSBA)
)
GO

ALTER TABLE NGUOIGIAMHO
ADD CONSTRAINT FK_NGH_KH
FOREIGN KEY(MA_KH)
REFERENCES KHACHHANG
GO

ALTER TABLE NHANVIEN
ADD CONSTRAINT FK_NV_TT
FOREIGN KEY(MA_TT)
REFERENCES TRUNGTAM
GO

ALTER TABLE CHITIET_GVX
ADD CONSTRAINT FK_CTGVX_GVX
FOREIGN KEY(MA_GVX)
REFERENCES GOIVACXIN
GO

ALTER TABLE CHITIET_GVX
ADD CONSTRAINT FK_CTGVX_VX
FOREIGN KEY(MA_VX)
REFERENCES GOIVACXIN
GO

ALTER TABLE KHO
ADD CONSTRAINT FK_KHO_TT
FOREIGN KEY(MA_TT)
REFERENCES TRUNGTAM
GO

ALTER TABLE KHO
ADD CONSTRAINT FK_KHO_GVX
FOREIGN KEY(MA_GVX)
REFERENCES GOIVACXIN
GO

ALTER TABLE PHIEUDKTIEM
ADD CONSTRAINT FK_PDKT_KH
FOREIGN KEY(MA_KH)
REFERENCES KHACHHANG
GO

ALTER TABLE PHIEUDKTIEM
ADD CONSTRAINT FK_PDKT_GVX
FOREIGN KEY(MA_GVX)
REFERENCES GOIVACXIN
GO

ALTER TABLE PHIEUDKTIEM
ADD CONSTRAINT FK_PDKT_TT
FOREIGN KEY(MA_TT)
REFERENCES TRUNGTAM
GO

ALTER TABLE PHIEUDATMUAVX
ADD CONSTRAINT FK_PDMVX_PDKT
FOREIGN KEY(MA_PDKT)
REFERENCES PHIEUDKTIEM
GO

ALTER TABLE PHIEUDATMUAVX
ADD CONSTRAINT FK_PDMXV_GVX
FOREIGN KEY(MA_GVX)
REFERENCES GOIVACXIN
GO

ALTER TABLE PHIEUDATMUAVX
ADD CONSTRAINT FK_PDMXV_DSDMVX
FOREIGN KEY(MA_DSDMVX)
REFERENCES DANHSACHDATMUAVX
GO

ALTER TABLE PHIEUNHAPHANG
ADD CONSTRAINT FK_PNH_DSDMVX
FOREIGN KEY(MA_DSMDVX)
REFERENCES DANHSACHDATMUAVX
GO

ALTER TABLE PHIEUNHAPHANG
ADD CONSTRAINT FK_PNH_NCC
FOREIGN KEY(MA_NCC)
REFERENCES NHACUNGCAP
GO

ALTER TABLE HOADON
ADD CONSTRAINT FK_HD_PDKT
FOREIGN KEY(MA_PDKT)
REFERENCES PHIEUDKTIEM
GO

ALTER TABLE CHITIET_HD
ADD CONSTRAINT FK_CTHD_HD
FOREIGN KEY(MA_HD)
REFERENCES HOADON
GO

ALTER TABLE LICHRANH
ADD CONSTRAINT FK_LR_NV
FOREIGN KEY(MA_NV)
REFERENCES NHANVIEN
GO

ALTER TABLE LICHLAMVIEC
ADD CONSTRAINT FK_LLV_NV
FOREIGN KEY(MA_NV)
REFERENCES NHANVIEN
GO

ALTER TABLE HANGCHO
ADD CONSTRAINT FK_HC_PDKT
FOREIGN KEY(MA_PDKT)
REFERENCES PHIEUDKTIEM
GO

ALTER TABLE HOSOBENHAN
ADD CONSTRAINT FK_HSBA_PDKT
FOREIGN KEY(MA_PDKT)
REFERENCES PHIEUDKTIEM
GO

ALTER TABLE HOSOBENHAN
ADD CONSTRAINT FK_HSBA_BS
FOREIGN KEY(MA_BS)
REFERENCES NHANVIEN
GO

ALTER TABLE HOSOBENHAN
ADD CONSTRAINT FK_HSBA_VXCD
FOREIGN KEY(VACXINCHIDINH)
REFERENCES GOIVACXIN
GO