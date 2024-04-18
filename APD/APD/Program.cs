using System.Reflection;
using APD.DAL;
using APD.Mapper;
using Microsoft.EntityFrameworkCore;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        
        builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(swagger =>
        {
            swagger.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "APD Swagger" });
            swagger.ResolveConflictingActions(
                apiDesc => { return apiDesc.First(); });
        
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            swagger.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
        
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"), sql => { });
        });
        
        builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

        #region Registry services
        new ServiceDal().Registry(builder.Services);
        #endregion
        
        var app = builder.Build();

        using (var serviceScope = ((IApplicationBuilder)app).ApplicationServices.GetService<IServiceScopeFactory>()
               ?.CreateScope())
        {
            if (serviceScope != null)
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
                context.Database.Migrate();
            }

        }

        app.UseSwagger();
        app.UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

        app.UseHttpsRedirection();

        //app.UseAuthentication();
        //app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}