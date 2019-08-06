using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using CompareDef;
using CompareLib;

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

        private ICompareDefinition _comparer;

        private List<string> _lines1 = new List<string>();
        private List<string> _lines2 = new List<string>();

        public ObservableCollection<string> differences { get; set; } = new ObservableCollection<string>();

        //public ShellVM()
        //{
        //    _comparer = new DusanCompareDefinition();
        //}

        public ShellVM(ICompareDefinition comparer)
        {
            this._comparer = comparer;
        }

        void LoadFilesAction()
        {
            Console.WriteLine("Loading files");
        }

        void CompareAction()
        {
            Console.WriteLine("Comparing files");

            foreach (var item in _comparer.Compare(_lines1, _lines2))
            {
                differences.Add(item);
            }
        }
    }
}
