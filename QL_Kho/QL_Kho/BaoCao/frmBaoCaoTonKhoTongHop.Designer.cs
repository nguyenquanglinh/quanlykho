namespace QL_Kho
{
    partial class frmBaoCaoTonKhoTongHop
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rpvBaoCaoViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupThaoTac = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXem = new System.Windows.Forms.Button();
            this.txtTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupThaoTac.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rpvBaoCaoViewer);
            this.groupBox2.Location = new System.Drawing.Point(6, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(894, 434);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Xem báo cáo";
            // 
            // rpvBaoCaoViewer
            // 
            this.rpvBaoCaoViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rpvBaoCaoViewer.LocalReport.ReportEmbeddedResource = "QL_Kho.BaoCao.rpTonKho.rdlc";
            this.rpvBaoCaoViewer.Location = new System.Drawing.Point(6, 19);
            this.rpvBaoCaoViewer.Name = "rpvBaoCaoViewer";
            this.rpvBaoCaoViewer.ServerReport.BearerToken = null;
            this.rpvBaoCaoViewer.Size = new System.Drawing.Size(882, 409);
            this.rpvBaoCaoViewer.TabIndex = 0;
            // 
            // groupThaoTac
            // 
            this.groupThaoTac.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupThaoTac.Controls.Add(this.label1);
            this.groupThaoTac.Controls.Add(this.txtDenNgay);
            this.groupThaoTac.Controls.Add(this.btnXem);
            this.groupThaoTac.Controls.Add(this.txtTuNgay);
            this.groupThaoTac.Controls.Add(this.label2);
            this.groupThaoTac.Location = new System.Drawing.Point(6, 2);
            this.groupThaoTac.Name = "groupThaoTac";
            this.groupThaoTac.Size = new System.Drawing.Size(894, 66);
            this.groupThaoTac.TabIndex = 14;
            this.groupThaoTac.TabStop = false;
            this.groupThaoTac.Text = "Thao tác";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(149, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 66;
            this.label1.Text = "Đến ngày";
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.CustomFormat = "";
            this.txtDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDenNgay.Location = new System.Drawing.Point(152, 33);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(97, 20);
            this.txtDenNgay.TabIndex = 65;
            // 
            // btnXem
            // 
            this.btnXem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnXem.Image = global::QL_Kho.Properties.Resources.pie_chart_diagram;
            this.btnXem.Location = new System.Drawing.Point(333, 28);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(124, 25);
            this.btnXem.TabIndex = 60;
            this.btnXem.Text = "Xem báo cáo";
            this.btnXem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.CustomFormat = "";
            this.txtTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtTuNgay.Location = new System.Drawing.Point(23, 33);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(98, 20);
            this.txtTuNgay.TabIndex = 65;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(20, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = "Từ ngày";
            // 
            // frmBaoCaoTonKhoTongHop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 520);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupThaoTac);
            this.Name = "frmBaoCaoTonKhoTongHop";
            this.Text = "Báo cáo tồn kho tổng hợp";
            this.Load += new System.EventHandler(this.frmBaoCaoTonKhoTongHop_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupThaoTac.ResumeLayout(false);
            this.groupThaoTac.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupThaoTac;
        private System.Windows.Forms.DateTimePicker txtTuNgay;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer rpvBaoCaoViewer;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker txtDenNgay;
        private System.Windows.Forms.Label label1;
    }
}