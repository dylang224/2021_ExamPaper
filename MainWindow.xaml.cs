///https://github.com/dylang224/2021_ExamPaper.git

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2021_ExamPaper
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Account> accounts = new List<Account>();
        List<Account> filteredAccounts = new List<Account>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //create 4 accounts

            CurrentAccount ca1 = new CurrentAccount("Joe", "Doe",1000,DateTime.Now.AddYears(-2), "168987979234");
            CurrentAccount ca2 = new CurrentAccount("Jane", "Doe", 2000, DateTime.Now.AddYears(-3), "15877685234");

            SavingsAccount sa1 = new SavingsAccount("Mr", "Anderson", 4000, DateTime.Now.AddYears(-4), "12564537334");
            SavingsAccount sa2 = new SavingsAccount("Agent", "Smith", 4500, DateTime.Now.AddYears(-5), "124674474434");

            //add to account list
            accounts.Add(ca1 );
            accounts.Add(ca2);
            accounts.Add(sa1);
            accounts.Add(sa2);
            //display

            lbxAccounts.ItemsSource = accounts;
        }

        private void lbxAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //determine what account is selected 
            Account selected = lbxAccounts.SelectedItem as Account;

            //check for null
            if (selected !=null)
            {
                //update display
                tblkFirstName.Text = selected.FirstName;
                tblkLastName.Text = selected.LastName;
                tblkBalance.Text = selected.Balance.ToString("c");
                tblkAccountType.Text = selected.GetType().Name;
                tblkInterestDate.Text = selected.InterestDate.ToString("d");

            }


        }

        private void checkBox_Click(object sender, RoutedEventArgs e)
        {
            //reset the listbox display
            lbxAccounts.ItemsSource = null;
            //clear the filter
            filteredAccounts.Clear();

            //determine what checkbox was selected
            bool savings = false, current = false;

            if (cbCurrent.IsChecked.Value)
                current = true;

            if(cbSavings.IsChecked.Value) 
                savings = true;
            //update display

            if (current && savings)
            {
                lbxAccounts.ItemsSource = accounts;
            }

            //filter accounts
            else if (current)
            {
                foreach (Account account in accounts)
                {
                    if (account is CurrentAccount)
                        filteredAccounts.Add(account);
                }
                lbxAccounts.ItemsSource = filteredAccounts;
            }

            else if (savings)
            {
                foreach (Account account in accounts)
                {
                    if (account is SavingsAccount)
                        filteredAccounts.Add(account);
                }
                lbxAccounts.ItemsSource = filteredAccounts;

            }
        }
    }
}