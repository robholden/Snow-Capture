﻿using Identity.Domain;

using Library.Service.Api;

using Microsoft.AspNetCore;

namespace Identity.Api;

public static class Program
{
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args).CreateBuilder<Startup>();

    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().MigrateDbContext<IdentityContext>().Run();
    }
}