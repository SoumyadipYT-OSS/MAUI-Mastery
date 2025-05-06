using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;

namespace _01_MVVM_structure.ViewModels;

class ClockViewModel : INotifyPropertyChanged 
{
    private DateTime _dateTime;
    private readonly System.Threading.Timer? _timer;

    // Property to bind to the view
    public DateTime DateTimeBindView {
        get => _dateTime;
        set {
            if ((_dateTime != value)) {
                _dateTime = value;
                OnPropertyChanged();
            }
        }
    }

    // Constructor
    public ClockViewModel() {
        this.DateTimeBindView = DateTime.Now;

        // Set up a timer to update the DateTimeBindView property every second
        _timer = new System.Threading.Timer(new TimerCallback((s) => this.DateTimeBindView = DateTime.Now),
                                            null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
    }

    // Destructor to clean up the timer for memory management
    ~ClockViewModel() =>
        _timer!.Dispose();


    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
