using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DirectoryFileBrowser.Tools
{
    public class BindingCommand<T> : ICommand
    {
        #region Fields
        readonly Action<T> _execute;
        readonly Predicate<T> _canExecute;

        public event EventHandler CanExecuteChanged;
        #endregion

        public BindingCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute != null)
                _execute = execute;
            else
                throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
