using DAO;
using EXE201_NEWDAWN_BE.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.IdentityServices(builder.Configuration);
builder.Services.ApplicationServices(builder.Configuration);

//builder.Services.AddDbContext<DataContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlClient")));

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

//using var scope = app.Services.CreateScope();
//var services = scope.ServiceProvider;
//try
//{
//    var context = services.GetRequiredService<DataContext>();
//    await context.Database.MigrateAsync();
//    await SeedData.SeedAccount(context);
//}
//catch (Exception ex)
//{
//    var logger = services.GetService<ILogger<Program>>();
//    logger.LogError(ex, "An error occured during migration");
//}


app.UseStaticFiles(new StaticFileOptions
{

    FileProvider = new PhysicalFileProvider(
   Path.Combine(builder.Environment.ContentRootPath, "Uploads")),
    RequestPath = "/Uploads"
});

app.MapControllers();

app.Run();
