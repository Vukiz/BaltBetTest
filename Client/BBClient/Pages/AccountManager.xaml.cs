using System;
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
        private BetServiceClient client;
        public AccountManager(int accCode)
        {
            InitializeComponent();
            client = new BetServiceClient();
            UpdateAccountInfo(accCode);
        }

        private void UpdateAccountInfo(int code)
        {
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
            try
            {
                client.Open();
                var events = client.GetEvents();
                EventsListView.Items.Clear();
                foreach (var ev in events)
                {
                    EventsListView.Items.Add(new Event { Factor = ev.Factor, Name = ev.Name });
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
            try
            {
                client.Open();
                int amount;
                if (int.TryParse(refillTB.Text, out amount) && client.AccountRefill(account.Code, amount))
                {
                    account.Amount += amount;
                    accountAmountTB.Text = account.Amount.ToString();
                    amountStatus.Text = "Success";
                    refillTB.Text = "";
                }
                else
                {
                    amountStatus.Text = "Account cannot be refilled";
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
                BetStatus.Content = "Select event to play with";
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
                    BetStatus.Content = "Wrong bet";
                }
                else
                {
                    if (betAmount > account.Amount)
                    {
                        BetStatus.Content = "Not Enough money";
                    }
                    else
                    {
                        try
                        {
                            client.Open();
                            client.AccountWithdraw(account.Code, betAmount);
                            client.MakeBet(account.Code, betAmount, BetType.Simple, new[] { results });
                            BetStatus.Content = "Bet Success";
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
            try
            {
                client.Open();
                int amount;
                if (int.TryParse(withdrawTB.Text, out amount) && client.AccountWithdraw(account.Code, amount))
                {
                    account.Amount -= amount;
                    accountAmountTB.Text = account.Amount.ToString();
                    amountStatus.Text = "Success";
                    withdrawTB.Text = "";
                }
                else
                {
                    amountStatus.Text = "Cannot withdraw from account";
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
