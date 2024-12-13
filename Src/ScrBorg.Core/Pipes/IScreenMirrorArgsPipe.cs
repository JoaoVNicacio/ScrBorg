namespace ScrBorg.Core.Pipes;

public interface IScreenMirrorArgsPipe
{
    string GetWirelessConfigArg();
    string GetStartArg(
        EStartArgs startType = EStartArgs.USB,
        uint displayId = 0,
        string? deviceIpAddress = DEFAULT_IP);
}
