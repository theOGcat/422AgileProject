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
    /// Interaction logic for Change Password.xaml
    /// </summary>
    public partial class Change_Password : Window
    {


        int userId;

        public Change_Password(int user)
        {
            InitializeComponent();
            this.userId = user;
        }


        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            UserData userdata = new UserData();
            string newPassword = this.passwordTextBox.Password;
            string confirmPassword = this.passwordconfirmTextBox.Password;

            if (String.Equals(newPassword, confirmPassword))
            {
                userdata.updatePassword(userId, newPassword);
                MessageBox.Show("Update Success");
                this.Close();

            }
            else MessageBox.Show("Please Make sure same password in confirm and new password");



        }

        private void cancleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
