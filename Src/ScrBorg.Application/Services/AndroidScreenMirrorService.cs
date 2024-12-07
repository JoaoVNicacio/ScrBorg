using System.Diagnostics;
using ScrBorg.Core.ScreenMirror;

namespace ScrBorg.Application.Services;

public class AndroidScreenMirrorService(
    IScreenMirroringResolver screenMirroringResolver) : IAndroidScreenMirrorService
{
    #region Constants
    private const string ALREADY_RUNNING_ERROR_MESSAGE = "The screen mirroring is already running.";
    #endregion

    #region PropertiesAndCompositions
    private Process? _process;
    private readonly IScreenMirroringResolver _screenMirroringResolver = screenMirroringResolver;
    #endregion

    #region Events
    public event Action<string>? OutputReceived;
    public event Action<string>? ErrorReceived;
    #endregion

    #region PublicMethods
    public void StartMirroring(string arguments = "")
    {
        if (_process is not null and { HasExited: !true })
            throw new InvalidOperationException(ALREADY_RUNNING_ERROR_MESSAGE);

        _process = _screenMirroringResolver.GetScreenMirroringProcess(arguments);

        _process.OutputDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrWhiteSpace(e.Data))
                OutputReceived?.Invoke(e.Data);
        };

        _process.ErrorDataReceived += (sender, e) =>
        {
            if (!string.IsNullOrWhiteSpace(e.Data))
                ErrorReceived?.Invoke(e.Data);
        };

        _process.Start();
        _process.BeginOutputReadLine();
        _process.BeginErrorReadLine();
    }

    public void StopMirroring()
    {
        if (_process is not null and { HasExited: !true })
        {
            _process.Kill();
            _process.Dispose();
            _process = null;
        }
    }
    #endregion
}
