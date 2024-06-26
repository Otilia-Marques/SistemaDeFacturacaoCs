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

namespace SistemadeFaturacao
{
    public partial class FormularioCategoria : Form
    {
        public String Stringid;
        public static FormularioCategoria instance;
        private static BD bd = new BD();
        private SqlConnection conn = bd.conexao();
        private Categoria categoria = new Categoria();

  
        public FormularioCategoria()
        {
            instance = this;
            InitializeComponent();
        }

        private void FormularioCategoria_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'sistemaDeFacturacaoDataSet1.categoria'. Você pode movê-la ou removê-la conforme necessário.
            this.categoriaTableAdapter1.Fill(this.sistemaDeFacturacaoDataSet1.categoria);
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormularioCRUDCategoria formulario = new FormularioCRUDCategoria();
            formulario.SetButtonVisibility(false, 1);

            formulario.ShowDialog();

        }
        public static DataGridViewRow selectedRow = null;

        private void dataGridViewCategoria_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = dataGridViewCategoria.Rows[e.RowIndex];
                FormularioCRUDCategoria formulario = new FormularioCRUDCategoria();
                formulario.SetButtonVisibility(false, 2);
                formulario.ShowDialog();
    
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
             
        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {
 
        }

        private void textid_TextChanged(object sender, EventArgs e)
        {
            if (textid.Text.Equals(""))
            {
                dataGridViewCategoria.DataSource = categoria.BindData();
            }
            else
            {

                dataGridViewCategoria.DataSource = categoria.BindData(textid.Text);



            }
        }

        public void FormularioCategoria_Shown(object sender, EventArgs e)
        {
            this.categoriaTableAdapter1.Fill(this.sistemaDeFacturacaoDataSet1.categoria);
        }
    }
}
