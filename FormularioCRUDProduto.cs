using iText.StyledXmlParser.Jsoup.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SistemadeFaturacao
{
    public partial class FormularioCRUDProduto : Form
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

        public static FormularioCRUDProduto frm;

        public static FormularioCRUDProduto GetFormularioCRUDProduto
        {
            get
            {
                if (frm == null)
                {
                    frm = new FormularioCRUDProduto();
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

        public FormularioCRUDProduto()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void ShowImage(byte[] imageData)
        {
            // Converte o array de bytes em uma imagem e exibe na PictureBox
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                pictureBox1.Image = Image.FromStream(ms);
            }
        }
       
        private byte[] getImage()
        {
            MemoryStream st = new MemoryStream();
            pictureBox1.Image.Save(st, pictureBox1.Image.RawFormat);

            return st.GetBuffer();

        }
        private void FormularioCRUDProduto_Load(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("getcategoriasetaxas", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = cmd.ExecuteReader();

            // Processar os resultados da primeira consulta (categorias)
            combocategoria.Items.Clear();
            while (rdr.Read())
            {
                combocategoria.Items.Add(rdr["nome"].ToString());
            }

            // Ler resultados da segunda consulta (taxas)
            if (rdr.NextResult())
            {
                combotaxa.Items.Clear();
                while (rdr.Read())
                {
                    combotaxa.Items.Add(rdr["taxa"].ToString());
                }
            }

            rdr.Close(); // Fechar o DataReader

            if (FormularioProduto.selectedRow != null)
            {
                Stringid = FormularioProduto.selectedRow.Cells[0].Value.ToString();
                textcodigobarra.Text = FormularioProduto.selectedRow.Cells[1].Value.ToString();
                textnome.Text = FormularioProduto.selectedRow.Cells[2].Value.ToString();
                textdescricao.Text = FormularioProduto.selectedRow.Cells[3].Value.ToString();
                String categoria = FormularioProduto.selectedRow.Cells[4].Value.ToString();


                SqlCommand getCategoryIDCmd = new SqlCommand("SELECT nome FROM categoria WHERE id_categoria = @id_categoria", conn);
                getCategoryIDCmd.Parameters.AddWithValue("@id_categoria", Convert.ToInt64(categoria));
                SqlDataReader reader = getCategoryIDCmd.ExecuteReader();

                String cat = null;
                if (reader.Read())
                {
                    cat = reader["nome"].ToString();
                }
                reader.Close();



                int a = 0;
                for (int i = 0; i < combocategoria.Items.Count; i++)
                {
                    if (combocategoria.Items[i].ToString().Equals(cat))
                    {
                        a = i;
                        break;
                    }
                }
                combocategoria.SelectedIndex = a;

                textpreco.Text = SubstituirVirgulasPorPontos(FormularioProduto.selectedRow.Cells[5].Value.ToString());
                textquantidade.Text = FormularioProduto.selectedRow.Cells[6].Value.ToString();
                String taxa = FormularioProduto.selectedRow.Cells[7].Value.ToString();

                SqlCommand getTaxaIDCmd = new SqlCommand("SELECT taxa FROM taxa_iva WHERE id_taxa_iva = @id_taxa_iva", conn);
                getTaxaIDCmd.Parameters.AddWithValue("@id_taxa_iva", Convert.ToInt64(taxa));
                SqlDataReader reader1 = getTaxaIDCmd.ExecuteReader();

                String tax = null;
                if (reader1.Read())
                {
                    tax = reader1["taxa"].ToString();
                }
                reader1.Close();



                 a = 0;
                for (int i = 0; i < combotaxa.Items.Count; i++)
                {
                    if (combotaxa.Items[i].ToString().Equals(tax))
                    {
                        a = i;
                        break;
                    }
                }
                combotaxa.SelectedIndex = a;


                if (FormularioProduto.selectedRow.Cells[8].Value.ToString().Equals("Ativo"))
                {
                    combostatus.SelectedIndex = 0;
                }
                else
                {
                    combostatus.SelectedIndex = 1;
                }

                if (FormularioProduto.selectedRow.Cells[9].Value != DBNull.Value)
                {
                    byte[] imageData = (byte[])FormularioProduto.selectedRow.Cells[9].Value;
                    ShowImage(imageData);
                }

                FormularioProduto.selectedRow = null;
            }

            conn.Close();
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            String codigobarra = textcodigobarra.Text.Trim();
            String descricao = textdescricao.Text.Trim();
            String quantidade = textquantidade.Text.Trim();
            String nome = textnome.Text.Trim();
            String preco = textpreco.Text.Trim();

            if(combotaxa.SelectedItem == null || combocategoria.SelectedItem == null || combostatus.SelectedItem == null)
            {
                MessageBox.Show("É necessário preencher todos os campos", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            String taxa = combotaxa.SelectedItem.ToString();
                String status = combostatus.SelectedItem.ToString();
                String categoria = combocategoria.SelectedItem.ToString();

                Produto produto = new Produto(nome, codigobarra, descricao, preco, quantidade, status, taxa, categoria);

                if(produto.verificarEspacosVazios())
                {

                    if(produto.contemLetra() && produto.contemEspaco() && codigobarra.Length == 13)
                    {
                     
                          




       if (produto.IsNumber(quantidade, 1))

                                    {
                                        if (produto.IsNumber(preco, 2))
                                        {
                                            int numero;
                                            decimal numero1;

                                            // Usa a cultura en-US para garantir a conversão correta de ponto decimal
                                            if (decimal.TryParse(preco, System.Globalization.NumberStyles.Any, new System.Globalization.CultureInfo("en-US"), out numero1))
                                            {
                                                if (numero1 >= 0)
                                                {
                                                    if (int.TryParse(quantidade, System.Globalization.NumberStyles.Any, new System.Globalization.CultureInfo("en-US"), out numero))
                                                    {
                                                        if (numero >= 0)
                                                        {
                                                if (pictureBox1.Image != null)
                                                {
                                                    conn.Open();

                                                    SqlCommand cmd = new SqlCommand("ValidaRegistroProduto", conn);

                                                    cmd.CommandType = CommandType.StoredProcedure;

                                                    cmd.Parameters.AddWithValue("@codigo_produto", codigobarra);
                                                    cmd.Parameters.AddWithValue("@nome", nome);
                                                    cmd.Parameters.AddWithValue("@descricao", descricao);
                                                    cmd.Parameters.AddWithValue("@categoria", categoria);
                                                    cmd.Parameters.AddWithValue("@preco", Convert.ToDecimal(textpreco.Text));
                                                    cmd.Parameters.AddWithValue("@quantidade", Convert.ToInt32(textquantidade.Text));
                                                    cmd.Parameters.AddWithValue("@taxa", Convert.ToDecimal(combotaxa.SelectedItem.ToString()));
                                                    cmd.Parameters.AddWithValue("@status", status);


                                                    cmd.Parameters.AddWithValue("@foto", getImage());


                                                    SqlParameter resultadoParam = new SqlParameter("@resultado", SqlDbType.Int);
                                                    resultadoParam.Direction = ParameterDirection.Output;
                                                    cmd.Parameters.Add(resultadoParam);

                                                    cmd.ExecuteNonQuery();

                                                    int resultado = (int)cmd.Parameters["@resultado"].Value;

                                                    if (resultado == 1)
                                                    {
                                                        MessageBox.Show("O código de barra digitado já existe!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                        conn.Close();
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Produto inserido com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        textcodigobarra.Clear();
                                                        textnome.Clear();
                                                        textdescricao.Clear();
                                                        textpreco.Clear();
                                                        textquantidade.Clear();
                                                        combostatus.SelectedIndex = -1;
                                                        combotaxa.SelectedIndex = -1;
                                                        combocategoria.SelectedIndex = -1;
                                                        pictureBox1.Image = null;


                                                        conn.Close();
                                                        FormularioProduto.instance.FormularioProduto_Shown(null, null);
                                                        this.Close();

                                                    }

                                                }
                                                else
                                                {
                                                    MessageBox.Show("A imagem do produto é obrigatória", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                }



                                            }
                                                        else
                                                        {
                                                            MessageBox.Show("Quantidade inválida", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Quantidade inválida", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Preço inválido", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Preço inválido", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            }




                                        }
                                        else
                                        {
                                            MessageBox.Show("Por favor, digite um preço válido", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                        }

                                    }
       else
                                    {
                                        MessageBox.Show("Por favor, digite uma quantidade válida", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    }

    


                                
                
                    }
                    else
                    {
                        MessageBox.Show("O código de barra está no formato incorreto", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }


                }





            
        
            
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }
        public static string SubstituirVirgulasPorPontos(string input)
        {
            return input.Replace(',', '.');
        }


        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto(textnome.Text, textcodigobarra.Text, textdescricao.Text, textpreco.Text, textquantidade.Text, combostatus.SelectedItem.ToString(), combocategoria.SelectedItem.ToString(), combotaxa.SelectedItem.ToString());
 

            if (produto.verificarEspacosVazios())
            {
                if (produto.contemLetra() && produto.contemEspaco() && (textcodigobarra.Text.Length == 13))
                {
               
                      
                                if (produto.IsNumber(textquantidade.Text, 1))
                                {
                                    if (produto.IsNumber(textpreco.Text, 2))
                                    {
                                        int numero;
                                        decimal numero1;

                                        // Usa a cultura en-US para garantir a conversão correta de ponto decimal
                                        if (decimal.TryParse(textpreco.Text, System.Globalization.NumberStyles.Any, new System.Globalization.CultureInfo("en-US"), out numero1))
                                        {
                                            if (numero1 >= 0)
                                            {
                                                if (int.TryParse(textquantidade.Text, System.Globalization.NumberStyles.Any, new System.Globalization.CultureInfo("en-US"), out numero))
                                                {
                                                    if (numero >= 0)
                                                    {
                                       conn.Open();


                                                SqlCommand cmd = new SqlCommand("AtualizaProduto", conn)
                                                {
                                                    CommandType = CommandType.StoredProcedure
                                                };

                                                cmd.Parameters.AddWithValue("@id_produto", Stringid);
                                                cmd.Parameters.AddWithValue("@codigo_produto", textcodigobarra.Text.Trim());
                                                cmd.Parameters.AddWithValue("@nome", textnome.Text.Trim());
                                                cmd.Parameters.AddWithValue("@descricao", textdescricao.Text.Trim());
                                                cmd.Parameters.AddWithValue("@categoria", combocategoria.SelectedItem.ToString().Trim());
                                                cmd.Parameters.AddWithValue("@preco", numero1);
                                                cmd.Parameters.AddWithValue("@quantidade", numero);
                                                cmd.Parameters.AddWithValue("@taxa", Convert.ToDecimal(combotaxa.SelectedItem.ToString().Trim()));
                                                cmd.Parameters.AddWithValue("@status", combostatus.SelectedItem.ToString().Trim());


                                                cmd.Parameters.AddWithValue("@foto", getImage());


                                                cmd.ExecuteNonQuery();

                                                conn.Close();
                                                FormularioProduto.instance.FormularioProduto_Shown(null, null);

                                                MessageBox.Show("Atualização feita com sucesso");
                                                this.Close();
                                   

                                        }
                                                    else
                                                    {
                                                        MessageBox.Show("Quantidade inválida", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Quantidade inválida", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Preço inválido", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Preço inválido", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Por favor, digite um preço válido", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Por favor, digite uma quantidade válida", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                        
               
                }
                else
                {
                    MessageBox.Show("O código de barra está no formato incorreto", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DeletaProduto", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                // Verificar se o usuário existe
                cmd.Parameters.AddWithValue("@IdProduto", Stringid);

                // Adicionar parâmetro de saída
                SqlParameter resultadoParam = new SqlParameter("@Resultado", SqlDbType.Int);
                resultadoParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(resultadoParam);

                // Executar o comando
                cmd.ExecuteNonQuery();

                // Obter o valor do parâmetro de saída
                int resultado = (int)cmd.Parameters["@Resultado"].Value;

                // Verificar o resultado e mostrar a mensagem apropriada
                if (resultado == 1)
                {
                    MessageBox.Show("Produto não encontrado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {

                    DialogResult dr = MessageBox.Show("Tem a certeza de que deseja eliminar esse produto?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (dr == DialogResult.Yes)
                    {
                        FormularioProduto.instance.FormularioProduto_Shown(null, null);
                        MessageBox.Show("Produto eliminado com sucesso");
                        conn.Close();
                        textcodigobarra.Clear();
                        textnome.Clear();
                        textdescricao.Clear();
                        textpreco.Clear();
                        textquantidade.Clear();
                        combostatus.SelectedIndex = -1;
                        combotaxa.SelectedIndex = -1;
                        combocategoria.SelectedIndex = -1;
                        pictureBox1.Image = null;



                        FormularioProduto.instance.FormularioProduto_Shown(null, null);
                        this.Close();
                    }


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao eliminar produto: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void FormularioCRUDProduto_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, Wm_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
