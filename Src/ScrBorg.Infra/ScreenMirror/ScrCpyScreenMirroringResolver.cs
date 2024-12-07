using System.Diagnostics;
using ScrBorg.Core.ScreenMirror;

namespace ScrBorg.Infra.ScreenMirror;

public class ScrCpyScreenMirroringResolver : IScreenMirroringResolver
{
    public Process GetScreenMirroringProcess(string arguments = "")
        => new()
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "scrcpy",
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        };
}
