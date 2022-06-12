using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Profile.Application.Resources;

namespace Profile.Application;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseApplication(this IApplicationBuilder builder)
    {
        builder.UseRequestLocalization(options =>
        {
            var supportedCultures = new[]
            {
                CultureNames.En,
                CultureNames.Ru
            };
            
            options.AddSupportedCultures(supportedCultures);
            options.AddSupportedUICultures(supportedCultures);
            options.SetDefaultCulture(supportedCultures[0]);
            options.RequestCultureProviders.Add(new AcceptLanguageHeaderRequestCultureProvider());
        });
        
        return builder;
    }
}