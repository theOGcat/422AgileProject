using BookStoreLIB;
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
using System.Windows.Shapes;

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for updateWindow.xaml
    /// </summary>
    public partial class updateWindow : Window

    {
        public UserData UD { set; get; }
        int userId;

        public updateWindow(int user, UserData userdata)
        {
            InitializeComponent();
            this.userId = user;
            UD = userdata;
            address();
            payment();
            username();
        }

        private void address()
        {
            Address.Text = UD.GetAddress(UD.UserID);

        }


        private void PasswordButton_Click(object sender, RoutedEventArgs e)
        {
            Change_Password Cpw = new Change_Password(userId);
            Cpw.Owner = this;
            Cpw.ShowDialog();

        }

        private void PaymentButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddressButton_Click(object sender, RoutedEventArgs e)
        {

        }        
        private void cancleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }        
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void payment()
        {
           
            Payment.Text = UD.GetCardNum(UD.UserID).ToString();
        }


        private void username()
        {
            Name.Text = UD.Getusername(UD.UserID) ;
        }

        private void logout(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow Lgo = new MainWindow();
            Lgo.Show();
        }


    }

}
