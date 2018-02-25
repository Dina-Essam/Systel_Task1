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
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Connection.ConVal("constring")))
                {
                    connection.Query<Users>($"insert into users (username,password,privilege,groupid) values(convert(text,'{user.username}'),convert(text,'{user.password}'),{user.privilege},{user.groupid})");
                }
        }
        public List<int> loadgroupid()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Connection.ConVal("constring")))
            {
                return connection.Query<int>($"select ID from groups").ToList<int>();
            }
        }

    }
}
