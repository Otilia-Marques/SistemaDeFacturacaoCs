namespace SistemadeFaturacao
{
    partial class FormularioTaxa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewTaxa = new Guna.UI2.WinForms.Guna2DataGridView();
            this.idtaxaivaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datavigenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ativoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxaivaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sistemaDeFacturacaoDataSet2 = new SistemadeFaturacao.SistemaDeFacturacaoDataSet2();
            this.taxaivaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sistemadefaturacaoDataSet8 = new SistemadeFaturacao.sistemadefaturacaoDataSet8();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.textid = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.taxa_ivaTableAdapter1 = new SistemadeFaturacao.sistemadefaturacaoDataSet8TableAdapters.taxa_ivaTableAdapter();
            this.taxa_ivaTableAdapter = new SistemadeFaturacao.SistemaDeFacturacaoDataSet2TableAdapters.taxa_ivaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaxa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxaivaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaDeFacturacaoDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxaivaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemadefaturacaoDataSet8)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewTaxa
            // 
            this.dataGridViewTaxa.AllowUserToAddRows = false;
            this.dataGridViewTaxa.AllowUserToDeleteRows = false;
            this.dataGridViewTaxa.AllowUserToResizeColumns = false;
            this.dataGridViewTaxa.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Fuchsia;
            this.dataGridViewTaxa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTaxa.AutoGenerateColumns = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTaxa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTaxa.ColumnHeadersHeight = 30;
            this.dataGridViewTaxa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridViewTaxa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idtaxaivaDataGridViewTextBoxColumn,
            this.datavigenciaDataGridViewTextBoxColumn,
            this.taxaDataGridViewTextBoxColumn,
            this.descricaoDataGridViewTextBoxColumn,
            this.ativoDataGridViewTextBoxColumn});
            this.dataGridViewTaxa.DataSource = this.taxaivaBindingSource;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTaxa.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTaxa.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewTaxa.Location = new System.Drawing.Point(127, 120);
            this.dataGridViewTaxa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewTaxa.Name = "dataGridViewTaxa";
            this.dataGridViewTaxa.ReadOnly = true;
            this.dataGridViewTaxa.RowHeadersVisible = false;
            this.dataGridViewTaxa.RowHeadersWidth = 51;
            this.dataGridViewTaxa.RowTemplate.Height = 40;
            this.dataGridViewTaxa.Size = new System.Drawing.Size(771, 401);
            this.dataGridViewTaxa.TabIndex = 15;
            this.dataGridViewTaxa.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewTaxa.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridViewTaxa.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridViewTaxa.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridViewTaxa.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridViewTaxa.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewTaxa.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewTaxa.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridViewTaxa.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewTaxa.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTaxa.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewTaxa.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridViewTaxa.ThemeStyle.HeaderStyle.Height = 30;
            this.dataGridViewTaxa.ThemeStyle.ReadOnly = true;
            this.dataGridViewTaxa.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewTaxa.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewTaxa.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTaxa.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewTaxa.ThemeStyle.RowsStyle.Height = 40;
            this.dataGridViewTaxa.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewTaxa.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewTaxa.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewTaxa_CellMouseClick);
            // 
            // idtaxaivaDataGridViewTextBoxColumn
            // 
            this.idtaxaivaDataGridViewTextBoxColumn.DataPropertyName = "id_taxa_iva";
            this.idtaxaivaDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idtaxaivaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idtaxaivaDataGridViewTextBoxColumn.Name = "idtaxaivaDataGridViewTextBoxColumn";
            this.idtaxaivaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // datavigenciaDataGridViewTextBoxColumn
            // 
            this.datavigenciaDataGridViewTextBoxColumn.DataPropertyName = "data_vigencia";
            this.datavigenciaDataGridViewTextBoxColumn.HeaderText = "Data de Vigência";
            this.datavigenciaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.datavigenciaDataGridViewTextBoxColumn.Name = "datavigenciaDataGridViewTextBoxColumn";
            this.datavigenciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // taxaDataGridViewTextBoxColumn
            // 
            this.taxaDataGridViewTextBoxColumn.DataPropertyName = "taxa";
            this.taxaDataGridViewTextBoxColumn.HeaderText = "Taxa (%)";
            this.taxaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.taxaDataGridViewTextBoxColumn.Name = "taxaDataGridViewTextBoxColumn";
            this.taxaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            this.descricaoDataGridViewTextBoxColumn.DataPropertyName = "descricao";
            this.descricaoDataGridViewTextBoxColumn.HeaderText = "Descrição";
            this.descricaoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            this.descricaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ativoDataGridViewTextBoxColumn
            // 
            this.ativoDataGridViewTextBoxColumn.DataPropertyName = "ativo";
            this.ativoDataGridViewTextBoxColumn.HeaderText = "Ativo";
            this.ativoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ativoDataGridViewTextBoxColumn.Name = "ativoDataGridViewTextBoxColumn";
            this.ativoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // taxaivaBindingSource
            // 
            this.taxaivaBindingSource.DataMember = "taxa_iva";
            this.taxaivaBindingSource.DataSource = this.sistemaDeFacturacaoDataSet2;
            // 
            // sistemaDeFacturacaoDataSet2
            // 
            this.sistemaDeFacturacaoDataSet2.DataSetName = "SistemaDeFacturacaoDataSet2";
            this.sistemaDeFacturacaoDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taxaivaBindingSource1
            // 
            this.taxaivaBindingSource1.DataMember = "taxa_iva";
            this.taxaivaBindingSource1.DataSource = this.sistemadefaturacaoDataSet8;
            // 
            // sistemadefaturacaoDataSet8
            // 
            this.sistemadefaturacaoDataSet8.DataSetName = "sistemadefaturacaoDataSet8";
            this.sistemadefaturacaoDataSet8.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderColor = System.Drawing.Color.BlueViolet;
            this.guna2Button1.BorderRadius = 20;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Aqua;
            this.guna2Button1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.Blue;
            this.guna2Button1.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(384, 538);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(294, 56);
            this.guna2Button1.TabIndex = 13;
            this.guna2Button1.Text = "Registrar";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.BlueViolet;
            this.guna2Panel1.Controls.Add(this.textid);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1064, 80);
            this.guna2Panel1.TabIndex = 12;
            // 
            // textid
            // 
            this.textid.AutoRoundedCorners = true;
            this.textid.BorderRadius = 21;
            this.textid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textid.DefaultText = "";
            this.textid.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textid.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textid.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textid.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textid.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textid.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textid.ForeColor = System.Drawing.Color.Black;
            this.textid.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textid.IconLeftSize = new System.Drawing.Size(30, 30);
            this.textid.Location = new System.Drawing.Point(240, 22);
            this.textid.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.textid.Name = "textid";
            this.textid.PasswordChar = '\0';
            this.textid.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.textid.PlaceholderText = "Pesquisar Aqui...";
            this.textid.SelectedText = "";
            this.textid.Size = new System.Drawing.Size(307, 45);
            this.textid.TabIndex = 11;
            this.textid.TextChanged += new System.EventHandler(this.textid_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(130, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pesquisar:";
            // 
            // taxa_ivaTableAdapter1
            // 
            this.taxa_ivaTableAdapter1.ClearBeforeFill = true;
            // 
            // taxa_ivaTableAdapter
            // 
            this.taxa_ivaTableAdapter.ClearBeforeFill = true;
            // 
            // FormularioTaxa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlueViolet;
            this.ClientSize = new System.Drawing.Size(1064, 674);
            this.Controls.Add(this.dataGridViewTaxa);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormularioTaxa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormularioTaxa";
            this.Load += new System.EventHandler(this.FormularioTaxa_Load);
            this.Shown += new System.EventHandler(this.FormularioTaxa_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTaxa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxaivaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaDeFacturacaoDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taxaivaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemadefaturacaoDataSet8)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DataGridView dataGridViewTaxa;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox textid;
        private System.Windows.Forms.Label label1;
        private sistemadefaturacaoDataSet8 sistemadefaturacaoDataSet8;
        private System.Windows.Forms.BindingSource taxaivaBindingSource1;
        private sistemadefaturacaoDataSet8TableAdapters.taxa_ivaTableAdapter taxa_ivaTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtaxaivaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datavigenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ativoDataGridViewTextBoxColumn;
        private SistemaDeFacturacaoDataSet2 sistemaDeFacturacaoDataSet2;
        private System.Windows.Forms.BindingSource taxaivaBindingSource;
        private SistemaDeFacturacaoDataSet2TableAdapters.taxa_ivaTableAdapter taxa_ivaTableAdapter;
    }
}