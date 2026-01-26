
using _4EPlatForm.Application;
using PlatformSettings.Application.Services;

namespace SystemSetting
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddGrpc();
            builder.Services.AddGrpcReflection();
            var logger = new LoggerConfiguration()
         .ReadFrom.Configuration(builder.Configuration)
         .Enrich.FromLogContext()
         .CreateLogger();
            builder.Host.UseSerilog(logger);

            builder.WebHost.ConfigureKestrel(options =>
            {
                options.Listen(IPAddress.Any, 7297, o => o.Protocols = HttpProtocols.Http2);

                // ADDED THIS LINE to fix the problem
                options.Listen(IPAddress.Any, 5196, o => o.Protocols = HttpProtocols.Http1);
            });
            // Add services to the container.
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://elasticsearch:9200"))
            {
                AutoRegisterTemplate = true,
                AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6
            }).CreateLogger();

            //builder.Host.UseSerilog();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped(typeof(IGRepository<>), typeof(GRepository<>));
            // configure consumers injections for kafka
            /* builder.Services.ConfigureConsumersInjection();*/
            // Sql Providers
            builder.Services.ConfigureSqlProviders(builder.Configuration);
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CoreModule).Assembly);
            });
            builder.Services.AddAutoMapper(typeof(Program), typeof(CoreModule));
            builder.Services.AddScoped(typeof(IGRepository<>), typeof(GRepository<>));
            builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            //builder.Services.AddScoped<PermissionsCheckerMiddleware, PermissionsCheckerMiddleware>();
            builder.Services.AddSingleton<ITokenService, TokenService>();
            builder.Services.AddScoped<IWorkspace, Workspace>();
            builder.Services.AddUserManagementGrpcClients(builder.Configuration["GrpcServiceSettings:UserManagementUrl"]);
            builder.Services.AddWorkspaceGrpcClients(builder.Configuration["GrpcServiceSettings:WorkspaceUrl"]);
            builder.Services.AddHostedService<AddPermissionsMiddleware>();
            builder.Services.AddScoped<PermissionsGroupingCheckerMiddleware, PermissionsGroupingCheckerMiddleware>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowCors",
                    builder =>
                    {
                        builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("http://localhost:3000")
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials();
                    });
            });
            // Configure Swagger Auth
            builder.Services.ConfigureSwaggerAuth();
            builder.Services.AddUnitOfWorkRepositories();

            //Idntity Server Configuration
            builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                // the name of your api resources   
                options.Audience = "UserManagementServer";
                /// identity server url                    
                options.Authority = builder.Configuration.GetValue<string>("IdentityUrl");
                options.RequireHttpsMetadata = false;

            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ResourceOwnerPolicy", policy =>
                {
                    policy.AddAuthenticationSchemes("Bearer");
                    policy.RequireClaim("scope", "4EMicroServices"); // Require scope associated with Resource Owner Password token
                });

                options.AddPolicy("ClientCredentialsPolicy", policy =>
                {
                    policy.AddAuthenticationSchemes("Bearer");
                    policy.RequireClaim("scope", "CPAggregatorAPI"); // Require scope associated with Client Credentials token
                });
            });
            builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            builder.WebHost.UseWebRoot("wwwroot");

            var app = builder.Build();

            using (var serviceScope = app.Services.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<DBContext>();
                var serviceProvider = serviceScope.ServiceProvider;
                if (!serviceScope.ServiceProvider.GetService<DBContext>().AllMigrationsApplied())
                {
                    serviceScope.ServiceProvider.GetService<DBContext>().Migrate();
                }
                ContextSeed.Seed(dbContext, serviceProvider);
            }


            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
                RequestPath = "/wwwroot"
            });

            app.UseCors("AllowCors");
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseMiddleware<PermissionsCheckerMiddleware>();
            app.UseMiddleware<PermissionsGroupingCheckerMiddleware>();
            app.MapGrpcService<MainSettingsServices>();
            app.MapGrpcService<PlatformSettingsControllerAndActionNameService>();
            app.MapGrpcReflectionService();
            app.MapControllers();
            app.UseSerilogRequestLogging();
            app.Run();
        }
    }
}
