#load "./parameters.cake"

public class BuildPaths
{
    public BuildFiles Files { get; private set; }
    public BuildDirectories Directories { get; private set; }

    public static BuildPaths GetPaths(ICakeContext context, BuildParameters parameters)
    {
        var configuration =  parameters.Configuration;
        var buildDirectories = GetBuildDirectories(context);
        var testAssemblies = buildDirectories.TestDirs
                                             .Select(dir => dir.Combine("bin")
                                                               .Combine(configuration)
                                                               .Combine(parameters.TargetFramework)
                                                               .CombineWithFilePath(dir.GetDirectoryName() + ".dll"))
                                             .ToList();
        var testProjects =  buildDirectories.TestDirs.Select(dir => dir.CombineWithFilePath(dir.GetDirectoryName() + ".csproj")).ToList();

        var buildFiles = new BuildFiles(
            buildDirectories.RootDir.CombineWithFilePath("Ritter.sln"),
            buildDirectories.TestResults.CombineWithFilePath("OpenCover.xml"),
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
        var applicationTestsDir = testsDir.Combine(context.Directory("Application.Seedwork.Tests"));
        var domainTestsDir = testsDir.Combine(context.Directory("Domain.Seedwork.Tests"));
        var infraCrosscuttingTestsDir = testsDir.Combine(context.Directory("Infra.Crosscutting.Tests"));
        var infraDataTestsDir = testsDir.Combine(context.Directory("Infra.Data.Seedwork.Tests"));
        var apiProjectDir = srcDir.Combine(context.Directory("Api.Seedwork"));
        var appProjectDir = srcDir.Combine(context.Directory("Application.Seedwork"));
        var domainProjectDir = srcDir.Combine(context.Directory("Domain.Seedwork"));
        var infraSeedProjectDir = srcDir.Combine(context.Directory("Infra.Crosscutting"));
        var infraDataProjectDir = srcDir.Combine(context.Directory("Infra.Data.Seedwork"));

        var testDirs = new []{
                                applicationTestsDir,
                                domainTestsDir,
                                infraCrosscuttingTestsDir,
                                infraDataTestsDir
                            };
        var toClean = new[] {
                                 testResults,
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
                                    artifacts,
                                    testResults,
                                    testDirs,
                                    toClean);
    }
}

public class BuildFiles
{
    public FilePath Solution { get; private set; }
    public FilePath TestCoverageOutput { get; set;}
    public ICollection<FilePath> TestAssemblies { get; private set; }
    public ICollection<FilePath> TestProjects { get; private set; }

    public BuildFiles(FilePath solution,
                      FilePath testCoverageOutput,
                      ICollection<FilePath> testAssemblies,
                      ICollection<FilePath> testProjects)
    {
        Solution = solution;
        TestAssemblies = testAssemblies;
        TestCoverageOutput = testCoverageOutput;
        TestProjects = testProjects;
    }
}

public class BuildDirectories
{
    public DirectoryPath RootDir { get; private set; }
    public DirectoryPath Artifacts { get; private set; }
    public DirectoryPath TestResults { get; private set; }
    public ICollection<DirectoryPath> TestDirs { get; private set; }
    public ICollection<DirectoryPath> ToClean { get; private set; }

    public BuildDirectories(
        DirectoryPath rootDir,
        DirectoryPath artifacts,
        DirectoryPath testResults,
        ICollection<DirectoryPath> testDirs,
        ICollection<DirectoryPath> toClean)
    {
        RootDir = rootDir;
        Artifacts = artifacts;
        TestDirs = testDirs;
        ToClean = toClean;
        TestResults = testResults;
    }
}
