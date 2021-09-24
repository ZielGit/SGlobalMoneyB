
namespace SGlobalMoneyB.DesktopUI
{
    partial class frm_report_nombre
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.oReporteUsuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.oReporteUsuarioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // oReporteUsuarioBindingSource
            // 
            this.oReporteUsuarioBindingSource.DataSource = typeof(SGlobalMoneyB.Core.Entidades.oReporteUsuario);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetDNI";
            reportDataSource1.Value = this.oReporteUsuarioBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SGlobalMoneyB.DesktopUI.rp_reporte_nombre.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-2, -4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(802, 461);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load_1);
            // 
            // frm_report_nombre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frm_report_nombre";
            this.Text = "frm_report_nombre";
            this.Load += new System.EventHandler(this.frm_report_nombre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.oReporteUsuarioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource oReporteUsuarioBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}