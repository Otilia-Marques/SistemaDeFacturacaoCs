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
    public partial class FormularioTaxa : Form
    {
        public String Stringid;
        private static BD bd = new BD();
        private SqlConnection conn = bd.conexao();
        public static FormularioTaxa instance;

        private Taxa taxa = new Taxa();

        public FormularioTaxa()
        {
            instance = this;
            InitializeComponent();
        }

        private void FormularioTaxa_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'sistemaDeFacturacaoDataSet2.taxa_iva'. Você pode movê-la ou removê-la conforme necessário.
            this.taxa_ivaTableAdapter.Fill(this.sistemaDeFacturacaoDataSet2.taxa_iva);
            

        }

        private void btnpesquisar_Click(object sender, EventArgs e)
        {
 

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormularioCRUDTaxa formulario = new FormularioCRUDTaxa();
            formulario.SetButtonVisibility(false, 1);

            formulario.ShowDialog();
        }
        public static DataGridViewRow selectedRow = null;

        private void dataGridViewTaxa_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = dataGridViewTaxa.Rows[e.RowIndex];
                FormularioCRUDTaxa formulario = new FormularioCRUDTaxa();
                formulario.SetButtonVisibility(false, 2);
                formulario.ShowDialog();
                //  FormularioCRUDUsuario.GetFormularioCRUDUsuario.ShowDialog();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
    
        }

        public void FormularioTaxa_Shown(object sender, EventArgs e)
        {
            this.taxa_ivaTableAdapter.Fill(this.sistemaDeFacturacaoDataSet2.taxa_iva);
        }

        private void textid_TextChanged(object sender, EventArgs e)
        {
            if (textid.Text.Equals(""))
            {
                dataGridViewTaxa.DataSource = taxa.BindData();
            }
            else
            {
                dataGridViewTaxa.DataSource = taxa.BindData(textid.Text);



            }
        }
    }
}
