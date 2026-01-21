namespace GitHubActionsLab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = CreateApp(args);
            app.Run();
        }

        public static WebApplication CreateApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapGet("/hello", () => "Hello, world!")
                .WithName("Hello")
                .WithOpenApi();

            return app;
        }
    }
}