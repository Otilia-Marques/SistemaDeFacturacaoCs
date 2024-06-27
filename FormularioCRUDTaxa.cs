using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace SistemadeFaturacao
{
    public partial class FormularioCRUDTaxa : Form
    {
        public String Stringid;
        private static BD bd = new BD();
        private SqlConnection conn = bd.conexao();
        public const int Wm_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]

        public static extern bool ReleaseCapture();


        public static FormularioCRUDTaxa frm;

        public static FormularioCRUDTaxa GetFormularioCRUDTaxa
        {
            get
            {
                if (frm == null)
                {
                    frm = new FormularioCRUDTaxa();
                }
                return frm;
            }
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

            //  ButtonC.Visible = isVisible;
        }
        public FormularioCRUDTaxa()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String descricao = textdescricao.Text;
            String taxa = texttaxa.Text;
            String data = guna2DateTimePicker1.Text;

            if (comboativo.SelectedItem != null)
            {
                String estado = comboativo.SelectedItem.ToString();

                Taxa novaTaxa = new Taxa(taxa, data, descricao, estado);

                if (novaTaxa.verificarEspacosVazios())
                {
                    if (novaTaxa.IsNumber(taxa))
                    {
                        decimal numero;
                        // Usa a cultura en-US para garantir a conversão correta de ponto decimal
                        if (decimal.TryParse(taxa, System.Globalization.NumberStyles.Any, new System.Globalization.CultureInfo("en-US"), out numero))
                        {
                            if ((numero >= 0) && (numero <= 100))
                            {
                                if (novaTaxa.addTaxa())
                                {
                                    FormularioTaxa.instance.FormularioTaxa_Shown(null, null);
                                    texttaxa.Clear();
                                    textdescricao.Clear();
                                    guna2DateTimePicker1.Value = DateTime.Now;
                                    comboativo.SelectedIndex = -1;

                                    this.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Taxa inválida", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Taxa inválida", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("É necessário preencher todos os campos", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void FormularioCRUDTaxa_Load(object sender, EventArgs e)
        {
            if (FormularioTaxa.selectedRow != null)
            {


                Stringid = FormularioTaxa.selectedRow.Cells[0].Value.ToString();
                guna2DateTimePicker1.Value = Convert.ToDateTime(FormularioTaxa.selectedRow.Cells[1].Value.ToString());

                texttaxa.Text = SubstituirVirgulasPorPontos(FormularioTaxa.selectedRow.Cells[2].Value.ToString());
           
                textdescricao.Text = FormularioTaxa.selectedRow.Cells[3].Value.ToString();
                if (FormularioTaxa.selectedRow.Cells[4].Value.ToString().Equals("Ativa"))
                {
                    comboativo.SelectedIndex = 0;

                }
                else
                {
                    comboativo.SelectedIndex = 1;
                }
  
                FormularioTaxa.selectedRow = null;
            }


        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Validar se o valor da taxa é um número decimal válido
            decimal taxa;
            if (!decimal.TryParse(texttaxa.Text, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture, out taxa))
            {
                MessageBox.Show("Valor da taxa não é um número decimal válido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar se há espaços vazios nos campos obrigatórios
            Taxa novaTaxa = new Taxa(texttaxa.Text, guna2DateTimePicker1.Text, textdescricao.Text, comboativo.SelectedItem.ToString());
            if (novaTaxa.verificarEspacosVazios())
            {
                if((taxa >= 0) && (taxa <100))
                    {
                    SqlCommand cmd = new SqlCommand("AtualizaTaxa", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Definir parâmetros do comando SQL
                    cmd.Parameters.AddWithValue("@Taxa", taxa);
                    cmd.Parameters.AddWithValue("@Data_Vigencia", guna2DateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("@Descricao", textdescricao.Text);
                    cmd.Parameters.AddWithValue("@Ativo", comboativo.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@id_taxa", Stringid); // Certifique-se de definir isso corretamente

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int result = (int)reader["Result"];
                            if (result == 1)
                            {
                                MessageBox.Show("A taxa já existe!");
                            }
                            else
                            {
                                // Atualização bem-sucedida
                                FormularioTaxa.instance.FormularioTaxa_Shown(null, null);
                                MessageBox.Show("Atualização feita com sucesso");
                                this.Close();
                            }
                        }
                    }

                    catch (SqlException ex)
                    {
                        MessageBox.Show("Erro ao executar a atualização da taxa: " + ex.Message, "Erro SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Taxa inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string SubstituirVirgulasPorPontos(string input)
        {
            return input.Replace(',', '.');
        }


        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            String descricao = textdescricao.Text.Trim();
            String taxa = texttaxa.Text.Trim();
            String data = guna2DateTimePicker1.Text.Trim();

            Taxa novaTaxa = new Taxa();
            if (novaTaxa.deleteTaxa(Stringid))
            {
                FormularioTaxa.instance.FormularioTaxa_Shown(null, null);


                texttaxa.Clear();
                textdescricao.Clear();
                guna2DateTimePicker1.Value = DateTime.Now;
                comboativo.SelectedIndex = -1;
                this.Close();
            }
        }

        private void FormularioCRUDTaxa_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, Wm_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
