using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsiTakipSistemi
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=FURKAN;Initial Catalog=AsiTakipSistemi;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToShortDateString();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Hemsire",baglanti);

            SqlDataAdapter adptr = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlCommand komut1 = new SqlCommand("select * from Asi",baglanti);

            SqlDataAdapter adptr1 = new SqlDataAdapter(komut1);

            DataTable dt1 = new DataTable();
            adptr1.Fill(dt1);
            dataGridView2.DataSource = dt1;

            baglanti.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string tc = textBox1.Text;
            int asi_id = Convert.ToInt32(textBox2.Text);

            if(tc == "" || textBox2.Text == "")
            {
                MessageBox.Show("Eksik bilgiler var!!");
            }
            else
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand("insert into AsiYapar(AsiID,HemsireTC) values(@p1,@p2)", baglanti);

                komut.Parameters.AddWithValue("@p1",asi_id);
                komut.Parameters.AddWithValue("@p2", tc);

                komut.ExecuteNonQuery();

                MessageBox.Show("Atama gerçekleşti!!");
                textBox1.Text = "";
                textBox2.Text = "";
                baglanti.Close();
            }
            

        }
    }
}
