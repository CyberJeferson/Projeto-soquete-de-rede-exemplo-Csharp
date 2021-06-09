namespace JogoDaVelhaAPS
{
    partial class AguardarResposta
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
            this.lstatus = new System.Windows.Forms.Label();
            this.Contagem = new System.Windows.Forms.Timer(this.components);
            this.Letras = new System.Windows.Forms.Timer(this.components);
            this.lAnimacao = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lAnimacao)).BeginInit();
            this.SuspendLayout();
            // 
            // lstatus
            // 
            this.lstatus.AutoSize = true;
            this.lstatus.Font = new System.Drawing.Font("Wide Latin", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstatus.Location = new System.Drawing.Point(74, 264);
            this.lstatus.Name = "lstatus";
            this.lstatus.Size = new System.Drawing.Size(591, 18);
            this.lstatus.TabIndex = 1;
            this.lstatus.Text = "AGUARDANDO O PLAYER RESPONDER";
            // 
            // Contagem
            // 
            this.Contagem.Enabled = true;
            this.Contagem.Interval = 10000;
            this.Contagem.Tick += new System.EventHandler(this.Contagem_Tick);
            // 
            // Letras
            // 
            this.Letras.Enabled = true;
            this.Letras.Tick += new System.EventHandler(this.Letras_Tick);
            // 
            // lAnimacao
            // 
            this.lAnimacao.Location = new System.Drawing.Point(266, 8);
            this.lAnimacao.Name = "lAnimacao";
            this.lAnimacao.Size = new System.Drawing.Size(198, 249);
            this.lAnimacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lAnimacao.TabIndex = 0;
            this.lAnimacao.TabStop = false;
            // 
            // AguardarResposta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(757, 311);
            this.Controls.Add(this.lstatus);
            this.Controls.Add(this.lAnimacao);
            this.ForeColor = System.Drawing.Color.Lime;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AguardarResposta";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AguardarResposta";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AguardarResposta_FormClosing);
            this.Load += new System.EventHandler(this.AguardarResposta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lAnimacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox lAnimacao;
        private System.Windows.Forms.Label lstatus;
        private System.Windows.Forms.Timer Contagem;
        private System.Windows.Forms.Timer Letras;
    }
}