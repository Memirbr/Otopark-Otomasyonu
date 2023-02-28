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

namespace Otopark_Otomasyonu
{
    public partial class aracyerleri : Form
    {
        public aracyerleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-FS52QEK;Initial Catalog=otopark;Integrated Security=True");
        private void aracyerleri_Load(object sender, EventArgs e)
        {
            Bosparkyerleri();
            Doluarac();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from musteri", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                foreach (Control item in Controls)
                {
                    if (item is Button)
                    {
                        if (item.Text == read["parkyeri"].ToString())
                        {
                            item.Text = read["Plaka"].ToString();
                        }
                    }
                }
            }
            baglanti.Close();

        }

        private void Doluarac()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from aracdurum", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                foreach (Control item in Controls)
                {
                    if (item is Button)
                    {
                        if (item.Text == read["parkyeri"].ToString() && read["durum"].ToString() == "DOLU")
                        {
                            item.BackColor = Color.Red;
                        }
                    }
                }
            }
            baglanti.Close();
        }

        private void Bosparkyerleri()
        {
            int sayac = 1;
            foreach (Control item in Controls)
            {
                if (item is Button)
                {
                    item.Text = "Park Yeri - " + sayac;
                    item.Name = "Park Yeri - " + sayac;
                    sayac++;
                }
            }
        }
    }
}
