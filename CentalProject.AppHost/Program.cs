var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Cental_DtoLayer>("cental-dtolayer");

builder.Build().Run();
