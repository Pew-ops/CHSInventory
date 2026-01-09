namespace CHSInventory.Nurse
{
    partial class NursePatient
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtfullname = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtId = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtcomplain = new Guna.UI2.WinForms.Guna2TextBox();
            this.datagridpatients = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2TextBox7 = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnadd = new Guna.UI2.WinForms.Guna2Button();
            this.btndelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnupdate = new Guna.UI2.WinForms.Guna2Button();
            this.cmbprogram = new System.Windows.Forms.ComboBox();
            this.cmbnurseassign = new System.Windows.Forms.ComboBox();
            this.chklistmedicine = new System.Windows.Forms.CheckedListBox();
            this.txtsearchmedicine = new Guna.UI2.WinForms.Guna2TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagridpatients)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(54, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(440, 65);
            this.label9.TabIndex = 6;
            this.label9.Text = "Patient / Despince";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 314);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Full Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "ID Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(89, 420);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "Program:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(69, 482);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 32);
            this.label4.TabIndex = 10;
            this.label4.Text = "Complaint:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(80, 541);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "Medicine:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(130, 686);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 32);
            this.label6.TabIndex = 12;
            this.label6.Text = "COD:";
            // 
            // txtfullname
            // 
            this.txtfullname.BorderRadius = 15;
            this.txtfullname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtfullname.DefaultText = "";
            this.txtfullname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtfullname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtfullname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtfullname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtfullname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtfullname.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtfullname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtfullname.Location = new System.Drawing.Point(227, 300);
            this.txtfullname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtfullname.Name = "txtfullname";
            this.txtfullname.PlaceholderText = "";
            this.txtfullname.SelectedText = "";
            this.txtfullname.Size = new System.Drawing.Size(267, 46);
            this.txtfullname.TabIndex = 13;
            // 
            // txtId
            // 
            this.txtId.BorderRadius = 15;
            this.txtId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtId.DefaultText = "";
            this.txtId.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtId.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtId.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtId.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtId.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtId.Location = new System.Drawing.Point(227, 356);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtId.Name = "txtId";
            this.txtId.PlaceholderText = "";
            this.txtId.SelectedText = "";
            this.txtId.Size = new System.Drawing.Size(267, 46);
            this.txtId.TabIndex = 14;
            // 
            // txtcomplain
            // 
            this.txtcomplain.BorderRadius = 15;
            this.txtcomplain.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtcomplain.DefaultText = "";
            this.txtcomplain.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtcomplain.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtcomplain.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtcomplain.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtcomplain.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtcomplain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtcomplain.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtcomplain.Location = new System.Drawing.Point(227, 468);
            this.txtcomplain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtcomplain.Name = "txtcomplain";
            this.txtcomplain.PlaceholderText = "";
            this.txtcomplain.SelectedText = "";
            this.txtcomplain.Size = new System.Drawing.Size(267, 46);
            this.txtcomplain.TabIndex = 16;
            // 
            // datagridpatients
            // 
            this.datagridpatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridpatients.Location = new System.Drawing.Point(541, 247);
            this.datagridpatients.Name = "datagridpatients";
            this.datagridpatients.RowHeadersWidth = 62;
            this.datagridpatients.RowTemplate.Height = 28;
            this.datagridpatients.Size = new System.Drawing.Size(997, 558);
            this.datagridpatients.TabIndex = 19;
            this.datagridpatients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridpatients_CellContentClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(198, 28);
            this.label7.TabIndex = 20;
            this.label7.Text = "Patients Information";
            // 
            // guna2TextBox7
            // 
            this.guna2TextBox7.BorderRadius = 15;
            this.guna2TextBox7.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox7.DefaultText = "";
            this.guna2TextBox7.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox7.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox7.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox7.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox7.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox7.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox7.Location = new System.Drawing.Point(541, 182);
            this.guna2TextBox7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.guna2TextBox7.Name = "guna2TextBox7";
            this.guna2TextBox7.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.guna2TextBox7.PlaceholderText = "School ID....";
            this.guna2TextBox7.SelectedText = "";
            this.guna2TextBox7.Size = new System.Drawing.Size(317, 46);
            this.guna2TextBox7.TabIndex = 21;
            // 
            // btnadd
            // 
            this.btnadd.BorderRadius = 15;
            this.btnadd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnadd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnadd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnadd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnadd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnadd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnadd.ForeColor = System.Drawing.Color.White;
            this.btnadd.Location = new System.Drawing.Point(284, 865);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(147, 55);
            this.btnadd.TabIndex = 22;
            this.btnadd.Text = "ADD";
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btndelete
            // 
            this.btndelete.BorderRadius = 15;
            this.btndelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btndelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btndelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btndelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btndelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btndelete.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.White;
            this.btndelete.Location = new System.Drawing.Point(1379, 865);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(147, 55);
            this.btndelete.TabIndex = 23;
            this.btndelete.Text = "DELETE";
            // 
            // btnupdate
            // 
            this.btnupdate.BorderRadius = 15;
            this.btnupdate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnupdate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnupdate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnupdate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnupdate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnupdate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnupdate.ForeColor = System.Drawing.Color.White;
            this.btnupdate.Location = new System.Drawing.Point(1188, 865);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(147, 55);
            this.btnupdate.TabIndex = 24;
            this.btnupdate.Text = "UPDATE";
            // 
            // cmbprogram
            // 
            this.cmbprogram.FormattingEnabled = true;
            this.cmbprogram.Items.AddRange(new object[] {
            "BSIT",
            "COMSCI",
            "ENGINEERING",
            "DEE",
            "DCE",
            "DTE",
            "CSIT"});
            this.cmbprogram.Location = new System.Drawing.Point(227, 420);
            this.cmbprogram.Name = "cmbprogram";
            this.cmbprogram.Size = new System.Drawing.Size(267, 28);
            this.cmbprogram.TabIndex = 25;
            // 
            // cmbnurseassign
            // 
            this.cmbnurseassign.FormattingEnabled = true;
            this.cmbnurseassign.Location = new System.Drawing.Point(227, 690);
            this.cmbnurseassign.Name = "cmbnurseassign";
            this.cmbnurseassign.Size = new System.Drawing.Size(267, 28);
            this.cmbnurseassign.TabIndex = 26;
            // 
            // chklistmedicine
            // 
            this.chklistmedicine.FormattingEnabled = true;
            this.chklistmedicine.Location = new System.Drawing.Point(224, 593);
            this.chklistmedicine.Name = "chklistmedicine";
            this.chklistmedicine.Size = new System.Drawing.Size(267, 73);
            this.chklistmedicine.TabIndex = 28;
            this.chklistmedicine.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklistmedicine_ItemCheck_1);
            // 
            // txtsearchmedicine
            // 
            this.txtsearchmedicine.BorderRadius = 15;
            this.txtsearchmedicine.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtsearchmedicine.DefaultText = "";
            this.txtsearchmedicine.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtsearchmedicine.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtsearchmedicine.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsearchmedicine.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtsearchmedicine.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtsearchmedicine.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtsearchmedicine.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtsearchmedicine.Location = new System.Drawing.Point(224, 532);
            this.txtsearchmedicine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtsearchmedicine.Name = "txtsearchmedicine";
            this.txtsearchmedicine.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtsearchmedicine.PlaceholderText = "Search medicine...";
            this.txtsearchmedicine.SelectedText = "";
            this.txtsearchmedicine.Size = new System.Drawing.Size(267, 46);
            this.txtsearchmedicine.TabIndex = 29;
            this.txtsearchmedicine.TextChanged += new System.EventHandler(this.txtsearchmedicine_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(227, 732);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(267, 26);
            this.dateTimePicker1.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(130, 729);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 32);
            this.label8.TabIndex = 31;
            this.label8.Text = "Date:";
            // 
            // NursePatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtsearchmedicine);
            this.Controls.Add(this.chklistmedicine);
            this.Controls.Add(this.cmbnurseassign);
            this.Controls.Add(this.cmbprogram);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.guna2TextBox7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.datagridpatients);
            this.Controls.Add(this.txtcomplain);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtfullname);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Name = "NursePatient";
            this.Size = new System.Drawing.Size(1587, 990);
            ((System.ComponentModel.ISupportInitialize)(this.datagridpatients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtfullname;
        private Guna.UI2.WinForms.Guna2TextBox txtId;
        private Guna.UI2.WinForms.Guna2TextBox txtcomplain;
        private System.Windows.Forms.DataGridView datagridpatients;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox7;
        private Guna.UI2.WinForms.Guna2Button btnadd;
        private Guna.UI2.WinForms.Guna2Button btndelete;
        private Guna.UI2.WinForms.Guna2Button btnupdate;
        private System.Windows.Forms.ComboBox cmbprogram;
        private System.Windows.Forms.ComboBox cmbnurseassign;
        private System.Windows.Forms.CheckedListBox chklistmedicine;
        private Guna.UI2.WinForms.Guna2TextBox txtsearchmedicine;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
    }
}
