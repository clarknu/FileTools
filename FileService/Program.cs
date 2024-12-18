namespace FileService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        _ = builder.Services.AddHostedService<Worker>();

        var host = builder.Build();
        host.Run();
    }
}