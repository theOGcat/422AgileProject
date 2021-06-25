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
using System.Data.SqlClient;
using System.Diagnostics;
using BookStoreDATA;
using System.IO;


namespace BookStoreGUI
{

    /// Interaction logic for searchWindow.xaml
    /// </summary>
    public partial class searchWindow : Window
    {

        // BookCatalog bookcatalog = new BookCatalog();


        DataTable list = new DataTable();
        public searchWindow()
        {
            InitializeComponent();
        }

        private void bSearchButton_Click(object sender, RoutedEventArgs e)
        {
            string keyword = thisTextboxYear.Text;
            StringBuilder handle = new StringBuilder();
            handle.Append("%");
            handle.Append(keyword);
            handle.Append("%");
            string connectionstring = "Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB20EX;Persist Security Info=True;User ID=AgileDB20EX;Password=AgileDB20EX";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlDataAdapter conn1 = new SqlDataAdapter();
                DataTable dtbl = new DataTable();
                DataView sortTable;
                switch (listOfSearch.Text)
                {
                    case "Year":
                        conn1 = new SqlDataAdapter("Select Title," +
                            "Author, Price, Year  from BookData where " +
                            "Year like @Year", conn);
                        conn1.SelectCommand.Parameters.AddWithValue("@Year", handle.ToString());
                        dtbl = new DataTable();
                        conn1.Fill(dtbl);

                        //sort table result
                        sortTable = dtbl.DefaultView;
                        sortTable.Sort = "Year";
                        dtbl = sortTable.ToTable();
                        break;

                    case "Author":
                        conn1 = new SqlDataAdapter("Select Title," +
                            "Author, Price, Year  from BookData where " +
                            "Author like @Author", conn);
                        conn1.SelectCommand.Parameters.AddWithValue("@Author", handle.ToString());
                        dtbl = new DataTable();
                        conn1.Fill(dtbl);

                        //sort table result
                        sortTable = dtbl.DefaultView;
                        sortTable.Sort = "Author";
                        dtbl = sortTable.ToTable();
                        break;

                    case "Price":
                        conn1 = new SqlDataAdapter("Select Title," +
                            "Author, Price, Year  from BookData where " +
                            "Price like @Price", conn);
                        conn1.SelectCommand.Parameters.AddWithValue("@Price", handle.ToString());
                        dtbl = new DataTable();
                        conn1.Fill(dtbl);

                        //sort table result
                        sortTable = dtbl.DefaultView;
                        sortTable.Sort = "Price";
                        dtbl = sortTable.ToTable();
                        break;

                    case "Title":
                        conn1 = new SqlDataAdapter("Select Title," +
                            "Author, Price, Year  from BookData where " +
                            "Title like @Title", conn);
                        conn1.SelectCommand.Parameters.AddWithValue("@Title", handle.ToString());
                        dtbl = new DataTable();
                        conn1.Fill(dtbl);

                        //sort table result
                        sortTable = dtbl.DefaultView;
                        sortTable.Sort = "Title";
                        dtbl = sortTable.ToTable();
                        break;

                    default:
                        MessageBox.Show("Please select a kind of keyword.");
                        break;
                }




                ProductsDataGrid.ItemsSource = dtbl.DefaultView;
                list = dtbl;
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }

        private void eSearchButton_Click(object sender, RoutedEventArgs e)
        {
            string keyword = thisTextboxYear.Text;
            string connectionstring = "Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB20EX;Persist Security Info=True;User ID=AgileDB20EX;Password=AgileDB20EX";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlDataAdapter conn1 = new SqlDataAdapter();
                DataTable dtbl = new DataTable();
                DataView sortTable;
                switch (listOfSearch.Text)
                {
                    case "Year":
                        conn1 = new SqlDataAdapter("Select Title," +
                            "Author, Price, Year  from BookData where " +
                            "Year = @Year", conn);
                        conn1.SelectCommand.Parameters.AddWithValue("@Year", keyword);
                        dtbl = new DataTable();
                        conn1.Fill(dtbl);

                        //sort table result
                        sortTable = dtbl.DefaultView;
                        sortTable.Sort = "Year";
                        dtbl = sortTable.ToTable();
                        break;

                    case "Author":
                        conn1 = new SqlDataAdapter("Select Title," +
                            "Author, Price, Year  from BookData where " +
                            "Author = @Author", conn);
                        conn1.SelectCommand.Parameters.AddWithValue("@Author", keyword);
                        dtbl = new DataTable();
                        conn1.Fill(dtbl);

                        //sort table result
                        sortTable = dtbl.DefaultView;
                        sortTable.Sort = "Author";
                        dtbl = sortTable.ToTable();
                        break;

                    case "Price":
                        conn1 = new SqlDataAdapter("Select Title," +
                            "Author, Price, Year  from BookData where " +
                            "Price = @Price", conn);
                        conn1.SelectCommand.Parameters.AddWithValue("@Price", keyword);
                        dtbl = new DataTable();
                        conn1.Fill(dtbl);

                        //sort table result
                        sortTable = dtbl.DefaultView;
                        sortTable.Sort = "Price";
                        dtbl = sortTable.ToTable();
                        break;

                    case "Title":
                        conn1 = new SqlDataAdapter("Select Title," +
                            "Author, Price, Year  from BookData where " +
                            "Title = @Title", conn);
                        conn1.SelectCommand.Parameters.AddWithValue("@Title", keyword);
                        dtbl = new DataTable();
                        conn1.Fill(dtbl);

                        //sort table result
                        sortTable = dtbl.DefaultView;
                        sortTable.Sort = "Title";
                        dtbl = sortTable.ToTable();
                        break;

                    default:
                        MessageBox.Show("Please select a kind of keyword.");
                        break;
                }




                ProductsDataGrid.ItemsSource = dtbl.DefaultView;

                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBoxForm_Load(object sender, EventArgs e)
        {
            listOfSearch.Items.Add("Year");
            listOfSearch.Items.Add("Title");
            listOfSearch.Items.Add("Price");
            listOfSearch.Items.Add("Author");
        }

        private void sPubButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectRow;
            selectRow = (DataRowView)this.ProductsDataGrid.SelectedItems[0];
            string title = (string)selectRow.Row.ItemArray[0];
            //MessageBox.Show(title);
            string connectionstring = "Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB20EX;Persist Security Info=True;User ID=AgileDB20EX;Password=AgileDB20EX";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();
                SqlDataAdapter conn1 = new SqlDataAdapter();
                conn1 = new SqlDataAdapter("Select Title," +
                            "Publisher  from BookData where " +
                            "Title = @Title", conn);
                conn1.SelectCommand.Parameters.AddWithValue("@Title", title);

                DataTable publisher = new DataTable();
                conn1.Fill(publisher);

                StringWriter value = new StringWriter();
                publisher.TableName = "publisher";
                publisher.WriteXmlSchema(value);
                StringBuilder showValue = new StringBuilder();
                //showValue.Append(value.ToString());
                value.Close();
                DataRow row = publisher.Rows[0];
                showValue.Append(Convert.ToString(row[1]));
                /*for (int i=0; i<publisher.Rows.Count; i++)
                {
                    MessageBox.Show("i= "+i);
                    DataRow row = publisher.Rows[i];
                    if(i>0)
                    {
                        showValue.Append("#$%");
                    }
                    for(int j=0; j<publisher.Columns.Count; j++)
                    {
                        if(j>0)
                        {
                            showValue.Append("^&*");
                        }
                        showValue.Append(Convert.ToString(row[j]));
                        MessageBox.Show("j= " + j);
                    }
                }*/
                MessageBox.Show("Publisher: " + showValue.ToString());
            }
        }

        private void rSearchButton_Click(object sender, RoutedEventArgs e)
        {
            DataTable rSearch = list;
            string keyword = reKeyword.Text;
            StringBuilder command = new StringBuilder();
            command.Append("Title = '");
            command.Append(keyword);
            command.Append("'");
            MessageBox.Show(command.ToString());
            DataRow[] info = rSearch.Select(command.ToString());
            if (info.Length == 0)
            {
                MessageBox.Show("No book is found.");
                return;
            }
            DataTable shows = info[0].Table.Clone();
            foreach (DataRow r in info)
            {
                shows.ImportRow(r);
            }
            ProductsDataGrid.ItemsSource = shows.DefaultView;
        }
















    }
}
