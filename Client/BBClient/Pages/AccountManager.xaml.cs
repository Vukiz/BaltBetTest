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
            accountAmountTB.Text = account.Amount.ToString();
            accountCodeTB.Text = account.Code.ToString();
            accountFIOTB.Text = account.FIO;
        }
    }
}
