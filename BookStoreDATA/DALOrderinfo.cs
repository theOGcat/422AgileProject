
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace BookStoreDATA {
    public class DALOrderinfo {

        public void InsertandDet(int userid,int cardNum, string address, string nameoncard)
        {
            string connectionstring = "Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB20EX;Persist Security Info=True;User ID=AgileDB20EX;Password=AgileDB20EX";
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = cmd.CommandText = "Select card_no from Payment_Info where"
                    + " user_id = @UserId";

                cmd.Parameters.AddWithValue("@UserId", userid);

                int ifExit = (int)cmd.ExecuteScalar();

                if(ifExit > 0)
                {

                }
                else
                {
                    cmd.CommandText = "INSERT into Payment_info (card_no, user_id, name_on_card, address) " +
                        "VALUES (@CardN, @UserI, @NOC, @Ad)";
                    cmd.Parameters.AddWithValue("@UserI", userid);
                    cmd.Parameters.AddWithValue("@CardN", cardNum);
                    cmd.Parameters.AddWithValue("@NOC", nameoncard);
                    cmd.Parameters.AddWithValue("@Ad", address);

                    cmd.ExecuteScalar();
                }


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
        public void UpdateCardnum(int userid, int cardNumber)
        {
            string connectionstring = "Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB20EX;Persist Security Info=True;User ID=AgileDB20EX;Password=AgileDB20EX";
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Payment_Info" +
                    " SET card_no = @CN WHERE"
                    + " user_id = @USERID";

                cmd.Parameters.AddWithValue("@UserId", userid);
                cmd.Parameters.AddWithValue("@CN", cardNumber);

                int upCN = (int)cmd.ExecuteScalar();


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

        public void UpdateAddress(int userid, string address)
        {
            string connectionstring = "Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB20EX;Persist Security Info=True;User ID=AgileDB20EX;Password=AgileDB20EX";
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {

                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Payment_Info" +
                    " SET address = @ADDRESS WHERE"
                    + " user_id = @USERID";

                cmd.Parameters.AddWithValue("@UserId", userid);
                cmd.Parameters.AddWithValue("@ADDRESS", address);

                string upAd =  (string)cmd.ExecuteScalar();


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
        public string GetAddress(int userid)
        {
            string connectionstring = "Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB20EX;Persist Security Info=True;User ID=AgileDB20EX;Password=AgileDB20EX";
            SqlConnection conn = new SqlConnection(connectionstring);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select Delivery_Info.address from Delivery_Info,UserData where Delivery_Info.delivery_id=UserData.DeliveryID and UserData.UserID= @USERID";

                cmd.Parameters.AddWithValue("@UserId", userid);

                string usercAddress = (string)cmd.ExecuteScalar();

                return usercAddress;
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return "Fall";
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public int InsertInformOrderId(int orderid, int UID, int TTal, int cd_nm)
        {
            string connectionstring = "Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB20EX;Persist Security Info=True;User ID=AgileDB20EX;Password=AgileDB20EX";
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "INSERT into OrderInfo (order_id, UserID, total, card_no, delivery_id) VALUES (@OrderId, @UserId, @total, @Card_num, 0)";
                cmd.Parameters.AddWithValue("@OrderId", orderid);
                cmd.Parameters.AddWithValue("@UserId", UID);
                cmd.Parameters.AddWithValue("@total", TTal);
                cmd.Parameters.AddWithValue("@Card_num", cd_nm);
                cmd.ExecuteScalar();
                //conn.Close();
                return 1;
            }

            catch (Exception ex)
            {
                Debug.WriteLine("Error");
                return 2;
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }




        public int GetCardNum(int userid)
        {
            string connectionstring = "Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB20EX;Persist Security Info=True;User ID=AgileDB20EX;Password=AgileDB20EX";
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select card_no from Payment_Info, UserData where Payment_Info.card_no = UserData.CardID and  UserData.UserID =@USERID";
                cmd.Parameters.AddWithValue("@UserId", userid);
                int usercardname = (int)cmd.ExecuteScalar();
                return usercardname;
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return 2;
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public string Getusername(int userid)
        {
            string connectionstring = "Data Source=tfs.cspc1.uwindsor.ca;Initial Catalog=AgileDB20EX;Persist Security Info=True;User ID=AgileDB20EX;Password=AgileDB20EX";
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Select Username from  UserData where UserData.UserID = @USERID";
                cmd.Parameters.AddWithValue("@UserId", userid);
                string username = (string)cmd.ExecuteScalar();
                return username;
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return "False";
            }

            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

    }
}
