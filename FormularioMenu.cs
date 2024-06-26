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
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SistemadeFaturacao
{

    public partial class FormularioMenu : MetroFramework.Forms.MetroForm
    {
        public const int Wm_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]

        public static extern bool ReleaseCapture();


        private static BD bd = new BD();
        private SqlConnection conn = bd.conexao();

        public String stringemaillogado;
        public FormularioMenu(string stringemaillogado)
        {
            InitializeComponent();
            this.stringemaillogado = stringemaillogado;
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ControlBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            labelopcao.Text = "Dashboard";
            pictureopcao.Image = Properties.Resources.data;
            container(new FormularioDashboard());
        }
        private void container(object formulario)
        {
            if (formpanel.Controls.Count > 0) formpanel.Controls.Clear();

            Form form = formulario as Form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            formpanel.Controls.Add(form);
            formpanel.Tag = form;
            form.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            labelopcao.Text = "Usuários";
            pictureopcao.Image = Properties.Resources.worker;
            container(new FormularioUsuario());
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            labelopcao.Text = "Categoria de Produtos";
            pictureopcao.Image = Properties.Resources.category_8428362;
            container(new FormularioCategoria());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            labelopcao.Text = "Taxas";
            pictureopcao.Image = Properties.Resources.percentagem;
            container(new FormularioTaxa());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            labelopcao.Text = "Produtos";
            pictureopcao.Image = Properties.Resources.dairy_products;
            container(new FormularioProduto());
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            labelopcao.Text = "Vendas";
            pictureopcao.Image = Properties.Resources.terminal_pos;

            container(new FormularioVenda());
        }

        private void FormularioMenu_Load(object sender, EventArgs e)
        {
         
            conn.Open();
       
            SqlCommand getCategoryIDCmd = new SqlCommand("SELECT * FROM usuario WHERE email = @email", conn);
            getCategoryIDCmd.Parameters.AddWithValue("@email", stringemaillogado);
            // int codigo = (int)getCategoryIDCmd.ExecuteScalar();

            SqlDataReader reader = getCategoryIDCmd.ExecuteReader();

        
            if (reader.Read())
            {
                if(!reader["tipodeusuario"].ToString().Equals("Administrador"))
                {
                    btnusuario.Visible = false;
                    guna2Button4.Visible = false;
                    guna2Button3.Visible = false;
                    guna2Button7.Visible = false;
                }
        

                label1.Text =reader["primeironome"].ToString() + " " + reader["ultimonome"].ToString();
                label2.Text = reader["tipodeusuario"].ToString();

            
                    byte[] imageData = (byte[])reader["foto"];
                MemoryStream ms = new MemoryStream(imageData);
                    
                        guna2CirclePictureBox1.Image = Image.FromStream(ms);
                    
                
        

            }
       
            reader.Close();

            conn.Close();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Deseja sair?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Yes)
            {
                this.Hide();
                FormularioLogin menu = new FormularioLogin();
                menu.Show();

            }
            
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            labelopcao.Text = "Relatórios";
            pictureopcao.Image = Properties.Resources.report;
          //  container(new());
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, Wm_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
