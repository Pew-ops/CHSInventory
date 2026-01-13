namespace CHSInventory.Forms.STA
{
    partial class staDisposal
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
            this.dataGridViewdisposal = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewdisposal)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewdisposal
            // 
            this.dataGridViewdisposal.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewdisposal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewdisposal.Location = new System.Drawing.Point(145, 288);
            this.dataGridViewdisposal.Name = "dataGridViewdisposal";
            this.dataGridViewdisposal.RowHeadersWidth = 62;
            this.dataGridViewdisposal.RowTemplate.Height = 28;
            this.dataGridViewdisposal.Size = new System.Drawing.Size(1217, 762);
            this.dataGridViewdisposal.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(61, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(218, 65);
            this.label9.TabIndex = 22;
            this.label9.Text = "Disposal";
            // 
            // staDisposal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dataGridViewdisposal);
            this.Name = "staDisposal";
            this.Size = new System.Drawing.Size(1587, 1050);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewdisposal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridViewdisposal;
        private System.Windows.Forms.Label label9;
    }
}
