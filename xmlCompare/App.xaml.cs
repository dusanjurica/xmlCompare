using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using CompareDef;
using DusanCompareLib;

namespace xmlCompare
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow mainWindow;

            using (var container = new UnityContainer())
            {
                container.RegisterType<ICompareDefinition, DusanCompareDefinition>();

                mainWindow = container.Resolve<MainWindow>();
            }

            mainWindow.Show();
        }
    }
}
