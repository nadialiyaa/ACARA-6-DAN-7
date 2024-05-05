using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using AxMapWinGIS;
using MapWinGIS;

namespace ACARA_6_7
{
    public partial class formMainWindow : Form
    {
        public static string strAppPath = "";
        public static string strFilePath = "";
        public int handleBatasKecamatan;
        public int handleFasilitasPendidikan;
        public formPopUp formPopUpObject = null;
        public formAddPoint formAddPointObject = null;
        public formBuffer formBufferObject = null;
        private int handleBatasDesa;
        public int handleAsetFasPendJaktim;

        public formMainWindow()
        {
            InitializeComponent();
            strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            strFilePath = Path.Combine(strAppPath, "Resource");
            legend1.Map = (MapWinGIS.Map)axMap1.GetOcx();
            axMap1.SendMouseMove = true;
            axMap1.SendMouseDown = true;
            axMap1.SendMouseUp = true;
            axMap1.MapCursor = tkCursor.crsrMapDefault;
            KryptonRibbonGroup_Identify.PerformClick();
            formPopUpObject = new formPopUp(this);
            formAddPointObject = new formAddPoint(this);
            formBufferObject = new formBuffer(this);
        }

        private void formMainWindow_Load(object sender, EventArgs e)
        {
            var utils = new Utils();

            //============================
            //ADD LAYER BATAS ADMIN
            //============================
            string shpBatasDesa = Path.Combine(strFilePath, "C:/Users/nadia/Desktop/PRAKTIKUM SEM 2/PGD/ACARA 6 DAN 7/ACARA_6_7/ACARA_6_7/Resource/Database/Spatial/Kec_Jaktim.shp");
            MapWinGIS.Shapefile sfBatasDesa = new MapWinGIS.Shapefile();
            sfBatasDesa.Open(shpBatasDesa, null);
            handleBatasDesa = legend1.Layers.Add(sfBatasDesa, true);
            legend1.GetLayer(handleBatasDesa).Name = "Batas Administrasi";

            int fidDesa = sfBatasDesa.Table.get_FieldIndexByName("NAMOBJ");
            sfBatasDesa.Categories.Generate(fidDesa, tkClassificationType.ctUniqueValues, 0);
            ColorScheme schemeBatasDesa = new ColorScheme();
            //sfBatas Desa. Categories.ApplyColorScheme (tkColorScheme Type.ctSchemeGraduated, scheme BatasDesa);
            schemeBatasDesa.SetColors2(tkMapColor.OrangeRed, tkMapColor.LightYellow);
            sfBatasDesa.Categories.ApplyColorScheme3(tkColorSchemeType.ctSchemeGraduated,
                schemeBatasDesa, tkShapeElements.shElementFill, 0, Convert.ToInt32(sfBatasDesa.Categories.Count / 2));

            schemeBatasDesa.SetColors2(tkMapColor.ForestGreen, tkMapColor.PowderBlue);
            sfBatasDesa.Categories.ApplyColorScheme3(tkColorSchemeType.ctSchemeGraduated,
                schemeBatasDesa, tkShapeElements.shElementFill, (Convert.ToInt32(sfBatasDesa.Categories.Count / 2) + 1),
            (sfBatasDesa.Categories.Count - 1));
            axMap1.Redraw();

            //=========================
            //ADD LAYER JARINGAN JALAN
            //=========================

            string shpJalan = Path.Combine(strFilePath, "C:/Users/nadia/Desktop/PRAKTIKUM SEM 2/PGD/ACARA 6 DAN 7/ACARA_6_7/ACARA_6_7/Resource/Database/Spatial/Jalan_Jaktim.shp");
            MapWinGIS.Shapefile sfJalan = new MapWinGIS.Shapefile();
            sfJalan.Open(shpJalan, null);
            int handleJalan = legend1.Layers.Add(sfJalan, true);
            legend1.GetLayer(handleJalan).Name = "Jaringan Jalan";

            LinePattern patternAreteri = new LinePattern();
            patternAreteri.AddLine(utils.ColorByName(tkMapColor.Red), 3.0f, tkDashStyle.dsSolid);
            ShapefileCategory ctArteri = sfJalan.Categories.Add("Jalan Arteri");
            ctArteri.Expression = "[REMARK] = \"Jalan Arteri\"";
            ctArteri.DrawingOptions.LinePattern = patternAreteri;
            ctArteri.DrawingOptions.UseLinePattern = true;

            LinePattern patternLokal = new LinePattern();
            patternLokal.AddLine(utils.ColorByName(tkMapColor.Red), 2.0f, tkDashStyle.dsDashDot);
            ShapefileCategory ctLokal = sfJalan.Categories.Add("Jalan Lokal");
            ctLokal.Expression = "[REMARK] = \"Jalan Lokal\"";
            ctLokal.DrawingOptions.LinePattern = patternLokal;
            ctLokal.DrawingOptions.UseLinePattern = true;

            LinePattern patternSetapak = new LinePattern();
            patternSetapak.AddLine(utils.ColorByName(tkMapColor.Red), 1.0f, tkDashStyle.dsDashDotDot);
            ShapefileCategory ctSetapak = sfJalan.Categories.Add("Jalan Setapak");
            ctSetapak.Expression = "[REMARK] : \"Jalan Setapak\"";
            sfJalan.Categories.Add("Jalan Setapak");
            ctSetapak.DrawingOptions.LinePattern = patternSetapak;
            ctSetapak.DrawingOptions.UseLinePattern = true;

            sfJalan.DefaultDrawingOptions.Visible = false; // hide all the unclassified points
            sfJalan.Categories.ApplyExpressions();
            axMap1.Redraw();

            //=====================
            //ADD LAYER ASET 
            //=====================
           loadAsetFasPendJaktim();
        }
        //=====================
        //BASEMAP
        //=====================

        private void Basemap_None_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = MapWinGIS.tkTileProvider.ProviderNone;
            axMap1.Redraw();
            axMap1.Refresh();
        }
        private void Basemap_OpenStreetMap_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = MapWinGIS.tkTileProvider.OpenStreetMap;
            axMap1.Redraw();
            axMap1.Refresh();
        }

        private void Basemap_OpenCycleMap_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = MapWinGIS.tkTileProvider.OpenCycleMap;
            axMap1.Redraw();
            axMap1.Refresh();
        }
        private void Basemap_OpenTransportMap_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = MapWinGIS.tkTileProvider.OpenTransportMap;
            axMap1.Redraw();
            axMap1.Refresh();
        }
        private void Basemap_BingMaps_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = MapWinGIS.tkTileProvider.BingMaps;
            axMap1.Redraw();
            axMap1.Refresh();
        }
        private void Basemap_BingSatellite_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = MapWinGIS.tkTileProvider.BingSatellite;
            axMap1.Redraw();
            axMap1.Refresh();
        }
        private void Basemap_BingHybrid_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = MapWinGIS.tkTileProvider.BingHybrid;
            axMap1.Redraw();
            axMap1.Refresh();
        }
        private void Basemap_GoogleMaps_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = MapWinGIS.tkTileProvider.GoogleMaps;
            axMap1.Redraw();
            axMap1.Refresh();
        }
        private void Basemap_GoogleSatellite_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = MapWinGIS.tkTileProvider.GoogleSatellite;
            axMap1.Redraw();
            axMap1.Refresh();
        }
        private void Basemap_GoogleHybrid_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = MapWinGIS.tkTileProvider.BingHybrid;
            axMap1.Redraw();
            axMap1.Refresh();
        }
        private void Basemap_GoogleTerrain_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = MapWinGIS.tkTileProvider.GoogleTerrain;
            axMap1.Redraw();
            axMap1.Refresh();
        }
        private void Basemap_HereMaps_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = MapWinGIS.tkTileProvider.HereMaps;
            axMap1.Redraw();
            axMap1.Refresh();
        }
        private void Basemap_HereSatellite_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = MapWinGIS.tkTileProvider.HereSatellite;
            axMap1.Redraw();
            axMap1.Refresh();
        }
        private void Basemap_HereHybrid_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = MapWinGIS.tkTileProvider.HereHybrid;
            axMap1.Redraw();
            axMap1.Refresh();
        }
        private void Basemap_HereTerrain_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = MapWinGIS.tkTileProvider.HereTerrain;
            axMap1.Redraw();
            axMap1.Refresh();
        }
        private void Basemap_Rosreestr_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = MapWinGIS.tkTileProvider.Rosreestr;
            axMap1.Redraw();
            axMap1.Refresh();
        }
        private void Basemap_MapQuestAerial_CheckedChanged(object sender, EventArgs e)
        {
            axMap1.TileProvider = MapWinGIS.tkTileProvider.MapQuestAerial;
            axMap1.Redraw();
            axMap1.Refresh();
        }
        //==============================
        //CURSOR MODE, IDENTIFY, MEASURE
        //==============================
        private void KryptonRibbonGroup_Normal_Click(object sender, EventArgs e)
        {
            axMap1.MapCursor = tkCursor.crsrMapDefault;
            if (KryptonRibbonGroup_Normal.Checked == true)
            {
                axMap1.CursorMode = MapWinGIS.tkCursorMode.cmNone;
                KryptonRibbonGroup_Normal.Checked = false;
                KryptonRibbonGroup_ZoomIn.Checked = false;
                KryptonRibbonGroup_ZoomOut.Checked = false;
                KryptonRibbonGroup_Pan.Checked = false;
                KryptonRibbonGroup_Identify.Checked = false;
                KryptonRibbonGroupButton_Length.Checked = false;
                KryptonRibbonGroup_Area.Checked = false;
            }
            else
            {
                KryptonRibbonGroup_Normal.Checked = true;
                axMap1.CursorMode = MapWinGIS.tkCursorMode.cmNone;
            }
        }

        private void KryptonRibbonGroup_ZoomIn_Click(object sender, EventArgs e)
        {
            axMap1.MapCursor = tkCursor.crsrMapDefault;
            if (KryptonRibbonGroup_ZoomIn.Checked == true)
            {
                axMap1.CursorMode = MapWinGIS.tkCursorMode.cmZoomIn;
                KryptonRibbonGroup_Normal.Checked = false;
                KryptonRibbonGroup_ZoomIn.Checked = false;
                KryptonRibbonGroup_ZoomOut.Checked = false;
                KryptonRibbonGroup_Pan.Checked = false;
                KryptonRibbonGroup_Identify.Checked = false;
                KryptonRibbonGroupButton_Length.Checked = false;
                KryptonRibbonGroup_Area.Checked = false;
            }
            else
            {
                KryptonRibbonGroup_Normal.Checked = true;
                axMap1.CursorMode = MapWinGIS.tkCursorMode.cmNone;
            }
            axMap1.ZoomIn(0.2);
        }

        private void KryptonRibbonGroup_ZoomOut_Click(object sender, EventArgs e)
        {
            axMap1.MapCursor = tkCursor.crsrMapDefault;
            if (KryptonRibbonGroup_ZoomOut.Checked == true)
            {
                axMap1.CursorMode = MapWinGIS.tkCursorMode.cmZoomOut;
                KryptonRibbonGroup_Normal.Checked = false;
                KryptonRibbonGroup_ZoomIn.Checked = false;
                KryptonRibbonGroup_ZoomOut.Checked = false;
                KryptonRibbonGroup_Pan.Checked = false;
                KryptonRibbonGroup_Identify.Checked = false;
                KryptonRibbonGroupButton_Length.Checked = false;
                KryptonRibbonGroup_Area.Checked = false;
            }
            else
            {
                KryptonRibbonGroup_Normal.Checked = true;
                axMap1.CursorMode = MapWinGIS.tkCursorMode.cmNone;
            }
            axMap1.ZoomOut(0.2);
        }

        private void KryptonRibbonGroup_Pan_Click(object sender, EventArgs e)
        {
            axMap1.MapCursor = tkCursor.crsrMapDefault;
            if (KryptonRibbonGroup_Pan.Checked == true)
            {
                axMap1.CursorMode = MapWinGIS.tkCursorMode.cmPan;
                KryptonRibbonGroup_Normal.Checked = false;
                KryptonRibbonGroup_ZoomIn.Checked = false;
                KryptonRibbonGroup_ZoomOut.Checked = false;
                KryptonRibbonGroup_Pan.Checked = false;
                KryptonRibbonGroup_Identify.Checked = false;
                KryptonRibbonGroupButton_Length.Checked = false;
                KryptonRibbonGroup_Area.Checked = false;
            }
            else
            {
                KryptonRibbonGroup_Normal.Checked = true;
                axMap1.CursorMode = MapWinGIS.tkCursorMode.cmNone;
            }
        }

        private void KryptonRibbonGroup_Identify_Click(object sender, EventArgs e)
        {
            axMap1.MapCursor = tkCursor.crsrMapDefault;
            if (KryptonRibbonGroup_Identify.Checked == true)
            {
                axMap1.CursorMode = MapWinGIS.tkCursorMode.cmIdentify;
                KryptonRibbonGroup_Normal.Checked = false;
                KryptonRibbonGroup_ZoomIn.Checked = false;
                KryptonRibbonGroup_ZoomOut.Checked = false;
                KryptonRibbonGroup_Pan.Checked = false;
                KryptonRibbonGroup_Identify.Checked = false;
                KryptonRibbonGroupButton_Length.Checked = false;
                KryptonRibbonGroup_Area.Checked = false;
            }
            else
            {
                KryptonRibbonGroup_Normal.Checked = true;
                axMap1.CursorMode = MapWinGIS.tkCursorMode.cmNone;
            }
        }

        private void KryptonRibbonGroupButton_Length_Click(object sender, EventArgs e)
        {
            axMap1.MapCursor = tkCursor.crsrMapDefault;
            if (KryptonRibbonGroupButton_Length.Checked == true)
            {
                axMap1.CursorMode = MapWinGIS.tkCursorMode.cmMeasure;
                KryptonRibbonGroup_Normal.Checked = false;
                KryptonRibbonGroup_ZoomIn.Checked = false;
                KryptonRibbonGroup_ZoomOut.Checked = false;
                KryptonRibbonGroup_Pan.Checked = false;
                KryptonRibbonGroup_Identify.Checked = false;
                KryptonRibbonGroupButton_Length.Checked = false;
                KryptonRibbonGroup_Area.Checked = false;
            }
            else
            {
                KryptonRibbonGroup_Normal.Checked = true;
                axMap1.CursorMode = MapWinGIS.tkCursorMode.cmNone;
            }

        }

        private void KryptonRibbonGroup_Area_Click(object sender, EventArgs e)
        {
            axMap1.MapCursor = tkCursor.crsrMapDefault;
            if (KryptonRibbonGroup_Area.Checked == true)
            {
                axMap1.CursorMode = MapWinGIS.tkCursorMode.cmMeasure;
                KryptonRibbonGroup_Normal.Checked = false;
                KryptonRibbonGroup_ZoomIn.Checked = false;
                KryptonRibbonGroup_ZoomOut.Checked = false;
                KryptonRibbonGroup_Pan.Checked = false;
                KryptonRibbonGroup_Identify.Checked = false;
                KryptonRibbonGroupButton_Length.Checked = false;
                KryptonRibbonGroup_Area.Checked = false;
            }
            else
            {
                KryptonRibbonGroup_Normal.Checked = true;
                axMap1.CursorMode = MapWinGIS.tkCursorMode.cmNone;
            }
        }

        private void KryptonRibbonGroup_Previous_Click(object sender, EventArgs e)
        {
            axMap1.ZoomToPrev();
        }

        private void KryptonRibbonGroup_ZoomExtent_Click(object sender, EventArgs e)
        {
            axMap1.ZoomToMaxExtents();
        }

        //=================
        //DATA
        //=================
        private void KryptonRibbonGroup_AddData_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string strfileshp = "KOWE DURUNG MILIH SHAPEFILE DAB!";
            ofd.Title = "Browse Shapefile";
            ofd.InitialDirectory = @"C:\";
            ofd.Filter = "Shapefile (*.shp)|*.shp|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;

            if ((ofd.ShowDialog() == DialogResult.OK))
            {
                strfileshp = ofd.FileName;

                MapWinGIS.Shapefile sfFaspendJaktim = new MapWinGIS.Shapefile();
                sfFaspendJaktim.Open(strfileshp, null);
                int handleBufferResult = legend1.Layers.Add(sfFaspendJaktim, true);
                legend1.GetLayer(handleBufferResult).Name = System.IO.Path.GetFileName(strfileshp);
                sfFaspendJaktim.Identifiable = true;

                if (!formBufferObject.cboInput.Items.Contains(strfileshp))
                {
                    formBufferObject.cboInput.Items.Add(strfileshp);
                }
                formBufferObject.cboInput.Text = strfileshp;
            }
            else
            {
                MessageBox.Show(strfileshp, "Report",
                    MessageBoxButtons.OKCancel);
            }
        }

        private void KryptonRibbonGroup_RemoveData_Click(object sender, EventArgs e)
        {
            legend1.Layers.Remove(legend1.SelectedLayer);
        }


        //========================
        //DATAGRID VIEW EVENT
        //========================
        private void DataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DataGridView1.SelectedRows.Count > 0)
            {
                Shapefile sf = axMap1.get_Shapefile(handleAsetFasPendJaktim);
                sf.SelectNone();

                for (int i = 0; i < DataGridView1.SelectedRows.Count; i++)
                {
                    sf.set_ShapeSelected(Convert.ToInt32(DataGridView1.SelectedRows[i].Cells["“fid"].Value), true);

                }
                axMap1.ZoomToSelected(handleAsetFasPendJaktim);
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (DataGridView1.SelectedRows.Count > 0)
            {
                Shapefile sf = axMap1.get_Shapefile(handleAsetFasPendJaktim);
                sf.SelectNone();

                for (int i = 0; i < DataGridView1.SelectedRows.Count; i++)
                {
                    sf.set_ShapeSelected(Convert.ToInt32(DataGridView1.SelectedRows[i].Cells["fid"].Value), true);
                }
                axMap1.ZoomToSelected(handleAsetFasPendJaktim);
            }
        }

        //=====================
        //QUERY
        //=====================
        private void KryptonRibbonGroupComboBoxQueryKecamatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(KryptonRibbonGroupComboBoxQueryKecamatan.Text == "Cari Kecamatan..."))
            {
                KryptonRibbonGroupComboBoxQueryJenis_Pend.Items.Clear();
                KryptonRibbonGroupComboBoxQueryJenis_Pend.Text = "Cari Jenis...";
                KryptonRibbonGroupComboBoxQueryFas_Pend.Items.Clear();
                KryptonRibbonGroupComboBoxQueryFas_Pend.Text = "Cari Fasilitas Pendidikan...";

                Shapefile sfBatasDesa = axMap1.get_Shapefile(handleBatasDesa);
                sfBatasDesa.SelectNone();

                string errorBatasDesa = "";
                object resultBatasDesa = null;
                string queryBatasDesa = "[REMARK] = \"" + KryptonRibbonGroupComboBoxQueryKecamatan.Text + "\"";

                if (sfBatasDesa.Table.Query(queryBatasDesa, ref resultBatasDesa, ref errorBatasDesa))
                {
                    int[] shapesBatasDesa = resultBatasDesa as int[];
                    if (shapesBatasDesa != null)
                    {
                        for (int i = 0; i < shapesBatasDesa.Length; i++)
                        {
                            sfBatasDesa.set_ShapeSelected(shapesBatasDesa[i], true);

                            if (!KryptonRibbonGroupComboBoxQueryJenis_Pend.Items.Contains(
                                sfBatasDesa.CellValue[sfBatasDesa.FieldIndexByName["NAMOBJ"], shapesBatasDesa[i]].ToString()))
                            {
                                KryptonRibbonGroupComboBoxQueryJenis_Pend.Items.Add(
                                    sfBatasDesa.CellValue[sfBatasDesa.FieldIndexByName["NAMOBJ"], shapesBatasDesa[i]].ToString());
                            }
                        }
                        KryptonRibbonGroupComboBoxQueryJenis_Pend.Sorted = true;
                        axMap1.ZoomToSelected(handleBatasDesa);
                    }
                }

                Shapefile sfAsetFasPendJaktim = axMap1.get_Shapefile(handleAsetFasPendJaktim);
                sfAsetFasPendJaktim.SelectNone();

                string errorAsetFasPendJaktim = "";
                object resultAsetFasPendJaktim = null;
                string queryAsetFasPendJaktim = "[REMARK] = \"“" + KryptonRibbonGroupComboBoxQueryKecamatan.Text + "\"";

                if (sfAsetFasPendJaktim.Table.Query(queryAsetFasPendJaktim, ref resultAsetFasPendJaktim, ref errorAsetFasPendJaktim))
                {
                    int[] shapesAsetFasPendJaktim = resultAsetFasPendJaktim as int[];
                    if (shapesAsetFasPendJaktim != null)
                    {
                        if (!(shapesAsetFasPendJaktim.Length == 0))
                        {
                            MessageBox.Show("Pada Kecamatan " + KryptonRibbonGroupComboBoxQueryKecamatan.Text
                                + "ditemukan " + shapesAsetFasPendJaktim.Length.ToString()
                                + " aset milik Pemerintah Provinsi DKI Jakarta..", "Informasi Aset", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Pada Kecamatan" + KryptonRibbonGroupComboBoxQueryKecamatan.Text
                                + " tidak ditemukan aset milik Pemerintah Kabupaten Pacitan..", "Informasi Aset", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Pada Kecamatan " + KryptonRibbonGroupComboBoxQueryKecamatan.Text
                           + "tidak ditemukan aset milik Pemerintah Kabupaten Pacitan..", "Informasi Aset", MessageBoxButtons.OK);
                    }
                }
            }

        }

        private void KryptonRibbonGroupComboBoxQueryJenis_Pend_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(KryptonRibbonGroupComboBoxQueryKecamatan.Text == "Cari Kecamatan...")
                && !(KryptonRibbonGroupComboBoxQueryJenis_Pend.Text == "Cari Jenis Pendidikan..."))
            {
                KryptonRibbonGroupComboBoxQueryFas_Pend.Items.Clear();
                KryptonRibbonGroupComboBoxQueryFas_Pend.Text = "Cari Aset....";

                Shapefile sfBatasDesa = axMap1.get_Shapefile(handleBatasDesa);
                sfBatasDesa.SelectNone();

                string errorBatasDesa = "";
                object resultBatasDesa = null;
                string queryBatasDesa = "[REMARK] = \"" + KryptonRibbonGroupComboBoxQueryKecamatan.Text
                    + "\" AND [NAMOBJ] = \"" + KryptonRibbonGroupComboBoxQueryJenis_Pend.Text + "\"";

                if (sfBatasDesa.Table.Query(queryBatasDesa, ref resultBatasDesa, ref errorBatasDesa))
                {
                    int[] shapesBatasDesa = resultBatasDesa as int[];
                    if (shapesBatasDesa != null)
                    {
                        for (int i = 0; i < shapesBatasDesa.Length; i++)
                        {
                            sfBatasDesa.set_ShapeSelected(shapesBatasDesa[i], true);
                        }
                        axMap1.ZoomToSelected(handleBatasDesa);
                    }

                }
                Shapefile sfAsetFaspendJaktim = axMap1.get_Shapefile(handleAsetFasPendJaktim);
                sfAsetFaspendJaktim.SelectNone();

                string errorAsetFasPendJaktim = "";
                object resultAsetFasPendJaktim = null;
                string queryAsetFasPendJaktim = "[REMARK] = \"" + KryptonRibbonGroupComboBoxQueryKecamatan.Text
                    + "\" AND [NAMOBJ] = \"" + KryptonRibbonGroupComboBoxQueryJenis_Pend.Text + "\"";

                if (sfAsetFaspendJaktim.Table.Query(queryAsetFasPendJaktim, ref resultAsetFasPendJaktim, ref errorAsetFasPendJaktim))
                {
                    int[] shapesAsetFasPendJaktim = resultAsetFasPendJaktim as int[];
                    if (shapesAsetFasPendJaktim != null)
                    {
                        if (!(shapesAsetFasPendJaktim.Length == 0))
                        {
                            for (int i = 0; i < shapesAsetFasPendJaktim.Length; i++)
                            {
                                if (!KryptonRibbonGroupComboBoxQueryFas_Pend.Items.Contains(
                                    sfAsetFaspendJaktim.CellValue[sfAsetFaspendJaktim.FieldIndexByName["REMARK"],
                                    shapesAsetFasPendJaktim[i]].ToString()))
                                {
                                    KryptonRibbonGroupComboBoxQueryFas_Pend.Items.Add(
                                        sfAsetFaspendJaktim.CellValue[sfAsetFaspendJaktim.FieldIndexByName["REMARK"],
                                        shapesAsetFasPendJaktim[i]].ToString());
                                }
                            }
                            KryptonRibbonGroupComboBoxQueryFas_Pend.Sorted = true;
                            MessageBox.Show("Pada Kecamatan " + KryptonRibbonGroupComboBoxQueryKecamatan.Text
                                + " Desa " + KryptonRibbonGroupComboBoxQueryJenis_Pend.Text + " ditemukan "
                                + shapesAsetFasPendJaktim.Length.ToString() + " aset milik Pemerintah Provinsi DKI Jakarta..",
                                "Informasi Aset", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Pada Kecamatan " + KryptonRibbonGroupComboBoxQueryKecamatan.Text
                                + " Desa " + KryptonRibbonGroupComboBoxQueryJenis_Pend.Text + " ditemukan "
                                + shapesAsetFasPendJaktim.Length.ToString()
                                + " tidak ditemukan aset milik Pemerintah DKI Jakarta..",
                                "Informasi Aset", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Pada Kecamatan " + KryptonRibbonGroupComboBoxQueryKecamatan.Text
                            + " Desa " + KryptonRibbonGroupComboBoxQueryJenis_Pend.Text + " ditemukan "
                            + shapesAsetFasPendJaktim.Length.ToString()
                            + " tidak ditemukan aset milik Pemerintah DKI Jakarta..",
                            "Informasi Aset", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void KryptonRibbonGroupComboBoxQueryFas_Pend_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(KryptonRibbonGroupComboBoxQueryKecamatan.Text == "Cari Kecamatan...")
               && !(KryptonRibbonGroupComboBoxQueryJenis_Pend.Text == "Cari Jenis Pendidikan...")
               && !(KryptonRibbonGroupComboBoxQueryFas_Pend.Text == "Cari Aset..."))
            {
                Shapefile sfBatasDesa = axMap1.get_Shapefile(handleBatasDesa);
                sfBatasDesa.SelectNone();

                Shapefile sfAsetFasPendJaktim = axMap1.get_Shapefile(handleAsetFasPendJaktim);
                sfAsetFasPendJaktim.SelectNone();

                string errorAsetFasPendJaktim = "";
                object resultAsetFasPendJaktim = null;
                string queryAsetFasPendJaktim = "[REMARK] = \"" + KryptonRibbonGroupComboBoxQueryKecamatan.Text
                    + "\" AND [NAMOBJ] = \"" + KryptonRibbonGroupComboBoxQueryJenis_Pend.Text
                    + "\" AND [REMARK] = \"" + KryptonRibbonGroupComboBoxQueryFas_Pend.Text + "\"";

                if (sfAsetFasPendJaktim.Table.Query(queryAsetFasPendJaktim, ref resultAsetFasPendJaktim, ref errorAsetFasPendJaktim))
                {
                    int[] shapesAsetFasPendJaktim = resultAsetFasPendJaktim as int[];
                    if (shapesAsetFasPendJaktim != null)
                    {
                        for (int i = 0; i < shapesAsetFasPendJaktim.Length; i++)
                        {
                            sfAsetFasPendJaktim.set_ShapeSelected(shapesAsetFasPendJaktim[i], true);
                        }
                        axMap1.ZoomToSelected(handleAsetFasPendJaktim);
                        axMap1.ZoomIn(0.2);
                        axMap1.ZoomIn(0.2);
                        axMap1.ZoomIn(0.2);
                        axMap1.ZoomIn(0.2);
                        axMap1.ZoomIn(0.2);
                    }
                }
            }
        }

        //=========================
        //EDIT
        //=========================
        private void KryptonRibbonGroupButton_AddPoint_Click(object sender, EventArgs e)
        {
            formAddPointObject.Show();
            formAddPointObject.BringToFront();
        }

        //=========================
        //ANALYST
        //=========================
        private void kryptonRibbonGroupButton_Buffer_Click(object sender, EventArgs e)
        {
            formBufferObject.Show();
            formBufferObject.BringToFront();
        }


        //=========================
        //MAP EVENT
        //=========================

        private void axMap1_MouseUpEvent(object sender, _DMapEvents_MouseUpEvent e)
        {
            double projX = 0.0;
            double projY = 0.0;
            axMap1.PixelToProj(e.x, e.y, ref projX, ref projY);
            object result = null;
            Extents ext = new Extents();
            ext.SetBounds(projX, projY, 0.0, projX, projY, 0.0);
            double tolerance = 100; //meters
            Utils utils = new Utils();
            utils.ConvertDistance(tkUnitsOfMeasure.umMeters, tkUnitsOfMeasure.umDecimalDegrees, ref tolerance);

            if (KryptonRibbonGroup_Identify.Checked == true)
            {
                Shapefile sf = axMap1.get_Shapefile(handleAsetFasPendJaktim);
                sf.SelectNone();
                axMap1.Redraw2(tkRedrawType.RedrawAll);
                axMap1.Refresh();

                formPopUpObject.Hide();

                if (sf != null)
                {
                    if (sf.SelectShapes(ext, tolerance, SelectMode.INTERSECTION, ref result))
                    {
                        int[] shapes = result as int[];
                        if (shapes.Length > 0)
                        {
                            sf.SelectNone();
                            sf.set_ShapeSelected(shapes[0], true);
                            axMap1.Redraw2(tkRedrawType.RedrawAll);
                            axMap1.Refresh();

                            formPopUpObject.txtShapeIndex.Text = shapes[0].ToString();

                            formPopUpObject.txtKode.Text = sf.get_CellValue(
                                sf.Table.get_FieldIndexByName("kode"), shapes[0]).ToString();
                            formPopUpObject.txtNamaPendidikan.Text = sf.get_CellValue(
                                sf.Table.get_FieldIndexByName("penggunaan"), shapes[0]).ToString();
                            formPopUpObject.txtFoto.Text = sf.get_CellValue(
                                sf.Table.get_FieldIndexByName("foto"), shapes[0]).ToString();
                            formPopUpObject.cboJenisFasPend.Text = sf.get_CellValue(
                                sf.Table.get_FieldIndexByName("jenis pendidikan"), shapes[0]).ToString();

                            formPopUpObject.Show();
                            formPopUpObject.BringToFront();
                        }
                    }
                }
            }
            else if (axMap1.MapCursor == tkCursor.crsrCross)
            {
                formAddPointObject.txtTitikX.Text = Convert.ToString(projX);
                formAddPointObject.txtTitikY.Text = Convert.ToString(projY);
            }
        }
        //=======================
        //FUNCTION
        //=======================
        public void loadAsetFasPendJaktim()
        {
            //==============================
            //ADD LAYER ASET FASPEND JAKTIM
            //==============================
            string shpAsetFasPendJaktim = Path.Combine(strFilePath, "C:/Users/nadia/Desktop/PRAKTIKUM SEM 2/PGD/ACARA 6 DAN 7/ACARA_6_7/ACARA_6_7/Resource/Database/Spatial/Titik_Pend_Jaktim.shp");
            MapWinGIS.Shapefile sfAsetFasPendJaktim = new MapWinGIS.Shapefile();
            sfAsetFasPendJaktim.Open(shpAsetFasPendJaktim, null);
            handleAsetFasPendJaktim = legend1.Layers.Add(sfAsetFasPendJaktim, true);
            legend1.GetLayer(handleAsetFasPendJaktim).Name = "Fasilitas Pendidikan Jakarta Timur";

            sfAsetFasPendJaktim.DefaultDrawingOptions.Visible = false; //hide all the unclassified points
            sfAsetFasPendJaktim.Categories.ApplyExpressions();
            axMap1.Redraw();

            //===============================
            //LOAD ATTRIBUTE
            //===============================
            DataGridView1.Rows.Clear();
            KryptonRibbonGroupComboBoxQueryKecamatan.Items.Clear();

            for (int i = 0; i < sfAsetFasPendJaktim.Table.NumFields; i++)
            {
                DataGridView1.Columns.Add(sfAsetFasPendJaktim.Table.Field[i].Name, sfAsetFasPendJaktim.Table.Field[i].Name);
            }
            DataGridView1.Columns.Add("fid", "fid");

            for (int i = 0; i < sfAsetFasPendJaktim.Table.NumRows; i ++)
            {

                if (!KryptonRibbonGroupComboBoxQueryKecamatan.Items.Contains(
                   sfAsetFasPendJaktim.Table.CellValue[sfAsetFasPendJaktim.FieldIndexByName["NAMOBJ"], i].ToString())) ;
                {
                    KryptonRibbonGroupComboBoxQueryKecamatan.Items.Add(
                         sfAsetFasPendJaktim.Table.CellValue[sfAsetFasPendJaktim.FieldIndexByName["NAMOBJ"], i].ToString()) ;
                }
            }
            DataGridView1.ClearSelection();
            KryptonRibbonGroupComboBoxQueryKecamatan.Sorted = true;
        }
    }
}