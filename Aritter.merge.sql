-- Applications -------------------------------------------------------------

SET NOCOUNT ON
	
SET IDENTITY_INSERT [dbo].[Applications] ON;
GO

MERGE INTO [dbo].[Applications] AS T
USING (VALUES
	(1, NULL, 'Aritter', newid())
)
AS S ([Id], [Description], [Name], [UID])
ON (T.[Id] = S.[Id])

-- UPDATE MATCHED ROWS
WHEN MATCHED THEN
UPDATE SET
    [Description] = S.[Description],
    [Name] = S.[Name],
    [UID] = S.[UID]

-- INSERT NEW ROWS
WHEN NOT MATCHED BY TARGET THEN
    INSERT([Id], [Description], [Name], [UID])
    VALUES(S.[Id], S.[Description], S.[Name], S.[UID])

-- DELETE ROWS THAT ARE IN THE TARGET BUT NOT THE SOURCE
WHEN NOT MATCHED BY SOURCE THEN
DELETE;

PRINT 'Applications: ' + CAST(@@ROWCOUNT AS VARCHAR(100));
 
SET IDENTITY_INSERT [dbo].[Applications] OFF;
GO
-- UserProfiles -------------------------------------------------------------

SET NOCOUNT ON
	
SET IDENTITY_INSERT [dbo].[UserProfiles] ON;
GO

MERGE INTO [dbo].[UserProfiles] AS T
USING (VALUES
	(1, 'Anderson Ritter de Souza', newid())
)
AS S ([Id], [FullName], [UID])
ON (T.[Id] = S.[Id])

-- UPDATE MATCHED ROWS
WHEN MATCHED THEN
UPDATE SET
    [FullName] = S.[FullName],
    [UID] = S.[UID]

-- INSERT NEW ROWS
WHEN NOT MATCHED BY TARGET THEN
    INSERT([Id], [FullName], [UID])
    VALUES(S.[Id], S.[FullName], S.[UID])

-- DELETE ROWS THAT ARE IN THE TARGET BUT NOT THE SOURCE
WHEN NOT MATCHED BY SOURCE THEN
DELETE;

PRINT 'UserProfiles: ' + CAST(@@ROWCOUNT AS VARCHAR(100));
 
SET IDENTITY_INSERT [dbo].[UserProfiles] OFF;
GO
-- Rules -------------------------------------------------------------

SET NOCOUNT ON
	
SET IDENTITY_INSERT [dbo].[Rules] ON;
GO

MERGE INTO [dbo].[Rules] AS T
USING (VALUES
	(1, 1, 'Read', newid()),
	(2, 1, 'Write', newid()),
	(3, 1, 'Modify', newid())
)
AS S ([Id], [ApplicationId], [Name], [UID])
ON (T.[Id] = S.[Id])

-- UPDATE MATCHED ROWS
WHEN MATCHED THEN
UPDATE SET
    [ApplicationId] = S.[ApplicationId],
    [Name] = S.[Name],
    [UID] = S.[UID]

-- INSERT NEW ROWS
WHEN NOT MATCHED BY TARGET THEN
    INSERT([Id], [ApplicationId], [Name], [UID])
    VALUES(S.[Id], S.[ApplicationId], S.[Name], S.[UID])

-- DELETE ROWS THAT ARE IN THE TARGET BUT NOT THE SOURCE
WHEN NOT MATCHED BY SOURCE THEN
DELETE;

PRINT 'Rules: ' + CAST(@@ROWCOUNT AS VARCHAR(100));
 
SET IDENTITY_INSERT [dbo].[Rules] OFF;
GO
-- Resources -------------------------------------------------------------

SET NOCOUNT ON
	
SET IDENTITY_INSERT [dbo].[Resources] ON;
GO

MERGE INTO [dbo].[Resources] AS T
USING (VALUES
	(1, 1, NULL, 'Users', newid()),
	(2, 1, NULL, 'Security', newid()),
	(3, 1, NULL, 'PublicProfiles', newid())	
)
AS S ([Id], [ApplicationId], [Description], [Name], [UID])
ON (T.[Id] = S.[Id])

-- UPDATE MATCHED ROWS
WHEN MATCHED THEN
UPDATE SET
    [ApplicationId] = S.[ApplicationId],
    [Description] = S.[Description],
    [Name] = S.[Name],
    [UID] = S.[UID]

-- INSERT NEW ROWS
WHEN NOT MATCHED BY TARGET THEN
    INSERT([Id], [ApplicationId], [Description], [Name], [UID])
    VALUES(S.[Id], S.[ApplicationId], S.[Description], S.[Name], S.[UID])

-- DELETE ROWS THAT ARE IN THE TARGET BUT NOT THE SOURCE
WHEN NOT MATCHED BY SOURCE THEN
DELETE;

PRINT 'Resources: ' + CAST(@@ROWCOUNT AS VARCHAR(100));
 
SET IDENTITY_INSERT [dbo].[Resources] OFF;
GO
-- Roles -------------------------------------------------------------

SET NOCOUNT ON
	
SET IDENTITY_INSERT [dbo].[Roles] ON;
GO

MERGE INTO [dbo].[Roles] AS T
USING (VALUES
	(1, 1, 'Users', 'All users of system', newid()),
	(2, 1, 'Administrators', 'Administrators', newid()),
	(3, 1, 'Security Administrators', 'Security Administrators', newid())
)
AS S ([Id], [ApplicationId], [Description], [Name], [UID])
ON (T.[Id] = S.[Id])

-- UPDATE MATCHED ROWS
WHEN MATCHED THEN
UPDATE SET
    [ApplicationId] = S.[ApplicationId],
    [Description] = S.[Description],
    [Name] = S.[Name],
    [UID] = S.[UID]

-- INSERT NEW ROWS
WHEN NOT MATCHED BY TARGET THEN
    INSERT([Id], [ApplicationId], [Description], [Name], [UID])
    VALUES(S.[Id], S.[ApplicationId], S.[Description], S.[Name], S.[UID])

-- DELETE ROWS THAT ARE IN THE TARGET BUT NOT THE SOURCE
WHEN NOT MATCHED BY SOURCE THEN
DELETE;

PRINT 'Roles: ' + CAST(@@ROWCOUNT AS VARCHAR(100));
 
SET IDENTITY_INSERT [dbo].[Roles] OFF;
GO
-- UserAccounts -------------------------------------------------------------

SET NOCOUNT ON
	
SET IDENTITY_INSERT [dbo].[UserAccounts] ON;
GO

MERGE INTO [dbo].[UserAccounts] AS T
USING (VALUES
	(1, 'anderdsouza@gmail.com', 0, 0, 'eq5KRSUuKv4ANwh4JJFm8Q==', newid(), 1, 'aritters'),
	(2, 'arsouza@outlook.com', 0, 0, 'H6xHyv3UxPKMbKSFDcWmwA==', newid(), NULL, 'anderdsouza')
)
AS S ([Id], [Email], [InvalidLoginAttemptsCount], [MustChangePassword], [Password], [UID], [ProfileId], [Username])
ON (T.[Id] = S.[Id])

-- UPDATE MATCHED ROWS
WHEN MATCHED THEN
UPDATE SET
    [Email] = S.[Email],
    [InvalidLoginAttemptsCount] = S.[InvalidLoginAttemptsCount],
    [MustChangePassword] = S.[MustChangePassword],
    [Password] = S.[Password],
    [UID] = S.[UID],
    [ProfileId] = S.[ProfileId],
    [Username] = S.[Username]

-- INSERT NEW ROWS
WHEN NOT MATCHED BY TARGET THEN
    INSERT([Id], [Email], [InvalidLoginAttemptsCount], [MustChangePassword], [Password], [UID], [ProfileId], [Username])
    VALUES(S.[Id], S.[Email], S.[InvalidLoginAttemptsCount], S.[MustChangePassword], S.[Password], S.[UID], S.[ProfileId], S.[Username])

-- DELETE ROWS THAT ARE IN THE TARGET BUT NOT THE SOURCE
WHEN NOT MATCHED BY SOURCE THEN
DELETE;

PRINT 'UserAccounts: ' + CAST(@@ROWCOUNT AS VARCHAR(100));
 
SET IDENTITY_INSERT [dbo].[UserAccounts] OFF;
GO
-- Permissions -------------------------------------------------------------

SET NOCOUNT ON
	
SET IDENTITY_INSERT [dbo].[Permissions] ON;
GO

MERGE INTO [dbo].[Permissions] AS T
USING (VALUES
	(1, 1, 1, newid()),
	(2, 2, 1, newid()),
	(3, 3, 1, newid()),
	(4, 1, 2, newid()),
	(5, 2, 2, newid()),
	(6, 3, 2, newid()),
	(7, 1, 3, newid()),
	(8, 2, 3, newid()),
	(9, 3, 3, newid())
)
AS S ([Id], [RuleId], [ResourceId], [UID])
ON (T.[Id] = S.[Id])

-- UPDATE MATCHED ROWS
WHEN MATCHED THEN
UPDATE SET
    [RuleId] = S.[RuleId],
    [ResourceId] = S.[ResourceId],
    [UID] = S.[UID]

-- INSERT NEW ROWS
WHEN NOT MATCHED BY TARGET THEN
    INSERT([Id], [RuleId], [ResourceId], [UID])
    VALUES(S.[Id], S.[RuleId], S.[ResourceId], S.[UID])

-- DELETE ROWS THAT ARE IN THE TARGET BUT NOT THE SOURCE
WHEN NOT MATCHED BY SOURCE THEN
DELETE;

PRINT 'Permissions: ' + CAST(@@ROWCOUNT AS VARCHAR(100));
 
SET IDENTITY_INSERT [dbo].[Permissions] OFF;
GO
-- RoleMembers -------------------------------------------------------------

SET NOCOUNT ON
	
SET IDENTITY_INSERT [dbo].[RoleAssignments] ON;
GO

MERGE INTO [dbo].[RoleAssignments] AS T
USING (VALUES
	(1, newid(), 1, NULL, 1),
	(2, newid(), 1, NULL, 2),
	(3, newid(), 2, NULL, 3),
	(4, newid(), 1, 1, NULL),
	(5, newid(), 2, 1, NULL),
	(6, newid(), 3, 1, NULL)
)
AS S ([Id], [UID], [RoleId], [AccountAssignedId], [RoleAssignedId])
ON (T.[Id] = S.[Id])

-- UPDATE MATCHED ROWS
WHEN MATCHED THEN
UPDATE SET
    [UID] = S.[UID],
    [RoleId] = S.[RoleId],	
    [AccountAssignedId] = S.[AccountAssignedId]

-- INSERT NEW ROWS
WHEN NOT MATCHED BY TARGET THEN
    INSERT([Id], [UID], [RoleId], [AccountAssignedId], [RoleAssignedId])
    VALUES(S.[Id], S.[UID], S.[RoleId], S.[AccountAssignedId], S.[RoleAssignedId])

-- DELETE ROWS THAT ARE IN THE TARGET BUT NOT THE SOURCE
WHEN NOT MATCHED BY SOURCE THEN
DELETE;

PRINT 'RoleAssignments: ' + CAST(@@ROWCOUNT AS VARCHAR(100));
 
SET IDENTITY_INSERT [dbo].[RoleAssignments] OFF;
GO
-- Authorizations -------------------------------------------------------------

SET NOCOUNT ON
	
SET IDENTITY_INSERT [dbo].[Authorizations] ON;
GO

MERGE INTO [dbo].[Authorizations] AS T
USING (VALUES
	(1, 1, 0, 1, newid(), 2),
	(2, 1, 0, 2, newid(), 2),
	(3, 1, 0, 3, newid(), 2),
	(4, 1, 0, 4, newid(), 2),
	(5, 1, 0, 5, newid(), 2),
	(6, 1, 0, 6, newid(), 2),
	(7, 1, 0, 7, newid(), 2),
	(8, 1, 0, 8, newid(), 2),
	(9, 1, 0, 9, newid(), 2)
)
AS S ([Id], [Allowed], [Denied], [PermissionId], [UID], [RoleId])
ON (T.[Id] = S.[Id])

-- UPDATE MATCHED ROWS
WHEN MATCHED THEN
UPDATE SET
    [Allowed] = S.[Allowed],
    [Denied] = S.[Denied],
    [PermissionId] = S.[PermissionId],
    [UID] = S.[UID],
    [RoleId] = S.[RoleId]

-- INSERT NEW ROWS
WHEN NOT MATCHED BY TARGET THEN
    INSERT([Id], [Allowed], [Denied], [PermissionId], [UID], [RoleId])
    VALUES(S.[Id], S.[Allowed], S.[Denied], S.[PermissionId], S.[UID], S.[RoleId])

-- DELETE ROWS THAT ARE IN THE TARGET BUT NOT THE SOURCE
WHEN NOT MATCHED BY SOURCE THEN
DELETE;

PRINT 'Authorizations: ' + CAST(@@ROWCOUNT AS VARCHAR(100));
 
SET IDENTITY_INSERT [dbo].[Authorizations] OFF;
GO
