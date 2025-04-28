using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static testMWG9_4.Form1;

namespace testMWG9_4
{
    public partial class showLevel : Form
    {
        public showLevel()
        {
            InitializeComponent();
            
        }

        /* 参数传递 重构窗体*/

        //构造函数接收三个参数：选中行文本，ListBox控件，选中行索引
        public showLevel(string id,string name, string type, string city, string region, string level,
            string h_grade, string h_level, string s_grade, string s_level, string r_grade, string r_level,string situation)
        {
            InitializeComponent();

            listView1.GridLines = true;//表格是否显示网格线
            listView1.View  = View.Details;//设置显示方式
            listView1.Scrollable = true;//是否自动显示滚动条

            //添加表头（列）
            listView1.Columns.Add("Field Name", "Field Name");
            listView1.Columns.Add("Value", "Value");

            //添加表格内容
            ListViewItem item1 = new ListViewItem();
            ListViewItem item2 = new ListViewItem();
            ListViewItem item3 = new ListViewItem();
            ListViewItem item4 = new ListViewItem();
            ListViewItem item5 = new ListViewItem();
            ListViewItem item6 = new ListViewItem();
            ListViewItem item7 = new ListViewItem();
            ListViewItem item8 = new ListViewItem();
            ListViewItem item9 = new ListViewItem();
            ListViewItem item10 = new ListViewItem();
            ListViewItem item11 = new ListViewItem();
            ListViewItem item12 = new ListViewItem();
            ListViewItem item13 = new ListViewItem();

            item1.SubItems[0].Text = "尾矿库编码";
            item1.SubItems.Add(id);
            item2.SubItems[0].Text = "尾矿库名称";
            item2.SubItems.Add(name);
            item3.SubItems[0].Text = "矿种";
            item3.SubItems.Add(type);
            item4.SubItems[0].Text = "地市";
            item4.SubItems.Add(city);
            item5.SubItems[0].Text = "县(区、市)";
            item5.SubItems.Add(region);
            item6.SubItems[0].Text = "风险等级";
            item6.SubItems.Add(level);
            item7.SubItems[0].Text = "环境危害性(H)_分值";
            item7.SubItems.Add(h_grade);
            item8.SubItems[0].Text = "环境危害性(H)_等级";
            item8.SubItems.Add(h_level);
            item9.SubItems[0].Text = "周边环境敏感性(S)_分值";
            item9.SubItems.Add(s_grade);
            item10.SubItems[0].Text = "周边环境敏感性(S)_等级";
            item10.SubItems.Add(s_level);
            item11.SubItems[0].Text = "控制机制可靠性(R)_分值";
            item11.SubItems.Add(r_grade);
            item12.SubItems[0].Text = "控制机制可靠性(R)_等级";
            item12.SubItems.Add(r_level);
            item13.SubItems[0].Text = "运行情况";
            item13.SubItems.Add(situation);

            listView1.Items.Add(item1);
            listView1.Items.Add(item2);
            listView1.Items.Add(item3);
            listView1.Items.Add(item4);
            listView1.Items.Add(item5);
            listView1.Items.Add(item6);
            listView1.Items.Add(item7);
            listView1.Items.Add(item8);
            listView1.Items.Add(item9);
            listView1.Items.Add(item10);
            listView1.Items.Add(item11);
            listView1.Items.Add(item12);
            listView1.Items.Add(item13);

            listView1.Columns["Field Name"].Width = -1;//根据内容设置宽度
            listView1.Columns["Value"].Width = -1;//根据内容设置宽度

            mysql_Helper.num = 0;
        }
    }
}
