namespace P07ZawodnicyTrenerzy
{
    partial class FrmStartowy
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
            this.lbDane = new System.Windows.Forms.ListBox();
            this.btnSzczegoly = new System.Windows.Forms.Button();
            this.cbKraje = new System.Windows.Forms.ComboBox();
            this.btnNowy = new System.Windows.Forms.Button();
            this.btnOdswiez = new System.Windows.Forms.Button();
            this.btnGenerujPDF = new System.Windows.Forms.Button();
            this.btnSredniWiek = new System.Windows.Forms.Button();
            this.pnlFlagi = new System.Windows.Forms.Panel();
            this.btnWyszukiwarka = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbDane
            // 
            this.lbDane.FormattingEnabled = true;
            this.lbDane.Location = new System.Drawing.Point(32, 53);
            this.lbDane.Name = "lbDane";
            this.lbDane.Size = new System.Drawing.Size(257, 199);
            this.lbDane.TabIndex = 0;
            // 
            // btnSzczegoly
            // 
            this.btnSzczegoly.Location = new System.Drawing.Point(295, 83);
            this.btnSzczegoly.Name = "btnSzczegoly";
            this.btnSzczegoly.Size = new System.Drawing.Size(75, 23);
            this.btnSzczegoly.TabIndex = 1;
            this.btnSzczegoly.Text = "Szczegóły";
            this.btnSzczegoly.UseVisualStyleBackColor = true;
            this.btnSzczegoly.Click += new System.EventHandler(this.btnSzczegoly_Click);
            // 
            // cbKraje
            // 
            this.cbKraje.FormattingEnabled = true;
            this.cbKraje.Location = new System.Drawing.Point(32, 26);
            this.cbKraje.Name = "cbKraje";
            this.cbKraje.Size = new System.Drawing.Size(257, 21);
            this.cbKraje.TabIndex = 2;
            this.cbKraje.SelectedIndexChanged += new System.EventHandler(this.cbKraje_SelectedIndexChanged);
            // 
            // btnNowy
            // 
            this.btnNowy.Location = new System.Drawing.Point(295, 54);
            this.btnNowy.Name = "btnNowy";
            this.btnNowy.Size = new System.Drawing.Size(75, 23);
            this.btnNowy.TabIndex = 10;
            this.btnNowy.Text = "Nowy";
            this.btnNowy.UseVisualStyleBackColor = true;
            this.btnNowy.Click += new System.EventHandler(this.btnNowy_Click);
            // 
            // btnOdswiez
            // 
            this.btnOdswiez.Location = new System.Drawing.Point(296, 113);
            this.btnOdswiez.Name = "btnOdswiez";
            this.btnOdswiez.Size = new System.Drawing.Size(75, 23);
            this.btnOdswiez.TabIndex = 11;
            this.btnOdswiez.Text = "Odswiez";
            this.btnOdswiez.UseVisualStyleBackColor = true;
            this.btnOdswiez.Click += new System.EventHandler(this.btnOdswiez_Click);
            // 
            // btnGenerujPDF
            // 
            this.btnGenerujPDF.Location = new System.Drawing.Point(295, 142);
            this.btnGenerujPDF.Name = "btnGenerujPDF";
            this.btnGenerujPDF.Size = new System.Drawing.Size(75, 23);
            this.btnGenerujPDF.TabIndex = 12;
            this.btnGenerujPDF.Text = "Raport PDF";
            this.btnGenerujPDF.UseVisualStyleBackColor = true;
            this.btnGenerujPDF.Click += new System.EventHandler(this.btnGenerujPDF_Click);
            // 
            // btnSredniWiek
            // 
            this.btnSredniWiek.Location = new System.Drawing.Point(296, 172);
            this.btnSredniWiek.Name = "btnSredniWiek";
            this.btnSredniWiek.Size = new System.Drawing.Size(75, 23);
            this.btnSredniWiek.TabIndex = 13;
            this.btnSredniWiek.Text = "Średni Wiek";
            this.btnSredniWiek.UseVisualStyleBackColor = true;
            this.btnSredniWiek.Click += new System.EventHandler(this.btnSredniWiek_Click);
            // 
            // pnlFlagi
            // 
            this.pnlFlagi.Location = new System.Drawing.Point(12, 276);
            this.pnlFlagi.Name = "pnlFlagi";
            this.pnlFlagi.Size = new System.Drawing.Size(368, 82);
            this.pnlFlagi.TabIndex = 16;
            // 
            // btnWyszukiwarka
            // 
            this.btnWyszukiwarka.Location = new System.Drawing.Point(295, 201);
            this.btnWyszukiwarka.Name = "btnWyszukiwarka";
            this.btnWyszukiwarka.Size = new System.Drawing.Size(75, 23);
            this.btnWyszukiwarka.TabIndex = 17;
            this.btnWyszukiwarka.Text = "Wyszukiwarka";
            this.btnWyszukiwarka.UseVisualStyleBackColor = true;
            this.btnWyszukiwarka.Click += new System.EventHandler(this.btnWyszukiwarka_Click);
            // 
            // FrmStartowy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 370);
            this.Controls.Add(this.btnWyszukiwarka);
            this.Controls.Add(this.pnlFlagi);
            this.Controls.Add(this.btnSredniWiek);
            this.Controls.Add(this.btnGenerujPDF);
            this.Controls.Add(this.btnOdswiez);
            this.Controls.Add(this.btnNowy);
            this.Controls.Add(this.cbKraje);
            this.Controls.Add(this.btnSzczegoly);
            this.Controls.Add(this.lbDane);
            this.Name = "FrmStartowy";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbDane;
        private System.Windows.Forms.Button btnSzczegoly;
        private System.Windows.Forms.ComboBox cbKraje;
        private System.Windows.Forms.Button btnNowy;
        private System.Windows.Forms.Button btnOdswiez;
        private System.Windows.Forms.Button btnGenerujPDF;
        private System.Windows.Forms.Button btnSredniWiek;
        private System.Windows.Forms.Panel pnlFlagi;
        private System.Windows.Forms.Button btnWyszukiwarka;
    }
}

