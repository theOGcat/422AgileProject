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
using System.Windows.Shapes;
using System.Data;
using BookStoreLIB;
using System.Collections.ObjectModel;

namespace BookStoreGUI
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        DataSet dsBookCat;
        UserData userData;
        BookOrder bookOrder;
        SignUp SignUp;
        int UserId; 
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginDialog dlg = new LoginDialog();
            dlg.Owner = this;
            dlg.ShowDialog();
            // Process data entered by user if dialog box is accepted
            if (dlg.DialogResult == true)
            {
                if (userData.LogIn(dlg.nameTextBox.Text, dlg.passwordTextBox.Password) == true)
                {
                    this.statusTextBlock.Text = "You are logged in as User #" +
                    userData.UserID;
                    UserId = userData.UserID;
                }
                else
                    this.statusTextBlock.Text = "Your login failed. Please try again.";
            }
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            
            updateWindow udw = new updateWindow(UserId, userData);
            udw.Owner = this;
            if (userData.UserID < 1)
                MessageBox.Show("Please sign in to your account to update your password");
            else udw.ShowDialog();
            this.Close();
        }


        private void exitButton_Click(object sender, RoutedEventArgs e) { this.Close(); }

        public MainWindow() { InitializeComponent(); }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BookCatalog bookCat = new BookCatalog();
            dsBookCat = bookCat.GetBookInfo();
            this.DataContext = dsBookCat.Tables["Category"];


            bookOrder = new BookOrder();
            userData = new UserData();
            this.orderListView.ItemsSource = bookOrder.OrderItemList;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            OrderItemDialog orderItemDialog = new OrderItemDialog();
            DataRowView selectedRow;
            selectedRow = (DataRowView)this.ProductsDataGrid.SelectedItems[0];
            orderItemDialog.isbnTextBox.Text = selectedRow.Row.ItemArray[0].ToString();
            orderItemDialog.titleTextBox.Text = selectedRow.Row.ItemArray[2].ToString();
            orderItemDialog.priceTextBox.Text = selectedRow.Row.ItemArray[4].ToString();
            orderItemDialog.Owner = this;
            orderItemDialog.ShowDialog();
            if (orderItemDialog.DialogResult == true)
            {
                string isbn = orderItemDialog.isbnTextBox.Text;
                string title = orderItemDialog.titleTextBox.Text;
                double unitPrice = double.Parse(orderItemDialog.priceTextBox.Text);
                int quantity = int.Parse(orderItemDialog.quantityTextBox.Text);
                bookOrder.AddItem(new OrderItem(isbn, title, unitPrice, quantity));
            }
        }

        private void chechoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (userData.UserID < 1 || bookOrder.OrderItemList.Count == 0)
                MessageBox.Show("Please sign in and select book(s) before placing the order");

            else
            {
                UserData ud = new UserData();

                //ud.getPaymentInfo(ud.UserID, ud.GetCardNum(ud.UserID), ud.LoginName, ud.GetAddress(ud.UserID));

                int cardnum = ud.GetCardNum(userData.UserID);

                CheakOut CO = new CheakOut(userData,bookOrder);
                   CO.Owner = this;
                   CO.ShowDialog();




                //ud.intsertOrderId(bookOrder.PlaceOrder(userData.UserID), userData.UserID, );
                /*
                int orderId;
                orderId = bookOrder.PlaceOrder(userData.UserID);
                MessageBox.Show("Your order has been placed. Your order id is " +
                orderId.ToString());*/
            }
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.orderListView.SelectedItem != null)
            {
                var selectedOrderItem = this.orderListView.SelectedItem as OrderItem;
                bookOrder.RemoveItem(selectedOrderItem.BookID);
            }

        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpDiaLog dlg = new SignUpDiaLog();
            SignUp = new SignUp();
            dlg.Owner = this;
            dlg.ShowDialog();
            if (dlg.DialogResult == true)
            {
                if (SignUp.SignUpUser(dlg.nameTextBox.Text, dlg.passwordTextBox.Text, dlg.passwordcondirmTextBox.Text, dlg.CardNumber.Text, dlg.NameOnCard.Text, dlg.Address.Text) == true)
                    this.statusTextBlock.Text = "You are insert in as User #" +
                    SignUp.UserID;
                else
                    this.statusTextBlock.Text = "Your login failed. Please try again.";
            }
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
            {
                searchWindow swd = new searchWindow();
                swd.Owner = this;
                swd.ShowDialog();
            }

        private void categoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
