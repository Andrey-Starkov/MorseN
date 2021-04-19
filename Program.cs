using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace MorseN
{
    class Program
    {


        static void Main(string[] args)
        {
            string lang; //Русский или английский
            string f1 = @"F:\06.04\MorseN\bin\Debug\netcoreapp2.0\Input.txt";
            string f2 = @"F:\06.04\MorseN\bin\Debug\netcoreapp2.0\Output.txt";
            string f3 = @"F:\06.04\MorseN\bin\Debug\netcoreapp2.0\Finale.txt";
            Console.WriteLine("RUS or ENG?");
            lang = Console.ReadLine();
            lang.ToUpper();
            Mors.Morse morzeTranslate = new Mors.Morse(lang);
        //    morzeTranslate.printSOVIETSLOVar();//////////////////////////////////////////
           // if (lang == "ENG") { language = ENGL; language2 = ENGREVERSE; } else { language = RUSL; language2 = RUSReverse; }
            string temp1 = "";
            {
                using (StreamReader s = new StreamReader(f1, true))
                {
                    using (StreamWriter ff = new StreamWriter(f2))
                    {
                        while ((temp1 = s.ReadLine()) != null)
                        {
                            ff.WriteLine(morzeTranslate.Morz(temp1));
                        }
                    }
                }

                temp1 = "";
                using (StreamReader s = new StreamReader(f2, true))
                {
                    using (StreamWriter ff = new StreamWriter(f3))
                    {
                        while ((temp1 = s.ReadLine()) != null)
                        {
                            ff.WriteLine(morzeTranslate.MorseReverse( f2, f3, temp1));
                        }
                    }
                }
            }
        }
    }
}


