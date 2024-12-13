using ScrBorg.Core.Pipes;

namespace ScrBorg.Infra.Pipes;

public class ScreenMirrorArgsPipe : IScreenMirrorArgsPipe
{
    #region Constants
    private const string TCP_IP_CONFIG_PARAM = "--tcp-ip";
    private const string TCP_IP_PARAM = "-s";
    private const string USB_PARAM = "-d";
    private const string DISPLAY_PARAM = "-display";
    #endregion

    public string GetStartArg(
        EStartArgs startType = EStartArgs.USB,
        uint displayId = 0,
        string? deviceIpAddress = DEFAULT_IP)
    => $"{DefineStartTypeParam(startType, deviceIpAddress)} {DISPLAY_PARAM}={displayId}";

    public string GetWirelessConfigArg() => TCP_IP_CONFIG_PARAM;

    private static string DefineStartTypeParam(EStartArgs startType, string? deviceIpAddress)
        => startType switch
        {
            EStartArgs.USB => USB_PARAM,
            EStartArgs.Wireless => $"{TCP_IP_PARAM} {deviceIpAddress}",
            _ => USB_PARAM
        };
}
