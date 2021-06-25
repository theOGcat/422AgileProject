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
    /// Interaction logic for SignUpDiaLog.xaml
    /// </summary>
    public partial class SignUpDiaLog : Window
    {
        public SignUpDiaLog()
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
