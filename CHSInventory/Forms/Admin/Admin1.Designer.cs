namespace CHSInventory
{
    partial class Admin1
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnexpiredAdmin = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.btnuserAdmin = new Guna.UI2.WinForms.Guna2Button();
            this.btninventoryAdmin = new Guna.UI2.WinForms.Guna2Button();
            this.btndashboardAdmin = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnexitadmin = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Firebrick;
            this.panel1.Controls.Add(this.btnlogout);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnexpiredAdmin);
            this.panel1.Controls.Add(this.guna2Button5);
            this.panel1.Controls.Add(this.btnuserAdmin);
            this.panel1.Controls.Add(this.btninventoryAdmin);
            this.panel1.Controls.Add(this.btndashboardAdmin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 1106);
            this.panel1.TabIndex = 0;
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
            this.btnlogout.Location = new System.Drawing.Point(23, 969);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(282, 59);
            this.btnlogout.TabIndex = 9;
            this.btnlogout.Text = "LOG OUT";
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(40, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Admin Panel";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(28, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHS MEDICINE";
            // 
            // btnexpiredAdmin
            // 
            this.btnexpiredAdmin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnexpiredAdmin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnexpiredAdmin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnexpiredAdmin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnexpiredAdmin.FillColor = System.Drawing.Color.Firebrick;
            this.btnexpiredAdmin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnexpiredAdmin.ForeColor = System.Drawing.Color.White;
            this.btnexpiredAdmin.Location = new System.Drawing.Point(23, 709);
            this.btnexpiredAdmin.Name = "btnexpiredAdmin";
            this.btnexpiredAdmin.Size = new System.Drawing.Size(282, 57);
            this.btnexpiredAdmin.TabIndex = 5;
            this.btnexpiredAdmin.Text = "⏰Expired";
            this.btnexpiredAdmin.Click += new System.EventHandler(this.btnexpiredAdmin_Click);
            // 
            // guna2Button5
            // 
            this.guna2Button5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button5.FillColor = System.Drawing.Color.Firebrick;
            this.guna2Button5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.guna2Button5.ForeColor = System.Drawing.Color.White;
            this.guna2Button5.Location = new System.Drawing.Point(23, 596);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.Size = new System.Drawing.Size(282, 61);
            this.guna2Button5.TabIndex = 3;
            this.guna2Button5.Text = "👤Patients";
            this.guna2Button5.Click += new System.EventHandler(this.guna2Button5_Click);
            // 
            // btnuserAdmin
            // 
            this.btnuserAdmin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnuserAdmin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnuserAdmin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnuserAdmin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnuserAdmin.FillColor = System.Drawing.Color.Firebrick;
            this.btnuserAdmin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnuserAdmin.ForeColor = System.Drawing.Color.White;
            this.btnuserAdmin.Location = new System.Drawing.Point(23, 369);
            this.btnuserAdmin.Name = "btnuserAdmin";
            this.btnuserAdmin.Size = new System.Drawing.Size(282, 60);
            this.btnuserAdmin.TabIndex = 3;
            this.btnuserAdmin.Text = "👥User";
            this.btnuserAdmin.Click += new System.EventHandler(this.btnuserAdmin_Click);
            // 
            // btninventoryAdmin
            // 
            this.btninventoryAdmin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btninventoryAdmin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btninventoryAdmin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btninventoryAdmin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btninventoryAdmin.FillColor = System.Drawing.Color.Firebrick;
            this.btninventoryAdmin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btninventoryAdmin.ForeColor = System.Drawing.Color.White;
            this.btninventoryAdmin.Location = new System.Drawing.Point(23, 484);
            this.btninventoryAdmin.Name = "btninventoryAdmin";
            this.btninventoryAdmin.Size = new System.Drawing.Size(282, 63);
            this.btninventoryAdmin.TabIndex = 2;
            this.btninventoryAdmin.Text = "💊Inventory";
            this.btninventoryAdmin.Click += new System.EventHandler(this.btninventoryAdmin_Click);
            // 
            // btndashboardAdmin
            // 
            this.btndashboardAdmin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btndashboardAdmin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btndashboardAdmin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btndashboardAdmin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btndashboardAdmin.FillColor = System.Drawing.Color.Firebrick;
            this.btndashboardAdmin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btndashboardAdmin.ForeColor = System.Drawing.Color.White;
            this.btndashboardAdmin.Location = new System.Drawing.Point(23, 264);
            this.btndashboardAdmin.Name = "btndashboardAdmin";
            this.btndashboardAdmin.Size = new System.Drawing.Size(282, 59);
            this.btndashboardAdmin.TabIndex = 1;
            this.btndashboardAdmin.Text = "🏠Dashboard";
            this.btndashboardAdmin.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.btnexitadmin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(337, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1609, 73);
            this.panel2.TabIndex = 1;
            // 
            // btnexitadmin
            // 
            this.btnexitadmin.BackColor = System.Drawing.Color.Red;
            this.btnexitadmin.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexitadmin.ForeColor = System.Drawing.Color.White;
            this.btnexitadmin.Location = new System.Drawing.Point(1530, 18);
            this.btnexitadmin.Name = "btnexitadmin";
            this.btnexitadmin.Size = new System.Drawing.Size(44, 43);
            this.btnexitadmin.TabIndex = 0;
            this.btnexitadmin.Text = "X";
            this.btnexitadmin.UseVisualStyleBackColor = false;
            this.btnexitadmin.Click += new System.EventHandler(this.btnexitadmin_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(337, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1609, 1033);
            this.panel3.TabIndex = 2;
            // 
            // Admin1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1946, 1106);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btndashboardAdmin;
        private Guna.UI2.WinForms.Guna2Button btninventoryAdmin;
        private Guna.UI2.WinForms.Guna2Button btnexpiredAdmin;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Guna.UI2.WinForms.Guna2Button btnuserAdmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnexitadmin;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI2.WinForms.Guna2Button btnlogout;
    }
}