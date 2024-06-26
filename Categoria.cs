using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SistemadeFaturacao
{
    public class Categoria
    {

        private static BD bd = new BD();
        private SqlConnection conn = bd.conexao();

        private String nome;

        public Categoria(String nome)
        {
            this.nome = nome;
        }

        public Categoria()
        {

        }
        public bool verificarEspacosVazios()
        {

                this.nome = this.nome.Trim();
            

                if (nome.Equals(""))
                {
                    MessageBox.Show("É Necessário Preencher o Campo", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                return true;
            


        }


        public DataTable BindData()
        {

            conn.Open();

            SqlCommand cmd = new SqlCommand("ListarCategorias", conn);

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
        public DataTable BindData(string texto)
        {

            conn.Open();

            SqlCommand cmd = new SqlCommand("ListarCategorias", conn);

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
        public bool addCategoria()
        {


                conn.Open();

                SqlCommand cmd = new SqlCommand("ValidaRegistroCategoria", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                // Adiciona parâmetros de entrada
                cmd.Parameters.AddWithValue("@Nome", nome);

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
                    MessageBox.Show("Ops! A Categoria inserida já existe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    conn.Close();
                return false;
                }
                else
                {

                   


                    MessageBox.Show("Categoria Adicionada com sucesso!");


                    conn.Close();


                    

                
                return true;


            }
            
        }

        public bool deleteCategoria(String id)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DeletaCategoria", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                // Verificar se o usuário existe
                cmd.Parameters.AddWithValue("@IdCategoria", id);

                // Adicionar parâmetro de saída
                SqlParameter resultadoParam = new SqlParameter("@Resultado", SqlDbType.Int);
                resultadoParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(resultadoParam);


           

                    DialogResult dr = MessageBox.Show("Tem certeza de que deseja eliminar essa Categoria?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (dr == DialogResult.Yes)
                    {

                    // Executar o comando
                    cmd.ExecuteNonQuery();

                    // Obter o valor do parâmetro de saída
                    int resultado = (int)cmd.Parameters["@Resultado"].Value;

                    // Verificar o resultado e mostrar a mensagem apropriada
                    if (resultado == 1)
                    {
                        MessageBox.Show("Categoria não Encontrada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    MessageBox.Show("Categoria Eliminada com Sucesso");
                        return true;

         
                    }
                    else
                    {
                        return false;
                    }
                    

                


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Eliminar Eategoria: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }





    }
}
