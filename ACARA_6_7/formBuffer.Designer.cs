
namespace ACARA_6_7
{
    partial class formBuffer
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
            this.lblInput = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.lblSegments = new System.Windows.Forms.Label();
            this.lblSelectedOnly = new System.Windows.Forms.Label();
            this.lblMerge = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.txtSegments = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.cmdBrowse1 = new System.Windows.Forms.Button();
            this.cmdBrowse2 = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cboSelected = new System.Windows.Forms.ComboBox();
            this.cboMerge = new System.Windows.Forms.ComboBox();
            this.cboInput = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(26, 29);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(117, 20);
            this.lblInput.TabIndex = 0;
            this.lblInput.Text = "Input Shapefile";
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(26, 75);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(72, 20);
            this.lblDistance.TabIndex = 1;
            this.lblDistance.Text = "Distance";
            // 
            // lblSegments
            // 
            this.lblSegments.AutoSize = true;
            this.lblSegments.Location = new System.Drawing.Point(26, 119);
            this.lblSegments.Name = "lblSegments";
            this.lblSegments.Size = new System.Drawing.Size(82, 20);
            this.lblSegments.TabIndex = 2;
            this.lblSegments.Text = "Segments";
            // 
            // lblSelectedOnly
            // 
            this.lblSelectedOnly.AutoSize = true;
            this.lblSelectedOnly.Location = new System.Drawing.Point(26, 168);
            this.lblSelectedOnly.Name = "lblSelectedOnly";
            this.lblSelectedOnly.Size = new System.Drawing.Size(107, 20);
            this.lblSelectedOnly.TabIndex = 3;
            this.lblSelectedOnly.Text = "Selected Only";
            // 
            // lblMerge
            // 
            this.lblMerge.AutoSize = true;
            this.lblMerge.Location = new System.Drawing.Point(26, 215);
            this.lblMerge.Name = "lblMerge";
            this.lblMerge.Size = new System.Drawing.Size(112, 20);
            this.lblMerge.TabIndex = 4;
            this.lblMerge.Text = "Merge Results";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(26, 261);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(129, 20);
            this.lblOutput.TabIndex = 5;
            this.lblOutput.Text = "Output Shapefile";
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(161, 75);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(378, 26);
            this.txtDistance.TabIndex = 7;
            // 
            // txtSegments
            // 
            this.txtSegments.Location = new System.Drawing.Point(161, 119);
            this.txtSegments.Name = "txtSegments";
            this.txtSegments.Size = new System.Drawing.Size(378, 26);
            this.txtSegments.TabIndex = 8;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(161, 261);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(378, 26);
            this.txtOutput.TabIndex = 11;
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(161, 302);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(101, 24);
            this.checkBox.TabIndex = 12;
            this.checkBox.Text = "Overwrite";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // cmdBrowse1
            // 
            this.cmdBrowse1.Location = new System.Drawing.Point(554, 29);
            this.cmdBrowse1.Name = "cmdBrowse1";
            this.cmdBrowse1.Size = new System.Drawing.Size(101, 27);
            this.cmdBrowse1.TabIndex = 13;
            this.cmdBrowse1.Text = "Browse...";
            this.cmdBrowse1.UseVisualStyleBackColor = true;
            this.cmdBrowse1.Click += new System.EventHandler(this.cmdBrowse1_Click);
            // 
            // cmdBrowse2
            // 
            this.cmdBrowse2.Location = new System.Drawing.Point(554, 261);
            this.cmdBrowse2.Name = "cmdBrowse2";
            this.cmdBrowse2.Size = new System.Drawing.Size(101, 27);
            this.cmdBrowse2.TabIndex = 14;
            this.cmdBrowse2.Text = "Browse...";
            this.cmdBrowse2.UseVisualStyleBackColor = true;
            this.cmdBrowse2.Click += new System.EventHandler(this.cmdBrowse2_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(438, 348);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(101, 27);
            this.cmdOK.TabIndex = 15;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(554, 348);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(101, 27);
            this.cmdCancel.TabIndex = 16;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cboSelected
            // 
            this.cboSelected.FormattingEnabled = true;
            this.cboSelected.Location = new System.Drawing.Point(161, 159);
            this.cboSelected.Name = "cboSelected";
            this.cboSelected.Size = new System.Drawing.Size(378, 28);
            this.cboSelected.TabIndex = 17;
            // 
            // cboMerge
            // 
            this.cboMerge.FormattingEnabled = true;
            this.cboMerge.Location = new System.Drawing.Point(161, 207);
            this.cboMerge.Name = "cboMerge";
            this.cboMerge.Size = new System.Drawing.Size(378, 28);
            this.cboMerge.TabIndex = 18;
            // 
            // cboInput
            // 
            this.cboInput.FormattingEnabled = true;
            this.cboInput.Location = new System.Drawing.Point(161, 29);
            this.cboInput.Name = "cboInput";
            this.cboInput.Size = new System.Drawing.Size(378, 28);
            this.cboInput.TabIndex = 19;
            // 
            // formBuffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 395);
            this.Controls.Add(this.cboInput);
            this.Controls.Add(this.cboMerge);
            this.Controls.Add(this.cboSelected);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdBrowse2);
            this.Controls.Add(this.cmdBrowse1);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtSegments);
            this.Controls.Add(this.txtDistance);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblMerge);
            this.Controls.Add(this.lblSelectedOnly);
            this.Controls.Add(this.lblSegments);
            this.Controls.Add(this.lblDistance);
            this.Controls.Add(this.lblInput);
            this.Name = "formBuffer";
            this.Text = "Buffer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Label lblDistance;
        private System.Windows.Forms.Label lblSegments;
        private System.Windows.Forms.Label lblSelectedOnly;
        private System.Windows.Forms.Label lblMerge;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.TextBox txtSegments;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.Button cmdBrowse1;
        private System.Windows.Forms.Button cmdBrowse2;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ComboBox cboSelected;
        private System.Windows.Forms.ComboBox cboMerge;
        public System.Windows.Forms.ComboBox cboInput;
    }
}