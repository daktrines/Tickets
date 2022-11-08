using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19
{

    public static class Data
    {
        public static int КодПассажира;//Код записи
        //признак авторизации
        public static bool Login = false;
        public static string Fio;
        public static string Name;
        //Права доступа
        public static string Right;
        //Описываем глобальную переменную для запроса
        public static IQueryable SQL;
    }
}
