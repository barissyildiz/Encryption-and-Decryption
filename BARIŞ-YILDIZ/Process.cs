using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARIŞ_YILDIZ
{
    class Process
    {
        private String metin;
        private String anahtarkelime;
        private String outputmetin;
        private double aralık;
        public List<Char> listİngilizce;
        public List<Char> listTürkçe;
        public Dictionary<Char, Char> listencrypted;
        public String label_key1, label_key2, label_key3;

        public Process()
        {
            metin = this.metin;
            anahtarkelime = this.anahtarkelime;
            aralık = this.aralık;
            listİngilizce = this.listİngilizce;
            listTürkçe = this.listTürkçe;
            outputmetin = this.outputmetin;
            listİngilizce = new List<Char>();
            listTürkçe = new List<Char>();
            listencrypted = new Dictionary<Char, Char>();           

            for (Char c = 'a'; c <= 'z'; c++)
            {
                listİngilizce.Add(c);
            }
            listTürkçe.Add('a');
            listTürkçe.Add('b');
            listTürkçe.Add('c');
            listTürkçe.Add('ç');
            listTürkçe.Add('d');
            listTürkçe.Add('e');
            listTürkçe.Add('f');
            listTürkçe.Add('g');
            listTürkçe.Add('ğ');
            listTürkçe.Add('h');
            listTürkçe.Add('i');
            listTürkçe.Add('ı');
            listTürkçe.Add('j');
            listTürkçe.Add('k');
            listTürkçe.Add('l');
            listTürkçe.Add('m');
            listTürkçe.Add('n');
            listTürkçe.Add('o');
            listTürkçe.Add('ö');
            listTürkçe.Add('p');
            listTürkçe.Add('r');
            listTürkçe.Add('s');
            listTürkçe.Add('ş');
            listTürkçe.Add('t');
            listTürkçe.Add('u');
            listTürkçe.Add('ü');
            listTürkçe.Add('v');
            listTürkçe.Add('y');
            listTürkçe.Add('z');
        }

        public void setMetin(String yenimetin)
        {
            metin = yenimetin;
        }
        public String getMetin()
        {
            return metin;
        }

        public void setAnahtarKelime(String yeniAnahtarKelime)
        {
            anahtarkelime = yeniAnahtarKelime;
        }

        public String getAnahtarKelime()
        {
            return anahtarkelime;
        }

        public void setAralık(int yeniaralık)
        {
            aralık = double.Parse(yeniaralık.ToString());
        }

        public double getAralık()
        {
            return aralık;
        }

        public String getOutputMetin()
        {
            return outputmetin;
        }

        public void decimateKeyWord()
        {
            

            List<Char> harflist = new List<Char>();
            List<int> repeatvalues = new List<int>();
            int counter = 0;

            for (int i = 0; i < anahtarkelime.Length; i++)
            {
                harflist.Add(anahtarkelime[i]);
            }
            
                for (int i = 0; i < harflist.Count; i++)
                {
                    Char harf = harflist[i];
                    counter++;

                    for (int y = counter; y < harflist.Count; y++)
                    {
                        if (harflist[y] == harf)
                        {
                            //harflist.RemoveAt(y);
                            harflist[y] = ' ';
                        }
                    }
                }

            List<Char> finallist = new List<char>();

            for (int z = 0; z < harflist.Count; z++)
            {
                if (harflist[z] != ' ')
                {
                    finallist.Add(harflist[z]);
                }
            }


                anahtarkelime = string.Join("", finallist.ToArray());
                label_key1 = anahtarkelime;            
        
        }

        public void decimateKeyWordAddLetter(String dilseçeneği)
        {
            if (dilseçeneği.Equals("İNGİLİZCE"))
            {
                List<Char> harflist = new List<Char>();
                List<Char> templateListİnglizce = new List<Char>();
                templateListİnglizce = listİngilizce.ToList();

                for (int i = 0; i < anahtarkelime.Length; i++)
                {
                    harflist.Add(anahtarkelime[i]);
                }

                for (int i = 0; i < anahtarkelime.Length; i++)
                {
                    Char harf = anahtarkelime[i];

                    for (int y = 0; y < templateListİnglizce.Count; y++)
                    {
                        if (templateListİnglizce[y] == harf)
                        {
                            templateListİnglizce.RemoveAt(y);
                        }
                    }
                }
                anahtarkelime = anahtarkelime + string.Join("", templateListİnglizce.ToArray());
                label_key2 = anahtarkelime;
            }
            else if (dilseçeneği.Equals("TÜRKÇE"))
            {
                List<Char> harflist = new List<Char>();
                List<Char> templateListTürkçe = new List<Char>();
                templateListTürkçe = listTürkçe.ToList();

                for (int i = 0; i < anahtarkelime.Length; i++)
                {
                    harflist.Add(anahtarkelime[i]);
                }

                for (int i = 0; i < anahtarkelime.Length; i++)
                {
                    Char harf = anahtarkelime[i];

                    for (int y = 0; y < templateListTürkçe.Count; y++)
                    {
                        if (templateListTürkçe[y] == harf)
                        {
                            templateListTürkçe.RemoveAt(y);
                        }
                    }
                }
                anahtarkelime = anahtarkelime + string.Join("", templateListTürkçe.ToArray());
                label_key2 = anahtarkelime;
            }
        }

        public void encryptedtext()
        {
            List<Char> listfinaltext = new List<Char>();
            List<Char> templatetext = new List<Char>();

            foreach (char element in anahtarkelime)
            {
                templatetext.Add(element);
            }

            double counter = 0.0;
            List<char> listeindex = new List<char>();

            do
            {

                for (int i = 0; i < templatetext.Count; i++)
                {
                    counter++;

                    if (aralık / counter == 1.0)
                    {

                        listfinaltext.Add(templatetext[i]);
                        listeindex.Add(templatetext[i]);
                        counter = 0;

                    }
                    if (templatetext.Count < aralık)
                    {

                        foreach (char element in templatetext.ToList())
                        {
                            listfinaltext.Add(element);
                            templatetext.Remove(element);
                        }
                    }
                }

                if (templatetext.Count >= aralık)
                {
                    foreach (char element in listeindex)
                    {
                        templatetext.Remove(element);
                    }
                    listeindex.Clear();
                }

            } while (templatetext.Count != 0);

            anahtarkelime = string.Join("", listfinaltext.ToArray());
            label_key3 = anahtarkelime;
        }

        public void createDictionary(String dilseçeneği)
        {

            if (dilseçeneği.Equals("İNGİLİZCE"))
            {
                listencrypted.Clear();

                for (int i = 0; i < listİngilizce.Count; i++)
                {
                    listencrypted.Add(listİngilizce[i], anahtarkelime[i]);
                }

            }
            else if (dilseçeneği.Equals("TÜRKÇE"))
            {
                listencrypted.Clear();

                for (int i = 0; i < anahtarkelime.Length; i++)
                {
                    listencrypted.Add(listTürkçe[i], anahtarkelime[i]);
                }
            }
        }

        public void secondencryptedtext()
        {
            List<Char> listcharmetin = new List<Char>();

            foreach (char element in metin)
            {
                listcharmetin.Add(listencrypted[element]);
            }

            outputmetin = string.Join("", listcharmetin.ToArray());
        }

        public void createDictionary2(String dilseçeneği)
        {

            if (dilseçeneği.Equals("İNGİLİZCE"))
            {
                listencrypted.Clear();

                for (int i = 0; i < listİngilizce.Count; i++)
                {
                    listencrypted.Add(anahtarkelime[i], listİngilizce[i]);
                }

            }
            else if (dilseçeneği.Equals("TÜRKÇE"))
            {
                listencrypted.Clear();

                for (int i = 0; i < anahtarkelime.Length; i++)
                {
                    listencrypted.Add(anahtarkelime[i], listTürkçe[i]);
                }
            }
        }

        public void küçükharfler()
        {
            String newmetin = metin.ToLower();
            metin = newmetin;

        }
    }
}
