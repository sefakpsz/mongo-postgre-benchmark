using Discount.API.Context;
using Discount.API.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Finance.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<ContentDbContext>(options =>
            {
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

                options.UseNpgsql(configuration.GetValue<string>("DatabaseSettings:ConnectionString"), sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(3);
                });
            });

            services.AddSingleton<IContentRepository, ContentRepository>();
        }
    }
}