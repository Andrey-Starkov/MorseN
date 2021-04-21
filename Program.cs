using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using VeryPerfectMorse;


namespace MorseN
{
    class Program
    {


        static void Main(string[] args)
        {
            string lang; //Русский или английский
            string f1 = @"D:\06.04\MorseN\bin\Debug\netcoreapp2.0\Input.txt";
            string f2 = @"D:\06.04\MorseN\bin\Debug\netcoreapp2.0\Output.txt";
            //string f3 = @"D:\06.04\MorseN\bin\Debug\netcoreapp2.0\Finale.txt";
            Console.WriteLine("RUS or ENG?");
            lang = Console.ReadLine();
            lang = lang.ToUpper();
            Morse morzeTranslate = new Morse(lang);
            Console.WriteLine(" 'In' Morse or 'Out' ");
            string choose;
            choose = Console.ReadLine();
            choose = choose.ToUpper();
             string   temp1 = "";
                using (StreamReader s = new StreamReader(f1, true))
                {
                    using (StreamWriter ff = new StreamWriter(f2))
                    {
                        while ((temp1 = s.ReadLine()) != null)
                        {
                        if (choose == "IN")
                        {
                            ff.WriteLine(morzeTranslate.Morz(temp1));//Перевод данного текста в азбуку морза
                        }
                        if (choose == "OUT")
                        {
                            ff.WriteLine(morzeTranslate.MorseReverse(temp1));//Обратный перевод из азбуки морза в текст
                        }
                        }
                    }
                }
        }
    }
}
    



