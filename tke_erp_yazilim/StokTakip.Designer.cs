namespace tke_erp_yazilim
{
    partial class StokTakip
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtbirimfiyat = new System.Windows.Forms.NumericUpDown();
            this.btnkaydet = new System.Windows.Forms.Button();
            this.txtstokadi = new System.Windows.Forms.TextBox();
            this.txtstokkodu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lststok = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbirimfiyat)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbirimfiyat);
            this.groupBox1.Controls.Add(this.btnkaydet);
            this.groupBox1.Controls.Add(this.txtstokadi);
            this.groupBox1.Controls.Add(this.txtstokkodu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(355, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 386);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stok Kart Bilgileri";
            // 
            // txtbirimfiyat
            // 
            this.txtbirimfiyat.Location = new System.Drawing.Point(43, 227);
            this.txtbirimfiyat.Name = "txtbirimfiyat";
            this.txtbirimfiyat.Size = new System.Drawing.Size(100, 20);
            this.txtbirimfiyat.TabIndex = 8;
            // 
            // btnkaydet
            // 
            this.btnkaydet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnkaydet.Location = new System.Drawing.Point(43, 276);
            this.btnkaydet.Name = "btnkaydet";
            this.btnkaydet.Size = new System.Drawing.Size(75, 23);
            this.btnkaydet.TabIndex = 7;
            this.btnkaydet.Text = "Kaydet";
            this.btnkaydet.UseVisualStyleBackColor = false;
            this.btnkaydet.Click += new System.EventHandler(this.btnkaydet_Click);
            // 
            // txtstokadi
            // 
            this.txtstokadi.Location = new System.Drawing.Point(43, 150);
            this.txtstokadi.Name = "txtstokadi";
            this.txtstokadi.Size = new System.Drawing.Size(100, 20);
            this.txtstokadi.TabIndex = 5;
            // 
            // txtstokkodu
            // 
            this.txtstokkodu.Location = new System.Drawing.Point(43, 84);
            this.txtstokkodu.Name = "txtstokkodu";
            this.txtstokkodu.Size = new System.Drawing.Size(100, 20);
            this.txtstokkodu.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Birim Fiyat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stok Adı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stok Kodu";
            // 
            // lststok
            // 
            this.lststok.FormattingEnabled = true;
            this.lststok.Location = new System.Drawing.Point(95, 67);
            this.lststok.Name = "lststok";
            this.lststok.Size = new System.Drawing.Size(138, 381);
            this.lststok.TabIndex = 8;
            this.lststok.Click += new System.EventHandler(this.lststok_Click);
            // 
            // StokTakip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(800, 599);
            this.Controls.Add(this.lststok);
            this.Controls.Add(this.groupBox1);
            this.Name = "StokTakip";
            this.Text = "StokTakip";
            this.Load += new System.EventHandler(this.StokTakip_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtbirimfiyat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtstokadi;
        private System.Windows.Forms.TextBox txtstokkodu;
        private System.Windows.Forms.Button btnkaydet;
        private System.Windows.Forms.ListBox lststok;
        private System.Windows.Forms.NumericUpDown txtbirimfiyat;
    }
}