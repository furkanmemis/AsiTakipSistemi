using DevExpress.XtraBars.ViewInfo;
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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=FURKAN;Initial Catalog=AsiTakipSistemi;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = DateTime.Now.ToShortDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string email = textBox2.Text;
            string adres = textBox3.Text;
            string telefon = textBox4.Text;

            if(ad == "" || telefon == "" || email == "" || adres == "")
            {
                MessageBox.Show("Eksik bilgiler var!!");
            }
            else
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Saglayici(Ad,Email,Adres,TelefonNo) values(@p1,@p2,@p3,@p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", ad);
                komut.Parameters.AddWithValue("@p2", email);
                komut.Parameters.AddWithValue("@p3", adres);
                komut.Parameters.AddWithValue("@p4", telefon);

                komut.ExecuteNonQuery();

                MessageBox.Show("Yeni tedarikçi eklendi!!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                baglanti.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string ad = textBox5.Text;
            SqlCommand komut = new SqlCommand("select * from Saglayici where Ad ='" + ad + "'", baglanti);
            SqlDataAdapter adptr = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Saglayici",baglanti);
            SqlDataAdapter adptr = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string ad = textBox6.Text;

            SqlCommand komut = new SqlCommand("select Ad,Saglayici.SaglayiciID,Asi.HastalikTuru,Asi.AsiAdi,Tarih from TedarikEder inner join Asi on TedarikEder.AsiID = Asi.AsiId inner join Saglayici on TedarikEder.SaglayiciID = Saglayici.SaglayiciID where Ad = '"+ad+"'",baglanti);
            SqlDataAdapter adptr = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView2.DataSource = dt;

            baglanti.Close();
            textBox6.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string tur = textBox6.Text;

            SqlCommand komut = new SqlCommand("select Ad,Saglayici.SaglayiciID,Asi.HastalikTuru,Asi.AsiAdi,Tarih from TedarikEder inner join Asi on TedarikEder.AsiID = Asi.AsiId inner join Saglayici on TedarikEder.SaglayiciID = Saglayici.SaglayiciID where HastalikTuru = '" + tur + "'", baglanti);
            SqlDataAdapter adptr = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView2.DataSource = dt;

            baglanti.Close();
            textBox6.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string marka = textBox6.Text;

            SqlCommand komut = new SqlCommand("select Ad,Saglayici.SaglayiciID,Asi.HastalikTuru,Asi.AsiAdi,Tarih from TedarikEder inner join Asi on TedarikEder.AsiID = Asi.AsiId inner join Saglayici on TedarikEder.SaglayiciID = Saglayici.SaglayiciID where AsiAdi = '" + marka + "'", baglanti);
            SqlDataAdapter adptr = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView2.DataSource = dt;

            baglanti.Close();
            textBox6.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select Ad,Saglayici.SaglayiciID,Asi.HastalikTuru,Asi.AsiAdi,Tarih from TedarikEder inner join Asi on TedarikEder.AsiID = Asi.AsiId inner join Saglayici on TedarikEder.SaglayiciID = Saglayici.SaglayiciID", baglanti);
            SqlDataAdapter adptr = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            adptr.Fill(dt);
            dataGridView2.DataSource = dt;

            baglanti.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.Show();
        }
    }
}
