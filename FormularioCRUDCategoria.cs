using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemadeFaturacao
{
    public partial class FormularioCRUDCategoria : Form
    {
        public const int Wm_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]

        public static extern bool ReleaseCapture();

        public String Stringid;
        private static BD bd = new BD();
        private SqlConnection conn = bd.conexao();

        public static FormularioCRUDCategoria frm;

        public static FormularioCRUDCategoria GetFormularioCRUDCategoria
        {
            get
            {
                if (frm == null)
                {
                    frm = new FormularioCRUDCategoria();
                }
                return frm;
            }
        }
        public FormularioCRUDCategoria()
        {
            InitializeComponent();
        }
        public void SetButtonVisibility(bool isVisible, int n)
        {
            if (n == 1)
            {
                guna2Button4.Visible = isVisible;
                guna2Button3.Visible = isVisible;
                guna2Button1.Visible = true;
            }
            else
                if (n == 2)
            {
                guna2Button4.Visible = true;
                guna2Button3.Visible = true;
                guna2Button1.Visible = isVisible;
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            String nome = textcategoria.Text.Trim();

            Categoria categoria = new Categoria(nome);

            if (categoria.verificarEspacosVazios())
            {
                if(categoria.addCategoria())
                {
                    textcategoria.Clear();
                    FormularioCategoria.instance.FormularioCategoria_Shown(null, null);
                    this.Close();
                }

            }

        }

        private void FormularioCRUDCategoria_Load(object sender, EventArgs e)
        {
            if (FormularioCategoria.selectedRow != null)
            {
                Stringid = FormularioCategoria.selectedRow.Cells[0].Value.ToString();
                textcategoria.Text = FormularioCategoria.selectedRow.Cells[1].Value.ToString();
                FormularioCategoria.selectedRow = null;
            }


        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria(textcategoria.Text);

            if (categoria.verificarEspacosVazios())
            {
                SqlCommand cmd = new SqlCommand("AtualizaCategoria", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nome", textcategoria.Text.Trim());
                cmd.Parameters.AddWithValue("@id_categoria", Stringid);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int result = (int)reader["Result"];
                    if (result == 1)
                    {
                        MessageBox.Show("O Nome já existe!");
                    }
                    else
                    {
                        MessageBox.Show("Atualização feita com sucesso");
                        FormularioCategoria.instance.FormularioCategoria_Shown(null, null);
                        this.Close();
                    }
                }
                conn.Close();
            }
        }


        private void guna2Button4_Click(object sender, EventArgs e)
        {
            String nome = textcategoria.Text.Trim();

            Categoria categoria = new Categoria();

           if (categoria.deleteCategoria(Stringid))
            {
                FormularioCategoria.instance.FormularioCategoria_Shown(null, null);


                textcategoria.Clear();
                this.Close();
            }

  
        }

        private void FormularioCRUDCategoria_MouseEnter(object sender, EventArgs e)
        {

        }

        private void FormularioCRUDCategoria_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, Wm_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
