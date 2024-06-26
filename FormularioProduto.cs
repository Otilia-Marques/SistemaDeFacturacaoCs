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
    public partial class FormularioProduto : Form
    {
        public String Stringid;
        private static BD bd = new BD();
        private SqlConnection conn = bd.conexao();
        public static FormularioProduto instance;

        private Produto produto = new Produto();
        public FormularioProduto()
        {
            instance = this;
            InitializeComponent();
        }



        private void FormularioProduto_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'sistemaDeFacturacaoDataSet.produto'. Você pode movê-la ou removê-la conforme necessário.
            this.produtoTableAdapter2.Fill(this.sistemaDeFacturacaoDataSet.produto);
            

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormularioCRUDProduto formulario = new FormularioCRUDProduto();
            formulario.SetButtonVisibility(false, 1);

            formulario.ShowDialog();

        }
        public static DataGridViewRow selectedRow = null;

        private void dataGridViewUsuario_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = dataGridViewProduto.Rows[e.RowIndex];
                FormularioCRUDProduto formulario = new FormularioCRUDProduto();
                formulario.SetButtonVisibility(false, 2);
                formulario.ShowDialog();
                //  FormularioCRUDUsuario.GetFormularioCRUDUsuario.ShowDialog();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
     
        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {

        }

        private void produtoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
           
        }

        private void textid_TextChanged(object sender, EventArgs e)
        {
            if (textid.Text.Equals(""))
            {
                dataGridViewProduto.DataSource = produto.BindData();
            }
            else
            {

                dataGridViewProduto.DataSource = produto.BindData(textid.Text);


            }

        }

        public void FormularioProduto_Shown(object sender, EventArgs e)
        {
            this.produtoTableAdapter2.Fill(this.sistemaDeFacturacaoDataSet.produto);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}