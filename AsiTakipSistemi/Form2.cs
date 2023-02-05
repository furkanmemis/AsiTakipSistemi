using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.Utils;

namespace AsiTakipSistemi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToShortDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=FURKAN;Initial Catalog=AsiTakipSistemi;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            //Data Source=FURKAN;Initial Catalog=AsiTakipSistemi;Integrated Security=True
            string ad = textBox1.Text;
            string soyad = textBox2.Text;
            string tc = textBox3.Text;
            
            if(ad == "" || soyad == "" || tc == "" || textBox4.Text.Length > 1)
            {
                if (textBox4.Text.Length > 1)
                {
                    MessageBox.Show("Cinsiyeti k veya e şeklinde giriniz");
                }
                else
                {
                    MessageBox.Show("Eksik bilgiler tekrar giriniz!!");
                }
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Hasta(TC,Email,Ad,Soyad,DogumTarihi,Cinsiyet,Adres,TelefonNo) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglanti);
                komut.Parameters.AddWithValue("@p1", tc);
                komut.Parameters.AddWithValue("@p2", textBox9.Text);//email
                komut.Parameters.AddWithValue("@p3", ad);
                komut.Parameters.AddWithValue("@p4", soyad);
                komut.Parameters.AddWithValue("@p5", textBox5.Text);
                komut.Parameters.AddWithValue("@p6",textBox4.Text);
                komut.Parameters.AddWithValue("@p7", textBox6.Text);
                komut.Parameters.AddWithValue("@p8", textBox8.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Yeni Kayıt Alındı!!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox9.Text = "";
                textBox8.Text = "";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }
    }
}
