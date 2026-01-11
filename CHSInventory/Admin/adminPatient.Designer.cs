namespace CHSInventory.Admin
{
    partial class AdminPatient
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
            this.datagridpatientsrecord = new System.Windows.Forms.DataGridView();
            this.btnmakeareport = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagridpatientsrecord)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(50, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(393, 65);
            this.label9.TabIndex = 8;
            this.label9.Text = "Patient / Record";
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
            this.txtsearch.Location = new System.Drawing.Point(151, 167);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtsearch.PlaceholderText = "School ID....";
            this.txtsearch.SelectedText = "";
            this.txtsearch.Size = new System.Drawing.Size(317, 46);
            this.txtsearch.TabIndex = 23;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // datagridpatientsrecord
            // 
            this.datagridpatientsrecord.BackgroundColor = System.Drawing.Color.White;
            this.datagridpatientsrecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridpatientsrecord.Location = new System.Drawing.Point(151, 241);
            this.datagridpatientsrecord.Name = "datagridpatientsrecord";
            this.datagridpatientsrecord.RowHeadersWidth = 62;
            this.datagridpatientsrecord.RowTemplate.Height = 28;
            this.datagridpatientsrecord.Size = new System.Drawing.Size(1306, 524);
            this.datagridpatientsrecord.TabIndex = 24;
            // 
            // btnmakeareport
            // 
            this.btnmakeareport.BorderRadius = 15;
            this.btnmakeareport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnmakeareport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnmakeareport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnmakeareport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnmakeareport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnmakeareport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmakeareport.ForeColor = System.Drawing.Color.White;
            this.btnmakeareport.Location = new System.Drawing.Point(1173, 780);
            this.btnmakeareport.Name = "btnmakeareport";
            this.btnmakeareport.Size = new System.Drawing.Size(213, 67);
            this.btnmakeareport.TabIndex = 25;
            this.btnmakeareport.Text = "Make a Report";
            this.btnmakeareport.Click += new System.EventHandler(this.btnmakeareport_Click);
            // 
            // AdminPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnmakeareport);
            this.Controls.Add(this.datagridpatientsrecord);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.label9);
            this.Name = "AdminPatient";
            this.Size = new System.Drawing.Size(1609, 1033);
            ((System.ComponentModel.ISupportInitialize)(this.datagridpatientsrecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtsearch;
        private System.Windows.Forms.DataGridView datagridpatientsrecord;
        private Guna.UI2.WinForms.Guna2Button btnmakeareport;
    }
}
