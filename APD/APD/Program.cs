using APD.DAL;
using Microsoft.EntityFrameworkCore;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"), sql => { });
        });

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
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        //app.UseAuthentication();
        //app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}