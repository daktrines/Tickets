USE [Продажа билетов на самолет]
GO
/****** Object:  StoredProcedure [dbo].[НовыйСамолет]    Script Date: 05.11.2022 17:16:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[НовыйСамолет]

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