namespace JogoDaVelhaAPS
{
    partial class fconvite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fconvite));
            this.pFoto = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnAceitar = new System.Windows.Forms.Button();
            this.btnRecusar = new System.Windows.Forms.Button();
            this.lNome = new System.Windows.Forms.Label();
            this.Verificador = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pFoto
            // 
            this.pFoto.BackColor = System.Drawing.Color.Black;
            this.pFoto.Location = new System.Drawing.Point(303, 56);
            this.pFoto.Name = "pFoto";
            this.pFoto.Size = new System.Drawing.Size(132, 158);
            this.pFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pFoto.TabIndex = 0;
            this.pFoto.TabStop = false;
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Jokerman", 24F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(162, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 47);
            this.label1.TabIndex = 1;
            this.label1.Text = "CONVITE DE BATALHA";
         
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(438, 240);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(129, 153);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
           
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(151, 243);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(129, 153);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
           
            // 
            // btnAceitar
            // 
            this.btnAceitar.BackColor = System.Drawing.Color.Black;
            this.btnAceitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceitar.ForeColor = System.Drawing.Color.GreenYellow;
            this.btnAceitar.Location = new System.Drawing.Point(218, 336);
            this.btnAceitar.Name = "btnAceitar";
            this.btnAceitar.Size = new System.Drawing.Size(75, 23);
            this.btnAceitar.TabIndex = 4;
            this.btnAceitar.Text = "ACEITAR";
            this.btnAceitar.UseVisualStyleBackColor = false;
            this.btnAceitar.Click += new System.EventHandler(this.btnAceitar_Click);
            // 
            // btnRecusar
            // 
            this.btnRecusar.BackColor = System.Drawing.Color.Black;
            this.btnRecusar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecusar.ForeColor = System.Drawing.Color.Red;
            this.btnRecusar.Location = new System.Drawing.Point(419, 336);
            this.btnRecusar.Name = "btnRecusar";
            this.btnRecusar.Size = new System.Drawing.Size(75, 23);
            this.btnRecusar.TabIndex = 5;
            this.btnRecusar.Text = "RECUSAR";
            this.btnRecusar.UseVisualStyleBackColor = false;
            this.btnRecusar.Click += new System.EventHandler(this.btnRecusar_Click);
            // 
            // lNome
            // 
            this.lNome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lNome.AutoSize = true;
            this.lNome.BackColor = System.Drawing.Color.Black;
            this.lNome.Font = new System.Drawing.Font("Microsoft Himalaya", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNome.ForeColor = System.Drawing.Color.Red;
            this.lNome.Location = new System.Drawing.Point(371, 217);
            this.lNome.Name = "lNome";
            this.lNome.Size = new System.Drawing.Size(139, 64);
            this.lNome.TabIndex = 6;
            this.lNome.Text = "mikex";
            // 
            // Verificador
            // 
            this.Verificador.Enabled = true;
            this.Verificador.Interval = 1000;
       
            // 
            // fconvite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::JogoDaVelhaAPS.Properties.Resources.kisspng_flame_off_the_hook_barbecue_fire_restaurant_15_grill_flames_png_for_free_download_on_mbtskouds_5bfe0edd63fb38_6822048515433766054095;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(739, 362);
            this.Controls.Add(this.lNome);
            this.Controls.Add(this.btnRecusar);
            this.Controls.Add(this.btnAceitar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pFoto);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fconvite";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fconvite";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.ActiveCaption;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fconvite_FormClosing);
            this.Load += new System.EventHandler(this.fconvite_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pFoto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnAceitar;
        private System.Windows.Forms.Button btnRecusar;
        private System.Windows.Forms.Label lNome;
        internal System.Windows.Forms.Timer Verificador;
    }
}