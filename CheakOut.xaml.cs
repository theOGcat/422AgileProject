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
using System.Data;
using BookStoreLIB;
using System.Collections.ObjectModel;

namespace BookStoreGUI
{
    /// <summary>
    /// Interaction logic for CheakOut.xaml
    /// </summary>
    
    public partial class CheakOut : Window
    {

        public UserData UD { set; get; }
        public BookOrder BO { set; get; }

        int i;

        public CheakOut(UserData userdata, BookOrder bookOrder)
        {

            InitializeComponent();
            UD = userdata;
            BO = bookOrder;
            ChangeText();


        }

        void ChangeText()
        {

            UID.Text = "User ID : " + UD.UserID;
            DefaultNum.Text =  "" +UD.GetCardNum(UD.UserID);
            Address.Text = "" + UD.GetAddress(UD.UserID);

            double booktotal = BO.GetOrderTotal();
            double service_price = booktotal * 0.13;
            double total = booktotal + service_price;

            string gettotal = "Book total : " + booktotal + "\nService price : " + service_price + "\nTotal : " + total;

            PriceCount1.Text = gettotal;

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if(UD.GetAddress(UD.UserID) != null && UD.GetCardNum(UD.UserID)!= null)
            {
                i = Convert.ToInt32(DefaultNum.Text);
                UD.UPAD(UD.UserID, Address.Text);
                UD.UDcard(UD.UserID, i);
                MessageBox.Show(""+i);
            }
            else
            {
                MessageBox.Show("Please Enter the Card Number/Address");
            }

        }

        private void Check_out_click(object sender, RoutedEventArgs e)
        {
            int i = BO.PlaceOrder(UD.UserID);
            MessageBox.Show("Your order id is : " + i);
        }

        private void Address_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
