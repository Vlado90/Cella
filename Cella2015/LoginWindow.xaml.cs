using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Cella.Model;
using Cella2015.Helpers;

namespace Cella2015
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Elysium.Controls.Window
    {
        private bool isErrorLogVisible = false;

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            if (ValidateEmptyLogin())
            {
                if (ValidateLoginInfo())
                {
                    mainWindow.Show();
                    mainWindow.txtActiveUserName.Text = App.activeEmployee.Name + " " + App.activeEmployee.Surname;
                    this.Close();
                }
            }
        }

        public void Connect(int connectionId, object target)
        {
        }

        #region Validation
        public CellaValidationMessage Validate()
        {
            var result = new CellaValidationMessage();

            if (String.IsNullOrEmpty(txtLoginName.Text))
            {
                result.IsValid = false;
                result.Message = "Login can not be empty!";
                return result;
            }
            if (String.IsNullOrEmpty(txtLoginPassword.Password))
            {
                result.IsValid = false;
                result.Message = "Password can not be empty!";
                return result;
            }

            return result;
        }

        public bool ValidateEmptyLogin()
        {
            bool result = true;
            if ((String.IsNullOrEmpty(txtLoginName.Text)) && (String.IsNullOrEmpty(txtLoginPassword.Password)))
            {
                txtLoginName.BorderBrush = new SolidColorBrush(Colors.Red);
                txtLoginPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                ShowErrorLog("Enter login and password");

                return false;
            }

            if (String.IsNullOrEmpty(txtLoginName.Text))
            {
                result = false;
                txtLoginName.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            if (String.IsNullOrEmpty(txtLoginPassword.Password))
            {
                result = false;
                txtLoginPassword.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            return result;
        }

        public bool ValidateLoginInfo()
        {
            bool result = false;
            string login = txtLoginName.Text;

            CellaDbDataContext db = new CellaDbDataContext();
            var employee = new Employee();
            employee = (from e in db.Employees where e.Login == login select e).FirstOrDefault();
            if (employee != null)
            {
                if (MainWindow.ValidatePassword(txtLoginPassword.Password, employee.Hash))
                {
                    App.activeEmployee = employee;
                    return true;
                }
            }
            else
            {
                txtLoginName.BorderBrush = new SolidColorBrush(Colors.Black);
                ShowErrorLog("Login does not exist!");
                return false;
            }

            return result;
        }

        public void ShowErrorLog(string message)
        {
            if (!isErrorLogVisible)
            {
                this.Height = ActualHeight + 30;
                txbErrorLog.Visibility = Visibility.Visible;
                isErrorLogVisible = true;
            }
            txbErrorLog.Text = message;
        }

        public void HideErrorLog()
        {
            txbErrorLog.Visibility = Visibility.Collapsed;
            isErrorLogVisible = false;
        }   
        #endregion

        #region BooleanOrConverter

        //public class BooleanOrConverter : IMultiValueConverter
        //{
        //    public object Conver(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //    {
        //        foreach (object value in values)
        //        {
        //            if ((bool) value == true)
        //            {
        //                return true;
        //            }
        //        }
        //        return false;
        //    }

        //    public object[] ConvertBack(object value, Type[] taretTypes, object parameter, System.Globalization.CultureInfo culture)
        //    {
        //        throw new NotSupportedException();
        //    }

        //}
        #endregion

       // public static readonly DependencyProperty 

        private void TxtLoginName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            txtLoginName.BorderBrush = new SolidColorBrush(Colors.Black);
        }

        private void TxtLoginPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            txtLoginPassword.BorderBrush = new SolidColorBrush(Colors.Black);
        }
    }
}
