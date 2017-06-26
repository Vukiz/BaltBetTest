using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BBClient.BetServiceRef;

namespace BBClient.Pages
{
    /// <summary>
    /// Interaction logic for AccountManager.xaml
    /// </summary>
    public partial class AccountManager : Page
    {
        private Account account;
        public AccountManager(int accCode)
        {
            InitializeComponent();
            UpdateAccountInfo(accCode);
        }

        private void UpdateAccountInfo(int code)
        {
            var client = new BetServiceClient();
            try
            {
                client.Open();
                account = client.GetAccount(code);
                client.Close();
                accountAmountTB.Text = account.Amount.ToString();
                accountCodeTB.Text = account.Code.ToString();
                accountFIOTB.Text = account.FIO;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection problem");
            }
            finally
            {
                client.Close();
            }
        }

        private void ListUpdateBtnClick(object sender, RoutedEventArgs e)
        {
            var client = new BetServiceClient();
            try
            {
                client.Open();
                var events = client.GetEvents();
                EventsListView.Items.Clear();
                foreach (var ev in events)
                {
                    EventsListView.Items.Add(ev);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection problem");
            }
            finally
            {
                client.Close();
            }
        }

        private void RefillBtnClick(object sender, RoutedEventArgs e)
        {
            //payment script should be called here
            var client = new BetServiceClient();
            try
            {
                client.Open();
                int amount;
                if (int.TryParse(refillTB.Text, out amount) && client.AccountRefill(account.Code, amount))
                {
                    account.Amount += amount;
                    accountAmountTB.Text = account.Amount.ToString();
                    MessageBox.Show($"Succesfully refilled account by {amount}");
                    refillTB.Text = "";
                }
                else
                {
                    MessageBox.Show($"Account cannot be refilled by {amount}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection problem");
            }
            finally
            {
                client.Close();
            }
        }

        private void SimpleBetClick(object sender, RoutedEventArgs e)
        {
            if (EventsListView.SelectedItem == null)
            {
                MessageBox.Show("You should select event form the list");
            }
            else
            {
                var item = (Event)EventsListView.SelectedItem;
                var results = new Event
                {
                    Factor = item.Factor,
                    Name = item.Name
                };
                int betAmount;
                if (!int.TryParse(BetTextBox.Text, out betAmount))
                {
                    MessageBox.Show("Wrong bet");
                }
                else
                {
                    if (betAmount > account.Amount)
                    {
                        MessageBox.Show("Not enough money");
                    }
                    else
                    {
                        var client = new BetServiceClient();
                        try
                        {
                            client.Open();
                            client.AccountWithdraw(account.Code, betAmount);
                            client.MakeBet(account.Code, betAmount, BetType.Simple, new[] { results });
                            MessageBox.Show("Bet success");
                            BetTextBox.Text = "";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Connection problem");
                        }
                        finally
                        {
                            client.Close();
                        }
                    }
                }
            }
        }

        private void WithdrawBtnClick(object sender, RoutedEventArgs e)
        {
            var client = new BetServiceClient();
            try
            {
                client.Open();
                int amount;
                if (int.TryParse(withdrawTB.Text, out amount) && client.AccountWithdraw(account.Code, amount))
                {
                    account.Amount -= amount;
                    accountAmountTB.Text = account.Amount.ToString();

                    MessageBox.Show($"Succesfully withdrew  {amount}");
                    withdrawTB.Text = "";
                }
                else
                {

                    MessageBox.Show($"Cannot withdrew {amount}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection problem");
            }
            finally
            {
                client.Close();
            }
        }

        private void UpdateBtnClick(object sender, RoutedEventArgs e)
        {
            UpdateAccountInfo(account.Code);
        }

        private void BetUpdateBtnClick(object sender, RoutedEventArgs e)
        {
            var client = new BetServiceClient();
            try
            {
                client.Open();
                if (!string.IsNullOrEmpty(betCodeTB.Text))
                {
                    int betCode;
                    if (int.TryParse(betCodeTB.Text, out betCode))
                    {
                        var bet = client.GetBet(betCode);
                        BetsListView.Items.Clear();
                        BetsListView.Items.Add(bet);
                    }
                }
                else
                {
                    var bets = client.GetBets(account.Code);
                    BetsListView.Items.Clear();
                    foreach (var bet in bets)
                    {
                        BetsListView.Items.Add(bet);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection problem");
            }
            finally
            {
                client.Close();
            }
        }

        private void EventAddBtnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(EventFactorTB.Text) || string.IsNullOrEmpty(EventNameTB.Text)) return;
            decimal factor;

            if (decimal.TryParse(EventFactorTB.Text, out factor))
            {
                var client = new BetServiceClient();
                try
                {
                    client.Open();
                    client.AddEvent(EventNameTB.Text, factor);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection problem");
                }
                finally
                {
                    client.Close();
                }
            }
            EventFactorTB.Text = "";
            EventNameTB.Text = "";
            ListUpdateBtnClick(sender, e);
        }
    }
}
