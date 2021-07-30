using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BARIŞ_YILDIZ
{
    public partial class DecimationMethod : Form
    {
        Process process = new Process();
        String topla = "";

        public DecimationMethod()
        {
            InitializeComponent();
        }

        private void button_ana_menüye_dön_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
            this.Dispose();

        }

        private void textBox_yöntem1_input_sentence_TextChanged(object sender, EventArgs e)
        {
            topla = textBox_yöntem1_input_sentence.Text;
            foreach (char element in topla)
            {
                if (element == ' ')
                {
                    MessageBox.Show("Lütfen şifrelenecek metin girişi yapılırken boşluk bırakmayınız");
                    textBox_yöntem1_input_sentence.Text = "";
                }
            }                                  

            if (textBox_yöntem1_input_sentence.Text.Length != 0)
            {
                if (!Char.IsLetter((char)topla[topla.Length - 1]))
                {
                    MessageBox.Show("Şifreleme/Deşifre giriş paneline yalnızca harfler girilebilir");
                    textBox_yöntem1_input_sentence.Text = "";
                    topla = "";
                }
            }
            /*
            if (topla.Length > 50)
            {
                MessageBox.Show("Maximumum yazı boyutunu aştınız.Maximum yazı boyutu 50 karakter olabilir.");
                textBox_yöntem1_input_sentence.Text = "";
            }
             */ 
            if (comboBox_dilseçenegi.GetItemText(comboBox_dilseçenegi.SelectedItem).Equals("İNGİLİZCE"))
            {
                if (!check_metin_İnglizce(textBox_yöntem1_input_sentence.Text.ToLower()) && textBox_yöntem1_input_sentence.Text != "")
                {
                    MessageBox.Show("' "+harf_İnglizce(textBox_yöntem1_input_sentence.Text)+" '" + "harfi "+ "İngilizce alfabesinde bulunmamaktadır.Lütfen farklı bir harf giriniz.");
                    textBox_yöntem1_input_sentence.Text = "";
                }
            }
            else if (comboBox_dilseçenegi.GetItemText(comboBox_dilseçenegi.SelectedItem).Equals("TÜRKÇE"))
            {
                if (!check_metin_Türkçe(textBox_yöntem1_input_sentence.Text.ToLower()) && textBox_yöntem1_input_sentence.Text != "")
                {
                    MessageBox.Show("' " + harf_Türkçe(textBox_yöntem1_input_sentence.Text) + " '" + "harfi " + "Türkçe alfabesinde bulunmamaktadır.Lütfen farklı bir harf giriniz.");
                    textBox_yöntem1_input_sentence.Text = "";
                }
            }
        }

        private void DecimationMethod_Load(object sender, EventArgs e)
        {
            comboBox_dilseçenegi.Items.Add("TÜRKÇE");
            comboBox_dilseçenegi.Items.Add("İNGİLİZCE");
            comboBox_dilseçenegi.SelectedIndex = comboBox_dilseçenegi.FindStringExact("TÜRKÇE");
            comboBox_dilseçenegi.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_şifreleme_deşifre.Items.Add("ŞİFRELEME");
            comboBox_şifreleme_deşifre.Items.Add("DEŞİFRE");
            comboBox_şifreleme_deşifre.SelectedIndex = comboBox_şifreleme_deşifre.FindStringExact("ŞİFRELEME");
            comboBox_şifreleme_deşifre.DropDownStyle = ComboBoxStyle.DropDownList;
            yöntem2_output_sentence.Visible = false;

            ready_text_1.Visible = false;
            ready_text2.Visible = false;
            ready_text3.Visible = false;
            ready_text4.Visible = false;
            label_key1.Visible = false;
            label_key2.Visible = false;
            label_key3.Visible = false;

            //textBox_yöntem1_output_sentence.Enabled = false;
        }

        private void button_temizle_Click(object sender, EventArgs e)
        {
            textBox_anahtar.Text = "";
            textBox_aralık.Text = "";
            textBox_yöntem1_input_sentence.Text = "";
            yöntem2_output_sentence.Text = "";

            ready_text_1.Visible = false;
            ready_text2.Visible = false;
            ready_text3.Visible = false;
            ready_text4.Visible = false;
            label_key1.Visible = false;
            label_key2.Visible = false;
            label_key3.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String comboBox_metin_dilseçeneği = comboBox_dilseçenegi.GetItemText(comboBox_dilseçenegi.SelectedItem);
            String comboBox_metin_şifreleme_or_deşifre = comboBox_şifreleme_deşifre.GetItemText(comboBox_şifreleme_deşifre.SelectedItem);
            Boolean a = false;
            Boolean b = false;
            Boolean c = false;
            if (textBox_yöntem1_input_sentence.Text.Equals(""))
            {
                a = false;
            }
            else
            {
                a = true;
            }
            if (textBox_anahtar.Text.Equals(""))
            {
                b = false;
            }
            else
            {
                b = true;
            }
            if (textBox_aralık.Text.Equals(""))
            {
                c = false;
            }
            else
            {
                c = true;
            }
            if (textBox_yöntem1_input_sentence.Text.Equals("") || textBox_anahtar.Text.Equals("") || textBox_aralık.Text.Equals(""))
            {

                if (a == false)
                {
                    MessageBox.Show("LÜTFEN ŞİFRELENECEK/DEŞİFRE EDİLECEK METNİ GİRİNİZ");
                }
                if (b == false)
                {
                    MessageBox.Show("LÜTFEN ANAHTAR KELİMEYİ GİRİNİZ");
                }
                if (c == false)
                {

                    MessageBox.Show("LÜTFEN ARALIK DEĞERİNİ GİRİNİZ");
                }
            }
            else if (comboBox_metin_dilseçeneği.Equals("İNGİLİZCE") && comboBox_metin_şifreleme_or_deşifre.Equals("ŞİFRELEME"))
            {
                Boolean devam = false;

                if (check_metin_İnglizce(textBox_anahtar.Text) && check_metin_İnglizce(textBox_yöntem1_input_sentence.Text))
                {
                        foreach (char element in textBox_yöntem1_input_sentence.Text)
                        {

                            if (Char.IsUpper(element) == true)
                            {

                                MessageBox.Show("Şifrelenecek olan açık metin girilirken lütfen büyük harf kullanmayınız.");
                                textBox_yöntem1_input_sentence.Text = "";
                                devam = false;
                                break;
                            }
                            else
                            {
                                devam = true;
                            }
                        }
                        if (devam == true)
                        {

                            //ŞİFRELEME-İNGİLİZCE
                            String readytext = textBox_yöntem1_input_sentence.Text.ToLower();
                            textBox_yöntem1_input_sentence.Text = textBox_yöntem1_input_sentence.Text.Replace(" ", "");
                            process.setMetin(readytext);
                            process.setAnahtarKelime(textBox_anahtar.Text);
                            process.setAralık(Int32.Parse(textBox_aralık.Text));
                            process.decimateKeyWord();
                            process.decimateKeyWordAddLetter("İNGİLİZCE");
                            process.encryptedtext();
                            //MessageBox.Show(process.getAnahtarKelime().Length.ToString());
                            //MessageBox.Show(process.listİngilizce.Count.ToString());
                            process.createDictionary("İNGİLİZCE");
                            process.secondencryptedtext();
                            yöntem2_output_sentence.Visible = true;
                            activatevisible();
                            ready_text4.Text = "ŞİFRELENMİŞ SONUÇ METNİ";
                            label_key1.Text = process.label_key1;
                            label_key2.Text = process.label_key2;
                            label_key3.Text = process.label_key3;
                            yöntem2_output_sentence.Text = process.getOutputMetin().ToUpper();
                        }
                }
                else if (!check_metin_İnglizce(textBox_anahtar.Text))
                {
                    MessageBox.Show("'" + harf_İnglizce(textBox_anahtar.Text) + "'" + "İngilizce harf değildir.Lütfen anahtar kelime için farklı bir harf deneyiniz");
                    textBox_anahtar.Text = "";
                }
                else if (!check_metin_İnglizce(textBox_yöntem1_input_sentence.Text))
                {
                    MessageBox.Show("'" + harf_İnglizce(textBox_yöntem1_input_sentence.Text) + "'" + "İngilizce harf değildir.Lütfen giriş paneli için farklı bir harf deneyiniz");
                    textBox_yöntem1_input_sentence.Text = "";
                }

            }
            else if (comboBox_metin_dilseçeneği.Equals("TÜRKÇE") && comboBox_metin_şifreleme_or_deşifre.Equals("ŞİFRELEME"))
            {
                Boolean devam2 = false;

                if (check_metin_Türkçe(textBox_yöntem1_input_sentence.Text) && check_metin_Türkçe(textBox_anahtar.Text))
                {

                    foreach (char element in textBox_yöntem1_input_sentence.Text)
                        {

                            if (Char.IsUpper(element) == true)
                            {

                                MessageBox.Show("Şifrelenecek olan açık metin girilirken lütfen büyük harf kullanmayınız.");
                                textBox_yöntem1_input_sentence.Text = "";
                                devam2 = false;
                                break;
                            }
                            else
                            {
                                devam2 = true;
                            }
                        }
                    if (devam2 == true)
                    {

                        //ŞİFRELEME-TÜRKÇE
                        String readytext2 = textBox_yöntem1_input_sentence.Text.ToLower();
                        textBox_yöntem1_input_sentence.Text = textBox_yöntem1_input_sentence.Text.Replace(" ", "");
                        process.setMetin(readytext2);
                        process.setAnahtarKelime(textBox_anahtar.Text);
                        process.setAralık(Int32.Parse(textBox_aralık.Text));
                        process.decimateKeyWord();
                        process.decimateKeyWordAddLetter("TÜRKÇE");
                        process.encryptedtext();
                        process.createDictionary("TÜRKÇE");
                        process.secondencryptedtext();
                        yöntem2_output_sentence.Visible = true;
                        activatevisible();
                        ready_text4.Text = "ŞİFRENMİŞ SONUÇ METNİ";
                        label_key1.Text = process.label_key1;
                        label_key2.Text = process.label_key2;
                        label_key3.Text = process.label_key3;
                        yöntem2_output_sentence.Text = process.getOutputMetin().ToUpper();
                    }
                }
                else if (!check_metin_Türkçe(textBox_anahtar.Text))
                {
                    MessageBox.Show("'" + harf_Türkçe(textBox_anahtar.Text) + "'" + "Türkçe harf değildir.Lütfen anahtar kelime için farklı bir harf deneyiniz");
                    textBox_anahtar.Text = "";
                }
                else if (!check_metin_Türkçe(textBox_yöntem1_input_sentence.Text))
                {
                    MessageBox.Show("'" + harf_Türkçe(textBox_yöntem1_input_sentence.Text) + "'" + "Türkçe harf değildir.Lütfen giriş paneli için farklı bir harf deneyiniz");
                    textBox_yöntem1_input_sentence.Text = "";
                }
            }
            else if (comboBox_metin_dilseçeneği.Equals("İNGİLİZCE") && comboBox_metin_şifreleme_or_deşifre.Equals("DEŞİFRE"))
            {
                Boolean devam3 = false;

                if (check_metin_İnglizce(textBox_yöntem1_input_sentence.Text) && check_metin_İnglizce(textBox_anahtar.Text))
                {

                    foreach (char element in textBox_yöntem1_input_sentence.Text)
                        {

                            if (Char.IsLower(element) == true)
                            {

                                MessageBox.Show("Deşifre edilecek olan şifreli metin girilirken lütfen küçük harf kullanmayınız.");
                                textBox_yöntem1_input_sentence.Text = "";
                                devam3 = false;
                                break;
                            }
                            else
                            {
                                devam3 = true;
                            }
                        }
                    if (devam3 == true)
                    {

                        //DEŞİFRE-İNGİLİZCE
                        String readytext3 = textBox_yöntem1_input_sentence.Text.ToLower();
                        textBox_yöntem1_input_sentence.Text = textBox_yöntem1_input_sentence.Text.Replace(" ", "");
                        process.setMetin(readytext3);
                        process.küçükharfler();
                        process.setAnahtarKelime(textBox_anahtar.Text);
                        process.setAralık(Int32.Parse(textBox_aralık.Text));
                        process.decimateKeyWord();
                        process.decimateKeyWordAddLetter("İNGİLİZCE");
                        process.encryptedtext();
                        process.createDictionary2("İNGİLİZCE");
                        process.secondencryptedtext();
                        yöntem2_output_sentence.Visible = true;
                        activatevisible();
                        ready_text4.Text = "AÇIK METİN SONUCU";
                        label_key1.Text = process.label_key1;
                        label_key2.Text = process.label_key2;
                        label_key3.Text = process.label_key3;
                        yöntem2_output_sentence.Text = process.getOutputMetin().ToLower();
                    }

                }

                else if (!check_metin_İnglizce(textBox_anahtar.Text))
                {
                    MessageBox.Show("'" + harf_İnglizce(textBox_anahtar.Text) + "'" + "İngilizce harf değildir.Lütfen anahtar kelime için farklı bir harf deneyiniz");
                    textBox_anahtar.Text = "";
                }
                else if (!check_metin_İnglizce(textBox_yöntem1_input_sentence.Text))
                {
                    MessageBox.Show("'" + harf_İnglizce(textBox_yöntem1_input_sentence.Text) + "'" + "İngilizce harf değildir.Lütfen giriş paneli için farklı bir harf deneyiniz");
                    textBox_yöntem1_input_sentence.Text = "";
                }
            }
            else if (comboBox_metin_dilseçeneği.Equals("TÜRKÇE") && comboBox_metin_şifreleme_or_deşifre.Equals("DEŞİFRE"))
            {
                Boolean devam4 = false;

                if (check_metin_Türkçe(textBox_yöntem1_input_sentence.Text) && check_metin_Türkçe(textBox_anahtar.Text))
                {
                    foreach (char element in textBox_yöntem1_input_sentence.Text)
                        {

                            if (Char.IsLower(element) == true)
                            {

                                MessageBox.Show("Deşifre edilecek olan şifreli metin girilirken lütfen küçük harf kullanmayınız.");
                                textBox_yöntem1_input_sentence.Text = "";
                                devam4 = false;
                                break;
                            }
                            else
                            {
                                devam4 = true;
                            }
                        }
                    if (devam4 == true)
                    {

                        //DEŞİFRE-TÜRKÇE
                        String readytext4 = textBox_yöntem1_input_sentence.Text.ToLower();
                        textBox_yöntem1_input_sentence.Text = textBox_yöntem1_input_sentence.Text.Replace(" ", "");
                        process.setMetin(readytext4);
                        process.küçükharfler();
                        process.setAnahtarKelime(textBox_anahtar.Text);
                        process.setAralık(Int32.Parse(textBox_aralık.Text));
                        process.decimateKeyWord();
                        process.decimateKeyWordAddLetter("TÜRKÇE");
                        process.encryptedtext();
                        process.createDictionary2("TÜRKÇE");
                        process.secondencryptedtext();
                        yöntem2_output_sentence.Visible = true;
                        activatevisible();
                        ready_text4.Text = "AÇIK METİN SONUCU";
                        label_key1.Text = process.label_key1;
                        label_key2.Text = process.label_key2;
                        label_key3.Text = process.label_key3;
                        yöntem2_output_sentence.Text = process.getOutputMetin().ToLower();
                    }
                }

                else if (!check_metin_Türkçe(textBox_anahtar.Text))
                {
                    MessageBox.Show("'" + harf_Türkçe(textBox_anahtar.Text) + "'" + "Türkçe harf değildir.Lütfen anahtar kelime için farklı bir harf deneyiniz");
                    textBox_anahtar.Text = "";
                }
                else if (!check_metin_Türkçe(textBox_yöntem1_input_sentence.Text))
                {
                    MessageBox.Show("'" + harf_Türkçe(textBox_yöntem1_input_sentence.Text) + "'" + "Türkçe harf değildir.Lütfen giriş paneli için farklı bir harf deneyiniz");
                    textBox_yöntem1_input_sentence.Text = "";
                }
            }
        }

        public Boolean check_metin_İnglizce(String metin)
        {
            Boolean ingilizce = false;

            foreach (char harf in metin)
            {
                if (harf == 'ç' || harf == 'ğ' || harf == 'ö' || harf == 'ı' || harf == 'ş' || harf == 'ü' || harf == 'Ç' || harf == 'Ğ' || harf == 'Ö' || harf == 'I' || harf == 'Ş' || harf == 'Ü')
                {
                    ingilizce = false;
                }
                else
                {
                    ingilizce = true;
                }
            }
            return ingilizce;
        }

        public char harf_İnglizce(String metin)
        {
            char c = ' ';

            foreach (char harf in metin) 
            {
                if (harf == 'ç' || harf == 'ğ' || harf == 'ö' || harf == 'ı' || harf == 'ş' || harf == 'ü' || harf == 'Ç' || harf == 'Ğ' || harf == 'Ö' || harf == 'I' || harf == 'Ş' || harf == 'Ü')
                {
                    c = harf;
                }
            }
            return c;
        }

        public Boolean check_metin_Türkçe(String metin)
        {
                Boolean türkçe = false;

                foreach (char harf in metin)
                {
                    if (harf == 'q' || harf == 'w' || harf == 'x' || harf == 'Q' || harf == 'W' || harf == 'X')
                    {
                        türkçe = false;
                    }
                    else
                    {
                        türkçe = true;
                    }
                }
            
            return türkçe;
            
        }

        public char harf_Türkçe(String metin)
        {
            char c = ' ';

                foreach (char harf in metin)
                {
                    if (harf == 'x' || harf == 'q' || harf == 'w' || harf == 'X' || harf == 'Q' || harf == 'W')
                    {
                        c = harf;
                    }
                }
            
            return c;
        }

        private void textBox_aralık_TextChanged(object sender, EventArgs e)
        {
            int aralık;

            if (!textBox_aralık.Text.Equals(""))
            {
                try
                {
                    aralık = Int32.Parse(textBox_aralık.Text);
                    if (check_odd_interval(aralık))
                    {
                        textBox_aralık.Text = aralık.ToString()[aralık.ToString().Length - 1].ToString();
                    }
                    else
                    {
                        MessageBox.Show("LÜTFEN TEK SAYI GİRİNİZ");
                        textBox_aralık.Text = "";
                    }
                    
                }
                catch
                {
                    MessageBox.Show("Lütfen tamsayı giriniz");
                    textBox_aralık.Text = "";
                }
            }
        }

        public Boolean check_odd_interval(int sayi)
        {
            Boolean odd = false;
            if (sayi % 2 == 0)
            {
                odd = false;
            }
            else
            {
                odd = true;
            }

            return odd;
        }

        private void textBox_anahtar_TextChanged(object sender, EventArgs e)
        {
            String comboBox_metin_dilseçeneği = comboBox_dilseçenegi.GetItemText(comboBox_dilseçenegi.SelectedItem);
            String anahtarkelime = textBox_anahtar.Text;
            String keytext = "";
            Boolean upper = false;
            foreach(char element in anahtarkelime)
            {
                if(Char.IsUpper(element) == true){

                    MessageBox.Show("LÜTFEN ANAHTAR KELİMEYİ KÜÇÜK HARFLERLE YAZINIZ");
                    anahtarkelime = "";
                    textBox_anahtar.Text = "";
                    upper = true;
                    break;
                }
                if (Char.IsLetter(element) != true)
                {
                    MessageBox.Show("ANAHTAR KELİME YALNIZCA HARF ALABİLİR");
                    anahtarkelime = "";
                    textBox_anahtar.Text = "";
                    break;
                }
            }

            foreach (char element in anahtarkelime)
            {
                if (element == ' ')
                {
                    MessageBox.Show("Lütfen anahtar kelimeyi yazarken boşluk bırakmayınız");
                    textBox_anahtar.Text = "";
                    anahtarkelime = "";
                }
            } 
           
                if (anahtarkelime != "" && upper != false)
                {
                    if (!Char.IsLetter((char)anahtarkelime[anahtarkelime.Length - 1]))
                    {

                        MessageBox.Show("LÜTFEN HARF GİRİNİZ");
                        textBox_anahtar.Text = "";
                        anahtarkelime = textBox_anahtar.Text;
                    }
                    else if (comboBox_metin_dilseçeneği.Equals("İNGİLİZCE") && !check_metin_İnglizce(anahtarkelime))
                    {

                        MessageBox.Show("LÜTFEN İNGİLİZCE HARF GİRİNİZ " + "'" + harf_İnglizce(anahtarkelime) + "'" + " İNGİLİZCE ALFABESİNDE BULUNMAMAKTADIR. ");
                        textBox_anahtar.Text = "";
                        anahtarkelime = textBox_anahtar.Text;
                    }
                    else if (comboBox_metin_dilseçeneği.Equals("TÜRKÇE") && !check_metin_Türkçe(anahtarkelime))
                    {
                        MessageBox.Show("LÜTFEN TÜRKÇE HARF GİRİNİZ");
                        textBox_anahtar.Text = "";
                        anahtarkelime = textBox_anahtar.Text;
                    }
                }
        }

        private void comboBox_dilseçenegi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!check_metin_İnglizce(textBox_anahtar.Text) && textBox_anahtar.Text != "")
            {
                MessageBox.Show("'" + harf_İnglizce(textBox_anahtar.Text) + "'" + "İnglizce harf değildir.Lütfen anahtar kelime için farklı bir harf deneyiniz");
                textBox_anahtar.Text = "";
            }

            if (!check_metin_Türkçe(textBox_anahtar.Text) && textBox_anahtar.Text != "")
                {
                    MessageBox.Show("'" + harf_Türkçe(textBox_anahtar.Text) + "'" + "Türkçe harf değildir.Lütfen anahtar kelime için farklı bir harf deneyiniz");
                    textBox_anahtar.Text = "";
                }

            if (comboBox_dilseçenegi.GetItemText(comboBox_dilseçenegi.SelectedItem).Equals("İNGİLİZCE"))
            {
                if (!check_metin_İnglizce(textBox_yöntem1_input_sentence.Text) && textBox_yöntem1_input_sentence.Text != "")
                {
                    MessageBox.Show("' " + harf_İnglizce(textBox_yöntem1_input_sentence.Text) + " '" + "harfi " + "İngilizce alfabesinde bulunmamaktadır.Lütfen şifreleme/deşifre metin panelinde farklı bir harf giriniz.");
                    textBox_yöntem1_input_sentence.Text = "";
                }
            }
            else if (comboBox_dilseçenegi.GetItemText(comboBox_dilseçenegi.SelectedItem).Equals("TÜRKÇE"))
            {
                if (!check_metin_Türkçe(textBox_yöntem1_input_sentence.Text) && textBox_yöntem1_input_sentence.Text != "")
                {
                    MessageBox.Show("' " + harf_Türkçe(textBox_yöntem1_input_sentence.Text) + " '" + "harfi " + "Türkçe alfabesinde bulunmamaktadır.Lütfen şifreleme/deşifre metin panelinde farklı bir harf giriniz.");
                    textBox_yöntem1_input_sentence.Text = "";
                }
            }
        }

        private void comboBox_şifreleme_deşifre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void activatevisible() {

            ready_text_1.Visible = true;
            ready_text2.Visible = true;
            ready_text3.Visible = true;
            ready_text4.Visible = true;
            label_key1.Visible = true;
            label_key2.Visible = true;
            label_key3.Visible = true;

        }

        private void button_rule_information_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1)ANAHTAR KELİME VERİLİRKEN SADECE KÜÇÜK HARFLER KULLANILMALI VE BOŞLUKSUZ OLARAK YAZILMALIDIR."+"\n"+
                "2)ARALIK DEĞERİ VERİLİRKEN YALNIZCA 1-10 ARASINDAKİ TEK SAYILAR KULLANILMALIDIR."+"\n"+
                "3)LÜTFEN ŞİFRELEME/DEŞİFRE YAPILACAK METNİ GİRİNİZ KISMINA ŞİFRELEME YAPILACAK AÇIK METİN VERİSİ GİRİLECEKSE KÜÇÜK HARFLERLE VE BOŞLUKSUZ OLARAK GİRİLMELİDİR.DEŞİFRE EDİLECEK OLAN ŞİFRELİ METİN GİRİLECEKSE BÜYÜK HARFLERLE VE BOŞLUKSUZ OLARAK GİRİLMELİDİR."+"\n"+
                "Şifreleme ve deşifre yapmak için ilk olarak DİL SEÇİMİ kısmından dil seçimini ve ŞİFRELEME/DEŞİFRE kısmından şifreleme yapmak istiyorsanız şifreleme , deşifre yapmak istiyorsanız deşifre seçeneğini seçiniz."
                    + "'"+ " LÜTFEN ŞİFRELEME/DEŞİFRE YAPILACAK METNİ GİRİNİZ "+"'"+"yazısının altındaki boşluğu doldurunuz."+"'"+ " METNİ İŞLE BUTONUNA BASINIZ. " +"'"+
                    "Yapılan bu işlem sonrasında ŞİFRELEME/DEŞİFRE SONRASI OLUŞAN METİN KISMINDA şifreleme ve deşifreye ait sonuçlar görüntülenecektir.Method tekrardan kullanılmak istenirse TEMİZLE butonu kullanıldığında eski bilgiler temizlenerek uygulama yeniden hazır hale gelecektir.Uygulamada şifreleme ve deşifre işlemleri için farklı bir method kullanılmak istenirse ANA MENÜYE DÖN butonuna tıklandığında uygulama menüsüne dönüş gerçekleştirilecektir.");
        }

        private void button_run_information_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DECİMATİON METHOD güçlü şifreleme ve deşifre yapar.Kullanıcıdan alınan anahtar kelime bilgisinde tekrar eden harfler yok edilir ve DİL SEÇİMİ kısmında İngilizce seçilmişse anahtarda olmayan İngilizce alfabesindeki harfler sırasıyla,Türkçe seçilmişse anahtarda olmayan Türkçe alfabesindeki harfler sırasıyla anahtar kelimeye eklenir."+
                "Oluşturulmuş 1.şifrelemedeki harfler kullanıcıdan alınan aralık değerine göre alınarak yeni bir şifreleme/deşifre yapısı oluşturulur ve bu yapıda her bir harf sırasıyla yapılan dil seçimine göre alfabedeki harflere karşılık gelir.Şifreleme/Deşifre yapılmak istenilen metin bu şifreleme yapısı kullanılarak işlemi yapılır.");
        }
    }
}
