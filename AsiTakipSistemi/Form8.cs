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
using System.Data.SqlClient;

namespace AsiTakipSistemi
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=FURKAN;Initial Catalog=AsiTakipSistemi;Integrated Security=True");

        private void Form8_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToShortDateString();

            baglanti.Open();

            SqlCommand komut = new SqlCommand("select Ad,HastaneID from Hastane", baglanti);
            SqlDataAdapter adptr = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView1.DataSource = dt;


            SqlCommand komut1 = new SqlCommand("select * from Hemsire", baglanti);
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

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string soyad = textBox2.Text;
            string tc = textBox3.Text;
            string telefon = textBox4.Text;
            int hastane_id = Convert.ToInt32(textBox5.Text);

            if(ad == "" || soyad == "" || tc == "" || telefon == "" || textBox5.Text == "")
            {
                MessageBox.Show("Eksik bilgiler var!!");
            }
            else
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand("insert into Hemsire(TC,HastaneID,Ad,Soyad,TelefonNo) values(@p1,@p2,@p3,@p4,@p5)", baglanti);

                komut.Parameters.AddWithValue("@p1", tc);
                komut.Parameters.AddWithValue("@p2", hastane_id);
                komut.Parameters.AddWithValue("@p3", ad);
                komut.Parameters.AddWithValue("@p4", soyad);
                komut.Parameters.AddWithValue("@p5", telefon);

                komut.ExecuteNonQuery();

                MessageBox.Show("Yeni hemşire eklendi");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

                baglanti.Close();


            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tc = textBox6.Text;

            if(tc.Length != 11)
            {
                MessageBox.Show("Hatalı Giriş!!");
            }
            else
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand("select * from Hemsire where TC = '" + tc + "'");
                SqlDataAdapter adptr = new SqlDataAdapter(komut);

                DataTable dt = new DataTable();
                adptr.Fill(dt);
                dataGridView2.DataSource = dt;

                baglanti.Close();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select * from Hemsire", baglanti);
            SqlDataAdapter adptr = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView2.DataSource = dt;

            baglanti.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            f.Show();
        }
    }
}
