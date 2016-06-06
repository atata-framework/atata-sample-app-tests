using System.Reflection;
using System.Runtime.InteropServices;
using NUnit.Framework;

[assembly: AssemblyTitle("Atata.SampleApp.AutoTests")]
[assembly: Guid("ebadb914-9630-4f25-bd16-c0ca760f57bf")]

[assembly: LevelOfParallelism(4)]
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: SetCulture("en-us")]
[assembly: SetUICulture("en-us")]