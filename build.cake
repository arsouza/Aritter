#load "./parameters.cake"
#load "./paths.cake"

#tool nuget:?package=OpenCover
#tool nuget:?package=ReportGenerator

#addin nuget:?package=Cake.Git

var parameters = BuildParameters.GetParameters(Context);
var paths = BuildPaths.GetPaths(Context, parameters);

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

    ReportGenerator(paths.Files.TestCoverageOutput, paths.Directories.TestResults);

    if(!success)
    {
        throw new CakeException("There was an error while running the tests");
    }
});

Task("Nuget-Pack")
    .Does(() =>
{
    var success = true;

    var branch = GitDescribe(".");

    if (branch == "master")
    {
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
    }
    else
    {
        Information("Skiping task. The current branch is not 'master'");
    }

    if(!success)
    {
        throw new CakeException("There was an error while packing projects");
    }
});

Task("Nuget-Push")
    .IsDependentOn("Nuget-Pack")
    .Does(() =>
{
    var success = true;

    var branch = GitDescribe(".");

    if (branch == "master")
    {
        var files = GetFiles(paths.Directories.NugetSpecs + "/*.nupkg");

        foreach(var file in files)
        {
            try
            {
                var settings = new DotNetCoreNuGetPushSettings
                {
                    Source = "https://www.nuget.org/api/v2/package",
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
    }
    else
    {
        Information("Skiping task. The current branch is not 'master'");
    }

    if(!success)
    {
        throw new CakeException("There was an error while pushing packages");
    }
});

//nuget pack foo.csproj -Properties Configuration=Release

RunTarget(parameters.Target);
