USE [EileenGaldamez]
GO

CREATE Procedure [dbo].[SP_Product_SelectProduct]
(	
	@iAction varchar(50),
	@iCellarAreaID int,
	@iCategoryID  int,
	@iFatherCateogryID int
) 
As
Begin
	-- Action

	-- Get Product List to department and category
	if @iAction = 'GetProductListByDepartmentAndCategory'
	Begin
		IF @iFatherCateogryID = 0		
		BEGIN
			SELECT 
				P.*
			FROM tblProduct P INNER JOIN tblCellar C ON P.id = C.idProduct
			WHERE 
				C.idcellarArea = @iCellarAreaID AND 
				P.id NOT IN (
					SELECT A.idProduct 
					FROM tblAssignment A WHERE P.id = A.idProduct AND A.idCategory = @iCategoryID 
					)
			ORDER BY P.id
		END
		ELSE
		BEGIN
			SELECT 
				P.*
			FROM tblProduct P INNER JOIN tblAssignment AS C ON P.id = C.idProduct
			WHERE C.idCategory = @iFatherCateogryID AND 	
				P.id NOT IN (
					SELECT 
						A.idProduct 
					FROM tblAssignment A WHERE P.id = A.idProduct AND A.idCategory = @iCategoryID 
					)
			ORDER BY P.id
		END
	END
	ELSE IF @iAction = 'GetProductToCellarArea'
	BEGIN
		SELECT 
			P.*
		FROM 
			tblProduct AS P
		WHERE P.id NOT IN (
			SELECT C.idProduct FROM tblCellar AS C WHERE C.idcellarArea = @iCellarAreaID
		)
	END
	--Fin action
End

