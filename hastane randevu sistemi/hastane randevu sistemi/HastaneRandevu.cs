using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastane_randevu_sistemi
{
    public partial class HastaneRandevu : Form
    {
        public HastaneRandevu()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Bartın") 
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Amasra");
                comboBox2.Items.Add("Kurucaşile");
                comboBox2.Items.Add("Ulus");
                comboBox2.Items.Add("Merkez");
            }
            else if(comboBox1.SelectedItem=="Bayburt")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Merkez").ToString();
                comboBox2.Items.Add("Demirören");
                comboBox2.Items.Add("Aydıntepe");                   
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String DosyaAdi = "Randevu.txt";
            String dosyayol = @"C:\Users\lenovo\Desktop\hastane";
            String konum = Path.Combine(dosyayol, DosyaAdi);
            List<Veri> list = Veri.Veriler();
           
                if (File.Exists(konum) == true)
                {
                for (int i=0;i<list.Count;i++)
                {
                    String yazılacak = "";
                    yazılacak = "İl: " + list[i].İl + ", İlçe: " + list[i].İlce + ", Hastane: " + list[i].Hastane + ", Klinik: " + list[i].Klinik + ", Tarih: " + list[i].Tarih + ", Saat:" + list[i].Saat+"\n";
                    File.AppendAllText(konum, yazılacak);
                }
                MessageBox.Show("Randevularınız Kayıt Edildi!");

                }
                else
                {
                    File.Create(DosyaAdi);
                String baslık = "İl,İlçe,Hastane,Klinik,Tarih,Saat \n";
                File.AppendAllText(konum, baslık);
                    for(int i = 0; i < list.Count; i++)
                    {
                            String yazılacak = "";
                    yazılacak = "İl: " + list[i].İl + ", İlçe: " + list[i].İlce + ", Hastane: " + list[i].Hastane + ", Klinik: " + list[i].Klinik + ", Tarih: " + list[i].Tarih + ", Saat:" + list[i].Saat + "\n";
                    File.AppendAllText(konum, yazılacak);
                    }

                MessageBox.Show("Dosya oluşturuldu ve Randevu Başarıyla Kayıt Edildi!");
                }

            Veri.Temizle(list);

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string il = comboBox1.SelectedItem.ToString();
            string ilce = comboBox2.SelectedItem.ToString();
            string hastane = textBox1.Text;
            string klinik = textBox2.Text;
            DateTime tarih = dateTimePicker1.Value;
            DateTime saat = dateTimePicker2.Value;
            Veri veri = new Veri(il, ilce, hastane, klinik, tarih, saat);
            Veri.Ekle(veri);
            comboBox1.SelectedItem = null;
            comboBox2.SelectedItem = null;
            textBox1.Clear();
            textBox2.Clear();
            MessageBox.Show(Veri.Veriler().Count.ToString()+" Tane Randevunuz Mevcut Sisteme Kaydetmek İçin Kaydet Butonuna Basın!");
            
        }
    }
    public class Veri
    {
        private string il;
        private string ilce;
        private string hastane;
        private string klinik;
        private string tarih;
        private string saat;

        private static List<Veri> veriler = new List<Veri>();

        public Veri (string il, string ilce, string hastane, string klinik, DateTime tarih, DateTime saat)
        {
            this.il = il;
            this.ilce = ilce;
            this.hastane = hastane;
            this.klinik = klinik;
            this.tarih = tarih.ToShortDateString();
            this.saat = saat.ToShortTimeString();
            
            
        }
        public string İl { get { return il; }  set{ il = value; } }
        public string İlce { get { return ilce; } set { ilce = value; } }
        public string Hastane { get { return hastane; } set { hastane = value; } }
        public string Klinik { get { return klinik; } set { klinik = value; } }
        public string Tarih { get { return tarih; } set { tarih = value; } }
        public string Saat { get { return saat; } set { saat = value; } }

        public static List<Veri> Veriler()
        {
            return veriler;
        }
        public static void Ekle(Veri a)
        {
            veriler.Add(a);
        }
        public static void Temizle(List<Veri> x) 
        {
            x.Clear();
        }
    }

       
}
