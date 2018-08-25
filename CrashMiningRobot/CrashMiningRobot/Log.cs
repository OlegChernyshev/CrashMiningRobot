using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CrashMiningRobot
{
    public class Log
    {
        StreamWriter writer;
        List<string> strings = new List<string>();

        /// <summary>
        /// Записывает логи программы в файл
        /// </summary>
        /// <param name="name">Название файла</param>
        public Log (string name)
        {
            writer = new StreamWriter(name);
        }

        /// <summary>
        /// Добавить запись в список
        /// </summary>
        /// <param name="str"></param>
        public void Add (string str)
        {
            strings.Add(str);
        }

        /// <summary>
        /// Отчистить список
        /// </summary>
        public void Clear ()
        {
            strings.Clear();
        }

        /// <summary>
        /// Записывает запись в логи
        /// </summary>
        public void Write ()
        {
            foreach (string str in strings)
                writer.Write(str);
            strings.Clear();
        }

        public void Close ()
        {
            writer.Close();
        }

        ~Log ()
        {
            writer.Close();
        }
    }
}
