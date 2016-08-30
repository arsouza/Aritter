USE [Aritter]
GO

ALTER PROCEDURE [dbo].[sp_script_merge](
	@table_name AS VARCHAR(128),
	@output_script NVARCHAR(MAX) OUTPUT
)
AS
BEGIN

SET NOCOUNT ON;
 
DECLARE @RETURN INT;
DECLARE @MERGE_DATA NVARCHAR(MAX);

SET @output_script = '';

SET @output_script = @output_script + '-- ' + @table_name + ' -------------------------------------------------------------
';
SET @output_script = @output_script + '
';
SET @output_script = @output_script + 'SET NOCOUNT ON
	
';

-- SET THE IDENTITY INSERT ON FOR TABLES WITH IDENTITIES
SELECT
	@RETURN = OBJECTPROPERTY(OBJECT_ID(@table_name), 'TableHasIdentity');

IF @RETURN = 1 
SET @output_script = @output_script + 'SET IDENTITY_INSERT [dbo].[' + @table_name + '] ON;
GO

';

DECLARE @LIST VARCHAR(MAX) = '';
DECLARE @DATA VARCHAR(MAX) = '';

SELECT
	@LIST = @LIST + [NAME] + '], ['
FROM
	SYS.COLUMNS
WHERE
	OBJECT_ID = OBJECT_ID(@table_name);

SELECT
	@LIST = LEFT(@LIST, LEN(@LIST) - 4);

-- --------------------------------------------------------------------------------

SET @output_script = @output_script + 'MERGE INTO [dbo].[' + @table_name + '] AS T
';
SET @output_script = @output_script + 'USING (VALUES
';

DECLARE @TABLE_DATA TABLE (DATA NVARCHAR(MAX))
INSERT INTO @TABLE_DATA
EXEC sp_script_merge_data @table_name

DECLARE TABLE_CURSOR CURSOR FOR   
SELECT
	*
FROM
	@TABLE_DATA
  
OPEN TABLE_CURSOR  
FETCH NEXT FROM TABLE_CURSOR INTO @MERGE_DATA
  
WHILE @@FETCH_STATUS = 0  
BEGIN

	SET @output_script = @output_script + '	' + @MERGE_DATA + '
';

	FETCH NEXT FROM TABLE_CURSOR INTO @MERGE_DATA
END  
  
CLOSE TABLE_CURSOR  
DEALLOCATE TABLE_CURSOR

SET @output_script = LEFT(@output_script, LEN(@output_script) - 3) + '
';

SET @output_script = @output_script + ')
';
SET @output_script = @output_script + 'AS S ([' + @LIST + '])
';

-- GET THE JOIN COLUMNS ----------------------------------------------------------
SET @LIST = '';

SELECT
	@LIST = @LIST + 'T.[' + C.COLUMN_NAME + '] = S.[' + C.COLUMN_NAME + '] AND '
FROM
	INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK,
	INFORMATION_SCHEMA.KEY_COLUMN_USAGE C
WHERE
	PK.TABLE_NAME = @table_name
	AND CONSTRAINT_TYPE = 'PRIMARY KEY'
	AND C.TABLE_NAME = PK.TABLE_NAME
	AND C.CONSTRAINT_NAME = PK.CONSTRAINT_NAME;

IF LTRIM(RTRIM(@LIST)) <> ''
SELECT @LIST = LEFT(@LIST, LEN(@LIST) - 4);

SET @output_script = @output_script + 'ON (' + @LIST + ')

';

-- WHEN MATCHED ------------------------------------------------------------------
SET @output_script = @output_script + '-- UPDATE MATCHED ROWS
';
SET @output_script = @output_script + 'WHEN MATCHED THEN
';
SET @output_script = @output_script + 'UPDATE SET
';

SELECT
	@LIST = '';
SELECT
	@LIST = @LIST + '    [' + [NAME] + '] = S.[' + [NAME] + '],
'
FROM
	SYS.COLUMNS
WHERE
	OBJECT_ID = OBJECT_ID(@table_name)
	-- DON'T UPDATE PRIMARY KEYS
	AND [NAME] NOT IN (
		SELECT
			[COLUMN_NAME]
		FROM
			INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK,
			INFORMATION_SCHEMA.KEY_COLUMN_USAGE C
		WHERE
			PK.TABLE_NAME = @table_name
			AND CONSTRAINT_TYPE = 'PRIMARY KEY'
			AND C.TABLE_NAME = PK.TABLE_NAME
			AND C.CONSTRAINT_NAME = PK.CONSTRAINT_NAME
	)
	-- AND DON'T UPDATE IDENTITY COLUMNS
	AND COLUMNPROPERTY(OBJECT_ID(@table_name), [NAME], 'IsIdentity ') = 0;
                    
--PRINT @LIST                    
SET @output_script = @output_script + LEFT(@LIST, LEN(@LIST) -3);
SET @output_script = @output_script + '

';

-- WHEN NOT MATCHED BY TARGET ------------------------------------------------
SET @output_script = @output_script + '-- INSERT NEW ROWS
';
SET @output_script = @output_script + 'WHEN NOT MATCHED BY TARGET THEN
';

-- GET THE INSERT LIST
SET @LIST = '';

SELECT
	@LIST = @LIST + '[' + [NAME] + '], '
FROM
	SYS.COLUMNS
WHERE
	OBJECT_ID = OBJECT_ID(@table_name);

SELECT
	@LIST = LEFT(@LIST, LEN(@LIST) - 1)

SET @output_script = @output_script + '    INSERT(' + @LIST + ')
';

-- GET THE VALUES LIST
SET @LIST = '';

SELECT
	@LIST = @LIST + 'S.[' + [NAME] + '], '
FROM
	SYS.COLUMNS
WHERE
	OBJECT_ID = OBJECT_ID(@table_name);

SELECT
	@LIST = LEFT(@LIST, LEN(@LIST) - 1);

SET @output_script = @output_script + '    VALUES(' + @LIST + ')

';

-- WHEN NOT MATCHED BY SOURCE 
SET @output_script = @output_script + '-- DELETE ROWS THAT ARE IN THE TARGET BUT NOT THE SOURCE
';
SET @output_script = @output_script + 'WHEN NOT MATCHED BY SOURCE THEN
';
SET @output_script = @output_script + 'DELETE;
';

SET @output_script = @output_script + '
PRINT ''' + @table_name + ': '' + CAST(@@ROWCOUNT AS VARCHAR(100));

';

SET @output_script = @output_script + '';

-- SET THE IDENTITY INSERT OFF FOR TABLES WITH IDENTITIES
SELECT
	@RETURN = OBJECTPROPERTY(OBJECT_ID(@table_name), 'TableHasIdentity');

IF @RETURN = 1 
SET @output_script = @output_script + 'SET IDENTITY_INSERT [dbo].[' + @table_name + '] OFF;
';

SET @output_script = @output_script + 'GO';

END