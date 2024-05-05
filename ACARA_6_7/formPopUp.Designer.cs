
namespace ACARA_6_7
{
    partial class formPopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPopUp));
            this.cmdEdit = new System.Windows.Forms.Button();
            this.cmdHapus = new System.Windows.Forms.Button();
            this.txtShapeIndex = new System.Windows.Forms.TextBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.cmdPan = new System.Windows.Forms.Button();
            this.cmdZoomToExtent = new System.Windows.Forms.Button();
            this.cmdZoomOut = new System.Windows.Forms.Button();
            this.cmdZoomIn = new System.Windows.Forms.Button();
            this.txtKode = new System.Windows.Forms.TextBox();
            this.txtFoto = new System.Windows.Forms.TextBox();
            this.txtNamaPendidikan = new System.Windows.Forms.TextBox();
            this.lblFoto = new System.Windows.Forms.Label();
            this.lblJenisPendidikan = new System.Windows.Forms.Label();
            this.lblNamaPendidikan = new System.Windows.Forms.Label();
            this.lblKode = new System.Windows.Forms.Label();
            this.lblInformasi = new System.Windows.Forms.Label();
            this.axMap1 = new AxMapWinGIS.AxMap();
            this.cboJenisFasPend = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.axMap1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(532, 545);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(79, 35);
            this.cmdEdit.TabIndex = 33;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdHapus
            // 
            this.cmdHapus.Location = new System.Drawing.Point(441, 545);
            this.cmdHapus.Name = "cmdHapus";
            this.cmdHapus.Size = new System.Drawing.Size(79, 35);
            this.cmdHapus.TabIndex = 32;
            this.cmdHapus.Text = "Hapus";
            this.cmdHapus.UseVisualStyleBackColor = true;
            this.cmdHapus.Click += new System.EventHandler(this.cmdHapus_Click);
            // 
            // txtShapeIndex
            // 
            this.txtShapeIndex.Location = new System.Drawing.Point(20, 554);
            this.txtShapeIndex.Name = "txtShapeIndex";
            this.txtShapeIndex.Size = new System.Drawing.Size(130, 26);
            this.txtShapeIndex.TabIndex = 31;
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(525, 504);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(86, 29);
            this.cmdBrowse.TabIndex = 30;
            this.cmdBrowse.Text = "Browse...";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // cmdPan
            // 
            this.cmdPan.Location = new System.Drawing.Point(536, 257);
            this.cmdPan.Name = "cmdPan";
            this.cmdPan.Size = new System.Drawing.Size(75, 30);
            this.cmdPan.TabIndex = 29;
            this.cmdPan.Text = "Pan";
            this.cmdPan.UseVisualStyleBackColor = true;
            this.cmdPan.Click += new System.EventHandler(this.Pan_Click);
            // 
            // cmdZoomToExtent
            // 
            this.cmdZoomToExtent.Location = new System.Drawing.Point(536, 175);
            this.cmdZoomToExtent.Name = "cmdZoomToExtent";
            this.cmdZoomToExtent.Size = new System.Drawing.Size(75, 73);
            this.cmdZoomToExtent.TabIndex = 28;
            this.cmdZoomToExtent.Text = "Zoom To Extent";
            this.cmdZoomToExtent.UseVisualStyleBackColor = true;
            // 
            // cmdZoomOut
            // 
            this.cmdZoomOut.Location = new System.Drawing.Point(536, 116);
            this.cmdZoomOut.Name = "cmdZoomOut";
            this.cmdZoomOut.Size = new System.Drawing.Size(75, 49);
            this.cmdZoomOut.TabIndex = 27;
            this.cmdZoomOut.Text = "Zoom Out";
            this.cmdZoomOut.UseVisualStyleBackColor = true;
            // 
            // cmdZoomIn
            // 
            this.cmdZoomIn.Location = new System.Drawing.Point(536, 56);
            this.cmdZoomIn.Name = "cmdZoomIn";
            this.cmdZoomIn.Size = new System.Drawing.Size(75, 49);
            this.cmdZoomIn.TabIndex = 26;
            this.cmdZoomIn.Text = "Zoom In";
            this.cmdZoomIn.UseVisualStyleBackColor = true;
            // 
            // txtKode
            // 
            this.txtKode.Location = new System.Drawing.Point(252, 376);
            this.txtKode.Name = "txtKode";
            this.txtKode.Size = new System.Drawing.Size(359, 26);
            this.txtKode.TabIndex = 25;
            // 
            // txtFoto
            // 
            this.txtFoto.Location = new System.Drawing.Point(252, 504);
            this.txtFoto.Name = "txtFoto";
            this.txtFoto.Size = new System.Drawing.Size(267, 26);
            this.txtFoto.TabIndex = 24;
            // 
            // txtNamaPendidikan
            // 
            this.txtNamaPendidikan.Location = new System.Drawing.Point(252, 419);
            this.txtNamaPendidikan.Name = "txtNamaPendidikan";
            this.txtNamaPendidikan.Size = new System.Drawing.Size(359, 26);
            this.txtNamaPendidikan.TabIndex = 22;
            // 
            // lblFoto
            // 
            this.lblFoto.AutoSize = true;
            this.lblFoto.Location = new System.Drawing.Point(16, 504);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(42, 20);
            this.lblFoto.TabIndex = 21;
            this.lblFoto.Text = "Foto";
            // 
            // lblJenisPendidikan
            // 
            this.lblJenisPendidikan.AutoSize = true;
            this.lblJenisPendidikan.Location = new System.Drawing.Point(16, 462);
            this.lblJenisPendidikan.Name = "lblJenisPendidikan";
            this.lblJenisPendidikan.Size = new System.Drawing.Size(190, 20);
            this.lblJenisPendidikan.TabIndex = 20;
            this.lblJenisPendidikan.Text = "Jenis Fasilitas Pendidikan";
            // 
            // lblNamaPendidikan
            // 
            this.lblNamaPendidikan.AutoSize = true;
            this.lblNamaPendidikan.Location = new System.Drawing.Point(16, 419);
            this.lblNamaPendidikan.Name = "lblNamaPendidikan";
            this.lblNamaPendidikan.Size = new System.Drawing.Size(195, 20);
            this.lblNamaPendidikan.TabIndex = 19;
            this.lblNamaPendidikan.Text = "Nama Fasilitas Pendidikan";
            // 
            // lblKode
            // 
            this.lblKode.AutoSize = true;
            this.lblKode.Location = new System.Drawing.Point(16, 379);
            this.lblKode.Name = "lblKode";
            this.lblKode.Size = new System.Drawing.Size(46, 20);
            this.lblKode.TabIndex = 18;
            this.lblKode.Text = "Kode";
            // 
            // lblInformasi
            // 
            this.lblInformasi.AutoSize = true;
            this.lblInformasi.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformasi.Location = new System.Drawing.Point(202, 10);
            this.lblInformasi.Name = "lblInformasi";
            this.lblInformasi.Size = new System.Drawing.Size(226, 37);
            this.lblInformasi.TabIndex = 17;
            this.lblInformasi.Text = "INFORMASI";
            // 
            // axMap1
            // 
            this.axMap1.Enabled = true;
            this.axMap1.Location = new System.Drawing.Point(20, 56);
            this.axMap1.Name = "axMap1";
            this.axMap1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMap1.OcxState")));
            this.axMap1.Size = new System.Drawing.Size(499, 296);
            this.axMap1.TabIndex = 34;
            // 
            // cboJenisFasPend
            // 
            this.cboJenisFasPend.FormattingEnabled = true;
            this.cboJenisFasPend.Location = new System.Drawing.Point(252, 459);
            this.cboJenisFasPend.Name = "cboJenisFasPend";
            this.cboJenisFasPend.Size = new System.Drawing.Size(359, 28);
            this.cboJenisFasPend.TabIndex = 35;
            // 
            // formPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 591);
            this.Controls.Add(this.cboJenisFasPend);
            this.Controls.Add(this.axMap1);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdHapus);
            this.Controls.Add(this.txtShapeIndex);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.cmdPan);
            this.Controls.Add(this.cmdZoomToExtent);
            this.Controls.Add(this.cmdZoomOut);
            this.Controls.Add(this.cmdZoomIn);
            this.Controls.Add(this.txtKode);
            this.Controls.Add(this.txtFoto);
            this.Controls.Add(this.txtNamaPendidikan);
            this.Controls.Add(this.lblFoto);
            this.Controls.Add(this.lblJenisPendidikan);
            this.Controls.Add(this.lblNamaPendidikan);
            this.Controls.Add(this.lblKode);
            this.Controls.Add(this.lblInformasi);
            this.Name = "formPopUp";
            this.Text = "Informasi";
            this.Load += new System.EventHandler(this.formPopUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axMap1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button cmdEdit;
        internal System.Windows.Forms.Button cmdHapus;
        internal System.Windows.Forms.TextBox txtShapeIndex;
        internal System.Windows.Forms.Button cmdBrowse;
        internal System.Windows.Forms.Button cmdPan;
        internal System.Windows.Forms.Button cmdZoomToExtent;
        internal System.Windows.Forms.Button cmdZoomOut;
        internal System.Windows.Forms.Button cmdZoomIn;
        internal System.Windows.Forms.TextBox txtKode;
        internal System.Windows.Forms.TextBox txtFoto;
        internal System.Windows.Forms.TextBox txtNamaPendidikan;
        internal System.Windows.Forms.Label lblFoto;
        internal System.Windows.Forms.Label lblJenisPendidikan;
        internal System.Windows.Forms.Label lblNamaPendidikan;
        internal System.Windows.Forms.Label lblKode;
        internal System.Windows.Forms.Label lblInformasi;
        private AxMapWinGIS.AxMap axMap1;
        public System.Windows.Forms.ComboBox cboJenisFasPend;
    }
}