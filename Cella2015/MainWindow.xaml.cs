using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Security.Cryptography;
using Cella.Model;
using Cella2015.Helpers;

namespace Cella2015
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Elysium.Controls.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //txtActiveUserName.Text = App.activeEmployee.Name + " " + App.activeEmployee.Surname;
            TabCtrlMain.SelectionChanged += ShowHomeIcon;
        }

        #region private properties and helper methods
        private Dictionary<string, string> categoriesDictionary = new Dictionary<string, string>
        {
            {"Dry Cement Mixtures", "dryCementMixtures"},
            {"Elektricity", "elektricity"},
            {"Plumbing", "plumbing"},
            {"Tools", "tools"}
        };

        private Dictionary<string, string> genderDictionary = new Dictionary<string, string>
        {
            {"Female", "F"},
            {"Male", "M"}
        };

        public List<Employee> cellaEmployees = new List<Employee>();

        public List<EmployeeGridLine> GetEmployeeGridData()
        {
            using (Cella.Model.CellaDbDataContext dbContext = new CellaDbDataContext())
            {
                var list = new List<EmployeeGridLine>();
                var employees = dbContext.Employees.ToList();

                foreach (Employee e in employees)
                {
                    string name = e.Name + " " + e.Surname;
                    string address = e.Street + " " + e.Number + ", " + e.City;
                    var listObject = new EmployeeGridLine() { Id = e.EmployeeId.ToString(), Name = name, Address = address, BirthDate = e.BirthDate };
                    list.Add(listObject);
                }
                return list;
            }
        }

        public Dictionary<string, string> GetCategoriesDictionary
        {
            get
            {
                return categoriesDictionary;
            }
        }
        public Dictionary<string, string> GetGenderDictionary
        {
            get
            {
                return genderDictionary;
            }
        }

        #region EmployeeGridLine class
        public class EmployeeGridLine
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string BirthDate { get; set; }
        }
        #endregion

        #region Validator class
        protected class Validator
        {
            public bool isValid;
            public string validationMessage;

            public Validator()
            {
            }

            public Validator(bool valid, string message)
            {
                isValid = valid;
                validationMessage = message;
            }
        }
        #endregion
        #endregion

        #region Login/Logout Methods
        private void ImgLogout_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            App.appMainWindow = this;
            LogoutWindow logoutWindow = new LogoutWindow();
            logoutWindow.Show();
        }
        #endregion

        #region TabControl Helpers
        private void ShowHomeIcon(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            if (TabCtrlMain.SelectedIndex != 0) //Home Tab is not selected
            {
                imgHome.Visibility = Visibility.Visible;
            }
            else
            {
                imgHome.Visibility = Visibility.Collapsed;
            }
        }

        private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            TabCtrlMain.SelectedIndex = 0; //Home Tab
            imgHome.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region Item Methods
        private void BtnItemNew_OnClick(object sender, RoutedEventArgs e)
        {
            TabCtrlMain.SelectedIndex = 4;      //NewItem Tab 
        }

        private void BtnNewItemSave_OnClick(object sender, RoutedEventArgs e)
        {
            SaveNewItem();
            TabCtrlMain.SelectedIndex = 0;
        }

        private Validator VerifyNewItemForm()
        {
            if(txtNewItemName.Text == string.Empty) return new Validator(false, "");
            if (txtNewItemPlu.Text == string.Empty) return new Validator(false, "");
           
            return new Validator(true, "");
        }

        private void SaveNewItem()
        {
            //testing inputs
            //var pricePerPackage = new decimal();
            //pricePerPackage = (decimal) 2.13;

            var validator = VerifyNewItemForm();
            if (validator.isValid)
            {
                using (var cellaDb = new CellaDbDataContext())
                {
                    Item item = new Item()
                    {
                        Name = txtNewItemName.Text,
                        PLU = txtNewItemPlu.Text,
                        //Category = cmbNewItemCategory.SelectedItem.ToString(),
                        //PricePerUnit = Decimal.Parse(txtNewItemPricePerUnit.Text),
                        //PricePerPackage = pricePerPackage,
                        //UnitsPerPackage = Decimal.Parse(txtNewItemUnitsPerPackage.Text),
                        //UnitsOwned = 20,
                        //UnitsCriticalAmount = int.Parse(txtNewItemUnitsCriticalAmount.Text)
                    };
                    //if (cmbNewItemCategory.SelectedItem != "")
                    //{ item.Category = cmbNewItemCategory.SelectedItem.ToString(); }
                    //else
                    //{ item.Category = ""; }

                    cellaDb.Items.InsertOnSubmit(item);
                    cellaDb.SubmitChanges();
                }
            }
        }

        private void BtnItemImport_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        #endregion

        #region Employee Methods
        private void BtnNewEmployee_OnClick(object sender, RoutedEventArgs e)
        {
            TabCtrlMain.SelectedIndex = 6;      //NewEmployee tab
        }

        private void BtnNewEmployeeSave_OnClick(object sender, RoutedEventArgs e)
        {
            SaveNewEmployee();
            TabCtrlMain.SelectedIndex = 0;
        }

        private void BtnNewEmployeeCancel_OnClick(object sender, RoutedEventArgs e)
        {
            txtNewEmployeeName.Text = "";
            txtNewEmployeeSurname.Text = "";
            txtNewEmployeeStreet.Text = "";
            txtNewEmployeeNumber.Text = "";
            txtNewEmployeeCity.Text = "";
            txtNewEmployeePostcode.Text = "";
            cmbEmployeeGender.SelectedIndex = 0;
            txtNewEmployeeLogin.Text = "";
            pswNewEmployeePassword.Password = "";
            pswNewEmployeePasswordAgain.Password = "";
            TabCtrlMain.SelectedIndex = 3;
        }

        // EmployeeId, Name, Surname, Street, Number, City, PostCode, Gender, BirthDate, Login, Password 
        //string name, string surname, string street, string number, string city, string postcode, string gender, string birthdate, string login, string password
        private void SaveNewEmployee()
        {
            var validator = VerifyNewEmployeeForm();
            if (validator.isValid)
            {
                using (var cellaDb = new CellaDbDataContext())
                {
                    Employee employee = new Employee()
                    {
                        Name = txtNewEmployeeName.Text,
                        Surname = txtNewEmployeeSurname.Text,
                        Street = txtNewEmployeeStreet.Text,
                        Number = txtNewEmployeeNumber.Text,
                        City = txtNewEmployeeCity.Text,
                        PostCode = txtNewEmployeePostcode.Text,
                        Gender = char.Parse(cmbEmployeeGender.SelectedValue.ToString()),
                        BirthDate = calNewEmployeeBirthdate.SelectedDate.Value.ToString("dd/MM/yyyy"),
                        Login = txtNewEmployeeLogin.Text,
                        Password = pswNewEmployeePassword.Password,
                        Hash = CreateHash(pswNewEmployeePassword.Password)
                    };

                    cellaDb.Employees.InsertOnSubmit(employee);
                    cellaDb.SubmitChanges();
                }

                //clear New Employee form
                txtNewEmployeeName.Text = "";
                txtNewEmployeeSurname.Text = "";
                txtNewEmployeeStreet.Text = "";
                txtNewEmployeeNumber.Text = "";
                txtNewEmployeeCity.Text = "";
                txtNewEmployeePostcode.Text = "";
                cmbEmployeeGender.SelectedIndex = 0;
                txtNewEmployeeLogin.Text = "";
                pswNewEmployeePassword.Password = "";
                pswNewEmployeePasswordAgain.Password = "";
                TabCtrlMain.SelectedIndex = 3;
            }

        }

        private Validator VerifyNewEmployeeForm()
        {
            if (txtNewEmployeeName.Text == string.Empty ) return new Validator(false, "");
            if (txtNewEmployeeSurname.Text == string.Empty) return new Validator(false, "");
            if (txtNewEmployeeStreet.Text == string.Empty) return new Validator(false, "");
            if (txtNewEmployeeNumber.Text == string.Empty) return new Validator(false, "");
            if (txtNewEmployeeCity.Text == string.Empty) return new Validator(false, "");
            if (txtNewEmployeePostcode.Text == string.Empty) return new Validator(false, "");
            if (cmbEmployeeGender.SelectedValue.ToString() == string.Empty) return new Validator(false, "");
            if (calNewEmployeeBirthdate.SelectedDate.Value.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy")) return new Validator(false, "");
            if (txtNewEmployeeLogin.Text == string.Empty) return new Validator(false, "");
            if (pswNewEmployeePassword.Password == string.Empty) return new Validator(false, "");
            if (pswNewEmployeePasswordAgain.Password == string.Empty) return new Validator(false, "");

            if (pswNewEmployeePassword.Password != pswNewEmployeePasswordAgain.Password) return new Validator(false, "");

            return new Validator(true, "");
        }

        private void GrdEmployees_OnLoaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            var items = GetEmployeeGridData();
            grid.ItemsSource = items;
        }
        #endregion

        #region Hashing Methods

        public const int SALT_BYTE_SIZE = 24;
        public const int HASH_BYTE_SIZE = 24;
        public const int PBKDF2_ITERATIONS = 1000;
        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;

        public static string CreateHash(string password)
        {
            //generate random salt
            RNGCryptoServiceProvider cryptoService = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            cryptoService.GetBytes(salt);

            //hash the password and encode the parameters
            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
        }

        public static bool ValidatePassword(string password, string correctHash)
        {
            // Extract the parameters from the hash
            char[] delimiter = { ':' };
            string[] split = correctHash.Split(delimiter);
            int iterations = Int32.Parse(split[ITERATION_INDEX]);
            byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
            byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

            byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }

        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }

        #endregion

        public void Connect(int connectionId, object target)
        {
            throw new NotImplementedException();
        }

        
    }
}
