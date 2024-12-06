using System.Diagnostics;

namespace ScrBorg.Application.Services;

public class AndroidScreenMirrorService : IAndroidScreenMirrorService
{
    private const string ALREADY_RUNNING_ERROR_MESSAGE = "The screen mirroring is already running.";
    private Process? _process;
    public event Action<string>? OutputReceived;
    public event Action<string>? ErrorReceived;

    public void StartMirroring(string arguments = "")
    {
        if (_process is not null and { HasExited: true })
            throw new InvalidOperationException(ALREADY_RUNNING_ERROR_MESSAGE);

        _process = new Process
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
        if (_process is not null and { HasExited: true })
        {
            _process.Kill();
            _process.Dispose();
            _process = null;
        }
    }
}
