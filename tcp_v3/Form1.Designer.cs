namespace tcp_v3
{
    partial class Form1
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
            this.textBoxKomunikat = new System.Windows.Forms.TextBox();
            this.buttonWyslij = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxOdbior = new System.Windows.Forms.RichTextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxAdres = new System.Windows.Forms.TextBox();
            this.buttonSerwuj = new System.Windows.Forms.Button();
            this.buttonPolacz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxKomunikat
            // 
            this.textBoxKomunikat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKomunikat.Enabled = false;
            this.textBoxKomunikat.Location = new System.Drawing.Point(16, 246);
            this.textBoxKomunikat.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxKomunikat.Name = "textBoxKomunikat";
            this.textBoxKomunikat.Size = new System.Drawing.Size(356, 22);
            this.textBoxKomunikat.TabIndex = 25;
            // 
            // buttonWyslij
            // 
            this.buttonWyslij.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWyslij.Enabled = false;
            this.buttonWyslij.Location = new System.Drawing.Point(16, 278);
            this.buttonWyslij.Margin = new System.Windows.Forms.Padding(4);
            this.buttonWyslij.Name = "buttonWyslij";
            this.buttonWyslij.Size = new System.Drawing.Size(357, 37);
            this.buttonWyslij.TabIndex = 24;
            this.buttonWyslij.Text = "Wyślij";
            this.buttonWyslij.UseVisualStyleBackColor = true;
            this.buttonWyslij.Click += new System.EventHandler(this.buttonWyslij_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Adres";
            // 
            // richTextBoxOdbior
            // 
            this.richTextBoxOdbior.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxOdbior.Location = new System.Drawing.Point(16, 132);
            this.richTextBoxOdbior.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxOdbior.Name = "richTextBoxOdbior";
            this.richTextBoxOdbior.ReadOnly = true;
            this.richTextBoxOdbior.Size = new System.Drawing.Size(356, 106);
            this.richTextBoxOdbior.TabIndex = 22;
            this.richTextBoxOdbior.Text = "";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPort.Location = new System.Drawing.Point(107, 39);
            this.textBoxPort.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(265, 22);
            this.textBoxPort.TabIndex = 21;
            this.textBoxPort.Text = "2222";
            // 
            // textBoxAdres
            // 
            this.textBoxAdres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAdres.Location = new System.Drawing.Point(107, 12);
            this.textBoxAdres.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAdres.Name = "textBoxAdres";
            this.textBoxAdres.Size = new System.Drawing.Size(265, 22);
            this.textBoxAdres.TabIndex = 20;
            this.textBoxAdres.Text = "192.168.43.43";
            this.textBoxAdres.TextChanged += new System.EventHandler(this.textBoxAdres_TextChanged);
            // 
            // buttonSerwuj
            // 
            this.buttonSerwuj.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSerwuj.Location = new System.Drawing.Point(273, 76);
            this.buttonSerwuj.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSerwuj.Name = "buttonSerwuj";
            this.buttonSerwuj.Size = new System.Drawing.Size(100, 28);
            this.buttonSerwuj.TabIndex = 19;
            this.buttonSerwuj.Text = "Serwuj";
            this.buttonSerwuj.UseVisualStyleBackColor = true;
            this.buttonSerwuj.Click += new System.EventHandler(this.buttonSerwuj_Click);
            // 
            // buttonPolacz
            // 
            this.buttonPolacz.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonPolacz.Location = new System.Drawing.Point(107, 76);
            this.buttonPolacz.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPolacz.Name = "buttonPolacz";
            this.buttonPolacz.Size = new System.Drawing.Size(100, 28);
            this.buttonPolacz.TabIndex = 18;
            this.buttonPolacz.Text = "Połącz";
            this.buttonPolacz.UseVisualStyleBackColor = true;
            this.buttonPolacz.Click += new System.EventHandler(this.buttonPolacz_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 327);
            this.Controls.Add(this.textBoxKomunikat);
            this.Controls.Add(this.buttonWyslij);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxOdbior);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxAdres);
            this.Controls.Add(this.buttonSerwuj);
            this.Controls.Add(this.buttonPolacz);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(394, 358);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxKomunikat;
        private System.Windows.Forms.Button buttonWyslij;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxOdbior;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxAdres;
        private System.Windows.Forms.Button buttonSerwuj;
        private System.Windows.Forms.Button buttonPolacz;
    }
}

