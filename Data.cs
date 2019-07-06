using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace http_exchange
{
    class Data
    {
        public static string ReturnData() // Метод для вывода даты
        {
            string data;
            string str = Http_Get.Get();
            data = str.Substring(str.Length - 12, 10);
            return data;
        }
    }
}
