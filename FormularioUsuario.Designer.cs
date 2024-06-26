namespace SistemadeFaturacao
{
    partial class FormularioUsuario
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.textid = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.dataGridViewUsuario = new Guna.UI2.WinForms.Guna2DataGridView();
            this.idusuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primeironomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ultimonomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.senhaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipodeusuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fotoDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.usuarioBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.sistemaDeFacturacaoDataSet3 = new SistemadeFaturacao.SistemaDeFacturacaoDataSet3();
            this.usuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sistemadefaturacaoDataSet = new SistemadeFaturacao.sistemadefaturacaoDataSet();
            this.usuarioTableAdapter = new SistemadeFaturacao.sistemadefaturacaoDataSetTableAdapters.usuarioTableAdapter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.usuarioTableAdapter1 = new SistemadeFaturacao.SistemaDeFacturacaoDataSet3TableAdapters.usuarioTableAdapter();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaDeFacturacaoDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemadefaturacaoDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.textid);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1064, 80);
            this.guna2Panel1.TabIndex = 0;
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
            this.textid.Location = new System.Drawing.Point(417, 22);
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
            this.label1.Location = new System.Drawing.Point(305, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pesquisar:";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Aqua;
            this.guna2Button1.BorderColor = System.Drawing.Color.White;
            this.guna2Button1.BorderRadius = 15;
            this.guna2Button1.BorderThickness = 1;
            this.guna2Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Times New Roman", 16F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.FillColor = System.Drawing.Color.Blue;
            this.guna2Button1.HoverState.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(526, 554);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(224, 56);
            this.guna2Button1.TabIndex = 2;
            this.guna2Button1.Text = "Registrar";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click_1);
            // 
            // dataGridViewUsuario
            // 
            this.dataGridViewUsuario.AllowUserToAddRows = false;
            this.dataGridViewUsuario.AllowUserToDeleteRows = false;
            this.dataGridViewUsuario.AllowUserToResizeColumns = false;
            this.dataGridViewUsuario.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Aqua;
            this.dataGridViewUsuario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewUsuario.AutoGenerateColumns = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUsuario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewUsuario.ColumnHeadersHeight = 30;
            this.dataGridViewUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridViewUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idusuarioDataGridViewTextBoxColumn,
            this.primeironomeDataGridViewTextBoxColumn,
            this.ultimonomeDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.senhaDataGridViewTextBoxColumn,
            this.tipodeusuarioDataGridViewTextBoxColumn,
            this.fotoDataGridViewImageColumn});
            this.dataGridViewUsuario.DataSource = this.usuarioBindingSource1;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUsuario.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewUsuario.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewUsuario.Location = new System.Drawing.Point(21, 118);
            this.dataGridViewUsuario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewUsuario.Name = "dataGridViewUsuario";
            this.dataGridViewUsuario.ReadOnly = true;
            this.dataGridViewUsuario.RowHeadersVisible = false;
            this.dataGridViewUsuario.RowHeadersWidth = 51;
            this.dataGridViewUsuario.RowTemplate.Height = 40;
            this.dataGridViewUsuario.Size = new System.Drawing.Size(1000, 428);
            this.dataGridViewUsuario.TabIndex = 5;
            this.dataGridViewUsuario.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewUsuario.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridViewUsuario.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridViewUsuario.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridViewUsuario.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridViewUsuario.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewUsuario.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewUsuario.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridViewUsuario.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewUsuario.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewUsuario.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewUsuario.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridViewUsuario.ThemeStyle.HeaderStyle.Height = 30;
            this.dataGridViewUsuario.ThemeStyle.ReadOnly = true;
            this.dataGridViewUsuario.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewUsuario.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewUsuario.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewUsuario.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewUsuario.ThemeStyle.RowsStyle.Height = 40;
            this.dataGridViewUsuario.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewUsuario.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewUsuario.DataSourceChanged += new System.EventHandler(this.dataGridViewUsuario_DataSourceChanged);
            this.dataGridViewUsuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsuario_CellClick);
            this.dataGridViewUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsuario_CellContentClick);
            this.dataGridViewUsuario.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewUsuario_CellMouseClick);
            this.dataGridViewUsuario.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridViewUsuario_ColumnAdded);
            this.dataGridViewUsuario.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewUsuario_UserAddedRow);
            // 
            // idusuarioDataGridViewTextBoxColumn
            // 
            this.idusuarioDataGridViewTextBoxColumn.DataPropertyName = "id_usuario";
            this.idusuarioDataGridViewTextBoxColumn.HeaderText = "ID";
            this.idusuarioDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idusuarioDataGridViewTextBoxColumn.Name = "idusuarioDataGridViewTextBoxColumn";
            this.idusuarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // primeironomeDataGridViewTextBoxColumn
            // 
            this.primeironomeDataGridViewTextBoxColumn.DataPropertyName = "primeironome";
            this.primeironomeDataGridViewTextBoxColumn.HeaderText = "Primeiro Nome";
            this.primeironomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.primeironomeDataGridViewTextBoxColumn.Name = "primeironomeDataGridViewTextBoxColumn";
            this.primeironomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ultimonomeDataGridViewTextBoxColumn
            // 
            this.ultimonomeDataGridViewTextBoxColumn.DataPropertyName = "ultimonome";
            this.ultimonomeDataGridViewTextBoxColumn.HeaderText = "Último Nome";
            this.ultimonomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ultimonomeDataGridViewTextBoxColumn.Name = "ultimonomeDataGridViewTextBoxColumn";
            this.ultimonomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "E-mail";
            this.emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            this.emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // senhaDataGridViewTextBoxColumn
            // 
            this.senhaDataGridViewTextBoxColumn.DataPropertyName = "senha";
            this.senhaDataGridViewTextBoxColumn.HeaderText = "Senha";
            this.senhaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.senhaDataGridViewTextBoxColumn.Name = "senhaDataGridViewTextBoxColumn";
            this.senhaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipodeusuarioDataGridViewTextBoxColumn
            // 
            this.tipodeusuarioDataGridViewTextBoxColumn.DataPropertyName = "tipodeusuario";
            this.tipodeusuarioDataGridViewTextBoxColumn.HeaderText = "Tipo de Usuário";
            this.tipodeusuarioDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tipodeusuarioDataGridViewTextBoxColumn.Name = "tipodeusuarioDataGridViewTextBoxColumn";
            this.tipodeusuarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fotoDataGridViewImageColumn
            // 
            this.fotoDataGridViewImageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fotoDataGridViewImageColumn.DataPropertyName = "foto";
            this.fotoDataGridViewImageColumn.HeaderText = "Foto";
            this.fotoDataGridViewImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.fotoDataGridViewImageColumn.MinimumWidth = 6;
            this.fotoDataGridViewImageColumn.Name = "fotoDataGridViewImageColumn";
            this.fotoDataGridViewImageColumn.ReadOnly = true;
            this.fotoDataGridViewImageColumn.Width = 131;
            // 
            // usuarioBindingSource1
            // 
            this.usuarioBindingSource1.DataMember = "usuario";
            this.usuarioBindingSource1.DataSource = this.sistemaDeFacturacaoDataSet3;
            // 
            // sistemaDeFacturacaoDataSet3
            // 
            this.sistemaDeFacturacaoDataSet3.DataSetName = "SistemaDeFacturacaoDataSet3";
            this.sistemaDeFacturacaoDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usuarioBindingSource
            // 
            this.usuarioBindingSource.DataMember = "usuario";
            this.usuarioBindingSource.DataSource = this.sistemadefaturacaoDataSet;
            // 
            // sistemadefaturacaoDataSet
            // 
            this.sistemadefaturacaoDataSet.DataSetName = "sistemadefaturacaoDataSet";
            this.sistemadefaturacaoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usuarioTableAdapter
            // 
            this.usuarioTableAdapter.ClearBeforeFill = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // usuarioTableAdapter1
            // 
            this.usuarioTableAdapter1.ClearBeforeFill = true;
            // 
            // FormularioUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlueViolet;
            this.ClientSize = new System.Drawing.Size(1064, 776);
            this.Controls.Add(this.dataGridViewUsuario);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormularioUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormularioUsuario";
            this.Load += new System.EventHandler(this.FormularioUsuario_Load);
            this.Shown += new System.EventHandler(this.FormularioUsuario_Shown);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemaDeFacturacaoDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sistemadefaturacaoDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridViewUsuario;
        private Guna.UI2.WinForms.Guna2TextBox textid;
        private System.Windows.Forms.DataGridViewTextBoxColumn idusuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn primeironomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ultimonomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn senhaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipodeusuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn fotoDataGridViewImageColumn;
        private sistemadefaturacaoDataSet sistemadefaturacaoDataSet;
        private System.Windows.Forms.BindingSource usuarioBindingSource;
        private sistemadefaturacaoDataSetTableAdapters.usuarioTableAdapter usuarioTableAdapter;
        private System.Windows.Forms.Timer timer1;
        private SistemaDeFacturacaoDataSet3 sistemaDeFacturacaoDataSet3;
        private System.Windows.Forms.BindingSource usuarioBindingSource1;
        private SistemaDeFacturacaoDataSet3TableAdapters.usuarioTableAdapter usuarioTableAdapter1;
    }
}