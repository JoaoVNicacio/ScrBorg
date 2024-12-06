using Microsoft.Extensions.DependencyInjection;
using ScrBorg.Application.Services;
using ScrBorg.Ui.ViewModels;

namespace ScrBorg.Ui.DependencyInjection;

internal static class DependencyInjectionExtensions
{
    internal static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        // Registre o serviço da interface IAndroidScreenMirrorService
        services.AddSingleton<IAndroidScreenMirrorService, AndroidScreenMirrorService>();

        // Adicione os outros serviços
        services.AddTransient<MainViewModel>();
        services.AddTransient<MainWindow>();

        return services;
    }
}
