using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mors
{
 
    class Morse
    {
        public Dictionary<string, string> L = new Dictionary<string, string> { [""] = "" };
        public Dictionary<string, string> Reverse = new Dictionary<string, string> { [""] = "" };

   


        public Dictionary<string,string> RUS(Dictionary<string,string> RUSL)
        {
            string path_lang = @"D:\06.04\MorseN\bin\Debug\netcoreapp2.0\RUS.txt"; //Текстовый файл,в котором размещена библиотека языка
            using (StreamReader f = new StreamReader(path_lang,true))  //Чтение экзампляра файла с помощью потоков
            {
                string key = ""; //Значение для библиотеки
                string value = ""; //Значение для библиотеки
                string s = ""; //Строка, с помощью которой мы проходим по файлу 
                while ((s = f.ReadLine()) != null)
                {
                    int i = 0;
                    while (s[i] != ' ') //Доходит до пробела, в текстовике всё в формате *-(здесь пробел)A ,тоесть о считывает *- в key
                    {
                        key += s[i];
                        i++;
                    }
                    i++;
                    value += s[i]; //в value считывает второе значение в строчке, это один символ, поэтому мы можем просто считать символ от i
                    RUSL.Add(value, key); //В зависимости от того мы хотим переводить в или из Морза мы меняем value и key местами
                    key = "";
                    value = "";
                }

            }
            return RUSL; //Возвращате библиотеку
        }

        public static Dictionary<string, string> RUSLReverse(Dictionary<string, string> RUSL) //Все оставшиеся языки по аналогии с предыдущем
        {
            string path_lang = @"D:\06.04\MorseN\bin\Debug\netcoreapp2.0\RUS.txt";
            using (StreamReader f = new StreamReader(path_lang, true))  
            {
                string key = ""; 
                string value = ""; 
                string s = "";  
                while ((s = f.ReadLine()) != null)
                {
                    int i = 0;
                    while (s[i] != ' ')
                    {
                        key += s[i];
                        i++;
                    }
                    i++;
                    value += s[i];
                    RUSL.Add(key, value);


                    key = "";
                    value = "";
                }

            }
            return RUSL;
        }


        public static Dictionary<string, string> ENG(Dictionary<string, string> RUSL)
        {
            string path_lang = @"D:\06.04\MorseN\bin\Debug\netcoreapp2.0\ENG.txt";
            using (StreamReader f = new StreamReader(path_lang, true))  
            {
                string key = ""; 
                string value = ""; 
                string s = ""; 
                while ((s = f.ReadLine()) != null)
                {
                    int i = 0;
                    while (s[i] != ' ')
                    {
                        key += s[i];
                        i++;
                    }
                    i++;
                    value += s[i];
                    RUSL.Add(value, key);


                    key = "";
                    value = "";
                }

            }
            return RUSL;
        }

        public static Dictionary<string, string> ENGLReverse(Dictionary<string, string> RUSL) 
        {
            string path_lang = @"D:\06.04\MorseN\bin\Debug\netcoreapp2.0\ENG.txt";
            using (StreamReader f = new StreamReader(path_lang, true))  
            {
                string key = ""; 
                string value = ""; 
                string s = ""; 
                while ((s = f.ReadLine()) != null)
                {
                    int i = 0;
                    while (s[i] != ' ')
                    {
                        key += s[i];
                        i++;
                    }
                    i++;
                    value += s[i];
                    RUSL.Add(key, value);


                    key = "";
                    value = "";
                }

            }
            return RUSL;
        }


        public Morse(string lang)
        {
            if (lang == "RUS")
            {
                L = RUS(L);
                Reverse = RUSLReverse(Reverse);
            }
            else { 
            L = ENG(L);
            Reverse = ENGLReverse(Reverse);}
        }


       public void printSOVIETSLOVar() {////////////////////////////////////////////////////////////
            foreach (KeyValuePair<string, string> kvp in Reverse)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
}
        //public static Dictionary<string,string> Morsa(string lang,bool a) //Сюда загружаются все библиотеки языков, и выбирается язык
        //{
        public string Morz(string temp1)  //Перевод в азбуку Морза
        {
           // printSOVIETSLOVar();
            //string path_Output = @"D:\06.04\MorseN\bin\Debug\netcoreapp2.0\Output.txt";        // Путь к файлу, в котором будет хранится результат   
            //string f = @"D:\06.04\MorseN\bin\Debug\netcoreapp2.0\Input.txt"; //Путь к файлу из которого мы берём текст
            string result = "";
            // string temp1 = "";
          //  temp1.ToUpper();
            string temp2 = "";
            bool a = false; //Нужно чтоб определить, найден ли ненужный символ по типу запятой или нет)
            result = "";
            for (int i = 0; i < temp1.Length; i++)
            {
                temp1=temp1.ToUpper();
               // Console.WriteLine(temp1);
                char c = temp1[i];
                //Toupper(c);
                //Char.ToUpper(c);
                //Console.WriteLine();
                if (c == ' ') { result += " "; continue; } //Добавляет пробел, если был пробел в тексте, таким образом в переводе в Морзу будет 2 пробела перед следующим символом
                                                           // И мы сможем восстановить этот пробел из текста
                temp2 += c;
                try
                {
                    result += L[temp2];
                }
                catch
                {
                    temp2 = "";
                    a = true;
                }
                if (!a)
                //Мне просто нужно, чтобы при ошибке не добавлялось пробела, ради этого оно и сделано
                {
                    temp2 = "";
                    result += " ";
                }
                a = false;
            }
        //    Console.WriteLine(result);
            return result;
        }

        public string MorseReverse(string temp1) //Перевод из азбуки Морза
        {
            string result = "";
            string temp2 = "";
         //   printSOVIETSLOVar();
          //  Console.WriteLine("aa");
            {
                result = ""; //Переведённая в итоге строка
                temp1 += " "; //Данная нам строка в которую мы должны перевести из Азбуки Морза
                for (int i = 0; i < temp1.Length; i++)
                {
                    try
                    {
                        if (temp1[i] != ' ') //В Морзе между всеми символами пишется пробел
                        {
                            temp2 += temp1[i];
                        }
                        else
                        {
                            result += Reverse[temp2];
                            temp2 = "";
                            if ((temp1[i + 1] == ' ')) { result += " "; } //Если 2 пробела подряд, то он меняет это на пробел в переведённой строке
                        }
                    }
                    catch { }

                }
                temp1 = "";
            }
            //Console.WriteLine(result);
            return result;
        }

        //    Dictionary<string, string> ENGL = new Dictionary<string, string> { [""] = "" };
        //    Dictionary<string, string> ENGREVERSE = new Dictionary<string, string> { [""] = "" };

        //}

    }
}