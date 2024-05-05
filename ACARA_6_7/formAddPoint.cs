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
    public partial class formAddPoint : Form
    {
        formMainWindow formMainWindowObject;

        public formAddPoint(formMainWindow formMainWindowInitialized)
        {
            InitializeComponent();
            formMainWindowObject = formMainWindowInitialized;
        }

        private void rdoTitik_Cursor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTitik_Cursor.Checked == true)
            {
                formMainWindowObject.KryptonRibbonGroup_Normal.PerformClick();
                formMainWindowObject.axMap1.MapCursor = tkCursor.crsrCross;
                txtTitikX.Enabled = false;
                txtTitikY.Enabled = false;
            }
            else
            {
                formMainWindowObject.axMap1.MapCursor = tkCursor.crsrMapDefault;
                formMainWindowObject.KryptonRibbonGroup_Normal.PerformClick();
                txtTitikX.Enabled = true;
                txtTitikY.Enabled = true;
            }
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Browse Photo";
            ofd.InitialDirectory = @"C\";
            ofd.Filter = ofd.Title = "Browse Shapefile";
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "Shapefile (*.shp)|*shp|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;

            if ((ofd.ShowDialog() == DialogResult.OK))
            {
                string fileName = @Path.GetFileName(ofd.FileName);
                string sourcePath = @Path.GetDirectoryName(ofd.FileName);
                string targetPath = @Path.Combine(formMainWindow.strFilePath, "Database/NonSpatial/Foto");
                string sourceFile = @Path.Combine(sourcePath, fileName);
                string destFile = @Path.Combine(targetPath, fileName);
                File.Copy(sourceFile, destFile, true);
                txtFoto.Text = fileName;
            }
            else
            {
                MessageBox.Show("Belum memilih foto", "Report", MessageBoxButtons.OK);
            }

        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Shapefile sf = formMainWindowObject.axMap1.get_Shapefile(formMainWindowObject.handleAsetFasPendJaktim);
            bool result = sf.CreateNewWithShapeID("", ShpfileType.SHP_POINT);

            var myPoint = new MapWinGIS.Point();
            myPoint.x = Convert.ToDouble(txtTitikX);
            myPoint.y = Convert.ToDouble(txtTitikY);

            //MessageBox.Show(sf.ShapefileType.ToString());
            Shape myShape = new Shape();
            myShape.Create(ShpfileType.SHP_POINT);
            int myPointIndex = 0;
            myShape.InsertPoint(myPoint, ref myPointIndex);
            int myShapeIndex = 0;

            sf.StartEditingShapes();
            if (sf.EditInsertShape(myShape, ref myShapeIndex))
            {
                sf.Save();
                sf.StartEditingTable();
                sf.EditCellValue(sf.Table.get_FieldIndexByName("penggunaan"),
                    myShapeIndex, txtNamaPendidikan.Text);
                sf.EditCellValue(sf.Table.get_FieldIndexByName("nama_pendidikan"),
                    myShapeIndex, txtNamaPendidikan.Text);
                sf.EditCellValue(sf.Table.get_FieldIndexByName("foto"),
                    myShapeIndex, txtFoto.Text);
                sf.Save();
                sf.StopEditingTable();
            }
            else
            {
                MessageBox.Show(sf.ErrorMsg[sf.LastErrorCode].ToString());
            }
            sf.Save();
            sf.StopEditingShapes();

            formMainWindowObject.axMap1.RemoveLayer(formMainWindowObject.handleAsetFasPendJaktim);
            formMainWindowObject.axMap1.Redraw();
            formMainWindowObject.axMap1.Redraw2(tkRedrawType.RedrawAll);
            formMainWindowObject.axMap1.Refresh();
            formMainWindowObject.legend1.RedrawLegendAndMap();
            formMainWindowObject.legend1.Refresh();
            formMainWindowObject.Refresh();

            formMainWindowObject.loadAsetFasPendJaktim(); 
            formMainWindowObject.axMap1.Redraw();
            formMainWindowObject.axMap1.Redraw2(tkRedrawType.RedrawAll);
            formMainWindowObject.axMap1.Refresh();
            formMainWindowObject.legend1.RedrawLegendAndMap();
            formMainWindowObject.legend1.Refresh();
            formMainWindowObject.Refresh();

            this.Hide();
            MessageBox.Show("Data Saved.");
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void formAddPoint_Load(object sender, EventArgs e)
        {
            rdo_TitikKeyboard.Checked = true;
            txtTitikX.Text = "";
            txtTitikY.Text = "";
            txtNamaPendidikan.Text = "";
            txtJenisPendidikan.Text = "";
            txtFoto.Text = "";
        }

        private void formAddPoint_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            this.Hide();
            rdo_TitikKeyboard.Checked = true;
            txtTitikX.Text = "";
            txtTitikY.Text = "";
            txtNamaPendidikan.Text = "";
            txtJenisPendidikan.Text = "";
            txtFoto.Text = "";
            formMainWindowObject.axMap1.MapCursor = tkCursor.crsrMapDefault;
            formMainWindowObject.KryptonRibbonGroup_Normal.PerformClick();
        }
    }
}
