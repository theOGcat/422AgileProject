using System;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;


namespace BookStoreDATA
{
    public class DALUserInfo
    {
        public int Login(string userName, string password)
        {
            string connectionstring = "Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB20EX;Persist Security Info=True;User ID=AgileDB20EX;Password=AgileDB20EX";
            SqlConnection conn = new SqlConnection(connectionstring);
           
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select UserID from UserData where"
                    +" UserName = @UserName and Password = @Password";

                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Password", password);

                

                int userId = (int)cmd.ExecuteScalar();
                if (userId > 0)
                    return userId;
                else
                    return -1;

            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return -2;
            }

            finally{
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }



        public void updatePassword(int userId, string Password)
        {
            string connectionstring = "Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB20EX;Persist Security Info=True;User ID=AgileDB20EX;Password=AgileDB20EX";
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE UserData" +
                    " SET Password = @PassWord WHERE"
                    + " UserID = @UserId";

                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@PassWord", Password);

                int upPassword = (int)cmd.ExecuteScalar();


            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }











    }
}