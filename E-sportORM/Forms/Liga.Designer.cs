namespace E_sportORM.Forms
{
    partial class Liga
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NameOfTeam = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Win = new System.Windows.Forms.TextBox();
            this.Status = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.OD = new System.Windows.Forms.MonthCalendar();
            this.DO = new System.Windows.Forms.MonthCalendar();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.typ = new System.Windows.Forms.ComboBox();
            this.Poz = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(433, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "_______________________________________________________________________";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vytvoření ligy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(16, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Název";
            // 
            // NameOfTeam
            // 
            this.NameOfTeam.Location = new System.Drawing.Point(100, 92);
            this.NameOfTeam.Name = "NameOfTeam";
            this.NameOfTeam.Size = new System.Drawing.Size(100, 20);
            this.NameOfTeam.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(16, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Požadavek";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(259, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Výhra";
            // 
            // Win
            // 
            this.Win.Location = new System.Drawing.Point(313, 92);
            this.Win.Name = "Win";
            this.Win.Size = new System.Drawing.Size(100, 20);
            this.Win.TabIndex = 9;
            // 
            // Status
            // 
            this.Status.DisplayMember = "(none)";
            this.Status.FormattingEnabled = true;
            this.Status.Items.AddRange(new object[] {
            "Probíhající"});
            this.Status.Location = new System.Drawing.Point(313, 139);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(100, 21);
            this.Status.TabIndex = 10;
            this.Status.Tag = "";
            this.Status.ValueMember = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(259, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Status";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(340, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Konec ligy";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(49, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Začátek ligy";
            // 
            // OD
            // 
            this.OD.Location = new System.Drawing.Point(19, 207);
            this.OD.MaxSelectionCount = 1;
            this.OD.Name = "OD";
            this.OD.TabIndex = 14;
            // 
            // DO
            // 
            this.DO.Location = new System.Drawing.Point(295, 207);
            this.DO.MaxSelectionCount = 1;
            this.DO.Name = "DO";
            this.DO.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Vytvoření ligy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(203, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Typ";
            // 
            // typ
            // 
            this.typ.DisplayMember = "(none)";
            this.typ.FormattingEnabled = true;
            this.typ.Items.AddRange(new object[] {
            "Týmová liga",
            "Hráčská liga"});
            this.typ.Location = new System.Drawing.Point(181, 210);
            this.typ.Name = "typ";
            this.typ.Size = new System.Drawing.Size(100, 21);
            this.typ.TabIndex = 18;
            this.typ.Tag = "";
            this.typ.ValueMember = "0";
            // 
            // Poz
            // 
            this.Poz.DisplayMember = "(none)";
            this.Poz.FormattingEnabled = true;
            this.Poz.Items.AddRange(new object[] {
            "Žádný",
            "Alespoň 5 lidí"});
            this.Poz.Location = new System.Drawing.Point(100, 138);
            this.Poz.Name = "Poz";
            this.Poz.Size = new System.Drawing.Size(100, 21);
            this.Poz.TabIndex = 19;
            this.Poz.Tag = "";
            this.Poz.ValueMember = "0";
            // 
            // Liga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 441);
            this.Controls.Add(this.Poz);
            this.Controls.Add(this.typ);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DO);
            this.Controls.Add(this.OD);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Win);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NameOfTeam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Liga";
            this.Text = "Vytvoření ligy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NameOfTeam;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Win;
        private System.Windows.Forms.ComboBox Status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MonthCalendar OD;
        private System.Windows.Forms.MonthCalendar DO;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox typ;
        private System.Windows.Forms.ComboBox Poz;
    }
}