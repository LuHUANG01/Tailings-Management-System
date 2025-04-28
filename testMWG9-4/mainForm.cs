using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MapWinGIS;
//using AxMapWinGIS;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using DotSpatial.Controls;
using DotSpatial.Symbology.Forms;
using DotSpatial.Symbology;
using DotSpatial.Data;
using DotSpatial.Topology;
using System.Data.SqlClient;
using DotSpatial.Projections;
//using DotSpatial.Data.GdalExtension;
using DotSpatial.Data.Rasters.GdalExtension;

namespace testMWG9_4
{
    public partial class mainForm : Form
    {

        Boolean textboxHasText = false;//判断坐标输入框是否有文本(dotspatial)     

        //private MySqlConnection mysql_con;//先声明一个MySqlConnection 便于后续操作数据库使用
        public class mysql_Helper
        {
            public static String mysql_con = "data source=localhost;database=tailings;user id=root;password=123456;pooling=true;charset=utf8;";
            public static String link = "data source=localhost;database=tailings;user id=root;password=123456;pooling=true;charset=utf8;";
            public static MySqlConnection MySQL_con;
            public static DataTable dt_excel = new DataTable();
            public static System.Data.DataSet ds = new System.Data.DataSet();
            public static int num = 0;
        }
        public string select_name;

        public mainForm()
        {
            InitializeComponent();

            /*dotspatial*/

            /* 数据库界面：光标移动到输入框提示文案消失 */
            textBox2.LostFocus += new EventHandler(textBox2_Leave); //失去焦点后发生事件
            textBox2.GotFocus += new EventHandler(textBox2_Enter);  //获取焦点前发生事件
            textBox2.Text = "请输入尾矿库名称";
            textBox2.ForeColor = Color.LightGray;

            //map1.AddLayers();
            //map1.AddImageLayer();
            //map1.AddLayer();

            string fileName1 = "D://111bishe/侯老师给的数据/矢量数据/凤县高程1.tif";
            string fileName2 = "D://111bishe/侯老师给的数据/矢量数据/淹没区域1.tif";
            string fileName3 = "D://111bishe/侯老师给的数据/矢量数据/淹没区域21.tif";
            string fileName4 = "D://111bishe/侯老师给的数据/矢量数据/淹没区域31.tif";
            string fileName5 = "D://111bishe/侯老师给的数据/矢量数据/淹没区域41.tif";
            string fileName6 = "D://111bishe/侯老师给的数据/矢量数据/淹没区域51.tif";
            string fileName7 = "D://111bishe/侯老师给的数据/矢量数据/尾矿库溃坝路径.shp";
            string fileName8 = "D://111bishe/侯老师给的数据/矢量数据/封堵点1.shp";
            string fileName9 = "D://111bishe/侯老师给的数据/矢量数据/封堵点2t.shp";
            string fileName10 = "D://111bishe/侯老师给的数据/矢量数据/宝鸡市尾矿库.shp";
            //string fileName11 = "D://DATA/Export_Output.shp";


            //map1.AddLayer(fileName1);
            //map1.AddLayer(fileName2);
            //map1.AddLayer(fileName3);
            //map1.AddLayer(fileName4);
            //map1.AddLayer(fileName5);
            //map1.AddLayer(fileName6);
            //map1.AddLayer(fileName7);
            //map1.AddLayer(fileName8);
            //map1.AddLayer(fileName9);
            //map1.AddLayer(fileName10);
            //ProjectionInfo projection = new ProjectionInfo();
            //projection = ProjectionInfo.FromEpsgCode(4326);

            //map1.Projection = projection;

            fileName4 = @"D:\111bishe\侯老师给的数据\矢量数据\tmp\2.tif";
            fileName9 = @"D:\111bishe\侯老师给的数据\矢量数据\tmp\1.shp";

            //map1.AddLayer(fileName4);
            //map1.AddLayer(fileName9);

            //map1.AddRasterLayer();
        }

        /* 选择可视化展示的区域（流域） */
        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "嘉陵江流域")
            {
                map1.ClearLayers();
                map1.Projection = KnownCoordinateSystems.Geographic.World.WGS1984;
                //map1.Projection = KnownCoordinateSystems.Projected.UtmNad1983.NAD1983UTMZone49N;



                //先加载栅格数据
                DirectoryInfo topDir = Directory.GetParent(System.Environment.CurrentDirectory);
                string pathto = topDir.Parent.FullName;

                string outputFile1 = pathto + "\\data\\凤县高程1.tif";
                string outputFile2 = pathto + "\\data\\淹没区域1.tif";
                string outputFile3 = pathto + "\\data\\淹没区域21.tif";
                string outputFile4 = pathto + "\\data\\淹没区域31.tif";
                string outputFile5 = pathto + "\\data\\淹没区域41.tif";
                string outputFile6 = pathto + "\\data\\淹没区域51.tif";



                /*
                 添加DotSpatial 1.9\Windows Extensions\DotSpatial.Data.Rasters.GdalExtension
                 中的DotSpatial.Data.Rasters.GdalExtension.dll
                 */
                DotSpatial.Data.Rasters.GdalExtension.GdalRasterProvider lGdalRasterProvider = new DotSpatial.Data.Rasters.GdalExtension.GdalRasterProvider();

                DotSpatial.Data.IRaster image1 = DotSpatial.Data.DataManager.DefaultDataManager.OpenRaster(outputFile1);
                map1.Layers.Add(image1);
                DotSpatial.Data.IRaster image2 = DotSpatial.Data.DataManager.DefaultDataManager.OpenRaster(outputFile2);
                map1.Layers.Add(image2);
                DotSpatial.Data.IRaster image3 = DotSpatial.Data.DataManager.DefaultDataManager.OpenRaster(outputFile3);
                map1.Layers.Add(image3);
                DotSpatial.Data.IRaster image4 = DotSpatial.Data.DataManager.DefaultDataManager.OpenRaster(outputFile4);
                map1.Layers.Add(image4);
                DotSpatial.Data.IRaster image5 = DotSpatial.Data.DataManager.DefaultDataManager.OpenRaster(outputFile5);
                map1.Layers.Add(image5);
                DotSpatial.Data.IRaster image6 = DotSpatial.Data.DataManager.DefaultDataManager.OpenRaster(outputFile6);
                map1.Layers.Add(image6);

                image1.Reproject(map1.Projection);
                image2.Reproject(map1.Projection);
                image3.Reproject(map1.Projection);
                image4.Reproject(map1.Projection);
                image5.Reproject(map1.Projection);

                map1.Layers[0].Reproject(map1.Projection);
                map1.Layers[1].Reproject(map1.Projection);
                map1.Layers[2].Reproject(map1.Projection);
                map1.Layers[3].Reproject(map1.Projection);
                map1.Layers[4].Reproject(map1.Projection);

                IMapRasterLayer layer1 = map1.Layers[1] as IMapRasterLayer;
                DotSpatial.Symbology.ColorScheme scheme1 = new DotSpatial.Symbology.ColorScheme();
                ColorCategory category1 = new ColorCategory(911, 65535, Color.Yellow, Color.Red);
                scheme1.AddCategory(category1);
                layer1.Symbolizer.Scheme = scheme1;
                layer1.WriteBitmap();
                image2.Close();

                IMapRasterLayer layer2 = map1.Layers[2] as IMapRasterLayer;
                DotSpatial.Symbology.ColorScheme scheme2 = new DotSpatial.Symbology.ColorScheme();
                ColorCategory category2 = new ColorCategory(1044, 1799, Color.Yellow, Color.Red);
                scheme2.AddCategory(category2);
                layer2.Symbolizer.Scheme = scheme2;
                layer2.WriteBitmap();
                image3.Close();

                IMapRasterLayer layer3 = map1.Layers[3] as IMapRasterLayer;
                DotSpatial.Symbology.ColorScheme scheme3 = new DotSpatial.Symbology.ColorScheme();
                ColorCategory category3 = new ColorCategory(1159, 1499, Color.Yellow, Color.Red);
                scheme3.AddCategory(category3);
                layer3.Symbolizer.Scheme = scheme3;
                layer3.WriteBitmap();
                image4.Close();

                IMapRasterLayer layer4 = map1.Layers[4] as IMapRasterLayer;
                DotSpatial.Symbology.ColorScheme scheme4 = new DotSpatial.Symbology.ColorScheme();
                ColorCategory category4 = new ColorCategory(1161, 1499, Color.Yellow, Color.Red);
                scheme4.AddCategory(category4);
                layer4.Symbolizer.Scheme = scheme4;
                layer4.WriteBitmap();
                image5.Close();

                IMapRasterLayer layer5 = map1.Layers[5] as IMapRasterLayer;
                DotSpatial.Symbology.ColorScheme scheme5 = new DotSpatial.Symbology.ColorScheme();
                ColorCategory category5 = new ColorCategory(957, 1399, Color.Yellow, Color.Red);
                scheme5.AddCategory(category5);
                layer5.Symbolizer.Scheme = scheme5;
                layer5.WriteBitmap();
                image6.Close();

                string fileName7 = pathto + "\\data\\溃坝路径.shp";
                string fileName8 = pathto + "\\data\\封堵.shp";
                string fileName9 = pathto + "\\data\\封堵点.shp";
                string fileName10 = pathto + "\\data\\line.shp";
                string fileName11 = pathto + "\\data\\陕西省尾矿点（341）.shp";

                //FeatureSet FS1 = new FeatureSet();


                map1.AddLayer(fileName11);
                map1.AddLayer(fileName7);
                map1.AddLayer(fileName8);
                map1.AddLayer(fileName9);
                map1.AddLayer(fileName10);

                map1.Layers[5].Reproject(map1.Projection);
                map1.Layers[6].Reproject(map1.Projection);
                map1.Layers[7].Reproject(map1.Projection);
                map1.Layers[8].Reproject(map1.Projection);
                map1.Layers[9].Reproject(map1.Projection);

                // map1.
                //var shp = DotSpatial.Data.Shapefile.OpenFile(pathto + "\\data\\line.shp");
                //shp.Projection = KnownCoordinateSystems.Geographic.World.WGS1984;
                //var layer = map1.Layers.Add(shp) as MapLineLayer;
            }
        }


        //textbox获得焦点
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textboxHasText == false)
                textBox2.Text = "";

            textBox2.ForeColor = Color.Black;
        }
        //textbox失去焦点
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "请输入地理坐标";
                textBox2.ForeColor = Color.LightGray;
                textboxHasText = false;
            }
            else
                textboxHasText = true;
        }

        /* 实时显示坐标 */
        private void map1_MouseMove(object sender, MouseEventArgs e)
        {
            //将地图和坐标函数绑定
            GeoMouseArgs args = new GeoMouseArgs(e, map1);

            //求X、Y轴坐标

            string xpanel = String.Format("X: {0:0.00000}", args.GeographicLocation.X);

            string ypanel = String.Format("Y: {0:0.00000}", args.GeographicLocation.Y);

            //this.CoordateLabel.Text = xpanel + " " + ypanel;
            label4.Text = xpanel + " " + ypanel;
        }

        /* 点击尾矿库显示尾矿库基本信息 */
        private void map1_SelectionChanged(object sender, EventArgs e)
        {
            if (map1.FunctionMode == FunctionMode.Select)
            {
                PointLayer pLayer1 = map1.Layers[6] as PointLayer;
                //FeatureSet fs = null;
                //fs = (FeatureSet)map1.Layers[10].DataSet;
                if (pLayer1.Selection.Count > 1)
                {
                    if (mysql_Helper.num == 0)
                    {

                        mysql_Helper.num++;
                    }
                    else if (mysql_Helper.num == 1)
                    {
                        MessageBox.Show("选择多个元素,请选择一个元素", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        mysql_Helper.num = 0;
                    }
                    return;
                }
                else if (pLayer1.Selection.Count == 1)
                {
                    foreach (Feature feature in pLayer1.Selection.ToFeatureList())
                    {
                        //MessageBox.Show((string)feature.DataRow["尾矿库"]); //feature2.DataRow.Field<Int64>("林班号").ToString()
                        select_name = (string)feature.DataRow["尾矿库"];
                        mysql_Helper.num++;
                        //数据库查询
                        MySqlConnection conn = new MySqlConnection(mysql_Helper.mysql_con);//MessageBox.Show(feature.DataRow.Field<string>("NAME"));
                        conn.Open();
                        if (conn.State.ToString() == "Open")
                        {
                            //string selectname = (string)feature.DataRow["尾矿库"];
                            string str = "SELECT * FROM tailings.test where name ='" + select_name + "'";

                            MySqlDataAdapter da = new MySqlDataAdapter();       // 实例化sqldataadpter
                            MySqlCommand cmd1 = new MySqlCommand(str, conn);     //sql语句
                            MySqlDataReader test = cmd1.ExecuteReader();
                            if (test.Read())
                            {
                                string id = test["id_risk"].ToString();
                                string name = test["name"].ToString();
                                string type = test["type"].ToString();
                                string city = test["city"].ToString();
                                string region = test["region"].ToString();
                                string level = test["level"].ToString();
                                string h_grade = test["h_grade"].ToString();
                                string h_level = test["h_level"].ToString();
                                string s_grade = test["s_grade"].ToString();
                                string s_level = test["s_level"].ToString();
                                string r_grade = test["r_grade"].ToString();
                                string r_level = test["r_level"].ToString();
                                string situation = test["situation"].ToString();
                                if (mysql_Helper.num == 2)
                                {
                                    showLevel showLevel1 = new showLevel(id, name, type, city, region, level, h_grade, h_level, s_grade, s_level, r_grade, r_level, situation);
                                    showLevel1.ShowDialog();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("数据库连接失败");
                            return;
                        }
                    }
                }
            }
        }

        /* 结果直接查询（尾矿库名称） */
        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "请输入尾矿库名称")
            {
                MessageBox.Show("请输入尾矿库名称");
            }
            else
            {
                //对数据库查询
                MySqlConnection con = new MySqlConnection(mysql_Helper.mysql_con);
                MySqlCommand cmd = con.CreateCommand();
                con.Open();
                try
                {
                    cmd.CommandText = "SELECT * FROM tailings.datamysql where tailings ='" + textBox2.Text + "'";
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    //System.Data.DataSet ds = new System.Data.DataSet();
                    adap.Fill(mysql_Helper.ds);
                    dataGridView1.DataSource = mysql_Helper.ds.Tables[0].DefaultView;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        ///* 选择指标查询 */
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string h_level;
        //    string s_level;
        //    string r_level;
        //    if (comboBox1.Text == "环境危害性(H)" || comboBox3.Text == "周边环境敏感性(S)" || comboBox2.Text == "控制机制可靠性(R)")
        //    {
        //        MessageBox.Show("请选择各项指标"); ;
        //    }
        //    else
        //    {
        //        if (comboBox1.Text == "不列入筛选条件")
        //        {
        //            h_level = "";
        //        }
        //        else
        //        {
        //            h_level = comboBox1.Text;
        //        }
        //        if (comboBox3.Text == "不列入筛选条件")
        //        {
        //            s_level = "";
        //        }
        //        else
        //        {
        //            s_level = comboBox3.Text;
        //        }
        //        if (comboBox2.Text == "不列入筛选条件")
        //        {
        //            r_level = "";
        //        }
        //        else
        //        {
        //            r_level = comboBox2.Text;
        //        }
        //        MySqlConnection con = new MySqlConnection(mysql_Helper.mysql_con);
        //        MySqlCommand cmd = con.CreateCommand();
        //        con.Open();
        //        try
        //        {
        //            //多条件查询
        //            string Sersql = "SELECT * FROM tailings.test where h_level='" + h_level + "'";
        //            Sersql += "and s_level='" + s_level + "'";
        //            Sersql += "and r_level='" + r_level + "'";
        //            cmd.CommandText = Sersql;
        //            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
        //            System.Data.DataSet ds = new System.Data.DataSet();
        //            adap.Fill(ds);
        //            dataGridView2.DataSource = ds.Tables[0].DefaultView;
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //        finally
        //        {
        //            if (con.State == ConnectionState.Open)
        //            {
        //                con.Close();
        //            }
        //        }
        //    }
        //}

        /* 风险等级查询 */
        private void button19_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text == "环境风险等级")
            {
                MessageBox.Show("请选择环境风险等级");
            }
            else
            {
                string level = "";
                MySqlConnection con = new MySqlConnection(mysql_Helper.mysql_con);
                MySqlCommand cmd = con.CreateCommand();
                con.Open();
                try
                {
                    if (comboBox6.Text == "暂无数据")
                    {
                        level = "";
                    }
                    else
                    {
                        level = comboBox6.Text;
                    }
                    cmd.CommandText = "SELECT * FROM tailings.datamysql where regulatory_level ='" + level + "'";
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    System.Data.DataSet ds = new System.Data.DataSet();
                    adap.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0].DefaultView;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        /* 地市和县的二级联动 */
        private void city_SelectedIndexChanged(object sender, EventArgs e)
        {
            region.Items.Clear();
            if (city.Text == "西安市")
            {
                region.Items.Add("新城区");
                region.Items.Add("碑林区");
                region.Items.Add("莲湖区");
                region.Items.Add("雁塔区");
                region.Items.Add("未央区");
                region.Items.Add("灞桥区");
                region.Items.Add("阎良区");
                region.Items.Add("临潼区");
                region.Items.Add("长安区");
                region.Items.Add("高陵区");
                region.Items.Add("鄠邑区");
                region.Items.Add("周至县");
                region.Items.Add("蓝田县");
            }
            else if (city.Text == "宝鸡市")
            {
                region.Items.Add("渭滨区");
                region.Items.Add("金台区");
                region.Items.Add("陈仓区");
                region.Items.Add("凤翔县");
                region.Items.Add("岐山县");
                region.Items.Add("扶风县");
                region.Items.Add("眉县");
                region.Items.Add("陇县");
                region.Items.Add("千阳县");
                region.Items.Add("麟游县");
                region.Items.Add("凤县");
                region.Items.Add("太白县");
            }
            else if (city.Text == "咸阳市")
            {
                region.Items.Add("秦都区");
                region.Items.Add("杨陵区");
                region.Items.Add("渭城区");
                region.Items.Add("兴平市");
                region.Items.Add("三原县");
                region.Items.Add("泾阳县");
                region.Items.Add("乾县");
                region.Items.Add("礼泉县");
                region.Items.Add("永寿县");
                region.Items.Add("彬州市");
                region.Items.Add("长武县");
                region.Items.Add("旬邑县");
                region.Items.Add("淳化县");
                region.Items.Add("武功县");
            }
            else if (city.Text == "铜川市")
            {
                region.Items.Add("王益区");
                region.Items.Add("印台区");
                region.Items.Add("耀州区");
                region.Items.Add("宜君县");
            }
            else if (city.Text == "渭南市")
            {
                region.Items.Add("临渭区");
                region.Items.Add("华州区");
                region.Items.Add("潼关县");
                region.Items.Add("大荔县");
                region.Items.Add("合阳县");
                region.Items.Add("澄城县");
                region.Items.Add("蒲城县");
                region.Items.Add("白水县");
                region.Items.Add("富平县");
                region.Items.Add("韩城市");
                region.Items.Add("华阴市");
            }
            else if (city.Text == "延安市")
            {
                region.Items.Add("宝塔区");
                region.Items.Add("安塞区");
                region.Items.Add("延长县");
                region.Items.Add("延川县");
                region.Items.Add("子长县");
                region.Items.Add("志丹县");
                region.Items.Add("吴起县");
                region.Items.Add("甘泉县");
                region.Items.Add("富县");
                region.Items.Add("洛川县");
                region.Items.Add("宜川县");
                region.Items.Add("黄龙县");
                region.Items.Add("黄陵县");
            }
            else if (city.Text == "榆林市")
            {
                region.Items.Add("榆阳区");
                region.Items.Add("横山区");
                region.Items.Add("神木市");
                region.Items.Add("府谷县");
                region.Items.Add("靖边县");
                region.Items.Add("定边县");
                region.Items.Add("绥德县");
                region.Items.Add("米脂县");
                region.Items.Add("佳县");
                region.Items.Add("吴堡县");
                region.Items.Add("清涧县");
                region.Items.Add("子洲县");
            }
            else if (city.Text == "汉中市")
            {
                region.Items.Add("汉台区");
                region.Items.Add("南郑区");
                region.Items.Add("城固县");
                region.Items.Add("洋县");
                region.Items.Add("西乡县");
                region.Items.Add("勉县");
                region.Items.Add("宁强县");
                region.Items.Add("略阳县");
                region.Items.Add("镇巴县");
                region.Items.Add("留坝县");
                region.Items.Add("佛坪县");
            }
            else if (city.Text == "安康市")
            {
                region.Items.Add("汉滨区");
                region.Items.Add("汉阴县");
                region.Items.Add("石泉县");
                region.Items.Add("宁陕县");
                region.Items.Add("紫阳县");
                region.Items.Add("岚皋县");
                region.Items.Add("平利县");
                region.Items.Add("镇坪县");
                region.Items.Add("旬阳县");
                region.Items.Add("白河县");
            }
            else if (city.Text == "商洛市")
            {
                region.Items.Add("商州区");
                region.Items.Add("洛南县");
                region.Items.Add("丹凤县");
                region.Items.Add("商南县");
                region.Items.Add("山阳县");
                region.Items.Add("镇安县");
                region.Items.Add("柞水县");
            }
        }

        /* 地区查询 */
        private void button3_Click(object sender, EventArgs e)
        {
            if (region.Text == "选择县(区、市)")
            {
                MessageBox.Show("请选择地区");
            }
            else
            {
                //对数据库查询
                MySqlConnection con = new MySqlConnection(mysql_Helper.mysql_con);
                MySqlCommand cmd = con.CreateCommand();
                con.Open();
                try
                {
                    cmd.CommandText = "SELECT * FROM tailings.datamysql where county ='" + region.Text + "'";
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    //System.Data.DataSet ds = new System.Data.DataSet();
                    adap.Fill(mysql_Helper.ds);
                    dataGridView1.DataSource = mysql_Helper.ds.Tables[0].DefaultView;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        ///* 增加 */
        //private void button10_Click_1(object sender, EventArgs e)
        //{
        //    add addData = new add();
        //    addData.ShowDialog();
        //}

        ///* 修改 */
        //private void button9_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView2.SelectedRows.Count == 0)//判断是否选中某行
        //    {
        //        MessageBox.Show("请选中需要修改的信息");
        //    }
        //    else if (dataGridView2.SelectedRows.Count > 1)
        //    {
        //        MessageBox.Show("请选中一行信息");
        //    }
        //    else if (dataGridView2.SelectedRows.Count == 1)
        //    {
        //        int a = dataGridView2.CurrentRow.Index;
        //        string id = dataGridView2.Rows[a].Cells[0].Value.ToString();
        //        string name = (string)dataGridView2.Rows[a].Cells[1].Value;
        //        string type = (string)dataGridView2.Rows[a].Cells[2].Value;
        //        string city = (string)dataGridView2.Rows[a].Cells[3].Value;
        //        string region = (string)dataGridView2.Rows[a].Cells[4].Value;
        //        string level = (string)dataGridView2.Rows[a].Cells[5].Value;
        //        string h_grade = (string)dataGridView2.Rows[a].Cells[6].Value;
        //        string h_level = (string)dataGridView2.Rows[a].Cells[7].Value;
        //        string s_grade = (string)dataGridView2.Rows[a].Cells[8].Value;
        //        string s_level = (string)dataGridView2.Rows[a].Cells[9].Value;
        //        string r_grade = (string)dataGridView2.Rows[a].Cells[10].Value;
        //        string r_level = (string)dataGridView2.Rows[a].Cells[11].Value;
        //        string situation = (string)dataGridView2.Rows[a].Cells[12].Value;
        //        edit editData = new edit(id, name, type, city, region, level,
        //         h_grade, h_level, s_grade, s_level, r_grade, r_level, situation);
        //        editData.ShowDialog();
        //    }
        //}

        ///* 删除 */
        //private void button7_Click(object sender, EventArgs e)
        //{
        //    if (dataGridView2.SelectedRows.Count == 0)//判断是否选中某行
        //    {
        //        MessageBox.Show("请选中需要修改的信息");
        //    }
        //    else if (dataGridView2.SelectedRows.Count > 1)
        //    {
        //        MessageBox.Show("请选中一行信息");
        //    }
        //    else if (dataGridView2.SelectedRows.Count == 1)
        //    {

        //        int a = dataGridView2.CurrentRow.Index;
        //        DataGridViewRow dgr = dataGridView2.SelectedRows[0];
        //        string id = dataGridView2.Rows[a].Cells[0].Value.ToString();

        //        MySqlConnection con = new MySqlConnection(mysql_Helper.mysql_con);
        //        MySqlCommand cmd = con.CreateCommand();
        //        con.Open();
        //        cmd.CommandText = "DELETE from test1 where id_risk=" + id;
        //        if (cmd.ExecuteNonQuery() > 0)
        //            dataGridView2.Rows.Remove(dgr);//如果成功从数据中删除了记录，则从列表中同步删除。
        //        else
        //            MessageBox.Show(string.Format("从数据库中删除id为{0}的记录失败", dgr.Cells[0].Value.ToString()));
        //        con.Close();
        //    }
        //}

        ///* 刷新 */
        //private void button2_Click(object sender, EventArgs e)
        //{

        //    //对数据库查询
        //    MySqlConnection con = new MySqlConnection(mysql_Helper.mysql_con);
        //    MySqlCommand cmd = con.CreateCommand();
        //    con.Open();
        //    try
        //    {
        //        cmd.CommandText = "SELECT * FROM tailings.test1";
        //        MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
        //        adap.Fill(mysql_Helper.ds);
        //        dataGridView2.DataSource = mysql_Helper.ds.Tables[0].DefaultView;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();
        //        }
        //    }
        //}



        private void button15_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = FunctionMode.ZoomIn;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = FunctionMode.ZoomOut;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = FunctionMode.Pan;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            map1.ZoomToMaxExtent();
            // map1.ZoomOutFartherThanMaxExtent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = FunctionMode.Info;
        }

        /* 点击展开lengend */
        private void button16_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed == false)
            {
                splitContainer1.Panel1Collapsed = true;
            }
            else
            {
                splitContainer1.Panel1Collapsed = false;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //map1.FunctionMode = FunctionMode.Label;
            map1.FunctionMode = FunctionMode.Select;
        }

        /* 界面切换 地理信息综合展示界面 */
        private void button1_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = true;
            this.panel1.Visible = false ;
        }

        /* 界面切换 地理信息综合展示界面 */
        private void button9_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.panel2.Visible = false;
        }

        /* 界面切换 数据库 风险分级展示 */
        private void button2_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.panel2.Visible = false;

            //设置第 1 列的列标题
            //dataGridView1.Columns[0].HeaderText = "编号";
            ////设置第2列的列标题
            //dataGridView1.Columns[1].HeaderText = "专业名称";
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void 数据修改_Enter(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
