USE [Продажа билетов на самолет]
GO
/****** Object:  StoredProcedure [dbo].[БилетыПроцедура]    Script Date: 06.11.2022 21:27:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[БилетыПроцедура]
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
