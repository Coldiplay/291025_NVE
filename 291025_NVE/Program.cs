
using _291025_NVE.CQRS.Users;
using _291025_NVE.Validators;
using _291025_NVE.Validators.Behavior;
using MyMediator.Interfaces;
using MyMediator.Types;

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
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            // Сами валидаторы
            builder.Services.AddTransient<IValidator<RegisterUserCommand>, RegisterUserCommandValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
