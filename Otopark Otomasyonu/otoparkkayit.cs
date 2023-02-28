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

namespace Otopark_Otomasyonu
{
    public partial class otoparkkayit : Form
    {
        public otoparkkayit()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FS52QEK;Initial Catalog=otopark;Integrated Security=True");
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void otoparkkayit_Load(object sender, EventArgs e)
        {
            Bosarac();
            Markaekle();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select marka,seri from seribilgi", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboseri.Items.Add(read["seri"].ToString());
            }
            baglanti.Close();
        }

        private void Markaekle()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select marka from markabilgi", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combomarka.Items.Add(read["marka"].ToString());
            }
            baglanti.Close();
        }

        private void Bosarac()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from aracdurum WHERE durum = 'BOŞ'",baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboparkyeri.Items.Add(read["parkyeri"].ToString());
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into musteri(tc,ad,soyad,tel,email,Plaka,marka,seri,renk,parkyeri,tarih) values(@tc,@ad,@soyad,@tel,@email,@Plaka,@marka,@seri,@renk,@parkyeri,@tarih)", baglanti);
            komut.Parameters.Add("@tc", txttc.Text);
            komut.Parameters.Add("@ad", txtad.Text);
            komut.Parameters.Add("@soyad", txtsoyad.Text);
            komut.Parameters.Add("@tel", txttel.Text);
            komut.Parameters.Add("@email", txtmail.Text);
            komut.Parameters.Add("@Plaka", txtplaka.Text);
            komut.Parameters.Add("@marka", combomarka.Text);
            komut.Parameters.Add("@seri", comboseri.Text);
            komut.Parameters.Add("@renk", txtrenk.Text);
            komut.Parameters.Add("@parkyeri", comboparkyeri.Text);
            komut.Parameters.Add("@tarih", DateTime.Now.ToString());
            komut.ExecuteNonQuery();
            SqlCommand komut2 = new SqlCommand("update aracdurum set durum = 'DOLU' WHERE parkyeri ='" + comboparkyeri.SelectedItem + "'", baglanti);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Araç Kaydı Oluşturuldu");
            comboparkyeri.Items.Clear();
            Bosarac();
            combomarka.Items.Clear();
            Markaekle();
           

            foreach (Control item in grupkişi.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in gruparaç.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in gruparaç.Controls)
            {
                if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }

        private void buttonmarka_Click(object sender, EventArgs e)
        {
            frmmarka marka = new frmmarka();
            marka.ShowDialog();
        }

        private void buttonseri_Click(object sender, EventArgs e)
        {
            frmseri seri = new frmseri();
            seri.ShowDialog();
        }

        private void combomarka_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void comboseri_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
