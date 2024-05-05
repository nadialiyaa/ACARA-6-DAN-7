
namespace ACARA_6_7
{
    partial class formAddPoint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAddPoint));
            this.rdoTitik_Cursor = new System.Windows.Forms.RadioButton();
            this.rdo_TitikKeyboard = new System.Windows.Forms.RadioButton();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtTitikX = new System.Windows.Forms.TextBox();
            this.txtTitikY = new System.Windows.Forms.TextBox();
            this.lblKode = new System.Windows.Forms.Label();
            this.lblNamaPendidikan = new System.Windows.Forms.Label();
            this.lblJenisPendidikan = new System.Windows.Forms.Label();
            this.lblFoto = new System.Windows.Forms.Label();
            this.txtNamaPendidikan = new System.Windows.Forms.TextBox();
            this.txtJenisPendidikan = new System.Windows.Forms.TextBox();
            this.txtFoto = new System.Windows.Forms.TextBox();
            this.txtKode = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdZoomIn = new System.Windows.Forms.Button();
            this.cmdZoomOut = new System.Windows.Forms.Button();
            this.cmdZoomToExtent = new System.Windows.Forms.Button();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtShapeIndex = new System.Windows.Forms.TextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.axMap1 = new AxMapWinGIS.AxMap();
            ((System.ComponentModel.ISupportInitialize)(this.axMap1)).BeginInit();
            this.SuspendLayout();
            // 
            // rdoTitik_Cursor
            // 
            this.rdoTitik_Cursor.AutoSize = true;
            this.rdoTitik_Cursor.Checked = true;
            this.rdoTitik_Cursor.Location = new System.Drawing.Point(27, 23);
            this.rdoTitik_Cursor.Name = "rdoTitik_Cursor";
            this.rdoTitik_Cursor.Size = new System.Drawing.Size(314, 24);
            this.rdoTitik_Cursor.TabIndex = 31;
            this.rdoTitik_Cursor.TabStop = true;
            this.rdoTitik_Cursor.Text = "Digitasi on screen menggunakan cursor";
            this.rdoTitik_Cursor.UseVisualStyleBackColor = true;
            this.rdoTitik_Cursor.CheckedChanged += new System.EventHandler(this.rdoTitik_Cursor_CheckedChanged);
            // 
            // rdo_TitikKeyboard
            // 
            this.rdo_TitikKeyboard.AutoSize = true;
            this.rdo_TitikKeyboard.Location = new System.Drawing.Point(27, 65);
            this.rdo_TitikKeyboard.Name = "rdo_TitikKeyboard";
            this.rdo_TitikKeyboard.Size = new System.Drawing.Size(246, 24);
            this.rdo_TitikKeyboard.TabIndex = 32;
            this.rdo_TitikKeyboard.TabStop = true;
            this.rdo_TitikKeyboard.Text = "Input menggunakan keyboard";
            this.rdo_TitikKeyboard.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(342, 70);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(32, 20);
            this.Label1.TabIndex = 33;
            this.Label1.Text = "X  :";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(534, 173);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(57, 20);
            this.Label2.TabIndex = 34;
            this.Label2.Text = "Label2";
            // 
            // txtTitikX
            // 
            this.txtTitikX.Location = new System.Drawing.Point(377, 67);
            this.txtTitikX.Name = "txtTitikX";
            this.txtTitikX.Size = new System.Drawing.Size(100, 26);
            this.txtTitikX.TabIndex = 35;
            // 
            // txtTitikY
            // 
            this.txtTitikY.Location = new System.Drawing.Point(534, 65);
            this.txtTitikY.Name = "txtTitikY";
            this.txtTitikY.Size = new System.Drawing.Size(106, 26);
            this.txtTitikY.TabIndex = 36;
            // 
            // lblKode
            // 
            this.lblKode.AutoSize = true;
            this.lblKode.Location = new System.Drawing.Point(37, 475);
            this.lblKode.Name = "lblKode";
            this.lblKode.Size = new System.Drawing.Size(46, 20);
            this.lblKode.TabIndex = 37;
            this.lblKode.Text = "Kode";
            // 
            // lblNamaPendidikan
            // 
            this.lblNamaPendidikan.AutoSize = true;
            this.lblNamaPendidikan.Location = new System.Drawing.Point(37, 515);
            this.lblNamaPendidikan.Name = "lblNamaPendidikan";
            this.lblNamaPendidikan.Size = new System.Drawing.Size(195, 20);
            this.lblNamaPendidikan.TabIndex = 38;
            this.lblNamaPendidikan.Text = "Nama Fasilitas Pendidikan";
            // 
            // lblJenisPendidikan
            // 
            this.lblJenisPendidikan.AutoSize = true;
            this.lblJenisPendidikan.Location = new System.Drawing.Point(37, 558);
            this.lblJenisPendidikan.Name = "lblJenisPendidikan";
            this.lblJenisPendidikan.Size = new System.Drawing.Size(190, 20);
            this.lblJenisPendidikan.TabIndex = 39;
            this.lblJenisPendidikan.Text = "Jenis Fasilitas Pendidikan";
            // 
            // lblFoto
            // 
            this.lblFoto.AutoSize = true;
            this.lblFoto.Location = new System.Drawing.Point(37, 600);
            this.lblFoto.Name = "lblFoto";
            this.lblFoto.Size = new System.Drawing.Size(42, 20);
            this.lblFoto.TabIndex = 40;
            this.lblFoto.Text = "Foto";
            // 
            // txtNamaPendidikan
            // 
            this.txtNamaPendidikan.Location = new System.Drawing.Point(282, 515);
            this.txtNamaPendidikan.Name = "txtNamaPendidikan";
            this.txtNamaPendidikan.Size = new System.Drawing.Size(358, 26);
            this.txtNamaPendidikan.TabIndex = 41;
            // 
            // txtJenisPendidikan
            // 
            this.txtJenisPendidikan.Location = new System.Drawing.Point(282, 558);
            this.txtJenisPendidikan.Name = "txtJenisPendidikan";
            this.txtJenisPendidikan.Size = new System.Drawing.Size(358, 26);
            this.txtJenisPendidikan.TabIndex = 42;
            // 
            // txtFoto
            // 
            this.txtFoto.Location = new System.Drawing.Point(282, 600);
            this.txtFoto.Name = "txtFoto";
            this.txtFoto.Size = new System.Drawing.Size(229, 26);
            this.txtFoto.TabIndex = 43;
            // 
            // txtKode
            // 
            this.txtKode.Location = new System.Drawing.Point(282, 472);
            this.txtKode.Name = "txtKode";
            this.txtKode.Size = new System.Drawing.Size(358, 26);
            this.txtKode.TabIndex = 44;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(561, 666);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(79, 35);
            this.cmdCancel.TabIndex = 53;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdZoomIn
            // 
            this.cmdZoomIn.Location = new System.Drawing.Point(538, 123);
            this.cmdZoomIn.Name = "cmdZoomIn";
            this.cmdZoomIn.Size = new System.Drawing.Size(102, 42);
            this.cmdZoomIn.TabIndex = 46;
            this.cmdZoomIn.Text = "Zoom In";
            this.cmdZoomIn.UseVisualStyleBackColor = true;
            // 
            // cmdZoomOut
            // 
            this.cmdZoomOut.Location = new System.Drawing.Point(538, 171);
            this.cmdZoomOut.Name = "cmdZoomOut";
            this.cmdZoomOut.Size = new System.Drawing.Size(102, 39);
            this.cmdZoomOut.TabIndex = 47;
            this.cmdZoomOut.Text = "Zoom Out";
            this.cmdZoomOut.UseVisualStyleBackColor = true;
            // 
            // cmdZoomToExtent
            // 
            this.cmdZoomToExtent.Location = new System.Drawing.Point(538, 216);
            this.cmdZoomToExtent.Name = "cmdZoomToExtent";
            this.cmdZoomToExtent.Size = new System.Drawing.Size(102, 59);
            this.cmdZoomToExtent.TabIndex = 48;
            this.cmdZoomToExtent.Text = "Zoom To Extent";
            this.cmdZoomToExtent.UseVisualStyleBackColor = true;
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.Location = new System.Drawing.Point(517, 599);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.Size = new System.Drawing.Size(123, 29);
            this.cmdBrowse.TabIndex = 49;
            this.cmdBrowse.Text = "Browse...";
            this.cmdBrowse.UseVisualStyleBackColor = true;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(496, 71);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(32, 20);
            this.Label3.TabIndex = 50;
            this.Label3.Text = "Y  :";
            // 
            // txtShapeIndex
            // 
            this.txtShapeIndex.Location = new System.Drawing.Point(41, 670);
            this.txtShapeIndex.Name = "txtShapeIndex";
            this.txtShapeIndex.Size = new System.Drawing.Size(130, 26);
            this.txtShapeIndex.TabIndex = 51;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(464, 666);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(79, 35);
            this.cmdSave.TabIndex = 52;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // axMap1
            // 
            this.axMap1.Enabled = true;
            this.axMap1.Location = new System.Drawing.Point(27, 123);
            this.axMap1.Name = "axMap1";
            this.axMap1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMap1.OcxState")));
            this.axMap1.Size = new System.Drawing.Size(484, 329);
            this.axMap1.TabIndex = 54;
            // 
            // formAddPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 717);
            this.Controls.Add(this.axMap1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.txtShapeIndex);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.cmdBrowse);
            this.Controls.Add(this.cmdZoomToExtent);
            this.Controls.Add(this.cmdZoomOut);
            this.Controls.Add(this.cmdZoomIn);
            this.Controls.Add(this.txtKode);
            this.Controls.Add(this.txtFoto);
            this.Controls.Add(this.txtJenisPendidikan);
            this.Controls.Add(this.txtNamaPendidikan);
            this.Controls.Add(this.lblFoto);
            this.Controls.Add(this.lblJenisPendidikan);
            this.Controls.Add(this.lblNamaPendidikan);
            this.Controls.Add(this.lblKode);
            this.Controls.Add(this.txtTitikY);
            this.Controls.Add(this.txtTitikX);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.rdo_TitikKeyboard);
            this.Controls.Add(this.rdoTitik_Cursor);
            this.Name = "formAddPoint";
            this.Text = "Add Point";
            this.Load += new System.EventHandler(this.formAddPoint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axMap1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.RadioButton rdoTitik_Cursor;
        internal System.Windows.Forms.RadioButton rdo_TitikKeyboard;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtTitikX;
        internal System.Windows.Forms.TextBox txtTitikY;
        internal System.Windows.Forms.Label lblKode;
        internal System.Windows.Forms.Label lblNamaPendidikan;
        internal System.Windows.Forms.Label lblJenisPendidikan;
        internal System.Windows.Forms.Label lblFoto;
        internal System.Windows.Forms.TextBox txtNamaPendidikan;
        internal System.Windows.Forms.TextBox txtJenisPendidikan;
        internal System.Windows.Forms.TextBox txtFoto;
        internal System.Windows.Forms.TextBox txtKode;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdZoomIn;
        internal System.Windows.Forms.Button cmdZoomOut;
        internal System.Windows.Forms.Button cmdZoomToExtent;
        internal System.Windows.Forms.Button cmdBrowse;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtShapeIndex;
        internal System.Windows.Forms.Button cmdSave;
        private AxMapWinGIS.AxMap axMap1;
    }
}