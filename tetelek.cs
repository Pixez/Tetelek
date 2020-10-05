/////////////////////////////////////////////////////////
// Jakab Magor tulajdona és kódja
// Saját kódként feltüntetés szigoruan tilos!
/////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetelek
{
    class Program
    {
        static void Main(string[] args)
        {
            Tetel Tetelek = new Tetel(); ///hivatkozás a Tetel osztályra. Muszály!

            /////////////////////////////////////////////////////
            // Alap Tételek
            /////////////////////////////////////////////////////
            int[] A = { 1, 23, 43, 52, 21, 2, 3, 4 };
            Console.WriteLine("Az (A) Halmaz: {0}",Kiir(A,A.Length));

            Console.WriteLine("Összegzés:");
            Console.WriteLine("A halmaz elemeinek összege: {0}", Tetelek.Osszegzes(A));

            Console.WriteLine("Átlag:");
            Console.WriteLine("A halmaz elemeinek átlaga: {0}", Tetelek.Atlag(A));

            Console.WriteLine("Megszámlálás:");
            Console.WriteLine("A 50 -nél alacsonyabb számok darabszáma: {0}", Tetelek.Megszamlalas(A));

            Console.WriteLine("Kiválasztás:");
            Console.WriteLine("Az első 50 nél nagyobb szám: {0}",Tetelek.Kivalasztas(A));

            /////////////////////////////////////////////////////
            // Kereső tételek
            /////////////////////////////////////////////////////
            Console.WriteLine("Eldöntés:");
            if (Tetelek.Eldontes(A))
            {
                Console.WriteLine("Van benne 50");
            }
            else
            {
                Console.WriteLine("Nincs benne 50");
            }

            Console.WriteLine("Lineáris Keresés:");
            if (Tetelek.LinearisKereses(A)!=-1)
            {
                Console.WriteLine("Az első 50 -nél nagyobb szám helye(0 -tól számolva): {0}",Tetelek.LinearisKereses(A));
            }
            else
            {
                Console.WriteLine("Nincs benne 50 -nél nagyobb szám");
            }

            /////////////////////////////////////////////////////
            // Szélső Érték Tételek
            /////////////////////////////////////////////////////
            Console.WriteLine("A Szélső értékei:");
            Console.WriteLine("Min: {0}",Tetelek.SzelsoErtek.Min(A));

            Console.WriteLine("Max: {0}",Tetelek.SzelsoErtek.Max(A));

            /////////////////////////////////////////////////////
            // Válogatásos Tételek
            /////////////////////////////////////////////////////
            Console.WriteLine("Kiválogatás:");
            Console.WriteLine("Az 50-nél kissebb számok az A halmazban: {0}",Kiir(Tetelek.Kivalogatas(A).Item1, Tetelek.Kivalogatas(A).Item2));

            Console.WriteLine("Szétválogatás:");
            Console.WriteLine("Az 50-nél kissebb számok az A halmazban: {0}",Kiir(Tetelek.Szetvalogatas(A).Item1, Tetelek.Szetvalogatas(A).Item2));
            Console.WriteLine("Az 50-nél nagyobb számok az A halmazban: {0}", Kiir(Tetelek.Szetvalogatas(A).Item3, Tetelek.Szetvalogatas(A).Item4));

            /////////////////////////////////////////////////////
            // Metszet, Únió
            /////////////////////////////////////////////////////
            int[] B = { 73, 100, 43, 49, 57, 21, 23, 92, 1 };
            Console.WriteLine("A (B) Halmaz: {0}",Kiir(B,B.Length));

            Console.WriteLine("Metszet:");
            Console.WriteLine("(M) Az A és B halmaz metszete: {0}", Kiir(Tetelek.Metszet(A, B).Item1, Tetelek.Metszet(A, B).Item2));

            Console.WriteLine("Unió:");
            Console.WriteLine("(U) Az A és B halmaz uniója: {0}", Kiir(Tetelek.Unio(A, B).Item1, Tetelek.Unio(A, B).Item2));

            /////////////////////////////////////////////////////
            // Rendezés Tételek
            /////////////////////////////////////////////////////
            Tetelek.Rendezes.JavitottBuborekos(A);
            Console.WriteLine("A rendezett (A) Halmaz: {0}", Kiir(A, A.Length));
            Console.ReadKey();
        }

        //////////////////////////////////////////////////////////////
        // Kiírás fügvény
        // Haszna: Kiír egy halmazt
        // Bemenete: Halmaz, Halmaz számossága
        //////////////////////////////////////////////////////////////
        
        static string Kiir(int[] A,int n)
        {
            string kiiras = "";
            for (int i = 0; i < n - 1; i++)
            {
                kiiras = kiiras + A[i] + ",";
            }
            return kiiras + A[n - 1];
        }
    }
    public class Tetel
    {
        //////////////////////////////////////////////////////////////
        // Összegzés fügvény
        // Haszna: Visszaadja az adott halmaz elemeinek összegét
        // Bemenete: Halmaz
        //////////////////////////////////////////////////////////////
        public int Osszegzes(int[] A)
        {
            int szum = 0;
            for (int i = 0; i < A.Length; i++)
            {
                szum = szum + A[i];
            }
            return szum;
        }
        //////////////////////////////////////////////////////////////
        // Átlag fügvény
        // Haszna: Visszaadja az adott halmaz elemeinek átlagát
        // Bemenete: Halmaz
        //////////////////////////////////////////////////////////////
        public double Atlag(int[] A)
        {
            int szum = 0;
            for (int i = 0; i < A.Length; i++)
            {
                szum = szum + A[i];
            }
            double atlag = (double)szum / A.Length;
            return atlag;
        }

        //////////////////////////////////////////////////////////////
        // Megszámlálás fügvény
        // Haszna: Visszaadja a Halmaz elemeinek számát amelyek fegfelelnek egy adott tulajdonságnak
        // Bemenete: Halmaz
        //////////////////////////////////////////////////////////////
        public int Megszamlalas(int[] A)
        {
            int db = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < 50)
                {
                    db++;
                }
            }
            return db;
        }

        //////////////////////////////////////////////////////////////
        // Kiválasztás fügvény
        // Haszna: Feltételezve hogy van egy T tulajdonságú elem. Visszadja az első T tulajdonságú elem sorszámát
        // Bemenete: Halmaz
        //////////////////////////////////////////////////////////////
        public int Kivalasztas(int[] A)
        {
            int sorszam = 0;
            while (!(A[sorszam] < 50))
            {
                sorszam++;
            }
            return sorszam;
        }

        //////////////////////////////////////////////////////////////
        // Eldöntés fügvény
        // Haszna: Visszad egy igaz értéket ha van az adott halmazban T tulajdonságú elem,
        //         külömben a hamis értéket adja vissza
        // Bemenete: Halmaz
        //////////////////////////////////////////////////////////////
        public bool Eldontes(int[] A)
        {
            int x = 0;
            while (x < A.Length && !(A[x] == 50))
            {
                x++;
            }
            return x < A.Length;
        }

        //////////////////////////////////////////////////////////////
        // Lineáris Keresés fügvény
        // Haszna: Megkeresi az első T tulajdonságú elemet az adott halmazban és vissza adja annak sorszámát.
        //         Ha nem találja meg akkor visszaadja -1 értéket
        // Bemenete: Halmaz
        //////////////////////////////////////////////////////////////
        public int LinearisKereses(int[] A)
        {
            int x = 0;
            if (x < A.Length && !(A[x] > 50))
            {
                x++;
            }
            if (x < A.Length)
            {
                return x;
            }
            return -1;
        }

        //////////////////////////////////////////////////////////////
        // Kiválogatás fügvény
        // Haszna: Visszaadja egys adott halmazból kiszedett T tulajdonságú elemeket egy másik halmazba(B).
        //         A (B) halmaznak a számosságát is visszaadja a fügvény
        // Bemenete: Halmaz
        //////////////////////////////////////////////////////////////
        public (int[], int) Kivalogatas(int[] A)
        {
            int[] B = new int[A.Length];
            int bdb =0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < 50)
                {
                    B[bdb] = A[i];
                    bdb++;
                }
            }
            return (B, bdb);
        }

        //////////////////////////////////////////////////////////////
        // Szétválogatás fügvény
        // Haszna: Az adott halmazból kiválogatja a T tulajdonságú elemeket és azokat a (B) halmazba rakja.
        //         Amely elemek nem felelnek meg a T tulajdonságnak azokat a (C) halmazba adja vissza.
        //         Mindkettő(B, C) halmaznak a számosságát is visszaadja a függvény
        // Bemenete: Halmaz
        //////////////////////////////////////////////////////////////
        public (int[], int, int[], int) Szetvalogatas(int[] A)
        {
            int[] B = new int[A.Length];
            int[] C = new int[A.Length];
            int bdb = 0;
            int cdb = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < 50)
                {
                    B[bdb] = A[i];
                    bdb++;
                }
                else
                {
                    C[cdb] = A[i];
                    cdb++;
                }
            }
            return (B,bdb,C,cdb);
        }

        //////////////////////////////////////////////////////////////
        // Metszet fügvény
        // Haszna: Az (A) bemeneti, és (B) bemeneti halmazok azonos elemeit teszi be, és adja vissza a (M) halmazba.
        //         Az (M) halmaz számosságát is visszaadjuk
        // Bemenete: (A)Halmaz,(B)Halmaz
        //////////////////////////////////////////////////////////////
        public (int[], int) Metszet(int[] A, int[] B)
        {
            int[] M = new int[A.Length];
            int mdb = 0;
            int x;
            for (int i = 0; i < B.Length; i++)
            {
                x = 0;
                while (x < A.Length && !(A[x] == B[i]))
                {
                    x++;
                }
                if (x < A.Length)
                {
                    M[mdb] = B[i];
                    mdb++;
                }
            }
            return (M, mdb);
        }

        //////////////////////////////////////////////////////////////
        // Únió fügvény
        // Haszna: Az (A)bemeneti halmaz és (B)bemeneti halmaz elemeit egy (U)halmazba rakja, és küldi vissza.
        //         Azonos elemeket csak egyszer rak bele az (U)halmazba. A halmaz számosságát visszaküldjük
        // Bemenete: (A)Halmaz,(B)Halmaz
        //////////////////////////////////////////////////////////////
        public (int[], int) Unio(int[] A, int[] B)
        {
            int[] U = new int[A.Length + B.Length];
            int udb = 0;
            int x;
            for (int i = 0; i < A.Length; i++)
            {
                U[i] = A[i];
            }
            udb = A.Length;
            for (int i = 0; i < B.Length; i++)
            {
                x = 0;
                while (x < A.Length && !(A[x] == B[i]))
                {
                    x++;
                }
                if (!(x < A.Length))
                {
                    U[udb] = B[i];
                    udb++;
                }
            }
            return (U, udb);
        }

        //////////////////////////////////////////////////////////////
        // A másik osztályokra hivatkozás, hogy lehessen használni ezeket a Tetel részeként.
        //////////////////////////////////////////////////////////////
        public SzelsoErtek SzelsoErtek = new SzelsoErtek();
        public Rendezes Rendezes = new Rendezes();
        //////////////////////////////////////////////////////////////
    }

    //////////////////////////////////////////////////////////////
    // Szélsőérték osztály
    // Külön osztályba raktam mert ugyanannak a tételnek részei, de nem mindegy melyiket alkalmazzuk.
    //////////////////////////////////////////////////////////////
    public class SzelsoErtek
    {
        //////////////////////////////////////////////////////////////
        // Maximum fügvény
        // Haszna: Visszaadja az adott halmaz legnagyobb értékű elemének helyét
        // Bemenete: Halmaz
        //////////////////////////////////////////////////////////////
        public int Max(int[] A)
        {
            int hely = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > A[hely])
                {
                    hely = i;
                }
            }
            return A[hely];
        }

        //////////////////////////////////////////////////////////////
        // Maximum fügvény
        // Haszna: Visszaadja az adott halmaz legkissebb értékű elemének helyét
        // Bemenete: Halmaz
        //////////////////////////////////////////////////////////////
        public int Min(int[] A)
        {
            int hely = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < A[hely])
                {
                    hely = i;
                }
            }
            return A[hely];
        }
    }

    //////////////////////////////////////////////////////////////
    // Rendezés Tétele
    // Minden rendezés ezek között helyes. Az eggyetlen külömbség közöttük az az idő amig leirod, és az idő amig lefut a program.
    //////////////////////////////////////////////////////////////
    public class Rendezes
    {
        //////////////////////////////////////////////////////////////
        // Cserélő rendezés fügvény
        // Bemenete: Halmaz
        // Elve: Végigmegyünk a halmazon, Párokban összehasonlítjuk az elemeket és ha kell akkor cserélünk.
        //       Ezt ismételjük amig rendezett a halmaz
        // Megjegyzés: Az Alap rendezés fügvény. A leglassab rendezés ezek közül. Nincs eggyáltalán optimalizálva
        //////////////////////////////////////////////////////////////
        public void Cserelo(int[] A)
        {
            int seged;
            for (int k=0;k<A.Length;k++)
            {
                for (int b=0;b<A.Length;b++)
                {
                    seged = A[b];
                    A[b] = A[b + 1];
                    A[b + 1] = seged;
                }
            }
        }

        //////////////////////////////////////////////////////////////
        // Buborékos rendezés fügvény
        // Bemenete: Halmaz
        // Elve: Végigmegyünk a halmazon, Párokban összehasonlítjuk az elemeket és ha kell akkor cserélünk.
        //       Ezt ismételjük, de minden ismétléskor eggyel kevesebb elemet nézünk meg,
        //       mert minden ismétléskor az utolsó elem biztosan a jó helyen lessz.
        // Megjegyzés: Az Alap rendezésnél gyorsabb. Kicsit optimalizált
        //////////////////////////////////////////////////////////////
        public void Buborekos(int[] A)
        {
            int seged;
            for (int k = A.Length - 1; k >= 0; k--)
            {
                for (int b = 0; b < k; b++)
                {
                    if (A[b] > A[b + 1])
                    {
                        seged = A[b];
                        A[b] = A[b + 1];
                        A[b + 1] = seged;
                    }
                }
            }
        }

        //////////////////////////////////////////////////////////////
        // Javított Buborékos rendezés rendezés fügvény
        // Bemenete: Halmaz
        // Elve: Végigmegyünk a halmazon, Párokban összehasonlítjuk az elemeket és ha kell akkor cserélünk.
        //       Ezt ismételjük, de minden ismétléskor eggyel kevesebb elemet nézünk meg,
        //       mert minden ismétléskor az utolsó elem biztosan a jó helyen lessz.
        //       MInden ismétléskor megnézzük hogy az előző alkalommal történt -e csere, ha nem akkor a rendezés befejeződött.
        // Megjegyzés: Ez a rendezés ajánlott. Viszonylag gyors és Iskolai elvárásban ez a leg komplikáltabb amit kérnek.
        //////////////////////////////////////////////////////////////
        public void JavitottBuborekos(int[] A)
        {
            bool csere = true;
            int seged;
            for (int k = A.Length - 1; k >= 0 && csere; k--)
            {
                csere = false;
                for (int b = 0; b < k; b++)
                {
                    if (A[b] > A[b + 1])
                    {
                        seged = A[b];
                        A[b] = A[b + 1];
                        A[b + 1] = seged;
                        csere = true;
                    }
                }
            }
        }

        //////////////////////////////////////////////////////////////
        // BEillesztéses rendezés fügvény
        // Bemenete: Halmaz
        // Elve: Végig megyünk az összes elemen a halmazban és összehasonlítjuk az előző elemmel.
        //       Ha a szám kissebb mint az előző akkor az adott számot beíllesztjük a korrekt helyre és megjelőljük rendezettként.
        //       Ha az adott elem az első a ciklusban akkor rendezetnek jelöljük.
        // Megjegyzés: A kevenc rendezésem. Legrosszabb esetben olyan gyors mint a Buborékos rendezés, de átlagban gyorsabb.
        //////////////////////////////////////////////////////////////
        public void Beilleszteses(int[] A)
        {
            int seged;
            int j;
            for (int i = 0; i < A.Length; i++)
            {
                j = i;
                while (j > 0&&A[j-1]>A[j])
                {
                    seged = A[j];
                    A[j] = A[j - 1];
                    A[j - 1] = seged;
                    j--;
                }
            }
        }

        //////////////////////////////////////////////////////////////
        // Gyors rendezés fügvény
        // Bemenete: Halmaz,az első elem indexe,az utolsó elem indexe
        //           Tetelek.Rendezes.Gyors(A, 0, A.Lenght-1);
        // Elve: Kijelölünk egy elemet melyet megjelölünk a pivot -ként.Tőle balra helyezzük a kisebb elemek, tőle jobbra a nagyobbakat.
        //       Ezt ismételjük mig rendeződik a halmaz.
        // Megjegyzés: A leggyorsabb rendezés. DE kifejezetten össszetett a többi rendezéshez képest.
        //             Iskolai használatra nem ajánlott.
        //             A Partition fügyvény a rendezéshez tartozik/kötelető.
        //////////////////////////////////////////////////////////////
        public void Gyors(int[] A, int bal, int jobb)
        {
            if (bal < jobb)
            {
                int pivot = Partition(A, bal, jobb);

                if (pivot > 1)
                {
                    Gyors(A, bal, pivot - 1);
                }
                if (pivot + 1 < jobb)
                {
                    Gyors(A, pivot + 1, jobb);
                }
            }
        }
        private int Partition(int[] A, int bal, int jobb)
        {
            int seged;
            int pivot = A[bal];
            while (true)
            {
                while (A[bal] < pivot)
                {
                    bal++;
                }
                while (A[jobb] > pivot)
                {
                    jobb--;
                }
                if (bal < jobb)
                {
                    if (A[bal] == A[jobb]) return jobb;

                    seged = A[bal];
                    A[bal] = A[jobb];
                    A[jobb] = seged;
                }
                else
                {
                    return jobb;
                }
            }
        }
    }
}
