using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AxMapWinGIS;
using MapWinGIS;


namespace ACARA_6_7
{
    public partial class formBuffer : Form
    {
        formMainWindow formMainWindowObject;

        public formBuffer(formMainWindow formMainWindowInitialized)
        {
            InitializeComponent();
            formMainWindowObject = formMainWindowInitialized;
        }
        
        private void formBuffer_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < formMainWindowObject.legend1.Layers.Count; i++)
            {
                if (!cboInput.Items.Contains(formMainWindowObject.legend1.Layers[i].FileName)) ;
                {
                    cboInput.Items.Add(formMainWindowObject.legend1.Layers[i].FileName);
                }
            }
        }

        private void cmdBrowse2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            string stroutputshp = "Belum memilih output shapefile";

            sfd.Title = "Output Shapefile";
            sfd.InitialDirectory = @"C:\";
            sfd.Filter = "Shapefile (*.shp)|*.shp|All files (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;

            if((sfd.ShowDialog() == DialogResult.OK))
            {
                stroutputshp = sfd.FileName;
                txtOutput.Text = stroutputshp;
            }
            else
            {
                MessageBox.Show("Belum memilih output shapefile", "Report",
                    MessageBoxButtons.OKCancel);
            }
        }

        private void cmdBrowse1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string strfileshp = "Belum memilih shapefile";

            ofd.Title = "Browse Shapefile";
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "Shapefile (*.shp)|*shp|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;

            if ((ofd.ShowDialog() == DialogResult.OK))
            {
                strfileshp = ofd.FileName;
                if (!cboInput.Items.Contains(strfileshp))
                {
                    cboInput.Items.Add(strfileshp);
                }
                cboInput.Text = strfileshp;
            }
            else
            {
                MessageBox.Show("Belum memilih shapefile", "Report",
                   MessageBoxButtons.OKCancel);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            string inputshapefile = Convert.ToString(cboInput.Text);
            double inputdistance = Convert.ToDouble(txtDistance.Text);
            int inputsegment = Convert.ToInt16(txtSegments.Text);
            bool inputselected = Convert.ToBoolean(cboSelected.Text);
            bool inputmerge = Convert.ToBoolean(cboMerge.Text);
            bool inputoverwrite = Convert.ToBoolean(checkBox.Checked);
            string outputshapefile = Convert.ToString(txtOutput.Text);

            Shapefile sf = new Shapefile();
            sf.Open(inputshapefile);

            Utils utils = new Utils();
            utils.ConvertDistance(tkUnitsOfMeasure.umMeters, tkUnitsOfMeasure.umDecimalDegrees, ref inputdistance);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void formBuffer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
