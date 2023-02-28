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
    public partial class aracsil : Form
    {
        public aracsil()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FS52QEK;Initial Catalog=otopark;Integrated Security=True");
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void aracsil_Load(object sender, EventArgs e)
        {
            Doluyerler();
            plakalar();
            timer1.Enabled = true;
        }

        private void plakalar()
        {
            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from musteri", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboPlaka.Items.Add(read["Plaka"].ToString());
            }
            baglanti.Close();
        }

        private void Doluyerler()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from aracdurum where durum='DOLU'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboParkYeri.Items.Add(read["parkyeri"].ToString());
            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from musteri where Plaka='" + comboPlaka.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtParkYeri.Text = read["parkyeri"].ToString();
            }
            baglanti.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from musteri where parkyeri='" + comboParkYeri.SelectedItem+ "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtParkYeri2.Text = read["parkyeri"].ToString();
                txtTc.Text = read["tc"].ToString();
                txtAd.Text = read["ad"].ToString();
                txtSoyad.Text = read["soyad"].ToString();
                txtMarka.Text = read["marka"].ToString();
                txtSeri.Text = read["seri"].ToString();
                txtPlaka.Text = read["Plaka"].ToString();
                lblGelişTarihi.Text = read["tarih"].ToString();
            }
            baglanti.Close();
            DateTime  geliş, çıkış;
            geliş = DateTime.Parse(lblGelişTarihi.Text);
            çıkış = DateTime.Parse(lblÇıkışTarihi.Text);
            TimeSpan fark;
            fark = çıkış - geliş;
            lblSüre.Text = fark.TotalHours.ToString("0.00");
            lblToplamTutar.Text = (double.Parse(lblSüre.Text) * (2.5)).ToString("0.00");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblÇıkışTarihi.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from musteri where Plaka='" + txtPlaka.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            SqlCommand komut3 = new SqlCommand("insert into satis(parkyeri,Plaka,geliş_tarihi,çıkış_tarihi,süre,tutar) values(@parkyeri,@Plaka,@geliş_tarihi,@çıkış_tarihi,@süre,@tutar) ", baglanti);
            komut3.Parameters.AddWithValue("@parkyeri", txtParkYeri2.Text);
            komut3.Parameters.AddWithValue("@Plaka", txtPlaka.Text);
            komut3.Parameters.AddWithValue("@geliş_tarihi", lblGelişTarihi.Text);
            komut3.Parameters.AddWithValue("@çıkış_tarihi", lblÇıkışTarihi.Text);
            komut3.Parameters.AddWithValue("@süre", double.Parse(lblSüre.Text));
            komut3.Parameters.AddWithValue("@tutar", double.Parse(lblToplamTutar.Text));
            komut3.ExecuteNonQuery();

            SqlCommand komut2 = new SqlCommand("update aracdurum set durum='BOŞ' where parkyeri='" + txtParkYeri2.Text + "'", baglanti);
            komut2.ExecuteNonQuery();



            baglanti.Close();
            MessageBox.Show("Araç çıkışı yapıldı");

            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                    txtParkYeri.Text = "";
                    comboParkYeri.Text = "";
                    comboPlaka.Text = "";
                }
            }

            comboPlaka.Items.Clear();
            comboParkYeri.Items.Clear();
            Doluyerler();
            plakalar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
