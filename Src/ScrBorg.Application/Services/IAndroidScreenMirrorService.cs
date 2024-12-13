

namespace ScrBorg.Application.Services;

public interface IAndroidScreenMirrorService
{
    event Action<string> OutputReceived;
    event Action<string> ErrorReceived;

    /// <summary>
    /// The StartMirroring method starts a process for mirroring with specified arguments and
    /// handles output and error data received during the process.
    /// </summary>
    /// <param name="arguments">The `StartMirroring` method you provided is used to start mirroring a android screen
    /// The `arguments` parameter allows you to pass additional command-line arguments to
    /// the process when starting mirroring.</param>
    void StartMirroring(
        EStartArgs startType = EStartArgs.USB,
        uint displayId = 0,
        string? deviceIpAddress = DEFAULT_IP);

    void ConfigureWireless();

    /// <summary>
    /// The StopMirroring method checks if a process exists and has exited, then kills and disposes of the
    /// process.
    /// </summary>
    void StopMirroring();
}
