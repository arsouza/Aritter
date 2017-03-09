using System;
using System.Diagnostics;

namespace Aritter.CodeCoverage
{
	class Program
	{
		private static string dotnet = "\"C:/Program Files/dotnet/dotnet.exe\"";
		private static string opencover = @"""C:\Users\andersonritter\.nuget\packages\OpenCover\4.6.519\tools\OpenCover.Console.exe""";
		private static string reportgenerator = @"""C:\Users\andersonritter\.nuget\packages\ReportGenerator\2.5.5\tools\ReportGenerator.exe""";
		private static string targetdir = @"C:\Projetos\Aritter\Aritter\src\Aritter.Infra.Crosscutting.Tests";
		private static string targetargs = "test";
		private static string filter = "\"+[Aritter*]* -[*Tests]*\"";
		private static string coveragedir = "Coverage";
		private static string coveragefile = $"Coverage.xml";
		
		static void Main(string[] args)
		{
			// Run code coverage analysis  
			Process openCoverProcess = new Process()
			{
				StartInfo = new ProcessStartInfo(opencover, $"-target:{dotnet} -output:{coveragefile} -targetargs:{targetargs} -register:user -targetdir:{targetdir} -filter:{filter} -log:All -oldStyle")
			};

			openCoverProcess.Start();
			openCoverProcess.WaitForExit();

			Process reportGeneratorProcess = new Process()
			{
				StartInfo = new ProcessStartInfo(reportgenerator, $"-targetdir:{coveragedir} -reporttypes:Html;Badges -reports:{coveragefile} -verbosity:Error")
			};

			reportGeneratorProcess.Start();
			reportGeneratorProcess.WaitForExit();

			Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", $@"{targetdir}\{coveragedir}\index.htm");
			Console.ReadKey();
		}
	}
}