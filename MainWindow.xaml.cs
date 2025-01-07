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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //create 4 accounts

            CurrentAccount ca1 = new CurrentAccount("Joe", "Doe",1000,DateTime.Now.AddYears(-2), "168987979234");
            CurrentAccount ca2 = new CurrentAccount("Jane", "Doe", 2000, DateTime.Now.AddYears(-3), "15877685234");

            SavingsAccount sa1 = new SavingsAccount("Anderson", "Mr", 4000, DateTime.Now.AddYears(-4), "12564537334");
            SavingsAccount sa2 = new SavingsAccount("Smith", "Agent", 4500, DateTime.Now.AddYears(-5), "124674474434");

            //add to account list
            accounts.Add(ca1 );
            accounts.Add(ca2);
            accounts.Add(sa1);
            accounts.Add(sa2);
            //display

            lbxAccounts.ItemsSource = accounts;
        }
    }
}