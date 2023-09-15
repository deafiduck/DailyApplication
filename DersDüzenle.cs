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
        string Kullanici_;
        public class DersBilgisi
        {
            public string DersKodu;
            public int AKTS;
            public int Kredi;
        }
        public DersDüzenle(string Kullanici_Adi)
        {
            InitializeComponent();
            Kullanici_ = Kullanici_Adi;
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
            /* checkedListBox1.Items.Clear();


             SqlConnection baglanti = new SqlConnection(connectionString);
             baglanti.Open();

             string sql = "SELECT DersAdi, DersKodu, AKTS, Kredi FROM Dersler WHERE Donem=@Donem";
             SqlParameter prm1 = new SqlParameter("Donem", numericUpDown1.Text);
             //seçilen dönemde olan derslerin bilgilerini çeker

             SqlCommand komut = new SqlCommand(sql, baglanti);
             komut.Parameters.Add(prm1);
             //eleştirir

             Dictionary<string, DersBilgisi> dersBilgileri = new Dictionary<string, DersBilgisi>();
             //seçilen dersBilgisi adla structa adama yapılıyor

             using (SqlDataReader reader = komut.ExecuteReader())
             {
                 while (reader.Read())
                 {

                     string dersAdi = reader["DersAdi"].ToString();
                     string dersKodu = reader["DersKodu"].ToString();
                     int akts = Convert.ToInt32(reader["AKTS"]);
                     int kredi = Convert.ToInt32(reader["Kredi"]);

                     //checkedListBox1.ClearSelected();
                     DersBilgisi bilgi = new DersBilgisi { DersKodu = dersKodu, AKTS = akts, Kredi = kredi };
                     dersBilgileri[dersAdi] = bilgi;
                 }
             }

             foreach (var kvp in dersBilgileri)
             {
                 string dersBilgi = $"{kvp.Key} - Ders Kodu: {kvp.Value.DersKodu} - AKTS: {kvp.Value.AKTS} - Kredi: {kvp.Value.Kredi}";
                 checkedListBox1.Items.Add(dersBilgi);
                 void Update()
                 {
                     // Şu an seçili öğeyi kontrol ediyoruz
                     if (checkedListBox1.GetItemChecked(checkedListBox1.Items.IndexOf(dersBilgi)))
                     {
                         string sorgu = "INSERT INTO Transkript (Ders, Not_, Kullanici) VALUES (@ders, @not, @Kullanici)";

                         using (SqlCommand komut2 = new SqlCommand(sorgu, baglanti))
                         {
                             komut2.Parameters.AddWithValue("@ders", kvp.Key);
                             komut2.Parameters.AddWithValue("@not", 0); // Not değerini doldurmanız gerekiyor
                             komut2.Parameters.AddWithValue("@Kullanici", "KullaniciAdi"); // Kullanıcı adını doldurmanız gerekiyor

                             komut2.ExecuteNonQuery(); // Veritabanına ekleme işlemini gerçekleştir
                         }
                     }
                 }
             }




             baglanti.Close();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenu fm = new FrmMenu(Kullanici_);
            fm.Show();
            this.Hide();
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //derslerin bilgileri yazacak
            // Seçilen dönem
            string donemBilgisi = numericUpDown2.Value.ToString();


            // Veritabanı bağlantısı
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();
                AnaMenu aa = new AnaMenu();
                foreach (string secilenDers in checkedListBox2.CheckedItems)
                {
                    string[] parcalar = secilenDers.Split('-');
                    string DersAdi = parcalar[0].Trim();
                    string KullaniciAdi = aa.kullanici; // Burada kullanıcı adını AnaMenude aldığım veri yaptım

                    // Dersin zaten eklenip eklenmediğini kontrol etmek için bir sorgu
                    string sql2 = "INSERT INTO Transkript2 (DersAdi, KullaniciAdi) " +
                                  "SELECT @DersAdi, @KullaniciAdi " +
                                  "WHERE NOT EXISTS (SELECT 1 FROM Transkript2 " +
                                  "WHERE DersAdi = @DersAdi AND KullaniciAdi = @KullaniciAdi)";
                    
                    SqlCommand komut2 = new SqlCommand(sql2, baglanti);
                    komut2.Parameters.AddWithValue("@DersAdi", DersAdi);
                    komut2.Parameters.AddWithValue("@KullaniciAdi", Kullanici_);

                    int etkilenenSatirSayisi = komut2.ExecuteNonQuery();

                    if (etkilenenSatirSayisi > 0)
                    {
                        // Ders başarıyla eklendi
                        MessageBox.Show($"{DersAdi} dersi transkripte eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Ders zaten ekli, işlem atlandı
                        //MessageBox.Show($"{DersAdi} dersi zaten transkripte ekli.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

       

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            // Seçilen dönem
            string donemBilgisi = numericUpDown2.Value.ToString();

            // Veritabanı bağlantısı
            using (SqlConnection baglanti = new SqlConnection(connectionString))
            {
                baglanti.Open();

                string sql = "SELECT DersAdi, DersKodu, AKTS, Kredi FROM Dersler WHERE Donem=@Donem";

                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.AddWithValue("@Donem", donemBilgisi);

                checkedListBox2.Items.Clear(); // checkedListBox1 içeriğini temizle

                using (SqlDataReader reader = komut.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string dersAdi = reader["DersAdi"].ToString();
                        string dersKodu = reader["DersKodu"].ToString();
                        int akts = Convert.ToInt32(reader["AKTS"]);
                        int kredi = Convert.ToInt32(reader["Kredi"]);

                        // Ders adı, ders kodu, AKTS ve kredi bilgilerini birleştir
                        string bilgi = $"{dersAdi} - Ders Kodu: {dersKodu} - AKTS: {akts} - Kredi: {kredi}";

                        checkedListBox2.Items.Add(bilgi); // Bilgiyi checkedListBox1'e ekle
                    }
                }



            }
        }
    }
}


