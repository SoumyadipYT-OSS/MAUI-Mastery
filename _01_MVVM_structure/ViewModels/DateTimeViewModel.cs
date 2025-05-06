using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace _01_MVVM_structure.ViewModels {
    public class DateTimeViewModel : INotifyPropertyChanged {
        private DateTime _currentDateTime;
        private DateTime _adjustedDateTime;
        private int _daysDifference;

        public DateTime CurrentDateTime {
            get => _currentDateTime;
            set {
                if (_currentDateTime != value) {
                    _currentDateTime = value;
                    OnPropertyChanged();
                    // My Calculate day difference method goes here
                    CalculateDaysDifference();
                }
            }
        }

        public DateTime AdjustedDateTime {
            get => _adjustedDateTime;
            set {
                if (_adjustedDateTime != value) {
                    _adjustedDateTime = value;
                    OnPropertyChanged();
                    CalculateDaysDifference();
                }
            }
        }


        public int DaysDifference {
            get => _daysDifference;
            set {
                if (_daysDifference != value) {
                    _daysDifference = value;
                    OnPropertyChanged();
                }
            }
        }



        public ICommand? RefreshTimeCommand { get; }
        public ICommand? AddDaysCommand { get; }

        public DateTimeViewModel() {
            // Initialize with current date and time
            CurrentDateTime = DateTime.Now;
            AdjustedDateTime = CurrentDateTime;

            // Initialize commands
            RefreshTimeCommand = new Command(RefreshTime);
            AddDaysCommand = new Command<string>(AddDays);
        }


        private void RefreshTime() {
            CurrentDateTime = DateTime.Now;
        }

        private void AddDays(string daysString) {
            if (int.TryParse(daysString, out int days)) {
                AdjustedDateTime = AdjustedDateTime.AddDays(days);
            }
        }

        private void CalculateDaysDifference() {
            DaysDifference = (AdjustedDateTime - CurrentDateTime).Days;
        }



        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
