USE [Продажа билетов на самолет]
GO
/****** Object:  StoredProcedure [dbo].[АэропортПрибытиеРейса]    Script Date: 12.11.2022 22:12:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[АэропортПрибытиеРейса]
@RaceId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT        dbo.Аэропорты.Наименование, dbo.Аэропорты.Город
FROM            dbo.Аэропорты INNER JOIN
                         dbo.Рейсы ON dbo.Аэропорты.КодАэропорта = dbo.Рейсы.Прибытие
Where КодРейса = @RaceId 
END
