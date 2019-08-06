using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace xmlCompare.ViewModel
{
    public class CreatorOfCommands : ICommand
    {
        Action _execute;
        bool _canExecute;

        public event EventHandler CanExecuteChanged;

        public CreatorOfCommands(Action execute, bool canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this._canExecute;
        }

        public void Execute(object parameter)
        {
            this._execute();
        }
    }
}
