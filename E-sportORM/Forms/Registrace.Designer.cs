namespace E_sportORM.Forms
{
    partial class Registrace
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Nick = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.Pass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.State = new System.Windows.Forms.ComboBox();
            this.Reg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registrovat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(433, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "_______________________________________________________________________";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(16, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Přezdívka";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(16, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(244, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Heslo";
            // 
            // Nick
            // 
            this.Nick.Location = new System.Drawing.Point(101, 98);
            this.Nick.Name = "Nick";
            this.Nick.Size = new System.Drawing.Size(100, 20);
            this.Nick.TabIndex = 5;
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(101, 153);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(100, 20);
            this.Email.TabIndex = 6;
            // 
            // Pass
            // 
            this.Pass.Location = new System.Drawing.Point(305, 98);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(121, 20);
            this.Pass.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(244, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Lokace";
            // 
            // State
            // 
            this.State.DisplayMember = "(none)";
            this.State.FormattingEnabled = true;
            this.State.Items.AddRange(new object[] {
            "Evropa",
            "Amerika",
            "Asie",
            "Australie"});
            this.State.Location = new System.Drawing.Point(304, 152);
            this.State.Name = "State";
            this.State.Size = new System.Drawing.Size(121, 21);
            this.State.TabIndex = 9;
            this.State.Tag = "";
            this.State.ValueMember = "0";
            // 
            // Reg
            // 
            this.Reg.Location = new System.Drawing.Point(194, 259);
            this.Reg.Name = "Reg";
            this.Reg.Size = new System.Drawing.Size(75, 23);
            this.Reg.TabIndex = 10;
            this.Reg.Text = "Registrace";
            this.Reg.UseVisualStyleBackColor = true;
            this.Reg.Click += new System.EventHandler(this.Reg_Click);
            // 
            // Registrace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 297);
            this.Controls.Add(this.Reg);
            this.Controls.Add(this.State);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Nick);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Registrace";
            this.Text = "Registrace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Nick;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.TextBox Pass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox State;
        private System.Windows.Forms.Button Reg;
    }
}