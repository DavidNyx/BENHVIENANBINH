USE BENHVIENANHBINH
GO

--DROP PROC INSERT_PDKT
--DROP PROC INSERT_NGH
--DROP PROC INSERT_KH
--DROP PROC INSERT_PDMVX
GO

CREATE PROC INSERT_PDKT
	@MA_PDKT CHAR(5),
	@MA_KH CHAR(5),
	@NGAYTIEM DATE,
	@MA_TT CHAR(5),
	@MA_GVX CHAR(5)
AS
BEGIN 
	IF @NGAYTIEM <= (SELECT GETDATE())
	BEGIN
		RAISERROR (N'Ngày tiêm không hợp lệ', 16, 1)
		RETURN
	END
	INSERT PHIEUDKTIEM VALUES(@MA_PDKT, @MA_KH, @MA_GVX, @MA_TT, @NGAYTIEM)
END
GO

CREATE PROC INSERT_NGH
	@MA_KH CHAR(5),
	@HOTEN NVARCHAR(30),
	@NGAYSINH DATE,
	@SDT CHAR(10),
	@DIACHI NVARCHAR(100)
AS
BEGIN
	IF DATEDIFF(YY, @NGAYSINH, GETDATE()) < 18
		RETURN 0
	ELSE
	BEGIN
		INSERT NGUOIGIAMHO VALUES(@MA_KH, @HOTEN, @NGAYSINH, @DIACHI, @SDT)
		RETURN 1
	END

END
GO

CREATE PROC INSERT_KH
	@MA_KH CHAR(5),
	@HOTEN NVARCHAR(30),
	@NGAYSINH DATE,
	@DIACHI NVARCHAR(100),
	@SDT CHAR(10),
	@CMND CHAR(10),
	@HOTEN_NGH NVARCHAR(30),
	@NGAYSINH_NGH DATE,
	@SDT_NGH CHAR(10),
	@DIACHI_NGH NVARCHAR(100)
AS
BEGIN
	INSERT KHACHHANG VALUES (@MA_KH, @HOTEN, @DIACHI, @NGAYSINH, @SDT, GETDATE(), @CMND)
	IF DATEDIFF(YY, @NGAYSINH, GETDATE()) < 18
	BEGIN
		DECLARE @FLAG BIT
		EXEC @FLAG = INSERT_NGH @MA_KH, @HOTEN_NGH, @NGAYSINH_NGH, @SDT_NGH, @DIACHI_NGH
		IF @FLAG = 0
		BEGIN
			DELETE KHACHHANG WHERE MA_KH = @MA_KH
			RAISERROR (N'Người giám hộ không hợp lệ', 16, 1)
			RETURN
		END
	END
END
GO

CREATE PROC INSERT_PDMVX
	@MA_PDMVX CHAR(5),
	@MA_PDKTIEM CHAR(5),
	@MA_GVX CHAR(5),
	@TEN_GXV NVARCHAR(30)
AS
BEGIN
	IF (@MA_GVX IS NOT NULL AND @TEN_GXV IS NOT NULL) OR (@MA_GVX IS NULL AND @TEN_GXV IS NULL)
	BEGIN
		RAISERROR (N'Mã vắc xin và tên vắc xin không hợp lệ.', 16, 1)
		RETURN
	END
	INSERT PHIEUDATMUAVX (MA_PDMVX, MA_PDKT, MA_GVX, TEN_GVX) VALUES (@MA_PDMVX, @MA_PDKTIEM, @MA_GVX, @TEN_GXV)
END
GO