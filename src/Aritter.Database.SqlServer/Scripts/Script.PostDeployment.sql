/*
Post-Deployment Script Template                            
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.        
 Use SQLCMD syntax to include a file in the post-deployment script.            
 Example:      :r .\myfile.sql                                
 Use SQLCMD syntax to reference a variable in the post-deployment script.        
 Example:      :setvar TableName MyTable                            
               SELECT * FROM [$(TableName)]                    
--------------------------------------------------------------------------------------
*/
:r .\Scripts\DataLoad\Module.sql
:r .\Scripts\DataLoad\Roles.sql
:r .\Scripts\DataLoad\Users.sql
:r .\Scripts\DataLoad\UserRoles.sql
:r .\Scripts\DataLoad\UsersPasswords.sql
:r .\Scripts\DataLoad\Features.sql
:r .\Scripts\DataLoad\Permissions.sql
:r .\Scripts\DataLoad\Authorizations.sql