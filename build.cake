#load "./parameters.cake"
#load "./paths.cake"

#tool nuget:?package=OpenCover
#tool nuget:?package=ReportGenerator

#addin nuget:?package=Cake.Git

var parameters = BuildParameters.GetParameters(Context);
var paths = BuildPaths.GetPaths(Context, parameters);
var isMasterBranch = StringComparer.OrdinalIgnoreCase.Equals("master", GitDescribe("."));

Setup(context =>
{
    if (!DirectoryExists(paths.Directories.Artifacts))
    {
        CreateDirectory(paths.Directories.Artifacts);
    }

    if (!DirectoryExists(paths.Directories.TestResults))
    {
        CreateDirectory(paths.Directories.TestResults);
    }

    if (!DirectoryExists(paths.Directories.Coverage))
    {
        CreateDirectory(paths.Directories.Coverage);
    }
});

Task("Clean")
    .Does(() =>
{
    CleanDirectories(paths.Directories.ToClean);
});

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreBuild(paths.Files.Solution.ToString(), new DotNetCoreBuildSettings
    {
        Configuration = parameters.Configuration,
        ArgumentCustomization = arg => arg.AppendSwitch("/p:DebugType","=","Full")
    });
});

Task("Run-Tests")
    .Does(() =>
{
    var success = true;
    var openCoverSettings = new OpenCoverSettings
    {
        OldStyle = true,
        MergeOutput = true
    }
    .WithFilter("+[Ritter*]*");

    if(parameters.UseDotNetVsTest){

        Action<ICakeContext> testAction = context =>
        {
            var argumentBuilder = new ProcessArgumentBuilder();
            argumentBuilder.Append("vstest")
                           .Append(string.Join(" ", paths.Files.TestAssemblies.Select(val => MakeAbsolute(val).ToString())))
                           .Append("--Parallel");

            context.StartProcess("dotnet", new ProcessSettings
            {
                Arguments = argumentBuilder
            });
        };

        OpenCover(testAction, paths.Files.TestCoverageOutput, openCoverSettings);
    }
    else
    {
        foreach(var project in paths.Files.TestProjects)
        {
            try
            {
                var projectFile = MakeAbsolute(project).ToString();
                var dotNetTestSettings = new DotNetCoreTestSettings
                {
                    Configuration = parameters.Configuration,
                    ResultsDirectory = paths.Directories.TestResults,
                    NoBuild = true
                };

                OpenCover(context => context.DotNetCoreTest(projectFile, dotNetTestSettings), paths.Files.TestCoverageOutput, openCoverSettings);
            }
            catch(Exception ex)
            {
                success = false;
                Error("There was an error while running the tests", ex);
            }
        }
    }

    ReportGenerator(paths.Files.TestCoverageOutput, paths.Directories.Coverage);

    if(!success)
    {
        throw new CakeException("There was an error while running the tests");
    }
});

Task("Nuget-Pack")
    .Does(() =>
{
    var success = true;

    foreach(var project in paths.Files.Projects)
    {
        try
        {
            var projectFile = MakeAbsolute(project).ToString();
            var settings = new DotNetCorePackSettings
            {
                Configuration = parameters.Configuration,
                OutputDirectory = paths.Directories.NugetSpecs,
                NoRestore = true,
                NoBuild = true
            };

            DotNetCorePack(projectFile, settings);
        }
        catch(Exception ex)
        {
            success = false;
            Error("There was an error while packing project", ex);
        }
    }

    if(!success)
    {
        throw new CakeException("There was an error while packing projects");
    }
});

Task("Nuget-Push")
    .WithCriteria(isMasterBranch)
    .IsDependentOn("Nuget-Pack")
    .Does(() =>
{
    var success = true;

    var files = GetFiles(paths.Directories.NugetSpecs + "/*.nupkg");

    foreach(var file in files)
    {
        try
        {
            var settings = new DotNetCoreNuGetPushSettings
            {
                Source = "https://api.nuget.org/v3/index.json",
                ApiKey = "oy2al35gno3g3prywoyqur7t5fminoduhheao46svy6sj4"
            };

            DotNetCoreNuGetPush(file.ToString(), settings);
        }
        catch(Exception ex)
        {
            success = false;
            Error("There was an error while pushing package", ex);
        }
    }

    if(!success)
    {
        throw new CakeException("There was an error while pushing packages");
    }
});

Task("Default")
    .IsDependentOn("Build")
    .IsDependentOn("Run-Tests")
    .IsDependentOn("Nuget-Pack")
    .IsDependentOn("Nuget-Push")
    .Does(() =>
    {
    });

RunTarget(parameters.Target);
