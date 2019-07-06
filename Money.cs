using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace http_exchange
{
    class Money
    {
        public static List <string> Currect()  // Определяем возможные валюты
        {
            string str = Http_Get.Get(); ;
            string[] curr;
            curr = str.Split('"','{',':',',');   // Разделяем текст и создаем текстовый массив
            for (int i = 0; i < curr.Length; i++)  // Удаляем мусор из массива
            {
                if (curr[i].Length != 3)
                {
                    curr[i] = "";
                }
            }
            List<string> listValue = new List<string>();

            for (int i = 0; i < curr.Length; i++)  // Не пустые ячейки текстового массива загоняем в коллекцию (экономия памяти, длинна массива получалась 140, длинна списка 33)
            {
                if (curr[i] != "")
                {
                    listValue.Add(curr[i]);
                }
            }
            return listValue;

        }
        

    }
}
