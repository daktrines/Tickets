USE [������� ������� �� �������]
GO
/****** Object:  StoredProcedure [dbo].[�����������]    Script Date: 19.10.2022 22:04:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[���������������]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT        dbo.������.���������, dbo.������.��������, dbo.������������.������������, dbo.���������.�������, dbo.���������.���, dbo.���������.��������, dbo.������.��������������, dbo.������.�����, 
                         dbo.�����.���������������, dbo.�����.����������������, dbo.���������.����� AS [�����-����������]
FROM            dbo.������ INNER JOIN
                         dbo.��������� ON dbo.������.������������ = dbo.���������.������������ INNER JOIN
                         dbo.����� ON dbo.������.�������� = dbo.�����.�������� INNER JOIN
                         dbo.������������ ON dbo.������.��������������� = dbo.������������.��������������� AND dbo.�����.��������������� = dbo.������������.��������������� INNER JOIN
                         dbo.��������� ON dbo.�����.�������� = dbo.���������.������������
END
GO