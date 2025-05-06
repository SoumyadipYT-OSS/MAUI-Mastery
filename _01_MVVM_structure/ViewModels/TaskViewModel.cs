using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace _01_MVVM_structure.ViewModels {
    public class TaskViewModel : INotifyPropertyChanged {
        private ObservableCollection<TaskItem> _tasks;
        private string _newTaskTitle;
        private string _stats;

        public ObservableCollection<TaskItem> Tasks {
            get => _tasks;
            set {
                if (_tasks != value) {
                    _tasks = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NewTaskTitle {
            get => _newTaskTitle;
            set {
                if (_newTaskTitle != value) {
                    _newTaskTitle = value;
                    OnPropertyChanged();
                    // Enable/disable the Add command based on text availability
                    ((Command)AddTaskCommand).ChangeCanExecute();
                }
            }
        }

        public string Stats {
            get => _stats;
            set {
                if (_stats != value) {
                    _stats = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }

        public TaskViewModel() {
            _tasks = new ObservableCollection<TaskItem>();
            _newTaskTitle = string.Empty;
            _stats = string.Empty; // Initialize _stats to avoid CS8618

            // Sample data
            _tasks.Add(new TaskItem { Title = "Buy groceries", IsCompleted = false });
            _tasks.Add(new TaskItem { Title = "Finish MAUI project", IsCompleted = false });
            _tasks.Add(new TaskItem { Title = "Learn MVVM pattern", IsCompleted = true });

            // Commands
            AddTaskCommand = new Command(
                execute: AddTask,
                canExecute: () => !string.IsNullOrWhiteSpace(NewTaskTitle)
            );

            DeleteTaskCommand = new Command<TaskItem>(DeleteTask);

            UpdateStats();
        }

        private void AddTask() {
            if (!string.IsNullOrWhiteSpace(NewTaskTitle)) {
                Tasks.Add(new TaskItem { Title = NewTaskTitle, IsCompleted = false });
                NewTaskTitle = string.Empty; // Clear the entry
                UpdateStats();
            }
        }

        private void DeleteTask(TaskItem task) {
            if (Tasks.Contains(task)) {
                Tasks.Remove(task);
                UpdateStats();
            }
        }

        public void UpdateTaskStatus(TaskItem task) {
            // The IsCompleted property is already updated through binding
            // Just need to update stats and UI
            UpdateStats();
        }

        private void UpdateStats() {
            int total = Tasks.Count;
            int completed = Tasks.Count(t => t.IsCompleted);
            Stats = $"{completed} of {total} tasks completed";
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public class TaskItem : INotifyPropertyChanged {
        private string? _title;
        private bool _isCompleted;

        public string Title {
            get => _title!;
            set {
                if (_title != value) {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsCompleted {
            get => _isCompleted;
            set {
                if (_isCompleted != value) {
                    _isCompleted = value;
                    OnPropertyChanged();
                }
            }
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    // Converter to add strikethrough for completed tasks
    public class BoolToStrikethroughConverter : IValueConverter {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture) {
            if (value is bool isCompleted && isCompleted)
                return TextDecorations.Strikethrough;

            return TextDecorations.None;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
