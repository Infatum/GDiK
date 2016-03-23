namespace Laba4_Forms
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
            this.textField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chooseFileBtn = new System.Windows.Forms.Button();
            this.calculatedSymbolsField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.clculateSymbolsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textField
            // 
            this.textField.Location = new System.Drawing.Point(12, 31);
            this.textField.Multiline = true;
            this.textField.Name = "textField";
            this.textField.Size = new System.Drawing.Size(340, 297);
            this.textField.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Jokerman", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Image = global::Laba4_Forms.Properties.Resources.lol;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(-2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Текст:";
            // 
            // chooseFileBtn
            // 
            this.chooseFileBtn.BackColor = System.Drawing.Color.Transparent;
            this.chooseFileBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chooseFileBtn.Font = new System.Drawing.Font("Britannic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseFileBtn.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.chooseFileBtn.Location = new System.Drawing.Point(12, 334);
            this.chooseFileBtn.Name = "chooseFileBtn";
            this.chooseFileBtn.Size = new System.Drawing.Size(177, 36);
            this.chooseFileBtn.TabIndex = 2;
            this.chooseFileBtn.Text = "Вибрати файл";
            this.chooseFileBtn.UseVisualStyleBackColor = false;
            this.chooseFileBtn.Click += new System.EventHandler(this.chooseFileBtn_Click);
            // 
            // calculatedSymbolsField
            // 
            this.calculatedSymbolsField.Location = new System.Drawing.Point(373, 31);
            this.calculatedSymbolsField.Multiline = true;
            this.calculatedSymbolsField.Name = "calculatedSymbolsField";
            this.calculatedSymbolsField.Size = new System.Drawing.Size(279, 297);
            this.calculatedSymbolsField.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Niagara Engraved", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Image = global::Laba4_Forms.Properties.Resources.lol;
            this.label2.Location = new System.Drawing.Point(379, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Підрахувати входження символів:";
            // 
            // clculateSymbolsBtn
            // 
            this.clculateSymbolsBtn.BackColor = System.Drawing.Color.Transparent;
            this.clculateSymbolsBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.clculateSymbolsBtn.Font = new System.Drawing.Font("Britannic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clculateSymbolsBtn.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.clculateSymbolsBtn.Location = new System.Drawing.Point(491, 334);
            this.clculateSymbolsBtn.Name = "clculateSymbolsBtn";
            this.clculateSymbolsBtn.Size = new System.Drawing.Size(161, 36);
            this.clculateSymbolsBtn.TabIndex = 5;
            this.clculateSymbolsBtn.Text = "Підрахувати";
            this.clculateSymbolsBtn.UseVisualStyleBackColor = false;
            this.clculateSymbolsBtn.Click += new System.EventHandler(this.clculateSymbolsBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Coral;
            this.BackgroundImage = global::Laba4_Forms.Properties.Resources.lol;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(663, 376);
            this.Controls.Add(this.clculateSymbolsBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.calculatedSymbolsField);
            this.Controls.Add(this.chooseFileBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textField);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button chooseFileBtn;
        private System.Windows.Forms.TextBox calculatedSymbolsField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clculateSymbolsBtn;
    }
}

