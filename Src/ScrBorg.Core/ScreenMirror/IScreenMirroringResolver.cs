using System.Diagnostics;

namespace ScrBorg.Core.ScreenMirror;

public interface IScreenMirroringResolver
{
    Process GetScreenMirroringProcess(string arguments = "");
}
