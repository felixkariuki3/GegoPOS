using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GegoPOS
{
    internal class DBConnect
    {
        private string con;
        public string myConnection()
            {
            con = @"Data Source=INFICORE\MSSQLSERVER19;Initial Catalog=GEGOPOS;User ID=sa;Password=123;Encrypt=False";
            return con;
        }
    }
}
