using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using BBClient.BetServiceRef;

namespace BBClient.Pages
{
    /// <summary>
    /// Interaction logic for AccountChoose.xaml
    /// </summary>
    public partial class AccountChoose : Page
    {
        BetServiceClient client;
        public AccountChoose()
        {
            InitializeComponent();
            client = new BetServiceClient();
            loginStatus.Text = "";
        }
        
        private void LoginBtnClick(object sender, RoutedEventArgs e)
        {
            loginBtn.IsEnabled = false;
            var accCode = -1;
            if (int.TryParse(accCodeTB.Text, out accCode))
            {
                try
                {
                    client.Open();
                    var acc = client.GetAccount(accCode);
                    if (acc.Code == 0)
                    {
                        loginStatus.Text = $"There is no account with code - {accCode}";
                    }
                    else
                    {
                        loginStatus.Text = "Succesful login";
                        NavigationService?.Navigate(new AccountManager(accCode));
                    }
                }
                catch (Exception ex)
                {
                    loginStatus.Text = "Cannot connect to server";
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

        private void AccountCreateBtnClick(object sender, RoutedEventArgs e)
        {
            accountCreateBtn.IsEnabled = false;

            if (string.IsNullOrEmpty(accNameTB.Text) || string.IsNullOrEmpty(accSurnameTB.Text) ||
                string.IsNullOrEmpty(accLastNameTB.Text))
            {
                accountCreationToolTip.Text = "Name, Surname or Lastname cannot be empty";
            }
            else
            {
                try
                {
                    client.Open();
                    var acc = client.CreateAccount($"{accNameTB.Text} {accSurnameTB.Text} {accLastNameTB.Text}");
                    if (acc.Code > 0)
                    {
                        accountCreationToolTip.Text = "Account creation succeed";
                        NavigationService?.Navigate(new AccountManager(acc.Code));
                    }
                    else
                    {
                        MessageBox.Show("Cannot create account");
                    }
                }
                catch (Exception ex)
                {
                    loginStatus.Text = "Cannot connect to server";
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
