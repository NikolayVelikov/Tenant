using Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<TestContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Ovveride tenantId: https://www.codingame.com/playgrounds/5514/multi-tenant-asp-net-core-4---applying-tenant-rules-to-all-enitites

builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<ITenantProvider, DummyTenantPovider>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Auth/Login";
                options.AccessDeniedPath = "/Auth/Permission";

                options.Cookie.Name = "Tenant";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);

                // Link: https://www.yogihosting.com/aspnet-core-cookie-authentication/
                // Link: https://docs.microsoft.com/en-us/archive/msdn-magazine/2017/september/cutting-edge-cookies-claims-and-authentication-in-asp-net-core
                // Link: https://www.kaspersky.com/resource-center/definitions/cookies
                // Link: https://stackoverflow.com/questions/38360045/why-do-i-get-user-identity-isauthenticated-false - possible failure for Authorization
            });

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();