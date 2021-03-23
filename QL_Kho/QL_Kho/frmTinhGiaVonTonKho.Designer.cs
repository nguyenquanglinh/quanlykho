namespace QL_Kho
{
    partial class frmTinhGiaVonTonKho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTinhGiaVonTonKho));
            this.btnLuuLai = new System.Windows.Forms.Button();
            this.groupThaoTac = new System.Windows.Forms.GroupBox();
            this.txtNgayTinhTonKho = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupThaoTac.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLuuLai
            // 
            this.btnLuuLai.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuLai.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnLuuLai.Image = global::QL_Kho.Properties.Resources.save_as;
            this.btnLuuLai.Location = new System.Drawing.Point(270, 35);
            this.btnLuuLai.Name = "btnLuuLai";
            this.btnLuuLai.Size = new System.Drawing.Size(106, 25);
            this.btnLuuLai.TabIndex = 215;
            this.btnLuuLai.Text = "Cập nhật";
            this.btnLuuLai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLuuLai.UseVisualStyleBackColor = true;
            this.btnLuuLai.Click += new System.EventHandler(this.btnLuuLai_Click);
            // 
            // groupThaoTac
            // 
            this.groupThaoTac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupThaoTac.Controls.Add(this.txtNgayTinhTonKho);
            this.groupThaoTac.Controls.Add(this.label2);
            this.groupThaoTac.Controls.Add(this.btnLuuLai);
            this.groupThaoTac.Location = new System.Drawing.Point(6, 2);
            this.groupThaoTac.Name = "groupThaoTac";
            this.groupThaoTac.Size = new System.Drawing.Size(427, 76);
            this.groupThaoTac.TabIndex = 14;
            this.groupThaoTac.TabStop = false;
            this.groupThaoTac.Text = "Thao tác";
            // 
            // txtNgayTinhTonKho
            // 
            this.txtNgayTinhTonKho.CustomFormat = "MM/yyyy";
            this.txtNgayTinhTonKho.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtNgayTinhTonKho.Location = new System.Drawing.Point(104, 40);
            this.txtNgayTinhTonKho.Name = "txtNgayTinhTonKho";
            this.txtNgayTinhTonKho.ShowUpDown = true;
            this.txtNgayTinhTonKho.Size = new System.Drawing.Size(141, 20);
            this.txtNgayTinhTonKho.TabIndex = 216;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(101, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 18);
            this.label2.TabIndex = 217;
            this.label2.Text = "Tháng cập nhật";
            // 
            // frmTinhGiaVonTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 81);
            this.Controls.Add(this.groupThaoTac);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTinhGiaVonTonKho";
            this.Text = "Tính giá vốn tồn kho";
            this.Load += new System.EventHandler(this.frmNhanVien_Load);
            this.groupThaoTac.ResumeLayout(false);
            this.groupThaoTac.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupThaoTac;
        private System.Windows.Forms.Button btnLuuLai;
        private System.Windows.Forms.DateTimePicker txtNgayTinhTonKho;
        private System.Windows.Forms.Label label2;
    }
}