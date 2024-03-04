using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace payrollsystemsti
{
    internal class Connection
    {
        public SqlConnection con;
        public SqlCommand cmd;
        public SqlDataAdapter sda;
        public string pkk;
		public string constr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=stipayrolldb;Integrated Security=True;TrustServerCertificate=True;Encrypt = false";

        public void OpenConnection()
        {

            con = new SqlConnection(constr);
			if(con.State == System.Data.ConnectionState.Closed)
			{
				con.Open();
			}
            

        }
		
		public void CloseConnection()
		{
			if (con.State == System.Data.ConnectionState.Open)
			{
				con.Close();
			}
		}
		public void DataSend(string SQL)
		{
			OpenConnection();
			cmd = new SqlCommand(SQL, con);
			cmd.ExecuteNonQuery();
			pkk = "";
			con.Close();
		}

		public void DataGet(string SQL)
		{
			OpenConnection(); 
			sda = new SqlDataAdapter(SQL, con);
		}
	}
}
