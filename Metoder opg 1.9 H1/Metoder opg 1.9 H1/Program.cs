using System;

namespace Metoder_opg_1._9_H1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Lav et array der indeholder 7 tilfældige lottoTal mellem 1 og 20.Dette er vinder-kuponen.
              Lav nu endnu et array med 7 tal der repræsenterer en brugers kupon.
              I kan lade brugeren indtaste de 7 tal, eller i kan ”hardcode” brugerens kupon.
              Undersøg hvor mange rigtige tal der er på brugerens kupon, og udbetal forskellige gevinster 
              på kuponer der har mere end to rigtige.*/

            

            int antal = 0; // Erklærer en variabel til at holde styr på hvor mange rigtige der er

            int[] lottoTal = new int[7]; //Laver et array med 7 pladser

            FyldArrayRandom(lottoTal, 1, 100);

            Udskrift(lottoTal);

            int[] kupon = { 5, 8, 13, 24, 68, 70, 91 };//Laver et array mere med faste værdier

            TomLinje();// udskriver tom linje for pænere visuelt udtryk

            Udskrift(kupon);
            
            TomLinje();
            antal = Gevinst(lottoTal, kupon);

            AntalRigtige(antal);        

            Console.ReadKey();//"Fastholder" programmet
        }
        
        //Opretter metode til tom linje
        public static void TomLinje()
        {
            Console.WriteLine();
        }
        
        //Opretter metode til udskrift
        public static void Udskrift(int [] arraynavn)
        {
            foreach (int tal in arraynavn)
            {
                Console.WriteLine(tal);
            }

        }
        
        //Opretter metode til at fylde tilfældige tal i arrayet
        public static void FyldArrayRandom(int[] arraynavn, int min, int max)
        {
            Random r = new Random();
            for (int i = 0; i < arraynavn.Length; i++) //indsætter tilfældige tal i arrayet
            {
                int ran = r.Next(min, max);
                arraynavn[i] = ran;
              
            }


        }
        //Opretter metode til at tjekke om de udtrykne tal optræder på kuponen
        public static int Gevinst(int[] lottoTal, int[] kupon)
        {
            Array.Sort(kupon); //sørger for at kuponen er sorteret ellers kan man ikke lave binarysearch
            int antal = 0;
            for (int i = 0; i < lottoTal.Length; i++) //tjekker om lottotallene optræder på kuponen
            {
                int answer = Array.BinarySearch(kupon, lottoTal[i]);//bruger binary search til at gennemløbe kuponen

                if (answer >= 0)//hvis tallet er >= 0 betyder det at tallet optræder i kupon arrayet
                {
                    antal++; //tæller 1 op for hver "rigtig" i den binære search
                }
               
            }return antal;

        } 
        //Opretter metode til at udskrive antal rigtige samt præmie
        public static void AntalRigtige(int antal)
        {
            switch (antal) //bruger switch til at udskrive til brugeren antal rigtige og præmie
            {
                case 0:
                case 1:
                    Console.WriteLine("Desværre ikke nok rigtige");
                    break;
                case 2:
                    Console.WriteLine("Du har 2 rigtige, præmien er 35 kr");
                    break;
                case 3:
                    Console.WriteLine("Du har 3 rigtige, præmien er 70 kr");
                    break;
                case 4:
                    Console.WriteLine("Du har 4 rigtige, præmien er 250 kr");
                    break;
                case 5:
                    Console.WriteLine("Du har 5 rigtige, præmien er 1000 kr");
                    break;
                case 6:
                    Console.WriteLine("Du har 6 rigtige, præmien er 5000 kr");
                    break;
                case 7:
                    Console.WriteLine("TILLYKKE Du har 7 rigtige, præmien er 1.000.000 kr");
                    break;

                default:
                    break;
            }



        }
    }
}
