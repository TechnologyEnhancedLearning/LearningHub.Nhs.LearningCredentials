
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

---- Initial lookup data
:r ..\ReleaseScripts\Populate_ClientSystems.sql
:r ..\ReleaseScripts\Populate_PeriodUnits.sql
:r ..\ReleaseScripts\Populate_VerifiableCredentials.sql
:r ..\ReleaseScripts\Populate_UserVerifiableCredentialStatuses.sql

