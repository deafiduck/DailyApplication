using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDaily
{
    public partial class DersDüzenle : Form
    {
        string connectionString = "Data Source=DESKTOP-N5A035R;Initial Catalog=Daily;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public class DersBilgisi
        {
            public string DersKodu;
            public int AKTS;
            public int Kredi;
        }
        public DersDüzenle()
        {
            InitializeComponent();
        }

       
           
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // listBox1 seçim değiştikçe checkedListBox1'i temizle
           
            // checkedListBox1.Items.Clear();

            SqlConnection baglanti = new SqlConnection(connectionString);
            baglanti.Open();

            string sql = "SELECT DersAdi, DersKodu, AKTS, Kredi FROM Dersler WHERE Donem=@Donem";
            SqlParameter prm1 = new SqlParameter("Donem", numericUpDown1.Text);

            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.Add(prm1);

            Dictionary<string, DersBilgisi> dersBilgileri = new Dictionary<string, DersBilgisi>();

            using (SqlDataReader reader = komut.ExecuteReader())
            {
                while (reader.Read())
                {

                    string dersAdi = reader["DersAdi"].ToString();
                    string dersKodu = reader["DersKodu"].ToString();
                    int akts = Convert.ToInt32(reader["AKTS"]);
                    int kredi = Convert.ToInt32(reader["Kredi"]);

                    checkedListBox1.ClearSelected();
                    DersBilgisi bilgi = new DersBilgisi { DersKodu = dersKodu, AKTS = akts, Kredi = kredi };
                    dersBilgileri[dersAdi] = bilgi;
                }
            }

            foreach (var kvp in dersBilgileri)
            {
                string dersBilgi = $"{kvp.Key} - Ders Kodu: {kvp.Value.DersKodu} - AKTS: {kvp.Value.AKTS} - Kredi: {kvp.Value.Kredi}";
                checkedListBox1.Items.Add(dersBilgi);

                // Şu an seçili öğeyi kontrol ediyoruz
                if (checkedListBox1.GetItemChecked(checkedListBox1.Items.IndexOf(dersBilgi)))
                {
                    string sorgu = "INSERT INTO Transkript (Ders, Not_, Kullanici) VALUES (@ders, @not, @Kullanici)";

                    using (SqlCommand komut2 = new SqlCommand(sorgu, baglanti))
                    {
                        komut2.Parameters.AddWithValue("@ders", kvp.Key);
                        //komut2.Parameters.AddWithValue("@not", 0); // Not değerini doldurmanız gerekiyor
                        komut2.Parameters.AddWithValue("@Kullanici", "KullaniciAdi"); // Kullanıcı adını doldurmanız gerekiyor

                        komut2.ExecuteNonQuery(); // Veritabanına ekleme işlemini gerçekleştir
                    }
                }
            }




            baglanti.Close();
        }
    }
}
