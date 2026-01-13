namespace CHSInventory
{
    partial class Nurses
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
            this.btnlogout = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnstock = new Guna.UI2.WinForms.Guna2Button();
            this.btnpatients = new Guna.UI2.WinForms.Guna2Button();
            this.btnDispense = new Guna.UI2.WinForms.Guna2Button();
            this.btnexpired = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnexitsta = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Firebrick;
            this.panel1.Controls.Add(this.btnlogout);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnstock);
            this.panel1.Controls.Add(this.btnpatients);
            this.panel1.Controls.Add(this.btnDispense);
            this.panel1.Controls.Add(this.btnexpired);
            this.panel1.Controls.Add(this.guna2Button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 1050);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnlogout
            // 
            this.btnlogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnlogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnlogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnlogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnlogout.FillColor = System.Drawing.Color.Firebrick;
            this.btnlogout.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnlogout.ForeColor = System.Drawing.Color.White;
            this.btnlogout.Location = new System.Drawing.Point(29, 919);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(282, 59);
            this.btnlogout.TabIndex = 8;
            this.btnlogout.Text = "LOG OUT";
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(45, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nurse Panel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(34, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 40);
            this.label1.TabIndex = 6;
            this.label1.Text = "CHS MEDICINE";
            // 
            // btnstock
            // 
            this.btnstock.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnstock.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnstock.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnstock.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnstock.FillColor = System.Drawing.Color.Firebrick;
            this.btnstock.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnstock.ForeColor = System.Drawing.Color.White;
            this.btnstock.Location = new System.Drawing.Point(29, 768);
            this.btnstock.Name = "btnstock";
            this.btnstock.Size = new System.Drawing.Size(282, 59);
            this.btnstock.TabIndex = 5;
            this.btnstock.Text = "💊Stock";
            this.btnstock.Click += new System.EventHandler(this.btnstock_Click);
            // 
            // btnpatients
            // 
            this.btnpatients.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnpatients.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnpatients.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnpatients.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnpatients.FillColor = System.Drawing.Color.Firebrick;
            this.btnpatients.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnpatients.ForeColor = System.Drawing.Color.White;
            this.btnpatients.Location = new System.Drawing.Point(29, 643);
            this.btnpatients.Name = "btnpatients";
            this.btnpatients.Size = new System.Drawing.Size(282, 59);
            this.btnpatients.TabIndex = 3;
            this.btnpatients.Text = "👤Patients";
            this.btnpatients.Click += new System.EventHandler(this.btnpatients_Click);
            // 
            // btnDispense
            // 
            this.btnDispense.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDispense.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDispense.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDispense.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDispense.FillColor = System.Drawing.Color.Firebrick;
            this.btnDispense.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDispense.ForeColor = System.Drawing.Color.White;
            this.btnDispense.Location = new System.Drawing.Point(29, 513);
            this.btnDispense.Name = "btnDispense";
            this.btnDispense.Size = new System.Drawing.Size(282, 59);
            this.btnDispense.TabIndex = 4;
            this.btnDispense.Text = "📤Dispense";
            this.btnDispense.Click += new System.EventHandler(this.guna2Button4_Click);
            // 
            // btnexpired
            // 
            this.btnexpired.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnexpired.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnexpired.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnexpired.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnexpired.FillColor = System.Drawing.Color.Firebrick;
            this.btnexpired.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnexpired.ForeColor = System.Drawing.Color.White;
            this.btnexpired.Location = new System.Drawing.Point(29, 382);
            this.btnexpired.Name = "btnexpired";
            this.btnexpired.Size = new System.Drawing.Size(282, 59);
            this.btnexpired.TabIndex = 3;
            this.btnexpired.Text = "⏰Expired";
            this.btnexpired.Click += new System.EventHandler(this.btnexpired_Click);
            // 
            // guna2Button2
            // 
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.Firebrick;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(29, 256);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(282, 59);
            this.guna2Button2.TabIndex = 2;
            this.guna2Button2.Text = "💊Inventory";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnexitsta);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(337, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1587, 73);
            this.panel2.TabIndex = 2;
            // 
            // btnexitsta
            // 
            this.btnexitsta.BackColor = System.Drawing.Color.Red;
            this.btnexitsta.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexitsta.ForeColor = System.Drawing.Color.White;
            this.btnexitsta.Location = new System.Drawing.Point(1531, 12);
            this.btnexitsta.Name = "btnexitsta";
            this.btnexitsta.Size = new System.Drawing.Size(44, 43);
            this.btnexitsta.TabIndex = 1;
            this.btnexitsta.Text = "X";
            this.btnexitsta.UseVisualStyleBackColor = false;
            this.btnexitsta.Click += new System.EventHandler(this.btnexitsta_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(337, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1587, 977);
            this.panel3.TabIndex = 3;
            // 
            // Nurses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Nurses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nurse";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Nurse_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnpatients;
        private Guna.UI2.WinForms.Guna2Button btnDispense;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button btnexpired;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnexitsta;
        private Guna.UI2.WinForms.Guna2Button btnlogout;
        private Guna.UI2.WinForms.Guna2Button btnstock;
    }
}