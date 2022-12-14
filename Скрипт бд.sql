USE [master]
GO
/****** Object:  Database [Продажа билетов на самолет]    Script Date: 23.11.2022 19:33:55 ******/
CREATE DATABASE [Продажа билетов на самолет]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Продажа билетов на самолет', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Продажа билетов на самолет.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Продажа билетов на самолет_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Продажа билетов на самолет_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Продажа билетов на самолет] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Продажа билетов на самолет].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Продажа билетов на самолет] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET ARITHABORT OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Продажа билетов на самолет] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Продажа билетов на самолет] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Продажа билетов на самолет] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Продажа билетов на самолет] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Продажа билетов на самолет] SET  MULTI_USER 
GO
ALTER DATABASE [Продажа билетов на самолет] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Продажа билетов на самолет] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Продажа билетов на самолет] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Продажа билетов на самолет] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Продажа билетов на самолет] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Продажа билетов на самолет] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Продажа билетов на самолет] SET QUERY_STORE = OFF
GO
USE [Продажа билетов на самолет]
GO
/****** Object:  UserDefinedFunction [dbo].[МинимальноеКоличествоМестВСамолете]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[МинимальноеКоличествоМестВСамолете] ()

RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @МинКолвоМест int 

	-- Add the T-SQL statements to compute the return value here
	SELECT @МинКолвоМест= Min(КоличествоМест)
	From Самолеты

	-- Return the result of the function
	RETURN @МинКолвоМест

END

GO
/****** Object:  UserDefinedFunction [dbo].[ПассажирыСБагажом]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[ПассажирыСБагажом] (@Багаж bit)

RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @КоличествоПассажиров int

	-- Add the T-SQL statements to compute the return value here
	SELECT @КоличествоПассажиров = COUNT(КодПассажира)
	FROM Билеты
	WHERE Багаж = @Багаж

	-- Return the result of the function
	RETURN @КоличествоПассажиров

END

GO
/****** Object:  UserDefinedFunction [dbo].[СовершеннолетниеПассажиры]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[СовершеннолетниеПассажиры] ()

RETURNS int
AS
BEGIN
	-- Declare the return variable here
	DECLARE @КоличествоСовершеннолетних int

	-- Add the T-SQL statements to compute the return value here
	SELECT @КоличествоСовершеннолетних = COUNT(КодПассажира)
	FROM Пассажиры
	WHERE YEAR(GetDate()) - YEAR(ДатаРождения) >= 18

	-- Return the result of the function
	RETURN @КоличествоСовершеннолетних

END

GO
/****** Object:  Table [dbo].[Билеты]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Билеты](
	[КодБилета] [bigint] NOT NULL,
	[КодРейса] [int] NOT NULL,
	[КодАвиакомпании] [int] NOT NULL,
	[КодПассажира] [int] NOT NULL,
	[НазваниеКласса] [nvarchar](50) NULL,
	[ДатаПокупкиБилета] [date] NOT NULL,
	[ВремяПокупкиБилета] [time](7) NOT NULL,
	[Багаж] [bit] NULL,
 CONSTRAINT [PK_Билеты] PRIMARY KEY CLUSTERED 
(
	[КодБилета] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Пассажиры]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Пассажиры](
	[КодПассажира] [int] NOT NULL,
	[Фамилия] [nvarchar](50) NOT NULL,
	[Имя] [nvarchar](50) NOT NULL,
	[Отчество] [nvarchar](50) NOT NULL,
	[СерияПаспорта] [int] NOT NULL,
	[НомерПаспорта] [int] NOT NULL,
	[МобильныйТелефон] [nvarchar](50) NULL,
	[ДатаРождения] [date] NOT NULL,
 CONSTRAINT [PK_Пассажиры] PRIMARY KEY CLUSTERED 
(
	[КодПассажира] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ПассажирыКлассы]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ПассажирыКлассы]
AS
SELECT        dbo.Пассажиры.Фамилия, dbo.Пассажиры.Имя, dbo.Пассажиры.Отчество, dbo.Билеты.НазваниеКласса
FROM            dbo.Пассажиры INNER JOIN
                         dbo.Билеты ON dbo.Пассажиры.КодПассажира = dbo.Билеты.КодПассажира
GO
/****** Object:  Table [dbo].[Аэропорты]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Аэропорты](
	[КодАэропорта] [int] NOT NULL,
	[Наименование] [nvarchar](50) NOT NULL,
	[Город] [nvarchar](50) NOT NULL,
	[Телефон] [nvarchar](50) NULL,
 CONSTRAINT [PK_Аэропорты] PRIMARY KEY CLUSTERED 
(
	[КодАэропорта] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Рейсы]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Рейсы](
	[КодРейса] [int] NOT NULL,
	[КодАвиакомпании] [int] NOT NULL,
	[КодСамолёта] [int] NOT NULL,
	[Отправление] [int] NOT NULL,
	[Прибытие] [int] NOT NULL,
	[ДатаОтправления] [date] NOT NULL,
	[ДатаПрибытия] [date] NOT NULL,
	[ВремяОтправления] [time](7) NOT NULL,
	[ВремяПрибытия] [time](7) NOT NULL,
	[ДлительностьПерелета] [nvarchar](50) NOT NULL,
	[СтоимостьБилета] [money] NOT NULL,
 CONSTRAINT [PK_Рейсы] PRIMARY KEY CLUSTERED 
(
	[КодРейса] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ПассажирыОтправление]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ПассажирыОтправление]
AS
SELECT        dbo.Пассажиры.Фамилия, dbo.Пассажиры.Имя, dbo.Пассажиры.Отчество, dbo.Аэропорты.Город AS ГородОтправления
FROM            dbo.Билеты INNER JOIN
                         dbo.Пассажиры ON dbo.Билеты.КодПассажира = dbo.Пассажиры.КодПассажира INNER JOIN
                         dbo.Рейсы ON dbo.Билеты.КодРейса = dbo.Рейсы.КодРейса INNER JOIN
                         dbo.Аэропорты ON dbo.Рейсы.Отправление = dbo.Аэропорты.КодАэропорта
GO
/****** Object:  Table [dbo].[Авиакомпании]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Авиакомпании](
	[КодАвиакомпании] [int] NOT NULL,
	[Наименование] [nvarchar](50) NOT NULL,
	[Телефон] [nvarchar](50) NULL,
	[ЭлектронныйАдрес] [nvarchar](50) NULL,
 CONSTRAINT [PK_Авиакомпании] PRIMARY KEY CLUSTERED 
(
	[КодАвиакомпании] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Самолеты]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Самолеты](
	[КодСамолета] [int] NOT NULL,
	[КодАвиакомпании] [int] NOT NULL,
	[МодельСамолета] [nvarchar](50) NOT NULL,
	[КоличествоМест] [int] NULL,
 CONSTRAINT [PK_Самолеты] PRIMARY KEY CLUSTERED 
(
	[КодСамолета] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Авиакомпании] ([КодАвиакомпании], [Наименование], [Телефон], [ЭлектронныйАдрес]) VALUES (319, N'S7 Airlines', N'8 495 783-07-07', N'presscenter@s7.ru')
INSERT [dbo].[Авиакомпании] ([КодАвиакомпании], [Наименование], [Телефон], [ЭлектронныйАдрес]) VALUES (320, N'Ural Airlines', N'8 800 770-02-62', N'vacancy@u6.ru')
INSERT [dbo].[Авиакомпании] ([КодАвиакомпании], [Наименование], [Телефон], [ЭлектронныйАдрес]) VALUES (737, N'Pegas Fly', N'8 495 228-31-84', N'pegast@pegast.ru')
INSERT [dbo].[Авиакомпании] ([КодАвиакомпании], [Наименование], [Телефон], [ЭлектронныйАдрес]) VALUES (777, N'Aeroflot', N'8 800 444-55-55', N'follow@aeroflot.ru')
INSERT [dbo].[Авиакомпании] ([КодАвиакомпании], [Наименование], [Телефон], [ЭлектронныйАдрес]) VALUES (801, N'IrAero', N'8 800 707-49-96', N'info@iraero.ru')
INSERT [dbo].[Авиакомпании] ([КодАвиакомпании], [Наименование], [Телефон], [ЭлектронныйАдрес]) VALUES (823, N'Red Wings Airlines', N'8 800 350-99-77', N'info@aero-alliance.ru')
GO
INSERT [dbo].[Аэропорты] ([КодАэропорта], [Наименование], [Город], [Телефон]) VALUES (12, N'Шереметьево', N'Москва', N'8 495 578-65-65')
INSERT [dbo].[Аэропорты] ([КодАэропорта], [Наименование], [Город], [Телефон]) VALUES (15, N'Пулково', N'Санкт-Петербург', N'8 812 337-38-22')
INSERT [dbo].[Аэропорты] ([КодАэропорта], [Наименование], [Город], [Телефон]) VALUES (17, N'Стригино', N'Нижний Новгород', N'8 831 261-80-80')
INSERT [dbo].[Аэропорты] ([КодАэропорта], [Наименование], [Город], [Телефон]) VALUES (19, N'Большое Савино', N'Пермь', N'8 342 299-17-71')
INSERT [dbo].[Аэропорты] ([КодАэропорта], [Наименование], [Город], [Телефон]) VALUES (21, N'Кневичи', N'Владивосток', N'8 423 376-79-09')
INSERT [dbo].[Аэропорты] ([КодАэропорта], [Наименование], [Город], [Телефон]) VALUES (23, N'Кольцово', N'Екатеринбург', N'8 800 100-03-33')
GO
INSERT [dbo].[Билеты] ([КодБилета], [КодРейса], [КодАвиакомпании], [КодПассажира], [НазваниеКласса], [ДатаПокупкиБилета], [ВремяПокупкиБилета], [Багаж]) VALUES (65116853213, 106, 777, 11, N'Бизнес-класс', CAST(N'2022-11-08' AS Date), CAST(N'20:34:43.9257021' AS Time), 1)
INSERT [dbo].[Билеты] ([КодБилета], [КодРейса], [КодАвиакомпании], [КодПассажира], [НазваниеКласса], [ДатаПокупкиБилета], [ВремяПокупкиБилета], [Багаж]) VALUES (1478963258963, 103, 777, 4, N'Эконом-класс', CAST(N'2022-04-01' AS Date), CAST(N'06:30:00' AS Time), 1)
INSERT [dbo].[Билеты] ([КодБилета], [КодРейса], [КодАвиакомпании], [КодПассажира], [НазваниеКласса], [ДатаПокупкиБилета], [ВремяПокупкиБилета], [Багаж]) VALUES (1745632896523, 112, 823, 13, N'Бизнес-класс', CAST(N'2022-05-04' AS Date), CAST(N'04:07:00' AS Time), 1)
INSERT [dbo].[Билеты] ([КодБилета], [КодРейса], [КодАвиакомпании], [КодПассажира], [НазваниеКласса], [ДатаПокупкиБилета], [ВремяПокупкиБилета], [Багаж]) VALUES (2579632148596, 106, 737, 7, N'Бизнес-класс', CAST(N'2022-04-28' AS Date), CAST(N'12:38:00' AS Time), 0)
INSERT [dbo].[Билеты] ([КодБилета], [КодРейса], [КодАвиакомпании], [КодПассажира], [НазваниеКласса], [ДатаПокупкиБилета], [ВремяПокупкиБилета], [Багаж]) VALUES (3587496852563, 111, 737, 12, N'Эконом-класс', CAST(N'2022-05-01' AS Date), CAST(N'20:20:00' AS Time), 0)
INSERT [dbo].[Билеты] ([КодБилета], [КодРейса], [КодАвиакомпании], [КодПассажира], [НазваниеКласса], [ДатаПокупкиБилета], [ВремяПокупкиБилета], [Багаж]) VALUES (3698574269853, 113, 320, 14, N'Эконом-класс', CAST(N'2022-11-16' AS Date), CAST(N'20:04:53.2479269' AS Time), 0)
INSERT [dbo].[Билеты] ([КодБилета], [КодРейса], [КодАвиакомпании], [КодПассажира], [НазваниеКласса], [ДатаПокупкиБилета], [ВремяПокупкиБилета], [Багаж]) VALUES (5473366991425, 102, 737, 3, N'Эконом-класс', CAST(N'2022-04-08' AS Date), CAST(N'21:36:00' AS Time), 0)
INSERT [dbo].[Билеты] ([КодБилета], [КодРейса], [КодАвиакомпании], [КодПассажира], [НазваниеКласса], [ДатаПокупкиБилета], [ВремяПокупкиБилета], [Багаж]) VALUES (5874369558569, 100, 319, 1, N'Бизнес-класс', CAST(N'2022-04-03' AS Date), CAST(N'13:40:00' AS Time), 1)
INSERT [dbo].[Билеты] ([КодБилета], [КодРейса], [КодАвиакомпании], [КодПассажира], [НазваниеКласса], [ДатаПокупкиБилета], [ВремяПокупкиБилета], [Багаж]) VALUES (6985126352417, 115, 737, 16, N'Бизнес-класс', CAST(N'2022-05-09' AS Date), CAST(N'17:45:00' AS Time), 1)
INSERT [dbo].[Билеты] ([КодБилета], [КодРейса], [КодАвиакомпании], [КодПассажира], [НазваниеКласса], [ДатаПокупкиБилета], [ВремяПокупкиБилета], [Багаж]) VALUES (7896325412589, 105, 823, 6, N'Бизнес-класс', CAST(N'2022-04-18' AS Date), CAST(N'18:20:00' AS Time), 1)
INSERT [dbo].[Билеты] ([КодБилета], [КодРейса], [КодАвиакомпании], [КодПассажира], [НазваниеКласса], [ДатаПокупкиБилета], [ВремяПокупкиБилета], [Багаж]) VALUES (7896325874125, 104, 801, 5, N'Бизнес-класс', CAST(N'2022-04-12' AS Date), CAST(N'15:47:00' AS Time), 1)
INSERT [dbo].[Билеты] ([КодБилета], [КодРейса], [КодАвиакомпании], [КодПассажира], [НазваниеКласса], [ДатаПокупкиБилета], [ВремяПокупкиБилета], [Багаж]) VALUES (8596324178596, 107, 320, 8, N'Эконом-класс', CAST(N'2022-04-20' AS Date), CAST(N'10:04:00' AS Time), 1)
INSERT [dbo].[Билеты] ([КодБилета], [КодРейса], [КодАвиакомпании], [КодПассажира], [НазваниеКласса], [ДатаПокупкиБилета], [ВремяПокупкиБилета], [Багаж]) VALUES (8963147526398, 109, 777, 10, N'Эконом-класс', CAST(N'2022-05-02' AS Date), CAST(N'19:01:00' AS Time), 1)
INSERT [dbo].[Билеты] ([КодБилета], [КодРейса], [КодАвиакомпании], [КодПассажира], [НазваниеКласса], [ДатаПокупкиБилета], [ВремяПокупкиБилета], [Багаж]) VALUES (9658743658962, 108, 319, 9, N'Эконом-класс', CAST(N'2022-05-01' AS Date), CAST(N'08:45:00' AS Time), 0)
INSERT [dbo].[Билеты] ([КодБилета], [КодРейса], [КодАвиакомпании], [КодПассажира], [НазваниеКласса], [ДатаПокупкиБилета], [ВремяПокупкиБилета], [Багаж]) VALUES (9874336589214, 101, 320, 2, N'Эконом-класс', CAST(N'2022-03-20' AS Date), CAST(N'08:05:00' AS Time), 0)
GO
INSERT [dbo].[Пассажиры] ([КодПассажира], [Фамилия], [Имя], [Отчество], [СерияПаспорта], [НомерПаспорта], [МобильныйТелефон], [ДатаРождения]) VALUES (1, N'Калион', N'Екатерина', N'Максимовна', 4437, 239072, N'8 953 748-45-05', CAST(N'2003-12-21' AS Date))
INSERT [dbo].[Пассажиры] ([КодПассажира], [Фамилия], [Имя], [Отчество], [СерияПаспорта], [НомерПаспорта], [МобильныйТелефон], [ДатаРождения]) VALUES (2, N'Панфёров', N'Никифор', N'Филиппович', 5896, 125896, N'8 900 485-05-36', CAST(N'1989-06-24' AS Date))
INSERT [dbo].[Пассажиры] ([КодПассажира], [Фамилия], [Имя], [Отчество], [СерияПаспорта], [НомерПаспорта], [МобильныйТелефон], [ДатаРождения]) VALUES (3, N'Радченко', N'Татьяна', N'Ивановна', 1456, 365899, N'8 456 789-89-96', CAST(N'2001-03-12' AS Date))
INSERT [dbo].[Пассажиры] ([КодПассажира], [Фамилия], [Имя], [Отчество], [СерияПаспорта], [НомерПаспорта], [МобильныйТелефон], [ДатаРождения]) VALUES (4, N'Горбунова', N'Лариса', N'Егоровна', 7896, 147832, N'8 965 478-14-25', CAST(N'1988-12-03' AS Date))
INSERT [dbo].[Пассажиры] ([КодПассажира], [Фамилия], [Имя], [Отчество], [СерияПаспорта], [НомерПаспорта], [МобильныйТелефон], [ДатаРождения]) VALUES (5, N'Савкин', N'Алексей', N'Иванович', 2698, 782569, N'8 975 856-36-37', CAST(N'1999-11-26' AS Date))
INSERT [dbo].[Пассажиры] ([КодПассажира], [Фамилия], [Имя], [Отчество], [СерияПаспорта], [НомерПаспорта], [МобильныйТелефон], [ДатаРождения]) VALUES (6, N'Маринова', N'Ксения', N'Тимофеевна', 3644, 961233, N'8 953 321-12-04', CAST(N'1985-05-15' AS Date))
INSERT [dbo].[Пассажиры] ([КодПассажира], [Фамилия], [Имя], [Отчество], [СерияПаспорта], [НомерПаспорта], [МобильныйТелефон], [ДатаРождения]) VALUES (7, N'Крылов', N'Мирон', N'Данилович', 1459, 478596, N'8 963 564-52-52', CAST(N'2000-03-02' AS Date))
INSERT [dbo].[Пассажиры] ([КодПассажира], [Фамилия], [Имя], [Отчество], [СерияПаспорта], [НомерПаспорта], [МобильныйТелефон], [ДатаРождения]) VALUES (8, N'Рудакова', N'Ксения', N'Георгиевна', 4759, 258963, N'8 456 123-78-96', CAST(N'1988-11-04' AS Date))
INSERT [dbo].[Пассажиры] ([КодПассажира], [Фамилия], [Имя], [Отчество], [СерияПаспорта], [НомерПаспорта], [МобильныйТелефон], [ДатаРождения]) VALUES (9, N'Барсукова', N'Элина', N'Олеговна', 1239, 125478, N'8 965 852-12-02', CAST(N'1999-12-02' AS Date))
INSERT [dbo].[Пассажиры] ([КодПассажира], [Фамилия], [Имя], [Отчество], [СерияПаспорта], [НомерПаспорта], [МобильныйТелефон], [ДатаРождения]) VALUES (10, N'Павлов', N'Константин', N'Дмитриевич', 3698, 452555, N'8 365 568-14-54', CAST(N'1990-05-28' AS Date))
INSERT [dbo].[Пассажиры] ([КодПассажира], [Фамилия], [Имя], [Отчество], [СерияПаспорта], [НомерПаспорта], [МобильныйТелефон], [ДатаРождения]) VALUES (11, N'Медведева', N'Ольга', N'Тихоновна', 7897, 145635, N'8 698 142-14-25', CAST(N'2001-02-14' AS Date))
INSERT [dbo].[Пассажиры] ([КодПассажира], [Фамилия], [Имя], [Отчество], [СерияПаспорта], [НомерПаспорта], [МобильныйТелефон], [ДатаРождения]) VALUES (12, N'Руднев', N'Дмитрий', N'Дмитриевич', 2782, 322369, N'8 123 405-14-04', CAST(N'1991-01-01' AS Date))
INSERT [dbo].[Пассажиры] ([КодПассажира], [Фамилия], [Имя], [Отчество], [СерияПаспорта], [НомерПаспорта], [МобильныйТелефон], [ДатаРождения]) VALUES (13, N'Зверев', N'Михаил', N'Львович', 7339, 493322, N'8 409 759-89-90', CAST(N'1989-09-09' AS Date))
INSERT [dbo].[Пассажиры] ([КодПассажира], [Фамилия], [Имя], [Отчество], [СерияПаспорта], [НомерПаспорта], [МобильныйТелефон], [ДатаРождения]) VALUES (14, N'Смирнова', N'Василиса', N'Мирославовна', 6398, 698745, N'8 788 963-25-05', CAST(N'1970-03-20' AS Date))
INSERT [dbo].[Пассажиры] ([КодПассажира], [Фамилия], [Имя], [Отчество], [СерияПаспорта], [НомерПаспорта], [МобильныйТелефон], [ДатаРождения]) VALUES (15, N'Корнилов', N'Дмитрий', N'Тимофеевич', 1299, 962478, N'8 803 256-28-96', CAST(N'1981-07-29' AS Date))
INSERT [dbo].[Пассажиры] ([КодПассажира], [Фамилия], [Имя], [Отчество], [СерияПаспорта], [НомерПаспорта], [МобильныйТелефон], [ДатаРождения]) VALUES (16, N'Островский', N'Александр', N'Филиппович', 6478, 283779, N'8 150 369-96-03', CAST(N'1999-12-12' AS Date))
GO
INSERT [dbo].[Рейсы] ([КодРейса], [КодАвиакомпании], [КодСамолёта], [Отправление], [Прибытие], [ДатаОтправления], [ДатаПрибытия], [ВремяОтправления], [ВремяПрибытия], [ДлительностьПерелета], [СтоимостьБилета]) VALUES (100, 319, 58, 12, 15, CAST(N'2022-04-05' AS Date), CAST(N'2022-04-06' AS Date), CAST(N'23:10:00' AS Time), CAST(N'00:30:00' AS Time), N'1ч 20м', 39360.0000)
INSERT [dbo].[Рейсы] ([КодРейса], [КодАвиакомпании], [КодСамолёта], [Отправление], [Прибытие], [ДатаОтправления], [ДатаПрибытия], [ВремяОтправления], [ВремяПрибытия], [ДлительностьПерелета], [СтоимостьБилета]) VALUES (101, 320, 64, 12, 17, CAST(N'2022-04-06' AS Date), CAST(N'2022-04-06' AS Date), CAST(N'00:30:00' AS Time), CAST(N'01:40:00' AS Time), N'1ч 10м', 4819.0000)
INSERT [dbo].[Рейсы] ([КодРейса], [КодАвиакомпании], [КодСамолёта], [Отправление], [Прибытие], [ДатаОтправления], [ДатаПрибытия], [ВремяОтправления], [ВремяПрибытия], [ДлительностьПерелета], [СтоимостьБилета]) VALUES (102, 737, 73, 15, 17, CAST(N'2022-04-09' AS Date), CAST(N'2022-04-09' AS Date), CAST(N'09:35:00' AS Time), CAST(N'11:20:00' AS Time), N'1ч 45м', 6811.0000)
INSERT [dbo].[Рейсы] ([КодРейса], [КодАвиакомпании], [КодСамолёта], [Отправление], [Прибытие], [ДатаОтправления], [ДатаПрибытия], [ВремяОтправления], [ВремяПрибытия], [ДлительностьПерелета], [СтоимостьБилета]) VALUES (103, 777, 77, 17, 19, CAST(N'2022-04-14' AS Date), CAST(N'2022-04-14' AS Date), CAST(N'06:45:00' AS Time), CAST(N'10:15:00' AS Time), N'1ч 30м', 887.0000)
INSERT [dbo].[Рейсы] ([КодРейса], [КодАвиакомпании], [КодСамолёта], [Отправление], [Прибытие], [ДатаОтправления], [ДатаПрибытия], [ВремяОтправления], [ВремяПрибытия], [ДлительностьПерелета], [СтоимостьБилета]) VALUES (104, 801, 80, 19, 21, CAST(N'2022-04-17' AS Date), CAST(N'2022-04-18' AS Date), CAST(N'13:30:00' AS Time), CAST(N'09:45:00' AS Time), N'15ч 15м', 136278.0000)
INSERT [dbo].[Рейсы] ([КодРейса], [КодАвиакомпании], [КодСамолёта], [Отправление], [Прибытие], [ДатаОтправления], [ДатаПрибытия], [ВремяОтправления], [ВремяПрибытия], [ДлительностьПерелета], [СтоимостьБилета]) VALUES (105, 823, 99, 21, 23, CAST(N'2022-04-20' AS Date), CAST(N'2022-04-20' AS Date), CAST(N'15:35:00' AS Time), CAST(N'20:20:00' AS Time), N'9ч 45м', 66430.0000)
INSERT [dbo].[Рейсы] ([КодРейса], [КодАвиакомпании], [КодСамолёта], [Отправление], [Прибытие], [ДатаОтправления], [ДатаПрибытия], [ВремяОтправления], [ВремяПрибытия], [ДлительностьПерелета], [СтоимостьБилета]) VALUES (106, 737, 73, 15, 21, CAST(N'2022-05-02' AS Date), CAST(N'2022-05-03' AS Date), CAST(N'21:50:00' AS Time), CAST(N'19:20:00' AS Time), N'14ч 30м', 38000.0000)
INSERT [dbo].[Рейсы] ([КодРейса], [КодАвиакомпании], [КодСамолёта], [Отправление], [Прибытие], [ДатаОтправления], [ДатаПрибытия], [ВремяОтправления], [ВремяПрибытия], [ДлительностьПерелета], [СтоимостьБилета]) VALUES (107, 320, 64, 17, 23, CAST(N'2022-05-02' AS Date), CAST(N'2022-05-03' AS Date), CAST(N'21:45:00' AS Time), CAST(N'04:20:00' AS Time), N'4ч 35м', 7553.0000)
INSERT [dbo].[Рейсы] ([КодРейса], [КодАвиакомпании], [КодСамолёта], [Отправление], [Прибытие], [ДатаОтправления], [ДатаПрибытия], [ВремяОтправления], [ВремяПрибытия], [ДлительностьПерелета], [СтоимостьБилета]) VALUES (108, 319, 58, 23, 12, CAST(N'2022-05-04' AS Date), CAST(N'2022-05-04' AS Date), CAST(N'21:00:00' AS Time), CAST(N'23:40:00' AS Time), N'2ч 40м', 10288.0000)
INSERT [dbo].[Рейсы] ([КодРейса], [КодАвиакомпании], [КодСамолёта], [Отправление], [Прибытие], [ДатаОтправления], [ДатаПрибытия], [ВремяОтправления], [ВремяПрибытия], [ДлительностьПерелета], [СтоимостьБилета]) VALUES (109, 777, 77, 19, 17, CAST(N'2022-05-05' AS Date), CAST(N'2022-05-05' AS Date), CAST(N'06:35:00' AS Time), CAST(N'12:40:00' AS Time), N'8ч 05м', 6544.0000)
INSERT [dbo].[Рейсы] ([КодРейса], [КодАвиакомпании], [КодСамолёта], [Отправление], [Прибытие], [ДатаОтправления], [ДатаПрибытия], [ВремяОтправления], [ВремяПрибытия], [ДлительностьПерелета], [СтоимостьБилета]) VALUES (110, 801, 80, 21, 23, CAST(N'2022-05-06' AS Date), CAST(N'2022-05-06' AS Date), CAST(N'07:25:00' AS Time), CAST(N'12:10:00' AS Time), N'9ч 45м', 21650.0000)
INSERT [dbo].[Рейсы] ([КодРейса], [КодАвиакомпании], [КодСамолёта], [Отправление], [Прибытие], [ДатаОтправления], [ДатаПрибытия], [ВремяОтправления], [ВремяПрибытия], [ДлительностьПерелета], [СтоимостьБилета]) VALUES (111, 737, 73, 19, 15, CAST(N'2022-05-05' AS Date), CAST(N'2022-05-05' AS Date), CAST(N'05:35:00' AS Time), CAST(N'08:05:00' AS Time), N'2ч 30м', 3849.0000)
INSERT [dbo].[Рейсы] ([КодРейса], [КодАвиакомпании], [КодСамолёта], [Отправление], [Прибытие], [ДатаОтправления], [ДатаПрибытия], [ВремяОтправления], [ВремяПрибытия], [ДлительностьПерелета], [СтоимостьБилета]) VALUES (112, 823, 99, 21, 12, CAST(N'2022-05-06' AS Date), CAST(N'2022-05-06' AS Date), CAST(N'12:05:00' AS Time), CAST(N'20:45:00' AS Time), N'8ч 40м', 17105.0000)
INSERT [dbo].[Рейсы] ([КодРейса], [КодАвиакомпании], [КодСамолёта], [Отправление], [Прибытие], [ДатаОтправления], [ДатаПрибытия], [ВремяОтправления], [ВремяПрибытия], [ДлительностьПерелета], [СтоимостьБилета]) VALUES (113, 320, 64, 23, 19, CAST(N'2022-05-07' AS Date), CAST(N'2022-05-07' AS Date), CAST(N'07:00:00' AS Time), CAST(N'12:40:00' AS Time), N'5ч 40м', 12658.0000)
INSERT [dbo].[Рейсы] ([КодРейса], [КодАвиакомпании], [КодСамолёта], [Отправление], [Прибытие], [ДатаОтправления], [ДатаПрибытия], [ВремяОтправления], [ВремяПрибытия], [ДлительностьПерелета], [СтоимостьБилета]) VALUES (114, 777, 77, 15, 23, CAST(N'2022-05-09' AS Date), CAST(N'2022-05-09' AS Date), CAST(N'13:40:00' AS Time), CAST(N'18:35:00' AS Time), N'2ч 55м', 6361.0000)
INSERT [dbo].[Рейсы] ([КодРейса], [КодАвиакомпании], [КодСамолёта], [Отправление], [Прибытие], [ДатаОтправления], [ДатаПрибытия], [ВремяОтправления], [ВремяПрибытия], [ДлительностьПерелета], [СтоимостьБилета]) VALUES (115, 737, 73, 21, 17, CAST(N'2022-05-10' AS Date), CAST(N'2022-05-11' AS Date), CAST(N'13:50:00' AS Time), CAST(N'02:45:00' AS Time), N'12ч 55м', 136342.0000)
GO
INSERT [dbo].[Самолеты] ([КодСамолета], [КодАвиакомпании], [МодельСамолета], [КоличествоМест]) VALUES (58, 319, N'Airbus A319', 134)
INSERT [dbo].[Самолеты] ([КодСамолета], [КодАвиакомпании], [МодельСамолета], [КоличествоМест]) VALUES (64, 320, N'Airbus A320', 180)
INSERT [dbo].[Самолеты] ([КодСамолета], [КодАвиакомпании], [МодельСамолета], [КоличествоМест]) VALUES (73, 737, N'Boeing 737-800', 189)
INSERT [dbo].[Самолеты] ([КодСамолета], [КодАвиакомпании], [МодельСамолета], [КоличествоМест]) VALUES (77, 777, N'Boeing B777-300', 400)
INSERT [dbo].[Самолеты] ([КодСамолета], [КодАвиакомпании], [МодельСамолета], [КоличествоМест]) VALUES (80, 801, N'Canadair CRJ-100', 50)
INSERT [dbo].[Самолеты] ([КодСамолета], [КодАвиакомпании], [МодельСамолета], [КоличествоМест]) VALUES (99, 823, N'Airbus A321-200', 220)
GO
ALTER TABLE [dbo].[Билеты]  WITH CHECK ADD  CONSTRAINT [FK_Билеты_Авиакомпании] FOREIGN KEY([КодАвиакомпании])
REFERENCES [dbo].[Авиакомпании] ([КодАвиакомпании])
GO
ALTER TABLE [dbo].[Билеты] CHECK CONSTRAINT [FK_Билеты_Авиакомпании]
GO
ALTER TABLE [dbo].[Билеты]  WITH CHECK ADD  CONSTRAINT [FK_Билеты_Пассажиры] FOREIGN KEY([КодПассажира])
REFERENCES [dbo].[Пассажиры] ([КодПассажира])
GO
ALTER TABLE [dbo].[Билеты] CHECK CONSTRAINT [FK_Билеты_Пассажиры]
GO
ALTER TABLE [dbo].[Билеты]  WITH CHECK ADD  CONSTRAINT [FK_Билеты_Рейсы] FOREIGN KEY([КодРейса])
REFERENCES [dbo].[Рейсы] ([КодРейса])
GO
ALTER TABLE [dbo].[Билеты] CHECK CONSTRAINT [FK_Билеты_Рейсы]
GO
ALTER TABLE [dbo].[Рейсы]  WITH CHECK ADD  CONSTRAINT [FK_Рейсы_Авиакомпании] FOREIGN KEY([КодАвиакомпании])
REFERENCES [dbo].[Авиакомпании] ([КодАвиакомпании])
GO
ALTER TABLE [dbo].[Рейсы] CHECK CONSTRAINT [FK_Рейсы_Авиакомпании]
GO
ALTER TABLE [dbo].[Рейсы]  WITH CHECK ADD  CONSTRAINT [FK_Рейсы_Аэропорты] FOREIGN KEY([Отправление])
REFERENCES [dbo].[Аэропорты] ([КодАэропорта])
GO
ALTER TABLE [dbo].[Рейсы] CHECK CONSTRAINT [FK_Рейсы_Аэропорты]
GO
ALTER TABLE [dbo].[Рейсы]  WITH CHECK ADD  CONSTRAINT [FK_Рейсы_Аэропорты1] FOREIGN KEY([Прибытие])
REFERENCES [dbo].[Аэропорты] ([КодАэропорта])
GO
ALTER TABLE [dbo].[Рейсы] CHECK CONSTRAINT [FK_Рейсы_Аэропорты1]
GO
ALTER TABLE [dbo].[Рейсы]  WITH CHECK ADD  CONSTRAINT [FK_Рейсы_Самолеты] FOREIGN KEY([КодСамолёта])
REFERENCES [dbo].[Самолеты] ([КодСамолета])
GO
ALTER TABLE [dbo].[Рейсы] CHECK CONSTRAINT [FK_Рейсы_Самолеты]
GO
ALTER TABLE [dbo].[Самолеты]  WITH CHECK ADD  CONSTRAINT [FK_Самолеты_Авиакомпании] FOREIGN KEY([КодАвиакомпании])
REFERENCES [dbo].[Авиакомпании] ([КодАвиакомпании])
GO
ALTER TABLE [dbo].[Самолеты] CHECK CONSTRAINT [FK_Самолеты_Авиакомпании]
GO
/****** Object:  StoredProcedure [dbo].[АэропортПрибытиеРейса]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[АэропортПрибытиеРейса]
@RaceId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT        dbo.Аэропорты.Наименование, dbo.Аэропорты.Город
FROM            dbo.Аэропорты INNER JOIN
                         dbo.Рейсы ON dbo.Аэропорты.КодАэропорта = dbo.Рейсы.Прибытие
Where КодРейса = @RaceId 
END
GO
/****** Object:  StoredProcedure [dbo].[БилетыПроцедура]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[БилетыПроцедура]
AS
BEGIN
	SET NOCOUNT ON;
SELECT        dbo.Билеты.КодБилета, dbo.Билеты.КодРейса, dbo.Авиакомпании.Наименование, dbo.Пассажиры.Фамилия, dbo.Пассажиры.Имя, dbo.Пассажиры.Отчество, dbo.Билеты.НазваниеКласса, dbo.Билеты.Багаж, 
                         dbo.Рейсы.ДатаОтправления, dbo.Рейсы.ВремяОтправления, dbo.Аэропорты.Город AS [Город-назначение]
FROM            dbo.Билеты INNER JOIN
                         dbo.Пассажиры ON dbo.Билеты.КодПассажира = dbo.Пассажиры.КодПассажира INNER JOIN
                         dbo.Рейсы ON dbo.Билеты.КодРейса = dbo.Рейсы.КодРейса INNER JOIN
                         dbo.Авиакомпании ON dbo.Рейсы.КодАвиакомпании = dbo.Авиакомпании.КодАвиакомпании INNER JOIN
                         dbo.Аэропорты ON dbo.Рейсы.Прибытие = dbo.Аэропорты.КодАэропорта
END
GO
/****** Object:  StoredProcedure [dbo].[ВозрастПассажиров]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ВозрастПассажиров]
AS
BEGIN
SET NOCOUNT ON;
SELECT    Фамилия+' '+ Left(Имя,1)+'. '+Left(Отчество,1)+ '. ' AS ФИО,
Year(GetDate()) -  Year(ДатаРождения) AS Возраст     
FROM     Пассажиры
ORDER By Возраст ASC
END
GO
/****** Object:  StoredProcedure [dbo].[ГлавноеОкно]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ГлавноеОкно]
AS
BEGIN
SET NOCOUNT ON;
SELECT        dbo.Пассажиры.КодПассажира, dbo.Пассажиры.Фамилия, dbo.Пассажиры.Имя, dbo.Пассажиры.Отчество, dbo.Пассажиры.СерияПаспорта, dbo.Пассажиры.НомерПаспорта, dbo.Пассажиры.МобильныйТелефон, 
                         dbo.Пассажиры.ДатаРождения, dbo.Билеты.НазваниеКласса, dbo.Билеты.Багаж
FROM            dbo.Билеты INNER JOIN
                         dbo.Пассажиры ON dbo.Билеты.КодПассажира = dbo.Пассажиры.КодПассажира
Order By   dbo.Пассажиры.КодПассажира;
						 END
GO
/****** Object:  StoredProcedure [dbo].[ГородОтправления]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ГородОтправления]
@ГородОтправления nvarchar(15)
AS
BEGIN
SET NOCOUNT ON;
SELECT  dbo.Пассажиры.Фамилия, dbo.Пассажиры.Имя, dbo.Пассажиры.Отчество, dbo.Аэропорты.Город AS ГородОтправления
FROM dbo.Билеты INNER JOIN
                         dbo.Пассажиры ON dbo.Билеты.КодПассажира = dbo.Пассажиры.КодПассажира INNER JOIN
                         dbo.Рейсы ON dbo.Билеты.КодРейса = dbo.Рейсы.КодРейса INNER JOIN
                         dbo.Аэропорты ON dbo.Рейсы.Отправление = dbo.Аэропорты.КодАэропорта
Where @ГородОтправления = dbo.Аэропорты.Город
END
GO
/****** Object:  StoredProcedure [dbo].[ИзменениеТелефонаАвиакомпании]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ИзменениеТелефонаАвиакомпании]
@КодАвиакомпании int,
@Телефон nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		Update Авиакомпании Set Телефон = @Телефон Where КодАвиакомпании = @КодАвиакомпании
END
GO
/****** Object:  StoredProcedure [dbo].[МодельСамолета]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[МодельСамолета]
AS
BEGIN
SET NOCOUNT ON;
SELECT        dbo.Авиакомпании.Наименование, dbo.Самолеты.МодельСамолета
FROM            dbo.Авиакомпании INNER JOIN
                         dbo.Самолеты ON dbo.Авиакомпании.КодАвиакомпании = dbo.Самолеты.КодАвиакомпании
WHERE        dbo.Самолеты.МодельСамолета Like 'Airbus'+'%'
END
GO
/****** Object:  StoredProcedure [dbo].[НоваяАвиакомпания]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[НоваяАвиакомпания]

@КодАвиакомпании int=0,
@Наименование nvarchar(50)=0,
@Телефон nvarchar(50)=0,
@ЭлектронныйАдрес nvarchar(50)=0


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if exists (select * from Авиакомпании where @КодАвиакомпании= КодАвиакомпании )
	print 'Невозможно добавить авиакомпанию'
	else
	Insert INTO Авиакомпании(КодАвиакомпании, Наименование, Телефон , ЭлектронныйАдрес)
	values (@КодАвиакомпании, @Наименование, @Телефон, @ЭлектронныйАдрес)
    -- Insert statements for procedure here
	
END
GO
/****** Object:  StoredProcedure [dbo].[НовыйПассажир]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[НовыйПассажир]

@КодПассажира int=0,
@Фамилия nvarchar(50)=0,
@Имя nvarchar(50)=0,
@Отчество nvarchar(50)=0,
@СерияПаспорта int=0, 
@НомерПаспорта int=0,
@МобильныйТелефон nvarchar(50)=0, 
@ДатаРождения datetime=0

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if exists (select * from Пассажиры where @КодПассажира= КодПассажира )
	print 'Невозможно добавить пассажира'
	else
	Insert INTO Пассажиры(КодПассажира, Фамилия, Имя , Отчество, СерияПаспорта, НомерПаспорта, МобильныйТелефон, ДатаРождения)
	values (@КодПассажира, @Фамилия, @Имя, @Отчество, @СерияПаспорта, @НомерПаспорта, @МобильныйТелефон, @ДатаРождения)
    -- Insert statements for procedure here
	
END
GO
/****** Object:  StoredProcedure [dbo].[НовыйСамолет]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[НовыйСамолет]

@КодСамолета int=0,
@КодАвиакомпании int=0,
@МодельСамолета nvarchar(50)=0,
@КоличествоМест int=0

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Insert INTO Самолеты(КодСамолета, КодАвиакомпании, МодельСамолета , КоличествоМест)
	values (@КодСамолета, @КодАвиакомпании, @МодельСамолета, @КоличествоМест)
    -- Insert statements for procedure here

	
END
GO
/****** Object:  StoredProcedure [dbo].[ОпределеннаяДатаРейса]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ОпределеннаяДатаРейса]
AS
BEGIN
SET NOCOUNT ON;
SELECT        *
FROM          Рейсы
WHERE    ДатаОтправления >='05.04.2022' and ДатаОтправления <='20.04.2022'   
END
GO
/****** Object:  StoredProcedure [dbo].[ОпределеннаяПочтаИНомерАвиакомпании]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ОпределеннаяПочтаИНомерАвиакомпании]
@КодАвиакомпании int
AS
BEGIN
SET NOCOUNT ON;
SELECT @КодАвиакомпании AS НомерАвиакомпании, Телефон, ЭлектронныйАдрес
FROM Авиакомпании
Where КодАвиакомпании= @КодАвиакомпании
END
GO
/****** Object:  StoredProcedure [dbo].[ОпределенныйКласс]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ОпределенныйКласс]
@КлассСамолета nvarchar(15)
AS
BEGIN
SET NOCOUNT ON;
SELECT        dbo.Пассажиры.Фамилия, dbo.Пассажиры.Имя, dbo.Пассажиры.Отчество, dbo.Билеты.НазваниеКласса
FROM            dbo.Пассажиры INNER JOIN
                         dbo.Билеты ON dbo.Пассажиры.КодПассажира = dbo.Билеты.КодПассажира
Where @КлассСамолета = dbo.Билеты.НазваниеКласса
END
GO
/****** Object:  StoredProcedure [dbo].[РейсыПроцедура]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<NoName>
-- Create date: <09.11.22>
-- Description:	<МАЙКРОСОФТ НЕ ОСИЛИЛ ТАКУЮ БИТВУ>
-- =============================================
CREATE PROCEDURE [dbo].[РейсыПроцедура]
AS
BEGIN
	SET NOCOUNT ON;
SELECT        dbo.Рейсы.КодРейса, dbo.Авиакомпании.Наименование, dbo.Самолеты.МодельСамолета, dbo.Рейсы.ДатаОтправления, dbo.Рейсы.ДатаПрибытия, dbo.Рейсы.ВремяОтправления, dbo.Рейсы.ВремяПрибытия, 
                         dbo.Рейсы.ДлительностьПерелета, dbo.Рейсы.СтоимостьБилета, dbo.Аэропорты.Город AS [Город-отправление], Прибытия.Город AS [Город-назначение]
FROM            dbo.Авиакомпании INNER JOIN
                         dbo.Рейсы ON dbo.Авиакомпании.КодАвиакомпании = dbo.Рейсы.КодАвиакомпании INNER JOIN
                         dbo.Самолеты ON dbo.Авиакомпании.КодАвиакомпании = dbo.Самолеты.КодАвиакомпании AND dbo.Рейсы.КодСамолёта = dbo.Самолеты.КодСамолета INNER JOIN
                         dbo.Аэропорты ON dbo.Рейсы.Отправление = dbo.Аэропорты.КодАэропорта INNER JOIN
                             (SELECT       *
                               FROM            dbo.Аэропорты AS Аэропорты_1) AS Прибытия ON Прибытия.КодАэропорта = dbo.Рейсы.Прибытие
END
GO
/****** Object:  StoredProcedure [dbo].[СамолетыПроцедура]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[СамолетыПроцедура]
AS
BEGIN
SET NOCOUNT ON;
SELECT        dbo.Самолеты.КодСамолета, dbo.Авиакомпании.Наименование, dbo.Самолеты.МодельСамолета, dbo.Самолеты.КоличествоМест
FROM            dbo.Авиакомпании INNER JOIN
                         dbo.Самолеты ON dbo.Авиакомпании.КодАвиакомпании = dbo.Самолеты.КодАвиакомпании
						 END
GO
/****** Object:  StoredProcedure [dbo].[СтоимостьОпределенногоРейса]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[СтоимостьОпределенногоРейса]
@КодРейса int
AS
BEGIN
SET NOCOUNT ON;
SELECT @КодРейса AS НомерРейса, СтоимостьБилета AS СтоимостьБилета
FROM Рейсы
Where КодРейса= @КодРейса
END
GO
/****** Object:  StoredProcedure [dbo].[УдалениеАэропорта]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[УдалениеАэропорта]
@КодАэропорта int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE From Аэропорты
	WHERE КодАэропорта = @КодАэропорта
	PRINT 'Удаление произвведено успешно'
END
GO
/****** Object:  StoredProcedure [dbo].[УдалениеБилета]    Script Date: 23.11.2022 19:33:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[УдалениеБилета]
@КодБилета int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE From Билеты
	WHERE КодБилета = @КодБилета
	PRINT 'Удаление произвведено успешно'
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[27] 4[21] 2[10] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Пассажиры"
            Begin Extent = 
               Top = 5
               Left = 309
               Bottom = 135
               Right = 514
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Билеты"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 248
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 1500
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ПассажирыКлассы'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ПассажирыКлассы'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[34] 4[22] 2[15] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Билеты"
            Begin Extent = 
               Top = 9
               Left = 521
               Bottom = 225
               Right = 731
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Пассажиры"
            Begin Extent = 
               Top = 5
               Left = 773
               Bottom = 211
               Right = 978
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Рейсы"
            Begin Extent = 
               Top = 0
               Left = 245
               Bottom = 186
               Right = 463
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Аэропорты"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 182
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 3300
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   E' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ПассажирыОтправление'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'nd
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ПассажирыОтправление'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ПассажирыОтправление'
GO
USE [master]
GO
ALTER DATABASE [Продажа билетов на самолет] SET  READ_WRITE 
GO
