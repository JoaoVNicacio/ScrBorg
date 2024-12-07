using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using ScrBorg.Ui.DependencyInjection;

namespace ScrBorg.Ui;

class Program
{
    public static ServiceProvider AppServiceProvider = new ServiceCollection()
        .RegisterServices()
        .BuildServiceProvider();

    static void Main(string[] args)
        => BuildAvaloniaApp().UseReactiveUI()
                             .StartWithClassicDesktopLifetime(
                                args,
                                shutdownMode: ShutdownMode.OnMainWindowClose);

    static AppBuilder BuildAvaloniaApp() => AppBuilder.Configure<App>()
                                                      .UsePlatformDetect()
                                                      .LogToTrace()
                                                      .UseReactiveUI()
                                                      .UseSkia();
}
