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
    public partial class formPopUp : Form
    {
        formMainWindow formMainWindowObject;
        public formPopUp(formMainWindow formMainWindowInitialized)
        {
            InitializeComponent();
            formMainWindowObject = formMainWindowInitialized;
        }

        private void formPopUp_Load(object sender, EventArgs e)
        {

        }

        private void Pan_Click(object sender, EventArgs e)
        {

        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (cmdEdit.Text == "Edit")
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    "Please enter your password...", "Password", "", -1, -1);

                if (input == "nadie")
                {
                    cboJenisFasPend.Enabled = true;
                    txtNamaPendidikan.ReadOnly = false;
                    cmdBrowse.Enabled = true;
                    cmdHapus.Visible = true;
                    cmdEdit.Text = "Save";
                }
                else
                {
                    cboJenisFasPend.Enabled = false;
                    txtNamaPendidikan.ReadOnly = true;
                    cmdBrowse.Enabled = false;
                    cmdHapus.Visible = false;
                    cmdEdit.Text = "Edit";
                    MessageBox.Show("Password salah");
                }
            }
            else if (cmdEdit.Text == "Save")
            {
                Shapefile sf = formMainWindowObject.axMap1.get_Shapefile(formMainWindowObject.handleAsetFasPendJaktim);
                sf.StartEditingTable();
                sf.EditCellValue(sf.Table.get_FieldIndexByName("jenis_faspend"),
                    Convert.ToInt32(txtShapeIndex.Text), cboJenisFasPend.Text);
                sf.EditCellValue(sf.Table.get_FieldIndexByName("nama_pendidikan"),
                    Convert.ToInt32(txtShapeIndex.Text), txtNamaPendidikan.Text);
                sf.EditCellValue(sf.Table.get_FieldIndexByName("foto"),
                    Convert.ToInt32(txtShapeIndex.Text), txtFoto.Text);
                sf.StopEditingTable();
                sf.Save();

                cmdEdit.Text = "Edit";
                cboJenisFasPend.Enabled = false;
                txtNamaPendidikan.ReadOnly = true;
                cmdBrowse.Enabled = false;
                cmdHapus.Visible = false;
                formMainWindowObject.axMap1.Redraw2(tkRedrawType.RedrawAll);
                formMainWindowObject.axMap1.Refresh();
                this.Hide();
                MessageBox.Show("Data saved");
            }
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Browse Photo";
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "JPG (*.jpg)|*.jpg|JPEG (*.jpeg)|*.jpeg|PNG (*png)|*.png|All files (*.*)| *.*";
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

        private void cmdHapus_Click(object sender, EventArgs e)
        {
            Shapefile sf = formMainWindowObject.axMap1.get_Shapefile(formMainWindowObject.handleAsetFasPendJaktim);

            sf.StartEditingShapes();
            if (!sf.EditDeleteShape(Convert.ToInt32(txtShapeIndex.Text)))
            {
                MessageBox.Show("Gagal menghapus data. Error:" + sf.ErrorMsg[sf.LastErrorCode]);
            }
            else
            {
                MessageBox.Show("Berhasil menghapus data. Index = " + Convert.ToInt32(txtShapeIndex.Text));
                formMainWindowObject.axMap1.Redraw2(tkRedrawType.RedrawAll);
                formMainWindowObject.axMap1.Refresh();
;            }
            sf.Save();
            sf.StopEditingShapes();
        }

        private void formPopUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            Shapefile sf = formMainWindowObject.axMap1.get_Shapefile(formMainWindowObject.handleAsetFasPendJaktim);
            sf.SelectNone();
        }
    }
}
