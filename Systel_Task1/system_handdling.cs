using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Windows.Forms;

namespace Systel_Task1
{
    class system_handdling
    {
        public Users getuser(string name,string password)
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Connection.ConVal("constring")))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    return connection.Query<Users>($"select * from users where CAST(username as VARCHAR)= '{name}' and CAST(password as VARCHAR)= '{password}'").ToList<Users>().First<Users>();
                }
            }
            catch
            {
                MessageBox.Show("Error User Name or Password");
                return null;
            }
            
        }
        public void setuser(Users user)
        {
            try
            {

            
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Connection.ConVal("constring")))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    connection.Query<Users>($"insert into users (username,password,privilege,groupid) values(convert(text,'{user.username}'),convert(text,'{user.password}'),{user.privilege},{user.groupid})");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public List<int> loadgroupid()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Connection.ConVal("constring")))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                return connection.Query<int>($"select ID from groups").ToList<int>();
            }
        }
        public List<grouDevices> allDevices(int x)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Connection.ConVal("constring")))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                return connection.Query<grouDevices>($"select * from groupDevices where groupid='{x}'").ToList<grouDevices>();
            }
        }
        public void changeGroup(int group ,int id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Connection.ConVal("constring")))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                connection.Query<Users>($"update users set groupid='{group}' where userid='{id}'");
            }
        }
        public void insertdevice(string name ,int gid ,int pn ,int cc,int mod ,string ip)
        {
            try
            {


                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Connection.ConVal("constring")))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    connection.Query($"insert into groupDevices (devicename,groupid,platenumber,citycode,modemid,IP) values(convert(text,'{name}'),'{gid}','{pn}','{cc}','{mod}','{ip}')");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void deletedevice(int id)
        {
            try
            {


                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Connection.ConVal("constring")))
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    connection.Query($"delete from groupDevices where deviceid ='{id}'");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
