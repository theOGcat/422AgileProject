/* **********************************************************************************
 * For use by students taking 60-422 (Fall, 2014) to work on assignments and project.
 * Permission required material. Contact: xyuan@uwindsor.ca 
 * **********************************************************************************/
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
using BookStoreLIB;

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginDialog : Window
    {
        public LoginDialog()
        {
            InitializeComponent();
        }
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void cancleButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
