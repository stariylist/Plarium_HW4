using System;
using System.Collections.Generic;
using System.Text;

namespace task_A
{
    class Realization
    {
        public static void FindWord(string str, string word) // функция поиска слова в строке
        {
            string lowerStr = str.ToLower(); // переводим строку в нижний регистр
            string lowerWord = word.ToLower(); // для того, чтобы совпадали слова "кот" и "кОт"
            List<int> positions = new List<int>(); // контейнер для вхождений позиций подстроки в строку
            int index = lowerStr.IndexOf(lowerWord); // находим первое вхождение
            while (index != -1)
            {
                positions.Add(index); // заносим индекс в список
                index = lowerStr.IndexOf(lowerWord, index + lowerWord.Length);
            }
            int flag = 0; // флаг остановки вывода текста
            for (int i = 0; i < str.Length; i++)
            {
                if (positions.Contains(i))
                {

                    flag = i + lowerWord.Length; // считаем от начала поиска до длинны слова
                    Console.ForegroundColor = ConsoleColor.Green; // выделяем слово зеленым
                }
                Console.Write(str[i]);//вывод
                if (i == flag) // конец слова
                {
                    Console.ForegroundColor = ConsoleColor.White; // возвращаем тексту белый цвет
                }
            }
        }
        public static StringBuilder DeleteVerbs(string str) // функция удаления глаголов со строки
        {
            string[] endings = new string[] { "ете", "ут", "ите", "ат", "ишь", "ешь", "ить", "ать", "ять", "еть", "оть", "тся", "ться", "уть", "ишься", "ешься", "ит", "ет" }; // массив наиболее вероятных окончаний у глаголов
            StringBuilder strWithoutVerbs = new StringBuilder(); // создаем стринг билдер для новой строки без глаголов
            str = str.Replace(",", " ,");//сохраняем пробелы
            str = str.Replace(".", " .");
            string[] lowerStr = str.Split(' '); //сохраняем пробелы
            for (int i = 0; i < lowerStr.Length; i++) // проходим по всей строке
            {
                bool check = false; //флаг проверки
                for (int j = 0; j < endings.Length; j++) // проверяем по массиву окончаний
                {
                    if (lowerStr[i].EndsWith(endings[j]))// если находим окончание в слове
                    {
                        check = true; // меняем флаг
                    }
                }
                if (!check) // если мы не нашли общее окончание
                    strWithoutVerbs.Append(lowerStr[i] + " ");//добавляем слово в нашу строку
            }
            return strWithoutVerbs;//возвращаем строку
        }
        private static bool DoesFindSame(string word1, string word2, out int word1Begin, out int word1End, out int word2Begin, out int word2End) // булевая функция поиска общих частей слов
        {
            int lenghtWord1 = word1.Length; // длинна первого слова 
            int lenghtWord2 = word2.Length; // длинна второго слова
            int[,] array = new int[lenghtWord1, lenghtWord2]; // двумерный массив из длинн слов
            int maxMatch = 0; // максимальное число повторений в словах
            int max1 = 0; // индекс наибольшего совпадения первого слова
            int max2 = 0;// индекс наибольшего совпадения второго слова
            for (int i = 0; i < lenghtWord1; i++) // цикл для первого слова
            {
                for (int j = 0; j < lenghtWord2; j++) // цикл для второго слова
                {
                    if (word1[i] == word2[j]) // если текущие буквы равны
                    {
                        if (i == 0 || j == 0)
                        {
                            array[i, j] = 1;
                        }
                        else
                        {
                            array[i, j] = array[i - 1, j - 1] + 1;
                        }
                        if (array[i, j] > maxMatch) // сравниваем последовательность с максимальной
                        {
                            maxMatch = array[i, j];//присваиваем
                            max1 = i; // возвращаем для проверки первого слова
                            max2 = j; // возвращаем для проверки второго слова
                        }
                    }
                }
            }
            if (maxMatch < 2) // сбрасываем значения, если совпадений меньше, чем 2
            {
                word1Begin = 0;
                word1End = 0;
                word2Begin = 0;
                word2End = 0;
                return false;
            }
            else // если нашли больше совпадений
            {
                word1Begin = max1 + 1 - maxMatch; // начало совпадения первого
                word1End = maxMatch; // его длинна
                word2Begin = max2 + 1 - maxMatch;// начало совпадения первого
                word2End = maxMatch; // его длинна
                return true;
            }
        }
        private static void PrintWord(string word1, int word1Begin, int word1End) // вывод слов
        {
            int checkPrefix = 0; // для проверки на приставку
            for (int i = 0; i < word1.Length; i++) // проходим спосимвольно
            {
                if (i < word1Begin && checkPrefix == 0) // если совпадение больше 0, то есть приставка
                {
                    Console.Write(" Приставка: ");
                    checkPrefix++;
                }
                if (i == word1Begin) 
                    Console.Write(" Основание: "); // логика, как с приставкой, только здесь ==
                if (i == word1Begin + word1End) 
                    Console.Write(" Окончание: "); // аналогично, для окончания
                Console.Write(word1[i]);
            }
            Console.WriteLine();
        }
        public static void SeparateStr(string str) // делим слова на морфемы
        {
            int word1Begin = 0, word1End = 0, word2Begin = 0, word2End = 0; // ставим индексы в 0
            List<int> indexes = new List<int>();
            str = str.Replace(",", " ,");
            str = str.Replace(".", " .");
            string[] lowerStr = str.Split(' ');
            for (int i = 0; i < lowerStr.Length; i++) // проверяем слово
            {
                int repetitions = 0; // флаг повторений слов
                for (int j = 0; j < lowerStr.Length; j++)
                {
                    if (i == j || indexes.Contains(i) || indexes.Contains(j)) 
                        continue; // скип, если то же слово
                    if (DoesFindSame(lowerStr[i], lowerStr[j], out word1Begin, out word1End, out word2Begin, out word2End)) // вызов метода поиска общих частей
                    {
                        if (repetitions == 0) // если не было повторений 
                        {
                            PrintWord(lowerStr[i], word1Begin, word1End);
                            PrintWord(lowerStr[j], word2Begin, word2End);
                            repetitions++;
                        }
                        else
                        {
                            PrintWord(lowerStr[j], word2Begin, word2End); // для повторений выводим только 1 слово
                        }
                        indexes.Add(j);
                    }
                }
                indexes.Add(i);
            }
        }
    }
}