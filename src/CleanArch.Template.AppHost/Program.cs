var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CleanArch_WebApi>("cleanarch-webapi");

builder.Build().Run();
