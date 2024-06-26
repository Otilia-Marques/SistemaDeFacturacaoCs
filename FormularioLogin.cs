using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Font;
using iText.Layout.Borders;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Pdf.Canvas.Draw;
namespace SistemadeFaturacao
{/*
             if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, Wm_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
  */
    public partial class FormularioLogin : MetroFramework.Forms.MetroForm
    {
        public static FormularioLogin instance;
        public const int Wm_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]

        public static extern bool ReleaseCapture();

        public static BD bD = new BD();
        public SqlConnection conn = bD.conexao();
     
        public string stringemail;
        public FormularioLogin()
        {
            instance = this;
            InitializeComponent();
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ControlBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {


            String email = textemail1.Text;
            String senha = textsenha1.Text;

            Usuario usuario = new Usuario(email,senha);

            if(usuario.verificarEspacosVazios(1))
            {
                if(usuario.verificaEmail())
                {
                    if(usuario.loginUsuario())
                    {
                        textemail1.Clear();
                        textsenha1.Clear();
                        FormularioMenu menu = new FormularioMenu(email);
                        stringemail = email;
                        this.Hide();
                        menu.Show();
                    }

                }

            }

        }
     
        public String mail()
        {
            return stringemail;
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

       
       
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
   
        }

        private void FormularioLogin_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mousemove(object sender, MouseEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, Wm_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void metroPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, Wm_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
   
        }
        private void GerarPdf()
        {
            var arquivo = @"C:\Users\derio\Desktop\Preview.pdf";

            using (PdfWriter writer = new PdfWriter(arquivo))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    Paragraph footer = new Paragraph("A pagar mediante recibo\nObrigado pela sua encomenda!")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetMarginTop(20);
                    document.Add(footer);

                    document.Close();
                }
                System.Diagnostics.Process.Start("C:\\Users\\derio\\Desktop\\Preview.pdf");
            }

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            GerarPdf();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
