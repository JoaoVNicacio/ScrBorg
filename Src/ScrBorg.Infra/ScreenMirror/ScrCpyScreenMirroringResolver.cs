using System.Diagnostics;

using ScrBorg.Core.Pipes;
using ScrBorg.Core.ScreenMirror;

namespace ScrBorg.Infra.ScreenMirror;

public class ScrCpyScreenMirroringResolver(
    IScreenMirrorArgsPipe screenMirrorArgsPipes) : IScreenMirroringResolver
{
    private readonly IScreenMirrorArgsPipe _screenMirrorArgsPipes = screenMirrorArgsPipes;

    public Process GetScreenMirroringProcess(
        EStartArgs startType = EStartArgs.USB,
        uint displayId = 0,
        string? deviceIpAddress = DEFAULT_IP)
    {
        return new()
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "scrcpy",
                Arguments = _screenMirrorArgsPipes.GetStartArg(
                    startType,
                    displayId,
                    deviceIpAddress),
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        };
    }

    public Process GetWirelessConfiguringProcess()
    {
        return new()
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "scrcpy",
                Arguments = "--tcpip",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        };
    }
}
