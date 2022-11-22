using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets;

namespace Tickets
{
    public static class ContextDB
    {
        public static long ID;//Код записи

        public static string Fio;
        public static string Name;

        public static string find;
        //Права доступа
        public static string Right;
        //Описываем глобальную переменную для запроса
        public static IQueryable SQL;

        static Продажа_билетов_на_самолетEntities context;
        public static Продажа_билетов_на_самолетEntities GetContext()
        {
            if (context == null) context = new Продажа_билетов_на_самолетEntities();
            return context;
        }
    }
}
