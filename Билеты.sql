USE [Продажа билетов на самолет]
GO
/****** Object:  StoredProcedure [dbo].[ГлавноеОкно]    Script Date: 19.10.2022 22:04:32 ******/
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
                         dbo.Авиакомпании ON dbo.Билеты.КодАвиакомпании = dbo.Авиакомпании.КодАвиакомпании AND dbo.Рейсы.КодАвиакомпании = dbo.Авиакомпании.КодАвиакомпании INNER JOIN
                         dbo.Аэропорты ON dbo.Рейсы.Прибытие = dbo.Аэропорты.КодАэропорта
END
GO