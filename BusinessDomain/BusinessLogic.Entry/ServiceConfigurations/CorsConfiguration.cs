namespace BusinessLogic.Entry.ServiceConfigurations;
public static class CorsConfiguration
{
    public const string CorsPolicyName = "MyCorsPolicy";
    public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicyName, opt =>
            {
                opt.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });
        });
        return services;
    }
}