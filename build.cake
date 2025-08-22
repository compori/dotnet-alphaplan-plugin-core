#tool nuget:?package=NuGet.CommandLine&version=5.9.1
#tool nuget:?package=ReportGenerator&version=4.2.15
#tool nuget:?package=coverlet.console&version=1.5.3
#tool nuget:?package=OpenCover&version=4.7.922
// https://github.com/cake-build/cake/issues/2077
#tool nuget:?package=Microsoft.TestPlatform&version=16.2.0

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("Configuration", "Release");
var outputDirectory = Argument<DirectoryPath>("OutputDirectory", "output");
var packageDirectory = Argument<DirectoryPath>("PackageDirectory", "output/packages");
var codeCoverageDirectory = Argument<DirectoryPath>("CodeCoverageDirectory", "output/coverage");
var solutionFile = Argument("SolutionFile", "alphaplan-plugin-core.sln");
var versionSuffix = Argument("VersionSuffix", "");

var nugetDeployFeed = Argument("NugetDeployFeed", "https://api.nuget.org/v3/index.json");
var nugetDeployApiKey = Argument("NugetDeployApiKey", "");

//
// Parameter Alphaplan 2100 Version 287
//
var alphaplanSchnittellenExe2100Directory = Argument<DirectoryPath>("AlphaplanSchnittellenExe2100Directory", "references/alphaplan-2100-287/aps");
var alphaplanSchnittellenExe2100Path = Argument<FilePath>("AlphaplanSchnittellenExe2100Path", "references/alphaplan-2100-287/aps/AlphaplanSchnittstellen.exe");
var alphaplanSchnittellenPlugin2100Directory = Argument<DirectoryPath>("AlphaplanSchnittellenPlugin2100Directory", "references/alphaplan-2100-287/Data/Eigene");
var alphaplanSchnittellenPlugin2100TestRunnerPath = alphaplanSchnittellenPlugin2100Directory.CombineWithFilePath("TestRunnerPlugin.dll");

//
// Parameter Alphaplan 2850 Version 200
//
var alphaplanSchnittellenExe2850Directory = Argument<DirectoryPath>("AlphaplanSchnittellenExe2850Directory", "references/alphaplan-2850-200/app");
var alphaplanSchnittellenExe2850Path = Argument<FilePath>("AlphaplanSchnittellenExe2850Path", "references/alphaplan-2850-200/app/AlphaplanSchnittstellen.exe");
var alphaplanSchnittellenPlugin2850Directory = Argument<DirectoryPath>("AlphaplanSchnittellenPlugin2850Directory", "references/alphaplan-2850-200/app/Data/Eigene");
var alphaplanSchnittellenPlugin2850TestRunnerPath = alphaplanSchnittellenPlugin2850Directory.CombineWithFilePath("TestRunnerPlugin.dll");

//
// Parameter Alphaplan 3400 Version 134
//
var alphaplanSchnittellenExe3400Directory = Argument<DirectoryPath>("AlphaplanSchnittellenExe3400Directory", "references/alphaplan-3400-134/app");
var alphaplanSchnittellenExe3400Path = Argument<FilePath>("AlphaplanSchnittellenExe3400Path", "references/alphaplan-3400-134/app/AlphaplanSchnittstellen.exe");
var alphaplanSchnittellenPlugin3400Directory = Argument<DirectoryPath>("AlphaplanSchnittellenPlugin3400Directory", "references/alphaplan-3400-134/app/Data/Eigene");
var alphaplanSchnittellenPlugin3400TestRunnerPath = alphaplanSchnittellenPlugin3400Directory.CombineWithFilePath("TestRunnerPlugin.dll");

//
// Parameter Alphaplan 3850 Version 478
//
var alphaplanSchnittellenExe3850Directory = Argument<DirectoryPath>("AlphaplanSchnittellenExe3850Directory", "references/alphaplan-3850-478/app");
var alphaplanSchnittellenExe3850Path = Argument<FilePath>("AlphaplanSchnittellenExe3850Path", "references/alphaplan-3850-478/app/AlphaplanSchnittstellen.exe");
var alphaplanSchnittellenPlugin3850Directory = Argument<DirectoryPath>("AlphaplanSchnittellenPlugin3850Directory", "references/alphaplan-3850-478/app/Data/Eigene");
var alphaplanSchnittellenPlugin3850TestRunnerPath = alphaplanSchnittellenPlugin3850Directory.CombineWithFilePath("TestRunnerPlugin.dll");

//
// Parameter Alphaplan 4900 Version 311
//
var alphaplanSchnittellenExe4900Directory = Argument<DirectoryPath>("AlphaplanSchnittellenExe4900Directory", "references/alphaplan-4900-311/app");
var alphaplanSchnittellenExe4900Path = Argument<FilePath>("AlphaplanSchnittellenExe4900Path", "references/alphaplan-4900-311/app/AlphaplanSchnittstellen.exe");
var alphaplanSchnittellenPlugin4900Directory = Argument<DirectoryPath>("AlphaplanSchnittellenPlugin4900irectory", "references/alphaplan-4900-311/app/Data/Eigene");
var alphaplanSchnittellenPlugin4900TestRunnerPath = alphaplanSchnittellenPlugin4900Directory.CombineWithFilePath("TestRunnerPlugin.dll");

//
// Parameter Alphaplan 5500 Version 170
//
var alphaplanSchnittellenExe5500Directory = Argument<DirectoryPath>("AlphaplanSchnittellenExe5500Directory", "references/alphaplan-5500-170/app");
var alphaplanSchnittellenExe5500Path = Argument<FilePath>("AlphaplanSchnittellenExe5500Path", "references/alphaplan-5500-170/app/AlphaplanSchnittstellen.exe");
var alphaplanSchnittellenPlugin5500Directory = Argument<DirectoryPath>("AlphaplanSchnittellenPlugin5500irectory", "references/alphaplan-5500-170/app/Data/Eigene");
var alphaplanSchnittellenPlugin5500TestRunnerPath = alphaplanSchnittellenPlugin5500Directory.CombineWithFilePath("TestRunnerPlugin.dll");

//
// Path for Tools
//
FilePath coverletPath = Context.Tools.Resolve("coverlet.console.dll");
FilePath vstestPath = Context.Tools.Resolve("vstest.console.exe");    


//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

// Target : Clean
// 
// Description
// - Cleans Alphaplan plugin directories
// - Cleans binary directories.
// - Cleans output directory.
// - Cleans the test coverage directory.
Task("Clean")
    .Does(() =>
{
    CleanDirectory(alphaplanSchnittellenPlugin2100Directory);
    CleanDirectory(alphaplanSchnittellenPlugin2850Directory);
    CleanDirectory(alphaplanSchnittellenPlugin3400Directory);
    CleanDirectory(alphaplanSchnittellenPlugin3850Directory);
    CleanDirectory(alphaplanSchnittellenPlugin4900Directory);
    CleanDirectory(alphaplanSchnittellenPlugin5500Directory);

    CleanDirectory(codeCoverageDirectory);
    CleanDirectory(outputDirectory);    
    CreateDirectory(codeCoverageDirectory);
    
    // remove all binaries in source files
    var srcBinDirectories = GetDirectories("./src/**/bin");
    foreach(var directory in srcBinDirectories)
    {
        CleanDirectory(directory);
    }

    // remove all intermediates in source files
    var srcObjDirectories = GetDirectories("./src/**/obj");
    foreach(var directory in srcObjDirectories)
    {
        CleanDirectory(directory);
    }

    // remove all binaries in test files
    var testsBinDirectories = GetDirectories("./tests/**/bin");
    foreach(var directory in testsBinDirectories)
    {
        CleanDirectory(directory);
    }

    // remove all intermediates in source files
    var testsObjDirectories = GetDirectories("./tests/**/obj");
    foreach(var directory in testsObjDirectories)
    {
        CleanDirectory(directory);
    }
});

// Target : Restore-NuGet-Packages
// 
// Description
// - Restores all needed NuGet packages for the projects.
Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    // https://docs.microsoft.com/en-us/nuget/consume-packages/package-restore
    //
    // Reload all nuget packages used by the solution
    NuGetRestore(solutionFile);
});

// Target : Build
// 
// Description
// - Builds the artifacts.
Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    // Use MSBuild
    MSBuild(solutionFile, settings => {
    settings.ArgumentCustomization = 
        args => args
            .Append("/p:IncludeSymbols=true")
            .Append("/p:IncludeSource=true")
            .Append($"/p:VersionSuffix={versionSuffix}");
    settings.SetConfiguration(configuration);
    });
});

Task("Deploy")
    .IsDependentOn("Build")
    .Does(() =>
{
     CreateDirectory(packageDirectory);

    var packageFiles = GetFiles($"src/**/bin/{configuration}/*.nupkg");
    foreach(var packageFile in packageFiles)
    {
        var packageFilename = packageFile.GetFilename();
        var destionation = MakeAbsolute(packageDirectory).CombineWithFilePath(packageFilename);
        CopyFile(packageFile.FullPath, destionation);
    }

    var spackageFiles = GetFiles($"src/**/bin/{configuration}/*.snupkg");
    foreach(var spackageFile in spackageFiles)
    {
        var spackageFilename = spackageFile.GetFilename();
        var sdestination = MakeAbsolute(packageDirectory).CombineWithFilePath(spackageFilename);
        CopyFile(spackageFile.FullPath, sdestination);
    }
    
    packageFiles = GetFiles(MakeAbsolute(packageDirectory).FullPath + "/*.nupkg");
    spackageFiles = GetFiles(MakeAbsolute(packageDirectory).FullPath + "/*.snupkg");
    if(string.IsNullOrWhiteSpace(nugetDeployApiKey)) 
    {
        Error("No nuget api key provided. Please use argument e.g. --NugetDeployApiKey=1234567-8901-abcd-ef12-13212313121");
        return;
    }

    // Push the package.
    NuGetPush(packageFiles,
        new NuGetPushSettings {
                Source = nugetDeployFeed,
                ApiKey = nugetDeployApiKey,
                SkipDuplicate = true
    });   
});

Task("Test-With-CodeCoverage")
    .IsDependentOn("Build")
    .Does(() =>
{
    var includeFilter = "[Compori.Alphaplan.*]*"; 
    var excludeFilter = "[xunit.*]*"; 

    var testRunners = new List<Tuple<FilePath, DirectoryPath, FilePath>>();
    testRunners.Add(new Tuple<FilePath, DirectoryPath, FilePath>(alphaplanSchnittellenPlugin2100TestRunnerPath, alphaplanSchnittellenExe2100Directory, alphaplanSchnittellenExe2100Path));
    testRunners.Add(new Tuple<FilePath, DirectoryPath, FilePath>(alphaplanSchnittellenPlugin2850TestRunnerPath, alphaplanSchnittellenExe2850Directory, alphaplanSchnittellenExe2850Path));    
    testRunners.Add(new Tuple<FilePath, DirectoryPath, FilePath>(alphaplanSchnittellenPlugin3400TestRunnerPath, alphaplanSchnittellenExe3400Directory, alphaplanSchnittellenExe3400Path));    
    testRunners.Add(new Tuple<FilePath, DirectoryPath, FilePath>(alphaplanSchnittellenPlugin3850TestRunnerPath, alphaplanSchnittellenExe3850Directory, alphaplanSchnittellenExe3850Path));    
    testRunners.Add(new Tuple<FilePath, DirectoryPath, FilePath>(alphaplanSchnittellenPlugin5500TestRunnerPath, alphaplanSchnittellenExe5500Directory, alphaplanSchnittellenExe5500Path));    

    var i = 0;
    foreach(var testRunner in testRunners)
    {
        i++;
        var pluginPath = MakeAbsolute(testRunner.Item1);
        var workingDirectory = MakeAbsolute(testRunner.Item2);
        var alphaplanSchnittstellenExePath  = MakeAbsolute(testRunner.Item3);
        var pluginFilename = pluginPath.GetFilename();
        var coverageFile = pluginPath.GetFilenameWithoutExtension() + "." + i.ToString() + ".opencover.coverage.xml";
        var coveragePath = MakeAbsolute(codeCoverageDirectory).CombineWithFilePath(coverageFile);
/*
        Information(pluginPath);
        Information(pluginPath.GetFilename());
        Information(workingDirectory);
        Information(alphaplanSchnittstellenExePath);
        Information(coverageFile);
        Information(coveragePath);
*/        
        var settings = new OpenCoverSettings();
        settings.WithFilter($"+{includeFilter}");
        settings.WithFilter($"-{excludeFilter}") ;
        settings.WorkingDirectory = workingDirectory;

        OpenCover(
            action => {
                action.ProcessRunner.Start
                (
                    alphaplanSchnittstellenExePath.FullPath, 
                    new ProcessSettings 
                    {
                        Arguments = new ProcessArgumentBuilder()
                            .Append("-debug")
                            .Append($"-job {pluginFilename}"),
                        WorkingDirectory = workingDirectory
                    }
                );
            },
            coveragePath, settings                          
        );          
    }
});

// Target : Test-With-CoverageReport
// 
// Description
// - Executes the test and generates with code coverage files.
// - Generates a code coverage html report with badges.
Task("Test-With-CodeCoverageReport")
    .IsDependentOn("Test-With-CodeCoverage")
    .Does(() =>
{
    ReportGenerator( 
        new GlobPattern(MakeAbsolute(codeCoverageDirectory).FullPath + "/*.coverage.xml"), 
        MakeAbsolute(codeCoverageDirectory).FullPath + "/report",
        new ReportGeneratorSettings(){
            ReportTypes = new[] { 
                ReportGeneratorReportType.HtmlInline,
                ReportGeneratorReportType.Badges 
            }
        }
    );
});

// Target : Build
// 
// Description
// - Setup the default task.
Task("Default")
    .IsDependentOn("Build");

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
