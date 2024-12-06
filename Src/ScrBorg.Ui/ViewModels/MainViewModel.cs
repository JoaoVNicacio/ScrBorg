using ScrBorg.Application.Services;

namespace ScrBorg.Ui.ViewModels;

public class MainViewModel : ReactiveObject
{
    public MainViewModel(IAndroidScreenMirrorService scrcpyService)
    {
        _scrcpyService = scrcpyService;

        _scrcpyService.OutputReceived += OnOutputReceived;
        _scrcpyService.ErrorReceived += OnErrorReceived;

        StartCommand = ReactiveCommand.Create(StartMirroring);
        StopCommand = ReactiveCommand.Create(StopMirroring);
    }

    #region Fields
    private readonly IAndroidScreenMirrorService _scrcpyService;
    private bool _isRunning;
    #endregion

    #region Properties
    public ObservableCollection<string> TerminalOutput { get; } = [];

    public bool IsRunning
    {
        get => _isRunning;
        set => this.RaiseAndSetIfChanged(ref _isRunning, value);
    }
    #endregion

    #region InterfaceEvents
    public ReactiveCommand<Unit, Unit> StartCommand { get; }
    public ReactiveCommand<Unit, Unit> StopCommand { get; }

    private void StartMirroring()
    {
        _scrcpyService.StartMirroring();
        IsRunning = true;
    }

    private void StopMirroring()
    {
        _scrcpyService.StopMirroring();
        IsRunning = false;
    }

    private void OnOutputReceived(string message) => TerminalOutput.Add($"OUTPUT: {message}");

    private void OnErrorReceived(string message) => TerminalOutput.Add($"ERROR: {message}");
    #endregion
}