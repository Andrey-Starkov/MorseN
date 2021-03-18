using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MorseN
{
    class Morse
    {

        public static void Morz(string choose,string language)  //Метод, в котором происходит основная работа программы
        {
            string path_Output = @"C:\Users\andre\OneDrive\Рабочий стол\Morse\Output.txt";        // Путь к файлу, в котором будет хранится результат   
            string path_lang;
            if (language=="ENG")   //Выборя языка
            {
                path_lang = @"C:\Users\andre\OneDrive\Рабочий стол\Morse\Lang\ENG.txt";
            }
            else
            {
                path_lang = @"C:\Users\andre\OneDrive\Рабочий стол\Morse\Lang\RUS.txt";
            }

            Dictionary<string, string> languageMorse = new Dictionary<string, string> { [""] = "" };  //Пустая библиотека
            using (StreamReader f = new StreamReader(path_lang,true))  //Чтение экзампляра файла с помощью потоков
            {
                string key = ""; //Значение для библиотеки
                string value = ""; //Значение для библиотеки
                string s = ""; //Строка, с помощью которой мы проходим по файлу 
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
                    if (choose == "1") //В зависимости от того, хотим мы перевести из Морза или наоборт в Морзу зависит что в библиотеки будет слево, а что справо.
                    {
                        languageMorse.Add(value, key);
                    }
                    else { languageMorse.Add(key, value); }
                    key = "";
                    value = "";
                }
            }

            string result = "";
            if (choose == "1") //Перевод в азбуку Морза
            {
                string temp1 = "";
                string temp2="";
                temp1 = Console.ReadLine();
                try
                {
                    for (int i = 0; i < temp1.Length; i++)
                    {
                        temp2 += temp1[i];
                        result += languageMorse[temp2];
                        result += " ";
                        temp2 = "";
                    }
                }
                catch { }
            }
            else
            {
                // Перевод из азбуки Морза
                string temp1, temp2 = "";
                temp1 = Console.ReadLine();
                temp1 += " ";
                for (int i = 0; i < temp1.Length; i++)
                {
                    if (temp1[i] != ' ')
                    {
                        temp2 += temp1[i];
                    }
                    else
                    {
                        result += languageMorse[temp2];
                        temp2 = "";
                    }
                }
            }
            using (StreamWriter ff = new StreamWriter(path_Output, true)) //Вывод в файл
                ff.WriteLine(result);
        }
        static public void Morsee() //Интерфейс, выбор языка и режима
        {
            string choose,languache;
            Console.WriteLine("В азбуку Морза?\n 1 - Да \n 2 - Из азубки Морза");
            choose = Console.ReadLine();
            Console.WriteLine("Какой выберете язык?\n ENG - английский \n RUS - русский");
            languache = Console.ReadLine();
            Morz(choose,languache);
        }

    }

}

