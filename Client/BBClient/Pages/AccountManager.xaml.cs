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
            EventsListView.Items.Clear();
            foreach (var ev in client.GetEvents())
            {
                EventsListView.Items.Add(new Event { Factor = ev.Factor, Name = ev.Name });
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

        private void SimpleBet_Click(object sender, RoutedEventArgs e)
        {
            var client = new BetServiceClient();
            if (EventsListView.SelectedItem == null) BetStatus.Content = "Select event to play with";
            var item = (Event)EventsListView.SelectedItem;

            var results = new Event
            {
                Factor = item.Factor,
                Name = item.Name
            };
            int betAmount;
            if (!int.TryParse(BetTextBox.Text, out betAmount))
            {
                BetStatus.Content = "Wrong bet";
            }
            else
            {
                if (betAmount > account.Amount) BetStatus.Content = "Not Enough money";
                client.AccountWithdraw(account.Code, betAmount);
                client.MakeBet(account.Code, betAmount, BetType.Simple, new[] { results });
                BetStatus.Content = "Bet Success";
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

        private void BetUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            var client = new BetServiceClient();
            if (!string.IsNullOrEmpty(betCodeTB.Text))
            {

            }
            else
            {
               /* var bets = client.GetBets(account.Code);
                BetsListView.Items.Clear();
                foreach (var bet in bets)
                {
                    BetsListView.Items.Add(bet);
                }*/
            }
        }
    }
}
