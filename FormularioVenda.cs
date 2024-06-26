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
    public partial class FormularioVenda : Form
    {

        private static BD bd = new BD();
        private SqlConnection conn = bd.conexao();

        public static FormularioVenda instance;

        public string Stringemail;
        public FormularioVenda()
        {
            instance = this;
            InitializeComponent();
        }

        public FormularioVenda(string stringemail)
        {
            instance = this;
            InitializeComponent();
        }


        private void guna2Button4_Click(object sender, EventArgs e)
        {





            FormularioCRUDVenda formulario = new FormularioCRUDVenda();
            formulario.ShowDialog();
        }

        private void FormularioVenda_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'sistemaDeFacturacaoDataSet4.vendas'. Você pode movê-la ou removê-la conforme necessário.
            this.vendasTableAdapter1.Fill(this.sistemaDeFacturacaoDataSet4.vendas);
          
            
    //        FormularioVenda formularioCRUDVenda = new FormularioVenda(Stringemail);

        }

        public void FormularioVenda_Shown(object sender, EventArgs e)
        {
            this.vendasTableAdapter1.Fill(this.sistemaDeFacturacaoDataSet4.vendas);
        }
    }
}
    

