using NUnit.Framework;

[assembly: LevelOfParallelism(4)]
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: SetCulture("en-US")]
[assembly: SetUICulture("en-US")]
