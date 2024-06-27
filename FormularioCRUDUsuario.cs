using MaterialDesignExtensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SistemadeFaturacao
{

    public partial class FormularioCRUDUsuario : Form
    {
        public String Stringid;
        public static FormularioCRUDUsuario instance;
        private static BD bd = new BD();
        private SqlConnection conn = bd.conexao();

        public const int Wm_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]

        public static extern bool ReleaseCapture();


        public static FormularioCRUDUsuario frm;

        public static FormularioCRUDUsuario GetFormularioCRUDUsuario
        {
            get
            {
                if (frm == null)
                {
                    frm = new FormularioCRUDUsuario();
                }
                return frm;
            }
        }

        public FormularioCRUDUsuario()
        {
            InitializeComponent();
            instance = this;
            
        }
        public void SetButtonVisibility(bool isVisible,int n)
        {
            if(n == 1)
            {
                guna2Button4.Visible = isVisible;
                guna2Button3.Visible = isVisible;
                guna2Button1.Visible = true;
            }
            else
                if(n == 2)
                {
                guna2Button4.Visible = true;
                guna2Button3.Visible = true;
                guna2Button1.Visible = isVisible;
            }

      
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {

            String primeironome = textprimeironome.Text;
            String ultimonome = textultimonome.Text;
            String email = textemail.Text;
            String senha = textsenha.Text;

            if(combousuario.SelectedItem != null)
            {
                String tipodeusuario = combousuario.SelectedItem.ToString();
              

            Usuario usuario = new Usuario(email,senha,primeironome,ultimonome,tipodeusuario);


                if (usuario.verificarEspacosVazios(2))
                {

                    if (usuario.verificaEmail())
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("ValidaRegistroUsuario", conn);
                        
                            cmd.CommandType = CommandType.StoredProcedure;

                            // Adiciona parâmetros de entrada
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Senha", senha);
                            cmd.Parameters.AddWithValue("@PrimeiroNome", primeironome);
                            cmd.Parameters.AddWithValue("@UltimoNome", ultimonome);
                            cmd.Parameters.AddWithValue("@TipoDeUsuario", tipodeusuario);

                            if (pictureBox1.Image != null)
                            {
                                cmd.Parameters.AddWithValue("@Foto", getImage());
                            }
                            else
                            {
                                cmd.Parameters.Add("@Foto", SqlDbType.Image, -1).Value = DBNull.Value;

                            }
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
                                MessageBox.Show("O email digitado já existe!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            conn.Close();
                        }
                            else
                            {

                                  FormularioUsuario.instance.FormularioUsuario_Shown(null,null);
                          

                            MessageBox.Show("Usuário registrado com sucesso!");
                            textprimeironome.Clear();
                            textultimonome.Clear();
                            textemail.Clear();
                            textsenha.Clear();
                            combousuario.SelectedIndex = -1;
                            pictureBox1.Image = null;

                           

                            conn.Close();

    
                            this.Close();

                        }
                        


                    }

                }
                else
                {
                    MessageBox.Show("É necessário preencher todos os campos", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("É necessário preencher todos os campos", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }

        }
        private void ShowImage(byte[] imageData)
        {
            // Converte o array de bytes em uma imagem e exibe na PictureBox
            MemoryStream ms = new MemoryStream(imageData);
            
                pictureBox1.Image = Image.FromStream(ms);
            
        }

        private byte[] getImage()
        {
            MemoryStream st = new MemoryStream();
            pictureBox1.Image.Save(st, pictureBox1.Image.RawFormat);

            return st.GetBuffer();

        }

        private void FormularioCRUDUsuario_Load(object sender, EventArgs e)
        {
            if(FormularioUsuario.selectedRow != null)
            {
                Stringid = FormularioUsuario.selectedRow.Cells[0].Value.ToString();
                textprimeironome.Text = FormularioUsuario.selectedRow.Cells[1].Value.ToString();
                textultimonome.Text = FormularioUsuario.selectedRow.Cells[2].Value.ToString();
                textemail.Text = FormularioUsuario.selectedRow.Cells[3].Value.ToString();
                textsenha.Text = FormularioUsuario.selectedRow.Cells[4].Value.ToString();
                if (FormularioUsuario.selectedRow.Cells[5].Value.ToString().Equals("Administrador"))
                {
                    combousuario.SelectedIndex = 0;

                }
                else
                {
                    combousuario.SelectedIndex = 1;
                }
                // Verifica se a célula contém uma imagem
                if (FormularioUsuario.selectedRow.Cells[6].Value != null && FormularioUsuario.selectedRow.Cells[6].Value is byte[])
                {
                    byte[] imageData = (byte[])FormularioUsuario.selectedRow.Cells[6].Value;
                    ShowImage(imageData);
                }
                else
                {
                    // Limpar a PictureBox se a célula não contiver uma imagem
                    pictureBox1.Image = null;
                }
                FormularioUsuario.selectedRow = null;
            }


        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(textemail.Text, textsenha.Text, textprimeironome.Text, textultimonome.Text, combousuario.SelectedItem.ToString());

            if (usuario.verificarEspacosVazios(2))
            {
                if (usuario.verificaEmail())
                {
                    SqlCommand cmd = new SqlCommand("AtualizaUsuario", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PrimeiroNome", textprimeironome.Text.Trim());
                    cmd.Parameters.AddWithValue("@UltimoNome", textultimonome.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", textemail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Senha", textsenha.Text.Trim());
                    cmd.Parameters.AddWithValue("@TipoDeUsuario", combousuario.SelectedItem.ToString());

                    // Adiciona a imagem atualizada
                    if (pictureBox1.Image != null)
                    {
                        cmd.Parameters.AddWithValue("@Foto", getImage());
                    }
                    else
                    {
                        cmd.Parameters.Add("@Foto", SqlDbType.Image, -1).Value = DBNull.Value;
                    }

                    cmd.Parameters.AddWithValue("@id_usuario", Stringid);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        int result = (int)reader["Result"];
                        if (result == 1)
                        {
                            MessageBox.Show("O email já existe!");
                        }
                        else
                        {
                            MessageBox.Show("Atualização feita com sucesso");
                            FormularioUsuario.instance.FormularioUsuario_Shown(null, null);
                            this.Close();
                        }
                    }
                    conn.Close();
                }
            }
        }


        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DeletaUsuario", conn);
                
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Verificar se o usuário existe
                cmd.Parameters.AddWithValue("@IdUsuario", Stringid);

                // Adicionar parâmetro de saída
                SqlParameter resultadoParam = new SqlParameter("@Resultado", SqlDbType.Int);
                resultadoParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(resultadoParam);

                // Executar o comando
                cmd.ExecuteNonQuery();

                // Obter o valor do parâmetro de saída
                int resultado = (int)cmd.Parameters["@Resultado"].Value;

                // Verificar o resultado e mostrar a mensagem apropriada
                if (resultado == 1)
                {
                    MessageBox.Show("Usuário não encontrado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {

                    DialogResult dr = MessageBox.Show("Deseja eliminar esse usuário?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (dr == DialogResult.Yes)
                    {
                        FormularioUsuario.instance.FormularioUsuario_Shown(null, null);
                        MessageBox.Show("Usuário eliminado com sucesso");

                        textprimeironome.Clear();
                        textultimonome.Clear();
                        textemail.Clear();
                        textsenha.Clear();
                        combousuario.SelectedIndex = -1;
                        pictureBox1.Image = null;
                        this.Hide();
                    }


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao eliminar usuário: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void FormularioCRUDUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
    
        }

        private void FormularioCRUDUsuario_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, Wm_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void quantidadeusuarios_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}