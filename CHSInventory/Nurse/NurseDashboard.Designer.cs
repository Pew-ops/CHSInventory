namespace CHSInventory.Nurse
{
    partial class NurseDashboard
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
            this.datagridviewdashboard = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbllowstock = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblpatient = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblcountexpire = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbltotalmedicine = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtsearch = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewdashboard)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridviewdashboard
            // 
            this.datagridviewdashboard.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.datagridviewdashboard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridviewdashboard.Location = new System.Drawing.Point(130, 462);
            this.datagridviewdashboard.Name = "datagridviewdashboard";
            this.datagridviewdashboard.RowHeadersWidth = 62;
            this.datagridviewdashboard.RowTemplate.Height = 28;
            this.datagridviewdashboard.Size = new System.Drawing.Size(1304, 471);
            this.datagridviewdashboard.TabIndex = 12;
            this.datagridviewdashboard.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridviewdashboard_CellContentClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(35, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(273, 65);
            this.label9.TabIndex = 13;
            this.label9.Text = "Dashboard";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(118, 126);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1368, 205);
            this.panel1.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Brown;
            this.panel5.Controls.Add(this.lbllowstock);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.pictureBox4);
            this.panel5.Location = new System.Drawing.Point(1039, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(297, 162);
            this.panel5.TabIndex = 5;
            // 
            // lbllowstock
            // 
            this.lbllowstock.AutoSize = true;
            this.lbllowstock.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllowstock.ForeColor = System.Drawing.Color.White;
            this.lbllowstock.Location = new System.Drawing.Point(176, 71);
            this.lbllowstock.Name = "lbllowstock";
            this.lbllowstock.Size = new System.Drawing.Size(76, 38);
            this.lbllowstock.TabIndex = 10;
            this.lbllowstock.Text = "1000";
            this.lbllowstock.Click += new System.EventHandler(this.lbllowstock_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(167, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 21);
            this.label7.TabIndex = 2;
            this.label7.Text = "Low stock";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::CHSInventory.Properties.Resources.drugs__1_;
            this.pictureBox4.Location = new System.Drawing.Point(12, 53);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(134, 88);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Brown;
            this.panel4.Controls.Add(this.lblpatient);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Location = new System.Drawing.Point(701, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(312, 162);
            this.panel4.TabIndex = 4;
            // 
            // lblpatient
            // 
            this.lblpatient.AutoSize = true;
            this.lblpatient.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpatient.ForeColor = System.Drawing.Color.White;
            this.lblpatient.Location = new System.Drawing.Point(185, 71);
            this.lblpatient.Name = "lblpatient";
            this.lblpatient.Size = new System.Drawing.Size(76, 38);
            this.lblpatient.TabIndex = 4;
            this.lblpatient.Text = "1000";
            this.lblpatient.Click += new System.EventHandler(this.lblpatient_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(165, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "Total Patients";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CHSInventory.Properties.Resources.patient;
            this.pictureBox3.Location = new System.Drawing.Point(25, 53);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(134, 88);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Brown;
            this.panel3.Controls.Add(this.lblcountexpire);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(363, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(309, 162);
            this.panel3.TabIndex = 3;
            // 
            // lblcountexpire
            // 
            this.lblcountexpire.AutoSize = true;
            this.lblcountexpire.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcountexpire.ForeColor = System.Drawing.Color.White;
            this.lblcountexpire.Location = new System.Drawing.Point(187, 71);
            this.lblcountexpire.Name = "lblcountexpire";
            this.lblcountexpire.Size = new System.Drawing.Size(76, 38);
            this.lblcountexpire.TabIndex = 3;
            this.lblcountexpire.Text = "1000";
            this.lblcountexpire.Click += new System.EventHandler(this.lblcountexpire_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(158, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Items near Expire";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CHSInventory.Properties.Resources.expired__1_;
            this.pictureBox2.Location = new System.Drawing.Point(18, 53);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(134, 88);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Brown;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lbltotalmedicine);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(32, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 162);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(152, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Stock";
            // 
            // lbltotalmedicine
            // 
            this.lbltotalmedicine.AutoSize = true;
            this.lbltotalmedicine.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalmedicine.ForeColor = System.Drawing.Color.White;
            this.lbltotalmedicine.Location = new System.Drawing.Point(174, 71);
            this.lbltotalmedicine.Name = "lbltotalmedicine";
            this.lbltotalmedicine.Size = new System.Drawing.Size(76, 38);
            this.lbltotalmedicine.TabIndex = 1;
            this.lbltotalmedicine.Text = "1000";
            this.lbltotalmedicine.Click += new System.EventHandler(this.lbltotalmedicine_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CHSInventory.Properties.Resources.available;
            this.pictureBox1.Location = new System.Drawing.Point(12, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtsearch
            // 
            this.txtsearch.BorderRadius = 15;
            this.txtsearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtsearch.DefaultText = "";
            this.txtsearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtsearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtsearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtsearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtsearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtsearch.Location = new System.Drawing.Point(130, 406);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PlaceholderText = "Search....";
            this.txtsearch.SelectedText = "";
            this.txtsearch.Size = new System.Drawing.Size(409, 48);
            this.txtsearch.TabIndex = 15;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // NurseDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.datagridviewdashboard);
            this.Name = "NurseDashboard";
            this.Size = new System.Drawing.Size(1587, 977);
            this.Load += new System.EventHandler(this.NurseDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridviewdashboard)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView datagridviewdashboard;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbllowstock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblpatient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblcountexpire;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbltotalmedicine;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2TextBox txtsearch;
    }
}
