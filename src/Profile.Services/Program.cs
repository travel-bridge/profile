using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Profile.Application;
using Profile.Infrastructure;
using Profile.Services.Gql;
using Profile.Services.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.Authority = builder.Configuration["Security:Authority"]
            ?? throw new InvalidOperationException("Security authority are not configured.");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };

        if (builder.Environment.IsDevelopment())
            options.RequireHttpsMetadata = false;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(AuthorizePolicies.ReadProfile, policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "profile.read");
    });
    options.AddPolicy(AuthorizePolicies.WriteProfile, policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "profile.write");
    });
});

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCors();
builder.Services.AddGql();
builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("ProfileDatabase")
        ?? throw new InvalidOperationException("Connection string is not configured."));

var app = builder.Build();
app.UseApplication();

if (!builder.Environment.IsDevelopment())
{
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(x=> x.SetIsOriginAllowed(_ => true).AllowCredentials().AllowAnyHeader().AllowAnyMethod());
app.MapGraphQL().AllowAnonymous();
app.MapHealthChecks("/health");

await app.RunAsync();