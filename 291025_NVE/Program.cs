
using _291025_NVE.CQRS.Users;
using _291025_NVE.Validators;
using _291025_NVE.Validators.Behavior;
using MyMediator.Extension;
using MyMediator.Interfaces;
using MyMediator.Types;
using Scalar.AspNetCore;
using System.Reflection;

namespace _291025_NVE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddSingleton<IMediator, Mediator>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            //builder.Services.AddScoped<Mediator>();
            //builder.Services.AddMediatorHandlers(Assembly.GetExecutingAssembly());

            // Сами валидаторы
            builder.Services.AddTransient<IValidator<RegisterUserCommand>, RegisterUserCommandValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseMiddleware<GlobalExceptionMiddleware>();
            
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
