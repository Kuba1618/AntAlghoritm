using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcp_v3
{
    public class AntAlghoritm
    {
        double alfa = 1;
        double beta = 1;
        int numberOfAnts;
        int numberOfRounds;
        int roundNumber = 0;
        double finalWinner;
        string path1 = @"C:\Users\jakub\Desktop\wyniki\" + "results_new_5_1" + ".txt";
        string path2 = @"C:\Users\jakub\Desktop\wyniki\" + "pythonData" + ".txt";

        double pheromone;
        // stworzenie tablicy, która jest zbiorem miast/punktów
        static int[,] numbers = { { 2, 0, 1 }, { 7, 2, 2 }, { 11, 5, 3 }, { 16, 3, 4 }, { 0, 4, 5 }, { 1, 14, 6 }, { 8, 22, 7 }, { 14, 17, 8 }, { 12, 15, 9 }, { 6, 10, 10 }, { 6, 20, 11 }, { 12, 19, 12 }, { 15, 12, 13 }, { 9, 14, 14 }, { 20, 7, 15 }, { 3, 3, 16 }, { 4, 17, 17 }, { 9, 15, 18 }, { 10, 10, 19 }, { 19, 19, 20 } };
        int numberOfCities = numbers.Length / 3;
        int numberOfCombinations = 0;
        double lengthTheBestRoute;
        double[,] allWinners;
        double[,] krawedziebezzmian;
        double[,] krawedziebezzmian2;
        double[] theBestRoute; // the sequence of visited cities
        double[,] routsWithTheirResults;
        int[] ostatecznywynik;
        double[,] krawedzie;

        AntAlghoritm() { }

        public AntAlghoritm(int iloscmrowek, int iloscrund, double feromon)
        {
            this.numberOfAnts = iloscmrowek;
            this.numberOfRounds = iloscrund;
            this.pheromone = feromon;
        }

        public void sendTheAntsOnTheRoad()
        {
            Random rnd = new Random();
            routsWithTheirResults = new double[numberOfAnts, numberOfCities + 2];

            allWinners = new double[numberOfRounds, numberOfCities + 2]; // +2, bo kolumna ostatnia powatarza się (jest równa pierwszej)
                                                                         //  oraz w zerowej zapisujemy długość trasy
            int ff = numberOfCities;

            for (int j = 0; j < numberOfCities - 1; j++)
            {
                numberOfCombinations = numberOfCombinations + ff - 1;
                ff = ff - 1;
            }

            krawedziebezzmian2 = new double[numberOfCombinations, 3];

            for (int j = 0; j < numberOfCombinations; j++)
            {
                krawedziebezzmian2[j, 2] = pheromone;
            }


            for (roundNumber = 0; roundNumber < numberOfRounds; roundNumber++)
            {
            for (int u = 0; u < numberOfAnts; u++)
            {
                int poczatek = 0;
                int koniec = numberOfCities;
                int wylosowana = rnd.Next(poczatek, koniec);

                krawedziebezzmian = new double[numberOfCombinations, 4];

                krawedzie = new double[numberOfCombinations, 4];
                double[,] arrayskip = new double[krawedzie.GetLength(0), krawedzie.GetLength(1)];

                int a = numberOfCities;
                int o = numberOfCities;
                int b = numberOfCities;
                int x = 0;

                for (int j = 0; j < numberOfCombinations; j++)
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
                        b = numberOfCities - 1 - x;
                    }
                    krawedzie[j, 0] = int.Parse(a.ToString());
                    krawedzie[j, 1] = int.Parse(b.ToString());
                    krawedziebezzmian[j, 0] = int.Parse(a.ToString());
                    krawedziebezzmian[j, 1] = int.Parse(b.ToString());
                }

                for (int j = 0; j < numberOfCombinations; j++)
                {
                    krawedzie[j, 2] = pheromone;
                    krawedziebezzmian[j, 2] = pheromone;
                }
                for (int j = 0; j < numberOfCombinations; j++)
                {
                    krawedzie[j, 2] = krawedziebezzmian2[j, 2];
                }

                for (int j = 0; j < numberOfCombinations; j++)
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

                int[] nieodwiedzone = new int[numberOfCities];
                int hh = 0;
                for (int i = 0; i < numberOfCities; i++)
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

                Array.Resize(ref nieodwiedzone, numberOfCities - 1);
                ostatecznywynik = new int[numberOfCities + 1];
                ostatecznywynik[0] = wylosowana1;

                int[] dostepnywybortras = new int[numberOfCities - 1];
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

                for (int k = 0; k < (numberOfCities - 1); k++)
                {

                    sumaprawd = 0;
                    for (int i = 0; i < dostepnywybortras.GetLength(0); i++)
                    {
                        for (int j = 0; j < krawedzie.GetLength(0); j++)
                        {
                            if (dostepnywybortras[i] == j)
                            {
                                sumaprawd = sumaprawd + (Math.Pow(krawedzie[j, 2], alfa) * Math.Pow((1 / (krawedzie[j, 3] * krawedzie[j, 3])), beta));
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
                                tabprawd[i] = (Math.Pow(krawedzie[j, 2], alfa) * Math.Pow((1 / (krawedzie[j, 3] * krawedzie[j, 3])), beta)) / sumaprawd;
                                p = p + tabprawd[i];

                                if (losowa < p)
                                {
                                    if (q == 0)
                                    {
                                        krawedzdousuniecia = j;

                                        routsWithTheirResults[u, 0] = routsWithTheirResults[u, 0] + krawedzie[j, 3];

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

                    //Console.WriteLine("DOSTEPNY WYBOR TRAS:");
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

                saveResultsAllOfWaysInCurrentIteration(u);

            }


            saveTheBestWayOfCurrentIteration();

            saveLengthTheBestWayInCurrentIteration();

            // ---------------------------------TU WYSŁAĆ DO SERWERA--------------------------------------------------------!!!!               
            // ---------------------------------ODEBRAĆ WYNIKI Z SERWERA I ZAPISAĆ--------------------------------------------------------!!!!               
            saveResultsAllOfWinners();
            updatePheronomeAmount();
            //roundNumber++;
            }

            chooseTheFinalWinner();  //to zrobić w programie serwera ???

            saveResultToFile();
        }

        public void saveResultsAllOfWaysInCurrentIteration(int u)
        {
            ostatecznywynik[numberOfCities] = ostatecznywynik[0];


            string zbiortras = ostatecznywynik[0].ToString();
            for (int i = 0; i < ostatecznywynik.GetLength(0); i++)
            {
                routsWithTheirResults[u, i + 1] = ostatecznywynik[i];
            }

            for (int i = 0; i < krawedziebezzmian.GetLength(0); i++)
            {
                if (ostatecznywynik[numberOfCities] == krawedziebezzmian[i, 0] && ostatecznywynik[numberOfCities - 1] == krawedziebezzmian[i, 1] || ostatecznywynik[numberOfCities - 1] == krawedziebezzmian[i, 0] && ostatecznywynik[numberOfCities] == krawedziebezzmian[i, 1])
                {
                    routsWithTheirResults[u, 0] = routsWithTheirResults[u, 0] + krawedzie[i, 3];
                }
            }
        }

        public void saveTheBestWayOfCurrentIteration()
        {
            //Console.WriteLine("TRASA NAJLEPSZEJ MROWKI: --------------------------------------");
            theBestRoute = new double[numberOfCities + 1];// numberOfCities + 1 bo miasto 1 i ostatnie się powtarzają

            lengthTheBestRoute = routsWithTheirResults[0, 0];

            for (int i = 0; i < numberOfCities + 1; i++)
            {
                theBestRoute[i] = routsWithTheirResults[0, i + 1];
                Console.Write(theBestRoute[i] + ",");
            }
        }

        public void saveLengthTheBestWayInCurrentIteration()
        {
            for (int i = 1; i < numberOfAnts; i++)
            {
                if (lengthTheBestRoute > routsWithTheirResults[i, 0])
                {
                    for (int j = 0; j < numberOfCities + 1; j++)
                    {
                        theBestRoute[j] = routsWithTheirResults[i, j + 1]; //wysłać theBestRoute do serwera
                    }
                    lengthTheBestRoute = routsWithTheirResults[i, 0];
                }
            }
            Console.WriteLine("\n" + lengthTheBestRoute);
        }

        public void saveResultsAllOfWinners()
        {
            for (int i = 0; i < numberOfCities + 1; i++)
            {
                allWinners[roundNumber, i + 1] = theBestRoute[i];
            }

            allWinners[roundNumber, 0] = lengthTheBestRoute; //wysłać lengthTheBestRoute do serwera

            for (int i = 0; i < numberOfAnts; i++)
            {
                routsWithTheirResults[i, 0] = 0;
            }
        }

        public void updatePheronomeAmount()
        {
            int aa = numberOfCities;
            int oo = numberOfCities;
            int bb = numberOfCities;
            int xx = 0;

            for (int j = 0; j < numberOfCombinations; j++)
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
                    bb = numberOfCities - 1 - xx;
                }
                krawedziebezzmian2[j, 0] = int.Parse(aa.ToString()); //Można nazwać po prostu krawędzie
                krawedziebezzmian2[j, 1] = int.Parse(bb.ToString());
            }

            for (int j = 0; j < (numberOfCities); j++)
            {
                for (int i = 0; i < numberOfCombinations; i++)
                {
                    if ((theBestRoute[j].ToString() == krawedziebezzmian2[i, 0].ToString() && theBestRoute[j + 1].ToString() == krawedziebezzmian2[i, 1].ToString()) || (theBestRoute[j].ToString() == krawedziebezzmian2[i, 1].ToString() && theBestRoute[j + 1].ToString() == krawedziebezzmian2[i, 0].ToString()))
                    {
                        krawedziebezzmian2[i, 2] = krawedziebezzmian2[i, 2] * 1.1; //aktualizacja Feromonu
                    }
                }
            }

        }

        public void chooseTheFinalWinner()
        {
            int z = 0;
            finalWinner = allWinners[0, 0];

            for (int j = 0; j < numberOfRounds; j++)
            {
                //Console.WriteLine(allWinners[j, 0]);
                if (finalWinner > allWinners[j, 0])
                {
                    finalWinner = allWinners[j, 0];
                    z = j;
                }

            }

            //Console.WriteLine("koncowy wynik");
            Console.WriteLine("\n\n" + finalWinner);

            //showAllWinersAfterIteration(z);
            saveResultsForPythonVisualization(z);

        }

        public void showAllWinersAfterIteration(int z)
        {
            for (int j = 1; j < numberOfCities + 2; j++)
            {
                Console.Write(allWinners[z, j]);
                Console.Write(",");
            }
        }

        public void saveResultsForPythonVisualization(int z)
        {
            File.Delete(path2);
            using (StreamWriter writer = new StreamWriter(path2, true)) //// true to append data to the file
            {

                for (int j = 1; j < numberOfCities + 2; j++)
                {
                    writer.Write(allWinners[z, j]);
                    writer.Write(",");
                }
                writer.WriteLine();
                for (int j = 0; j < numberOfCities; j++)
                {
                    writer.Write("[");
                    writer.Write(numbers[j, 0]);
                    writer.Write(",");
                    writer.Write(numbers[j, 1]);
                    writer.Write("]");
                    writer.Write(";");
                }

                //writer.WriteLine();
                //writer.WriteLine(numbers);
            }
        }

        public void saveResultToFile()
        {
            DateTime thisMoment = DateTime.Now;
            if (!File.Exists(path1))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path1))
                {
                    sw.Write(thisMoment.ToString("g") + "       Długość trasy: ");
                    sw.WriteLine(finalWinner);
                }
            }
            else
            {
                // This text is always added, making the file longer over time
                // if it is not deleted.
                using (StreamWriter sw = File.AppendText(path1))
                {
                    sw.Write(thisMoment.ToString("g") + "       Długość trasy: ");
                    sw.WriteLine(finalWinner);
                }
            }
        }
    }
}


//!!!!!!!!!!!Uruchomienie ALgorytmu!!!!!!!!
//AntAlghoritm alg = new AntAlghoritm(50, 15, 1);
//alg.sendTheAntsOnTheRoad();