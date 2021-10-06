using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanBanAPI.Extensions
{
    //public static class ServiceCollectionExtensions
    //{
    //    public static IServiceCollection AddRepositories(this IServiceCollection services)
    //    {
    //        return services
    //            .AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>))
    //            .AddScoped<IUserRepository, UserRepository>()
    //            .AddScoped<IDepartmentRepository, DepartmentRepository>();
    //    }

    //    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    //    {
    //        return services
    //            .AddScoped<IUnitOfWork, UnitOfWork>();
    //    }

    //    public static IServiceCollection AddDatabase(this IServiceCollection services
    //        , IConfiguration configuration)
    //    {
    //        return services.AddDbContext<EFContext>(options =>
    //                 options.UseSqlServer(configuration.GetConnectionString("DDDConnectionString")));
    //    }

    //    public static IServiceCollection AddBusinessServices(this IServiceCollection services
    //       )
    //    {
    //        return services
    //            .AddScoped<UserService>();
    //    }
    //}
}
