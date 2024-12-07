using Microsoft.Extensions.DependencyInjection;
using ScrBorg.Application.Services;
using ScrBorg.Core.ScreenMirror;
using ScrBorg.Infra.ScreenMirror;
using ScrBorg.Ui.ViewModels;
using ScrBorg.Ui.Windows;

namespace ScrBorg.Ui.DependencyInjection;

internal static class DependencyInjectionExtensions
{
    internal static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<IScreenMirroringResolver, ScrCpyScreenMirroringResolver>();
        services.AddSingleton<IAndroidScreenMirrorService, AndroidScreenMirrorService>();

        services.AddTransient<MainViewModel>();
        services.AddTransient<MainWindow>();

        return services;
    }
}
