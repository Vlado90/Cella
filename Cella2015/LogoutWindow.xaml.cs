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
using System.Windows.Shapes;

namespace Cella2015
{
    /// <summary>
    /// Interaction logic for LogoutWindow.xaml
    /// </summary>
    public partial class LogoutWindow : Elysium.Controls.Window
    {
        public LogoutWindow()
        {
            InitializeComponent();
        }

        private void BtnLogoutCancel_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnLogoutSubmit_OnClick(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            App.appMainWindow.Close();
            this.Close();
        }

        private void BtnLogoutExit_OnClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        public void Connect(int connectionId, object target)
        {
        }
    }
}
