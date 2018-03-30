#load "./parameters.cake"
#load "./paths.cake"

#tool nuget:?package=OpenCover
#tool nuget:?package=ReportGenerator

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

    if(success == false)
    {
        throw new CakeException("There was an error while running the tests");
    }

});

RunTarget(parameters.Target);
