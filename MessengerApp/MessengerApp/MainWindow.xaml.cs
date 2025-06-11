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

namespace MessengerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MessengerWindow fensterA;
        private MessengerWindow fensterB;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOpenA_Click(object sender, RoutedEventArgs e)
        {
            if (fensterA == null || !fensterA.IsLoaded)
            {
                fensterA = new MessengerWindow("A");
                fensterA.Show();
                TryConnectWindows();
            }
            else
            {
                fensterA.Focus();
            }
        }

        private void BtnOpenB_Click(object sender, RoutedEventArgs e)
        {
            if (fensterB == null || !fensterB.IsLoaded)
            {
                fensterB = new MessengerWindow("B");
                fensterB.Show();
                TryConnectWindows();
            }
            else
            {
                fensterB.Focus();
            }
        }

       
        private void TryConnectWindows()
        {
            if (fensterA != null && fensterB != null)
            {
                fensterA.MessageSent += fensterB.OnOtherWindowMessageReceived;
                fensterB.MessageSent += fensterA.OnOtherWindowMessageReceived;
            }
        }
    }
}