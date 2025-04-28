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
using MapWinGIS;
using DotSpatial.Symbology.Forms;
using DotSpatial.Symbology;
using DotSpatial.Data;
using DotSpatial.Topology;
using System.Data.SqlClient;
//using DotSpatial.Data.GdalExtension;

namespace testMWG9_4
{
    public partial class Form1 : Form
    {
        Boolean textboxHasText = false;//判断坐标输入框是否有文本(dotspatial)     
        private ToolStripStatusLabel m_label = null;// a label to show result in（mapwingis界面）

        //private MySqlConnection mysql_con;//先声明一个MySqlConnection 便于后续操作数据库使用
        public class mysql_Helper
        {
            public static String mysql_con = "data source=localhost;database=tailings;user id=root;password=123456;pooling=true;charset=utf8;";
            public static String link = "data source=localhost;database=tailings;user id=root;password=123456;pooling=true;charset=utf8;";
            public static MySqlConnection MySQL_con;
            public static DataTable dt_excel = new DataTable();
            public static System.Data.DataSet ds = new System.Data.DataSet();
            public static int num=0;
        }
        public string select_name;

        public Form1()
        {
            InitializeComponent();

            int intHandler;//声明一个句柄，为以后生成图层句柄做准备

            //声明一个Shapefile类型的对象(实例化) 
            MapWinGIS.Shapefile shapefile = new MapWinGIS.Shapefile();
            MapWinGIS.Shapefile shapefile1 = new MapWinGIS.Shapefile();
            MapWinGIS.Shapefile shapefile2 = new MapWinGIS.Shapefile();
            MapWinGIS.Shapefile shapefile3 = new MapWinGIS.Shapefile();
            MapWinGIS.Shapefile shapefile4 = new MapWinGIS.Shapefile();
            //MapWinGIS.Image Image = new MapWinGIS.Image();

            //使用这个对象就可以打开一个地图类型的文件(一个shapefile文件)，注意文件的路径
            //shapefile.Open(@"D://111bishe/侯老师给的数据/矢量数据/宝鸡市尾矿库.shp", null);
            //shapefile1.Open(@"D://111bishe/侯老师给的数据/矢量数据/尾矿库溃坝路径.shp", null);
            //shapefile2.Open(@"D://111bishe/侯老师给的数据/矢量数据/封堵点2t.shp", null);
            //shapefile3.Open(@"D://111bishe/侯老师给的数据/矢量数据/封堵点1.shp", null);
            shapefile4.Open(@"D://DATA/456.shp", null);//尾矿库具体点定位

            //调用axMap2对象的添加图层方法就将地图显示在了界面上,载入地图文件，true显示
            //int intHandler = axMap2.AddLayer(shapefile, true);
            //intHandler = axMap2.AddLayer(shapefile2, true);
            //intHandler = axMap2.AddLayer(shapefile3, true);
            //intHandler = axMap2.AddLayer(shapefile1, true);
            intHandler = axMap2.AddLayer(shapefile4, true);
            //////intHandler = axMap2.AddLayer(Image, true);

            /*属性对话框*/
            //shapefile = axMap2.get_Shapefile(intHandler);
            //if (!shapefile.Table.StartEditingTable(null))
            //{
            //    MessageBox.Show("Failed to show: " + shapefile.Table.ErrorMsg[shapefile.LastErrorCode]);
            //}
            //else
            //{
            //    string expression = "";
            //    for (int i = 1; i < shapefile.NumFields; i++)      // all the fields will be displayed apart the first one
            //    {
            //        expression += "[" + shapefile.Field[i].Name + "]";
            //        if (i != shapefile.NumFields - 1)
            //        {
            //            const string endLine = "\"\n\"";
            //            expression += string.Format("+ {0} +", endLine);
            //        }
            //    }
            //    shapefile.Labels.Generate(expression, tkLabelPositioning.lpCentroid, false);
            //    shapefile.Labels.TextRenderingHint = tkTextRenderingHint.SystemDefault;

            //    axMap2.SendMouseDown = true;

            //    axMap2.CursorMode = tkCursorMode.cmNone;
            //    MapEvents.MouseDownEvent += AxMap2MouseDownEvent2;  // change MapEvents to axMap1
            //    //this.ZoomToValue(shapefile, "Name", "Lakeview");
            //}


            /*dotspatial*/

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


            map1.AddLayer(fileName1);
            //map1.AddLayer(fileName2);
            //map1.AddLayer(fileName3);
            //map1.AddLayer(fileName4);
            //map1.AddLayer(fileName5);
            //map1.AddLayer(fileName6);
            //map1.AddLayer(fileName7);
            //map1.AddLayer(fileName8);
            //map1.AddLayer(fileName9);
            //map1.AddLayer(fileName10);
            //map1.AddLayer(fileName11);

        }

        //处理鼠标按下事件。动态创建编辑表单。
        /*
        // </summary>
        private void AxMap2MouseDownEvent2(object sender, _DMapEvents_MouseDownEvent e)
        {
            int layerHandle = axMap2.get_LayerHandle(0);  //这里假设我们要编辑的层是第一个1（索引为0）
            Shapefile sf = axMap2.get_Shapefile(layerHandle);
            if (sf != null)
            {
                double projX = 0.0;
                double projY = 0.0;
                MessageBox.Show("111");
                axMap2.PixelToProj(e.x, e.y, ref projX, ref projY);

                object result = null;
                Extents ext = new Extents();
                ext.SetBounds(projX, projY, 0.0, projX, projY, 0.0);
                if (sf.SelectShapes(ext, 0.0, SelectMode.INCLUSION, ref result))
                {
                    int[] shapes = result as int[];
                    MessageBox.Show("2221");
                    if (shapes == null) return;
                    if (shapes.Length > 1)
                    {
                        string s = "More than one shapes were selected. Shape indices:";
                        for (int i = 0; i < shapes.Length; i++)
                            s += shapes[i] + Environment.NewLine;
                        MessageBox.Show(s);
                        MessageBox.Show("222");
                    }
                    else
                    {
                        sf.set_ShapeSelected(shapes[0], true);  // selecting the shape we are about to edit
                        axMap2.Redraw(); Application.DoEvents();

                        Form form = new Form();
                        for (int i = 0; i < sf.NumFields; i++)
                        {
                            MessageBox.Show("333");
                            System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                            label.Left = 15;
                            label.Top = i * 30 + 5;
                            label.Text = sf.Field[i].Name;
                            label.Width = 60;
                            form.Controls.Add(label);
                            TextBox box = new TextBox();
                            box.Left = 80;
                            box.Top = label.Top;
                            box.Width = 80;
                            box.Text = sf.CellValue[i, shapes[0]].ToString();
                            box.Name = sf.Field[i].Name;
                            form.Controls.Add(box);
                        }
                        form.Width = 180;
                        form.Height = sf.NumFields * 30 + 70;
                        //Button btn = new Button
                        //{
                        //    Text = "Ok",
                        //    Top = sf.NumFields * 30 + 10,
                        //    Left = 20,
                        //    Width = 70,
                        //    Height = 25
                        //};
                        //btn.Click += BtnClick;
                        //form.Controls.Add(btn);
                        //btn = new Button
                        //{
                        //    Text = "Cancel",
                        //    Top = sf.NumFields * 30 + 10,
                        //    Left = 100,
                        //    Width = 70,
                        //    Height = 25
                        //};
                        //btn.Click += BtnClick;
                        //form.Controls.Add(btn);
                        form.FormClosed += FormFormClosed;
                        form.Text = "Shape: " + shapes[0];
                        form.ShowInTaskbar = false;
                        form.StartPosition = FormStartPosition.CenterParent;
                        form.FormBorderStyle = FormBorderStyle.FixedDialog;
                        form.MaximizeBox = false;
                        form.MinimizeBox = false;
                        form.ShowDialog(axMap2.Parent);
                    }
                }
            }
            // Execute this code if you want to save the results.
            // sf.StopEditingShapes(true, true, null);
        }

        // Clears selected shapes on the closing of the form
        // </summary>
        void FormFormClosed(object sender, FormClosedEventArgs e)
        {
            int layerHandle = axMap2.get_LayerHandle(0);
            Shapefile sf = axMap2.get_Shapefile(layerHandle);
            if (sf != null)
            {
                sf.SelectNone();
                axMap2.Redraw();
            }
        }
        */

        ///*显示属性表 示例：ShowAttributes.cs*/ // Shows attributes of shape in mouse move event.

        // a label to show result in
        //System.Windows.Forms.Label Attributes = null;

        //public void ShowAttributes(AxMap axMap2, string dataPath, System.Windows.Forms.Label Attributes)
        //{
        //    //    axMap1.Projection = tkMapProjection.PROJECTION_GOOGLE_MERCATOR;
        //    int ShowAttributes_intHandler;
        //    string filename = "D://DATA//456.shp";
        //    Shapefile sf = new Shapefile();
        //    if (sf.Open(filename))
        //    {
        //        ShowAttributes_intHandler = axMap2.AddLayer(sf, true);
        //                sf = axMap2.get_Shapefile(ShowAttributes_intHandler);     // in case a copy of shapefile was created by GlobalSettings.ReprojectLayersOnAdding

        //                axMap2.SendMouseMove = true;
        //                axMap2.CursorMode = tkCursorMode.cmIdentify; 
        //                axMap2.ShapeHighlighted += AxMap2ShapeHighlighted;
        //                //show_table = label;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Failed to open shapefile");
        //    }
        //}

        //public AxMapWinGIS._DMapEvents_ShapeHighlightedEventHandler axMap2_ShapeHighlighted { get; set; }

        //} /*显示属性表 try2*/


        /* 选项卡显示切换 */
        private void funtion1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.Visible = true;
            this.tabControl2.Visible = false;
        }

        /* 选项卡显示切换：点击“尾矿库信息管理”菜单栏 */
        private void funtion2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.Visible = false;
            this.tabControl2.Visible = true;

            //设置第 1 列的列标题
            //dataGridView1.Columns[0].HeaderText = "编号";
            ////设置第2列的列标题
            //dataGridView1.Columns[1].HeaderText = "专业名称";
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }



        //textbox获得焦点
        private void textBox11_Enter(object sender, EventArgs e)
        {
            if (textboxHasText == false)
                textBox11.Text = "";

            textBox11.ForeColor = Color.Black;
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textboxHasText == false)
                textBox2.Text = "";

            textBox2.ForeColor = Color.Black;
        }
        //textbox失去焦点
        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                textBox11.Text = "请输入地理坐标";
                textBox11.ForeColor = Color.LightGray;
                textboxHasText = false;
            }
            else
                textboxHasText = true;
        }
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

        //搜索按钮合法判定//mapwingis
        private void button8_Click(object sender, EventArgs e)
        {

            Form2 f2 = new Form2();
            //this.Close();
            f2.Show();

            if (textBox11.Text == "请输入地理坐标" && comboBox5.Items == null)
            {

                MessageBox.Show("输入坐标或未选择地区", "查询提示");
            }
        }

        //数据库显示
        private void button10_Click(object sender, EventArgs e)
        {
            ///*通过NPOI插件读写excel*/           
            //DataTable dt = new DataTable();//新建表
            //dt = ExcelUtility.ExcelToDataTable(this.openFileDialog1.FileName.Replace("\\", "//"), true);
            //dataGridView1.DataSource = dt;
        }

        private void zoomIn_Click(object sender, EventArgs e)
        {
            // 放大
            axMap2.CursorMode = MapWinGIS.tkCursorMode.cmZoomIn;
        }

        private void zoomOut_Click(object sender, EventArgs e)
        {
            //缩小
            axMap2.CursorMode = MapWinGIS.tkCursorMode.cmZoomOut;
        }

        private void pan_Click(object sender, EventArgs e)
        {
            //漫游
            axMap2.CursorMode = MapWinGIS.tkCursorMode.cmPan;
        }

        private void maxExtents_Click(object sender, EventArgs e)
        {
            //全幅
            axMap2.ZoomToMaxExtents();
        }

        private void Identify_Click(object sender, EventArgs e)
        {
            //识别
            axMap2.CursorMode = MapWinGIS.tkCursorMode.cmIdentify;
            //axMap2.CursorMode = MapWinGIS.tkCursorMode.cmSelection;
            show_table.Text = "高亮！";
        }

        private void zoomTo_Click(object sender, EventArgs e)
        {
            MapWinGIS.Extents myExtents = (Extents)axMap2.Extents;

            //设置经纬度范围(地理坐标系)          
            myExtents.MoveTo(107.40, 33.42);

            //定位该范围
            axMap2.Extents = myExtents;
            axMap2.CurrentScale = 0.025;

            axMap2.CursorMode = MapWinGIS.tkCursorMode.cmIdentify;
        }

        private void map1_Load(object sender, EventArgs e)
        {

        }



        private void button3_Click(object sender, EventArgs e)
        {

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox12.Text = this.openFileDialog1.FileName;
            }
            /*通过NPOI插件读写excel*/
            DataTable dt = new DataTable();//新建表
            //dt = ExcelUtility.ExcelToDataTable(this.openFileDialog1.FileName.Replace("\\", "//"), true);
            dataGridView1.DataSource = dt;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click_1(object sender, EventArgs e)
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
        }

        private void button11_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = FunctionMode.Info;
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
            toolStripStatusLabel1.Text = xpanel + " " + ypanel;
        }

        /* 点击展开lengend */
        private void button16_Click(object sender, EventArgs e)
        {
            if (legend1.Visible == false)
            {
                legend1.Visible = true;
            }
            else
            {
                legend1.Visible = false;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //map1.FunctionMode = FunctionMode.Label;
            map1.FunctionMode = FunctionMode.Select;

        }

        //customLabels.PropertyChanged -= customLabels_PropertyChanged;
        //customLabels.PropertyChanged += customLabels_PropertyChanged;

        /* 点击尾矿库显示尾矿库基本信息 */

        private void map1_SelectionChanged(object sender, EventArgs e)
        {
            if (map1.FunctionMode == FunctionMode.Select)
            {
                //遍历要素
                PointLayer pLayer = map1.Layers[map1.Layers.Count - 1] as PointLayer;
                //if (pLayer.Selection.Count == 0  )
                //if (pLayer.Selection.ToFeatureList().Count == 0)
                //{
                //    MessageBox.Show("无选中记录", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //   int a = pLayer.Selection.ToFeatureList().Count;

                //    return;
                //}
                //else{
                foreach (Feature feature in pLayer.Selection.ToFeatureList())
                {
                    if (pLayer.Selection.ToFeatureList().Count == 0)
                    {
                        MessageBox.Show("无选中元素", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (pLayer.Selection.ToFeatureList().Count > 1)
                    {
                        if (mysql_Helper.num ==0 ) {
                            
                            mysql_Helper.num++;
                        } else if (mysql_Helper.num == 1)
                        {
                            MessageBox.Show("选择超过一个元素", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            mysql_Helper.num = 0;
                        }
                        return;
                    }
                    else if (pLayer.Selection.ToFeatureList().Count == 1)
                    {
                        //MessageBox.Show((string)feature.DataRow["尾矿库"]);
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
                                if (mysql_Helper.num ==2 ) {
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
            
            //customLabels.PropertyChanged -= customLabels_PropertyChanged;
            //map1.SelectionChanged -= map1_SelectionChanged;
            //map1.SelectionChanged += map1_SelectionChanged;
        }


        // Handles ShapeHighlighted event and shows attributes of the selected shape in the label
        private void axMap2_ShapeHighlighted(object sender, AxMapWinGIS._DMapEvents_ShapeHighlightedEvent e)
        {
            MapWinGIS.Shapefile sf = axMap2.get_Shapefile(e.layerHandle);
            if (sf != null)
            {
                //MessageBox.Show("sf != null");
                string s = "";
                for (int i = 0; i < sf.NumFields; i++)
                {
                    string val = sf.get_CellValue(i, e.shapeIndex).ToString();
                    if (val == "") val = "null";
                    s += sf.Table.Field[i].Name + ":" + val + "; ";
                }
                show_table.Text = s;

            }
        }


        // private float X;//当前窗体的宽度
        // private float Y;//当前窗体的高度
        private void Form1_Load(object sender, EventArgs e)
        {
            //     {
            //         X = this.Width;//获取窗体的宽度
            //         Y = this.Height;//获取窗体的高度
            //         setTag(this);//调用方法
            //     }
        }

        // /// 将控件的宽，高，左边距，顶边距和字体大小暂存到tag属性中
        // private void setTag(Control cons)
        // {
        //     foreach (Control con in cons.Controls)
        //     {
        //         con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
        //         if (con.Controls.Count > 0)
        //             setTag(con);
        //     }
        // }

        // //根据窗体大小调整控件大小
        //private void setControls(float newx, float newy, Control cons)
        // {
        //     //遍历窗体中的控件，重新设置控件的值
        //     foreach (Control con in cons.Controls)
        //     {               
        //         string[] mytag = con.Tag.ToString().Split(new char[] { ':' });//获取控件的Tag属性值，并分割后存储字符串数组
        //         float a = System.Convert.ToSingle(mytag[0]) * newx;//根据窗体缩放比例确定控件的值，宽度
        //         con.Width = (int)a;//宽度
        //         a = System.Convert.ToSingle(mytag[1]) * newy;//高度
        //         con.Height = (int)(a);
        //         a = System.Convert.ToSingle(mytag[2]) * newx;//左边距离
        //         con.Left = (int)(a);
        //         a = System.Convert.ToSingle(mytag[3]) * newy;//上边缘距离
        //         con.Top = (int)(a);
        //         Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
        //         con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
        //         if (con.Controls.Count > 0)
        //         {
        //             setControls(newx, newy, con);
        //         }
        //     }
        // }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //     float newx = (this.Width) / X; //窗体宽度缩放比例
            //     float newy = (this.Height) / Y;//窗体高度缩放比例
            //     setControls(newx, newy, this);//随窗体改变控件大小
        }

        /* 结果直接查询 */
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
                    cmd.CommandText = "SELECT * FROM tailings.test where name ='" + textBox2.Text + "'";
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    System.Data.DataSet ds = new System.Data.DataSet();
                    adap.Fill(ds);
                    dataGridView2.DataSource = mysql_Helper.ds.Tables[0].DefaultView;
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

        /* 选择指标查询 */
        private void button1_Click(object sender, EventArgs e)
        {
            string h_level;
            string s_level;
            string r_level;
            if (comboBox1.Text == "环境危害性(H)" || comboBox3.Text == "周边环境敏感性(S)" || comboBox2.Text == "控制机制可靠性(R)")
            {
                MessageBox.Show("请选择各项指标"); ;
            }
            else
            {
                if (comboBox1.Text == "不列入筛选条件")
                {
                    h_level = "";
                }
                else
                {
                    h_level = comboBox1.Text;
                }
                if (comboBox3.Text == "不列入筛选条件")
                {
                    s_level = "";
                }
                else
                {
                    s_level = comboBox3.Text;
                }
                if (comboBox2.Text == "不列入筛选条件")
                {
                    r_level = "";
                }
                else
                {
                    r_level = comboBox2.Text;
                }
                MySqlConnection con = new MySqlConnection(mysql_Helper.mysql_con);
                MySqlCommand cmd = con.CreateCommand();
                con.Open();
                try
                {
                    //多条件查询
                    string Sersql = "SELECT * FROM tailings.test where h_level='" + h_level + "'";
                    Sersql += "and s_level='" + s_level + "'";
                    Sersql += "and r_level='" + r_level + "'";
                    cmd.CommandText = Sersql;
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    System.Data.DataSet ds = new System.Data.DataSet();
                    adap.Fill(ds); 
                    dataGridView2.DataSource = ds.Tables[0].DefaultView;
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
                    cmd.CommandText = "SELECT * FROM tailings.test where level ='" + level + "'";
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    System.Data.DataSet ds = new System.Data.DataSet();
                    adap.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0].DefaultView;
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

        /* 增加 */
        private void button10_Click_1(object sender, EventArgs e)
        {
            add addData = new add();
            addData.ShowDialog();
        }

        /* 修改 */
        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)//判断是否选中某行
            {
                MessageBox.Show("请选中需要修改的信息");
            }
            else if (dataGridView2.SelectedRows.Count > 1)
            {
                MessageBox.Show("请选中一行信息");
            }
            else if (dataGridView2.SelectedRows.Count == 1)
            {
                int a = dataGridView2.CurrentRow.Index;
                string id = dataGridView2.Rows[a].Cells[0].Value.ToString();
                string name = (string)dataGridView2.Rows[a].Cells[1].Value;
                string type = (string)dataGridView2.Rows[a].Cells[2].Value;
                string city = (string)dataGridView2.Rows[a].Cells[3].Value;
                string region = (string)dataGridView2.Rows[a].Cells[4].Value;
                string level = (string)dataGridView2.Rows[a].Cells[5].Value;
                string h_grade = (string)dataGridView2.Rows[a].Cells[6].Value;
                string h_level = (string)dataGridView2.Rows[a].Cells[7].Value;
                string s_grade = (string)dataGridView2.Rows[a].Cells[8].Value;
                string s_level = (string)dataGridView2.Rows[a].Cells[9].Value;
                string r_grade = (string)dataGridView2.Rows[a].Cells[10].Value;
                string r_level = (string)dataGridView2.Rows[a].Cells[11].Value;
                string situation = (string)dataGridView2.Rows[a].Cells[12].Value;
                edit editData = new edit(id, name, type, city, region, level,
                 h_grade, h_level, s_grade, s_level, r_grade, r_level, situation);
                editData.ShowDialog();
            }
        }

        /* 删除 */
        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)//判断是否选中某行
            {
                MessageBox.Show("请选中需要修改的信息");
            }
            else if (dataGridView2.SelectedRows.Count > 1)
            {
                MessageBox.Show("请选中一行信息");
            }
            else if (dataGridView2.SelectedRows.Count == 1)
            {

                int a = dataGridView2.CurrentRow.Index;
                DataGridViewRow dgr = dataGridView2.SelectedRows[0];
                string id = dataGridView2.Rows[a].Cells[0].Value.ToString();

                MySqlConnection con = new MySqlConnection(mysql_Helper.mysql_con);
                MySqlCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "DELETE from test1 where id_risk=" + id;
                if (cmd.ExecuteNonQuery() > 0)
                    dataGridView2.Rows.Remove(dgr);//如果成功从数据中删除了记录，则从列表中同步删除。
                else
                    MessageBox.Show(string.Format("从数据库中删除id为{0}的记录失败", dgr.Cells[0].Value.ToString()));
                con.Close();
            }
        }

        /* 刷新 */
        private void button2_Click(object sender, EventArgs e)
        {

            //对数据库查询
            MySqlConnection con = new MySqlConnection(mysql_Helper.mysql_con);
            MySqlCommand cmd = con.CreateCommand();
            con.Open();
            try
            {
                cmd.CommandText = "SELECT * FROM tailings.test1";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                adap.Fill(mysql_Helper.ds );
                dataGridView2.DataSource = mysql_Helper.ds.Tables[0].DefaultView;
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

        /* 数据库操作 方法 */
        /// MySQL open
        public string MySQL_Open(string link)
        {
            try
            {
                mysql_Helper.MySQL_con = new MySqlConnection(link);
                mysql_Helper.MySQL_con.Open();
                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// MySQL close
        public string MySQL_Close()
        {
            try
            {
                if (mysql_Helper.MySQL_con == null)
                {
                    return "No database connection";
                }
                if (mysql_Helper.MySQL_con.State == ConnectionState.Open || mysql_Helper.MySQL_con.State == ConnectionState.Connecting)
                {
                    mysql_Helper.MySQL_con.Close();
                    mysql_Helper.MySQL_con.Dispose();
                }
                else
                {
                    if (mysql_Helper.MySQL_con.State == ConnectionState.Closed)
                    {
                        return "success";
                    }
                    if (mysql_Helper.MySQL_con.State == ConnectionState.Broken)
                    {
                        return "ConnectionState:Broken";
                    }
                }
                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// MySQL select 返回dataSet
        public System.Data.DataSet MySQL_Select(string sql, string link, out string record)
        {
            try
            {
                //储存数据的工具初始化
                System.Data.DataSet ds = new System.Data.DataSet();
                //相当于链接数据库的一个工具类（连接字符串）
                using (MySqlConnection con = new MySqlConnection(link))
                {
                    con.Open(); //打开
                    //用SqlConnection工具链接数据库，在通过sql查询语句查询结果现存入sql适配器
                    MySqlDataAdapter sda = new MySqlDataAdapter(sql, con); //(查询语句和连接工具)
                    sda.Fill(ds); //将适配器数据存入DataSet工具中
                    con.Close(); //用完关闭SqlConnection工具
                    sda.Dispose(); //手动释放SqlDataAdapter
                    record = "success";
                    return ds;
                }
            }
            catch (Exception ex)
            {
                System.Data.DataSet dataSet = new System.Data.DataSet();
                record = ex.Message.ToString();
                return dataSet;
            }
        }

        /// MySQL insert,delete,update
        public static string MySQL_Insdelupd(string sql, string link)
        {
            try
            {
                int num = 0;
                using (MySqlConnection con = new MySqlConnection(link))
                {
                    con.Open();
                    //操作数据库的工具SqlCommand
                    MySqlCommand cmd = new MySqlCommand(sql, con); //(操作语句和链接工具)
                    num = cmd.ExecuteNonQuery(); //执行操作返回影响行数
                    con.Close();
                    return "success" + num;
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        /* 闭库的尾矿库显示为灰色 设置dataGridView2标题 */
        private void dataGridView2_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

            if (e.RowIndex >= dataGridView2.Rows.Count - 1)
                return;
            DataGridViewRow dgr = dataGridView2.Rows[e.RowIndex];
            try
            {
                //dgr.Cells[]是当前状态列的索引值，用以确定判断哪一列的值
                if (dgr.Cells[12].Value.ToString() == "闭库")
                {
                    //定义画笔，使用颜色是深灰。
                    using (SolidBrush brush = new SolidBrush(Color.Gray))
                    {
                        //利用画笔填充当前行
                        e.Graphics.FillRectangle(brush, e.RowBounds);
                        //将值重新写回当前行。
                        e.PaintCellsContent(e.ClipBounds);
                        e.Handled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dataGridView2.Columns[0].HeaderCell.Value = "尾矿库编码";
            dataGridView2.Columns[1].HeaderCell.Value = "尾矿库名称";
            dataGridView2.Columns[2].HeaderCell.Value = "矿种";
            dataGridView2.Columns[3].HeaderCell.Value = "地市";
            dataGridView2.Columns[4].HeaderCell.Value = "县(区、市)";
            dataGridView2.Columns[5].HeaderCell.Value = "风险等级";
            dataGridView2.Columns[6].HeaderCell.Value = "环境危害性(H)_分值";
            dataGridView2.Columns[7].HeaderCell.Value = "环境危害性(H)_等级";
            dataGridView2.Columns[8].HeaderCell.Value = "周边环境敏感性(S)_分值";
            dataGridView2.Columns[9].HeaderCell.Value = "周边环境敏感性(S)_等级";
            dataGridView2.Columns[10].HeaderCell.Value = "控制机制可靠性(R)_分值";
            dataGridView2.Columns[11].HeaderCell.Value = "控制机制可靠性(R)_等级";
            dataGridView2.Columns[12].HeaderCell.Value = "运行情况";
        }

        /* 导出文件为excel */
        private void button20_Click(object sender, EventArgs e)
        {
            if (mysql_Helper.ds.Tables.Count != 0)
            {
                //打开文件对话框
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = "保存文件";
                saveFileDialog1.Filter = "Excel 文件(*.xls)|*.xls|Excel 文件(*.xlsx)|*.xlsx|所有文件(*.*)|*.*";
                saveFileDialog1.FileName = "尾矿库风险分级.xls"; //设置默认另存为的名字
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string txtPath = saveFileDialog1.FileName;
                    //string sql = "select Sanname as 姓名,Sanphone as 电话,SanRoomType as 房间类型,SanRoomID as 房间号码,SanRuTime as 入住时间,SanLiTime as 离店时间,SanMoney as 房费,SanYaJin as 押金,SanZFway as 支付方式 from San_Checkin";
                    //DataTable dt = DBHelper.GetDataTable(sql);
                    //ExcelUtility.DataTableToExcel(mysql_Helper.ds.Tables[0], txtPath);
                }
            }
            else {
                MessageBox.Show("请先刷新表格再进行保存");
            }
        }

        /* 输入sql语句查询 */
        private void button21_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text == "")
            //{
            //    MessageBox.Show("请输入合法SQL语句");
            //}
            //else
            //{
            //    //对数据库查询
            //    MySqlConnection con = new MySqlConnection(mysql_Helper.mysql_con);
            //    MySqlCommand cmd = con.CreateCommand();
            //    con.Open();
            //    try
            //    {
            //        cmd.CommandText = textBox1.Text;
            //        MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            //        System.Data.DataSet ds = new System.Data.DataSet();
            //        adap.Fill(ds);
            //        dataGridView2.DataSource = mysql_Helper.ds.Tables[0].DefaultView;
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show(textBox1.Text);
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
        }

        /* 调节窗体大小 */
        private void Form1_Resize(object sender, EventArgs e)
        {
           // this.Width = this.Height * 1200/670;
        }
    }
}
