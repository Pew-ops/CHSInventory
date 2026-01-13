namespace CHSInventory.Admin
{
    partial class AdminExpired
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
            this.label9 = new System.Windows.Forms.Label();
            this.txtsearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.datagrigitemrecorddispose = new System.Windows.Forms.DataGridView();
            this.btnmakereport = new Guna.UI2.WinForms.Guna2Button();
            this.btndispose = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagrigitemrecorddispose)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(33, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(437, 65);
            this.label9.TabIndex = 9;
            this.label9.Text = "Expired / Disposal";
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
            this.txtsearch.Location = new System.Drawing.Point(153, 160);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtsearch.PlaceholderText = "School ID....";
            this.txtsearch.SelectedText = "";
            this.txtsearch.Size = new System.Drawing.Size(317, 53);
            this.txtsearch.TabIndex = 24;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // datagrigitemrecorddispose
            // 
            this.datagrigitemrecorddispose.BackgroundColor = System.Drawing.Color.White;
            this.datagrigitemrecorddispose.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrigitemrecorddispose.Location = new System.Drawing.Point(153, 231);
            this.datagrigitemrecorddispose.Name = "datagrigitemrecorddispose";
            this.datagrigitemrecorddispose.RowHeadersWidth = 62;
            this.datagrigitemrecorddispose.RowTemplate.Height = 28;
            this.datagrigitemrecorddispose.Size = new System.Drawing.Size(1306, 524);
            this.datagrigitemrecorddispose.TabIndex = 25;

            // 
            // btnmakereport
            // 
            this.btnmakereport.BorderRadius = 15;
            this.btnmakereport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnmakereport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnmakereport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnmakereport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnmakereport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnmakereport.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnmakereport.ForeColor = System.Drawing.Color.White;
            this.btnmakereport.Location = new System.Drawing.Point(1197, 813);
            this.btnmakereport.Name = "btnmakereport";
            this.btnmakereport.Size = new System.Drawing.Size(236, 73);
            this.btnmakereport.TabIndex = 26;
            this.btnmakereport.Text = "Make a Report";
            this.btnmakereport.Click += new System.EventHandler(this.btnmakereport_Click);
            // 
            // btndispose
            // 
            this.btndispose.BorderRadius = 15;
            this.btndispose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btndispose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btndispose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btndispose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btndispose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btndispose.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btndispose.ForeColor = System.Drawing.Color.White;
            this.btndispose.Location = new System.Drawing.Point(894, 813);
            this.btndispose.Name = "btndispose";
            this.btndispose.Size = new System.Drawing.Size(236, 73);
            this.btndispose.TabIndex = 27;
            this.btndispose.Text = "Dispose";
            this.btndispose.Click += new System.EventHandler(this.btndispose_Click);
            // 
            // AdminExpired
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btndispose);
            this.Controls.Add(this.btnmakereport);
            this.Controls.Add(this.datagrigitemrecorddispose);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.label9);
            this.Name = "AdminExpired";
            this.Size = new System.Drawing.Size(1609, 1033);
            ((System.ComponentModel.ISupportInitialize)(this.datagrigitemrecorddispose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtsearch;
        private System.Windows.Forms.DataGridView datagrigitemrecorddispose;
        private Guna.UI2.WinForms.Guna2Button btnmakereport;
        private Guna.UI2.WinForms.Guna2Button btndispose;
    }
}
