USE [master]
GO
/****** Object:  Database [DA_QLYKHO]    Script Date: 7/24/2018 12:14:24 PM ******/
CREATE DATABASE [DA_QLYKHO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DA_QLYKHO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DA_QLYKHO.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DA_QLYKHO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\DA_QLYKHO_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DA_QLYKHO] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DA_QLYKHO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DA_QLYKHO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET ARITHABORT OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DA_QLYKHO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DA_QLYKHO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DA_QLYKHO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DA_QLYKHO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DA_QLYKHO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DA_QLYKHO] SET  MULTI_USER 
GO
ALTER DATABASE [DA_QLYKHO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DA_QLYKHO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DA_QLYKHO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DA_QLYKHO] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [DA_QLYKHO] SET DELAYED_DURABILITY = DISABLED 
GO
USE [DA_QLYKHO]
GO
/****** Object:  Table [dbo].[CTPHIEUMUA]    Script Date: 7/24/2018 12:14:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTPHIEUMUA](
	[MaCTPM] [nvarchar](20) NOT NULL,
	[MaPM] [nvarchar](20) NULL,
	[MaHH] [nvarchar](20) NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_CTPHIEUMUA] PRIMARY KEY CLUSTERED 
(
	[MaCTPM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTPHIEUNHAP]    Script Date: 7/24/2018 12:14:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTPHIEUNHAP](
	[MaCTPN] [nvarchar](20) NOT NULL,
	[MaPN] [nvarchar](20) NULL,
	[MaHH] [nvarchar](20) NULL,
	[SoLuong] [int] NULL,
	[GiaNhap] [money] NULL,
 CONSTRAINT [PK_CTPHIEUNHAP] PRIMARY KEY CLUSTERED 
(
	[MaCTPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTPHIEUXUAT]    Script Date: 7/24/2018 12:14:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTPHIEUXUAT](
	[MaCTPX] [nvarchar](20) NOT NULL,
	[MaPX] [nvarchar](20) NULL,
	[MaHH] [nvarchar](20) NULL,
	[SoLuong] [int] NULL,
	[GiaXuat] [money] NULL,
 CONSTRAINT [PK_CTPHIEUXUAT] PRIMARY KEY CLUSTERED 
(
	[MaCTPX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DANGNHAP]    Script Date: 7/24/2018 12:14:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DANGNHAP](
	[ID] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](50) NULL,
	[MaNV] [nvarchar](20) NULL,
	[PhanQuyen] [nvarchar](10) NULL,
 CONSTRAINT [PK_DANGNHAP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HANGHOA]    Script Date: 7/24/2018 12:14:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HANGHOA](
	[MaHH] [nvarchar](20) NOT NULL,
	[TenHangHoa] [nvarchar](100) NULL,
	[MoTa] [nvarchar](500) NULL,
	[DVT] [nvarchar](10) NULL,
	[MaNH] [nvarchar](20) NULL,
	[MaNCC] [nvarchar](20) NULL,
	[GiaVon] [money] NULL,
	[NgayCapNhat] [date] NULL,
 CONSTRAINT [PK_HANGHOA] PRIMARY KEY CLUSTERED 
(
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 7/24/2018 12:14:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [nvarchar](20) NOT NULL,
	[TenKhachHang] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [nvarchar](11) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KHO]    Script Date: 7/24/2018 12:14:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHO](
	[MaKho] [nvarchar](20) NOT NULL,
	[TenKho] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
 CONSTRAINT [PK_KHO] PRIMARY KEY CLUSTERED 
(
	[MaKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NHACUNGCAP]    Script Date: 7/24/2018 12:14:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHACUNGCAP](
	[MaNCC] [nvarchar](20) NOT NULL,
	[TenNCC] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [nvarchar](11) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_NHACUNGCAP] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 7/24/2018 12:14:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MaNV] [nvarchar](20) NOT NULL,
	[TenNhanVien] [nvarchar](50) NULL,
	[ChucVu] [nvarchar](20) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nvarchar](5) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [nvarchar](11) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NHOMHANG]    Script Date: 7/24/2018 12:14:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHOMHANG](
	[MaNH] [nvarchar](20) NOT NULL,
	[TenNhomHang] [nvarchar](100) NULL,
	[MoTa] [nvarchar](500) NULL,
 CONSTRAINT [PK_NHOMHANG] PRIMARY KEY CLUSTERED 
(
	[MaNH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUMUA]    Script Date: 7/24/2018 12:14:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUMUA](
	[MaPM] [nvarchar](20) NOT NULL,
	[NgayLap] [date] NULL,
	[MaNV] [nvarchar](20) NULL,
	[GhiChu] [nvarchar](500) NULL,
 CONSTRAINT [PK_PHIEUMUA] PRIMARY KEY CLUSTERED 
(
	[MaPM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUNHAP]    Script Date: 7/24/2018 12:14:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUNHAP](
	[MaPN] [nvarchar](20) NOT NULL,
	[NgayNhap] [datetime] NULL,
	[MaNCC] [nvarchar](20) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[MaNV] [nvarchar](20) NULL,
	[MaKho] [nvarchar](20) NULL,
	[GhiChu] [nvarchar](500) NULL,
 CONSTRAINT [PK_PHIEUNHAP] PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUXUAT]    Script Date: 7/24/2018 12:14:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUXUAT](
	[MaPX] [nvarchar](20) NOT NULL,
	[NgayXuat] [datetime] NULL,
	[MaKH] [nvarchar](20) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[MaNV] [nvarchar](20) NULL,
	[MaKho] [nvarchar](20) NULL,
	[GhiChu] [nvarchar](500) NULL,
 CONSTRAINT [PK_PHIEUXUAT] PRIMARY KEY CLUSTERED 
(
	[MaPX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TONDAUKY]    Script Date: 7/24/2018 12:14:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TONDAUKY](
	[MaHH] [nvarchar](20) NOT NULL,
	[MaKho] [nvarchar](20) NOT NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [money] NULL,
	[NgayCapNhat] [date] NOT NULL,
	[NgayNhap] [date] NOT NULL,
 CONSTRAINT [PK_TONDAUKY] PRIMARY KEY CLUSTERED 
(
	[MaHH] ASC,
	[MaKho] ASC,
	[NgayCapNhat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CTPHIEUMUA]  WITH CHECK ADD  CONSTRAINT [FK_CTPHIEUMUA_HANGHOA] FOREIGN KEY([MaHH])
REFERENCES [dbo].[HANGHOA] ([MaHH])
GO
ALTER TABLE [dbo].[CTPHIEUMUA] CHECK CONSTRAINT [FK_CTPHIEUMUA_HANGHOA]
GO
ALTER TABLE [dbo].[CTPHIEUMUA]  WITH CHECK ADD  CONSTRAINT [FK_CTPHIEUMUA_PHIEUMUA] FOREIGN KEY([MaPM])
REFERENCES [dbo].[PHIEUMUA] ([MaPM])
GO
ALTER TABLE [dbo].[CTPHIEUMUA] CHECK CONSTRAINT [FK_CTPHIEUMUA_PHIEUMUA]
GO
ALTER TABLE [dbo].[CTPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CTPHIEUNHAP_HANGHOA] FOREIGN KEY([MaHH])
REFERENCES [dbo].[HANGHOA] ([MaHH])
GO
ALTER TABLE [dbo].[CTPHIEUNHAP] CHECK CONSTRAINT [FK_CTPHIEUNHAP_HANGHOA]
GO
ALTER TABLE [dbo].[CTPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CTPHIEUNHAP_PHIEUNHAP] FOREIGN KEY([MaPN])
REFERENCES [dbo].[PHIEUNHAP] ([MaPN])
GO
ALTER TABLE [dbo].[CTPHIEUNHAP] CHECK CONSTRAINT [FK_CTPHIEUNHAP_PHIEUNHAP]
GO
ALTER TABLE [dbo].[CTPHIEUXUAT]  WITH CHECK ADD  CONSTRAINT [FK_CTPHIEUXUAT_HANGHOA] FOREIGN KEY([MaHH])
REFERENCES [dbo].[HANGHOA] ([MaHH])
GO
ALTER TABLE [dbo].[CTPHIEUXUAT] CHECK CONSTRAINT [FK_CTPHIEUXUAT_HANGHOA]
GO
ALTER TABLE [dbo].[CTPHIEUXUAT]  WITH CHECK ADD  CONSTRAINT [FK_CTPHIEUXUAT_PHIEUXUAT] FOREIGN KEY([MaPX])
REFERENCES [dbo].[PHIEUXUAT] ([MaPX])
GO
ALTER TABLE [dbo].[CTPHIEUXUAT] CHECK CONSTRAINT [FK_CTPHIEUXUAT_PHIEUXUAT]
GO
ALTER TABLE [dbo].[DANGNHAP]  WITH CHECK ADD  CONSTRAINT [FK_DANGNHAP_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[DANGNHAP] CHECK CONSTRAINT [FK_DANGNHAP_NHANVIEN]
GO
ALTER TABLE [dbo].[HANGHOA]  WITH CHECK ADD  CONSTRAINT [FK_HANGHOA_NHACUNGCAP] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NHACUNGCAP] ([MaNCC])
GO
ALTER TABLE [dbo].[HANGHOA] CHECK CONSTRAINT [FK_HANGHOA_NHACUNGCAP]
GO
ALTER TABLE [dbo].[HANGHOA]  WITH CHECK ADD  CONSTRAINT [FK_HANGHOA_NHOMHANG] FOREIGN KEY([MaNH])
REFERENCES [dbo].[NHOMHANG] ([MaNH])
GO
ALTER TABLE [dbo].[HANGHOA] CHECK CONSTRAINT [FK_HANGHOA_NHOMHANG]
GO
ALTER TABLE [dbo].[PHIEUMUA]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUMUA_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[PHIEUMUA] CHECK CONSTRAINT [FK_PHIEUMUA_NHANVIEN]
GO
ALTER TABLE [dbo].[PHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUNHAP_KHO] FOREIGN KEY([MaKho])
REFERENCES [dbo].[KHO] ([MaKho])
GO
ALTER TABLE [dbo].[PHIEUNHAP] CHECK CONSTRAINT [FK_PHIEUNHAP_KHO]
GO
ALTER TABLE [dbo].[PHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUNHAP_NHACUNGCAP] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NHACUNGCAP] ([MaNCC])
GO
ALTER TABLE [dbo].[PHIEUNHAP] CHECK CONSTRAINT [FK_PHIEUNHAP_NHACUNGCAP]
GO
ALTER TABLE [dbo].[PHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUNHAP_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[PHIEUNHAP] CHECK CONSTRAINT [FK_PHIEUNHAP_NHANVIEN]
GO
ALTER TABLE [dbo].[PHIEUXUAT]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUXUAT_KHACHHANG] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[PHIEUXUAT] CHECK CONSTRAINT [FK_PHIEUXUAT_KHACHHANG]
GO
ALTER TABLE [dbo].[PHIEUXUAT]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUXUAT_KHO] FOREIGN KEY([MaKho])
REFERENCES [dbo].[KHO] ([MaKho])
GO
ALTER TABLE [dbo].[PHIEUXUAT] CHECK CONSTRAINT [FK_PHIEUXUAT_KHO]
GO
ALTER TABLE [dbo].[PHIEUXUAT]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUXUAT_NHANVIEN] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NHANVIEN] ([MaNV])
GO
ALTER TABLE [dbo].[PHIEUXUAT] CHECK CONSTRAINT [FK_PHIEUXUAT_NHANVIEN]
GO
ALTER TABLE [dbo].[TONDAUKY]  WITH CHECK ADD  CONSTRAINT [FK_TONDAUKY_HANGHOA] FOREIGN KEY([MaHH])
REFERENCES [dbo].[HANGHOA] ([MaHH])
GO
ALTER TABLE [dbo].[TONDAUKY] CHECK CONSTRAINT [FK_TONDAUKY_HANGHOA]
GO
ALTER TABLE [dbo].[TONDAUKY]  WITH CHECK ADD  CONSTRAINT [FK_TONDAUKY_KHO] FOREIGN KEY([MaKho])
REFERENCES [dbo].[KHO] ([MaKho])
GO
ALTER TABLE [dbo].[TONDAUKY] CHECK CONSTRAINT [FK_TONDAUKY_KHO]
GO
USE [master]
GO
ALTER DATABASE [DA_QLYKHO] SET  READ_WRITE 
GO
