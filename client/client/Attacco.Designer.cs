namespace client
{
    partial class Attacco
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRiga = new System.Windows.Forms.ComboBox();
            this.comboBoxColonna = new System.Windows.Forms.ComboBox();
            this.buttonAttacca = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Riga";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Colonna";
            // 
            // comboBoxRiga
            // 
            this.comboBoxRiga.FormattingEnabled = true;
            this.comboBoxRiga.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBoxRiga.Location = new System.Drawing.Point(68, 51);
            this.comboBoxRiga.Name = "comboBoxRiga";
            this.comboBoxRiga.Size = new System.Drawing.Size(76, 21);
            this.comboBoxRiga.TabIndex = 2;
            // 
            // comboBoxColonna
            // 
            this.comboBoxColonna.FormattingEnabled = true;
            this.comboBoxColonna.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBoxColonna.Location = new System.Drawing.Point(183, 51);
            this.comboBoxColonna.Name = "comboBoxColonna";
            this.comboBoxColonna.Size = new System.Drawing.Size(76, 21);
            this.comboBoxColonna.TabIndex = 3;
            // 
            // buttonAttacca
            // 
            this.buttonAttacca.Location = new System.Drawing.Point(128, 99);
            this.buttonAttacca.Name = "buttonAttacca";
            this.buttonAttacca.Size = new System.Drawing.Size(75, 23);
            this.buttonAttacca.TabIndex = 4;
            this.buttonAttacca.Text = "ATTACCO!";
            this.buttonAttacca.UseVisualStyleBackColor = true;
            this.buttonAttacca.Click += new System.EventHandler(this.buttonAttacca_Click);
            // 
            // Attacco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(332, 159);
            this.Controls.Add(this.buttonAttacca);
            this.Controls.Add(this.comboBoxColonna);
            this.Controls.Add(this.comboBoxRiga);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Attacco";
            this.Text = "Attacco";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxRiga;
        private System.Windows.Forms.ComboBox comboBoxColonna;
        private System.Windows.Forms.Button buttonAttacca;
    }
}