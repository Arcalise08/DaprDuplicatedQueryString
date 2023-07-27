namespace DaprProblem.Two;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var service = builder.Services;
        service.AddMvc().AddDapr();
        var app = builder.Build();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        app.Run();
    }
}
