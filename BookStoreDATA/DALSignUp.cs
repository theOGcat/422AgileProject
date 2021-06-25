using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;


namespace BookStoreDATA
{
    public class DALSignUp
    {
        public int SignUp(string loginName, string passWord,string CardNumber,string NameOnCard,string Address)
        {
            string connectionstring = "Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB20EX;Persist Security Info=True;User ID=AgileDB20EX;Password=AgileDB20EX";
            SqlConnection conn = new SqlConnection(connectionstring);
            try
            {
              
               
               
                //insert name and password
                string sql = "insert into UserData(UserName,Password) values('"+loginName+"','"+passWord+ "')Select @@Identity";
                SqlCommand mycmd1 = new SqlCommand();
                mycmd1.CommandText = sql;
                mycmd1.Connection = conn;

                conn.Open();
                int userId = Convert.ToInt32(mycmd1.ExecuteScalar());
                conn.Close();

     
                //insert payment
                mycmd1.Connection = conn;
                mycmd1.CommandText = "INSERT into Payment_info (card_no, user_id, name_on_card, address) " +
                        "VALUES ('" + CardNumber + "', '" + userId + "', '" + NameOnCard + "', '" + Address + "')";
                conn.Open();
                mycmd1.ExecuteScalar();
                conn.Close();

                //mycmd1.Parameters.AddWithValue("@UserName", loginName);
                //mycmd1.Parameters.AddWithValue("@Password", passWord);
                //(int)cmd.ExecuteScalar();


                if (userId > 0)
                    return userId;
                else
                   return -1;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return -4;
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }
    }
}
