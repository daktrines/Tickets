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
ALTER PROCEDURE [dbo].[ГлавноеОкно]
AS
BEGIN
SET NOCOUNT ON;
SELECT        dbo.Пассажиры.КодПассажира, dbo.Пассажиры.Фамилия, dbo.Пассажиры.Имя, dbo.Пассажиры.Отчество, dbo.Пассажиры.СерияПаспорта, dbo.Пассажиры.НомерПаспорта, dbo.Пассажиры.МобильныйТелефон, 
                         dbo.Пассажиры.ДатаРождения, dbo.Билеты.НазваниеКласса, dbo.Билеты.Багаж
FROM            dbo.Билеты INNER JOIN
                         dbo.Пассажиры ON dbo.Билеты.КодПассажира = dbo.Пассажиры.КодПассажира
Order By   dbo.Пассажиры.КодПассажира;
						 END