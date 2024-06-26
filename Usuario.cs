using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemadeFaturacao
{
    public class Usuario
    {
        private static BD bd = new BD();
        private SqlConnection conn = bd.conexao();

        private String primeironome;
        private String ultimonome;
        private String email;
        private String senha;
        private String tipoDeUsuario;
        private byte[] foto = null;

        public Usuario(String email,String senha)
        {
            this.email = email;
            this.senha = senha;           
        }
        public Usuario(String email, String senha,String primeironome,String ultimonome,String tipoDeUsuario)
        {
            this.email = email;
            this.senha = senha;
            this.primeironome = primeironome;
            this.ultimonome =ultimonome;
            this.tipoDeUsuario = tipoDeUsuario;
        }
        public Usuario(String email, String senha, String primeironome, String ultimonome, String tipoDeUsuario, byte[] foto)
        {
            this.email = email;
            this.senha = senha;
            this.primeironome = primeironome;
            this.ultimonome = ultimonome;
            this.tipoDeUsuario = tipoDeUsuario;
            this.foto = foto;
        }
        public Usuario()
        {

        }
        private bool validaEmail(string email)
        {
        
            string padrao = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(padrao, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public bool verificaEmail()
        {

            if (!validaEmail(this.email))
            {
                MessageBox.Show("Por Favor, Digite um E-mail Válido", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
             return true;
        }

        public bool verificarEspacosVazios(int i)
        {
            if(i == 1)
            {
                this.email = this.email.Trim();
                this.senha = this.senha.Trim();

                if (email.Equals("") || senha.Equals(""))
                {
                    MessageBox.Show("É Necessário Preencher todos os Campos", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                return true;
            }
            else
            {
                this.primeironome = this.primeironome.Trim();
                this.ultimonome = this.ultimonome.Trim();
                this.email = this.email.Trim();
                this.senha = this.senha.Trim();
             
                if (primeironome.Equals("") || ultimonome.Equals("") || email.Equals("") || senha.Equals(""))
        
             {
                    MessageBox.Show("É Necessário Preencher todos os Campos", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                return true;
            }

        }

  
        public bool loginUsuario()
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("ValidaLogin", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            // Adiciona parâmetros de entrada
            cmd.Parameters.AddWithValue("@Email", this.email);
            cmd.Parameters.AddWithValue("@Senha", this.senha);

            // Adiciona parâmetros de saída
            SqlParameter resultadoParam = new SqlParameter("@Resultado", SqlDbType.Int);
            resultadoParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(resultadoParam);

            SqlParameter emailUsuarioParam = new SqlParameter("@EmailUsuario", SqlDbType.NVarChar, 50);
            emailUsuarioParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(emailUsuarioParam);

            // Executa o comando
            cmd.ExecuteNonQuery();

            // Obtém os valores dos parâmetros de saída
            int resultado = (int)cmd.Parameters["@Resultado"].Value;
            string emailUsuario = cmd.Parameters["@EmailUsuario"].Value as string;

            // Verifica o resultado e mostra a mensagem apropriada
            if (resultado == 1)
            {
               
                MessageBox.Show("Email Inserido não Existe.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                conn.Close();
                return false;

            }
            else if (resultado == 2)
            {

                MessageBox.Show("Senha Inserida está Incorreta.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                conn.Close();
                return false;

            }
            else if (resultado == 3)
            {
                MessageBox.Show("Login Bem-Sucedido!");
                conn.Close();
                // Aqui você pode adicionar código para abrir uma nova janela ou realizar outras ações de sucesso no login
                return true;
            }
            return false;
           
        }
        public DataTable BindData()
        {

            conn.Open();

            SqlCommand cmd = new SqlCommand("ListarUsuarios", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", string.IsNullOrEmpty(this.primeironome) ? (object)DBNull.Value : this.primeironome);


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

            SqlCommand cmd = new SqlCommand("ListarUsuarios", conn);

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