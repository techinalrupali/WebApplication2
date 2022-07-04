using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class UserDal
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public UserDal()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public int Save(User us)
        {
            string str = "insert into user1 values(@fullname,@emailid,@password,@roleid)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@fullname", us.FullName);
            cmd.Parameters.AddWithValue("@emailid", us.Emailid);
            cmd.Parameters.AddWithValue("@password", us.password);
            cmd.Parameters.AddWithValue("@roleid", us.RoleId);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Update(User us)
        {
            string str = "update user1 set FullName=@fullname,EmailId=@emailid,password=@password,RoleId=@roleid where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", us.Id);
            cmd.Parameters.AddWithValue("@fullname", us.FullName);
            cmd.Parameters.AddWithValue("@emailid", us.Emailid);
            cmd.Parameters.AddWithValue("@password", us.password);
            cmd.Parameters.AddWithValue("@roleid", us.RoleId);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int Delete(int id)
        {
            string str = "delete from user1 where Id=@id";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public int Check(string email,string pass)
        {
            string str = "Select EmailId,password from user1 where EmailId=@emailid and password=@password";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@emailid",email);
            cmd.Parameters.AddWithValue("@password",pass);
            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                con.Close();
                return 1;
            }
            else
            {
                con.Close();
                return 0;
            }
           
        }
    }
}

