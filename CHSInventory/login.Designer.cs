namespace CHSInventory
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtemail1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtpassword1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.cmbrole1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnlogin1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Firebrick;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 910);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CHSInventory.Properties.Resources.University_of_Mindanao_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(116, 212);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(323, 334);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(49, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "CHS INVENTORY SYSTEM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(629, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 48);
            this.label2.TabIndex = 2;
            this.label2.Text = "LOGIN";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(631, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 32);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password";
            // 
            // txtemail1
            // 
            this.txtemail1.BorderColor = System.Drawing.Color.Silver;
            this.txtemail1.BorderRadius = 15;
            this.txtemail1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtemail1.DefaultText = "";
            this.txtemail1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtemail1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtemail1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtemail1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtemail1.FillColor = System.Drawing.Color.Gainsboro;
            this.txtemail1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtemail1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtemail1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtemail1.Location = new System.Drawing.Point(637, 201);
            this.txtemail1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtemail1.Name = "txtemail1";
            this.txtemail1.PlaceholderText = "";
            this.txtemail1.SelectedText = "";
            this.txtemail1.Size = new System.Drawing.Size(497, 60);
            this.txtemail1.TabIndex = 12;
            this.txtemail1.TextChanged += new System.EventHandler(this.txtemail1_TextChanged);
            // 
            // txtpassword1
            // 
            this.txtpassword1.BorderRadius = 15;
            this.txtpassword1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpassword1.DefaultText = "";
            this.txtpassword1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtpassword1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtpassword1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpassword1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpassword1.FillColor = System.Drawing.Color.Gainsboro;
            this.txtpassword1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpassword1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtpassword1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpassword1.Location = new System.Drawing.Point(637, 325);
            this.txtpassword1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtpassword1.Name = "txtpassword1";
            this.txtpassword1.PlaceholderText = "";
            this.txtpassword1.SelectedText = "";
            this.txtpassword1.Size = new System.Drawing.Size(497, 60);
            this.txtpassword1.TabIndex = 13;
            this.txtpassword1.TextChanged += new System.EventHandler(this.txtpassword1_TextChanged);
            // 
            // cmbrole1
            // 
            this.cmbrole1.AutoRoundedCorners = true;
            this.cmbrole1.BackColor = System.Drawing.Color.Transparent;
            this.cmbrole1.BorderRadius = 17;
            this.cmbrole1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbrole1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbrole1.FillColor = System.Drawing.Color.Gainsboro;
            this.cmbrole1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbrole1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbrole1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbrole1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbrole1.ItemHeight = 30;
            this.cmbrole1.Items.AddRange(new object[] {
            "Admin",
            "Nurse",
            "STA"});
            this.cmbrole1.Location = new System.Drawing.Point(637, 449);
            this.cmbrole1.Name = "cmbrole1";
            this.cmbrole1.Size = new System.Drawing.Size(488, 36);
            this.cmbrole1.TabIndex = 14;
            this.cmbrole1.SelectedIndexChanged += new System.EventHandler(this.guna2ComboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(641, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 32);
            this.label3.TabIndex = 15;
            this.label3.Text = "Role";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(641, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 32);
            this.label5.TabIndex = 16;
            this.label5.Text = "Email";
            // 
            // btnlogin1
            // 
            this.btnlogin1.BorderRadius = 15;
            this.btnlogin1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnlogin1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnlogin1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnlogin1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnlogin1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnlogin1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnlogin1.ForeColor = System.Drawing.Color.White;
            this.btnlogin1.Location = new System.Drawing.Point(637, 541);
            this.btnlogin1.Name = "btnlogin1";
            this.btnlogin1.Size = new System.Drawing.Size(497, 60);
            this.btnlogin1.TabIndex = 17;
            this.btnlogin1.Text = "LOGIN";
            this.btnlogin1.Click += new System.EventHandler(this.btnlogin1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1167, 692);
            this.Controls.Add(this.btnlogin1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbrole1);
            this.Controls.Add(this.txtpassword1);
            this.Controls.Add(this.txtemail1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtemail1;
        private Guna.UI2.WinForms.Guna2TextBox txtpassword1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbrole1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btnlogin1;
    }
}

