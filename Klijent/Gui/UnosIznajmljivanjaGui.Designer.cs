
namespace Klijent.Gui
{
    partial class UnosIznajmljivanjaGui
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
            this.btnUnos = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnMinus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPrimerak = new System.Windows.Forms.ComboBox();
            this.btnPlus = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRok = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbClan = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFIlm = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUnos
            // 
            this.btnUnos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(175)))), ((int)(((byte)(188)))));
            this.btnUnos.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnUnos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(23)))), ((int)(((byte)(80)))));
            this.btnUnos.Location = new System.Drawing.Point(201, 624);
            this.btnUnos.Name = "btnUnos";
            this.btnUnos.Size = new System.Drawing.Size(158, 48);
            this.btnUnos.TabIndex = 36;
            this.btnUnos.Text = "Unos";
            this.btnUnos.UseVisualStyleBackColor = false;
            this.btnUnos.Click += new System.EventHandler(this.btnUnos_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(76)))), ((int)(((byte)(124)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 433);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(338, 178);
            this.dataGridView1.TabIndex = 33;
            // 
            // btnMinus
            // 
            this.btnMinus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(175)))), ((int)(((byte)(188)))));
            this.btnMinus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(23)))), ((int)(((byte)(80)))));
            this.btnMinus.Location = new System.Drawing.Point(21, 363);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(158, 48);
            this.btnMinus.TabIndex = 32;
            this.btnMinus.Text = "_";
            this.btnMinus.UseVisualStyleBackColor = false;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(226)))), ((int)(((byte)(223)))));
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 31;
            this.label1.Text = "Primerak:";
            // 
            // cmbPrimerak
            // 
            this.cmbPrimerak.FormattingEnabled = true;
            this.cmbPrimerak.Location = new System.Drawing.Point(19, 318);
            this.cmbPrimerak.Name = "cmbPrimerak";
            this.cmbPrimerak.Size = new System.Drawing.Size(340, 24);
            this.cmbPrimerak.TabIndex = 30;
            // 
            // btnPlus
            // 
            this.btnPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(175)))), ((int)(((byte)(188)))));
            this.btnPlus.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(23)))), ((int)(((byte)(80)))));
            this.btnPlus.Location = new System.Drawing.Point(202, 363);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(158, 48);
            this.btnPlus.TabIndex = 29;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = false;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(226)))), ((int)(((byte)(223)))));
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "Rok za iznajmljivanje u danima:";
            // 
            // txtRok
            // 
            this.txtRok.AcceptsReturn = true;
            this.txtRok.Location = new System.Drawing.Point(21, 46);
            this.txtRok.Name = "txtRok";
            this.txtRok.Size = new System.Drawing.Size(340, 22);
            this.txtRok.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(226)))), ((int)(((byte)(223)))));
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 19);
            this.label2.TabIndex = 38;
            this.label2.Text = "Clan:";
            // 
            // cmbClan
            // 
            this.cmbClan.FormattingEnabled = true;
            this.cmbClan.Location = new System.Drawing.Point(19, 121);
            this.cmbClan.Name = "cmbClan";
            this.cmbClan.Size = new System.Drawing.Size(340, 24);
            this.cmbClan.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(226)))), ((int)(((byte)(223)))));
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 19);
            this.label4.TabIndex = 40;
            this.label4.Text = "Film:";
            // 
            // cmbFIlm
            // 
            this.cmbFIlm.FormattingEnabled = true;
            this.cmbFIlm.Location = new System.Drawing.Point(19, 248);
            this.cmbFIlm.Name = "cmbFIlm";
            this.cmbFIlm.Size = new System.Drawing.Size(340, 24);
            this.cmbFIlm.TabIndex = 39;
            this.cmbFIlm.SelectedIndexChanged += new System.EventHandler(this.cmbFIlm_SelectedIndexChanged);
            // 
            // UnosIznajmljivanjaGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(372, 682);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbFIlm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbClan);
            this.Controls.Add(this.btnUnos);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbPrimerak);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRok);
            this.Name = "UnosIznajmljivanjaGui";
            this.Text = "UnosIznajmljivanjaGui";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUnos;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPrimerak;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRok;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbClan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbFIlm;
    }
}