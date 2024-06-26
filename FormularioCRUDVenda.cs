using Guna.UI2.WinForms;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using iText.Layout.Borders;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SistemadeFaturacao
{
    public partial class FormularioCRUDVenda : Form
    {
        public String Stringid;
        public static FormularioCRUDVenda instance;

        public int vendaid;
        public decimal totaltotal = 0;

        private static BD bd = new BD();
        private SqlConnection conn = bd.conexao();

        public string Stringemail;
        public int quant;
        public FormularioLogin login;
        public decimal troco;

        public String codigo_produto;
        string primeiroNome;
        string ultimoNome;
        public decimal desconto = 0;
        public FormularioCRUDVenda()
        {
            instance = this;
            InitializeComponent();
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {

            AddProduto formulario = new AddProduto();
            formulario.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }
        DataTable dt = new DataTable();
        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(guna2TextBox1.Text))
            {
                MessageBox.Show("Escolha uma quantidade", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (combo.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um produto", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!long.TryParse(guna2TextBox1.Text, out long quantidade))
            {
                MessageBox.Show("Escolha uma quantidade válida", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if ((quantidade > quant) && (quantidade <= 0))
            {
                MessageBox.Show("Escolha uma quantidade válida", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                conn.Open();

                string codigo_produto = combo.SelectedItem.ToString();
                SqlCommand getCategoryIDCmd = new SqlCommand("SELECT * FROM produto WHERE codigo_produto = @codigo_produto", conn);
                getCategoryIDCmd.Parameters.AddWithValue("@codigo_produto", Convert.ToInt64(combo.SelectedItem.ToString()));
                SqlDataReader reader = getCategoryIDCmd.ExecuteReader();

                decimal preco = 0;
                int imposto_id = 0;
                if (reader.Read())
                {
                    preco = Convert.ToDecimal(reader["preco"]);
                    imposto_id = Convert.ToInt16(reader["imposto_id"]);
                }
                reader.Close();

                SqlCommand getCategoryIDCmdd = new SqlCommand("SELECT taxa FROM taxa_iva WHERE id_taxa_iva = @id", conn);
                getCategoryIDCmdd.Parameters.AddWithValue("@id", imposto_id);
                decimal taxa_iva = (decimal)getCategoryIDCmdd.ExecuteScalar();

                decimal totalSemIva = quantidade * preco;
                decimal valorIva = totalSemIva * (taxa_iva / 100);
                decimal totalComIva = totalSemIva + valorIva;


                totaltotal += totalComIva;

                dt.Rows.Add(codigo_produto, quantidade, preco, taxa_iva, totalComIva);

                string updateQuery = "UPDATE produto SET quantidade = quantidade - @quant WHERE codigo_produto = @codigo_produto";
                SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                updateCmd.Parameters.AddWithValue("@quant", quantidade);
                updateCmd.Parameters.AddWithValue("@codigo_produto", codigo_produto);
                updateCmd.ExecuteNonQuery();

                conn.Close();

                labelnome.Text = "";
                labelpreco.Text = "";
                label3.Text = "";
                label7.Text = "";
                guna2TextBox1.Text = "";
                combo.SelectedIndex = -1;

                label8.Text = totaltotal.ToString() + " kz";
            }
        }
        private void FormularioCRUDVenda_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("codigo_produto", typeof(String));
            dt.Columns.Add("quantidade", typeof(int));
            dt.Columns.Add("preco", typeof(decimal));
            dt.Columns.Add("taxa_iva", typeof(decimal));
            dt.Columns.Add("total", typeof(decimal));
            guna2DataGridView1.DataSource = dt;

            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT codigo_produto FROM produto WHERE quantidade > 0 AND status = @status", conn);
            cmd.Parameters.AddWithValue("@status", "Ativo");


            SqlDataReader rdr = cmd.ExecuteReader();

            combo.Items.Clear();
            while (rdr.Read())
            {
                combo.Items.Add(rdr["codigo_produto"].ToString());
            }
            rdr.Close(); // Fechando o primeiro DataReader
            conn.Close();

        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo.SelectedIndex == -1)
            {
                labelnome.Text = "";
                labelpreco.Text = "";
                label3.Text = "";
                label7.Text = "";
            }
            else
            {
                conn.Open();

                codigo_produto = combo.SelectedItem.ToString();
                SqlCommand getCategoryIDCmd = new SqlCommand("SELECT nome FROM produto WHERE codigo_produto = @codigo_produto", conn);
                getCategoryIDCmd.Parameters.AddWithValue("@codigo_produto", Convert.ToInt64(combo.SelectedItem.ToString()));
                String codigo = (String)getCategoryIDCmd.ExecuteScalar();



                SqlCommand getTaxaIDCmd = new SqlCommand("SELECT preco FROM produto WHERE codigo_produto = @codigo_produto", conn);
                getTaxaIDCmd.Parameters.AddWithValue("@codigo_produto", Convert.ToDouble(combo.SelectedItem.ToString()));
                decimal taxaID = (decimal)getTaxaIDCmd.ExecuteScalar();

                getTaxaIDCmd = new SqlCommand("SELECT quantidade FROM produto WHERE codigo_produto = @codigo_produto", conn);
                getTaxaIDCmd.Parameters.AddWithValue("@codigo_produto", Convert.ToInt64(combo.SelectedItem.ToString()));
                quant = (int)getTaxaIDCmd.ExecuteScalar();



                getTaxaIDCmd = new SqlCommand("SELECT imposto_id FROM produto WHERE codigo_produto = @codigo_produto", conn);
                getTaxaIDCmd.Parameters.AddWithValue("@codigo_produto", Convert.ToInt64(combo.SelectedItem.ToString()));
                int taxaIDs = (int)getTaxaIDCmd.ExecuteScalar();

                getTaxaIDCmd = new SqlCommand("SELECT taxa FROM taxa_iva WHERE id_taxa_iva = @id", conn);
                getTaxaIDCmd.Parameters.AddWithValue("@id", taxaIDs);
                decimal taxaIDss = (decimal)getTaxaIDCmd.ExecuteScalar();

                labelnome.Text = codigo;
                labelpreco.Text = Convert.ToString(taxaID);
                label3.Text = Convert.ToString(taxaIDss) + " kz";
                label7.Text = Convert.ToString(quant);
                conn.Close();
            }
        }
        public static DataGridViewRow selectedRow = null;
        private void guna2DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Verifica se a célula clicada é válida
            {
                DataGridViewRow selectedRow = guna2DataGridView1.Rows[e.RowIndex];
                string codigo_produto = selectedRow.Cells["codigo_produto"].Value.ToString();
                int quantidadeRemover = Convert.ToInt32(selectedRow.Cells["quantidade"].Value);
                decimal preco = Convert.ToDecimal(selectedRow.Cells["preco"].Value);
                decimal taxa_iva = Convert.ToDecimal(selectedRow.Cells["taxa_iva"].Value);

                DialogResult dr = MessageBox.Show("Tem a certeza de que deseja eliminar esse produto?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                {

                    // Remove a linha do DataGridView
                    guna2DataGridView1.Rows.RemoveAt(e.RowIndex);



                    totaltotal -= ((quantidadeRemover * preco) + (quantidadeRemover * preco) * (taxa_iva / 100));
                    label8.Text = totaltotal.ToString() + " kz";
                    // Aumenta a quantidade no registro no banco de dados
                    AtualizarQuantidadeProduto(codigo_produto, quantidadeRemover);

                }
            }
        }
        private void AtualizarQuantidadeProduto(string codigo_produto, int quantidadeAdicionar)
        {
            try
            {
                // Abre a conexão com o banco de dados
                conn.Open();

                // Comando para atualizar a quantidade no banco de dados
                string updateQuery = "UPDATE produto SET quantidade = quantidade + @quantidadeAdicionar WHERE codigo_produto = @codigo_produto";
                using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                {
                    updateCmd.Parameters.AddWithValue("@quantidadeAdicionar", quantidadeAdicionar);
                    updateCmd.Parameters.AddWithValue("@codigo_produto", codigo_produto);






                    // Executa o comando
                    updateCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Trate a exceção aqui (por exemplo, exibindo uma mensagem ao usuário)
                MessageBox.Show("Ocorreu um erro ao atualizar a quantidade: " + ex.Message);
            }
            finally
            {
                // Fecha a conexão com o banco de dados
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Tem a certeza de que deseja cancelar essa venda?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Yes)
            {

                // Abre a conexão com o banco de dados
                conn.Open();

                foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string codigo_produto = row.Cells["codigo_produto"].Value.ToString();
                        int quantidadeAdicionar = Convert.ToInt32(row.Cells["quantidade"].Value);

                        // Comando para atualizar a quantidade no banco de dados
                        string updateQuery = "UPDATE produto SET quantidade = quantidade + @quantidadeAdicionar WHERE codigo_produto = @codigo_produto";
                        SqlCommand updateCmd = new SqlCommand(updateQuery, conn);

                        updateCmd.Parameters.AddWithValue("@quantidadeAdicionar", quantidadeAdicionar);
                        updateCmd.Parameters.AddWithValue("@codigo_produto", codigo_produto);

                        // Executa o comando
                        updateCmd.ExecuteNonQuery();
                        totaltotal = 0;

                    }
                }

                // Limpa o DataGridView
                dt.Rows.Clear();
                label8.Text = "0.00 kz";



                conn.Close();

            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            bool verif = false;

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row != null)
                    {
                        verif = true;
                        break;
                    }

                }
            }


                if (verif == true)
                {
                if (!decimal.TryParse(guna2TextBox2.Text, out decimal dsc))
                {
                    MessageBox.Show("Digite um desconto válido", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
if ((dsc < 0) || (dsc > 100))
                {
                    MessageBox.Show("Digite um desconto válido", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                else
                {
     
                        desconto = Convert.ToDecimal(guna2TextBox2.Text);
             


                    DialogResult dr = MessageBox.Show("Deseja realizar a venda?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (dr == DialogResult.Yes)
                    {

                        FormularioValor formularioValor = new FormularioValor();
                        formularioValor.ShowDialog();

                        if (FormularioValor.instance.verifica())
                        {
                            //se ele fechar o form sem inserir nada
                            decimal discount = (desconto / 100) * totaltotal;
                            decimal totalcomdisconto = totaltotal - discount;
                            troco = FormularioValor.instance.valor() - totalcomdisconto;

                            conn.Open();
                            string query = "SELECT id_usuario, primeironome, ultimonome FROM usuario WHERE email = @email";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@email", FormularioLogin.instance.mail());

                            SqlDataReader reader = cmd.ExecuteReader();
                            int codigo = 0;

                            if (reader.Read())
                            {
                                codigo = reader.GetInt32(0);
                                primeiroNome = reader.GetString(1);
                                ultimoNome = reader.GetString(2);

                            }
                            reader.Close();

                            query = "INSERT INTO vendas (usuario_id, data_venda, total) VALUES (@usuario_id, @data_venda, @total); SELECT SCOPE_IDENTITY();";

                            DateTime now = DateTime.Now;
                            string dateTimeString = now.ToString("yyyy-MM-dd HH:mm:ss");

                            cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@usuario_id", codigo);
                            cmd.Parameters.AddWithValue("@data_venda", dateTimeString);
                            cmd.Parameters.AddWithValue("@total", totaltotal);

                            int insertedId = Convert.ToInt32(cmd.ExecuteScalar());
                            conn.Close();

                            vendaid = insertedId;


                            FormularioVenda.instance.FormularioVenda_Shown(null, null);
                            GerarPdf(GetFilePath());
                            totaltotal = 0;
                            
                            MessageBox.Show("Venda feita com sucesso!");

                            dt = null;
                            vendaid = 0;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("A venda foi cancelada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }





                    }



                }




                }
                else
                {
                    MessageBox.Show("Coloque algum produto no carrinho", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }



            



        }

        private string GetFilePath()
        {
            string basePath;
            string extension;
            string filePath;

            basePath = @"C:\Users\DELL\Documents\FaturasProfJudson\Fatura Nº ";
            extension = ".pdf";
            do
            {
                filePath = $"{basePath}{vendaid.ToString()}{extension}";

            } while (File.Exists(filePath));



            return filePath;
        }

        public decimal total()
        {

            return totaltotal;

        }
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            /*PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument2;
            printPreviewDialog.ShowDialog(); */

            GerarPreview();


        }


        private void GerarPdf(string path)
        {


            using (PdfWriter writer = new PdfWriter(path))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    // Add header with company information
                    Paragraph header = new Paragraph("FATURA")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(20)
                        .SetBold();
                    document.Add(header);

                    LineSeparator separator = new LineSeparator(new SolidLine());
                    document.Add(separator);

                    // Company info
                    Paragraph companyInfo = new Paragraph()
                        .Add("Nome da empresa: Bebesuki'Store\n")
                        .Add("Endereço: Talatona, Rua 12\n")
                        .Add("Tel: 949315181\n")
                        .Add("Email:otiliaelidaniamarques777@gmail.com\n")
                        .Add($"Data: {DateTime.Now}\n")

.Add("Fatura N.º " + vendaid.ToString() + "\n")



                        .Add("Página 1 de 1")
                        .SetMarginTop(10);
                    document.Add(companyInfo);

                    document.Add(separator);


                    // Attended by
                    Paragraph attendedBy = new Paragraph("Atendido por: " + primeiroNome + " " + ultimoNome)
                        .SetMarginTop(10);
                    document.Add(attendedBy);




                    // Add table for items
                    Table itemsTable = new Table(new float[] { 4, 1, 2, 2, 2 });
                    itemsTable.SetWidth(UnitValue.CreatePercentValue(100));

                    itemsTable.AddHeaderCell("Código do Produto");
                    itemsTable.AddHeaderCell("Taxa do IVA(%)");
                    itemsTable.AddHeaderCell("Quantidade do Produto");
                    itemsTable.AddHeaderCell("Preço Unitário do Produto");
                    itemsTable.AddHeaderCell("Total Feito");

                    // Iterate over DataGridView rows and add to the PDF
                    double totalGeral = 0;
                    decimal subtotal = 0;

                    foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string produto = row.Cells["codigo_produto"].Value.ToString();
                        string quantidade = row.Cells["quantidade"].Value.ToString();
                        string precoUnitario = row.Cells["preco"].Value.ToString();
                        string iva = row.Cells["taxa_iva"].Value.ToString();

                        decimal quantidadeValue = Convert.ToDecimal(row.Cells["quantidade"].Value);
                        decimal precoUnitarioValue = Convert.ToDecimal(row.Cells["preco"].Value);
                        decimal ivaValue = Convert.ToDecimal(row.Cells["taxa_iva"].Value);

                        decimal totalValue = quantidadeValue * precoUnitarioValue + (ivaValue / 100 * quantidadeValue * precoUnitarioValue);
                        string total = totalValue.ToString("F2");

                        subtotal += quantidadeValue * precoUnitarioValue;

                        totalGeral += Convert.ToDouble(totalValue);

                        itemsTable.AddCell(new Cell().Add(new Paragraph(produto)));
                        itemsTable.AddCell(new Cell().Add(new Paragraph(iva)));
                        itemsTable.AddCell(new Cell().Add(new Paragraph(quantidade)));
                        itemsTable.AddCell(new Cell().Add(new Paragraph(precoUnitario + " kz")));
                        itemsTable.AddCell(new Cell().Add(new Paragraph(total + " kz")));
                    }

                    document.Add(itemsTable);


                    // Add totals
                    Table totalsTable = new Table(new float[] { 4, 2 });
                    totalsTable.SetWidth(UnitValue.CreatePercentValue(100));
                    totalsTable.AddCell(new Cell().Add(new Paragraph("Subtotal")).SetBorder(Border.NO_BORDER));
                    totalsTable.AddCell(new Cell().Add(new Paragraph(subtotal.ToString("F2") + " kz")).SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER));
                    totalsTable.AddCell(new Cell().Add(new Paragraph("Desconto")).SetBorder(Border.NO_BORDER));
                    totalsTable.AddCell(new Cell().Add(new Paragraph(desconto.ToString() + "%")).SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER));
                    totalsTable.AddCell(new Cell().Add(new Paragraph("Valor dado pelo cliente")).SetBorder(Border.NO_BORDER));
                    totalsTable.AddCell(new Cell().Add(new Paragraph(FormularioValor.instance.valor().ToString() + " kz")).SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER));
                    totalsTable.AddCell(new Cell().Add(new Paragraph("Tipo de Pagamento")).SetBorder(Border.NO_BORDER));
                    totalsTable.AddCell(new Cell().Add(new Paragraph(FormularioValor.instance.paga())).SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER));
                    totalsTable.AddCell(new Cell().Add(new Paragraph("Total a Pagar")).SetBold().SetBorder(Border.NO_BORDER));
                    totalsTable.AddCell(new Cell().Add(new Paragraph(totaltotal.ToString("F2") + " kz")).SetBold().SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER));
                    totalsTable.AddCell(new Cell().Add(new Paragraph("Troco")).SetBorder(Border.NO_BORDER));
                    totalsTable.AddCell(new Cell().Add(new Paragraph(troco.ToString("F2") + " kz")).SetTextAlignment(TextAlignment.RIGHT).SetBorder(Border.NO_BORDER));

                    document.Add(totalsTable);

                    // Add footer
                    Paragraph footer = new Paragraph("Obrigado por fazer negócios conosco" +
                        " Caso tenha alguma dúvida ou precise de assistência, por favor, entre em contato com nosso serviço de atendimento ao cliente." +
                        "\nObrigadaaa!")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetMarginTop(20);
                    document.Add(footer);




                    document.Close();
                }
            }
        }
        private void GerarPreview()
        {
            var arquivo = @"C:\Users\DELL\Documents\Preview.pdf";

            using (PdfWriter writer = new PdfWriter(arquivo))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf);

                    // Add header with company information
                    Paragraph header = new Paragraph("FATURA")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(20)
                        .SetBold();
                    document.Add(header);

                    LineSeparator separator = new LineSeparator(new SolidLine());
                    document.Add(separator);

                    // Company info
                    Paragraph companyInfo = new Paragraph()
                        
                        .Add("Nome da empresa: Bebesuki'Store\n")
                        .Add("Endereço: Talatona, Rua 12\n")
                        .Add("Tel: 949315181\n")
                        .Add("Email:otiliaelidaniamarques777@gmail.com\n")
                        .Add($"Data: {DateTime.Now}\n")

.Add("Fatura N.º " + vendaid.ToString() + "\n")



                        .Add("Página 1 de 1")
                        .SetMarginTop(10);
                    document.Add(companyInfo);

                    document.Add(separator);


                    // Attended by
                    Paragraph attendedBy = new Paragraph("Atendido por: " + primeiroNome + " " + ultimoNome)
                        .SetMarginTop(10);
                    document.Add(attendedBy);




                    // Add table for items
                    Table itemsTable = new Table(new float[] { 4, 1, 2, 2, 2 });
                    itemsTable.SetWidth(UnitValue.CreatePercentValue(100));
                    itemsTable.AddHeaderCell("Código do Produto");
                    itemsTable.AddHeaderCell("Taxa do IVA(%)");
                    itemsTable.AddHeaderCell("Quantidade do Produto");
                    itemsTable.AddHeaderCell("Preço Unitário do Produto");
                    itemsTable.AddHeaderCell("Total Feito");

                    // Iterate over DataGridView rows and add to the PDF
                    double totalGeral = 0;
                    decimal subtotal = 0;

                    foreach (DataGridViewRow row in guna2DataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string produto = row.Cells["codigo_produto"].Value.ToString();
                        string quantidade = row.Cells["quantidade"].Value.ToString();
                        string precoUnitario = row.Cells["preco"].Value.ToString();
                        string iva = row.Cells["taxa_iva"].Value.ToString();

                        decimal quantidadeValue = Convert.ToDecimal(row.Cells["quantidade"].Value);
                        decimal precoUnitarioValue = Convert.ToDecimal(row.Cells["preco"].Value);
                        decimal ivaValue = Convert.ToDecimal(row.Cells["taxa_iva"].Value);

                        decimal totalValue = quantidadeValue * precoUnitarioValue + (ivaValue / 100 * quantidadeValue * precoUnitarioValue);
                        string total = totalValue.ToString("F2");

                        subtotal += quantidadeValue * precoUnitarioValue;

                        totalGeral += Convert.ToDouble(totalValue);

                        itemsTable.AddCell(new Cell().Add(new Paragraph(produto)));
                        itemsTable.AddCell(new Cell().Add(new Paragraph(iva)));
                        itemsTable.AddCell(new Cell().Add(new Paragraph(quantidade)));
                        itemsTable.AddCell(new Cell().Add(new Paragraph(precoUnitario + " kz")));
                        itemsTable.AddCell(new Cell().Add(new Paragraph(total + " kz")));
                    }

                    document.Add(itemsTable);





                    document.Close();
                }
                System.Diagnostics.Process.Start("C:\\Users\\DELL\\Documents\\Preview.pdf");
            }

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
