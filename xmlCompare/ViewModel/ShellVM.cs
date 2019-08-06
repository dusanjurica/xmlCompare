using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace xmlCompare.ViewModel
{
    public class ShellVM
    {
        #region LoadFilesCommand
        private ICommand _loadFilesCommand;

        public ICommand LoadFilesCommand
        {
            get
            {
                return _loadFilesCommand ??
                  new CreatorOfCommands(LoadFilesAction, true);
            }
        }
        #endregion
        #region CompareCommand
        private ICommand _compareCommand;

        public ICommand CompareCommand
        {
            get
            {
                return _compareCommand ??
                  new CreatorOfCommands(CompareAction, true);
            }
        }
        #endregion

        public ObservableCollection<string> differences { get; set; } = new ObservableCollection<string>();

        public ShellVM()
        {
        }

        void LoadFilesAction()
        {
            Console.WriteLine("Loading files");
        }

        void CompareAction()
        {
            Console.WriteLine("Comparing files");

            differences.Add("diff");
        }
    }
}
