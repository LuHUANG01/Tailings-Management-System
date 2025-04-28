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
    public partial class dataBaseForm2 : Form
    {
        public dataBaseForm2()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {


            //对数据库查询
            MySqlConnection con = new MySqlConnection(mysql_Helper.mysql_con);
            MySqlCommand cmd = con.CreateCommand();
            con.Open();
            try
            {
                cmd.CommandText = "SELECT * FROM tailings.datamysql";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
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
}
