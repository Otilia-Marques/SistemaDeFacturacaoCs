using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;

namespace SistemadeFaturacao
{
    public class Produto
    {
        private static BD bd = new BD();
        private SqlConnection conn = bd.conexao();

        private String nome;
        private String codigoProduto;
        private String descricao;
        private String preco;
        private String quantidade;
        private String status;
        private String taxa;
        private String categoria;
        public Produto()
        {

        }
        public Produto(String nome,String codigoProduto,String descricao,String preco, String quantidade, String status, String taxa, String categoria)
        {
            this.nome = nome;
            this.codigoProduto = codigoProduto;
            this.descricao = descricao;
            this.preco = preco;
            this.quantidade = quantidade;
            this.status = status;
            this.taxa = taxa;
            this.categoria = categoria;

        }

        public DataTable BindData()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("ListarProdutos", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", string.IsNullOrEmpty(this.nome) ? (object)DBNull.Value : this.nome);


            SqlDataAdapter sd = new SqlDataAdapter();
            sd.SelectCommand = cmd;

            DataTable dt = new DataTable();
            dt.Clear();
            sd.Fill(dt);

            conn.Close();
            return dt;
        }
        public DataTable BindData1()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("ListarProdutos1", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", string.IsNullOrEmpty(this.nome) ? (object)DBNull.Value : this.nome);


            SqlDataAdapter sd = new SqlDataAdapter();
            sd.SelectCommand = cmd;

            DataTable dt = new DataTable();
            dt.Clear();
            sd.Fill(dt);

            conn.Close();
            return dt;
        }
        public bool IsNumber(string input, int i)
        {
            if (i == 1)
            {
                string pattern = @"^(?!-)[+]?\d+$";
                return Regex.IsMatch(input, pattern);
            }
            else
            {
                string pattern = @"^(?!-)[+]?(?:\d+\.\d+|\d+)$";
                return Regex.IsMatch(input, pattern);
            }
            // Expressão regular para verificar se a string é um número inteiro ou decimal
            
        }
        public  bool contemLetra()
        {
            foreach (char c in codigoProduto)
            {
                if (Char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }
        public bool contemEspaco()
        {
            foreach (char c in codigoProduto)
            {
                if (c == ' ')
                {
                    return false;
                }
            }
            return true;
        }
        public bool verificarEspacosVazios()
        {
            if (codigoProduto.Equals("") || descricao.Equals("") || quantidade.Equals("") || nome.Equals("") || preco.Equals("") || taxa.Equals("") || categoria.Equals("") || status.Equals(""))
            {
                MessageBox.Show("É Necessário Preencher todos os Campos", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {

            return true; 
            }

        }
        public DataTable BindData(string texto)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("ListarProdutos", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", string.IsNullOrEmpty(texto) ? (object)DBNull.Value : texto);


            SqlDataAdapter sd = new SqlDataAdapter();
            sd.SelectCommand = cmd;

            DataTable dt = new DataTable();
            dt.Clear();
            sd.Fill(dt);

            conn.Close();
            return dt;
        }
        public DataTable BindData1(string texto)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("ListarProdutos1", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", string.IsNullOrEmpty(texto) ? (object)DBNull.Value : texto);


            SqlDataAdapter sd = new SqlDataAdapter();
            sd.SelectCommand = cmd;

            DataTable dt = new DataTable();
            dt.Clear();
            sd.Fill(dt);

            conn.Close();
            return dt;
        }
    }
}
