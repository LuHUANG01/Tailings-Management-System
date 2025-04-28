using MySql.Data.MySqlClient;
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
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }

        /* 地市和县的二级联动 */
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
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

        /* 添加 */
        private void button1_Click(object sender, EventArgs e)
        {
            string level1;
            string h_level1;
            string s_level1;
            string r_level1;

            MySqlConnection add_sql = new MySqlConnection(mysql_Helper.mysql_con);
            //启动
            add_sql.Open();

            string Sersql = "SELECT * FROM tailings.test1 where id_risk='" + id.Text + "'";
            Sersql += "or name='" + name.Text + "'";

            MySqlCommand comd = new MySqlCommand(Sersql, add_sql);

            if (level.Text == "选择环境风险等级" || level.Text == "暂无数据")
            {
                level1 = "";
            }
            else
            {
                level1 = level.Text;
            }

            if (h_level.Text == "环境危害性(H)" || h_level.Text == "暂无数据")
            {
                h_level1 = "";
            }
            else
            {
                h_level1 = h_level.Text;
            }
            if (s_level.Text == "周边环境敏感性(S)" || s_level.Text == "暂无数据")
            {
                s_level1 = "";
            }
            else
            {
                s_level1 = s_level.Text;
            }
            if (r_level.Text == "控制机制可靠性(R)" || r_level.Text == "暂无数据")
            {
                r_level1 = "";
            }
            else
            {
                r_level1 = r_level.Text;
            }

            //强制转换int 判定编号和名称是否不存在
            if (comd.ExecuteScalar() != null)
            {
                MessageBox.Show("数据已存在,请确认编号和名称的唯一性");
                Sersql.Clone();
            } else if (city.Text =="选择" || region .Text == "选择" || id.Text =="" ||name .Text =="") {
                MessageBox.Show("带*为必填项");
            }
            else
            {
                string Sqlctr = "insert into test1(id_risk,name,type,city,region,level,h_grade,h_level,s_grade,s_level,r_grade,r_level,situation) " +
                    "values(" + "'" + Convert.ToInt32(id.Text) + "'," + "'" + name.Text + "'," + "'" + type.Text + "'," + "'" + city.Text + "'," + "'" + region.Text + "'" + "," + "'" + level1 + "'" + "," + "'" + h_grade.Text + "'" + "," + "'" + h_level1 + "'" + "," + "'" + s_grade.Text + "'" + "," + "'" + s_level1 + "'" + "," + "'" + r_grade.Text + "'" + "," + "'" + r_level1 + "'" + "," + "'" + situation.Text + "'" + ")";

                MySqlCommand com = new MySqlCommand(Sqlctr, add_sql);
                com.ExecuteNonQuery();
                MessageBox.Show("插入成功");
                Sqlctr.Clone();
                this.Dispose();//关闭当前窗口

            }
        }
    }
}
