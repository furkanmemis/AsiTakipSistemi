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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=FURKAN;Initial Catalog=AsiTakipSistemi;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToShortDateString();

            baglanti.Open();

            SqlCommand komut = new SqlCommand("select * from Hasta",baglanti);
            SqlDataAdapter adptr = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlCommand komut1 = new SqlCommand("select * from Hemsire", baglanti);
            SqlDataAdapter adptr1 = new SqlDataAdapter(komut1);

            DataTable dt1 = new DataTable();
            adptr1.Fill(dt1);
            dataGridView2.DataSource = dt1;

            SqlCommand komut2 = new SqlCommand("select * from Asi", baglanti);
            SqlDataAdapter adptr2 = new SqlDataAdapter(komut2);

            DataTable dt2 = new DataTable();
            adptr2.Fill(dt2);
            dataGridView3.DataSource = dt2;


            baglanti.Close();





        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string hasta_tc = textBox1.Text;
            string hemsire_tc = textBox2.Text;
            int asi_id = Convert.ToInt32(textBox3.Text);
            string tarih = textBox4.Text;


            if(hasta_tc == "" || hemsire_tc == "" || textBox3.Text == "" || tarih == "")
            {
                MessageBox.Show("Eksik bilgiler var!!");
            }
            else
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand("insert into Randevu(Tarih,HastaTC,AsiID,HemsireTC) values(@p1,@p2,@p3,@p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", tarih);
                komut.Parameters.AddWithValue("@p2", hasta_tc);
                komut.Parameters.AddWithValue("@p3", asi_id);
                komut.Parameters.AddWithValue("@p4", hemsire_tc);

                komut.ExecuteNonQuery();


                MessageBox.Show("Yeni randevu oluşturuldu");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                    

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form11 f = new Form11();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form12 f = new Form12();
            f.Show();
        }
    }
}
