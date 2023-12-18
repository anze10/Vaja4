using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_vaja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] imena = { "Franc", "Marija", "Janez", "Ana", "Marko", "Maja", "Ivan", "Irena", "Anton", "Mojca", "Andrej", "Mateja", "Jožef", "Nina", "Jože", "Nataša", "Luka", "Andreja", "Peter", "Barbara", "Marjan", "Jožica", "Matej", "Petra", "Tomaž", "Eva", "Milan", "Anja", "Aleš", "Katja", "Branko", "Sara", "Bojan", "Sonja", "Robert", "Tatjana", "Rok", "Jožefa", "Boštjan", "Katarina", "Matjaž", "Tanja", "Gregor", "Tina", "Miha", "Milena", "Stanislav", "Alenka", "Martin", "Vesna", "David", "Nika", "Igor", "Martina", "Jan", "Majda", "Dejan", "Urška", "Boris", "Ivana", "Dušan", "Špela", "Nejc", "Tjaša", "Žiga", "Frančiška", "Jure", "Anica", "Uroš", "Helena", "Alojz", "Dragica", "Blaž", "Darja", "Žan", "Nada", "Mitja", "Terezija", "Simon", "Kristina", "Matic", "Simona", "Klemen", "Lara", "Darko", "Danica", "Primož", "Marjeta", "Jernej", "Olga", "Anže", "Suzana", "Gašper", "Zdenka", "Drago", "Neža", "Aleksander", "Lidija", "Jaka", "Ema" };

            string[] priimki = { "Novak", "Horvat", "Kovačič", "Krajnc", "Zupančič", "Potočnik", "Kovač", "Mlakar", "Vidmar", "Kos", "Golob", "Turk", "Kralj", "Božič", "Korošec", "Bizjak", "Zupan", "Hribar", "Kotnik", "Rozman", "Kavčič", "Kastelic", "Oblak", "Hočevar", "Petek", "Kolar", "Žagar", "Košir", "Koren", "Klemenčič", "Zajc", "Knez", "Medved", "Petrič", "Zupanc", "Pirc", "Hrovat", "Pavlič", "Kuhar", "Lah", "Zorko", "Tomažič", "Uršič", "Erjavec", "Babič", "Sever", "Jerman", "Jereb", "Kovačević", "Kranjc", "Majcen", "Rupnik", "Pušnik", "Breznik", "Lesjak", "Perko", "Dolenc", "Močnik", "Furlan", "Pečnik", "Pavlin", "Vidic", "Logar", "Jenko", "Petrović", "Ribič", "Žnidaršič", "Janežič", "Tomšič", "Marolt", "Jelen", "Pintar", "Blatnik", "Maček", "Dolinar", "Černe", "Gregorič", "Hren", "Mihelič", "Cerar", "Zadravec", "Fras", "Kokalj", "Lešnik", "Bezjak", "Hodžić", "Leban", "Čeh", "Rus", "Jug", "Vidovič", "Kocjančič", "Jovanović", "Kobal", "Bogataj", "Kolenc", "Primožič", "Marković", "Lavrič", "Kolarič" };

            char[] skupine = new char[100];

            int[] moc = new int[100];

            int[] zdravje = new int[100];

            int[] mrtvi = new int[100];

            int[] statistika = new int[4];

            stocrk(skupine);

            dodajmoc(skupine, moc);

            napolnizdravje(skupine, zdravje);

            int maks = najmoc(moc);
            Console.WriteLine("Najec moci ima vojak {0} {1}, ki je {2} ima {3} moci in {4} zdravja", imena[maks], priimki[maks], skupine[maks], moc[maks], zdravje[maks]);
            int mini = najmn(moc);
            Console.WriteLine("Najman moci ima vojak {0} {1}, ki je {2} ima {3} moci in {4} zdravja", imena[mini], priimki[mini], skupine[mini], moc[mini], zdravje[mini]);
            vojan(zdravje, moc);

            preveri_mrtve(zdravje, moc, mrtvi, skupine, priimki, imena,statistika);

           int id_vodje = poisci_vodjo(skupine, moc, zdravje);
            Console.WriteLine("Vodja je bojevnik  {0} {1}", imena[id_vodje], priimki[id_vodje]);
            skupno_zdravje(skupine,zdravje);

        }
        public static void stocrk(char[] skupine)
        {
            Random rnd = new Random();
            for (int i = 0; i < skupine.Length; i++)
            {
                int a = rnd.Next(4);
                switch (a)
                {
                    case 0:
                        skupine[i] = 'B';
                        break;
                    case 1:
                        skupine[i] = 'Z';
                        break;
                    case 2:
                        skupine[i] = 'L';
                        break;
                    case 3:
                        skupine[i] = 'N';
                        break;
                }
            }
        }
        public static void dodajmoc(char[] skupine, int[] moc)
        {
            Random random = new Random();
            for (int i = 0; i < skupine.Length; i++)
            {
                switch (skupine[i])
                {
                    case 'B':
                        moc[i] = random.Next(90, 101);
                        break;
                    case 'Z':
                        moc[i] = random.Next(80, 91);
                        break;
                    case 'L':
                        moc[i] = random.Next(70, 81);
                        break;
                    case 'N':
                        moc[i] = random.Next(60, 71);
                        break;
                }

            }
        }
        public static void napolnizdravje(char[] skupine, int[] zdravje)
        {
            Random random = new Random();
            for (int i = 0; i < skupine.Length; i++)
            {
                if (skupine[i] == 'Z')
                {
                    zdravje[i] = random.Next(80, 101);
                }
                else
                {
                    zdravje[i] = random.Next(10, 101);
                }
            }
        }
        public static int najmoc(int[] moc)
        {
            int vrni = 0;
            int navecja_moc = 0;
            for (int i = 0; i < moc.Length; i++)
            {
                if (moc[i] > navecja_moc)
                {
                    navecja_moc = moc[i];
                    vrni = i;
                }

            }

            return vrni;
        }
        public static int najmn(int[] moc)
        {
            int vrni_min = 0;
            int najmanjsa_moc = 100;
            for (int i = 0; i < moc.Length; i++)
            {
                if (moc[i] < najmanjsa_moc)
                {
                    najmanjsa_moc = moc[i];
                    vrni_min = i;
                }

            }

            return vrni_min;

        }
        public static void vojan(int[] zdravje, int[] moc)
        {
            Random random = new Random();
            for (int i = 0; i < zdravje.Length; i++)
            {

                zdravje[i] -= random.Next(10, 91);


                moc[i] -= random.Next(10, 21);
                if (moc[i] <= 0 || zdravje[i] <= 0)
                {
                    moc[i] = 0;
                    zdravje[i] = 0;
                }
            }



        }
        public static void preveri_mrtve(int[] zdravje,int[] moc,int[] mrtvi,char[] skupine,string[] priimki,string[] imena, int[] statistika) {
            int B = 0;
            int Z = 0;
            int L = 0;
            int N = 0;
            for (int i = 0;i < zdravje.Length;i++)
            {
                if (zdravje[i] == 0)
                {
                    if (moc[i] == 0)
                    {
                        mrtvi[i] = 1;
                        switch(skupine[i])
                        {
                            case 'B':
                                B++;
                                break;
                            case 'Z':
                                Z++;
                                break;
                            case 'L':
                                L++;
                                break;
                            case 'N':
                                N++;
                                break;
                        }
                    }
                    else { Console.WriteLine("Error"); }
                    
                }
                else
                {
                    mrtvi[i] = 0;
                }
                
            }
            Console.WriteLine("Umrlo je {0} bojevnikov,{1} zdravilcev, {2} lovcev in {3} nabiralcev", B, Z, L, N);
            for(int i = 0; i < mrtvi.Length;i++) {
                if (mrtvi[i] == 1)
                {
                    Console.WriteLine("Umrel je {0} {1}, ki je bil {2}", imena[i], priimki[i], skupine[i]);
                }
            }
        }
        public static int poisci_vodjo(char[] skupine,int [] moc,int[] zdravje)
        {
            int vodja = 0;
            double pov = 0;
            double pov_naj = 0;
            for(int i = 0; i < skupine.Length; i++)
            {
                if (skupine[i] == 'B')
                {
                    pov = (moc[i]+zdravje[i])/2;
                    if (pov > pov_naj)
                    {
                        pov_naj = pov;
                        vodja = i;
                    }

                }
            }
            skupine[vodja] = 'V';
            return vodja;
        }
        public static void skupno_zdravje(char[] skupine, int[] zdravje)
        {   int counter = 0;
            int Zdravilci = 0;
            int Bojevniki = 0;
            for (int i = 0;i < skupine.Length; i++)
            {
                if (skupine[i] == 'Z')
                {
                    Zdravilci += zdravje[i];
                }
                if(skupine[i] == 'B')
                {   
                    Console.WriteLine("{0} {1} {2}",skupine[i], zdravje[i], counter);
                    counter++;
                    Bojevniki += zdravje[i];
                }

            }
            Console.WriteLine("Skupno zdravje zdravilcev je {0} skupno zdravje bojevnikov pa {1}",Zdravilci,Bojevniki);
        }
    }
}
