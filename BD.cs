using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeFaturacao
{
    public class BD
    {
        private static String conString = "Data Source=MARTINA-TINI;Initial Catalog=SistemaDeFacturacao;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        SqlConnection conn = new SqlConnection(conString);
        public BD()
        {

        }
        public SqlConnection conexao()
        {
            return conn;
        }
    }
}