using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastane_randevu_sistemi
{
    public partial class AşıRandevusu : Form
    {
        public AşıRandevusu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String ad = textBox1.Text;
            String soyad = textBox2.Text;
            String tc = textBox3.Text;
            String yas = textBox4.Text;
            String kilo = textBox5.Text;

            String DosyaAdi = "Asi{" + tc + "}.txt";
            String dosyayol = @"C:\Users\lenovo\Desktop\hastane";
            String konum =Path.Combine(dosyayol, DosyaAdi);

            String[] textVeri = { "Adı: " + ad, "Soyadı: " + soyad, "TC Kimlik: " + tc, "Yaş: " + yas, "Kilo: " + kilo };


            if (TCkimlik(tc)==true && ad != null && soyad != null && yas != null && tc != null && kilo != null)
            {
                if (File.Exists(konum)==true) 
                {

                    File.AppendAllLines(konum, textVeri);
                    MessageBox.Show("Randevu Başarıyla Kayıt Edildi!");
                    
                }
                else
                {
                    File.Create(DosyaAdi);
                    File.WriteAllLines(konum, textVeri);
                 
                    MessageBox.Show("Dosya oluşturuldu ve Randevu Başarıyla Kayıt Edildi!");
                }
                
            }
            else
                MessageBox.Show("Kayıt Başarısız TC Kimlik Kontrol edin Veya Boş Değer bırakmayın! ");

        }
        public bool TCkimlik(String tc) 
        {
            string tcKimlikNo = tc;
            bool returnvalue = false;
            if (tcKimlikNo.Length == 11)
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                TcNo = Int64.Parse(tcKimlikNo);

                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;

                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
            }


            return returnvalue;
            
        }
        
    }
}
