using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyDaily
{
    public partial class FrmMenu : Form
    {
        Sayfa s = new Sayfa();
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            s.Show();//o sahneye bağlıyoruz
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ayarladığımız tarihteki dosyayı açan 
            try
            {
                string gunluk;
                string txt_adi = dateTimePicker1.Text;

                FileStream fs = new FileStream(txt_adi, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                gunluk = sr.ReadToEnd();

                if (gunluk != null)
                {
                    s.richTextBox1.Text = gunluk;
                    gunluk = sr.ReadLine();
                    s.Show();
                    this.Hide();
                }
                sr.Close();
                fs.Close();
            }
            catch (Exception)
                {
                    MessageBox.Show("Bu tarihde kayıtlı bir günlük yok");
                }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kayit k=new Kayit();
            k.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Derslerim d=new Derslerim();
            d.Show();
            this.Hide();
        }
    }
}
