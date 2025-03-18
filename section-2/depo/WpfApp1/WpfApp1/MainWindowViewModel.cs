using System;
using System.ComponentModel;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Person _person;
        public Person Person
        {
            get { return _person; }
            set
            {
                if (_person != value)
                {
                    _person = value;
                    OnPropertyChanged(nameof(Person));
                    OnPropertyChanged(nameof(PersonName));
                }
            }
        }

        public string PersonName
        {
            get { return Person.Name; }
            set
            {
                if (Person.Name != value)
                {
                    Person.Name = value;
                    OnPropertyChanged(nameof(PersonName));
                }
            }
        }

        public ICommand ChangeNameCommand { get; }

        public MainWindowViewModel()
        {
            Person = new Person
            {
              Name = "Kimura"
            };

            ChangeNameCommand = new RelayCommand(ChangeName);
        }

        private void ChangeName()
        {
            PersonName = "Koga";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

  public class RelayCommand : ICommand
  {
    private readonly Action _execute;
    private readonly Func<bool> _canExecute;

    public RelayCommand(Action execute, Func<bool> canExecute = null)
    {
      _execute = execute ?? throw new ArgumentNullException(nameof(execute));
      _canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
      return _canExecute == null || _canExecute();
    }

    public void Execute(object parameter)
    {
      _execute();
    }

    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }
  }
}
