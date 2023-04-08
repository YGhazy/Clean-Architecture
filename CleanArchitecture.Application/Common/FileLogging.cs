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
    public class FileLogging : ILogging // prevent inheritance
    {
        // Lazy<T> This delays the cost of creating it till if/when it's needed instead of always incurring the cost.
        //add lock
        //or use static constructor
        private static readonly Lazy<FileLogging> _lazyLogger
            = new Lazy<FileLogging>(() => new FileLogging());

        public static FileLogging Instance
        {
            get
            {
                return _lazyLogger.Value;

            }
        }

        private FileLogging()
        {
        }

        /// <summary>
        /// SingletonOperation
        /// </summary> 

        public void LogException(string message)
        {
            string folderPath = Path.Combine(Environment.CurrentDirectory, "Logs");
            DirectoryInfo di = Directory.CreateDirectory(folderPath);
            string fileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            string logFilePath = Path.Combine(folderPath, fileName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }        }
        public void LogInformation(string message)
        {
            string folderPath = Path.Combine(Environment.CurrentDirectory, "Logs");
            DirectoryInfo di = Directory.CreateDirectory(folderPath);
            string fileName = string.Format("{0}_{1}.log", "Log", DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            string logFilePath = Path.Combine(folderPath, fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }

    }
}
