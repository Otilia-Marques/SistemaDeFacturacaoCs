using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemadeFaturacao
{
    public partial class FormularioValor : Form
    {
        public const int Wm_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]

        public static extern bool ReleaseCapture();

        public static FormularioValor instance;
        public string pagamento;
        public decimal valrop;
        public bool passa = true;
        public FormularioValor()
        {
            instance = this;
            InitializeComponent();
        }
        public bool IsNumber(string input)
        {
            // Expressão regular para verificar se a string é um número inteiro ou decimal
            string pattern = @"^(?!-)[+]?(?:\d+\.\d+|\d+)$";

            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Entrada incorreta", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
             if (combopagamento.SelectedIndex != -1)
            {

                if (!textvalor.Text.Equals(""))
                {
                    pagamento = combopagamento.SelectedItem.ToString();
                    if (IsNumber(textvalor.Text))
                    {
                        decimal numero;
                        // Usa a cultura en-US para garantir a conversão correta de ponto decimal
                        if (decimal.TryParse(textvalor.Text, System.Globalization.NumberStyles.Any, new System.Globalization.CultureInfo("en-US"), out numero))
                        {
                            if (numero >= 0)
                            {
                                if (numero >= FormularioCRUDVenda.instance.total())
                                {
                                    FormularioVenda.instance.FormularioVenda_Shown(null, null);
                                    valrop = numero;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("O valor é insuficiente", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                }

                            }
                            else
                            {
                                MessageBox.Show("Valor inválido", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Valor inválido", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Digite o valor", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
             else
            {
                MessageBox.Show("Escolha um tipo de pagamento", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void FormularioValor_Load(object sender, EventArgs e)
        {
            label1.Text = FormularioCRUDVenda.instance.total().ToString() + " kz";
        }
        public decimal valor()
        {

            return valrop;

        }
        public string paga()
        {

            return pagamento;

        }
        public bool verifica()
        {

            return passa;

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            if ((combopagamento.SelectedIndex == -1) || (textvalor.Text.Equals(""))) {
                passa = false;
            }
        }

        private void FormularioValor_MouseDown(object sender, MouseEventArgs e)
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

        private void combopagamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void quantidadeusuarios_Click(object sender, EventArgs e)
        {

        }
    }
}
