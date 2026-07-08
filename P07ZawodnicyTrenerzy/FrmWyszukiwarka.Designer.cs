namespace P07ZawodnicyTrenerzy
{
    partial class FrmWyszukiwarka
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
            this.txtSzukaj = new System.Windows.Forms.TextBox();
            this.btnSzukaj = new System.Windows.Forms.Button();
            this.pnlWyniki = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // txtSzukaj
            // 
            this.txtSzukaj.Location = new System.Drawing.Point(34, 28);
            this.txtSzukaj.Name = "txtSzukaj";
            this.txtSzukaj.Size = new System.Drawing.Size(337, 20);
            this.txtSzukaj.TabIndex = 2;
            // 
            // btnSzukaj
            // 
            this.btnSzukaj.Location = new System.Drawing.Point(377, 28);
            this.btnSzukaj.Name = "btnSzukaj";
            this.btnSzukaj.Size = new System.Drawing.Size(75, 23);
            this.btnSzukaj.TabIndex = 3;
            this.btnSzukaj.Text = "Szukaj";
            this.btnSzukaj.UseVisualStyleBackColor = true;
            this.btnSzukaj.Click += new System.EventHandler(this.btnSzukaj_Click);
            // 
            // pnlWyniki
            // 
            this.pnlWyniki.Location = new System.Drawing.Point(34, 57);
            this.pnlWyniki.Name = "pnlWyniki";
            this.pnlWyniki.Size = new System.Drawing.Size(409, 298);
            this.pnlWyniki.TabIndex = 4;
            // 
            // FrmWyszukiwarka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 366);
            this.Controls.Add(this.pnlWyniki);
            this.Controls.Add(this.btnSzukaj);
            this.Controls.Add(this.txtSzukaj);
            this.Name = "FrmWyszukiwarka";
            this.Text = "FrmWyszukiwarka";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSzukaj;
        private System.Windows.Forms.Button btnSzukaj;
        private System.Windows.Forms.Panel pnlWyniki;
    }
}