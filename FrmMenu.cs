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

            string gunluk;
            string txt_adi = dateTimePicker1.Text;
           
            FileStream fs = new FileStream(txt_adi,FileMode.Open,FileAccess.Read);
            StreamReader sr= new StreamReader(fs);
            gunluk= sr.ReadToEnd();
          
            if(gunluk!=null)
            {
                s.richTextBox1.Text = gunluk;
                gunluk=sr.ReadLine();
                s.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bu tarihde kayıtlı bir günlük yok");
            }
            sr.Close();
            fs.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kayit k=new Kayit();
            k.Show();
            this.Hide();
        }
    }
}
