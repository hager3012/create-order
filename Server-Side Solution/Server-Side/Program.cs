using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Server_Side.Erorrs;
using Server_Side.Middlewares;
using Server_Side.Repository;
using Server_Side.Repository.Contract;

namespace Server_Side
{
    public class Program
    {
        public static async  Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (Context) =>
                {
                    var errors = Context.ModelState.Where(M => M.Value.Errors.Count > 0)
                    .SelectMany(V => V.Value.Errors)
                    .Select(E => E.ErrorMessage);
                    var errorValitaion = new ApiValidationResponse(400)
                    {
                        Erorrs = errors
                    };
                return new BadRequestObjectResult(errorValitaion);
                };
            });
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("MyPolicy", option =>
                {
                    option.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
        var app = builder.Build();
            app.UseMiddleware<ApiExceptionMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStatusCodePagesWithRedirects("/erorr/{0}");
            app.UseHttpsRedirection();

            app.UseMiddleware<LanguageCheckMiddleware>();
            app.UseCors("MyPolicy");
            app.MapControllers();

            app.Run();
        }
    }
}