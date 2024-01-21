using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop_api.Data;
using shop_api.Errors;
using shop_api.Repository.Interfaces;
using shop_api.Repository.Repos;

namespace shop_api.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        // ********************
        // APPLICATION CONTEXT
        // ********************
        services.AddDbContext<ApplicationStoreDbContext>(opts => opts.
            UseMySql(configuration.GetConnectionString("ApplicationStoreConnectionString"),
            ServerVersion.AutoDetect(configuration.
            GetConnectionString("ApplicationStoreConnectionString"))));

        // ************************
        // REPOSITORIES INJECTIONS
        // ************************
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        // API BEHAVIOR OPTIONS CONFIGURATION
        services.Configure<ApiBehaviorOptions>(opts =>
        {
            // handle the invalid model state responses...
            opts.InvalidModelStateResponseFactory = actionContext =>
            {
                // gets the error messages from the model state
                var errors = actionContext.ModelState
                .Where(e => e.Value.Errors.Count > 0)
                .SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage).ToArray();

                // create the object that validates the error response
                var errorResponse = new ApiValidationErrorResponse
                {
                    Errors = errors
                };

                return new BadRequestObjectResult(errorResponse); // returns the custom error response
            };

        });

        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
            });
        });

        return services;
    }
}
