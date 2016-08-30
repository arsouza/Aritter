USE [Aritter]
GO

ALTER PROCEDURE [dbo].[sp_script_merge_data](
	@table_name AS VARCHAR(128)
)
AS
BEGIN

	DECLARE @COLUMN_NAME NVARCHAR(128);
	DECLARE @TYPE_NAME NVARCHAR(128);
	DECLARE @MAX_LENGTH NVARCHAR(128);
	DECLARE @SQL NVARCHAR(MAX);
	DECLARE @RETURN_VALUE NVARCHAR(MAX);

	SET NOCOUNT ON;

	SET @SQL = 'SELECT ' + CHAR(39) + '('  + CHAR(39) + ' + '

	DECLARE TABLE_CURSOR CURSOR FOR   
	SELECT
		C.[NAME],
		T.[NAME],
		C.[MAX_LENGTH]
	FROM
		SYS.COLUMNS C
		INNER JOIN SYS.TYPES T
		ON T.USER_TYPE_ID = C.USER_TYPE_ID
	WHERE
		OBJECT_ID = OBJECT_ID(@table_name); 
  
	OPEN TABLE_CURSOR  
	FETCH NEXT FROM TABLE_CURSOR INTO @COLUMN_NAME, @TYPE_NAME, @MAX_LENGTH
  
	IF @@FETCH_STATUS <> 0   
		SET @RETURN_VALUE = '';
  
	WHILE @@FETCH_STATUS = 0  
	BEGIN

		IF @TYPE_NAME IN ('char', 'varchar', 'text', 'nchar', 'nvarchar', 'ntext') AND @MAX_LENGTH = -1
			SET @SQL = @SQL + 'COALESCE((CHAR(39) + ' + 'CAST([' + @COLUMN_NAME + '] AS NVARCHAR(MAX)) + CHAR(39)), '+ CHAR(39) + 'NULL' + CHAR(39) +') + ' + CHAR(39) + ', ' + CHAR(39) + ' + ';
		ELSE IF @TYPE_NAME IN ('char', 'varchar', 'text', 'nchar', 'nvarchar', 'ntext') AND @MAX_LENGTH <> -1
			SET @SQL = @SQL + 'COALESCE((CHAR(39) + ' + 'CAST([' + @COLUMN_NAME + '] AS NVARCHAR(' + @MAX_LENGTH + ')) + CHAR(39)), '+ CHAR(39) + 'NULL' + CHAR(39) +') + ' + CHAR(39) + ', ' + CHAR(39) + ' + ';
		ELSE IF @TYPE_NAME IN ('uniqueidentifier')
			SET @SQL = @SQL + 'COALESCE((CHAR(39) + ' + 'CAST([' + @COLUMN_NAME + '] AS NVARCHAR(MAX)) + CHAR(39)), '+ CHAR(39) + 'NULL' + CHAR(39) +') + ' + CHAR(39) + ', ' + CHAR(39) + ' + ';
		ELSE IF @TYPE_NAME IN ('datetime', 'datetime2')
			SET @SQL = @SQL + 'COALESCE((CHAR(39) + ' + 'CONVERT(NVARCHAR(MAX), [' + @COLUMN_NAME + '], 121) + CHAR(39)), '+ CHAR(39) + 'NULL' + CHAR(39) +') + ' + CHAR(39) + ', ' + CHAR(39) + ' + ';
		ELSE IF @TYPE_NAME IN ('smalldatetime')
			SET @SQL = @SQL + 'COALESCE((CHAR(39) + ' + 'CONVERT(NVARCHAR(MAX), [' + @COLUMN_NAME + '], 120) + CHAR(39)), '+ CHAR(39) + 'NULL' + CHAR(39) +') + ' + CHAR(39) + ', ' + CHAR(39) + ' + ';
		ELSE IF @TYPE_NAME IN ('time')
			SET @SQL = @SQL + 'COALESCE((CHAR(39) + ' + 'CONVERT(NVARCHAR(MAX), [' + @COLUMN_NAME + '], 108) + CHAR(39)), '+ CHAR(39) + 'NULL' + CHAR(39) +') + ' + CHAR(39) + ', ' + CHAR(39) + ' + ';
		ELSE
			SET @SQL = @SQL + 'COALESCE((CAST([' + @COLUMN_NAME + '] AS NVARCHAR(MAX))), '+ CHAR(39) + 'NULL' + CHAR(39) +') + ' + CHAR(39) + ', ' + CHAR(39) + ' + ';

		FETCH NEXT FROM TABLE_CURSOR INTO @COLUMN_NAME, @TYPE_NAME, @MAX_LENGTH 
	END  
  
	CLOSE TABLE_CURSOR  
	DEALLOCATE TABLE_CURSOR

	SELECT
		@SQL = LEFT(@SQL, LEN(@SQL) - 6)

	SET @SQL = @SQL + ' + ' + CHAR(39) + '),' + CHAR(39) + ' FROM ' + @table_name

	EXEC @RETURN_VALUE = SYS.SP_EXECUTESQL @SQL

	RETURN @RETURN_VALUE
END