using UserAuth.Infrastructure;
using UserAuth.Core;
using UserAuth.Api.Middlewares;
using System.Text.Json.Serialization;
using UserAuth.Core.Mapper;
using FluentValidation.AspNetCore;

namespace UserAuth.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddIfrastuctureServices();
            builder.Services.AddCoreServices();

            builder.Services.AddAutoMapper(typeof(MappingRegisterToAuthResponseProfile).Assembly);

            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddControllers().AddJsonOptions(options =>

            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())

            );

            var app = builder.Build();

            app.UseExceptionHandlerMiddleware();
            app.UseRouting();   
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();


            app.Run();
        }
    }
}
