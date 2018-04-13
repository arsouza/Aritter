#load "./parameters.cake"

public class BuildPaths
{
    public BuildFiles Files { get; private set; }
    public BuildDirectories Directories { get; private set; }

    public static BuildPaths GetPaths(ICakeContext context, BuildParameters parameters)
    {
        var configuration =  parameters.Configuration;
        var buildDirectories = GetBuildDirectories(context);
        var testAssemblies = buildDirectories.Tests
                                             .Select(dir => dir.Combine("bin")
                                                               .Combine(configuration)
                                                               .Combine(parameters.TargetFramework)
                                                               .CombineWithFilePath(dir.GetDirectoryName() + ".dll"))
                                             .ToList();
        var testProjects =  buildDirectories.Tests.Select(dir => dir.CombineWithFilePath(dir.GetDirectoryName() + ".csproj")).ToList();
        var projects =  buildDirectories.Projects.Select(dir => dir.CombineWithFilePath(dir.GetDirectoryName() + ".csproj")).ToList();

        var buildFiles = new BuildFiles(
            buildDirectories.RootDir.CombineWithFilePath("Ritter.sln"),
            buildDirectories.TestResults.CombineWithFilePath("OpenCover.xml"),
            projects,
            testAssemblies,
            testProjects);

        return new BuildPaths
        {
            Files = buildFiles,
            Directories = buildDirectories
        };
    }

    public static BuildDirectories GetBuildDirectories(ICakeContext context)
    {
        var rootDir = (DirectoryPath)context.Directory("./");
        var srcDir = rootDir.Combine("src");
        var testsDir = rootDir.Combine("tests");
        var artifacts = rootDir.Combine(".artifacts");
        var testResults = artifacts.Combine("Test-Results");
        var nugetSpecs = artifacts.Combine("Nuget");
        var applicationTestsDir = testsDir.Combine(context.Directory("Application.Seedwork.Tests"));
        var domainTestsDir = testsDir.Combine(context.Directory("Domain.Seedwork.Tests"));
        var infraCrosscuttingTestsDir = testsDir.Combine(context.Directory("Infra.Crosscutting.Tests"));
        var infraDataTestsDir = testsDir.Combine(context.Directory("Infra.Data.Seedwork.Tests"));
        var apiProjectDir = srcDir.Combine(context.Directory("Api.Seedwork"));
        var appProjectDir = srcDir.Combine(context.Directory("Application.Seedwork"));
        var domainProjectDir = srcDir.Combine(context.Directory("Domain.Seedwork"));
        var infraSeedProjectDir = srcDir.Combine(context.Directory("Infra.Crosscutting"));
        var infraDataProjectDir = srcDir.Combine(context.Directory("Infra.Data.Seedwork"));

        var testsDirs = new []{
                                applicationTestsDir,
                                domainTestsDir,
                                infraCrosscuttingTestsDir,
                                infraDataTestsDir
                            };
        var projectsDirs = new []{
                                appProjectDir,
                                domainProjectDir,
                                infraSeedProjectDir,
                                infraDataProjectDir
                            };
        var toClean = new[] {
                                 testResults,
                                 nugetSpecs,
                                 applicationTestsDir.Combine("bin"),
                                 applicationTestsDir.Combine("obj"),
                                 domainTestsDir.Combine("bin"),
                                 domainTestsDir.Combine("obj"),
                                 infraCrosscuttingTestsDir.Combine("bin"),
                                 infraCrosscuttingTestsDir.Combine("obj"),
                                 infraDataTestsDir.Combine("bin"),
                                 infraDataTestsDir.Combine("obj"),
                                 apiProjectDir.Combine("bin"),
                                 apiProjectDir.Combine("obj"),
                                 appProjectDir.Combine("bin"),
                                 appProjectDir.Combine("obj"),
                                 domainProjectDir.Combine("bin"),
                                 domainProjectDir.Combine("obj"),
                                 infraSeedProjectDir.Combine("bin"),
                                 infraSeedProjectDir.Combine("obj"),
                                 infraDataProjectDir.Combine("bin"),
                                 infraDataProjectDir.Combine("obj")
                            };
        return new BuildDirectories(rootDir,
                                    srcDir,
                                    artifacts,
                                    testResults,
                                    nugetSpecs,
                                    projectsDirs,
                                    testsDirs,
                                    toClean);
    }
}

public class BuildFiles
{
    public FilePath Solution { get; private set; }
    public FilePath TestCoverageOutput { get; set;}
    public ICollection<FilePath> Projects { get; private set; }
    public ICollection<FilePath> TestAssemblies { get; private set; }
    public ICollection<FilePath> TestProjects { get; private set; }

    public BuildFiles(FilePath solution,
                      FilePath testCoverageOutput,
                      ICollection<FilePath> projects,
                      ICollection<FilePath> testAssemblies,
                      ICollection<FilePath> testProjects)
    {
        Solution = solution;
        TestCoverageOutput = testCoverageOutput;
        Projects = projects;
        TestAssemblies = testAssemblies;
        TestProjects = testProjects;
    }
}

public class BuildDirectories
{
    public DirectoryPath RootDir { get; private set; }
    public DirectoryPath Source { get; private set; }
    public DirectoryPath Artifacts { get; private set; }
    public DirectoryPath TestResults { get; private set; }
    public DirectoryPath NugetSpecs { get; private set; }
    public ICollection<DirectoryPath> Tests { get; private set; }
    public ICollection<DirectoryPath> Projects { get; private set; }
    public ICollection<DirectoryPath> ToClean { get; private set; }

    public BuildDirectories(
        DirectoryPath rootDir,
        DirectoryPath source,
        DirectoryPath artifacts,
        DirectoryPath testResults,
        DirectoryPath nugetSpecs,
        ICollection<DirectoryPath> projects,
        ICollection<DirectoryPath> tests,
        ICollection<DirectoryPath> toClean)
    {
        RootDir = rootDir;
        Artifacts = artifacts;
        Source = source;
        Tests = tests;
        ToClean = toClean;
        Projects = projects;
        TestResults = testResults;
        NugetSpecs = nugetSpecs;
    }
}
