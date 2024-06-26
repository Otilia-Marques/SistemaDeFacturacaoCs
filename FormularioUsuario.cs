using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace SistemadeFaturacao
{
    public partial class FormularioUsuario : Form
    {
        public static FormularioUsuario instance;

        private static BD bd = new BD();
        private SqlConnection conn = bd.conexao();
        private Usuario usuario = new Usuario();

        public FormularioUsuario()
        {
            InitializeComponent();
            instance = this;

        }

        private void FormularioUsuario_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'sistemaDeFacturacaoDataSet3.usuario'. Você pode movê-la ou removê-la conforme necessário.
            this.usuarioTableAdapter1.Fill(this.sistemaDeFacturacaoDataSet3.usuario);
            
       }
 

        private void dataGridViewUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
       
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

            FormularioCRUDUsuario formulario = new FormularioCRUDUsuario();
            formulario.SetButtonVisibility(false, 1);
      
            formulario.ShowDialog();
       
      }
        public static DataGridViewRow selectedRow = null;

        private void dataGridViewUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewUsuario_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = dataGridViewUsuario.Rows[e.RowIndex];
                FormularioCRUDUsuario formulario = new FormularioCRUDUsuario();
                formulario.SetButtonVisibility(false, 2);
                formulario.ShowDialog();
          }

        }
 
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            dataGridViewUsuario.DataSource = usuario.BindData();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
        
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void textid_TextChanged(object sender, EventArgs e)
        {
            if (textid.Text.Equals(""))
            {
                dataGridViewUsuario.DataSource = usuario.BindData();
            }
            else
            {
                dataGridViewUsuario.DataSource = usuario.BindData(textid.Text);
            }
        }

        public void FormularioUsuario_Shown(object sender, EventArgs e)
        {
            this.usuarioTableAdapter1.Fill(this.sistemaDeFacturacaoDataSet3.usuario);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }

        private void dataGridViewUsuario_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
   
        }

        private void dataGridViewUsuario_DataSourceChanged(object sender, EventArgs e)
        {
         
        }

        private void dataGridViewUsuario_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
  
        }
    }
}
