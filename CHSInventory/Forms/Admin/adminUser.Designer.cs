namespace CHSInventory
{
    partial class AdminUser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbroleadmin = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtpasswordadmin = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtboxemailadmin = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtlastnameadmin = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtfirstnameadmin = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnaddadmin = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.cmbroleadmin);
            this.panel1.Controls.Add(this.txtpasswordadmin);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtboxemailadmin);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtlastnameadmin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtfirstnameadmin);
            this.panel1.Controls.Add(this.btnaddadmin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(50, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 506);
            this.panel1.TabIndex = 6;
           
            // 
            // cmbroleadmin
            // 
            this.cmbroleadmin.AutoRoundedCorners = true;
            this.cmbroleadmin.BackColor = System.Drawing.Color.Transparent;
            this.cmbroleadmin.BorderRadius = 17;
            this.cmbroleadmin.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbroleadmin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbroleadmin.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbroleadmin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbroleadmin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbroleadmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbroleadmin.ItemHeight = 30;
            this.cmbroleadmin.Items.AddRange(new object[] {
            "Admin",
            "Nurses",
            "STA"});
            this.cmbroleadmin.Location = new System.Drawing.Point(167, 329);
            this.cmbroleadmin.Name = "cmbroleadmin";
            this.cmbroleadmin.Size = new System.Drawing.Size(271, 36);
            this.cmbroleadmin.TabIndex = 23;
            
            // 
            // txtpasswordadmin
            // 
            this.txtpasswordadmin.BorderRadius = 15;
            this.txtpasswordadmin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtpasswordadmin.DefaultText = "";
            this.txtpasswordadmin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtpasswordadmin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtpasswordadmin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpasswordadmin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtpasswordadmin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpasswordadmin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtpasswordadmin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtpasswordadmin.Location = new System.Drawing.Point(167, 269);
            this.txtpasswordadmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtpasswordadmin.Name = "txtpasswordadmin";
            this.txtpasswordadmin.PlaceholderText = "";
            this.txtpasswordadmin.SelectedText = "";
            this.txtpasswordadmin.Size = new System.Drawing.Size(271, 51);
            this.txtpasswordadmin.TabIndex = 21;
         
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 32);
            this.label8.TabIndex = 9;
            this.label8.Text = "Users Details";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 32);
            this.label5.TabIndex = 20;
            this.label5.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 32);
            this.label4.TabIndex = 18;
            this.label4.Text = "Role:";
            // 
            // txtboxemailadmin
            // 
            this.txtboxemailadmin.BorderRadius = 15;
            this.txtboxemailadmin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtboxemailadmin.DefaultText = "";
            this.txtboxemailadmin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtboxemailadmin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtboxemailadmin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxemailadmin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtboxemailadmin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxemailadmin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtboxemailadmin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtboxemailadmin.Location = new System.Drawing.Point(167, 208);
            this.txtboxemailadmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtboxemailadmin.Name = "txtboxemailadmin";
            this.txtboxemailadmin.PlaceholderText = "";
            this.txtboxemailadmin.SelectedText = "";
            this.txtboxemailadmin.Size = new System.Drawing.Size(271, 51);
            this.txtboxemailadmin.TabIndex = 17;
          
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 32);
            this.label3.TabIndex = 16;
            this.label3.Text = "Email:";
            // 
            // txtlastnameadmin
            // 
            this.txtlastnameadmin.BorderRadius = 15;
            this.txtlastnameadmin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtlastnameadmin.DefaultText = "";
            this.txtlastnameadmin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtlastnameadmin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtlastnameadmin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtlastnameadmin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtlastnameadmin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtlastnameadmin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtlastnameadmin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtlastnameadmin.Location = new System.Drawing.Point(167, 147);
            this.txtlastnameadmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtlastnameadmin.Name = "txtlastnameadmin";
            this.txtlastnameadmin.PlaceholderText = "";
            this.txtlastnameadmin.SelectedText = "";
            this.txtlastnameadmin.Size = new System.Drawing.Size(271, 51);
            this.txtlastnameadmin.TabIndex = 15;
            
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 32);
            this.label2.TabIndex = 14;
            this.label2.Text = "Last Name:";
            // 
            // txtfirstnameadmin
            // 
            this.txtfirstnameadmin.BorderRadius = 15;
            this.txtfirstnameadmin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtfirstnameadmin.DefaultText = "";
            this.txtfirstnameadmin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtfirstnameadmin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtfirstnameadmin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtfirstnameadmin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtfirstnameadmin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtfirstnameadmin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtfirstnameadmin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtfirstnameadmin.Location = new System.Drawing.Point(167, 86);
            this.txtfirstnameadmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtfirstnameadmin.Name = "txtfirstnameadmin";
            this.txtfirstnameadmin.PlaceholderText = "";
            this.txtfirstnameadmin.SelectedText = "";
            this.txtfirstnameadmin.Size = new System.Drawing.Size(271, 51);
            this.txtfirstnameadmin.TabIndex = 13;
       
            // 
            // btnaddadmin
            // 
            this.btnaddadmin.BackColor = System.Drawing.Color.Brown;
            this.btnaddadmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddadmin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddadmin.ForeColor = System.Drawing.Color.White;
            this.btnaddadmin.Location = new System.Drawing.Point(209, 406);
            this.btnaddadmin.Name = "btnaddadmin";
            this.btnaddadmin.Size = new System.Drawing.Size(157, 67);
            this.btnaddadmin.TabIndex = 12;
            this.btnaddadmin.Text = " Add User";
            this.btnaddadmin.UseVisualStyleBackColor = false;
            this.btnaddadmin.Click += new System.EventHandler(this.btnaddadmin_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(592, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 32);
            this.label6.TabIndex = 8;
            this.label6.Text = "All Users";
            
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(598, 266);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(943, 506);
            this.panel2.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(943, 506);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Brown;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(1110, 831);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(157, 62);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = " Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.Brown;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.White;
            this.btndelete.Location = new System.Drawing.Point(1346, 831);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(157, 62);
            this.btndelete.TabIndex = 14;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(80, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(330, 65);
            this.label9.TabIndex = 22;
            this.label9.Text = "User/ Adding";
            // 
            // AdminUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AdminUser";
            this.Size = new System.Drawing.Size(1609, 1033);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnaddadmin;
        private Guna.UI2.WinForms.Guna2TextBox txtfirstnameadmin;
        private Guna.UI2.WinForms.Guna2TextBox txtpasswordadmin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox txtboxemailadmin;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtlastnameadmin;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ComboBox cmbroleadmin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Label label9;
    }
}
