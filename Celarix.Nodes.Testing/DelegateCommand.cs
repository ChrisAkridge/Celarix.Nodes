using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Celarix.Nodes.Testing
{
    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> _action;
        private readonly Func<T, bool>? _condition;

        public event EventHandler? CanExecuteChanged;

        public DelegateCommand(Action<T> action, Func<T, bool>? condition = null)
        {
            _action = action;
            _condition = condition;
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter is T value)
            {
                return _condition?.Invoke(value) ?? true;
            }

            return _condition?.Invoke(default!) ?? true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is T value)
            {
                _action(value);
            }
            else
            {
                _action(default!);
            }
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, new EventArgs());
    }
}
