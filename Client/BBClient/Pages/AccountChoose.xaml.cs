using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using BBClient.BetServiceRef;

namespace BBClient.Pages
{
    /// <summary>
    /// Interaction logic for AccountChoose.xaml
    /// </summary>
    public partial class AccountChoose : Page
    {
        public AccountChoose()
        {
            InitializeComponent();
            loginStatus.Text = "";
        }
        private static bool IsDigit(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;
            var regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            loginBtn.IsEnabled = false;
            if (IsDigit(accCodeTB.Text))
            {
                loginStatus.Text = "";
                var client = new BetServiceClient();
                try
                {
                    var acc = client.GetAccount(int.Parse(accCodeTB.Text));
                    if (acc.Code == 0) loginStatus.Text = "Where is no such account.";
                    else
                    {
                        loginStatus.Text = "Successfull login";
                        NavigationService?.Navigate(new AccountManager(acc));
                    }
                }
                finally
                {
                    client.Close();
                }
            }
            else
            {
                loginStatus.Text = "Incorrect code";
            }
            loginBtn.IsEnabled = true;
        }

        private void accountCreateBtn_Click(object sender, RoutedEventArgs e)
        {
            accountCreateBtn.IsEnabled = false;

            if (string.IsNullOrEmpty(accNameTB.Text) || string.IsNullOrEmpty(accSurnameTB.Text) ||
                string.IsNullOrEmpty(accLastNameTB.Text))
            {
                accountCreationToolTip.Text = "Name, Surname or Lastname cannot be incorrect or empty";
            }
            else
            {
                var client = new BetServiceClient();
                try
                {
                    var acc = client.CreateAccount(accNameTB.Text + " " + accSurnameTB.Text + " " + accLastNameTB.Text);
                    if (acc.Code > 0)
                    {
                        accountCreationToolTip.Text = "Account creation succeed";
                        NavigationService?.Navigate(new AccountManager(acc));
                    }
                }
                finally
                {
                    client.Close();
                }
            }
            accountCreateBtn.IsEnabled = true;
        }

    }
}
