using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Cella.Model;

namespace Cella2015
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static LoginWindow loginWindow = new LoginWindow();
        public static MainWindow appMainWindow = new MainWindow();
        public static Employee activeEmployee = new Employee();

        private void App_StartUp(Object sender, StartupEventArgs e)
        {
            loginWindow.Show();
        }
    }
}
