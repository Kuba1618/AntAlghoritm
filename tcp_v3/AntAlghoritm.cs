using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class AntAlghoritm
    {
        int iloscmrowek;
        int iloscrund;

        double feromon;
        // stworzenie tablicy, która jest zbiorem miast/punktów
        static int[,] numbers = { { 2, 0, 1 }, { 7, 2, 2 }, { 11, 5, 3 }, { 16, 3, 4 }, { 0, 4, 5 }, { 1, 14, 6 }, { 8, 22, 7 }, { 14, 17, 8 }, { 12, 15, 9 }, { 6, 10, 10 }, { 6, 20, 11 }, { 12, 19, 12 }, { 15, 12, 13 }, { 9, 14, 14 }, { 20, 7, 15 }, { 3, 3, 16 }, { 4, 17, 17 }, { 9, 15, 18 }, { 10, 10, 19 }, { 19, 19, 20 } };

        int iloscmiast = numbers.Length / 3;

        AntAlghoritm() { }

        public AntAlghoritm(int iloscmrowek, int iloscrund, double feromon)
        {
            this.iloscmrowek = iloscmrowek;
            this.iloscrund = iloscrund;
            this.feromon = feromon;
        }

        public void metoda1()
        {
            Random rnd = new Random();
            double[,] trasyiichwyniki = new double[iloscmrowek, iloscmiast + 2];
            int ilosckombinacji = 0;
            int ff = iloscmiast;
            double[,] wszyscyzwyciezcy = new double[iloscrund, iloscmiast + 2];
            for (int j = 0; j < iloscmiast - 1; j++)
            {
                ilosckombinacji = ilosckombinacji + ff - 1;
                ff = ff - 1;
            }

            double[,] krawedziebezzmian2 = new double[ilosckombinacji, 3];

            for (int j = 0; j < ilosckombinacji; j++)
            {
                krawedziebezzmian2[j, 2] = feromon;
            }

            for (int y = 0; y < iloscrund; y++)
            {
                for (int u = 0; u < iloscmrowek; u++)
                {
                    int poczatek = 0;
                    int koniec = iloscmiast;
                    int wylosowana = rnd.Next(poczatek, koniec);

                    double[,] krawedziebezzmian = new double[ilosckombinacji, 4];

                    double[,] krawedzie = new double[ilosckombinacji, 4];
                    double[,] arrayskip = new double[krawedzie.GetLength(0), krawedzie.GetLength(1)];
                    int a = iloscmiast;
                    int o = iloscmiast;
                    int b = iloscmiast;
                    int x = 0;

                    for (int j = 0; j < ilosckombinacji; j++)
                    {
                        o = o - 1;
                        if (o == 0)
                        {
                            a = a - 1;
                            o = a - 1;
                        }
                        b = b - 1;

                        if (b == 0)
                        {
                            x = x + 1;
                            b = iloscmiast - 1 - x;
                        }
                        krawedzie[j, 0] = int.Parse(a.ToString());
                        krawedzie[j, 1] = int.Parse(b.ToString());
                        krawedziebezzmian[j, 0] = int.Parse(a.ToString());
                        krawedziebezzmian[j, 1] = int.Parse(b.ToString());
                    }

                    for (int j = 0; j < ilosckombinacji; j++)
                    {
                        krawedzie[j, 2] = feromon;
                        krawedziebezzmian[j, 2] = feromon;
                    }
                    for (int j = 0; j < ilosckombinacji; j++)
                    {
                        krawedzie[j, 2] = krawedziebezzmian2[j, 2];
                    }

                    for (int j = 0; j < ilosckombinacji; j++)
                    {
                        int pierwsza = Convert.ToInt32(krawedzie[j, 0]);
                        int druga = Convert.ToInt32(krawedzie[j, 1]);

                        int aX = numbers[pierwsza - 1, 0] - numbers[druga - 1, 0];
                        int aY = numbers[pierwsza - 1, 1] - numbers[druga - 1, 1];
                        double distancea = Math.Sqrt(aX * aX + aY * aY);

                        krawedzie[j, 3] = distancea;
                        krawedziebezzmian[j, 3] = distancea;
                    }

                    int wylosowana1 = wylosowana + 1;
                    string wylosowana1str = wylosowana1.ToString();

                    int[] nieodwiedzone = new int[iloscmiast];
                    int hh = 0;
                    for (int i = 0; i < iloscmiast; i++)
                    {
                        if (i != wylosowana)
                        {
                            nieodwiedzone[hh] = i + 1;
                        }
                        else
                        {
                            hh = hh - 1;
                        }
                        hh = hh + 1;
                    }

                    Array.Resize(ref nieodwiedzone, iloscmiast - 1);
                    int[] ostatecznywynik = new int[iloscmiast + 1];
                    ostatecznywynik[0] = wylosowana1;

                    int[] dostepnywybortras = new int[iloscmiast - 1];
                    int zm1 = 0;
                    for (int i = 0; i < krawedzie.GetLength(0); i++)
                    {
                        string tostr = krawedzie[i, 0].ToString();
                        string tostr2 = krawedzie[i, 1].ToString();

                        if ((tostr == wylosowana1str) || (tostr2 == wylosowana1str))
                        {
                            dostepnywybortras[zm1] = i;
                            zm1 = zm1 + 1;
                        }
                    }

                    double sumaprawd = 0;
                    double[] tabprawd = new double[dostepnywybortras.GetLength(0)];
                    double p = 0;
                    int q = 0;

                    double krawedzdousuniecia = 0;

                    for (int k = 0; k < (iloscmiast - 1); k++)
                    {

                        sumaprawd = 0;
                        for (int i = 0; i < dostepnywybortras.GetLength(0); i++)
                        {
                            for (int j = 0; j < krawedzie.GetLength(0); j++)
                            {
                                if (dostepnywybortras[i] == j)
                                {
                                    sumaprawd = sumaprawd + (krawedzie[j, 2] * (1 / (krawedzie[j, 3] * krawedzie[j, 3])));
                                }
                            }
                        }
                        Random random = new Random();
                        double losowa = random.Next(0, 1000);

                        losowa = losowa / 1000;

                        tabprawd = new double[dostepnywybortras.GetLength(0)];
                        p = 0;
                        q = 0;

                        for (int i = 0; i < dostepnywybortras.GetLength(0); i++) //5 --> 4 --> 3
                        {
                            for (int j = 0; j < krawedzie.GetLength(0); j++)
                            {
                                if (dostepnywybortras[i] == j)
                                {
                                    tabprawd[i] = (krawedzie[j, 2] * (1 / (krawedzie[j, 3] * krawedzie[j, 3]))) / sumaprawd;
                                    p = p + tabprawd[i];

                                    if (losowa < p)
                                    {
                                        if (q == 0)
                                        {
                                            krawedzdousuniecia = j;

                                            trasyiichwyniki[u, 0] = trasyiichwyniki[u, 0] + krawedzie[j, 3];

                                            if (wylosowana1 == krawedzie[j, 0])
                                            {
                                                ostatecznywynik[k + 1] = Convert.ToInt32(krawedzie[j, 1]);
                                            }

                                            else
                                            {
                                                ostatecznywynik[k + 1] = Convert.ToInt32(krawedzie[j, 0]);
                                            }

                                            int indexToRemove = i;
                                            nieodwiedzone = nieodwiedzone.Where((source, index) => index != indexToRemove).ToArray();
                                        }
                                        q = q + 1;
                                    }
                                }
                            }
                        }

                        int wylosowana2;

                        if (krawedzie[Convert.ToInt32(krawedzdousuniecia), 0] == wylosowana1)
                        {
                            wylosowana2 = Convert.ToInt32(krawedzie[Convert.ToInt32(krawedzdousuniecia), 1]);
                        }
                        else
                        {
                            wylosowana2 = Convert.ToInt32(krawedzie[Convert.ToInt32(krawedzdousuniecia), 0]);
                        }

                        for (int i = 0; i < krawedzie.GetLength(0); i++)
                        {
                            for (int j = 0; j < krawedzie.GetLength(1); j++)
                            {

                                int doubletoint2 = Convert.ToInt32(krawedzie[i, 0]);
                                int doubletoint3 = Convert.ToInt32(krawedzie[i, 1]);

                                if ((doubletoint2 == wylosowana1) || (doubletoint3 == wylosowana1))
                                {
                                    krawedzie[i, 0] = 0;
                                    krawedzie[i, 1] = 0;
                                }
                            }
                        }

                        wylosowana1str = wylosowana1.ToString();
                        zm1 = 0;

                        wylosowana1 = wylosowana2;

                        //Console.WriteLine("DOSTEPNY WYBOR TRAS");
                        for (int i = 0; i < krawedzie.GetLength(0); i++)
                        {
                            double tostr = krawedzie[i, 0];
                            double tostr1 = krawedzie[i, 1];
                            if (wylosowana1 == tostr || wylosowana1 == tostr1)
                            {
                                dostepnywybortras[zm1] = i;
                                zm1 = zm1 + 1;
                            }
                        }

                        Array.Resize(ref dostepnywybortras, dostepnywybortras.GetLength(0) - 1);

                    }

                    ostatecznywynik[iloscmiast] = ostatecznywynik[0];


                    string zbiortras = ostatecznywynik[0].ToString();
                    for (int i = 0; i < ostatecznywynik.GetLength(0); i++)
                    {
                        trasyiichwyniki[u, i + 1] = ostatecznywynik[i];
                    }

                    for (int i = 0; i < krawedziebezzmian.GetLength(0); i++)
                    {
                        if (ostatecznywynik[iloscmiast] == krawedziebezzmian[i, 0] && ostatecznywynik[iloscmiast - 1] == krawedziebezzmian[i, 1] || ostatecznywynik[iloscmiast - 1] == krawedziebezzmian[i, 0] && ostatecznywynik[iloscmiast] == krawedziebezzmian[i, 1])
                        {
                            trasyiichwyniki[u, 0] = trasyiichwyniki[u, 0] + krawedzie[i, 3];
                        }
                    }
                }


                //Console.WriteLine("TRASA NAJLEPSZEJ MROWKI: --------------------------------------");
                double[] najlepszatrasa = new double[iloscmiast + 1];// = trasyiichwyniki[0, 1];
                double dlugoscnalepszejtrasy = trasyiichwyniki[0, 0];
                for (int i = 0; i < iloscmiast + 1; i++)
                {
                    najlepszatrasa[i] = trasyiichwyniki[0, i + 1];
                }

                for (int i = 1; i < iloscmrowek; i++)
                {
                    if (dlugoscnalepszejtrasy > trasyiichwyniki[i, 0])
                    {
                        for (int j = 0; j < iloscmiast + 1; j++)
                        {
                            najlepszatrasa[j] = trasyiichwyniki[i, j + 1];
                        }
                        dlugoscnalepszejtrasy = trasyiichwyniki[i, 0];
                    }
                }

                for (int i = 0; i < iloscmiast + 1; i++)
                {
                    wszyscyzwyciezcy[y, i + 1] = najlepszatrasa[i];
                }

                wszyscyzwyciezcy[y, 0] = dlugoscnalepszejtrasy;

                for (int i = 0; i < iloscmrowek; i++)
                {
                    trasyiichwyniki[i, 0] = 0;
                }

                int aa = iloscmiast;
                int oo = iloscmiast;
                int bb = iloscmiast;
                int xx = 0;

                for (int j = 0; j < ilosckombinacji; j++)
                {
                    oo = oo - 1;
                    if (oo == 0)
                    {
                        aa = aa - 1;
                        oo = aa - 1;
                    }

                    bb = bb - 1;

                    if (bb == 0)
                    {
                        xx = xx + 1;
                        bb = iloscmiast - 1 - xx;
                    }
                    krawedziebezzmian2[j, 0] = int.Parse(aa.ToString());
                    krawedziebezzmian2[j, 1] = int.Parse(bb.ToString());
                }

                for (int j = 0; j < (iloscmiast); j++)
                {
                    for (int i = 0; i < ilosckombinacji; i++)
                    {
                        if ((najlepszatrasa[j].ToString() == krawedziebezzmian2[i, 0].ToString() && najlepszatrasa[j + 1].ToString() == krawedziebezzmian2[i, 1].ToString()) || (najlepszatrasa[j].ToString() == krawedziebezzmian2[i, 1].ToString() && najlepszatrasa[j + 1].ToString() == krawedziebezzmian2[i, 0].ToString()))
                        {
                            krawedziebezzmian2[i, 2] = krawedziebezzmian2[i, 2] * 1.1;
                        }
                    }
                }

            }
            double ostatecznyzwyciezca = wszyscyzwyciezcy[0, 0];
            int z = 0;
            for (int j = 0; j < iloscrund; j++)
            {
                //Console.WriteLine(wszyscyzwyciezcy[j, 0]);
                if (ostatecznyzwyciezca > wszyscyzwyciezcy[j, 0])
                {
                    ostatecznyzwyciezca = wszyscyzwyciezcy[j, 0];
                    z = j;
                }

            }

            //Console.WriteLine("koncowy wynik");
            Console.WriteLine(ostatecznyzwyciezca);
            for (int j = 1; j < iloscmiast + 2; j++)
            {
                Console.Write(wszyscyzwyciezcy[z, j]);
                Console.Write(",");
            }


            string path = @"C:\Users\jakub\Desktop\" +
                               "aaa" + ".txt";

            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(ostatecznyzwyciezca);
                }
            }
            else
            {
                // This text is always added, making the file longer over time
                // if it is not deleted.
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("Trasa 5:");
                    sw.WriteLine(ostatecznyzwyciezca);
                }
            }

        }

    }
}


//!!!!!!!!!!!Uruchomienie ALgorytmu!!!!!!!!
//AntAlghoritm alg = new AntAlghoritm(50, 15, 1);
//alg.metoda1();