using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using ScrBorg.Ui.DependencyInjection;

namespace ScrBorg.Ui;

class Program
{
    public static ServiceProvider AppServiceProvider = new ServiceCollection()
        .RegisterServices()
        .BuildServiceProvider();

    public static void Main(string[] args)
    {
        BuildAvaloniaApp().UseReactiveUI()
                          .StartWithClassicDesktopLifetime(
                                args,
                                shutdownMode: ShutdownMode.OnMainWindowClose);
    }

    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>()
                         .UsePlatformDetect()
                         .LogToTrace()
                         .UseReactiveUI()
                         .UseSkia();
    }
}
