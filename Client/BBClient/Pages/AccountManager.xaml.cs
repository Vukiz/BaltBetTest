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
using BBClient.BetServiceRef;

namespace BBClient.Pages
{
    /// <summary>
    /// Interaction logic for AccountManager.xaml
    /// </summary>
    public partial class AccountManager : Page
    {
        private Account account;
        public AccountManager(Account currAccount)
        {
            InitializeComponent();
            account = currAccount;
            UpdateAccountInfo();
        }

        private void UpdateAccountInfo()
        {

            var client = new BetServiceClient();
            account = client.GetAccount(account.Code);
            client.Close();
            accountAmountTB.Text = account.Amount.ToString();
            accountCodeTB.Text = account.Code.ToString();
            accountFIOTB.Text = account.FIO;
        }

        private void listUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            var client = new BetServiceClient();
            foreach (var ev in client.GetEvents())
            {
                EventsListView.Items.Add(new {ev.Factor, ev.Name });
                
            }
            client.Close();
        }
        private void refillBtn_Click(object sender, RoutedEventArgs e)
        {
            //payment script should be called here
            var client = new BetServiceClient();
            var amount = int.Parse(refillTB.Text);
            if (client.AccountRefill(account.Code, amount))
            {
                account.Amount += amount;
                accountAmountTB.Text = account.Amount.ToString();
                amountStatus.Text = "Success";
            }
            else
            {
                amountStatus.Text = "Account cannot be refilled";
            }
            client.Close();
        }

        private void withdrawBtn_Click(object sender, RoutedEventArgs e)
        {
            var client = new BetServiceClient();
            var amount = int.Parse(withdrawTB.Text);
            if (client.AccountWithdraw(account.Code, amount))
            {
                account.Amount -= amount;
                accountAmountTB.Text = account.Amount.ToString();
                amountStatus.Text = "Success";
            }
            else
            {
                amountStatus.Text = "Cannot withdraw from account";
            }
            client.Close();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateAccountInfo();
        }
        
    }
}
