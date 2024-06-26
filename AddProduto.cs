using Guna.UI2.WinForms;
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
    public partial class AddProduto : Form
    {
        public String Stringid;

        private static BD bd = new BD();
        private SqlConnection conn = bd.conexao();
        Produto produto = new Produto();



        public AddProduto()
        {
            InitializeComponent();
        }

        private void AddProduto_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'sistemadefaturacaoDataSet10.produto'. Você pode movê-la ou removê-la conforme necessário.
            dataGridViewItem.DataSource = produto.BindData1();
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {


        }

        private void fillByToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
 

        private void dataGridViewItem_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
        public void BindData()
        {

            SqlCommand cmd = new SqlCommand("SELECT * From produto WHERE quantidade > 0 AND status = @status", conn);
            cmd.Parameters.AddWithValue("@status", "Ativo");
            SqlDataAdapter sd = new SqlDataAdapter();
            sd.SelectCommand = cmd;

            DataTable dt = new DataTable();
            dt.Clear();
            sd.Fill(dt);
            dataGridViewItem.DataSource = dt;
        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {
 
        }

        private void textid_TextChanged(object sender, EventArgs e)
        {
            if (textid.Text.Equals(""))
            {
               dataGridViewItem.DataSource = produto.BindData1();
            }
            else
            {
                dataGridViewItem.DataSource = produto.BindData1(textid.Text);

            }
        }

        private void dataGridViewItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
