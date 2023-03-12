using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common
{
    public sealed class FileLogging : ILogging // prevent inheritance
    {
        // Lazy<T>
        private static readonly Lazy<FileLogging> _lazyLogger
            = new Lazy<FileLogging>(() => new FileLogging());

        public static FileLogging Instance
        {
            get
            {
                return _lazyLogger.Value;

            }
        }

        protected FileLogging()
        {
        }

        /// <summary>
        /// SingletonOperation
        /// </summary> 

        public void LogException(string message)
        {
            string folderPath = string.Format( AppDomain.CurrentDomain.BaseDirectory + "Exceptions");
            DirectoryInfo di = Directory.CreateDirectory(folderPath);
            string fileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss", CultureInfo.InvariantCulture));
            string logFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory + "Exceptions", fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }        }

    }
}
