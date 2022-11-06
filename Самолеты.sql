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
CREATE PROCEDURE [dbo].[СамолетыПроцедура]
AS
BEGIN
SET NOCOUNT ON;
SELECT        dbo.Самолеты.КодСамолета, dbo.Авиакомпании.Наименование, dbo.Самолеты.МодельСамолета, dbo.Самолеты.КоличествоМест
FROM            dbo.Авиакомпании INNER JOIN
                         dbo.Самолеты ON dbo.Авиакомпании.КодАвиакомпании = dbo.Самолеты.КодАвиакомпании
						 END