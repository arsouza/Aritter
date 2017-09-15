@echo off

SET dotnet="C:/Program Files/dotnet/dotnet.exe"  
SET opencover=C:\Users\andersonritter\.nuget\packages\OpenCover\4.6.519\tools\OpenCover.Console.exe 
SET reportgenerator=C:\Users\andersonritter\.nuget\packages\reportgenerator\2.5.11\tools\ReportGenerator.exe

SET targetargs="test"  
SET filter="+[Aritter*]* -[*Tests]*"  
SET coveragefile=Coverage.xml  
SET coveragedir="Reports/Coverage"

REM Run code coverage analysis  
%opencover% -oldStyle -register:user -target:%dotnet% -output:%coveragefile% -targetargs:%targetargs% -filter:%filter% -skipautoprops -hideskipped:All -log:All

REM Generate the report  
%reportgenerator% -targetdir:%coveragedir% -reporttypes:Html;Badges -reports:%coveragefile% -verbosity:Verbose

REM Open the report  
start "report" "%coveragedir%\index.htm"
