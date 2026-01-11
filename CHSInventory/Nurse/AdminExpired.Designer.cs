namespace CHSInventory.Nurse
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
            this.datagridpatientsrecord = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.datagridpatientsrecord)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(411, 65);
            this.label9.TabIndex = 23;
            this.label9.Text = "Expired/Disposal\r\n";
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
            this.txtsearch.Location = new System.Drawing.Point(89, 156);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtsearch.PlaceholderText = "School ID....";
            this.txtsearch.SelectedText = "";
            this.txtsearch.Size = new System.Drawing.Size(317, 46);
            this.txtsearch.TabIndex = 24;
            // 
            // datagridpatientsrecord
            // 
            this.datagridpatientsrecord.BackgroundColor = System.Drawing.Color.White;
            this.datagridpatientsrecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridpatientsrecord.Location = new System.Drawing.Point(89, 225);
            this.datagridpatientsrecord.Name = "datagridpatientsrecord";
            this.datagridpatientsrecord.RowHeadersWidth = 62;
            this.datagridpatientsrecord.RowTemplate.Height = 28;
            this.datagridpatientsrecord.Size = new System.Drawing.Size(1306, 524);
            this.datagridpatientsrecord.TabIndex = 25;
            // 
            // AdminExpired
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.datagridpatientsrecord);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.label9);
            this.Name = "AdminExpired";
            this.Size = new System.Drawing.Size(1587, 977);
            ((System.ComponentModel.ISupportInitialize)(this.datagridpatientsrecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtsearch;
        private System.Windows.Forms.DataGridView datagridpatientsrecord;
    }
}
