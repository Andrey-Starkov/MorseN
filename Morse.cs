using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Morse
{
 
    class Morse
    {
        public static void Morz(Dictionary<string, string> RUSL,string lang)  //Перевод в азбуку Морза
        {
            string path_Output = @"Output.txt";        // Путь к файлу, в котором будет хранится результат   
            string f = @"Input.txt"; //Путь к файлу из которого мы берём текст
            string result = "";
            string temp1 = "";
            string temp2 = "";
            bool a = false; //Костыль, нужный чтоб определить, найден ли ненужный символ по типу запятой или нет)
            using (StreamReader s = new StreamReader(f, true))
            {
                while ((temp1 = s.ReadLine()) != null)
                {
                    Console.WriteLine(temp1);
                    result = "";
                    for (int i = 0; i < temp1.Length; i++)
                    {
                            char c = temp1[i];
                        if (lang == "ENG")   //Тут перевод из нижнего регистра в верхней
                        {
                            if ((c >= 'a') && (c <= 'z')) { c -= ' '; }
                        }
                        else if (c == 'ё') { c = 'Е'; }
                        else
                        if ((c >= 'а') && (c <= 'я')) { c -= ' '; }
                            if (c == ' ') { result += " "; continue; } //Добавляет пробел, если был пробел в тексте, таким образом в переводе в Морзу будет 2 пробела перед следующим символом
                            // И мы сможем восстановить этот пробел из текста
                            temp2 += c;
                        try
                        {
                            result += RUSL[temp2];
                        }
                        catch {
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
                    using (StreamWriter ff = new StreamWriter(path_Output, true)) //Вывод в файл
                        ff.WriteLine(result);
                }
            }
        }

        public static void MorseReverse(Dictionary<string, string> RUSL,string f,string path_Output) //Перевод из азбуки Морза
        {
            string result = "";
            string temp1 = "", temp2 = "";
            using (StreamReader s = new StreamReader(f, true)) {
                while ((temp1 = s.ReadLine()) != null){
                    result = ""; //Переведённая в итоге строка
                    temp1 += " "; //Данная нам строка в которую мы должны перевести из Азбуки Морза
                    for (int i = 0; i < temp1.Length; i++)
                    {
                       try
                       {
                            //   for (int i = 0; i < temp1.Length; i++)
                            //   {
                            if (temp1[i] != ' ') //В Морзе между всеми символами пишется пробел
                            {
                                temp2 += temp1[i];
                            }
                            else
                            {
                                result += RUSL[temp2];
                                temp2 = "";
                                if ((temp1[i + 1] == ' ')) { result += " "; } //Если 2 пробела подряд, то он меняет это на пробел в переведённой строке
                            }
                          }
                        catch { }
                    }
                    using (StreamWriter ff = new StreamWriter(path_Output, true)) //Вывод в файл
                        ff.WriteLine(result);
                }
                temp1 = "";
            }
        }
           public static Dictionary<string,string> RUS(Dictionary<string,string> RUSL)
        {
            string path_lang = @"RUS.txt"; //Текстовый файл,в котором размещена библиотека языка
            using (StreamReader f = new StreamReader(path_lang, true))  //Чтение экзампляра файла с помощью потоков
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
            string path_lang = @"RUS.txt";
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
            string path_lang = @"ENG.txt";
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
            string path_lang = @"ENG.txt";
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


        static public void Morsee() //Сюда загружаются все библиотеки языков, и выбирается язык
        {
           
            Dictionary<string, string> RUSL = new Dictionary<string, string> { [""] = "" };
            Dictionary<string, string> RUSReverse = new Dictionary<string, string> { [""] = "" };
            Dictionary<string, string> ENGL = new Dictionary<string, string> { [""] = "" };
            Dictionary<string, string> ENGREVERSE = new Dictionary<string, string> { [""] = "" };
            RUSL = RUS(RUSL); //Формирование библиотеки
            RUSReverse = RUSLReverse(RUSReverse);
            ENGL = ENG(ENGL);
            ENGREVERSE = ENGLReverse(ENGREVERSE);
            string choose; //Русский или английский
            Console.WriteLine("RUS or ENG?");
            choose = Console.ReadLine();
            if (choose == "ENG")
            {
                Morz(ENGL,choose); //Переводит сначала в Морзу в один файл, выводит из Морзы обратно в другой файл
                MorseReverse(ENGREVERSE, @"Output.txt", @"Finale.txt");
            }
            if (choose=="RUS")
            {
                Morz(RUSL,choose);
                MorseReverse(RUSReverse, @"Output.txt", @"Finale.txt");
            }
        }
    }
}