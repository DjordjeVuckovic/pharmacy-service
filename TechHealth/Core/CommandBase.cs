using System;
using System.Windows.Input;

namespace TechHealth.Core
{
    public  class CommandBase:ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;
        
        public CommandBase(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public CommandBase(Action<object> execute) : this(execute, null) { }
        public bool CanExecute(object parameters)
        {
            return _canExecute == null ||  _canExecute(parameters);
        }

        public void Execute(object parameters)
        {
            _execute(parameters);
        }

        public event EventHandler CanExecuteChanged;

        public void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this,EventArgs.Empty);
        }
    }
}