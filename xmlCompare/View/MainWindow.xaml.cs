using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Unity;
using CompareDef;
using xmlCompare.ViewModel;

namespace xmlCompare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // podle stackoverflow
        [Dependency]
        public ShellVM vm { set { DataContext = value; } }

        public MainWindow()
        {
            InitializeComponent();
        }


        // moje tvorba
        //public ShellVM vm { get; }

        //public MainWindow(ICompareDefinition compareDefinition)
        //{
        //    InitializeComponent();

        //    vm = new ShellVM(compareDefinition);

        //    this.DataContext = vm;
        //}
    }
}
