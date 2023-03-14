

using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace exam
{
    class Human
    {
        private float chance = 100;
        Random Rnd = new Random();
        public enum EquationType
        {
            ADD,
            SUBTRACT,
            DIVIDE,
            MULTIPLY
        }

        public float doEquation(int x, int y, EquationType type, float chance=100)
        {

            if (Rnd.Next(0, 100) > chance)
            {
                return Rnd.Next(-38469, 38469);
            }

            switch (type)
            {

                case EquationType.ADD:
                    return x + y;

                case EquationType.SUBTRACT:
                    return x - y;

                case EquationType.DIVIDE:
                    return x / y;

                case EquationType.MULTIPLY:
                    return x * y;

                default:
                    return 0;

            }
        }

        public DateTime getTime()
        {
            return DateTime.Now;
        }
    }

    class StupidHuman : Human
    {
        public float chance = 69.5F;
    }
    class IntelligentHuman : Human { }

    class MainClass
    {
        private static short humans = 2;

        public static void Main(String[] args)
        {

            IntelligentHuman intelligentHuman = new IntelligentHuman();
            StupidHuman stupidHuman = new StupidHuman();
            while (true)
            {

             //WTF!
            ChooseHuman:
                Console.WriteLine("Aby wybrać osobę z która chcesz rozmawiać, wybierz liczbę która znajduje się przed ich nazwą.\n" +
                "1.Intelligent Human\n" +
                "2.Stupid Human\n");
                try
                {
                    int chosenHuman = Int32.Parse(Console.ReadLine());

                    while (true)
                    {

                        Console.WriteLine("Wybierz akcję:\n" +
                            "1.Działanie matematyczne\n" +
                            "2.Wybierz inną osobę do rozmowy\n" +
                            "3.Wyjdź z programu\n" +
                            "4.Spytaj o godzinę\n");

                        int taskInput = Int32.Parse(Console.ReadLine()); 

                        switch (taskInput)
                        {
                            case 1:

                                Console.WriteLine("Wybierz działanie:\n" +
                                    "1.Dodawanie\n" +
                                    "2.Odejmowanie\n" +
                                    "3.Dzielenie\n" +
                                    "4.Mnożenie\n");


                                int equationType = Int32.Parse(Console.ReadLine());


                                Console.WriteLine("Wybierz pierwszą liczbę");
                                int num1 = Int32.Parse(Console.ReadLine());

                                Console.WriteLine("Wybierz drugą liczbę");
                                int num2 = Int32.Parse(Console.ReadLine());

                                float result;


                                //OGOLNIE TO moglem to zrobic o wiele prosciej robiac intelligenthuman human i
                                //stupidhuman human w ifach ale zauwazylem to za puzno i juz mi sie nie chce pierdolic z tym ngl
                                switch (chosenHuman)
                                {
                                    case 1:
                                        result=intelligentHuman.doEquation(num1, num2, (Human.EquationType) equationType - 1);

                                        break;

                                    case 2: 
                                        result=stupidHuman.doEquation(num1, num2, (Human.EquationType) equationType - 1, stupidHuman.chance);

                                        break;
                                    default:
                                        // TYLKO ZEBY UNIKNAC BLEDU
                                        result = 53;
                                        break;
                                }

                                Console.WriteLine("Wynik:" + result +"\n");

                                break;

                            case 2:

                                // ale mondre jprd
                                goto ChooseHuman;

                            case 3:

                                Environment.Exit(1);
                                break;

                            case 4:

                                //tutaj to samo co z linijki 117 
                                //uzywam stupidhumana bez powodu moglem uzyc kazdego ale gdyby nie to co napisalem w 117 linijce to no.
                                Console.WriteLine("Witam godzina to" + stupidHuman.getTime() +"\n");
                                break;
                        }
                    }
                }
             
                catch (Exception)
                {
                    Console.WriteLine("Wystąpił błąd. Proszę spróbować ponownie.\n");
                }
            }
        }
    }

}