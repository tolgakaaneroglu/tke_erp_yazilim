namespace tke_erp_yazilim
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
            this.btnsiparis = new System.Windows.Forms.Button();
            this.butonstok = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsiparis
            // 
            this.btnsiparis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnsiparis.Location = new System.Drawing.Point(4, 12);
            this.btnsiparis.Name = "btnsiparis";
            this.btnsiparis.Size = new System.Drawing.Size(127, 52);
            this.btnsiparis.TabIndex = 0;
            this.btnsiparis.Text = "Yeni Sipariş Ekle";
            this.btnsiparis.UseVisualStyleBackColor = false;
            this.btnsiparis.Click += new System.EventHandler(this.btnsiparis_Click);
            // 
            // butonstok
            // 
            this.butonstok.BackColor = System.Drawing.Color.Yellow;
            this.butonstok.Location = new System.Drawing.Point(216, 12);
            this.butonstok.Name = "butonstok";
            this.butonstok.Size = new System.Drawing.Size(127, 52);
            this.butonstok.TabIndex = 1;
            this.butonstok.Text = "Stok Kart Liste";
            this.butonstok.UseVisualStyleBackColor = false;
            this.butonstok.Click += new System.EventHandler(this.butonstok_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(339, 316);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(349, 403);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.butonstok);
            this.Controls.Add(this.btnsiparis);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnsiparis;
        private System.Windows.Forms.Button btnstok;
        private System.Windows.Forms.Button butonstok;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

