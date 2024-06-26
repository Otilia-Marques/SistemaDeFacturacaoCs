using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.StyledXmlParser.Jsoup.Nodes;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SistemadeFaturacao
{
    public class Taxa
    {
        private static BD bd = new BD();
        private SqlConnection conn = bd.conexao();


        private String taxa;
        private String data_vigencia;
        private String descricao;
        private String ativo;

        public Taxa()
        {

        }
        public string SubstituirVirgulasPorPontos(string input)
        {
            return input.Replace(',', '.');
        }
        public Taxa(String taxa, String data_vigencia, string descricao, string ativo)
        {
           
            this.taxa = taxa;
            this.data_vigencia = data_vigencia;
            this.descricao = descricao;
            this.ativo = ativo;
        }

        public bool IsNumber(string input)
        {
            // Expressão regular para verificar se a string é um número inteiro ou decimal
            string pattern = @"^(?!-)[+]?(?:\d+\.\d+|\d+)$";

            if(Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Entrada incorreta", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }
        }
        public bool verificarEspacosVazios()
        {
 
                this.taxa = this.taxa.Trim();
                this.ativo = this.ativo.Trim();

                if (taxa.Equals("") || ativo.Equals(""))
                {
                    MessageBox.Show("É necessário preencher todos os campos", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                return true;

     

        }
        public DataTable BindData()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("ListarTaxas", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Taxa", DBNull.Value);  // Usar DBNull.Value para um parâmetro nulo

            SqlDataAdapter sd = new SqlDataAdapter();
            sd.SelectCommand = cmd;

            DataTable dt = new DataTable();
            dt.Clear();
            sd.Fill(dt);

            conn.Close();
            return dt;
        }

        public DataTable BindData(string texto)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("ListarTaxas", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Taxa", texto);  // Passando texto como parâmetro

            SqlDataAdapter sd = new SqlDataAdapter();
            sd.SelectCommand = cmd;

            DataTable dt = new DataTable();
            dt.Clear();
            sd.Fill(dt);

            conn.Close();
            return dt;
        }

        public bool addTaxa()
        {


        conn.Open();

            SqlCommand cmd = new SqlCommand("ValidaRegistroTaxa", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            // Adiciona parâmetros de entrada
            cmd.Parameters.AddWithValue("@taxa", taxa);
            cmd.Parameters.AddWithValue("@data_vigencia", data_vigencia);
            cmd.Parameters.AddWithValue("@descricao", descricao);
            cmd.Parameters.AddWithValue("@ativo", ativo);
            // Adiciona parâmetros de saída
            SqlParameter resultadoParam = new SqlParameter("@Resultado", SqlDbType.Int);
            resultadoParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(resultadoParam);


            // Executa o comando
            cmd.ExecuteNonQuery();

            // Obtém os valores dos parâmetros de saída
            int resultado = (int)cmd.Parameters["@Resultado"].Value;


            // Verifica o resultado e mostra a mensagem apropriada
            if (resultado == 1)
            {
                MessageBox.Show("A Taxa digitada já existe", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                conn.Close();
                return false;
            }
            else
            {




                MessageBox.Show("Taxa Adicionada com Sucesso!");


                conn.Close();





                return true;


            }


        }

        public bool deleteTaxa(String id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DeletaTaxa", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                // Verificar se o usuário existe
                cmd.Parameters.AddWithValue("@IdTaxa", id);

                // Adicionar parâmetro de saída
                SqlParameter resultadoParam = new SqlParameter("@Resultado", SqlDbType.Int);
                resultadoParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(resultadoParam);




                DialogResult dr = MessageBox.Show("Tem a certeza de que deseja eliminar essa Taxa?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                {

                    // Executar o comando
                    cmd.ExecuteNonQuery();

                    // Obter o valor do parâmetro de saída
                    int resultado = (int)cmd.Parameters["@Resultado"].Value;

                    // Verificar o resultado e mostrar a mensagem apropriada
                    if (resultado == 1)
                    {
                        MessageBox.Show("Taxa não encontrada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    MessageBox.Show("Taxa Eliminada com Sucesso");
                    return true;


                }
                else
                {
                    return false;
                }





            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Eliminar Categoria: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }



    }
}
