using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Login_Basic {
    class Connect_DB {
        public static SqlConnection SqlConnect() {
            string strConnect = @"Data Source=DREAMCOREI5;Initial Catalog=Management;Integrated Security=True";
            SqlConnection connect = new SqlConnection(strConnect);
            connect.Open();
            return connect;
        }
    }
}
