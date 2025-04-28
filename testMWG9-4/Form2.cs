using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapWinGIS;
using AxMapWinGIS;
using DotSpatial.Controls;

namespace testMWG9_4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

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

        private void 尾矿库数据管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
