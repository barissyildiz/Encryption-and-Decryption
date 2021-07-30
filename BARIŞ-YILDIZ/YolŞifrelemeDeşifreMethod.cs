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
    public partial class YolŞifrelemeDeşifreMethod : Form
    {
        public YolŞifrelemeDeşifreMethod()
        {
            InitializeComponent();
            this.textBox_yöntem2_input_sentence.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnter);
        }

        String metin = "";
        int length_table = 0;
        String raw, column;
        Boolean devam;

        private void button_ana_menüye_dön2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Dispose();
           
        }

        private void YolŞifrelemeDeşifreMethod_Load(object sender, EventArgs e)
        {
            //textBox_yöntem2_output_sentence.ReadOnly = true;
            comboBox_yöntem2_şifreleme_deşifre.Items.Add("ŞİFRELEME");
            comboBox_yöntem2_şifreleme_deşifre.Items.Add("DEŞİFRE");
            comboBox_yöntem2_şifreleme_deşifre.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_yöntem2_şifreleme_deşifre.SelectedIndex = comboBox_yöntem2_şifreleme_deşifre.FindStringExact("ŞİFRELEME");
            comboBox_dilseçenegi.Items.Add("İNGİLİZCE");
            comboBox_dilseçenegi.Items.Add("TÜRKÇE");
            comboBox_dilseçenegi.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_dilseçenegi.SelectedIndex = comboBox_dilseçenegi.FindStringExact("İNGİLİZCE");
            first_output_sentence.Visible = false;
            şifreleme_deşifre_yöntem2_output_label.Visible = false;
            label_ready_output_text1.Visible = false;
            label_ready_output_text2.Visible = false;
        }

        private void button_yöntem2_run_Click(object sender, EventArgs e)
        {
            Boolean devam = false;

            if (comboBox_yöntem2_şifreleme_deşifre.GetItemText(comboBox_yöntem2_şifreleme_deşifre.SelectedItem).Equals("ŞİFRELEME"))
            {
                foreach (char element in textBox_yöntem2_input_sentence.Text)
                {

                    if (Char.IsUpper(element) == true)
                    {
                        MessageBox.Show("Şifrelenecek olan açık metin girilirken lütfen büyük harf kullanmayınız.");
                        textBox_yöntem2_input_sentence.Text = "";
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
                    metin = textBox_yöntem2_input_sentence.Text.Replace(" ", "");
                    Boolean asal = Asalmı(CalculateMeasurement(metin));
                    if (asal == false)
                    {
                    }
                    else
                    {
                        metin = addX(metin);
                    }
                    Int32[,] list_table = possible_table_measurement(metin);
                    add_element_to_ComboBox(list_table);
                }
            }
            else if (comboBox_yöntem2_şifreleme_deşifre.GetItemText(comboBox_yöntem2_şifreleme_deşifre.SelectedItem).Equals("DEŞİFRE"))
            {
                foreach (char element in textBox_yöntem2_input_sentence.Text)
                {

                    if (Char.IsLower(element) == true)
                    {
                        MessageBox.Show("Deşifre edilecek olan şifreli metin girilirken lütfen küçük harf kullanmayınız.");
                        textBox_yöntem2_input_sentence.Text = "";
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
                    metin = textBox_yöntem2_input_sentence.Text.Replace(" ", "");
                    Boolean asal = Asalmı(CalculateMeasurement(metin));
                    if (asal == false)
                    {
                    }
                    else
                    {
                        metin = addX(metin);
                    }
                    Int32[,] list_table = possible_table_measurement(metin);
                    add_element_to_ComboBox(list_table);
                }
            }
        }

        public String deşifre_createTableA4(String metin)
        {
            String lastmetin = "";
            int s = metin.Length - 1;
            for (int i = 0; i < metin.Length; i++)
            {
                lastmetin = lastmetin + metin[s].ToString();
                s -= 1;
            }
            return lastmetin;
        }

        private int CalculateMeasurement(String metin)
        {
            int length = metin.Length;

            return length;
        }

        private Boolean Asalmı(int sayı)
        {
            Boolean asal = true;
            for (int i = 2; i < sayı; i++)
            {
                if (sayı % i == 0)
                {
                    asal = false;
                }
            }

                return asal;
        }

        private String addX(String word)
        {
            int counter = 0;
            int wordlength = CalculateMeasurement(word);
            Boolean asal = true;
            while (asal == true)
            {
                counter += 1;
                wordlength += 1;
                asal = Asalmı(wordlength);
            }

            if (counter != 0)
            {

                for (int i = 0; i < counter; i++)
                {
                    word = word + "X";                   
                }
                //MessageBox.Show(word);
            }
                return word;
        }
        private Int32[,] possible_table_measurement(String metin) {

            List<Int32> list_raw = new List<Int32>();
            List<Int32> list_column = new List<Int32>();
            int wordlength = CalculateMeasurement(metin);
            //int raw, column;

            for (int i = 1; i <= wordlength; i++)
            {
                if(wordlength % i == 0 ) {

                    list_raw.Add(i);
                    list_column.Add(wordlength/i);
                }
            }
            length_table = list_raw.Count();
            Int32[,] list_table_measurement = new Int32[length_table, length_table];
            for (int i = 0; i < length_table; i++)
            {
                list_table_measurement[0,i] = list_raw[i];
                list_table_measurement[1, i] = list_column[i];
            }

                return list_table_measurement;
        }

        private void add_element_to_ComboBox(Int32[,] list_table)
        {
            comboBox_yöntem2_table_measurement.Items.Clear();
         
            for (int i = 0; i < length_table; i++)
                
            {
                comboBox_yöntem2_table_measurement.Items.Add(list_table[0, i].ToString() + "X" + list_table[1, i].ToString());
            }
            comboBox_yöntem2_table_measurement.SelectedIndex = comboBox_yöntem2_table_measurement.FindStringExact(list_table[0,0].ToString() + "X" + list_table[1,0]);
            comboBox_yöntem2_table_measurement.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_yöntem2_input_sentence.Text = "";
            şifreleme_deşifre_yöntem2_output_label.Text = "";
            comboBox_yöntem2_table_measurement.Items.Clear();
            first_output_sentence.Visible = false;
            şifreleme_deşifre_yöntem2_output_label.Visible = false;
            label_ready_output_text1.Visible = false;
            label_ready_output_text2.Visible = false;
        }

        private void comboBox_yöntem2_table_measurement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox_yöntem2_input_sentence.Text != "")
            {
                if (comboBox_yöntem2_şifreleme_deşifre.GetItemText(comboBox_yöntem2_şifreleme_deşifre.SelectedItem).Equals("ŞİFRELEME"))
                {
                    raw = "";
                    column = "";
                    String comboBox_item = comboBox_yöntem2_table_measurement.SelectedItem.ToString();
                    int placeOfX = comboBox_item.IndexOf("X");
                    for (int i = 0; i < placeOfX; i++)
                    {

                        raw = raw + comboBox_item[i].ToString();
                    }
                    for (int i = placeOfX + 1; i < comboBox_item.Length; i++)
                    {
                        column = column + comboBox_item[i].ToString();
                    }

                    //createTable_E3(raw, column);
                    createTable_A4();
                }
                else
                {
                    raw = "";
                    column = "";
                    String comboBox_item = comboBox_yöntem2_table_measurement.SelectedItem.ToString();
                    int placeOfX = comboBox_item.IndexOf("X");
                    for (int i = 0; i < placeOfX; i++)
                    {

                        raw = raw + comboBox_item[i].ToString();
                    }
                    for (int i = placeOfX + 1; i < comboBox_item.Length; i++)
                    {
                        column = column + comboBox_item[i].ToString();
                    }
                    String deşifre_input_metin = textBox_yöntem2_input_sentence.Text.ToLower();
                    //şifreleme_deşifre_yöntem2_output_label.Text = deşifre_input_metin;
                    label_ready_output_text1.Visible = true;
                    label_ready_output_text2.Visible = true;
                    first_output_sentence.Visible = true;
                    şifreleme_deşifre_yöntem2_output_label.Visible = true;
                    String A4_deşifre_input_metin = deşifre_createTableA4(deşifre_input_metin);                    
                    first_output_sentence.Text = A4_deşifre_input_metin.ToUpper();
                    String lowertext = first_output_sentence.Text.ToLower();
                    label_ready_output_text1.Text = "A4 Matrisinden Filtreleme Sonucu Oluşan Matris";
                    label_ready_output_text2.Text = "E3 Matrisinden Filtreleme Sonucu OLuşan Açık Metin";
                    şifreleme_deşifre_yöntem2_output_label.Text = deşifre_createTable_E3("4","4",lowertext);
                }
            }
            else
            {
                MessageBox.Show("ŞİFRELEME VEYA DEŞİFRE YAPABİLMEK İÇİN HARFLER GİRİNİZ");
            }
        }

        private String createTable_E3(String raw, String column)
        {
        
            int dictionary_raw = 0;
            int dictionary_column = 0;
            int index = 0;
            int max_minicity_raw_column = 0;
            int max_value = -1;
            int max_minicity_min_column = 2000;
            int z = 0;
            int int_raw = Int32.Parse(raw);
            int int_column = Int32.Parse(column);
            Char[,] list = new Char[int_raw, int_column];
            //MessageBox.Show(raw + "\n" + column + "\n" + metin.Length);

            for (int i = 0; i < int_raw; i++)
            {
                for (int y = 0; y < int_column; y++)
                {
                    list[i, y] = metin[z];
                    z++;
                }
            }
            //List<Int32> list_max_degerler = new List<int>();
            //List<Int32> list_minimum_column = new List<int>();
            List<MatrixItem> list_class = new List<MatrixItem>();
          
            for (int k = 0; k < int_raw; k++)
            {
                for (int m = 0; m < int_column; m++)
                {
                    int max_degerler = k - m;
                    //MessageBox.Show("RAWCOMBO " + int_raw.ToString() + "Column" + int_column.ToString() + "FARK" + max_degerler.ToString());

                   //list_max_degerler.Add(max_degerler);
                   //list_minimum_column.Add(m);
                    MatrixItem matrixitem = new MatrixItem();
                    matrixitem.max_fark = max_degerler;
                    matrixitem.raw = k;
                    matrixitem.column = m;
                    list_class.Add(matrixitem);
                   
                }
            }

            //RAW VE COLUMN FARKI OLARAK EN BÜYÜK OLANDAN EN KÜÇÜK OLANA SIRALAMA          
            //kabarcikSirala(list_class);
            kabarcikSirala2(list_class);

            /*
            for (int u = 0; u < list_class.Count; u++)
            {
                MessageBox.Show("FARK : " + list_class[u].max_fark.ToString() + " RAW " + list_class[u].raw.ToString() + " Column " + list_class[u].column.ToString());
            }
             */             
           
            String şifrelimetin = "";
            int s = 0;
            for (int e = 0; e < list_class.Count; e++)
            {
                list_class.ElementAt(e).harf = metin[e];
            }

                
                for (int x = 0; x < Int32.Parse(raw); x++)
                {
                    for (int r = 0; r < Int32.Parse(column); r++)
                    {

                        char harf = findposition(list_class,x,r);
                        şifrelimetin = şifrelimetin + "  " + harf;
                    }
                    şifrelimetin = şifrelimetin + "\r\n";
                }
                    /*
                        for (int h = 0; h < Int32.Parse(raw); h++)
                        {
                            for (int g = 0; g < Int32.Parse(column); g++)
                            {
                                şifrelimetin = şifrelimetin + list_class.ElementAt(s).harf;
                                s++;
                            }

                            şifrelimetin = şifrelimetin + "\n";
                        }
                     */
                //textBox_yöntem2_output_sentence.Text = şifrelimetin;
                //MessageBox.Show(şifrelimetin);
                return şifrelimetin;

        }

        public void createTable_A4()
        {

            String şifrelimetin = createTable_E3(raw,column);
            String lastmetin = "";

            String ready_şifreli_metin = şifrelimetin.Replace(" ", "");
            //String ready_şifreli_metin = şifrelimetin;
            int s = ready_şifreli_metin.Length-1;
            for (int i = 0; i < ready_şifreli_metin.Length; i++)
            {
                lastmetin = lastmetin + ready_şifreli_metin[s].ToString();
                s -= 1;
            }
            label_ready_output_text1.Text = "E3 Matrisinden Filtreleme Sonucu Oluşan Matris";
            label_ready_output_text2.Text = "A4 Matrisinden Filtreleme Sonucu Oluşan Şifrelenmiş Matris";
            first_output_sentence.Text = şifrelimetin.Replace(" ","").ToUpper();
            şifreleme_deşifre_yöntem2_output_label.Text = lastmetin.ToUpper();
            şifreleme_deşifre_yöntem2_output_label.Visible = true;
            first_output_sentence.Visible = true;            
            label_ready_output_text1.Visible = true;
            label_ready_output_text2.Visible = true;           
        }

        public char findposition(List<MatrixItem> liste,int raw ,int column) {

            char harf = 'q';
            for (int j = 0; j < liste.Count; j++)
            {
                if (liste[j].raw == raw && liste[j].column == column)
                {
                    harf = liste[j].harf;
                }
            }
            return harf;         
        }

            public void kabarcikSirala(List<MatrixItem> siralanacakClass) {
 
            int i = 1,  j, deger,deger2;
            int diziAdet = siralanacakClass.Count;
            while (i < diziAdet)
            {
                j = diziAdet - 1;
                while (j >= 1)
                {
                    if (siralanacakClass[j-1].max_fark > siralanacakClass[j].max_fark)
                    {
                        deger = siralanacakClass[j].max_fark;
                        int temple_max_fark = siralanacakClass[j].max_fark;
                        int temple_raw = siralanacakClass[j].max_fark;
                        int temple_column = siralanacakClass[j].column;
                        siralanacakClass[j].max_fark = siralanacakClass[j - 1].max_fark;
                        siralanacakClass[j].raw = siralanacakClass[j - 1].raw;
                        siralanacakClass[j].column = siralanacakClass[j - 1].column;
                        siralanacakClass[j - 1].raw = temple_raw;
                        siralanacakClass[j - 1].column = temple_column;
                        siralanacakClass[j - 1].max_fark = deger;
                    }
                    else if (siralanacakClass[j - 1].max_fark == siralanacakClass[j].max_fark)
                    {
                        if (siralanacakClass[j - 1].column < siralanacakClass[j].column)
                        {
                            deger2 = siralanacakClass[j].column;
                            int temple_max_fark = siralanacakClass[j].max_fark;
                            int temple_raw = siralanacakClass[j].max_fark;
                            int temple_column = siralanacakClass[j].column;
                            siralanacakClass[j].column = siralanacakClass[j - 1].column;
                            siralanacakClass[j].raw = siralanacakClass[j - 1].raw;
                            siralanacakClass[j - 1].raw = temple_raw;
                            siralanacakClass[j - 1].column = deger2;
                        }
                    }
                    
                    j--;
                }
                i++;
            }

            /*
            for (int k = 0; k < int_raw; k++)
            {
                for (int m = 0; m < int_column; m++)
                {
                    //MessageBox.Show("k = " + k.ToString() + "" +list[k,m].ToString());
                    max_minicity_raw_column = int_raw - int_column;
                    if (max_minicity_raw_column > max_value)
                    {
                        max_value = max_minicity_raw_column;
                        dictionary_raw = int_raw;
                        dictionary_column = int_column;
                    }
                    else if (max_minicity_raw_column == max_value)
                    {
                        if (max_minicity_min_column > m)
                        {
                            max_minicity_min_column = m;
                            dictionary_raw = int_raw;
                            dictionary_column = int_column;
                        }
                    }

                }
            }
            MessageBox.Show(dictionary_raw.ToString() + dictionary_column.ToString());
             */
        }

            public static void kabarcikSirala2(List<MatrixItem> siralanacakDizi)
            {

                int i = 1, j;
                MatrixItem deger = new MatrixItem();
                int diziAdet = siralanacakDizi.Count;
                while (i < diziAdet)
                {
                    j = diziAdet - 1;
                    while (j >= 1)
                    {
                        if (siralanacakDizi[j - 1].column > siralanacakDizi[j].column)
                        {
                            deger = siralanacakDizi[j];
                            siralanacakDizi[j] = siralanacakDizi[j - 1];
                            siralanacakDizi[j - 1] = deger;
                        }
                        j--;
                    }
                    i++;
                }

                kabarcikSirala3(siralanacakDizi);
            }

            public static void kabarcikSirala3(List<MatrixItem> siralanacakDizi)
            {

                int i = 1, j;
                MatrixItem deger = new MatrixItem();
                int diziAdet = siralanacakDizi.Count;
                while (i < diziAdet)
                {
                    j = diziAdet - 1;
                    while (j >= 1)
                    {
                        if (siralanacakDizi[j - 1].max_fark < siralanacakDizi[j].max_fark)
                        {
                            deger = siralanacakDizi[j];
                            siralanacakDizi[j] = siralanacakDizi[j - 1];
                            siralanacakDizi[j - 1] = deger;
                        }
                        j--;
                    }
                    i++;
                }
            }

            private void textBox_yöntem2_input_sentence_TextChanged(object sender, EventArgs e)
            {
                if (textBox_yöntem2_input_sentence.Text.Length > 50)
                {
                    MessageBox.Show("50 HARF SINIRINI AŞTINIZ.EN FAZLA 50 HARF GİRİLEBİLİR.");
                    textBox_yöntem2_input_sentence.Text = "";
                }
            }

            private String deşifre_createTable_E3(String raw, String column,String matrix)
            {
                int z = 0;
                int int_raw = Int32.Parse(raw);
                int int_column = Int32.Parse(column);
                List<MatrixItem> list_class = new List<MatrixItem>();
                int indexofline = matrix.IndexOf("\n");
                column = indexofline.ToString();
                int count = 0;
                int columncounter = 0;
                List<Char> listmetin = new List<char>();
           

                for (int i = 0; i < matrix.Length; i++)
                {                   

                    if (matrix[i] == '\n')
                    {

                        count++;
                        columncounter = -1;
                        //list_class.Add(new MatrixItem(count, columncounter, count - columncounter, matrix[i+1]));
                        //continue;
                    }
                    if (matrix[i] != '\n')
                    {
                        MatrixItem matrixitem = new MatrixItem();
                        matrixitem.raw = count;
                        matrixitem.column = columncounter;
                        matrixitem.max_fark = count - columncounter;
                        matrixitem.harf = matrix[i];
                        list_class.Add(matrixitem);

                        //list_class.Add(new MatrixItem(count, columncounter+1, count - columncounter-1, matrix[i]));
                    }
                    //MessageBox.Show("RAW : " + count + "COLUMN : " + columncounter + "harf :" + matrix[i]);
                    if (matrix[i] != '\n')
                    {
                        columncounter++;
                    }
                }

                raw = count.ToString();
                column = columncounter.ToString();
                /*
                foreach (MatrixItem element in list_class)
                {
                    MessageBox.Show("RAW : " + element.raw + "COLUMN : "+ element.column +" maxfark" + element.max_fark+ " harf :" + element.harf);
                }
                 
                
                /*
                for (int k = 0; k < int_raw; k++)
                {
                    for (int m = 0; m < int_column; m++)
                    {
                        int max_degerler = k - m;
                       
                       
                        MatrixItem matrixitem = new MatrixItem();
                        matrixitem.max_fark = max_degerler;
                        matrixitem.raw = k;
                        matrixitem.column = m;
                        list_class.Add(matrixitem);

                    }
                }
                 */
                
                //RAW VE COLUMN FARKI OLARAK EN BÜYÜK OLANDAN EN KÜÇÜK OLANA SIRALAMA          
                //kabarcikSirala(list_class);
                //kabarcikSirala2(list_class);
                ll(list_class);
                String şifrelimetin = "";
                for (int i = 0; i < list_class.Count; i++)
                {
                   //MessageBox.Show("RAW : " +list_class[i].raw + "Column : "+list_class[i].column  + "max fark : " +list_class[i].max_fark + "harf : " +list_class[i].harf.ToString());
                    şifrelimetin = şifrelimetin + list_class[i].harf;
                
                }
                String şifrelimetin3 = "";
                şifrelimetin3 = şifrelimetin.Replace("\r", string.Empty).Replace("\n", string.Empty);
                    /*
                    for (int i = 0; i < list_class.Count; i++)
                    {
                        şifrelimetin = şifrelimetin + list_class[i].harf;
                    }

                    /*
                    String realmetin = "";
                    List<Char> listt = new List<char>();
                    foreach (MatrixItem element in list_class)
                    {
                        listt.Add(element.harf);

                    }

                    realmetin = realmetin + string.Join("",listt.ToArray());

                    return realmetin;
                    */
                    /*
                    String şifrelimetin = "";
                    int s = 0;
                    for (int e = 0; e < list_class.Count; e++)
                    {
                        list_class.ElementAt(e).harf = metin[e];
                    }
                 
                    String şifrelimetin = "";
                    
                    for (int x = 0; x < Int32.Parse(raw); x++)
                    {
                        for (int r = 0; r < Int32.Parse(column); r++)
                        {

                            char harf = findposition(list_class, x, r);
                            şifrelimetin = şifrelimetin + "  " + harf;
                        }
                    */
                        //şifrelimetin = şifrelimetin + "\r\n";
                    
                //MessageBox.Show(şifrelimetin);
                String şifrelimetin2 = "";
                int counter = 0;
                for (int i = 0; i < şifrelimetin3.Length; i++)
                {
                    if (şifrelimetin3[i] == 'x')
                    {
                        counter = i;
                        break;
                    }
                }
                if (counter != 0)
                {
                    şifrelimetin2 = şifrelimetin3.Substring(0, counter);
                    return şifrelimetin2;
                }
                else
                {
                    return şifrelimetin3;
                }
            }
                           

        public void ll(List<MatrixItem> listelele) {

            for (int y = 0; y < listelele.Count-1; y++)
            {

                for (int i = 0; i < listelele.Count-1; i++)
                {
                    if (listelele[i].max_fark < listelele[i + 1].max_fark)
                    {
                        int templeraw = listelele[i + 1].raw;
                        int templecolumn = listelele[i + 1].column;
                        int templemaxfark = listelele[i + 1].max_fark;
                        char harf = listelele[i + 1].harf;
                        listelele[i + 1].raw = listelele[i].raw;
                        listelele[i + 1].column = listelele[i].column;
                        listelele[i + 1].max_fark = listelele[i].max_fark;
                        listelele[i + 1].harf = listelele[i].harf;
                        listelele[i].raw = templeraw;
                        listelele[i].column = templecolumn;
                        listelele[i].max_fark = templemaxfark;
                        listelele[i].harf = harf;
                    }
                    else if (listelele[i].max_fark == listelele[i + 1].max_fark)
                    {
                        if (listelele[i].column > listelele[i + 1].column)
                        {
                            int templeraw = listelele[i + 1].raw;
                            int templecolumn = listelele[i + 1].column;
                            int templemaxfark = listelele[i + 1].max_fark;
                            char harf = listelele[i + 1].harf;
                            listelele[i + 1].raw = listelele[i].raw;
                            listelele[i + 1].column = listelele[i].column;
                            listelele[i + 1].max_fark = listelele[i].max_fark;
                            listelele[i + 1].harf = listelele[i].harf;
                            listelele[i].raw = templeraw;
                            listelele[i].column = templecolumn;
                            listelele[i].max_fark = templemaxfark;
                            listelele[i].harf = harf;
                        }
                    }
                }
            }
        }

            private void comboBox_yöntem2_şifreleme_deşifre_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (comboBox_yöntem2_şifreleme_deşifre.GetItemText(comboBox_yöntem2_şifreleme_deşifre.SelectedItem).Equals("DEŞİFRE"))
                {
                    comboBox_yöntem2_table_measurement.Enabled = false;
                }
                else if (comboBox_yöntem2_şifreleme_deşifre.GetItemText(comboBox_yöntem2_şifreleme_deşifre.SelectedItem).Equals("ŞİFRELEME"))
                {
                    comboBox_yöntem2_table_measurement.Enabled = true;
                }
            }

            private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)13)
                {
                    devam = true;
                    // Enter key pressed
                }
                else
                {
                    devam = false;
                }
            }

            private void textBox_yöntem2_input_sentence_TextChanged_1(object sender, EventArgs e)
            {

                    String topla = textBox_yöntem2_input_sentence.Text.ToLower();

                    if (textBox_yöntem2_input_sentence.Text.Length != 0)
                    {
                        if (!Char.IsLetter((char)topla[topla.Length - 1]) && devam == false)
                        {
                            MessageBox.Show("Şifreleme/Deşifre giriş paneline yalnızca harfler girilebilir");
                            textBox_yöntem2_input_sentence.Text = "";
                            topla = "";
                        }

                        if (comboBox_dilseçenegi.GetItemText(comboBox_dilseçenegi.SelectedItem).Equals("İNGİLİZCE"))
                        {
                            if (!check_metin_İnglizce(textBox_yöntem2_input_sentence.Text))
                            {
                                char harf = harf_İnglizce(textBox_yöntem2_input_sentence.Text);
                                if (harf != ' ')
                                {
                                    MessageBox.Show("'" + harf + "'" + " İngilizce alfabesinde bulunmamaktadır.Lütfen başka harf giriniz.");
                                }
                                textBox_yöntem2_input_sentence.Text = "";
                            }
                        }
                        else if (comboBox_dilseçenegi.GetItemText(comboBox_dilseçenegi.SelectedItem).Equals("TÜRKÇE"))
                        {
                            if (!check_metin_Türkçe(textBox_yöntem2_input_sentence.Text))
                            {
                                char harf = harf_Türkçe(textBox_yöntem2_input_sentence.Text);
                                if (harf != ' ')
                                {
                                    MessageBox.Show("'" + harf + "'" + " Türkçe alfabesinde bulunmamaktadır.Lütfen başka harf giriniz.");
                                }
                                textBox_yöntem2_input_sentence.Text = "";
                            }
                        }
                    }                         
            }

            public void check_panel_size(){

                if (şifreleme_deşifre_yöntem2_output_label.Location.X > panel1.Location.X || şifreleme_deşifre_yöntem2_output_label.Location.Y > panel1.Location.Y)
                {
                    panel1.Size = new Size(panel1.Height + şifreleme_deşifre_yöntem2_output_label.Height,panel1.Width + şifreleme_deşifre_yöntem2_output_label.Width);
                }


            }

            public Boolean check_metin_İnglizce(String metin)
            {
                Boolean ingilizce = false;

                foreach (char harf in metin)
                {
                    if (harf == 'ç' || harf == 'ğ' || harf == 'ö' || harf == 'ı' || harf == 'ş' || harf == 'ü')
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
                    if (harf == 'ç' || harf == 'ğ' || harf == 'ö' || harf == 'ı' || harf == 'ş' || harf == 'ü')
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
                    if (harf == 'q' || harf == 'w' || harf == 'x')
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
                    if (harf == 'x' || harf == 'q' || harf == 'w')
                    {
                        c = harf;
                    }
                }
                return c;
            }

            private void comboBox_dilseçenegi_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (comboBox_dilseçenegi.GetItemText(comboBox_dilseçenegi.SelectedItem).Equals("İNGİLİZCE"))
                {
                    if (!check_metin_İnglizce(textBox_yöntem2_input_sentence.Text))
                    {
                        char harf = harf_İnglizce(textBox_yöntem2_input_sentence.Text);
                        if (harf != ' ')
                        {
                            MessageBox.Show("'" + harf + "'" + " İngilizce alfabesinde bulunmamaktadır.Lütfen başka harf giriniz.");
                        }
                        textBox_yöntem2_input_sentence.Text = "";
                    }

                }
                else if (comboBox_dilseçenegi.GetItemText(comboBox_dilseçenegi.SelectedItem).Equals("TÜRKÇE"))
                {
                    if (!check_metin_Türkçe(textBox_yöntem2_input_sentence.Text))
                    {
                        char harf = harf_Türkçe(textBox_yöntem2_input_sentence.Text);
                        if (harf != ' ')
                        {
                            MessageBox.Show("'" + harf + "'" + " Türkçe alfabesinde bulunmamaktadır.Lütfen başka harf giriniz.");
                        }
                        textBox_yöntem2_input_sentence.Text = "";
                    }
                }
            }

            private void button_run_information_application_Click(object sender, EventArgs e)
            {

                MessageBox.Show("YOL ŞİFRELEME DEŞİFRE METHOD matris yapılarını kullanarak şifreleme ve deşifre yapar.Kullanıcıdan alınan şifrelenecek olan metin bilgisindeki harf sayısı alınır.Eğer harf sayısı asal sayıysa asal olmayana kadar metinin sonuna X eklenir ve metnin harf sayısına göre oluşabilecek matris boyutları belirlenir.Matris boyutu seçildikten sonra matrisin en son satırından ve ilk sütünundan başlayarak ilk satır ve son sütuna gidecek şekilde diagonal şekillerde matris yapısına dönüştürülür ve daha sonra elde edilen matris tersten yazılır ve şifreli matris elde edilmiş olur."+
                    "Şifreli matris deşifre edileceği zaman şifrelemenin tersi yapılır ve önceden eklenmiş olan X harfleri atılır ve açık metin elde edilmiş olur.");
               
            }

            private void button_rules_information_Click(object sender, EventArgs e)
            {

                MessageBox.Show("1)Şifreleme/Deşifre yapılacak LÜTFEN ŞİFRELEME/DEŞİFRE YAPILACAK VERİYİ GİRİNİZ kısmına yalnızca harfler girilmelidir."
                   + "\n" + "2)Şifreleme yapmak için bilgi girişi yapılırken matris yapısında olmayan açık metin(Şifreleme yapılacak olan metin) küçük harflerle ve boşluksuz olarak girilmelidir." + "\n" +
                   "3)Deşifre edilecek veri matris olarak yazılmalıdır.Matris yazılırken satır ve sütunlarıyla birlikte harfler arasında boşluk bırakmadan büyük harflerle yazılmalıdır." + "\n" + "\n" +
                   " Şifreleme ve deşifre yapmak için ilk olarak DİL SEÇENEĞİ kısmından dil seçimini ve ŞİFRELEME/DEŞİFRE kısmından şifreleme yapmak istiyorsanız şifreleme , deşifre yapmak istiyorsanız deşifre seçeneğini seçiniz."
                   + "'" + " LÜTFEN ŞİFRELEME/DEŞİFRE YAPILACAK VERİYİ GİRİNİZ " + "'" + "yazısının altındaki boşluğu doldurunuz." + "'" + " METNİ İŞLE BUTONUNA BASINIZ. " + "'"
                   + "Şifreleme yapacaksanız yapılacak bu işlem sonrasında olası tablo boyutları uygulamanın sağ tarafında görüntülenecektir.Tablo boyutlarından birini seçiniz.Seçilen tablo boyutuna göre şifreleme işlemi gerçekleştirilecektir."
                   + "Eğer aynı metin farklı bir tablo boyutunda şifreleme yapılmak istenirse " + "'" + " METNİ İŞLE" + "'" + "butonunu tekrardan kullanmaya gerek olmadan tablo boyutlarından seçim yapıldığında sonuçlar görüntülenecek,farklı bir metinde işlem yapılmak istenirse metin bilgisi girildikten sonra tekrardan METNİ İŞLE butonuna tıklanmalıdır."
                   + " ŞİFRELEME/DEŞİFRE SONRASI VERİ " + "yazısının altında şifrelemeye ve deşifreye dair bilgiler görüntülenecektir.Method tekrardan kullanılmak istenirse TEMİZLE butonu kullanıldığında eski bilgiler temizlenerek uygulama yeniden hazır hale gelecektir.Uygulamada şifreleme ve deşifre işlemleri için farklı bir method kullanılmak istenirse ANA MENÜYE DÖN butonuna tıklandığında uygulama menüsüne dönüş gerçekleştirilecektir.");       
            }

            private void first_output_sentence_SizeChanged(object sender, EventArgs e)
            {
                label_ready_output_text2.Top = first_output_sentence.Bottom + 20;
                şifreleme_deşifre_yöntem2_output_label.Top = label_ready_output_text2.Bottom + 20;
            }

    }
}
                                                                                        