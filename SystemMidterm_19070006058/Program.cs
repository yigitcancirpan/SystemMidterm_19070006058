using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using SystemMidterm_19070006058.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.AspNetCore.Mvc.Versioning;
using SystemMidterm_19070006058.Source;
using SystemMidterm_19070006058;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();


//builder.Services.AddDbContext<MidtermContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//                .AddJwtBearer(options => {
//                    options.TokenValidationParameters = new TokenValidationParameters
//                    {
//                        ValidateIssuer = true,
//                        ValidateAudience = true,
//                        ValidateLifetime = true,
//                        ValidateIssuerSigningKey = true,
//                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
//                        ValidAudience = builder.Configuration["Jwt:Audience"],
//                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                        
//                    };
//                });

//builder.Services.AddApiVersioning(o =>
//{
//    o.AssumeDefaultVersionWhenUnspecified = true;
//    o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
//    o.ReportApiVersions = true;
//    o.ApiVersionReader = ApiVersionReader.Combine(
//        new QueryStringApiVersionReader("api-version"),
//        new HeaderApiVersionReader("X-Version"),
//        new MediaTypeApiVersionReader("ver"));

//});
//builder.Services.AddVersionedApiExplorer(
//    options =>
//    {
//        options.GroupNameFormat = "'v'VVV";
//        options.SubstituteApiVersionInUrl = true;
//    });


//builder.Services.AddMemoryCache();
//// add services here
//builder.Services.AddScoped<ICustomerService, CustomerService>();
//builder.Services.AddScoped<IHouseService, HouseService>();
//builder.Services.AddScoped<IUserService, UserService>();


        


//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
    
//}

//app.UseHttpsRedirection();

//app.UseRouting();

//app.UseAuthentication();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
namespace SystemMidterm_19070006058
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
    }
}




