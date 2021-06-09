namespace JogoDaVelhaAPS
{
    partial class frmOcorrencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOcorrencias));
            this.pMapa = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdesc = new System.Windows.Forms.TextBox();
            this.txtlat = new System.Windows.Forms.TextBox();
            this.txtlong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gOcorrencia = new System.Windows.Forms.DataGridView();
            this.tpocorrencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dsocorrencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.latlong = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.EnviarCords = new System.Windows.Forms.Timer(this.components);
            this.Velocidade = new System.Windows.Forms.Label();
            this.pMapa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gOcorrencia)).BeginInit();
            this.SuspendLayout();
            // 
            // pMapa
            // 
            this.pMapa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pMapa.BackColor = System.Drawing.Color.White;
            this.pMapa.Controls.Add(this.label8);
            this.pMapa.Controls.Add(this.label2);
            this.pMapa.Location = new System.Drawing.Point(-2, 0);
            this.pMapa.Name = "pMapa";
            this.pMapa.Size = new System.Drawing.Size(993, 365);
            this.pMapa.TabIndex = 0;
            this.pMapa.Paint += new System.Windows.Forms.PaintEventHandler(this.pMapa_Paint);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "Mapa Satélite";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(242, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(489, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "POLÍCIA AMBIENTAL OCORRÊNCIAS";
            // 
            // txtTipo
            // 
            this.txtTipo.FormattingEnabled = true;
            this.txtTipo.Items.AddRange(new object[] {
            "QUEIMADAS",
            "CAÇA PROIBIDA",
            "CRIMES CONTRA A FLORA",
            "CRIMES CONTRA A FAUNA"});
            this.txtTipo.Location = new System.Drawing.Point(0, 417);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(225, 21);
            this.txtTipo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-3, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "TIPO DE CRIME AMBIENTAL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-3, 441);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "DESCRIÇÃO DO CRIME";
            // 
            // txtdesc
            // 
            this.txtdesc.Location = new System.Drawing.Point(1, 457);
            this.txtdesc.Multiline = true;
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Size = new System.Drawing.Size(224, 61);
            this.txtdesc.TabIndex = 4;
            // 
            // txtlat
            // 
            this.txtlat.Location = new System.Drawing.Point(0, 543);
            this.txtlat.Name = "txtlat";
            this.txtlat.Size = new System.Drawing.Size(104, 20);
            this.txtlat.TabIndex = 5;
            // 
            // txtlong
            // 
            this.txtlong.Location = new System.Drawing.Point(106, 543);
            this.txtlong.Name = "txtlong";
            this.txtlong.Size = new System.Drawing.Size(119, 20);
            this.txtlong.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1, 527);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "LATITUDE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(107, 527);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "LOGITUDE";
            // 
            // gOcorrencia
            // 
            this.gOcorrencia.AllowUserToAddRows = false;
            this.gOcorrencia.AllowUserToDeleteRows = false;
            this.gOcorrencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gOcorrencia.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gOcorrencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gOcorrencia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tpocorrencia,
            this.dsocorrencia,
            this.lto,
            this.lte});
            this.gOcorrencia.Location = new System.Drawing.Point(363, 383);
            this.gOcorrencia.Name = "gOcorrencia";
            this.gOcorrencia.ReadOnly = true;
            this.gOcorrencia.RowHeadersVisible = false;
            this.gOcorrencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gOcorrencia.Size = new System.Drawing.Size(624, 233);
            this.gOcorrencia.TabIndex = 10;
            this.gOcorrencia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gOcorrencia_CellClick);
            // 
            // tpocorrencia
            // 
            this.tpocorrencia.HeaderText = "Tipo de ocorrência";
            this.tpocorrencia.Name = "tpocorrencia";
            this.tpocorrencia.ReadOnly = true;
            // 
            // dsocorrencia
            // 
            this.dsocorrencia.HeaderText = "Descrição da ocorrência";
            this.dsocorrencia.MinimumWidth = 300;
            this.dsocorrencia.Name = "dsocorrencia";
            this.dsocorrencia.ReadOnly = true;
            this.dsocorrencia.Width = 300;
            // 
            // lto
            // 
            this.lto.HeaderText = "Latitude";
            this.lto.Name = "lto";
            this.lto.ReadOnly = true;
            // 
            // lte
            // 
            this.lte.HeaderText = "Longitude";
            this.lte.Name = "lte";
            this.lte.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(-3, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(233, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "REGISTRAR UMA NOVA OCORRÊNCIA";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Elephant", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(366, 367);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(266, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "OCORRÊNCIAS EM ADANDAMENTO";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // latlong
            // 
            this.latlong.Enabled = true;
            this.latlong.Tick += new System.EventHandler(this.latlong_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 569);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(225, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "GERAR OCORRÊNCIA";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 598);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(225, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "VOLTAR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // EnviarCords
            // 
            this.EnviarCords.Enabled = true;
            this.EnviarCords.Interval = 40000;
            this.EnviarCords.Tick += new System.EventHandler(this.EnviarCords_Tick);
            // 
            // Velocidade
            // 
            this.Velocidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Velocidade.AutoSize = true;
            this.Velocidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Velocidade.ForeColor = System.Drawing.Color.Red;
            this.Velocidade.Location = new System.Drawing.Point(360, 619);
            this.Velocidade.Name = "Velocidade";
            this.Velocidade.Size = new System.Drawing.Size(85, 29);
            this.Velocidade.TabIndex = 17;
            this.Velocidade.Text = "label9";
            // 
            // frmOcorrencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(987, 691);
            this.Controls.Add(this.Velocidade);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gOcorrencia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtlong);
            this.Controls.Add(this.txtlat);
            this.Controls.Add(this.txtdesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.pMapa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOcorrencias";
            this.Text = "Ocorrências em tempo real";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOcorrencias_FormClosing);
            this.Load += new System.EventHandler(this.frmOcorrencias_Load);
            this.pMapa.ResumeLayout(false);
            this.pMapa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gOcorrencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pMapa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtdesc;
        private System.Windows.Forms.TextBox txtlat;
        private System.Windows.Forms.TextBox txtlong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView gOcorrencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer latlong;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpocorrencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn dsocorrencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn lto;
        private System.Windows.Forms.DataGridViewTextBoxColumn lte;
        private System.Windows.Forms.Timer EnviarCords;
        private System.Windows.Forms.Label Velocidade;
    }
}