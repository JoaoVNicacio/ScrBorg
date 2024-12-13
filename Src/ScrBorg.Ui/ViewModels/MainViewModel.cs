using System;
using ScrBorg.Application.Services;

namespace ScrBorg.Ui.ViewModels;

public class MainViewModel : ReactiveObject
{
    public MainViewModel(IAndroidScreenMirrorService scrcpyService)
    {
        _screenMirroringService = scrcpyService;

        _screenMirroringService.OutputReceived += OnOutputReceived;
        _screenMirroringService.ErrorReceived += OnErrorReceived;

        StartCommand = ReactiveCommand.Create(StartMirroring);
        StopCommand = ReactiveCommand.Create(StopMirroring);
        ConfigureWirelessCommand = ReactiveCommand.Create(ConfigureWireless);
    }

    #region Fields
    private readonly IAndroidScreenMirrorService _screenMirroringService;
    private bool _isRunning;
    private bool _useTcpIp;
    private uint _displayId;
    #endregion

    #region Properties
    public ObservableCollection<string> TerminalOutput { get; } = [];

    public bool IsRunning
    {
        get => _isRunning;
        set => this.RaiseAndSetIfChanged(ref _isRunning, value);
    }

    public bool ShouldUseTcpIp
    {
        get => _useTcpIp;
        set => this.RaiseAndSetIfChanged(ref _useTcpIp, value);
    }

    public uint DisplayId
    {
        get => _displayId;
        set => this.RaiseAndSetIfChanged(ref _displayId, (uint)value);
    }
    #endregion

    #region InterfaceEvents
    public ReactiveCommand<Unit, Unit> StartCommand { get; }
    public ReactiveCommand<Unit, Unit> StopCommand { get; }
    public ReactiveCommand<Unit, Unit> ConfigureWirelessCommand { get; }

    private void StartMirroring()
    {
        _screenMirroringService.StartMirroring(
            _useTcpIp ? EStartArgs.Wireless : EStartArgs.USB,
            _displayId
        );

        IsRunning = true;
    }

    private void StopMirroring()
    {
        _screenMirroringService.StopMirroring();
        IsRunning = false;
    }

    private void ConfigureWireless() => _screenMirroringService.ConfigureWireless();

    private void OnOutputReceived(string message) => TerminalOutput.Add($"OUTPUT: {message}");

    private void OnErrorReceived(string message) => TerminalOutput.Add($"ERROR: {message}");
    #endregion
}
