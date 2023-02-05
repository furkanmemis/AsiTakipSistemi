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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AsiTakipSistemi
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=FURKAN;Initial Catalog=AsiTakipSistemi;Integrated Security=True");

        private void Form5_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToShortDateString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            string ad = textBox1.Text;
            string tur = textBox2.Text;
            if(ad == "" || tur == "" || textBox3.Text == "")
            {
                MessageBox.Show("Eksik bilgiler var!!");
            }
            else { 

                decimal doz = Convert.ToDecimal(textBox3.Text);
                baglanti.Open();

                SqlCommand komut = new SqlCommand("insert into Asi(AsiDoz,HastalikTuru,AsiAdi) values(@p1,@p2,@p3)", baglanti);
                komut.Parameters.AddWithValue("@p1", doz);
                komut.Parameters.AddWithValue("@p2", tur);
                komut.Parameters.AddWithValue("@p3", ad);
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Yeni aşı eklendi!!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";




            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ad = textBox4.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Asi where AsiAdi ='" + ad + "'", baglanti);
            SqlDataAdapter adptr = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Close();
            textBox4.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tur = textBox4.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Asi where HastalikTuru ='" + tur + "'", baglanti);
            SqlDataAdapter adptr = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Close();
            textBox4.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
        }
    }
}
