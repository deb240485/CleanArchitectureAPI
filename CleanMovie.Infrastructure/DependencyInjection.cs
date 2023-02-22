using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanMovie.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection ImplementPersistence
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieDBContext>(options => 
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"), 
                    b => b.MigrationsAssembly(typeof(MovieDBContext).Assembly.FullName)),
                    ServiceLifetime.Transient);

            services.AddScoped<IMovieDbContext>(provider => provider.GetRequiredService<MovieDBContext>());

            return services;
        }
    }
}
