using System.Diagnostics;

namespace ScrBorg.Core.ScreenMirror;

public interface IScreenMirroringResolver
{
    Process GetScreenMirroringProcess(
        EStartArgs startType = EStartArgs.USB,
        uint displayId = 0,
        string? deviceIpAddress = DEFAULT_IP);

    Process GetWirelessConfiguringProcess();
}
