using System;
using System.Windows.Input;

namespace TechHealth.DoctorView.Command
{
    public class RelayCommand:ICommand
    {
        readonly Action<object> _execute;
        private readonly Predicate<object> _predicate;

        public RelayCommand(Action<object> execute, Predicate<object> predicate)
        {
            _execute = execute;
            _predicate = predicate;
        }

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public bool CanExecute(object parameters)
        {
            return _predicate == null ? true : _predicate(parameters);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameters)
        {
            _execute.Invoke(parameters);
        }
    }
}